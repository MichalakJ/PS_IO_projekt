namespace PS_Client
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
            this.clientTextBox = new System.Windows.Forms.RichTextBox();
            this.discoverBtn = new System.Windows.Forms.Button();
            this.tcpBtn = new System.Windows.Forms.Button();
            this.serverList = new System.Windows.Forms.ListView();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.closeTCP = new System.Windows.Forms.Button();
            this.sendTCP = new System.Windows.Forms.Button();
            this.value = new System.Windows.Forms.TextBox();
            this.valueBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clientTextBox
            // 
            this.clientTextBox.Location = new System.Drawing.Point(12, 12);
            this.clientTextBox.Name = "clientTextBox";
            this.clientTextBox.Size = new System.Drawing.Size(595, 213);
            this.clientTextBox.TabIndex = 0;
            this.clientTextBox.Text = "";
            // 
            // discoverBtn
            // 
            this.discoverBtn.Location = new System.Drawing.Point(26, 260);
            this.discoverBtn.Name = "discoverBtn";
            this.discoverBtn.Size = new System.Drawing.Size(79, 24);
            this.discoverBtn.TabIndex = 1;
            this.discoverBtn.Text = "discover";
            this.discoverBtn.UseVisualStyleBackColor = true;
            this.discoverBtn.Click += new System.EventHandler(this.discoverBtn_Click);
            // 
            // tcpBtn
            // 
            this.tcpBtn.Location = new System.Drawing.Point(653, 175);
            this.tcpBtn.Name = "tcpBtn";
            this.tcpBtn.Size = new System.Drawing.Size(91, 23);
            this.tcpBtn.TabIndex = 2;
            this.tcpBtn.Text = "connect TCP";
            this.tcpBtn.UseVisualStyleBackColor = true;
            this.tcpBtn.Click += new System.EventHandler(this.tcpBtn_Click);
            // 
            // serverList
            // 
            this.serverList.Location = new System.Drawing.Point(653, 12);
            this.serverList.Name = "serverList";
            this.serverList.Size = new System.Drawing.Size(91, 157);
            this.serverList.TabIndex = 3;
            this.serverList.UseCompatibleStateImageBehavior = false;
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(650, 231);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(94, 20);
            this.userNameTextBox.TabIndex = 4;
            this.userNameTextBox.Text = "default";
            // 
            // closeTCP
            // 
            this.closeTCP.Location = new System.Drawing.Point(653, 201);
            this.closeTCP.Name = "closeTCP";
            this.closeTCP.Size = new System.Drawing.Size(91, 24);
            this.closeTCP.TabIndex = 5;
            this.closeTCP.Text = "close tcp connection";
            this.closeTCP.UseVisualStyleBackColor = true;
            this.closeTCP.Click += new System.EventHandler(this.closeTCP_Click);
            // 
            // sendTCP
            // 
            this.sendTCP.Location = new System.Drawing.Point(650, 257);
            this.sendTCP.Name = "sendTCP";
            this.sendTCP.Size = new System.Drawing.Size(94, 24);
            this.sendTCP.TabIndex = 6;
            this.sendTCP.Text = "send msg";
            this.sendTCP.UseVisualStyleBackColor = true;
            this.sendTCP.Click += new System.EventHandler(this.button1_Click);
            // 
            // value
            // 
            this.value.Location = new System.Drawing.Point(415, 231);
            this.value.Name = "value";
            this.value.Size = new System.Drawing.Size(80, 20);
            this.value.TabIndex = 7;
            this.value.Text = "1000";
            // 
            // valueBtn
            // 
            this.valueBtn.Location = new System.Drawing.Point(415, 267);
            this.valueBtn.Name = "valueBtn";
            this.valueBtn.Size = new System.Drawing.Size(79, 26);
            this.valueBtn.TabIndex = 8;
            this.valueBtn.Text = "VALUE";
            this.valueBtn.UseVisualStyleBackColor = true;
            this.valueBtn.Click += new System.EventHandler(this.valueBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 316);
            this.Controls.Add(this.valueBtn);
            this.Controls.Add(this.value);
            this.Controls.Add(this.sendTCP);
            this.Controls.Add(this.closeTCP);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.serverList);
            this.Controls.Add(this.tcpBtn);
            this.Controls.Add(this.discoverBtn);
            this.Controls.Add(this.clientTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox clientTextBox;
        private System.Windows.Forms.Button discoverBtn;
        private System.Windows.Forms.Button tcpBtn;
        private System.Windows.Forms.ListView serverList;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.Button closeTCP;
        private System.Windows.Forms.Button sendTCP;
        private System.Windows.Forms.TextBox value;
        private System.Windows.Forms.Button valueBtn;
    }
}

