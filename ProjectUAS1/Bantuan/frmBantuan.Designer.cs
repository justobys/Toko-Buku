namespace ProjectUAS1.Bantuan
{
    partial class bantuan_form
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
            this.pnlBantuan = new System.Windows.Forms.Panel();
            this.isiText = new System.Windows.Forms.TextBox();
            this.lblJudul = new System.Windows.Forms.Label();
            this.pnlBantuan.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBantuan
            // 
            this.pnlBantuan.AutoScroll = true;
            this.pnlBantuan.Controls.Add(this.isiText);
            this.pnlBantuan.Controls.Add(this.lblJudul);
            this.pnlBantuan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBantuan.Location = new System.Drawing.Point(0, 0);
            this.pnlBantuan.Name = "pnlBantuan";
            this.pnlBantuan.Size = new System.Drawing.Size(1066, 826);
            this.pnlBantuan.TabIndex = 0;
            // 
            // isiText
            // 
            this.isiText.Dock = System.Windows.Forms.DockStyle.Top;
            this.isiText.Font = new System.Drawing.Font("Poppins", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isiText.Location = new System.Drawing.Point(0, 73);
            this.isiText.Multiline = true;
            this.isiText.Name = "isiText";
            this.isiText.Size = new System.Drawing.Size(1066, 750);
            this.isiText.TabIndex = 2;
            // 
            // lblJudul
            // 
            this.lblJudul.AutoSize = true;
            this.lblJudul.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblJudul.Font = new System.Drawing.Font("Poppins", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJudul.Location = new System.Drawing.Point(0, 0);
            this.lblJudul.Name = "lblJudul";
            this.lblJudul.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.lblJudul.Size = new System.Drawing.Size(109, 73);
            this.lblJudul.TabIndex = 0;
            this.lblJudul.Text = "Judul";
            // 
            // bantuan_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 826);
            this.Controls.Add(this.pnlBantuan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "bantuan_form";
            this.Text = "bantuan_form";
            this.pnlBantuan.ResumeLayout(false);
            this.pnlBantuan.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBantuan;
        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.TextBox isiText;
    }
}