namespace DNSResolver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btn_start = new System.Windows.Forms.Button();
            this.cbIntercept = new System.Windows.Forms.CheckBox();
            this.tbxResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.BackColor = System.Drawing.Color.DarkRed;
            this.btn_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_start.ForeColor = System.Drawing.Color.White;
            this.btn_start.Location = new System.Drawing.Point(12, 12);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(260, 85);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "Start DNS Server";
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // cbIntercept
            // 
            this.cbIntercept.AutoSize = true;
            this.cbIntercept.Checked = true;
            this.cbIntercept.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIntercept.Location = new System.Drawing.Point(13, 104);
            this.cbIntercept.Name = "cbIntercept";
            this.cbIntercept.Size = new System.Drawing.Size(270, 17);
            this.cbIntercept.TabIndex = 1;
            this.cbIntercept.Text = "Intercept DNS queries with \"records.xml\" config file.";
            this.cbIntercept.UseVisualStyleBackColor = true;
            // 
            // tbxResult
            // 
            this.tbxResult.Location = new System.Drawing.Point(13, 128);
            this.tbxResult.Multiline = true;
            this.tbxResult.Name = "tbxResult";
            this.tbxResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxResult.Size = new System.Drawing.Size(259, 122);
            this.tbxResult.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.tbxResult);
            this.Controls.Add(this.cbIntercept);
            this.Controls.Add(this.btn_start);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "MainForm";
            this.Text = "DNS Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.CheckBox cbIntercept;
        private System.Windows.Forms.TextBox tbxResult;
    }
}

