namespace EncryptIncomingLogs
{
    partial class EncryptIncomingLog
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
            this.getEncryptedKey = new System.Windows.Forms.Button();
            this.getPublicKey = new System.Windows.Forms.Button();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.submitLog = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // getEncryptedKey
            // 
            this.getEncryptedKey.Location = new System.Drawing.Point(42, 63);
            this.getEncryptedKey.Name = "getEncryptedKey";
            this.getEncryptedKey.Size = new System.Drawing.Size(166, 23);
            this.getEncryptedKey.TabIndex = 0;
            this.getEncryptedKey.Text = "Get Encrypted Key";
            this.getEncryptedKey.UseVisualStyleBackColor = true;
            this.getEncryptedKey.Click += new System.EventHandler(this.GetEncryptedKey_Click);
            // 
            // getPublicKey
            // 
            this.getPublicKey.Location = new System.Drawing.Point(42, 111);
            this.getPublicKey.Name = "getPublicKey";
            this.getPublicKey.Size = new System.Drawing.Size(166, 23);
            this.getPublicKey.TabIndex = 1;
            this.getPublicKey.Text = "Get Public Key";
            this.getPublicKey.UseVisualStyleBackColor = true;
            this.getPublicKey.Click += new System.EventHandler(this.GetPrivateKey_Click);
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(42, 167);
            this.textBoxInput.Multiline = true;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(287, 93);
            this.textBoxInput.TabIndex = 2;
            // 
            // submitLog
            // 
            this.submitLog.Location = new System.Drawing.Point(42, 279);
            this.submitLog.Name = "submitLog";
            this.submitLog.Size = new System.Drawing.Size(75, 23);
            this.submitLog.TabIndex = 3;
            this.submitLog.Text = "Submit Log";
            this.submitLog.UseVisualStyleBackColor = true;
            this.submitLog.Click += new System.EventHandler(this.SubmitLog_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(39, 419);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(37, 13);
            this.statusLabel.TabIndex = 4;
            this.statusLabel.Text = "Status";
            // 
            // EncryptIncomingLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.submitLog);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.getPublicKey);
            this.Controls.Add(this.getEncryptedKey);
            this.Name = "EncryptIncomingLog";
            this.Text = "Encrypt Incoming Log";
            this.Load += new System.EventHandler(this.EncryptIncomingLog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getEncryptedKey;
        private System.Windows.Forms.Button getPublicKey;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Button submitLog;
        private System.Windows.Forms.Label statusLabel;
    }
}

