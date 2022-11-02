namespace _1_LABA
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.CreateButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.DeletButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(296, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "DATA BASE";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(183, 138);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(202, 184);
            this.listBox1.TabIndex = 1;
            // 
            // CreateButton
            // 
            this.CreateButton.BackColor = System.Drawing.Color.IndianRed;
            this.CreateButton.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CreateButton.Location = new System.Drawing.Point(420, 138);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(114, 46);
            this.CreateButton.TabIndex = 2;
            this.CreateButton.Text = "CREATE";
            this.CreateButton.UseVisualStyleBackColor = false;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.BackColor = System.Drawing.Color.IndianRed;
            this.EditButton.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EditButton.ForeColor = System.Drawing.Color.Black;
            this.EditButton.Location = new System.Drawing.Point(424, 207);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(112, 46);
            this.EditButton.TabIndex = 3;
            this.EditButton.Text = "EDIT";
            this.EditButton.UseVisualStyleBackColor = false;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // DeletButton
            // 
            this.DeletButton.BackColor = System.Drawing.Color.IndianRed;
            this.DeletButton.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DeletButton.Location = new System.Drawing.Point(422, 276);
            this.DeletButton.Name = "DeletButton";
            this.DeletButton.Size = new System.Drawing.Size(114, 46);
            this.DeletButton.TabIndex = 4;
            this.DeletButton.Text = "DELETE";
            this.DeletButton.UseVisualStyleBackColor = false;
            this.DeletButton.Click += new System.EventHandler(this.DeletButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DeletButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private ListBox listBox1;
        private Button CreateButton;
        private Button EditButton;
        private Button DeletButton;
    }
}