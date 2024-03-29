namespace PasswordManagerProject
{
    partial class MainWindowForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindowForm));
            this._platformText = new System.Windows.Forms.TextBox();
            this._nameText = new System.Windows.Forms.TextBox();
            this._passwordText = new System.Windows.Forms.TextBox();
            this._saveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.directoryBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this._copyEmailButton = new System.Windows.Forms.Button();
            this._copyPasswordButton = new System.Windows.Forms.Button();
            this._deleteButton = new System.Windows.Forms.Button();
            this._listBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // _platformText
            // 
            this._platformText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._platformText.Location = new System.Drawing.Point(194, 19);
            this._platformText.Name = "_platformText";
            this._platformText.Size = new System.Drawing.Size(234, 23);
            this._platformText.TabIndex = 3;
            // 
            // _nameText
            // 
            this._nameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._nameText.Location = new System.Drawing.Point(194, 61);
            this._nameText.Name = "_nameText";
            this._nameText.Size = new System.Drawing.Size(234, 23);
            this._nameText.TabIndex = 4;
            // 
            // _passwordText
            // 
            this._passwordText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._passwordText.Location = new System.Drawing.Point(194, 102);
            this._passwordText.Name = "_passwordText";
            this._passwordText.Size = new System.Drawing.Size(234, 23);
            this._passwordText.TabIndex = 5;
            // 
            // _saveButton
            // 
            this._saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._saveButton.Location = new System.Drawing.Point(194, 137);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(109, 30);
            this._saveButton.TabIndex = 7;
            this._saveButton.Text = "Save";
            this._saveButton.UseVisualStyleBackColor = true;
            this._saveButton.Click += new System.EventHandler(this.saveButton_Click);
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
            // _copyEmailButton
            // 
            this._copyEmailButton.Enabled = false;
            this._copyEmailButton.Location = new System.Drawing.Point(434, 173);
            this._copyEmailButton.Name = "_copyEmailButton";
            this._copyEmailButton.Size = new System.Drawing.Size(123, 24);
            this._copyEmailButton.TabIndex = 11;
            this._copyEmailButton.Text = "Copy Email";
            this._copyEmailButton.UseVisualStyleBackColor = true;
            // 
            // _copyPasswordButton
            // 
            this._copyPasswordButton.Enabled = false;
            this._copyPasswordButton.Location = new System.Drawing.Point(582, 173);
            this._copyPasswordButton.Name = "_copyPasswordButton";
            this._copyPasswordButton.Size = new System.Drawing.Size(117, 24);
            this._copyPasswordButton.TabIndex = 12;
            this._copyPasswordButton.Text = "Copy Password";
            this._copyPasswordButton.UseVisualStyleBackColor = true;
            // 
            // _deleteButton
            // 
            this._deleteButton.Enabled = false;
            this._deleteButton.Location = new System.Drawing.Point(319, 137);
            this._deleteButton.Name = "_deleteButton";
            this._deleteButton.Size = new System.Drawing.Size(109, 30);
            this._deleteButton.TabIndex = 13;
            this._deleteButton.Text = "Delete";
            this._deleteButton.UseVisualStyleBackColor = true;
            this._deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // _listBox
            // 
            this._listBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._listBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this._listBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._listBox.FormattingEnabled = true;
            this._listBox.ItemHeight = 20;
            this._listBox.Location = new System.Drawing.Point(434, 20);
            this._listBox.Name = "_listBox";
            this._listBox.ScrollAlwaysVisible = true;
            this._listBox.Size = new System.Drawing.Size(265, 142);
            this._listBox.Sorted = true;
            this._listBox.TabIndex = 15;
            // 
            // MainWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 207);
            this.Controls.Add(this._listBox);
            this.Controls.Add(this._deleteButton);
            this.Controls.Add(this._copyPasswordButton);
            this.Controls.Add(this._copyEmailButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._saveButton);
            this.Controls.Add(this._passwordText);
            this.Controls.Add(this._nameText);
            this.Controls.Add(this._platformText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainWindowForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox _platformText;
        private System.Windows.Forms.TextBox _nameText;
        private System.Windows.Forms.TextBox _passwordText;
        private System.Windows.Forms.Button _saveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog directoryBrowser;
        private System.Windows.Forms.Button _copyEmailButton;
        private System.Windows.Forms.Button _copyPasswordButton;
        private System.Windows.Forms.Button _deleteButton;
        private System.Windows.Forms.ListBox _listBox;
    }
}

