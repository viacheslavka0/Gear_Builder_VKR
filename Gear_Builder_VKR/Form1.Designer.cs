namespace Gear_Builder_VKR
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.build_btn = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.calculate_button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.step = new System.Windows.Forms.TextBox();
            this.ChoiseType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.linksnumber2 = new System.Windows.Forms.TextBox();
            this.linksnumber1 = new System.Windows.Forms.TextBox();
            this.torgue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gearratio = new System.Windows.Forms.TextBox();
            this.frequency2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.frequency1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.power = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.L_label = new System.Windows.Forms.Label();
            this.af_label = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.a_label = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.da2_label = new System.Windows.Forms.Label();
            this.d1_label = new System.Windows.Forms.Label();
            this.d2_label = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.da1_label = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // build_btn
            // 
            this.build_btn.Location = new System.Drawing.Point(554, 412);
            this.build_btn.Name = "build_btn";
            this.build_btn.Size = new System.Drawing.Size(126, 58);
            this.build_btn.TabIndex = 0;
            this.build_btn.Text = "Построение";
            this.build_btn.UseVisualStyleBackColor = true;
            this.build_btn.Click += new System.EventHandler(this.build_btn_click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(651, 43);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(922, 722);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.calculate_button);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.build_btn);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabPage1.Size = new System.Drawing.Size(914, 696);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Расчет и построение цепи";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(219, 625);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(165, 39);
            this.button5.TabIndex = 9;
            this.button5.Text = "Ещё...";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(686, 412);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(88, 58);
            this.button4.TabIndex = 8;
            this.button4.Text = "История расчетов";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(416, 515);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(182, 17);
            this.label15.TabIndex = 7;
            this.label15.Text = "Окно вывода информации";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(416, 535);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(358, 129);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(262, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(512, 29);
            this.label10.TabIndex = 5;
            this.label10.Text = "Цепь роликовая приводная ГОСТ 13568-97";
            // 
            // calculate_button
            // 
            this.calculate_button.Location = new System.Drawing.Point(411, 412);
            this.calculate_button.Name = "calculate_button";
            this.calculate_button.Size = new System.Drawing.Size(137, 58);
            this.calculate_button.TabIndex = 4;
            this.calculate_button.Text = "Выполнить расчет";
            this.calculate_button.UseVisualStyleBackColor = true;
            this.calculate_button.Click += new System.EventHandler(this.calculate_btn_click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Gear_Builder_VKR.Properties.Resources.Фото_цепи;
            this.pictureBox1.Location = new System.Drawing.Point(416, 119);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(358, 266);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(35, 625);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(165, 39);
            this.button2.TabIndex = 2;
            this.button2.Text = "Условия эксплуатации";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.step);
            this.groupBox1.Controls.Add(this.ChoiseType);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.linksnumber2);
            this.groupBox1.Controls.Add(this.linksnumber1);
            this.groupBox1.Controls.Add(this.torgue);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.gearratio);
            this.groupBox1.Controls.Add(this.frequency2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.frequency1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.power);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(35, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 560);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Исходные данные";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 511);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 17);
            this.label9.TabIndex = 7;
            this.label9.Text = "Шаг цепи";
            // 
            // step
            // 
            this.step.Location = new System.Drawing.Point(6, 531);
            this.step.Name = "step";
            this.step.Size = new System.Drawing.Size(343, 23);
            this.step.TabIndex = 8;
            // 
            // ChoiseType
            // 
            this.ChoiseType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChoiseType.FormattingEnabled = true;
            this.ChoiseType.Items.AddRange(new object[] {
            "Не выбрано",
            "По передаваемой мощности и частотам вращения",
            "По передаваемой мощности/крутящему моменту, частоте вращения и передаточному числ" +
                "у",
            "Свой вариант"});
            this.ChoiseType.Location = new System.Drawing.Point(9, 60);
            this.ChoiseType.Name = "ChoiseType";
            this.ChoiseType.Size = new System.Drawing.Size(340, 21);
            this.ChoiseType.TabIndex = 0;
            this.ChoiseType.DropDown += new System.EventHandler(this.ChoiseType_DropDown);
            this.ChoiseType.SelectedIndexChanged += new System.EventHandler(this.ChoiseType_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 17);
            this.label8.TabIndex = 5;
            this.label8.Text = "Выберите тип расчета";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 456);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(237, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "Число звеньев ведомой звездочки";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 402);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(238, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Число звеньев ведущей звездочки";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 349);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Крутящий момент, Н*м";
            // 
            // linksnumber2
            // 
            this.linksnumber2.Location = new System.Drawing.Point(6, 476);
            this.linksnumber2.Name = "linksnumber2";
            this.linksnumber2.Size = new System.Drawing.Size(343, 23);
            this.linksnumber2.TabIndex = 7;
            // 
            // linksnumber1
            // 
            this.linksnumber1.Location = new System.Drawing.Point(6, 425);
            this.linksnumber1.Name = "linksnumber1";
            this.linksnumber1.Size = new System.Drawing.Size(343, 23);
            this.linksnumber1.TabIndex = 6;
            // 
            // torgue
            // 
            this.torgue.Location = new System.Drawing.Point(6, 372);
            this.torgue.Name = "torgue";
            this.torgue.Size = new System.Drawing.Size(343, 23);
            this.torgue.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 297);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Передаточное число";
            // 
            // gearratio
            // 
            this.gearratio.Location = new System.Drawing.Point(6, 320);
            this.gearratio.Name = "gearratio";
            this.gearratio.Size = new System.Drawing.Size(343, 23);
            this.gearratio.TabIndex = 4;
            // 
            // frequency2
            // 
            this.frequency2.Location = new System.Drawing.Point(6, 268);
            this.frequency2.Name = "frequency2";
            this.frequency2.Size = new System.Drawing.Size(343, 23);
            this.frequency2.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(318, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Частота вращения ведомой звездочки, об/мин";
            // 
            // frequency1
            // 
            this.frequency1.Location = new System.Drawing.Point(6, 219);
            this.frequency1.Name = "frequency1";
            this.frequency1.Size = new System.Drawing.Size(343, 23);
            this.frequency1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(319, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Частота вращения ведущей звездочки, об/мин";
            // 
            // power
            // 
            this.power.Location = new System.Drawing.Point(6, 164);
            this.power.Name = "power";
            this.power.Size = new System.Drawing.Size(343, 23);
            this.power.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Передаваемая мощность, кВт";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(914, 696);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Результаты расчетов";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox2.Controls.Add(this.L_label);
            this.groupBox2.Controls.Add(this.af_label);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.a_label);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.da2_label);
            this.groupBox2.Controls.Add(this.d1_label);
            this.groupBox2.Controls.Add(this.d2_label);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.da1_label);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Location = new System.Drawing.Point(20, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(380, 366);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Геометрические величины";
            // 
            // L_label
            // 
            this.L_label.AutoSize = true;
            this.L_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_label.Location = new System.Drawing.Point(301, 263);
            this.L_label.Name = "L_label";
            this.L_label.Size = new System.Drawing.Size(16, 17);
            this.L_label.TabIndex = 1;
            this.L_label.Text = "L";
            this.L_label.Click += new System.EventHandler(this.label14_Click);
            // 
            // af_label
            // 
            this.af_label.AutoSize = true;
            this.af_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.af_label.Location = new System.Drawing.Point(301, 321);
            this.af_label.Name = "af_label";
            this.af_label.Size = new System.Drawing.Size(20, 17);
            this.af_label.TabIndex = 1;
            this.af_label.Text = "af";
            this.af_label.Click += new System.EventHandler(this.label14_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(13, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(241, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "Делительные диаметры звездочек";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(13, 110);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(203, 17);
            this.label12.TabIndex = 0;
            this.label12.Text = "Диаметр вершины звездочек";
            // 
            // a_label
            // 
            this.a_label.AutoSize = true;
            this.a_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.a_label.Location = new System.Drawing.Point(301, 205);
            this.a_label.Name = "a_label";
            this.a_label.Size = new System.Drawing.Size(16, 17);
            this.a_label.TabIndex = 1;
            this.a_label.Text = "a";
            this.a_label.Click += new System.EventHandler(this.label14_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(13, 205);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(284, 17);
            this.label13.TabIndex = 0;
            this.label13.Text = "Предварительное межосевое расстояние";
            // 
            // da2_label
            // 
            this.da2_label.AutoSize = true;
            this.da2_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.da2_label.Location = new System.Drawing.Point(301, 144);
            this.da2_label.Name = "da2_label";
            this.da2_label.Size = new System.Drawing.Size(32, 17);
            this.da2_label.TabIndex = 0;
            this.da2_label.Text = "da2";
            // 
            // d1_label
            // 
            this.d1_label.AutoSize = true;
            this.d1_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.d1_label.Location = new System.Drawing.Point(301, 30);
            this.d1_label.Name = "d1_label";
            this.d1_label.Size = new System.Drawing.Size(24, 17);
            this.d1_label.TabIndex = 0;
            this.d1_label.Text = "d1";
            // 
            // d2_label
            // 
            this.d2_label.AutoSize = true;
            this.d2_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.d2_label.Location = new System.Drawing.Point(301, 64);
            this.d2_label.Name = "d2_label";
            this.d2_label.Size = new System.Drawing.Size(24, 17);
            this.d2_label.TabIndex = 0;
            this.d2_label.Text = "d2";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(13, 263);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(150, 17);
            this.label14.TabIndex = 0;
            this.label14.Text = "Длина цепи (в шагах)";
            // 
            // da1_label
            // 
            this.da1_label.AutoSize = true;
            this.da1_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.da1_label.Location = new System.Drawing.Point(301, 110);
            this.da1_label.Name = "da1_label";
            this.da1_label.Size = new System.Drawing.Size(32, 17);
            this.da1_label.TabIndex = 0;
            this.da1_label.Text = "da1";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(13, 321);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(163, 17);
            this.label16.TabIndex = 0;
            this.label16.Text = "Межосевое расстояние";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 715);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Проектированеи цепной передачи по ГОСТ 13568-97";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button build_btn;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox power;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox frequency1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox gearratio;
        private System.Windows.Forms.TextBox frequency2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox torgue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox linksnumber2;
        private System.Windows.Forms.TextBox linksnumber1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox ChoiseType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button calculate_button;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox step;
        private System.Windows.Forms.Label d1_label;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label d2_label;
        private System.Windows.Forms.Label da2_label;
        private System.Windows.Forms.Label da1_label;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label a_label;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label L_label;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label af_label;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

