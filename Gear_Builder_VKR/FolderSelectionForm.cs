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
    public partial class FolderSelectionForm : Form
    {
        public string SelectedPath { get; private set; }

        public FolderSelectionForm()
        {
            InitializeComponent();
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    SelectedPath = dialog.SelectedPath;
                    
                    ConfirmSelection confirmSelection = new ConfirmSelection();
                    OK.Enabled = true;
                    pastePath.Text = dialog.SelectedPath;
                    
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FolderSelectionForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (SelectedPath != null)
                {
                DialogResult = DialogResult.Retry;
                Close();
                }
            
        }
    }
}

