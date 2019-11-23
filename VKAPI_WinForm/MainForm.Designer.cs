namespace VKAPI_WinForm
{
    partial class MainForm
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
            this.Button_GetToken = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxBxClientId = new System.Windows.Forms.TextBox();
            this.txBxCountOfRec = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTokenExpire = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblProcessing = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnStopGetGroups = new System.Windows.Forms.Button();
            this.btn_GetInfGroup = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblLastGroupId = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button_GetToken
            // 
            this.Button_GetToken.Location = new System.Drawing.Point(12, 57);
            this.Button_GetToken.Name = "Button_GetToken";
            this.Button_GetToken.Size = new System.Drawing.Size(94, 23);
            this.Button_GetToken.TabIndex = 4;
            this.Button_GetToken.Text = "Request token";
            this.Button_GetToken.UseVisualStyleBackColor = true;
            this.Button_GetToken.Click += new System.EventHandler(this.Button_GetToken_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxBxClientId);
            this.groupBox1.Controls.Add(this.txBxCountOfRec);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblTokenExpire);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.Button_GetToken);
            this.groupBox1.Location = new System.Drawing.Point(16, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 136);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // TxBxClientId
            // 
            this.TxBxClientId.Location = new System.Drawing.Point(73, 19);
            this.TxBxClientId.Name = "TxBxClientId";
            this.TxBxClientId.Size = new System.Drawing.Size(122, 20);
            this.TxBxClientId.TabIndex = 1;
            // 
            // txBxCountOfRec
            // 
            this.txBxCountOfRec.Location = new System.Drawing.Point(129, 92);
            this.txBxCountOfRec.Name = "txBxCountOfRec";
            this.txBxCountOfRec.Size = new System.Drawing.Size(93, 20);
            this.txBxCountOfRec.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Count of records";
            // 
            // lblTokenExpire
            // 
            this.lblTokenExpire.AutoSize = true;
            this.lblTokenExpire.Location = new System.Drawing.Point(206, 62);
            this.lblTokenExpire.Name = "lblTokenExpire";
            this.lblTokenExpire.Size = new System.Drawing.Size(10, 13);
            this.lblTokenExpire.TabIndex = 40;
            this.lblTokenExpire.Text = "-";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label20.Location = new System.Drawing.Point(9, 22);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(54, 13);
            this.label20.TabIndex = 34;
            this.label20.Text = "Client Id";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.Location = new System.Drawing.Point(112, 62);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(88, 13);
            this.label18.TabIndex = 33;
            this.label18.Text = "Token expiry :";
            // 
            // lblProcessing
            // 
            this.lblProcessing.AutoSize = true;
            this.lblProcessing.Location = new System.Drawing.Point(175, 253);
            this.lblProcessing.Name = "lblProcessing";
            this.lblProcessing.Size = new System.Drawing.Size(10, 13);
            this.lblProcessing.TabIndex = 32;
            this.lblProcessing.Text = "-";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(86, 253);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 13);
            this.label16.TabIndex = 28;
            this.label16.Text = "Processing :";
            // 
            // btnStopGetGroups
            // 
            this.btnStopGetGroups.Location = new System.Drawing.Point(192, 212);
            this.btnStopGetGroups.Name = "btnStopGetGroups";
            this.btnStopGetGroups.Size = new System.Drawing.Size(94, 23);
            this.btnStopGetGroups.TabIndex = 7;
            this.btnStopGetGroups.Text = "Stop parsing";
            this.btnStopGetGroups.UseVisualStyleBackColor = true;
            this.btnStopGetGroups.Click += new System.EventHandler(this.BtnStopGetGroups_Click);
            // 
            // btn_GetInfGroup
            // 
            this.btn_GetInfGroup.Location = new System.Drawing.Point(89, 212);
            this.btn_GetInfGroup.Name = "btn_GetInfGroup";
            this.btn_GetInfGroup.Size = new System.Drawing.Size(94, 23);
            this.btn_GetInfGroup.TabIndex = 6;
            this.btn_GetInfGroup.Text = "Start parsing";
            this.btn_GetInfGroup.UseVisualStyleBackColor = true;
            this.btn_GetInfGroup.Click += new System.EventHandler(this.Btn_GetInf_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblLastGroupId);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.lblProcessing);
            this.groupBox5.Controls.Add(this.groupBox1);
            this.groupBox5.Controls.Add(this.btnStopGetGroups);
            this.groupBox5.Controls.Add(this.btn_GetInfGroup);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Location = new System.Drawing.Point(47, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(377, 295);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            // 
            // lblLastGroupId
            // 
            this.lblLastGroupId.AutoSize = true;
            this.lblLastGroupId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLastGroupId.Location = new System.Drawing.Point(140, 189);
            this.lblLastGroupId.Name = "lblLastGroupId";
            this.lblLastGroupId.Size = new System.Drawing.Size(10, 13);
            this.lblLastGroupId.TabIndex = 34;
            this.lblLastGroupId.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(33, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Last Group Id :";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 336);
            this.Controls.Add(this.groupBox5);
            this.MaximumSize = new System.Drawing.Size(973, 534);
            this.MinimumSize = new System.Drawing.Size(501, 375);
            this.Name = "MainForm";
            this.Text = "Parse VK";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Button_GetToken;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_GetInfGroup;
        private System.Windows.Forms.Button btnStopGetGroups;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblProcessing;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblTokenExpire;
        private System.Windows.Forms.TextBox txBxCountOfRec;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLastGroupId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxBxClientId;
    }
}

