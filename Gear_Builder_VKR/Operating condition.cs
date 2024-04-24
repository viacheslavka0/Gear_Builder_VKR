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
    public partial class Operating_condition : Form
    {
        public Operating_condition()
        {
            InitializeComponent();
            Oiling.SelectedIndex = 0;
            Material.SelectedIndex = 0;
            Conditions.SelectedIndex = 0;
            Mode.SelectedIndex = 0;
            Tension.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
