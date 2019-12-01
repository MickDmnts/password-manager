namespace PasswordManagerProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.platformText = new System.Windows.Forms.TextBox();
            this.nameText = new System.Windows.Forms.TextBox();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.platformDropDown = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.fileInformationTextBox = new System.Windows.Forms.RichTextBox();
            this.directoryBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.fileCounterText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // platformText
            // 
            this.platformText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.platformText.Location = new System.Drawing.Point(194, 19);
            this.platformText.Name = "platformText";
            this.platformText.Size = new System.Drawing.Size(234, 23);
            this.platformText.TabIndex = 3;
            // 
            // nameText
            // 
            this.nameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameText.Location = new System.Drawing.Point(194, 61);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(234, 23);
            this.nameText.TabIndex = 4;
            // 
            // passwordText
            // 
            this.passwordText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordText.Location = new System.Drawing.Point(194, 102);
            this.passwordText.Name = "passwordText";
            this.passwordText.Size = new System.Drawing.Size(234, 23);
            this.passwordText.TabIndex = 5;
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(194, 138);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(109, 30);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Platform";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username/Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // platformDropDown
            // 
            this.platformDropDown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.platformDropDown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.platformDropDown.DropDownHeight = 110;
            this.platformDropDown.DropDownWidth = 190;
            this.platformDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.platformDropDown.FormattingEnabled = true;
            this.platformDropDown.IntegralHeight = false;
            this.platformDropDown.Location = new System.Drawing.Point(471, 19);
            this.platformDropDown.MaxDropDownItems = 99;
            this.platformDropDown.MaxLength = 9999;
            this.platformDropDown.Name = "platformDropDown";
            this.platformDropDown.Size = new System.Drawing.Size(189, 23);
            this.platformDropDown.TabIndex = 8;
            this.platformDropDown.TabStop = false;
            this.platformDropDown.Tag = "";
            this.platformDropDown.SelectedIndexChanged += new System.EventHandler(this.platformDropDown_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(514, -1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Select password";
            // 
            // fileInformationTextBox
            // 
            this.fileInformationTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.fileInformationTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fileInformationTextBox.Location = new System.Drawing.Point(434, 48);
            this.fileInformationTextBox.Name = "fileInformationTextBox";
            this.fileInformationTextBox.ReadOnly = true;
            this.fileInformationTextBox.Size = new System.Drawing.Size(265, 119);
            this.fileInformationTextBox.TabIndex = 10;
            this.fileInformationTextBox.Text = "";
            // 
            // fileCounterText
            // 
            this.fileCounterText.AutoSize = true;
            this.fileCounterText.Cursor = System.Windows.Forms.Cursors.Help;
            this.fileCounterText.Location = new System.Drawing.Point(431, 170);
            this.fileCounterText.Name = "fileCounterText";
            this.fileCounterText.Size = new System.Drawing.Size(98, 13);
            this.fileCounterText.TabIndex = 11;
            this.fileCounterText.Text = "Saved Passwords: ";
            this.fileCounterText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 207);
            this.Controls.Add(this.fileCounterText);
            this.Controls.Add(this.fileInformationTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.platformDropDown);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.platformText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password Manager v1.5.2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox platformText;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox platformDropDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox fileInformationTextBox;
        private System.Windows.Forms.FolderBrowserDialog directoryBrowser;
        private System.Windows.Forms.Label fileCounterText;
    }
}

