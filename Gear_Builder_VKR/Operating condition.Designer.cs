namespace Gear_Builder_VKR
{
    partial class Operating_condition
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.Oiling = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Preassure = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Mode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Tension = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Условия эксплуатации";
            // 
            // Oiling
            // 
            this.Oiling.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Oiling.FormattingEnabled = true;
            this.Oiling.Items.AddRange(new object[] {
            "Непрерывный (в маслянной ванне или от насоса)",
            "Капельный",
            "Периодический"});
            this.Oiling.Location = new System.Drawing.Point(19, 84);
            this.Oiling.Name = "Oiling";
            this.Oiling.Size = new System.Drawing.Size(332, 21);
            this.Oiling.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(19, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Тип смазывания";
            // 
            // Preassure
            // 
            this.Preassure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Preassure.FormattingEnabled = true;
            this.Preassure.Items.AddRange(new object[] {
            "Постоянная или близкая к ней",
            "Переменная",
            "Ударная"});
            this.Preassure.Location = new System.Drawing.Point(19, 148);
            this.Preassure.Name = "Preassure";
            this.Preassure.Size = new System.Drawing.Size(332, 21);
            this.Preassure.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(19, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Тип нагрузки";
            // 
            // Mode
            // 
            this.Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Mode.FormattingEnabled = true;
            this.Mode.Items.AddRange(new object[] {
            "Односменный",
            "Двусменный",
            "Трехсменный"});
            this.Mode.Location = new System.Drawing.Point(19, 212);
            this.Mode.Name = "Mode";
            this.Mode.Size = new System.Drawing.Size(332, 21);
            this.Mode.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(19, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 18);
            this.label5.TabIndex = 2;
            this.label5.Text = "Режим работы";
            // 
            // Tension
            // 
            this.Tension.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Tension.FormattingEnabled = true;
            this.Tension.Items.AddRange(new object[] {
            "Автоматическая ",
            "Периодическая"});
            this.Tension.Location = new System.Drawing.Point(19, 270);
            this.Tension.Name = "Tension";
            this.Tension.Size = new System.Drawing.Size(332, 21);
            this.Tension.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(19, 249);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(247, 18);
            this.label6.TabIndex = 2;
            this.label6.Text = "Способ регулирования натяжения";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(274, 330);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Закрыть";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(153, 330);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Принять";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Operating_condition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(367, 365);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Tension);
            this.Controls.Add(this.Mode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Preassure);
            this.Controls.Add(this.Oiling);
            this.Controls.Add(this.label1);
            this.Name = "Operating_condition";
            this.Text = "Условия эксплуатации";
            this.Load += new System.EventHandler(this.Operating_condition_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Oiling;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Preassure;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Mode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Tension;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}