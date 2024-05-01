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

        double nn, n1, n2, m, u, z1, z2, t,t_fin, a, af, La, da1,da2, d1,d2;
        double[] chainstep = { 8.0, 9.525, 12.7, 15.875, 19.05, 25.4, 31.75, 38.1, 44.45, 50.8, 63.5 };
        ModelRebuilder modelRebuilder = new ModelRebuilder();


        private System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();

        private void button5_Click(object sender, EventArgs e)
        {

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
                MessageBox.Show($"Ошибка COM: {ex.Message}", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неизвестная ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void build_btn_click(object sender, EventArgs e)
        {
            modelRebuilder.RebuildModel(GlobalData.Calculations[GlobalData.Calculations.Count-1]); 
     
        }

        private void calculate_btn_click(object sender, EventArgs e)
        {
            if (ChoiseType.SelectedIndex==0)
            {
                MessageBox.Show("Выберите тип расчета", " Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CultureInfo ci = new CultureInfo("ru-RU");

            nn = !string.IsNullOrWhiteSpace(power.Text) ? Convert.ToDouble(power.Text.Replace('.', ','), ci) : 0.0;
            n1 = !string.IsNullOrWhiteSpace(frequency1.Text) ? Convert.ToDouble(frequency1.Text.Replace('.', ','), ci) : 0.0;
            n2 = !string.IsNullOrWhiteSpace(frequency2.Text) ? Convert.ToDouble(frequency2.Text.Replace('.', ','), ci) : 0.0;
            u = !string.IsNullOrWhiteSpace(gearratio.Text) ? Convert.ToDouble(gearratio.Text.Replace('.', ','), ci) : 0.0;
            m = !string.IsNullOrWhiteSpace(torgue.Text) ? Convert.ToDouble(torgue.Text.Replace('.', ','), ci) : 0.0;
            z1 = !string.IsNullOrWhiteSpace(linksnumber1.Text) ? Convert.ToDouble(linksnumber1.Text.Replace('.', ','), ci) : 0.0;
            z2 = !string.IsNullOrWhiteSpace(linksnumber2.Text) ? Convert.ToDouble(linksnumber2.Text.Replace('.', ','), ci) : 0.0;

            

            if (nn> 0.0 && n1>0.0 )
            {
                m = Math.Round(9550 * (nn / n1),2);
                u = Math.Round(n1 / n2,2);

                z1 = Math.Floor(29 - 2 * u);
                if (z1%2 == 0){
                    z1--;
                }

                z2 = Math.Floor(z1 * u);
                if (z2%2 == 1) {  z2--; }

                linksnumber1.Text = Convert.ToString(z1);
                linksnumber2.Text = Convert.ToString(z2);
                gearratio.Text = Convert.ToString(u);
                torgue.Text = Convert.ToString(m);

                t= 28 * Math.Pow(m * ke / (Math.Abs(z1) * p0 ), 1.0 / 3.0);

                    t_fin = chainstep[0];
                    foreach (double pitch in chainstep)
                    {
                        if (t >= pitch)
                        {
                            t_fin = pitch;
                        }
                        else
                        {
                            t_fin = pitch;
                            break; 
                        }
                    }
                    
                    step.Text=Convert.ToString(t_fin);

                d1 = t_fin / Math.Sin(deg * 180 / z1);
                d2 = t_fin / Math.Sin(deg * 180 / z2);

                d1_label.Text = $"d1: {Math.Round(d1, 2)}";
                d2_label.Text = $"d2: {Math.Round(d2, 2)}";

                da1 = t_fin * (0.5 + 1 / Math.Tan(deg * 180 / z1));
                da2 = t_fin * (0.5 + 1 / Math.Tan(deg * 180 / z2));

                da1_label.Text= $"da1: {Math.Round(da1,2)}";
                da2_label.Text= $"da2: {Math.Round(da2,2)}";

                a = 40 + (da1 + da2) / 2;
                La = (2 * a) / t + (z1 + z2) / 2 + Math.Pow((z2 - z1), 2) / (2 * 3.14) * t / a;
                La = Math.Round(La);

                if (La % 2 == 1)
                {
                    La--;
                }

                af = t_fin / 4 * (La - ((z1 + z2) / 2) + Math.Sqrt(Math.Pow(La - ((z1 + z2) / 2), 2) 
                - (8 * Math.Pow((z2 - z1) / (2 * 3.14), 2))));

                a_label.Text= $"a: {Math.Round(a, 2)}";
                L_label.Text= $"L: {Math.Round(La, 2)}";
                af_label.Text = $"af: {Math.Round(af,2)}";

                GlobalData.Calculations.Add(new ChainDriveCalculation {Nn=nn, N1= n1, N2 = n2, M = m, U=u,Z1=z1 , Z2=z2,T=t,TFin=t_fin,A=a,Af=af,La=La,Da1=da1, Da2=da2,D1=d1,D2=d2 });
                
            }

        }
    }
}
