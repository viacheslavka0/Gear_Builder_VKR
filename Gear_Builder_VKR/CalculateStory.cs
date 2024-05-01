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

        private void PopulateTableLayoutPanel()
        {
            tableLayoutPanel1.SuspendLayout();  // Останавливаем отрисовку

            // Определение заголовков столбцов
            string[] headers = { "Передаваемая мощность", "N1", "N2", "M", "U", "Z1", "Z2", "T", "TFin", "A", "Af", "La", "Da1", "Da2", "D1", "D2" };

            // Сначала очищаем все, кроме заголовков
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            // Добавляем заголовки столбцов
            for (int columnIndex = 0; columnIndex < headers.Length; columnIndex++)
            {
                Label headerLabel = new Label
                {
                    Text = headers[columnIndex],
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                };
                tableLayoutPanel1.Controls.Add(headerLabel, columnIndex, 0);
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
            tableLayoutPanel1.ResumeLayout(); // Возобновляем отрисовку
            AdjustFormSize();
        }

        private void AddCalculationRow(ChainDriveCalculation calculation, int rowIndex)
        {
            PropertyInfo[] properties = calculation.GetType().GetProperties();
            for (int columnIndex = 0; columnIndex < properties.Length; columnIndex++)
            {
                PropertyInfo propInfo = properties[columnIndex];
                Label label = new Label { Text = propInfo.GetValue(calculation).ToString(), Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter };
                label.Click += Label_Click;
                label.Tag = rowIndex;  // Сохраняем индекс строки в Tag
                tableLayoutPanel1.Controls.Add(label, columnIndex, rowIndex);
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
                // Проверка на null перед попыткой приведения Tag к int
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
            this.Width = tablePreferredSize.Width + 20;
            this.Height = 600;
            this.AutoScroll = true;
        }

        

        private void btnSaveSelectedRow_Click_1(object sender, EventArgs e)
        {
            if (selectedRowIndex.HasValue && selectedRowIndex.Value > 0) // Проверяем, что строка выбрана
            {
                ChainDriveCalculation selectedCalculation = GlobalData.Calculations[selectedRowIndex.Value - 1]; // -1 потому что первая строка - заголовки
                MessageBox.Show("Подождите, цепная передача перестраивается");
                modelRebuilder.RebuildModel(selectedCalculation);

            }
        }
    }
}