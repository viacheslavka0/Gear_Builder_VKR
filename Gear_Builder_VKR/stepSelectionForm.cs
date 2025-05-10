using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Gear_Builder_VKR
{
    public partial class StepSelectionForm : Form
    {
        public double SelectedStep { get; private set; }

        public StepSelectionForm(List<double> stepOptions, double currentStep)
        {
            this.Text = "Выбор шага цепи";
            this.Size = new Size(100, 150);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            Label instructionLabel = new Label
            {
                Text = "Выберите шаг цепи:",
                AutoSize = true,
                Location = new Point(10, 10)
            };
            this.Controls.Add(instructionLabel);

            int yPosition = 40;
            foreach (var step in stepOptions)
            {
                Button stepButton = new Button
                {
                    Text = step.ToString(),
                    Location = new Point(10, yPosition),
                    Tag = step,
                    AutoSize = true
                };
                stepButton.Click += StepButton_Click;
                this.Controls.Add(stepButton);
                yPosition += 30;
            }

            this.SelectedStep = currentStep; // Устанавливаем текущий шаг по умолчанию
        }

        private void StepButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                this.SelectedStep = (double)clickedButton.Tag;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void StepSelectionForm_Load(object sender, EventArgs e)
        {

        }
    }
}
