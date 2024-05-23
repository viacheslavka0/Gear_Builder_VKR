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
using System.Diagnostics;
using stdole;

namespace Gear_Builder_VKR
{

    public partial class Form1 : Form
    {

        double nn, n1, n2, m, u, z1, z2, t, t_fin, a, af, La, da1, da2, d1, d2;
        double[] chainstep = { 8.0, 9.525, 12.7, 15.875, 19.05, 25.4, 31.75, 38.1, 44.45, 50.8, 63.5 };
        string folderPath;
        int number = 1;

        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//Приводная роликовая цепь";



        double p0 = 20;
        double deg = Math.PI / 180.0;

        KompasObject kompas;
        ksDocument3D kompas_document_3D;
        ksVariableCollection varcoll;
        ksPart kPart;

        ModelRebuilder modelRebuilder = new ModelRebuilder();
        DateTime now = DateTime.Now;



        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conditions.K1 = 1.3;
            conditions.K2 = 1;
            conditions.K3 = 1.5;
            conditions.K4 = 1;

            textBox1.Text = filePath;
        }

        ModelUpdater modelUpdater = new ModelUpdater();

        OperationConditions conditions = new OperationConditions();

        private System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();

        private void button1_Click_1(object sender, EventArgs e)
        {

            using (FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog())
            {
                folderBrowserDialog1.Description = "Выберите папку для сохранения файлов";
                folderBrowserDialog1.ShowNewFolderButton = true;  // Опционально, позволяет создавать новую папку в диалоге

                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
                {
                    filePath = folderBrowserDialog1.SelectedPath;
                    textBox1.Text = folderBrowserDialog1.SelectedPath;
                }
            }
        }

        double currentDistance = AdditionalParameters.GlobalParameters.InitialCenterDistance;
        double currentAngle = AdditionalParameters.GlobalParameters.InclineAngle;

        AdditionalParameters additionalParameters = new AdditionalParameters();

        private void button5_Click(object sender, EventArgs e)
        {
            if (additionalParameters.IsDisposed)
            {
                additionalParameters = new AdditionalParameters();
            }
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

            //try
            //{
            //    kompas = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5"); // Подключаемся к КОМПАС-3D
            //    if (kompas != null)
            //    {
            //        kompas_document_3D = (ksDocument3D)kompas.ActiveDocument3D(); // Получаем интерфейс активной 3D детали
            //        if (kompas_document_3D != null)
            //        {
            //            ksPart kPart = kompas_document_3D.GetPart((int)Part_Type.pTop_Part); // Получаем интерфейс ksPart
            //            if (kPart != null)
            //            {
            //                varcoll = kPart.VariableCollection(); // Получаем массив переменных
            //                varcoll.refresh(); // Обновляем массив переменных
            //            }
            //            else
            //            {
            //                MessageBox.Show("Ошибка: Не удалось получить интерфейс ksPart.", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("Ошибка: Не удалось получить активный документ 3D.", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Ошибка: Не удалось подключиться к КОМПАС-3D.", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //catch (COMException ex)
            //{
            //    MessageBox.Show($"Приложение КОМПАС-3D не запущено", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Неизвестная ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        private void build_btn_click(object sender, EventArgs e)
        {
            //if (GlobalData.FolderPath == null)
            //{
            //    using (FolderSelectionForm form = new FolderSelectionForm())
            //    {
            //        if (form.ShowDialog() == DialogResult.OK)
            //        {

            //        }
            //        else
            //        {
            //            MessageBox.Show("Построение отменено пользователем.");
            //            return;
            //        }
            //    }
            //}




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
        bool resultFirstClick = true;
        private void calculate_btn_click(object sender, EventArgs e)
        {

            bool isPowerActive = !power.Enabled;
            bool isFrequency1Active = !frequency1.Enabled;
            bool isFrequency2Active = !frequency2.Enabled;
            bool isGerratioActive = !gearratio.Enabled;
            bool isLinksNumber1Active = !linksnumber1.Enabled;
            bool isLinksNumber2Active = !linksnumber2.Enabled;
            bool isStepActive = !step.Enabled;

            double currentDistance = AdditionalParameters.GlobalParameters.InitialCenterDistance;
            double currentAngle = AdditionalParameters.GlobalParameters.InclineAngle;

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

            double k1 = conditions.K1;
            double k2 = conditions.K2;
            double k3 = conditions.K3;
            double k4 = conditions.K4;

            double ke = k1 * k2 * k3 * k4;
           
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
                for (int i = 0; i < chainstep.Length; i++)
                {
                    if (chainstep[i] > t)
                    {
                        t_fin = chainstep[i];
                        break; // Прерываем цикл, так как нашли первое значение больше t
                    }
                }

                double d1 = t_fin / Math.Sin(deg * 180 / z1);
                double d2 = t_fin / Math.Sin(deg * 180 / z2);

                var stepData = ChainStepData.GetChainStepData(t_fin);
                double b1, d1_, d4_, b7, h1_, d3_, rn;

                    // Присваиваем значения из stepData
                    b1 = stepData.B1;
                    d1_ = stepData.D1;
                    d4_ = stepData.D4;
                    b7 = stepData.B7;
                    h1_ = stepData.H1;
                    d3_ = stepData.D3;
                    rn = stepData.Rn;

                double delta = t_fin/d4_;
                double K=0.5;
                if (delta >= 1.4 || delta < 1.5) K = 0.48;
                if (delta >= 1.5 || delta < 1.5) K = 0.532;
                if (delta >= 1.6 || delta < 1.7) K = 0.555;
                
                double da1 = t_fin * (K + 1 / Math.Tan(deg * 180 / z1));
                double da2 = t_fin * (K + 1 / Math.Tan(deg * 180 / z2));

                if (currentDistance > 0)
                {
                    a = currentDistance;
                }
                else
                {
                    a = 40 + (da1 + da2) / 2;
                }
                double a1;
                if (currentAngle > 0)
                {
                    a1 = currentAngle;
                }
                else { a1 = 0; }


                double La = 2 * a / t + (z1 + z2) / 2 + Math.Pow((z2 - z1), 2) / (2 * 3.14) * t / a;
                La = Math.Round(La);
                La -= La % 2 == 1 ? 1 : 0;

                double af = t_fin / 4 * (La - ((z1 + z2) / 2) + Math.Sqrt(Math.Pow(La - ((z1 + z2) / 2), 2) - (8 * Math.Pow((z2 - z1) / (2 * 3.14), 2))));

                linksnumber1.Text = Convert.ToString(z1);
                linksnumber2.Text = Convert.ToString(z2);
                gearratio.Text = Convert.ToString(u);
                torgue.Text = Convert.ToString(m);

                d1_label.Text = $"d1: {Math.Round(d1, 2)}";
                d2_label.Text = $"d2: {Math.Round(d2, 2)}";

                da1_label.Text = $"da1: {Math.Round(da1, 2)}";
                da2_label.Text = $"da2: {Math.Round(da2, 2)}";

                a_label.Text = $"a: {Math.Round(a, 2)}";
                L_label.Text = $"La: {La}";
                af_label.Text = $"Af: {Math.Round(af, 2)}";
                step.Text = Convert.ToString(t_fin);

                //Расчет звездочки
                double dn1 = t_fin * (K + 1 / Math.Tan(180.0 / z1 * (Math.PI / 180.0)));
                double dn2 = t_fin * (K + 1 / Math.Tan(180.0 / z2 * (Math.PI / 180.0)));
                double r = 0.5025 * d4_;
                double dvn1 = d1 - 2 * r;
                double dvn2 = d2 - 2 * r;
                double alpha1 = 55 - (60 / z1);
                double alpha2 = 55 - (60 / z2);
                double fi1 = 360 / z1;
                double fi2 = 360 / z2;
                double y1 = 17-(64/z1);
                double y2 = 17-(64/z2);
                double beta1 = 18 - (56 /z1);
                double beta2 = 18 - (56 /z2);
                double r11 = 0.8 * d4_ + r;
                double r12 = 0.8 * d4_ + r;
                double fg1 = d4_*(1.24*Math.Sin(deg*y1)-0.8*Math.Sin(deg * beta1));
                double fg2 = d4_*(1.24*Math.Sin(deg * y2)-0.8*Math.Sin(deg * beta2));
                double r21 = d4_*(0.8*Math.Cos(deg * beta1)+1.24*Math.Cos(deg * y1)-1.3025)-0.05;
                double r22 = d4_*(0.8*Math.Cos(deg * beta2)+1.24*Math.Cos(deg * y2)-1.3025)-0.05;

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
                    D2 = Math.Round(d2, 2),
                    A1 = a1,
                    B1 = b1,
                    D1_ = d1_,
                    D4_ = d4_,
                    B7 = b7,
                    H1_ = h1_,
                    D3_ = d3_,
                    Rn = rn,

                    Dn1 = dn1,
                    Dn2 = dn2,
                    R=r,
                    Dvn1=dvn1,
                    Dvn2=dvn2,
                    Alpha1=alpha1,
                    Alpha2=alpha2,
                    Fi1=fi1,
                    Fi2=fi2,
                    Y1= y1,
                    Y2= y2,
                    Beta1=beta1,
                    Beta2=beta2,
                    R11=r11,
                    R12=r12,
                    Fg1=fg1,
                    Fg2=fg2,
                    R21=r21,
                    R22=r22,
                }) ;
                

                build_btn.Enabled = true;

                DateTime now = DateTime.Now;
                string timeString = now.ToString("HH:mm:ss");
                richTextBox1.Text += $"{timeString} :Расчет №{number} выполнен \n";
                number++;

                if (resultFirstClick)
                {
                    resultFirstClick = false;
                    MessageBox.Show("Теперь вы можете нажать на кнопку 'Еще' и уточнить межосевое расстояние \n\n" +
                        "При вводе вам предложат минимальное и максимальное значение","Внимание!");
                }
            }
        }
    }
    public class ChainStepData
    {
        public double T { get; set; }
        public double B1 { get; set; }
        public double D1 { get; set; }
        public double D4 { get; set; }
        public double D3 { get; set; }
        public double H1 { get; set; }
        public double B7 { get; set; }
        public double Rn { get; set; }


        public ChainStepData(double t, double b1, double d1, double d4, double d3, double h1, double b7, double rn)
        {
            T = t;
            B1 = b1;
            D1 = d1;
            D4 = d4;
            D3 = d3; // там везде поставил по 8, потом проверитЬ, как будет выглядеть (это d3_ на моем рисунке) 
            H1 = h1;
            B7 = b7;
            Rn = rn;
        }
        public static List<ChainStepData> chainSteps = new List<ChainStepData>
        {
            new ChainStepData(8.0, 3.00, 2.31, 5.00, 4, 7, 12, 4.6),
            new ChainStepData(9.525, 5.72, 3.28, 6.35, 5, 7, 15, 9.1),
            new ChainStepData(12.7, 7.75, 4.45, 8.51, 8, 9, 17, 18.2),
            new ChainStepData(15.875, 9.65, 5.08, 10.16, 8, 9, 16, 23),
            new ChainStepData(19.05, 12.7, 5.94, 11.91, 8, 15, 24, 31.8),
            new ChainStepData(25.4, 15.88, 7.92, 15.88, 8, 20, 28, 60),
            new ChainStepData(31.75, 19.05, 9.53, 19.05,10 , 26, 35, 89),
            new ChainStepData(38.1, 25.4, 11.10, 22.23, 11, 32, 48, 127),
            new ChainStepData(44.45, 25.4, 12.7, 25.4, 14, 38, 57, 172.4),
            new ChainStepData(50.8, 31.75, 14.27, 28.58, 16, 44, 68, 227),
            new ChainStepData(63.5, 38.1, 19.84, 39.68, 20, 56, 80, 354),
            // Добавьте остальные строки аналогичным образом
        };

        public static ChainStepData GetChainStepData(double tFin)
        {
            return chainSteps.FirstOrDefault(step => step.T == tFin);
        }
    }

}
