using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ComboBox;
using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;
using KAPITypes;
using KompasAPI7;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Gear_Builder_VKR
{

    public partial class Form1 : Form
    {

        double nn, n1, n2, m, u, z1, z2, t, t_fin, a, af, La, da1, da2, d1, d2;
        double[] chainstep = { 8.0, 9.525, 12.7, 15.875, 19.05, 25.4, 31.75, 38.1, 44.45, 50.8, 63.5 };
        string folderPath;
        int number = 1;
        ModelRebuilder modelRebuilder = new ModelRebuilder();
        DateTime now = DateTime.Now;

        ModelUpdater modelUpdater = new ModelUpdater();



        private System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();

        private void button5_Click(object sender, EventArgs e)
        {
            AdditionalParameters additionalParameters = new AdditionalParameters();
            additionalParameters.Show();
        }

        private void ChoiseType_DropDown(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox comboBox = sender as System.Windows.Forms.ComboBox;
            if (ChoiseType != null)
            {
                for (int i = 0; i < ChoiseType.Items.Count; i++)
                {
                    string itemText = ChoiseType.GetItemText(ChoiseType.Items[i]);
                    // Установка текста в Tooltip
                    if (itemText.Length > 50)
                    {
                        itemText = itemText.Substring(0, 50) + "...";
                    }
                    toolTip.SetToolTip(ChoiseType, itemText);
                }
            }
        }

        private void ChoiseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox[] textBoxes = { power, frequency1, frequency2, gearratio, torgue, linksnumber1, linksnumber2, step };
            switch (ChoiseType.SelectedIndex)
            {
                case 0:
                    foreach (var textBox in textBoxes)
                    {
                        textBox.Enabled = false;
                    }
                    break;
                case 1:
                    power.Enabled = true;
                    frequency1.Enabled = true;
                    frequency2.Enabled = true;
                    gearratio.Enabled = false;
                    torgue.Enabled = false;
                    linksnumber1.Enabled = false;
                    linksnumber2.Enabled = false;
                    break;
                case 2:
                    power.Enabled = true;
                    frequency1.Enabled = true;
                    frequency2.Enabled = false;
                    gearratio.Enabled = true;
                    torgue.Enabled = true;
                    linksnumber1.Enabled = false;
                    linksnumber2.Enabled = false;
                    break;
                case 3:
                    power.Enabled = true;
                    frequency1.Enabled = true;
                    frequency2.Enabled = true;
                    gearratio.Enabled = true;
                    torgue.Enabled = true;
                    linksnumber1.Enabled = true;
                    linksnumber2.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CalculateStory calculateStory = new CalculateStory();
            calculateStory.Show();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Operating_condition operating_Condition = new Operating_condition();
            operating_Condition.ShowDialog();

        }

        double ke = 1.79;
        double p0 = 20;
        double deg = Math.PI / 180.0;

        KompasObject kompas;
        ksDocument3D kompas_document_3D;
        ksVariableCollection varcoll;
        ksPart kPart;

        private void label14_Click(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();
            ChoiseType.SelectedIndex = 0;


            System.Windows.Forms.TextBox[] textBoxes = { power, frequency1, frequency2, gearratio, torgue, linksnumber1, linksnumber2, step };

            foreach (var textBox in textBoxes)
            {
                textBox.Enabled = false;
            }

            try
            {
                kompas = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5"); // Подключаемся к КОМПАС-3D
                if (kompas != null)
                {
                    kompas_document_3D = (ksDocument3D)kompas.ActiveDocument3D(); // Получаем интерфейс активной 3D детали
                    if (kompas_document_3D != null)
                    {
                        ksPart kPart = kompas_document_3D.GetPart((int)Part_Type.pTop_Part); // Получаем интерфейс ksPart
                        if (kPart != null)
                        {
                            varcoll = kPart.VariableCollection(); // Получаем массив переменных
                            varcoll.refresh(); // Обновляем массив переменных
                        }
                        else
                        {
                            MessageBox.Show("Ошибка: Не удалось получить интерфейс ksPart.", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ошибка: Не удалось получить активный документ 3D.", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка: Не удалось подключиться к КОМПАС-3D.", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (COMException ex)
            {
                MessageBox.Show($"Приложение КОМПАС-3D не запущено", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неизвестная ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void build_btn_click(object sender, EventArgs e)
        {
            if (GlobalData.FolderPath == null)
            {
                using (FolderSelectionForm form = new FolderSelectionForm())
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Построение отменено пользователем.");
                        return;
                    }
                }
            }



            modelRebuilder.RebuildModel(GlobalData.Calculations[GlobalData.Calculations.Count - 1]);
            //Dictionary<string, double> parametersToUpdate = new Dictionary<string, double>
            //{
            //    {"t", 19.05}
            //};
            //modelUpdater.UpdateComponentParameters(parametersToUpdate);

        }

        private double ConvertValue(System.Windows.Forms.TextBox textBox, CultureInfo ci)
        {
            return !string.IsNullOrWhiteSpace(textBox.Text) ? Convert.ToDouble(textBox.Text.Replace('.', ','), ci) : 0.0;
        }

        private bool ValidateInput(System.Windows.Forms.TextBox textBox, string errorMessage, bool isActive)
        {
            if (isActive)
                return true;

            // Использование CultureInfo.InvariantCulture для обработки чисел с точкой как десятичного разделителя
            if (!double.TryParse(textBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double value) || value <= 0)
            {
                MessageBox.Show(errorMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void calculate_btn_click(object sender, EventArgs e)
        {
            bool isPowerActive = !power.Enabled;
            bool isFrequency1Active = !frequency1.Enabled;
            bool isFrequency2Active = !frequency2.Enabled;
            bool isGerratioActive = !gearratio.Enabled;
            bool isLinksNumber1Active = !linksnumber1.Enabled;
            bool isLinksNumber2Active = !linksnumber2.Enabled;
            bool isStepActive = !step.Enabled;

            if (ChoiseType.SelectedIndex == 0)
            {
                MessageBox.Show("Выберите тип расчета", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateInput(power, "Передаваемая мощность не может быть отрицательной или нулевой", isPowerActive) ||
                !ValidateInput(frequency1, "Частота вращения не может быть отрицательной или нулевой", isFrequency1Active) ||
                !ValidateInput(frequency2, "Частота вращения не может быть отрицательной или нулевой", isFrequency2Active) ||
                !ValidateInput(gearratio, "Передаточное число не может быть отрицательным или нулевым", isGerratioActive) ||
                !ValidateInput(linksnumber1, "Число звеньев не может быть отрицательным или нулевым", isLinksNumber1Active) ||
                !ValidateInput(linksnumber2, "Число звеньев не может быть отрицательным или нулевым", isLinksNumber2Active) ||
                !ValidateInput(step, "Шаг цепи не может быть отрицательным или нулевым", isStepActive))
            {
                return;
            }

            CultureInfo ci = new CultureInfo("ru-RU");
            double nn = ConvertValue(power, ci);
            double n1 = ConvertValue(frequency1, ci);
            double n2 = ConvertValue(frequency2, ci);
            double u = ConvertValue(gearratio, ci);
            double m = ConvertValue(torgue, ci);
            double z1 = ConvertValue(linksnumber1, ci);
            double z2 = ConvertValue(linksnumber2, ci);

            if (nn > 0.0 && n1 > 0.0)
            {
                m = Math.Round(9550 * (nn / n1), 2);
                u = Math.Round(n1 / n2, 2);

                z1 = Math.Floor(29 - 2 * u);
                z1 -= z1 % 2 == 0 ? 1 : 0;

                z2 = Math.Floor(z1 * u);
                z2 -= z2 % 2 == 1 ? 1 : 0;

                double t = 28 * Math.Pow(m * ke / (Math.Abs(z1) * p0), 1.0 / 3.0);
                double t_fin = chainstep[0];
                foreach (double pitch in chainstep)
                {
                    if (t >= pitch) t_fin = pitch;
                    else break;
                }

                double d1 = t_fin / Math.Sin(deg * 180 / z1);
                double d2 = t_fin / Math.Sin(deg * 180 / z2);
                double da1 = t_fin * (0.5 + 1 / Math.Tan(deg * 180 / z1));
                double da2 = t_fin * (0.5 + 1 / Math.Tan(deg * 180 / z2));
                double a = 40 + (da1 + da2) / 2;
                double La = 2 * a / t + (z1 + z2) / 2 + Math.Pow((z2 - z1), 2) / (2 * 3.14) * t / a;
                La = Math.Round(La);
                La -= La % 2 == 1 ? 1 : 0;

                double af = t_fin / 4 * (La - ((z1 + z2) / 2) + Math.Sqrt(Math.Pow(La - ((z1 + z2) / 2), 2) - (8 * Math.Pow((z2 - z1) / (2 * 3.14), 2))));

                GlobalData.Calculations.Add(new ChainDriveCalculation
                {
                    Nn = Math.Round(nn, 2),
                    N1 = Math.Round(n1, 2),
                    N2 = Math.Round(n2, 2),
                    M = m,
                    U = u,
                    Z1 = z1,
                    Z2 = z2,
                    T = Math.Round(t, 2),
                    TFin = t_fin,
                    A = Math.Round(a, 2),
                    Af = Math.Round(af, 2),
                    La = La,
                    Da1 = Math.Round(da1, 2),
                    Da2 = Math.Round(da2, 2),
                    D1 = Math.Round(d1, 2),
                    D2 = Math.Round(d2, 2)
                });

                build_btn.Enabled = true;

                DateTime now = DateTime.Now;
                string timeString = now.ToString("HH:mm:ss");
                richTextBox1.Text += $"{timeString} :Расчет №{number} выполнен \n";
                number++;
            }
        }
    }
}
