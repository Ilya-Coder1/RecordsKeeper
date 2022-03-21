namespace lab3
{
    partial class AdditionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdditionForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.drinkRadio = new System.Windows.Forms.RadioButton();
            this.pizzaRadio = new System.Windows.Forms.RadioButton();
            this.clientNameBox = new System.Windows.Forms.TextBox();
            this.dateBox = new System.Windows.Forms.TextBox();
            this.pizzaTypeBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.drinkTypeBox = new System.Windows.Forms.TextBox();
            this.sizeBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.volumeBox = new System.Windows.Forms.ComboBox();
            this.countBox = new System.Windows.Forms.NumericUpDown();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.drinkRadio);
            this.groupBox1.Controls.Add(this.pizzaRadio);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 47);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Товар";
            // 
            // drinkRadio
            // 
            this.drinkRadio.AutoSize = true;
            this.drinkRadio.Location = new System.Drawing.Point(106, 19);
            this.drinkRadio.Name = "drinkRadio";
            this.drinkRadio.Size = new System.Drawing.Size(72, 19);
            this.drinkRadio.TabIndex = 1;
            this.drinkRadio.TabStop = true;
            this.drinkRadio.Text = "Напитки";
            this.drinkRadio.UseVisualStyleBackColor = true;
            // 
            // pizzaRadio
            // 
            this.pizzaRadio.AutoSize = true;
            this.pizzaRadio.Location = new System.Drawing.Point(6, 19);
            this.pizzaRadio.Name = "pizzaRadio";
            this.pizzaRadio.Size = new System.Drawing.Size(61, 19);
            this.pizzaRadio.TabIndex = 0;
            this.pizzaRadio.TabStop = true;
            this.pizzaRadio.Text = "Пицца";
            this.pizzaRadio.UseVisualStyleBackColor = true;
            this.pizzaRadio.CheckedChanged += new System.EventHandler(this.pizzaRadio_CheckedChanged);
            // 
            // clientNameBox
            // 
            this.clientNameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clientNameBox.Location = new System.Drawing.Point(142, 65);
            this.clientNameBox.Name = "clientNameBox";
            this.clientNameBox.Size = new System.Drawing.Size(110, 23);
            this.clientNameBox.TabIndex = 1;
            // 
            // dateBox
            // 
            this.dateBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dateBox.Location = new System.Drawing.Point(142, 94);
            this.dateBox.Name = "dateBox";
            this.dateBox.Size = new System.Drawing.Size(110, 23);
            this.dateBox.TabIndex = 2;
            // 
            // pizzaTypeBox
            // 
            this.pizzaTypeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pizzaTypeBox.Enabled = false;
            this.pizzaTypeBox.Location = new System.Drawing.Point(142, 152);
            this.pizzaTypeBox.Name = "pizzaTypeBox";
            this.pizzaTypeBox.Size = new System.Drawing.Size(110, 23);
            this.pizzaTypeBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "ФИО";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Дата (дд-мм-гг)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Количество";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Вид пиццы";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Размер (см)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Вид напитка";
            // 
            // drinkTypeBox
            // 
            this.drinkTypeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drinkTypeBox.Enabled = false;
            this.drinkTypeBox.Location = new System.Drawing.Point(142, 210);
            this.drinkTypeBox.Name = "drinkTypeBox";
            this.drinkTypeBox.Size = new System.Drawing.Size(110, 23);
            this.drinkTypeBox.TabIndex = 11;
            // 
            // sizeBox
            // 
            this.sizeBox.Enabled = false;
            this.sizeBox.FormattingEnabled = true;
            this.sizeBox.Items.AddRange(new object[] {
            "20",
            "30"});
            this.sizeBox.Location = new System.Drawing.Point(142, 181);
            this.sizeBox.Name = "sizeBox";
            this.sizeBox.Size = new System.Drawing.Size(110, 23);
            this.sizeBox.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "Объем (л)";
            // 
            // volumeBox
            // 
            this.volumeBox.Enabled = false;
            this.volumeBox.FormattingEnabled = true;
            this.volumeBox.Items.AddRange(new object[] {
            "0,3",
            "0,4",
            "0,5",
            "1"});
            this.volumeBox.Location = new System.Drawing.Point(142, 239);
            this.volumeBox.Name = "volumeBox";
            this.volumeBox.Size = new System.Drawing.Size(110, 23);
            this.volumeBox.TabIndex = 16;
            // 
            // countBox
            // 
            this.countBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.countBox.Location = new System.Drawing.Point(142, 123);
            this.countBox.Name = "countBox";
            this.countBox.Size = new System.Drawing.Size(110, 23);
            this.countBox.TabIndex = 17;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(172, 284);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(80, 25);
            this.saveButton.TabIndex = 18;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(86, 284);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(80, 25);
            this.cancelButton.TabIndex = 19;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // AdditionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 321);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.countBox);
            this.Controls.Add(this.volumeBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.sizeBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.drinkTypeBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pizzaTypeBox);
            this.Controls.Add(this.dateBox);
            this.Controls.Add(this.clientNameBox);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdditionForm";
            this.Text = "Добавление записи";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton drinkRadio;
        private System.Windows.Forms.RadioButton pizzaRadio;
        private System.Windows.Forms.TextBox clientNameBox;
        private System.Windows.Forms.TextBox dateBox;
        private System.Windows.Forms.TextBox pizzaTypeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox drinkTypeBox;
        private System.Windows.Forms.ComboBox sizeBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox volumeBox;
        private System.Windows.Forms.NumericUpDown countBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}