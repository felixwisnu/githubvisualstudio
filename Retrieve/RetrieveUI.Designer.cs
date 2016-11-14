namespace Retrieve
{
    partial class RetrieveUI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RetrieveUI));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lvLogs = new System.Windows.Forms.ListView();
            this.lvLogsch1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvLogsch8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvLogsch2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvLogsch5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvLogsch4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvLogsch3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblLastBackUp = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblLastRetrieve = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblExists = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblRemaining = new System.Windows.Forms.Label();
            this.lblNamaCabang = new System.Windows.Forms.Label();
            this.lblKodeCabang = new System.Windows.Forms.Label();
            this.lblTerminalID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIconRetrieve = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnManual = new System.Windows.Forms.Button();
            this.gbManual = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbManual.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Controls.Add(this.lvLogs);
            this.groupBox2.Location = new System.Drawing.Point(292, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(620, 387);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Retrieve Log Data :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 357);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Progress :";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(86, 353);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(511, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // lvLogs
            // 
            this.lvLogs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvLogsch1,
            this.lvLogsch8,
            this.lvLogsch2,
            this.lvLogsch5,
            this.lvLogsch4,
            this.lvLogsch3});
            this.lvLogs.GridLines = true;
            this.lvLogs.HoverSelection = true;
            this.lvLogs.Location = new System.Drawing.Point(23, 26);
            this.lvLogs.Name = "lvLogs";
            this.lvLogs.Size = new System.Drawing.Size(574, 321);
            this.lvLogs.TabIndex = 2;
            this.lvLogs.UseCompatibleStateImageBehavior = false;
            this.lvLogs.View = System.Windows.Forms.View.Details;
            // 
            // lvLogsch1
            // 
            this.lvLogsch1.Text = "Count";
            // 
            // lvLogsch8
            // 
            this.lvLogsch8.Text = "Terminal ID";
            this.lvLogsch8.Width = 80;
            // 
            // lvLogsch2
            // 
            this.lvLogsch2.Text = "EnrollNumber";
            this.lvLogsch2.Width = 90;
            // 
            // lvLogsch5
            // 
            this.lvLogsch5.Text = "Date";
            this.lvLogsch5.Width = 150;
            // 
            // lvLogsch4
            // 
            this.lvLogsch4.Text = "InOutMode";
            this.lvLogsch4.Width = 99;
            // 
            // lvLogsch3
            // 
            this.lvLogsch3.Text = "VerifyMode";
            this.lvLogsch3.Width = 76;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblLastBackUp);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.lblLastRetrieve);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.lblExists);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.lblStatus);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.lblTotal);
            this.groupBox3.Controls.Add(this.lblRemaining);
            this.groupBox3.Controls.Add(this.lblNamaCabang);
            this.groupBox3.Controls.Add(this.lblKodeCabang);
            this.groupBox3.Controls.Add(this.lblTerminalID);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(13, 148);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(274, 251);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Information :";
            // 
            // lblLastBackUp
            // 
            this.lblLastBackUp.AutoSize = true;
            this.lblLastBackUp.Location = new System.Drawing.Point(106, 148);
            this.lblLastBackUp.Name = "lblLastBackUp";
            this.lblLastBackUp.Size = new System.Drawing.Size(11, 13);
            this.lblLastBackUp.TabIndex = 17;
            this.lblLastBackUp.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Last BackUp     :";
            // 
            // lblLastRetrieve
            // 
            this.lblLastRetrieve.AutoSize = true;
            this.lblLastRetrieve.Location = new System.Drawing.Point(106, 127);
            this.lblLastRetrieve.Name = "lblLastRetrieve";
            this.lblLastRetrieve.Size = new System.Drawing.Size(11, 13);
            this.lblLastRetrieve.TabIndex = 15;
            this.lblLastRetrieve.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Last Retrieve     :";
            // 
            // lblExists
            // 
            this.lblExists.AutoSize = true;
            this.lblExists.Location = new System.Drawing.Point(107, 201);
            this.lblExists.Name = "lblExists";
            this.lblExists.Size = new System.Drawing.Size(13, 13);
            this.lblExists.TabIndex = 13;
            this.lblExists.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 201);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Exists Log          :";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(95, 27);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(85, 16);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "Disconnect";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Status    :";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(107, 219);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(13, 13);
            this.lblTotal.TabIndex = 9;
            this.lblTotal.Text = "0";
            // 
            // lblRemaining
            // 
            this.lblRemaining.AutoSize = true;
            this.lblRemaining.Location = new System.Drawing.Point(107, 183);
            this.lblRemaining.Name = "lblRemaining";
            this.lblRemaining.Size = new System.Drawing.Size(13, 13);
            this.lblRemaining.TabIndex = 8;
            this.lblRemaining.Text = "0";
            // 
            // lblNamaCabang
            // 
            this.lblNamaCabang.AutoSize = true;
            this.lblNamaCabang.Location = new System.Drawing.Point(106, 104);
            this.lblNamaCabang.Name = "lblNamaCabang";
            this.lblNamaCabang.Size = new System.Drawing.Size(11, 13);
            this.lblNamaCabang.TabIndex = 7;
            this.lblNamaCabang.Text = "*";
            // 
            // lblKodeCabang
            // 
            this.lblKodeCabang.AutoSize = true;
            this.lblKodeCabang.Location = new System.Drawing.Point(106, 82);
            this.lblKodeCabang.Name = "lblKodeCabang";
            this.lblKodeCabang.Size = new System.Drawing.Size(11, 13);
            this.lblKodeCabang.TabIndex = 6;
            this.lblKodeCabang.Text = "*";
            // 
            // lblTerminalID
            // 
            this.lblTerminalID.AutoSize = true;
            this.lblTerminalID.Location = new System.Drawing.Point(106, 61);
            this.lblTerminalID.Name = "lblTerminalID";
            this.lblTerminalID.Size = new System.Drawing.Size(11, 13);
            this.lblTerminalID.TabIndex = 5;
            this.lblTerminalID.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Nama Cabang   :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Kode Cabang    :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Total Log           :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Success Log     :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Terminal Id        :";
            // 
            // notifyIconRetrieve
            // 
            this.notifyIconRetrieve.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIconRetrieve.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconRetrieve.Icon")));
            this.notifyIconRetrieve.Text = "Retrive Absense";
            this.notifyIconRetrieve.Visible = true;
            // 
            // btnManual
            // 
            this.btnManual.Location = new System.Drawing.Point(20, 23);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(236, 43);
            this.btnManual.TabIndex = 2;
            this.btnManual.Text = "Retrieve Data";
            this.btnManual.UseVisualStyleBackColor = true;
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            // 
            // gbManual
            // 
            this.gbManual.Controls.Add(this.btnExport);
            this.gbManual.Controls.Add(this.btnManual);
            this.gbManual.Location = new System.Drawing.Point(13, 12);
            this.gbManual.Name = "gbManual";
            this.gbManual.Size = new System.Drawing.Size(274, 130);
            this.gbManual.TabIndex = 11;
            this.gbManual.TabStop = false;
            this.gbManual.Text = "Action :";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(20, 70);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(236, 43);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // RetrieveUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 411);
            this.Controls.Add(this.gbManual);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RetrieveUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Retrieve";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RetrieveUI_FormClosed);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbManual.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lvLogs;
        private System.Windows.Forms.ColumnHeader lvLogsch1;
        private System.Windows.Forms.ColumnHeader lvLogsch2;
        private System.Windows.Forms.ColumnHeader lvLogsch3;
        private System.Windows.Forms.ColumnHeader lvLogsch4;
        private System.Windows.Forms.ColumnHeader lvLogsch5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblRemaining;
        private System.Windows.Forms.Label lblNamaCabang;
        private System.Windows.Forms.Label lblKodeCabang;
        private System.Windows.Forms.Label lblTerminalID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.NotifyIcon notifyIconRetrieve;
        private System.Windows.Forms.ColumnHeader lvLogsch8;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblExists;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblLastRetrieve;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnManual;
        private System.Windows.Forms.GroupBox gbManual;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblLastBackUp;
        private System.Windows.Forms.Button btnExport;
    }
}

