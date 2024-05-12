using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace Gear_Builder_VKR
{
    public partial class CalculateStory : Form
    {
        public int? selectedRowIndex = null;
        ModelRebuilder modelRebuilder = new ModelRebuilder();
        private ToolTip toolTip = new ToolTip();


        public CalculateStory()
        {
            InitializeComponent();
            PopulateTableLayoutPanel();
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

        }

        private void AdjustColumnWidths()
        {
            int[] maxWidths = new int[headers.Length];

            // Инициализация массива максимальной ширины
            for (int i = 0; i < headers.Length; i++)
            {
                maxWidths[i] = TextRenderer.MeasureText(headers[i], new Font("Arial", 12, FontStyle.Bold)).Width;
            }

            // Расчет максимальной ширины на основе данных
            foreach (var calculation in GlobalData.Calculations)
            {
                PropertyInfo[] properties = calculation.GetType().GetProperties();
                for (int i = 0; i <= 16; i++)
                {
                    string text = properties[i].GetValue(calculation)?.ToString();
                    int textWidth = TextRenderer.MeasureText(text, new Font("Arial", 12)).Width;
                    if (textWidth > maxWidths[i])
                    {
                        maxWidths[i] = textWidth;
                    }
                }
            }

            // Установка ширины столбцов
            tableLayoutPanel1.ColumnStyles.Clear();
            for (int i = 0; i < headers.Length; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, maxWidths[i] + 10)); // Добавляем небольшой отступ
            }
        }

        public string[] headers = { "","N", "n1", "n2", "M", "U", "z1", "z2", "t_r",
            "t_f", "A_r", "A_f", "La", "da1", "da2", "d1", "d2" };
        public string[] tooltips = {"","Передаваемая мощность", "Частота вращения n1", "Частота вращения n2",
            "Крутящий момент", "Передаточное число", "Число зубьев зведочки z1", "Число зубьев зведочки z2", "Расчетный" +
                " шаг цепи", "Финальный шаг цепи",
            "Предварительное межосевое расстояние", "Расчетное межосевое расстояние", "Длина цепи (в шагах)", "Диаметр вершины звездочки da1",
            "Диаметр вершины звездочки da2", "Делительный диаметр звездочки d1","Делительный диаметр звездочки d2" };

        private void PopulateTableLayoutPanel()
        {
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            // Добавляем заголовки столбцов
            for (int columnIndex = 0; columnIndex < headers.Length; columnIndex++)
            {
                Label headerLabel = new Label
                {
                    Text = headers[columnIndex],
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Font = new Font("Arial", 11, FontStyle.Bold),
                };
                tableLayoutPanel1.Controls.Add(headerLabel, columnIndex, 0);
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                toolTip.SetToolTip(headerLabel, tooltips[columnIndex]);
            }

            // Добавляем данные расчетов
            int rowIndex = 1;
            foreach (var calculation in GlobalData.Calculations)
            {
                tableLayoutPanel1.RowCount++;
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                AddCalculationRow(calculation, rowIndex++);
            }

            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            label2.Visible = GlobalData.Calculations.Count > 0 ? false : true;
            tableLayoutPanel1.Location = new Point(18, 60);

            tableLayoutPanel1.ResumeLayout(); // Возобновляем отрисовку
            AdjustColumnWidths();
            AdjustFormSize();
        }

        private void AddCalculationRow(ChainDriveCalculation calculation, int rowIndex)
        {
            Label numberLabel = new Label
            {
                Text = rowIndex.ToString(),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 9, FontStyle.Regular)
            };
            tableLayoutPanel1.Controls.Add(numberLabel, 0, rowIndex); // Добавляем номер строки в первый столбец

            // Список свойств для отображения в таблице
            string[] displayedProperties = { "Nn", "N1", "N2", "M", "U", "Z1", "Z2", "T", "TFin", "A", "Af", "La", "Da1", "Da2", "D1", "D2" };

            // Получаем свойства объекта через рефлексию
            PropertyInfo[] properties = calculation.GetType().GetProperties()
                .Where(prop => displayedProperties.Contains(prop.Name)) // Фильтруем только те свойства, которые есть в списке
                .ToArray();

            for (int columnIndex = 0; columnIndex < properties.Length; columnIndex++)
            {
                PropertyInfo propInfo = properties[columnIndex];
                // Создаем и настраиваем Label для каждого свойства
                Label label = new Label
                {
                    Text = propInfo.GetValue(calculation)?.ToString(),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 9, FontStyle.Regular)
                };
                label.Click += Label_Click;
                label.Tag = rowIndex; // Сохраняем индекс строки в Tag

                // Добавляем Label в таблицу, учитывая что первый столбец занят номером строки
                tableLayoutPanel1.Controls.Add(label, columnIndex + 1, rowIndex);
            }
        }

        private void Label_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;
            int rowIndex = (int)label.Tag;
            HighlightRow(rowIndex);
            selectedRowIndex = rowIndex;
        }

        private void HighlightRow(int rowIndex)
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                if (control.Tag != null && (int)control.Tag == rowIndex)
                {
                    control.BackColor = Color.LightBlue;
                }
                else
                {
                    control.BackColor = Color.White;
                }
            }
        }

        private void AdjustFormSize()
        {
            Size tablePreferredSize = tableLayoutPanel1.GetPreferredSize(new Size(0, 0));
            this.Width = tablePreferredSize.Width + 40;
            this.Height = tablePreferredSize.Height + 200;
            this.AutoScroll = false;
        }



        private void btnSaveSelectedRow_Click_1(object sender, EventArgs e)
        {
            if (selectedRowIndex.HasValue && selectedRowIndex.Value > 0) // 
            {
                ChainDriveCalculation selectedCalculation = GlobalData.Calculations[selectedRowIndex.Value - 1];
                modelRebuilder.RebuildModel(selectedCalculation);

            }
            else { MessageBox.Show("Выберите строку"); }
        }

        private void CalculateStory_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveCalculationToFile();
        }
        private void SaveCalculationToFile()
        {
            if (selectedRowIndex == null)
            {
                MessageBox.Show("Пожалуйста, выберите строку для сохранения.");
                return;
            }

            ChainDriveCalculation selectedCalculation = GlobalData.Calculations[selectedRowIndex.Value-1];
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\CalculationResults.txt";

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Передаваемая мощность (N) - " + selectedCalculation.Nn +" кВт");
                writer.WriteLine("Число оборотов ведущей звездочки (n1) - " + selectedCalculation.N1);
                writer.WriteLine("Число оборотов ведомой звездочки (n2) - " + selectedCalculation.N2);
                writer.WriteLine("Крутящий момент (M) - " + selectedCalculation.M + " Н*м");
                writer.WriteLine("Передаточное число (U) - " + selectedCalculation.U);
                writer.WriteLine("Число звеньев ведущей звездочки (z1) - " + selectedCalculation.Z1);
                writer.WriteLine("Число звеньев ведомой звездочки (z2) - " + selectedCalculation.Z2);
                writer.WriteLine("Типоразмер цепи - ПР-" + selectedCalculation.TFin+"-"+selectedCalculation.Rn);
                writer.WriteLine("Делительный диаметр ведущей звездочки (d1) - " + selectedCalculation.D1+ " мм");
                writer.WriteLine("Делительный диаметр ведомой звездочки (d2) - " + selectedCalculation.D2 + " мм");
                writer.WriteLine("Диаметр вершины ведущей звездоки (da1) - " + selectedCalculation.Da1 + " мм");
                writer.WriteLine("Диаметр вершины ведомой звездоки (da2) - " + selectedCalculation.Da2 + " мм");
                writer.WriteLine("Межосевое расстояние - " + selectedCalculation.Af + " мм");
                writer.WriteLine("Угол наклона оси - " + selectedCalculation.A1);


                writer.WriteLine("Угол наклона (α) - " + selectedCalculation.A1);
                // Таким образом добавляете все переменные класса
            }

            MessageBox.Show("Результаты расчёта сохранены на рабочий стол: " + filePath);
        }
    }
}