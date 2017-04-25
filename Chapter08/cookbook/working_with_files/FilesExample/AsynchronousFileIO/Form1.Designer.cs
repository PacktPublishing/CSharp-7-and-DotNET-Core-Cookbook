namespace AsynchronousFileIO
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
            this.components = new System.ComponentModel.Container();
            this.btnCopyFilesAsync = new System.Windows.Forms.Button();
            this.asyncTimer = new System.Windows.Forms.Timer(this.components);
            this.lblTimer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCopyFilesAsync
            // 
            this.btnCopyFilesAsync.Location = new System.Drawing.Point(12, 12);
            this.btnCopyFilesAsync.Name = "btnCopyFilesAsync";
            this.btnCopyFilesAsync.Size = new System.Drawing.Size(119, 23);
            this.btnCopyFilesAsync.TabIndex = 0;
            this.btnCopyFilesAsync.Text = "Copy Files Async";
            this.btnCopyFilesAsync.UseVisualStyleBackColor = true;
            this.btnCopyFilesAsync.Click += new System.EventHandler(this.btnCopyFilesAsync_Click);
            // 
            // asyncTimer
            // 
            this.asyncTimer.Interval = 1000;
            this.asyncTimer.Tick += new System.EventHandler(this.asyncTimer_Tick);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Location = new System.Drawing.Point(137, 17);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(43, 13);
            this.lblTimer.TabIndex = 1;
            this.lblTimer.Text = "lblTimer";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 226);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.btnCopyFilesAsync);
            this.Name = "Form1";
            this.Text = "AsynchronousFileIO";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCopyFilesAsync;
        private System.Windows.Forms.Timer asyncTimer;
        private System.Windows.Forms.Label lblTimer;
    }
}

