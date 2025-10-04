namespace KelimeDefteri
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
            txtInput = new TextBox();
            txtCollectionName = new TextBox();
            btnCreateJson = new Button();
            btnReadTxt = new Button();
            lblStatus = new Label();
            btnJsonToTxt = new Button();
            btnLoadJson = new Button();
            SuspendLayout();
            // 
            // txtInput
            // 
            txtInput.Location = new Point(23, 23);
            txtInput.Margin = new Padding(4, 3, 4, 3);
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(349, 115);
            txtInput.TabIndex = 0;
            // 
            // txtCollectionName
            // 
            txtCollectionName.Location = new Point(23, 150);
            txtCollectionName.Margin = new Padding(4, 3, 4, 3);
            txtCollectionName.Name = "txtCollectionName";
            txtCollectionName.Size = new Size(349, 23);
            txtCollectionName.TabIndex = 1;
            txtCollectionName.Text = "Kelimelerim";
            // 
            // btnCreateJson
            // 
            btnCreateJson.Location = new Point(23, 190);
            btnCreateJson.Margin = new Padding(4, 3, 4, 3);
            btnCreateJson.Name = "btnCreateJson";
            btnCreateJson.Size = new Size(187, 35);
            btnCreateJson.TabIndex = 2;
            btnCreateJson.Text = "JSON Oluştur (Textbox)";
            btnCreateJson.UseVisualStyleBackColor = true;
            btnCreateJson.Click += btnCreateJson_Click;
            // 
            // btnReadTxt
            // 
            btnReadTxt.Location = new Point(233, 190);
            btnReadTxt.Margin = new Padding(4, 3, 4, 3);
            btnReadTxt.Name = "btnReadTxt";
            btnReadTxt.Size = new Size(187, 35);
            btnReadTxt.TabIndex = 3;
            btnReadTxt.Text = "TXT’den Oku ve JSON Oluştur";
            btnReadTxt.UseVisualStyleBackColor = true;
            btnReadTxt.Click += btnReadTxt_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(23, 279);
            lblStatus.Margin = new Padding(4, 0, 4, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(31, 15);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Info:";
            // 
            // btnJsonToTxt
            // 
            btnJsonToTxt.Location = new Point(23, 231);
            btnJsonToTxt.Margin = new Padding(4, 3, 4, 3);
            btnJsonToTxt.Name = "btnJsonToTxt";
            btnJsonToTxt.Size = new Size(187, 35);
            btnJsonToTxt.TabIndex = 5;
            btnJsonToTxt.Text = "JSON’dan TXT Oluştur";
            btnJsonToTxt.UseVisualStyleBackColor = true;
            btnJsonToTxt.Click += btnJsonToTxt_Click;
            // 
            // btnLoadJson
            // 
            btnLoadJson.Location = new Point(233, 231);
            btnLoadJson.Margin = new Padding(4, 3, 4, 3);
            btnLoadJson.Name = "btnLoadJson";
            btnLoadJson.Size = new Size(187, 35);
            btnLoadJson.TabIndex = 6;
            btnLoadJson.Text = "JSON’u Yükle";
            btnLoadJson.UseVisualStyleBackColor = true;
            btnLoadJson.Click += btnLoadJson_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(443, 302);
            Controls.Add(btnLoadJson);
            Controls.Add(btnJsonToTxt);
            Controls.Add(lblStatus);
            Controls.Add(btnReadTxt);
            Controls.Add(btnCreateJson);
            Controls.Add(txtCollectionName);
            Controls.Add(txtInput);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Kelime Defterim JSON Oluşturucu";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtCollectionName;
        private System.Windows.Forms.Button btnCreateJson;
        private System.Windows.Forms.Button btnReadTxt;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnJsonToTxt;
        private System.Windows.Forms.Button btnLoadJson;
    }
}