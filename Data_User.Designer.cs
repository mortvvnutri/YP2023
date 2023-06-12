namespace YP2023
{
    partial class Data_User
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
            this.Kont_page = new System.Windows.Forms.TabPage();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.oge = new System.Windows.Forms.RadioButton();
            this.ege = new System.Windows.Forms.RadioButton();
            this.TextBox4 = new System.Windows.Forms.TextBox();
            this.V_patronymic = new System.Windows.Forms.TextBox();
            this.V_name = new System.Windows.Forms.TextBox();
            this.V_surname = new System.Windows.Forms.TextBox();
            this.V_date_birth = new System.Windows.Forms.DateTimePicker();
            this.Z_pasport = new System.Windows.Forms.Label();
            this.Z_uch_zav = new System.Windows.Forms.Label();
            this.V_ex = new System.Windows.Forms.Label();
            this.Z_r_date = new System.Windows.Forms.Label();
            this.Z_surname = new System.Windows.Forms.Label();
            this.Z_name = new System.Windows.Forms.Label();
            this.Z_firstname = new System.Windows.Forms.Label();
            this.Vkladki = new System.Windows.Forms.TabControl();
            this.Sved_page = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.School = new System.Windows.Forms.RadioButton();
            this.SPO = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.predmcheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.V_passport = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Kont_page.SuspendLayout();
            this.Vkladki.SuspendLayout();
            this.Sved_page.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Kont_page
            // 
            this.Kont_page.BackColor = System.Drawing.Color.SeaShell;
            this.Kont_page.Controls.Add(this.textBox6);
            this.Kont_page.Controls.Add(this.label2);
            this.Kont_page.Controls.Add(this.textBox5);
            this.Kont_page.Controls.Add(this.label1);
            this.Kont_page.Location = new System.Drawing.Point(4, 33);
            this.Kont_page.Name = "Kont_page";
            this.Kont_page.Size = new System.Drawing.Size(730, 695);
            this.Kont_page.TabIndex = 1;
            this.Kont_page.Text = "Контактные данные";
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox6.Location = new System.Drawing.Point(362, 311);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(235, 32);
            this.textBox6.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(107, 316);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Электронная почта";
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox5.Location = new System.Drawing.Point(362, 228);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(235, 32);
            this.textBox5.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(116, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Номер телефона";
            // 
            // oge
            // 
            this.oge.AutoSize = true;
            this.oge.Location = new System.Drawing.Point(142, 11);
            this.oge.Name = "oge";
            this.oge.Size = new System.Drawing.Size(67, 28);
            this.oge.TabIndex = 9;
            this.oge.Text = "ОГЭ";
            this.oge.UseVisualStyleBackColor = true;
            this.oge.CheckedChanged += new System.EventHandler(this.oge_CheckedChanged);
            // 
            // ege
            // 
            this.ege.AutoSize = true;
            this.ege.Location = new System.Drawing.Point(257, 11);
            this.ege.Name = "ege";
            this.ege.Size = new System.Drawing.Size(65, 28);
            this.ege.TabIndex = 8;
            this.ege.Text = "ЕГЭ";
            this.ege.UseVisualStyleBackColor = true;
            this.ege.CheckedChanged += new System.EventHandler(this.ege_CheckedChanged);
            // 
            // TextBox4
            // 
            this.TextBox4.Location = new System.Drawing.Point(345, 440);
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.Size = new System.Drawing.Size(200, 29);
            this.TextBox4.TabIndex = 12;
            // 
            // V_patronymic
            // 
            this.V_patronymic.Location = new System.Drawing.Point(343, 129);
            this.V_patronymic.Name = "V_patronymic";
            this.V_patronymic.Size = new System.Drawing.Size(200, 29);
            this.V_patronymic.TabIndex = 6;
            this.V_patronymic.TextChanged += new System.EventHandler(this.V_patronymic_TextChanged);
            // 
            // V_name
            // 
            this.V_name.Location = new System.Drawing.Point(343, 84);
            this.V_name.Name = "V_name";
            this.V_name.Size = new System.Drawing.Size(200, 29);
            this.V_name.TabIndex = 5;
            this.V_name.TextChanged += new System.EventHandler(this.V_name_TextChanged);
            // 
            // V_surname
            // 
            this.V_surname.Location = new System.Drawing.Point(343, 36);
            this.V_surname.Name = "V_surname";
            this.V_surname.Size = new System.Drawing.Size(200, 29);
            this.V_surname.TabIndex = 4;
            this.V_surname.TextChanged += new System.EventHandler(this.V_firstname_TextChanged);
            // 
            // V_date_birth
            // 
            this.V_date_birth.Location = new System.Drawing.Point(343, 194);
            this.V_date_birth.Name = "V_date_birth";
            this.V_date_birth.Size = new System.Drawing.Size(200, 29);
            this.V_date_birth.TabIndex = 7;
            // 
            // Z_pasport
            // 
            this.Z_pasport.AutoSize = true;
            this.Z_pasport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Z_pasport.Location = new System.Drawing.Point(85, 257);
            this.Z_pasport.Name = "Z_pasport";
            this.Z_pasport.Size = new System.Drawing.Size(222, 20);
            this.Z_pasport.TabIndex = 21;
            this.Z_pasport.Text = "Номер паспорта (без серии)";
            // 
            // Z_uch_zav
            // 
            this.Z_uch_zav.AutoSize = true;
            this.Z_uch_zav.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Z_uch_zav.Location = new System.Drawing.Point(159, 440);
            this.Z_uch_zav.Name = "Z_uch_zav";
            this.Z_uch_zav.Size = new System.Drawing.Size(159, 20);
            this.Z_uch_zav.TabIndex = 19;
            this.Z_uch_zav.Text = "Учебное заведение";
            // 
            // V_ex
            // 
            this.V_ex.AutoSize = true;
            this.V_ex.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.V_ex.Location = new System.Drawing.Point(16, 13);
            this.V_ex.Name = "V_ex";
            this.V_ex.Size = new System.Drawing.Size(75, 20);
            this.V_ex.TabIndex = 16;
            this.V_ex.Text = "Экзамен";
            // 
            // Z_r_date
            // 
            this.Z_r_date.AutoSize = true;
            this.Z_r_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Z_r_date.Location = new System.Drawing.Point(179, 194);
            this.Z_r_date.Name = "Z_r_date";
            this.Z_r_date.Size = new System.Drawing.Size(128, 20);
            this.Z_r_date.TabIndex = 15;
            this.Z_r_date.Text = "Дата рождения";
            // 
            // Z_surname
            // 
            this.Z_surname.AutoSize = true;
            this.Z_surname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Z_surname.Location = new System.Drawing.Point(224, 129);
            this.Z_surname.Name = "Z_surname";
            this.Z_surname.Size = new System.Drawing.Size(83, 20);
            this.Z_surname.TabIndex = 14;
            this.Z_surname.Text = "Отчество";
            // 
            // Z_name
            // 
            this.Z_name.AutoSize = true;
            this.Z_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Z_name.Location = new System.Drawing.Point(267, 84);
            this.Z_name.Name = "Z_name";
            this.Z_name.Size = new System.Drawing.Size(40, 20);
            this.Z_name.TabIndex = 13;
            this.Z_name.Text = "Имя";
            // 
            // Z_firstname
            // 
            this.Z_firstname.AutoSize = true;
            this.Z_firstname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Z_firstname.Location = new System.Drawing.Point(226, 39);
            this.Z_firstname.Name = "Z_firstname";
            this.Z_firstname.Size = new System.Drawing.Size(81, 20);
            this.Z_firstname.TabIndex = 12;
            this.Z_firstname.Text = "Фамилия";
            // 
            // Vkladki
            // 
            this.Vkladki.Controls.Add(this.Sved_page);
            this.Vkladki.Controls.Add(this.Kont_page);
            this.Vkladki.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Vkladki.Location = new System.Drawing.Point(1, 1);
            this.Vkladki.Margin = new System.Windows.Forms.Padding(4);
            this.Vkladki.Name = "Vkladki";
            this.Vkladki.SelectedIndex = 0;
            this.Vkladki.Size = new System.Drawing.Size(738, 732);
            this.Vkladki.TabIndex = 1;
            // 
            // Sved_page
            // 
            this.Sved_page.BackColor = System.Drawing.Color.Gainsboro;
            this.Sved_page.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Sved_page.Controls.Add(this.panel2);
            this.Sved_page.Controls.Add(this.panel1);
            this.Sved_page.Controls.Add(this.label3);
            this.Sved_page.Controls.Add(this.predmcheckedListBox);
            this.Sved_page.Controls.Add(this.V_passport);
            this.Sved_page.Controls.Add(this.button2);
            this.Sved_page.Controls.Add(this.button1);
            this.Sved_page.Controls.Add(this.TextBox4);
            this.Sved_page.Controls.Add(this.V_patronymic);
            this.Sved_page.Controls.Add(this.V_name);
            this.Sved_page.Controls.Add(this.V_surname);
            this.Sved_page.Controls.Add(this.V_date_birth);
            this.Sved_page.Controls.Add(this.Z_pasport);
            this.Sved_page.Controls.Add(this.Z_uch_zav);
            this.Sved_page.Controls.Add(this.Z_r_date);
            this.Sved_page.Controls.Add(this.Z_surname);
            this.Sved_page.Controls.Add(this.Z_name);
            this.Sved_page.Controls.Add(this.Z_firstname);
            this.Sved_page.Location = new System.Drawing.Point(4, 33);
            this.Sved_page.Margin = new System.Windows.Forms.Padding(4);
            this.Sved_page.Name = "Sved_page";
            this.Sved_page.Padding = new System.Windows.Forms.Padding(4);
            this.Sved_page.Size = new System.Drawing.Size(730, 695);
            this.Sved_page.TabIndex = 0;
            this.Sved_page.Text = "Общие сведения";
            this.Sved_page.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Sved_page_MouseMove);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.School);
            this.panel2.Controls.Add(this.SPO);
            this.panel2.Location = new System.Drawing.Point(131, 361);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(454, 51);
            this.panel2.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(44, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 20);
            this.label4.TabIndex = 38;
            this.label4.Text = "Место обучения";
            // 
            // School
            // 
            this.School.AutoSize = true;
            this.School.Location = new System.Drawing.Point(332, 9);
            this.School.Name = "School";
            this.School.Size = new System.Drawing.Size(82, 28);
            this.School.TabIndex = 37;
            this.School.TabStop = true;
            this.School.Text = "Школа";
            this.School.UseVisualStyleBackColor = true;
            // 
            // SPO
            // 
            this.SPO.AutoSize = true;
            this.SPO.Location = new System.Drawing.Point(219, 12);
            this.SPO.Name = "SPO";
            this.SPO.Size = new System.Drawing.Size(79, 28);
            this.SPO.TabIndex = 36;
            this.SPO.TabStop = true;
            this.SPO.Text = "ССУЗ";
            this.SPO.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.oge);
            this.panel1.Controls.Add(this.ege);
            this.panel1.Controls.Add(this.V_ex);
            this.panel1.Location = new System.Drawing.Point(183, 308);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 47);
            this.panel1.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(152, 518);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 40);
            this.label3.TabIndex = 35;
            this.label3.Text = "Желаемые предметы\r\nдля сдачи экзамена";
            // 
            // predmcheckedListBox
            // 
            this.predmcheckedListBox.CheckOnClick = true;
            this.predmcheckedListBox.FormattingEnabled = true;
            this.predmcheckedListBox.Items.AddRange(new object[] {
            "Русский язык",
            "Математика",
            "История",
            "Обществознание",
            "Биология",
            "География",
            "Химия",
            "Литература"});
            this.predmcheckedListBox.Location = new System.Drawing.Point(345, 489);
            this.predmcheckedListBox.Name = "predmcheckedListBox";
            this.predmcheckedListBox.Size = new System.Drawing.Size(200, 124);
            this.predmcheckedListBox.TabIndex = 34;
            // 
            // V_passport
            // 
            this.V_passport.Location = new System.Drawing.Point(343, 251);
            this.V_passport.MaxLength = 6;
            this.V_passport.Name = "V_passport";
            this.V_passport.Size = new System.Drawing.Size(200, 29);
            this.V_passport.TabIndex = 10;
            this.V_passport.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            this.V_passport.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightCyan;
            this.button2.Location = new System.Drawing.Point(415, 634);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 40);
            this.button2.TabIndex = 14;
            this.button2.Text = "Сохранить";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MistyRose;
            this.button1.Location = new System.Drawing.Point(164, 634);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 40);
            this.button1.TabIndex = 33;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Data_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 735);
            this.Controls.Add(this.Vkladki);
            this.Name = "Data_User";
            this.Text = "Информация об обучающемся";
            this.Shown += new System.EventHandler(this.Data_User_Shown);
            this.Kont_page.ResumeLayout(false);
            this.Kont_page.PerformLayout();
            this.Vkladki.ResumeLayout(false);
            this.Sved_page.ResumeLayout(false);
            this.Sved_page.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabPage Kont_page;
        internal System.Windows.Forms.RadioButton oge;
        internal System.Windows.Forms.RadioButton ege;
        internal System.Windows.Forms.TextBox TextBox4;
        internal System.Windows.Forms.TextBox V_patronymic;
        internal System.Windows.Forms.TextBox V_name;
        internal System.Windows.Forms.TextBox V_surname;
        internal System.Windows.Forms.DateTimePicker V_date_birth;
        internal System.Windows.Forms.Label Z_pasport;
        internal System.Windows.Forms.Label Z_uch_zav;
        internal System.Windows.Forms.Label V_ex;
        internal System.Windows.Forms.Label Z_r_date;
        internal System.Windows.Forms.Label Z_surname;
        internal System.Windows.Forms.Label Z_name;
        internal System.Windows.Forms.Label Z_firstname;
        internal System.Windows.Forms.TabControl Vkladki;
        internal System.Windows.Forms.TabPage Sved_page;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox V_passport;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox predmcheckedListBox;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton School;
        private System.Windows.Forms.RadioButton SPO;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Label label4;
    }
}