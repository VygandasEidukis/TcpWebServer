namespace WebService.UI
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
            this.btn_ServerSwitch = new System.Windows.Forms.Button();
            this.btn_SelectRootPath = new System.Windows.Forms.Button();
            this.tb_RootPath = new System.Windows.Forms.TextBox();
            this.tb_Port = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_ServerSwitch
            // 
            this.btn_ServerSwitch.Location = new System.Drawing.Point(141, 101);
            this.btn_ServerSwitch.Name = "btn_ServerSwitch";
            this.btn_ServerSwitch.Size = new System.Drawing.Size(75, 23);
            this.btn_ServerSwitch.TabIndex = 0;
            this.btn_ServerSwitch.Text = "Start Server";
            this.btn_ServerSwitch.UseVisualStyleBackColor = true;
            this.btn_ServerSwitch.Click += new System.EventHandler(this.btn_ServerSwitch_Click);
            // 
            // btn_SelectRootPath
            // 
            this.btn_SelectRootPath.Location = new System.Drawing.Point(12, 101);
            this.btn_SelectRootPath.Name = "btn_SelectRootPath";
            this.btn_SelectRootPath.Size = new System.Drawing.Size(123, 23);
            this.btn_SelectRootPath.TabIndex = 1;
            this.btn_SelectRootPath.Text = "Select Root Directory";
            this.btn_SelectRootPath.UseVisualStyleBackColor = true;
            this.btn_SelectRootPath.Click += new System.EventHandler(this.btn_SelectRootPath_Click);
            // 
            // tb_RootPath
            // 
            this.tb_RootPath.Location = new System.Drawing.Point(12, 75);
            this.tb_RootPath.Name = "tb_RootPath";
            this.tb_RootPath.Size = new System.Drawing.Size(204, 20);
            this.tb_RootPath.TabIndex = 2;
            // 
            // tb_Port
            // 
            this.tb_Port.Location = new System.Drawing.Point(12, 32);
            this.tb_Port.Name = "tb_Port";
            this.tb_Port.Size = new System.Drawing.Size(115, 20);
            this.tb_Port.TabIndex = 3;
            this.tb_Port.Text = "8080";
            this.tb_Port.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Port_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Root Directory";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 140);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_Port);
            this.Controls.Add(this.tb_RootPath);
            this.Controls.Add(this.btn_SelectRootPath);
            this.Controls.Add(this.btn_ServerSwitch);
            this.Name = "Form1";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ServerSwitch;
        private System.Windows.Forms.Button btn_SelectRootPath;
        private System.Windows.Forms.TextBox tb_RootPath;
        private System.Windows.Forms.TextBox tb_Port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

