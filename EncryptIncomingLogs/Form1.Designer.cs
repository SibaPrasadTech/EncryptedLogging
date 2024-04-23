namespace EncryptionTools
{
    partial class EncryptionTool
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
            this.generateKeyFile = new System.Windows.Forms.Button();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.submitLog = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.keyLabel = new System.Windows.Forms.Label();
            this.decryptPreview = new System.Windows.Forms.TextBox();
            this.decryptLabel = new System.Windows.Forms.Label();
            this.decryptFile = new System.Windows.Forms.Button();
            this.selectKeyFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // generateKeyFile
            // 
            this.generateKeyFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateKeyFile.Location = new System.Drawing.Point(88, 96);
            this.generateKeyFile.Name = "generateKeyFile";
            this.generateKeyFile.Size = new System.Drawing.Size(177, 39);
            this.generateKeyFile.TabIndex = 1;
            this.generateKeyFile.Text = "Generate Key File";
            this.generateKeyFile.UseVisualStyleBackColor = true;
            this.generateKeyFile.Click += new System.EventHandler(this.GetPrivateKey_Click);
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(39, 231);
            this.textBoxInput.Multiline = true;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(287, 200);
            this.textBoxInput.TabIndex = 2;
            // 
            // submitLog
            // 
            this.submitLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitLog.Location = new System.Drawing.Point(139, 437);
            this.submitLog.Name = "submitLog";
            this.submitLog.Size = new System.Drawing.Size(75, 27);
            this.submitLog.TabIndex = 3;
            this.submitLog.Text = "Submit Log";
            this.submitLog.UseVisualStyleBackColor = true;
            this.submitLog.Click += new System.EventHandler(this.SubmitLog_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(40, 550);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(54, 17);
            this.statusLabel.TabIndex = 4;
            this.statusLabel.Text = "Status";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(92, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "SAMPLE ENCRYPTION";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(43, 36);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.generateKeyFile);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.submitLog);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxInput);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.keyLabel);
            this.splitContainer1.Panel2.Controls.Add(this.decryptPreview);
            this.splitContainer1.Panel2.Controls.Add(this.decryptLabel);
            this.splitContainer1.Panel2.Controls.Add(this.decryptFile);
            this.splitContainer1.Panel2.Controls.Add(this.selectKeyFile);
            this.splitContainer1.Panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1091, 477);
            this.splitContainer1.SplitterDistance = 363;
            this.splitContainer1.TabIndex = 6;
            // 
            // keyLabel
            // 
            this.keyLabel.AutoSize = true;
            this.keyLabel.Location = new System.Drawing.Point(211, 115);
            this.keyLabel.Name = "keyLabel";
            this.keyLabel.Size = new System.Drawing.Size(234, 20);
            this.keyLabel.TabIndex = 4;
            this.keyLabel.Text = "Key Status : No key file selected";
            // 
            // decryptPreview
            // 
            this.decryptPreview.Location = new System.Drawing.Point(31, 231);
            this.decryptPreview.Multiline = true;
            this.decryptPreview.Name = "decryptPreview";
            this.decryptPreview.Size = new System.Drawing.Size(557, 200);
            this.decryptPreview.TabIndex = 3;
            // 
            // decryptLabel
            // 
            this.decryptLabel.AutoSize = true;
            this.decryptLabel.Location = new System.Drawing.Point(211, 199);
            this.decryptLabel.Name = "decryptLabel";
            this.decryptLabel.Size = new System.Drawing.Size(278, 20);
            this.decryptLabel.TabIndex = 2;
            this.decryptLabel.Text = "Decryption Preview : No Logs selected";
            // 
            // decryptFile
            // 
            this.decryptFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decryptFile.Location = new System.Drawing.Point(31, 182);
            this.decryptFile.Name = "decryptFile";
            this.decryptFile.Size = new System.Drawing.Size(174, 37);
            this.decryptFile.TabIndex = 1;
            this.decryptFile.Text = "Decrypt File";
            this.decryptFile.UseVisualStyleBackColor = true;
            this.decryptFile.Click += new System.EventHandler(this.DecryptButton_Click);
            // 
            // selectKeyFile
            // 
            this.selectKeyFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectKeyFile.Location = new System.Drawing.Point(31, 96);
            this.selectKeyFile.Name = "selectKeyFile";
            this.selectKeyFile.Size = new System.Drawing.Size(174, 39);
            this.selectKeyFile.TabIndex = 0;
            this.selectKeyFile.Text = "Select Key File";
            this.selectKeyFile.UseVisualStyleBackColor = true;
            this.selectKeyFile.Click += new System.EventHandler(this.SelectKeyFile_Click);
            // 
            // EncryptionTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 586);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusLabel);
            this.Name = "EncryptionTool";
            this.Text = "Encryption Tool";
            this.Load += new System.EventHandler(this.EncryptionTool_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button generateKeyFile;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Button submitLog;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button selectKeyFile;
        private System.Windows.Forms.Button decryptFile;
        private System.Windows.Forms.Label decryptLabel;
        private System.Windows.Forms.TextBox decryptPreview;
        private System.Windows.Forms.Label keyLabel;
    }
}

