using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            this.Size = new Size(520, 250);
            label3.Text = "A_min = 0,6*(De1 + De2) + 30÷50мм \nA_max=80*t";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (GlobalData.Calculations.Count > 0)
            {
                double de1 = GlobalData.Calculations[GlobalData.Calculations.Count - 1].Da1;
                double de2 = GlobalData.Calculations[GlobalData.Calculations.Count - 1].Da2;
                double tFin = GlobalData.Calculations[GlobalData.Calculations.Count - 1].TFin;

                double minA = Math.Ceiling( 0.6 * (de1 + de2) + 40);
                double maxA = Math.Ceiling( 80*tFin);

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
                        }
                        else {label3.ForeColor= Color.Green;}
                        if (userInput > maxA)
                        {
                            label3.ForeColor = Color.Red;
                            label3.Text = $"> {maxA}";
                        }

                    }
                    else
                    {
                        label3.Text = "Please enter a valid number.";
                        label3.ForeColor = Color.Black;
                    }
                }
                else { label3.Text = $"A_min = 0.6*(De1 + De2) + 30÷50mm \nA_max=80*t";}
            }
            else
            { label3.Text = $"A_min = 0.6*(De1 + De2) + 30÷50mm \nA_max=80*t";}
        }
        }
}
