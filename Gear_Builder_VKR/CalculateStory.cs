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

namespace Gear_Builder_VKR
{
    public partial class CalculateStory : Form
    {
        private int? selectedRowIndex = null;
        ModelRebuilder modelRebuilder = new ModelRebuilder();

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
                for (int i = 0; i < 16; i++)
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
                    Font = new Font("Arial", 12, FontStyle.Bold),
                };
                tableLayoutPanel1.Controls.Add(headerLabel, columnIndex, 0);
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
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
            AdjustFormSize();
        }

        private void AddCalculationRow(ChainDriveCalculation calculation, int rowIndex)
        {
            Label numberLabel = new Label
            {
                Text = rowIndex.ToString(),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 12, FontStyle.Regular)
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
                    Font = new Font("Arial", 12, FontStyle.Regular)
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
            this.Width = tablePreferredSize.Width - 40;
            this.Height = tablePreferredSize.Height + 200;
            this.AutoScroll = false;
        }

        

        private void btnSaveSelectedRow_Click_1(object sender, EventArgs e)
        {
            if (selectedRowIndex.HasValue && selectedRowIndex.Value > 0) // 
            {
                ChainDriveCalculation selectedCalculation = GlobalData.Calculations[selectedRowIndex.Value - 1]; 
                MessageBox.Show("Подождите, цепная передача перестраивается");
                modelRebuilder.RebuildModel(selectedCalculation);

            }
            else { MessageBox.Show("Выберите строку"); }
        }

        private void CalculateStory_Load(object sender, EventArgs e)
        {

        }
    }
}