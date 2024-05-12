using Kompas6API5;
using Kompas6Constants3D;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gear_Builder_VKR
{
    public partial class AdditionalParameters : Form
    {
        public AdditionalParameters()
        {
            InitializeComponent();
            this.Size = new Size(560, 320);
            textBox1.Text = GlobalParameters.InitialCenterDistance.ToString();
            textBox2.Text = GlobalParameters.InclineAngle.ToString();
            label3.Text = "A_min = 0,6*(De1 + De2) + 30÷50мм \nA_max=80*t";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double result))
            {
                GlobalParameters.InitialCenterDistance = result;
            }
            else if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Ошибка: Неверное значение для межосевого расстояния.");
                return;
            }

            if (double.TryParse(textBox2.Text, out double inclineAngle))
            {
                GlobalParameters.InclineAngle = inclineAngle;
            }
            else
            {
                MessageBox.Show("Ошибка: Неверное значение угла наклона.");
                return;
            }

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (GlobalData.Calculations.Count > 0)
            {
                double de1 = GlobalData.Calculations[GlobalData.Calculations.Count - 1].Da1;
                double de2 = GlobalData.Calculations[GlobalData.Calculations.Count - 1].Da2;
                double tFin = GlobalData.Calculations[GlobalData.Calculations.Count - 1].TFin;

                double minA = Math.Ceiling(0.6 * (de1 + de2) + 40);
                double maxA = Math.Ceiling(80 * tFin);

                if (tFin != 0)
                {
                    label3.Text = $"> {minA}";
                    label3.ForeColor = Color.Black;

                    double userInput;
                    bool isValidInput = double.TryParse(textBox1.Text, out userInput);

                    if (isValidInput)
                    {
                        if (userInput < minA)
                        {
                            label3.ForeColor = Color.Red;
                            label3.Text = $"< {minA}";
                            button1.Enabled = false;
                        }
                        else { label3.ForeColor = Color.Green; button1.Enabled = true; }
                        if (userInput > maxA)
                        {
                            label3.ForeColor = Color.Red;
                            label3.Text = $"> {maxA}";
                            button1.Enabled = false;
                        }

                    }
                    else
                    {
                        label3.Text = "Please enter a valid number.";
                        label3.ForeColor = Color.Black;
                    }
                }
                else { label3.Text = $"A_min = 0.6*(De1 + De2) + 30÷50mm \nA_max=80*t"; }
            }
            else
            { label3.Text = $"A_min = 0.6*(De1 + De2) + 30÷50mm \nA_max=80*t"; }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label3.Visible = true;
            button3.Visible = false;
            textBox1.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label3.Visible = false;
            button3.Visible = true;
            textBox1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Откройте документ в Компас-3D, в котором необходимо измерить межосеовое расстояние. \n\n" +
                "Для этого выберите две цилиндричекие поверхности (через Ctrl) и нажмите ОК ","Внимание!",MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }
      
            {
                try
                {
                    KompasObject kompas = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
                    if (kompas == null)
                    {
                        MessageBox.Show("КОМПАС-3D не запущен");
                        return;
                    }

                    ksDocument3D kompas_document_3D = (ksDocument3D)kompas.ActiveDocument3D();
                    if (kompas_document_3D == null)
                    {
                        MessageBox.Show("Не открыта деталь в КОМПАС-3D.");
                        return;
                    }

                    ksPart kPart = kompas_document_3D.GetPart((int)Part_Type.pTop_Part);
                    if (kPart == null)
                    {
                        MessageBox.Show("Не удалось получить активную часть.");
                        return;
                    }

                    ksSelectionMng select = (ksSelectionMng)kompas_document_3D.GetSelectionMng();
                    if (select == null)
                    {
                        MessageBox.Show("Не удалось инициализировать менеджер выбора.");
                        return;
                    }

                    var a = select.First();
                    var b = select.Last();
                    if (a == null || b == null)
                    {
                        MessageBox.Show("Необходимо выбрать две грани.");
                        return;
                    }

                    ksMeasurer measurer = (ksMeasurer)kPart.GetMeasurer();
                    if (measurer == null)
                    {
                        MessageBox.Show("Не удалось инициализировать инструмент измерения.");
                        return;
                    }

                    measurer.SetObject1(a);
                    measurer.SetObject2(b);
                    measurer.Calc();
                    double res = measurer.NormalDistance;

                    textBox1.Text = Convert.ToString(res);
                }
                catch (COMException ex)
                {
                    MessageBox.Show($"Ошибка COM: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Сброс настроек
            textBox1.Clear();
            textBox2.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void AdditionalParameters_Load(object sender, EventArgs e)
        {
            // Загрузка сохраненных значений при открытии формы
            textBox1.Text = GlobalParameters.InitialCenterDistance.ToString();
            textBox2.Text = GlobalParameters.InclineAngle.ToString();
            if (radioButton1.Checked ) { } else { textBox1.Enabled = false; }
        }

        public static class GlobalParameters
        {
            public static double InitialCenterDistance { get; set; } = 0;
            public static double InclineAngle { get; set; } = 0;
        }
    }
}