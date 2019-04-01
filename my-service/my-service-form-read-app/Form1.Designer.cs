namespace my_service_form_read_app
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
            this.tb_Result = new System.Windows.Forms.TextBox();
            this.btn_ReadMemory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_Result
            // 
            this.tb_Result.Location = new System.Drawing.Point(50, 197);
            this.tb_Result.Multiline = true;
            this.tb_Result.Name = "tb_Result";
            this.tb_Result.Size = new System.Drawing.Size(690, 171);
            this.tb_Result.TabIndex = 0;
            // 
            // btn_ReadMemory
            // 
            this.btn_ReadMemory.Location = new System.Drawing.Point(261, 105);
            this.btn_ReadMemory.Name = "btn_ReadMemory";
            this.btn_ReadMemory.Size = new System.Drawing.Size(170, 23);
            this.btn_ReadMemory.TabIndex = 1;
            this.btn_ReadMemory.Text = "Read Memory";
            this.btn_ReadMemory.UseVisualStyleBackColor = true;
            this.btn_ReadMemory.Click += new System.EventHandler(this.btn_ReadMemory_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_ReadMemory);
            this.Controls.Add(this.tb_Result);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Result;
        private System.Windows.Forms.Button btn_ReadMemory;
    }
}

