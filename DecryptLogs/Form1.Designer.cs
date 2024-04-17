namespace DecryptLogs
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
            this.uploadAESencBtn = new System.Windows.Forms.Button();
            this.aesKeyLabel = new System.Windows.Forms.Label();
            this.uploadPrivateKeyBtn = new System.Windows.Forms.Button();
            this.privateKeyLabel = new System.Windows.Forms.Label();
            this.decryptFileBtn = new System.Windows.Forms.Button();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.decryptionStatusLabel = new System.Windows.Forms.Label();
            this._decryptOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._aesOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._privateOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // uploadAESencBtn
            // 
            this.uploadAESencBtn.Location = new System.Drawing.Point(60, 81);
            this.uploadAESencBtn.Name = "uploadAESencBtn";
            this.uploadAESencBtn.Size = new System.Drawing.Size(102, 23);
            this.uploadAESencBtn.TabIndex = 0;
            this.uploadAESencBtn.Text = "Upload ENC AES Key";
            this.uploadAESencBtn.UseVisualStyleBackColor = true;
            this.uploadAESencBtn.Click += new System.EventHandler(this.uploadAESencBtn_Click);
            // 
            // aesKeyLabel
            // 
            this.aesKeyLabel.AutoSize = true;
            this.aesKeyLabel.Location = new System.Drawing.Point(196, 91);
            this.aesKeyLabel.Name = "aesKeyLabel";
            this.aesKeyLabel.Size = new System.Drawing.Size(157, 13);
            this.aesKeyLabel.TabIndex = 1;
            this.aesKeyLabel.Text = "AES Key Status : Not Uploaded";
            // 
            // uploadPrivateKeyBtn
            // 
            this.uploadPrivateKeyBtn.Location = new System.Drawing.Point(60, 43);
            this.uploadPrivateKeyBtn.Name = "uploadPrivateKeyBtn";
            this.uploadPrivateKeyBtn.Size = new System.Drawing.Size(102, 23);
            this.uploadPrivateKeyBtn.TabIndex = 2;
            this.uploadPrivateKeyBtn.Text = "Upload Private Key";
            this.uploadPrivateKeyBtn.UseVisualStyleBackColor = true;
            this.uploadPrivateKeyBtn.Click += new System.EventHandler(this.uploadPrivateKeyBtn_Click);
            // 
            // privateKeyLabel
            // 
            this.privateKeyLabel.AutoSize = true;
            this.privateKeyLabel.Location = new System.Drawing.Point(196, 53);
            this.privateKeyLabel.Name = "privateKeyLabel";
            this.privateKeyLabel.Size = new System.Drawing.Size(169, 13);
            this.privateKeyLabel.TabIndex = 3;
            this.privateKeyLabel.Text = "Private Key Status : Not Uploaded";
            this.privateKeyLabel.Click += new System.EventHandler(this.privateKeyLabel_Click);
            // 
            // decryptFileBtn
            // 
            this.decryptFileBtn.Location = new System.Drawing.Point(149, 155);
            this.decryptFileBtn.Name = "decryptFileBtn";
            this.decryptFileBtn.Size = new System.Drawing.Size(181, 40);
            this.decryptFileBtn.TabIndex = 4;
            this.decryptFileBtn.Text = "Decrypt File";
            this.decryptFileBtn.UseVisualStyleBackColor = true;
            this.decryptFileBtn.Click += new System.EventHandler(this.decryptFileBtn_Click);
            // 
            // outputTextBox
            // 
            this.outputTextBox.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputTextBox.Location = new System.Drawing.Point(60, 254);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.outputTextBox.Size = new System.Drawing.Size(708, 142);
            this.outputTextBox.TabIndex = 5;
            this.outputTextBox.Text = "Decrypted Logs will appear here.";
            this.outputTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // decryptionStatusLabel
            // 
            this.decryptionStatusLabel.AutoSize = true;
            this.decryptionStatusLabel.Location = new System.Drawing.Point(57, 238);
            this.decryptionStatusLabel.Name = "decryptionStatusLabel";
            this.decryptionStatusLabel.Size = new System.Drawing.Size(179, 13);
            this.decryptionStatusLabel.TabIndex = 6;
            this.decryptionStatusLabel.Text = "Decryption Status : No logs selected";
            // 
            // _decryptOpenFileDialog
            // 
            this._decryptOpenFileDialog.FileName = "decrypt";
            // 
            // _aesOpenFileDialog
            // 
            this._aesOpenFileDialog.FileName = "uploadAESFile";
            // 
            // _privateOpenFileDialog
            // 
            this._privateOpenFileDialog.FileName = "uploadPrivateKey";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 450);
            this.Controls.Add(this.decryptionStatusLabel);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.decryptFileBtn);
            this.Controls.Add(this.privateKeyLabel);
            this.Controls.Add(this.uploadPrivateKeyBtn);
            this.Controls.Add(this.aesKeyLabel);
            this.Controls.Add(this.uploadAESencBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uploadAESencBtn;
        private System.Windows.Forms.Label aesKeyLabel;
        private System.Windows.Forms.Button uploadPrivateKeyBtn;
        private System.Windows.Forms.Label privateKeyLabel;
        private System.Windows.Forms.Button decryptFileBtn;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Label decryptionStatusLabel;
        private System.Windows.Forms.OpenFileDialog _decryptOpenFileDialog;
        private System.Windows.Forms.OpenFileDialog _aesOpenFileDialog;
        private System.Windows.Forms.OpenFileDialog _privateOpenFileDialog;
    }
}

