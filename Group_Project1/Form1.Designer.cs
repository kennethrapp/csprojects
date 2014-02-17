namespace Group_Project1
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnT_Add = new System.Windows.Forms.Button();
            this.lblT_2 = new System.Windows.Forms.Label();
            this.numT_2 = new System.Windows.Forms.NumericUpDown();
            this.lblT_1 = new System.Windows.Forms.Label();
            this.numT_1 = new System.Windows.Forms.NumericUpDown();
            this.cbT_Type = new System.Windows.Forms.ComboBox();
            this.radT_BySlice = new System.Windows.Forms.RadioButton();
            this.radT_Whole = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.completeOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pricesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnG_Add = new System.Windows.Forms.Button();
            this.numG_2 = new System.Windows.Forms.NumericUpDown();
            this.lblG_2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblG_1 = new System.Windows.Forms.Label();
            this.numG_1 = new System.Windows.Forms.NumericUpDown();
            this.cbG_Type = new System.Windows.Forms.ComboBox();
            this.radG_BySlice = new System.Windows.Forms.RadioButton();
            this.radG_Whole = new System.Windows.Forms.RadioButton();
            this.btnB_Add = new System.Windows.Forms.Button();
            this.numBev = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbB_Type = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbDiscount = new System.Windows.Forms.CheckBox();
            this.lbOrder = new System.Windows.Forms.ListBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnClearToppings = new System.Windows.Forms.Button();
            this.btnResetToppings = new System.Windows.Forms.Button();
            this.chkListToppings = new System.Windows.Forms.CheckedListBox();
            this.btnAddOne = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numT_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numT_1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numG_2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numG_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBev)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnT_Add);
            this.groupBox1.Controls.Add(this.lblT_2);
            this.groupBox1.Controls.Add(this.numT_2);
            this.groupBox1.Controls.Add(this.lblT_1);
            this.groupBox1.Controls.Add(this.numT_1);
            this.groupBox1.Controls.Add(this.cbT_Type);
            this.groupBox1.Controls.Add(this.radT_BySlice);
            this.groupBox1.Controls.Add(this.radT_Whole);
            this.groupBox1.Location = new System.Drawing.Point(23, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 197);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Traditional Pizza";
            // 
            // btnT_Add
            // 
            this.btnT_Add.Location = new System.Drawing.Point(18, 159);
            this.btnT_Add.Name = "btnT_Add";
            this.btnT_Add.Size = new System.Drawing.Size(171, 23);
            this.btnT_Add.TabIndex = 7;
            this.btnT_Add.Text = "Add to order";
            this.btnT_Add.UseVisualStyleBackColor = true;
            this.btnT_Add.Click += new System.EventHandler(this.btnT_Add_Click);
            // 
            // lblT_2
            // 
            this.lblT_2.AutoSize = true;
            this.lblT_2.Location = new System.Drawing.Point(15, 129);
            this.lblT_2.Name = "lblT_2";
            this.lblT_2.Size = new System.Drawing.Size(34, 13);
            this.lblT_2.TabIndex = 6;
            this.lblT_2.Text = "Large";
            // 
            // numT_2
            // 
            this.numT_2.Location = new System.Drawing.Point(143, 127);
            this.numT_2.Name = "numT_2";
            this.numT_2.Size = new System.Drawing.Size(46, 20);
            this.numT_2.TabIndex = 5;
            // 
            // lblT_1
            // 
            this.lblT_1.AutoSize = true;
            this.lblT_1.Location = new System.Drawing.Point(15, 105);
            this.lblT_1.Name = "lblT_1";
            this.lblT_1.Size = new System.Drawing.Size(44, 13);
            this.lblT_1.TabIndex = 4;
            this.lblT_1.Text = "Medium";
            // 
            // numT_1
            // 
            this.numT_1.Location = new System.Drawing.Point(143, 103);
            this.numT_1.Name = "numT_1";
            this.numT_1.Size = new System.Drawing.Size(46, 20);
            this.numT_1.TabIndex = 3;
            // 
            // cbT_Type
            // 
            this.cbT_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbT_Type.FormattingEnabled = true;
            this.cbT_Type.Items.AddRange(new object[] {
            "Plain",
            "White Pizza",
            "Lion\'s Roar Specialty"});
            this.cbT_Type.Location = new System.Drawing.Point(18, 63);
            this.cbT_Type.Name = "cbT_Type";
            this.cbT_Type.Size = new System.Drawing.Size(171, 21);
            this.cbT_Type.TabIndex = 2;
            // 
            // radT_BySlice
            // 
            this.radT_BySlice.AutoSize = true;
            this.radT_BySlice.Location = new System.Drawing.Point(110, 28);
            this.radT_BySlice.Name = "radT_BySlice";
            this.radT_BySlice.Size = new System.Drawing.Size(79, 17);
            this.radT_BySlice.TabIndex = 1;
            this.radT_BySlice.TabStop = true;
            this.radT_BySlice.Text = "By the slice";
            this.radT_BySlice.UseVisualStyleBackColor = true;
            this.radT_BySlice.CheckedChanged += new System.EventHandler(this.radT_BySlice_CheckedChanged);
            // 
            // radT_Whole
            // 
            this.radT_Whole.AutoSize = true;
            this.radT_Whole.Location = new System.Drawing.Point(18, 28);
            this.radT_Whole.Name = "radT_Whole";
            this.radT_Whole.Size = new System.Drawing.Size(83, 17);
            this.radT_Whole.TabIndex = 0;
            this.radT_Whole.TabStop = true;
            this.radT_Whole.Text = "Whole pizza";
            this.radT_Whole.UseVisualStyleBackColor = true;
            this.radT_Whole.CheckedChanged += new System.EventHandler(this.radT_Whole_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.pricesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(731, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.completeOrderToolStripMenuItem,
            this.clearOrderToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // completeOrderToolStripMenuItem
            // 
            this.completeOrderToolStripMenuItem.Name = "completeOrderToolStripMenuItem";
            this.completeOrderToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.completeOrderToolStripMenuItem.Text = "&Complete order";
            this.completeOrderToolStripMenuItem.Click += new System.EventHandler(this.completeOrderToolStripMenuItem_Click);
            // 
            // clearOrderToolStripMenuItem
            // 
            this.clearOrderToolStripMenuItem.Name = "clearOrderToolStripMenuItem";
            this.clearOrderToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.clearOrderToolStripMenuItem.Text = "C&lear order";
            this.clearOrderToolStripMenuItem.Click += new System.EventHandler(this.clearOrderToolStripMenuItem_Click);
            // 
            // pricesToolStripMenuItem
            // 
            this.pricesToolStripMenuItem.Name = "pricesToolStripMenuItem";
            this.pricesToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.pricesToolStripMenuItem.Text = "&Prices";
            this.pricesToolStripMenuItem.Click += new System.EventHandler(this.pricesToolStripMenuItem_Click);
            // 
            // btnG_Add
            // 
            this.btnG_Add.Location = new System.Drawing.Point(18, 159);
            this.btnG_Add.Name = "btnG_Add";
            this.btnG_Add.Size = new System.Drawing.Size(171, 23);
            this.btnG_Add.TabIndex = 7;
            this.btnG_Add.Text = "Add to order";
            this.btnG_Add.UseVisualStyleBackColor = true;
            this.btnG_Add.Click += new System.EventHandler(this.btnG_Add_Click);
            // 
            // numG_2
            // 
            this.numG_2.Location = new System.Drawing.Point(143, 127);
            this.numG_2.Name = "numG_2";
            this.numG_2.Size = new System.Drawing.Size(46, 20);
            this.numG_2.TabIndex = 5;
            // 
            // lblG_2
            // 
            this.lblG_2.AutoSize = true;
            this.lblG_2.Location = new System.Drawing.Point(15, 129);
            this.lblG_2.Name = "lblG_2";
            this.lblG_2.Size = new System.Drawing.Size(34, 13);
            this.lblG_2.TabIndex = 6;
            this.lblG_2.Text = "Large";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnG_Add);
            this.groupBox2.Controls.Add(this.lblG_2);
            this.groupBox2.Controls.Add(this.numG_2);
            this.groupBox2.Controls.Add(this.lblG_1);
            this.groupBox2.Controls.Add(this.numG_1);
            this.groupBox2.Controls.Add(this.cbG_Type);
            this.groupBox2.Controls.Add(this.radG_BySlice);
            this.groupBox2.Controls.Add(this.radG_Whole);
            this.groupBox2.Location = new System.Drawing.Point(262, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(206, 197);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gourmet Pizza";
            // 
            // lblG_1
            // 
            this.lblG_1.AutoSize = true;
            this.lblG_1.Location = new System.Drawing.Point(15, 105);
            this.lblG_1.Name = "lblG_1";
            this.lblG_1.Size = new System.Drawing.Size(44, 13);
            this.lblG_1.TabIndex = 4;
            this.lblG_1.Text = "Medium";
            // 
            // numG_1
            // 
            this.numG_1.Location = new System.Drawing.Point(143, 103);
            this.numG_1.Name = "numG_1";
            this.numG_1.Size = new System.Drawing.Size(46, 20);
            this.numG_1.TabIndex = 3;
            // 
            // cbG_Type
            // 
            this.cbG_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbG_Type.FormattingEnabled = true;
            this.cbG_Type.Items.AddRange(new object[] {
            "BBQ Chicken",
            "Cheeseburger Pizza",
            "Buffalo Chicken",
            "The Works"});
            this.cbG_Type.Location = new System.Drawing.Point(18, 63);
            this.cbG_Type.Name = "cbG_Type";
            this.cbG_Type.Size = new System.Drawing.Size(171, 21);
            this.cbG_Type.TabIndex = 2;
            // 
            // radG_BySlice
            // 
            this.radG_BySlice.AutoSize = true;
            this.radG_BySlice.Location = new System.Drawing.Point(110, 28);
            this.radG_BySlice.Name = "radG_BySlice";
            this.radG_BySlice.Size = new System.Drawing.Size(79, 17);
            this.radG_BySlice.TabIndex = 1;
            this.radG_BySlice.TabStop = true;
            this.radG_BySlice.Text = "By the slice";
            this.radG_BySlice.UseVisualStyleBackColor = true;
            this.radG_BySlice.CheckedChanged += new System.EventHandler(this.radG_BySlice_CheckedChanged);
            // 
            // radG_Whole
            // 
            this.radG_Whole.AutoSize = true;
            this.radG_Whole.Location = new System.Drawing.Point(18, 28);
            this.radG_Whole.Name = "radG_Whole";
            this.radG_Whole.Size = new System.Drawing.Size(83, 17);
            this.radG_Whole.TabIndex = 0;
            this.radG_Whole.TabStop = true;
            this.radG_Whole.Text = "Whole pizza";
            this.radG_Whole.UseVisualStyleBackColor = true;
            this.radG_Whole.CheckedChanged += new System.EventHandler(this.radG_Whole_CheckedChanged);
            // 
            // btnB_Add
            // 
            this.btnB_Add.Location = new System.Drawing.Point(18, 95);
            this.btnB_Add.Name = "btnB_Add";
            this.btnB_Add.Size = new System.Drawing.Size(171, 23);
            this.btnB_Add.TabIndex = 7;
            this.btnB_Add.Text = "Add to order";
            this.btnB_Add.UseVisualStyleBackColor = true;
            this.btnB_Add.Click += new System.EventHandler(this.btnB_Add_Click);
            // 
            // numBev
            // 
            this.numBev.Location = new System.Drawing.Point(143, 63);
            this.numBev.Name = "numBev";
            this.numBev.Size = new System.Drawing.Size(46, 20);
            this.numBev.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Quantity";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnB_Add);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.numBev);
            this.groupBox3.Controls.Add(this.cbB_Type);
            this.groupBox3.Location = new System.Drawing.Point(500, 52);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(206, 133);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Beverages";
            // 
            // cbB_Type
            // 
            this.cbB_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbB_Type.FormattingEnabled = true;
            this.cbB_Type.Items.AddRange(new object[] {
            "Water",
            "Fountain Soda (S)",
            "Fountain Soda (M)",
            "Fountain Soda (L)",
            "Bottled Soda",
            "Iced Tea (S)",
            "Iced Tea (M)",
            "Iced Tea (L)",
            "Lemonade (S)",
            "Lemonade (M)",
            "Lemonade (L)",
            "Juice (S)",
            "Juice (M)",
            "Juice (L)"});
            this.cbB_Type.Location = new System.Drawing.Point(18, 27);
            this.cbB_Type.Name = "cbB_Type";
            this.cbB_Type.Size = new System.Drawing.Size(171, 21);
            this.cbB_Type.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbDiscount);
            this.groupBox4.Location = new System.Drawing.Point(500, 192);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(206, 57);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Discount";
            // 
            // cbDiscount
            // 
            this.cbDiscount.AutoSize = true;
            this.cbDiscount.Location = new System.Drawing.Point(18, 24);
            this.cbDiscount.Name = "cbDiscount";
            this.cbDiscount.Size = new System.Drawing.Size(167, 17);
            this.cbDiscount.TabIndex = 0;
            this.cbDiscount.Text = "I am staff/faculty, or a student";
            this.cbDiscount.UseVisualStyleBackColor = true;
            // 
            // lbOrder
            // 
            this.lbOrder.FormattingEnabled = true;
            this.lbOrder.Location = new System.Drawing.Point(23, 383);
            this.lbOrder.Name = "lbOrder";
            this.lbOrder.Size = new System.Drawing.Size(683, 108);
            this.lbOrder.TabIndex = 10;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(23, 498);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(101, 33);
            this.btnRemove.TabIndex = 12;
            this.btnRemove.Text = "Remove One";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(340, 355);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Order";
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(218, 497);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(189, 33);
            this.btnRemoveAll.TabIndex = 14;
            this.btnRemoveAll.Text = "Remove All";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnClearToppings);
            this.groupBox5.Controls.Add(this.btnResetToppings);
            this.groupBox5.Controls.Add(this.chkListToppings);
            this.groupBox5.Location = new System.Drawing.Point(23, 255);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(683, 97);
            this.groupBox5.TabIndex = 21;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Toppings (.25)";
            // 
            // btnClearToppings
            // 
            this.btnClearToppings.Location = new System.Drawing.Point(560, 19);
            this.btnClearToppings.Name = "btnClearToppings";
            this.btnClearToppings.Size = new System.Drawing.Size(102, 23);
            this.btnClearToppings.TabIndex = 1;
            this.btnClearToppings.Text = "Clear";
            this.btnClearToppings.UseVisualStyleBackColor = true;
            this.btnClearToppings.Click += new System.EventHandler(this.btnClearToppings_Click);
            // 
            // btnResetToppings
            // 
            this.btnResetToppings.Location = new System.Drawing.Point(560, 48);
            this.btnResetToppings.Name = "btnResetToppings";
            this.btnResetToppings.Size = new System.Drawing.Size(102, 35);
            this.btnResetToppings.TabIndex = 22;
            this.btnResetToppings.Text = "Update";
            this.btnResetToppings.UseVisualStyleBackColor = true;
            this.btnResetToppings.Click += new System.EventHandler(this.btnResetToppings_Click);
            // 
            // chkListToppings
            // 
            this.chkListToppings.FormattingEnabled = true;
            this.chkListToppings.Items.AddRange(new object[] {
            "Bacon",
            "BBQ Chicken",
            "Beef",
            "Cajun Chicken",
            "Chicken Masala",
            "Chicken Tikka",
            "Chorizo",
            "Duck",
            "Ham",
            "Honey Cured Ham",
            "Meatballs",
            "People",
            "Pepperoni",
            "Proscuitto",
            "Salami",
            "Sausage",
            "Serrano Ham",
            "Turkey",
            "Venison"});
            this.chkListToppings.Location = new System.Drawing.Point(18, 19);
            this.chkListToppings.MultiColumn = true;
            this.chkListToppings.Name = "chkListToppings";
            this.chkListToppings.Size = new System.Drawing.Size(520, 64);
            this.chkListToppings.TabIndex = 0;
            // 
            // btnAddOne
            // 
            this.btnAddOne.Location = new System.Drawing.Point(128, 498);
            this.btnAddOne.Name = "btnAddOne";
            this.btnAddOne.Size = new System.Drawing.Size(84, 33);
            this.btnAddOne.TabIndex = 23;
            this.btnAddOne.Text = "Add One";
            this.btnAddOne.UseVisualStyleBackColor = true;
            this.btnAddOne.Click += new System.EventHandler(this.btnAddOne_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 543);
            this.Controls.Add(this.btnAddOne);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lbOrder);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox5);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Lion\'s Roar Pizza Shop";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numT_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numT_1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numG_2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numG_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBev)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radT_BySlice;
        private System.Windows.Forms.RadioButton radT_Whole;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label lblT_2;
        private System.Windows.Forms.NumericUpDown numT_2;
        private System.Windows.Forms.Label lblT_1;
        private System.Windows.Forms.NumericUpDown numT_1;
        private System.Windows.Forms.ComboBox cbT_Type;
        private System.Windows.Forms.Button btnT_Add;
        private System.Windows.Forms.Button btnG_Add;
        private System.Windows.Forms.NumericUpDown numG_2;
        private System.Windows.Forms.Label lblG_2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblG_1;
        private System.Windows.Forms.NumericUpDown numG_1;
        private System.Windows.Forms.ComboBox cbG_Type;
        private System.Windows.Forms.RadioButton radG_BySlice;
        private System.Windows.Forms.RadioButton radG_Whole;
        private System.Windows.Forms.Button btnB_Add;
        private System.Windows.Forms.NumericUpDown numBev;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbB_Type;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox cbDiscount;
        private System.Windows.Forms.ListBox lbOrder;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem completeOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pricesToolStripMenuItem;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckedListBox chkListToppings;
        private System.Windows.Forms.Button btnClearToppings;
        private System.Windows.Forms.Button btnResetToppings;
        private System.Windows.Forms.Button btnAddOne;
    }
}

