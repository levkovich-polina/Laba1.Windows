namespace _1_LABA.Forms
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
            this.PersonsListBox = new System.Windows.Forms.ListBox();
            this.CreateButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.FormPositionLabel = new System.Windows.Forms.Label();
            this.CoordinateQuarterLabel = new System.Windows.Forms.Label();
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
            // PersonsListBox
            // 
            this.PersonsListBox.FormattingEnabled = true;
            this.PersonsListBox.ItemHeight = 20;
            this.PersonsListBox.Location = new System.Drawing.Point(183, 138);
            this.PersonsListBox.Name = "PersonsListBox";
            this.PersonsListBox.Size = new System.Drawing.Size(202, 184);
            this.PersonsListBox.TabIndex = 1;
            // 
            // CreateButton
            // 
            this.CreateButton.BackColor = System.Drawing.Color.IndianRed;
            this.CreateButton.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CreateButton.Location = new System.Drawing.Point(420, 138);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(119, 46);
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
            this.EditButton.Size = new System.Drawing.Size(115, 46);
            this.EditButton.TabIndex = 3;
            this.EditButton.Text = "EDIT";
            this.EditButton.UseVisualStyleBackColor = false;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.IndianRed;
            this.DeleteButton.Font = new System.Drawing.Font("Arial Unicode MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DeleteButton.Location = new System.Drawing.Point(422, 276);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(117, 46);
            this.DeleteButton.TabIndex = 4;
            this.DeleteButton.Text = "DELETE";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // FormPositionLabel
            // 
            this.FormPositionLabel.AutoSize = true;
            this.FormPositionLabel.Location = new System.Drawing.Point(12, 9);
            this.FormPositionLabel.Name = "FormPositionLabel";
            this.FormPositionLabel.Size = new System.Drawing.Size(103, 20);
            this.FormPositionLabel.TabIndex = 5;
            this.FormPositionLabel.Text = "Form Position ";
            // 
            // CoordinateQuarterLabel
            // 
            this.CoordinateQuarterLabel.AutoSize = true;
            this.CoordinateQuarterLabel.Location = new System.Drawing.Point(12, 41);
            this.CoordinateQuarterLabel.Name = "CoordinateQuarterLabel";
            this.CoordinateQuarterLabel.Size = new System.Drawing.Size(137, 20);
            this.CoordinateQuarterLabel.TabIndex = 6;
            this.CoordinateQuarterLabel.Text = "Coordinate Quarter";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CoordinateQuarterLabel);
            this.Controls.Add(this.FormPositionLabel);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.PersonsListBox);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private ListBox PersonsListBox;
        private Button CreateButton;
        private Button EditButton;
        private Button DeleteButton;
        private Label FormPositionLabel;
        private Label CoordinateQuarterLabel;
    }
}