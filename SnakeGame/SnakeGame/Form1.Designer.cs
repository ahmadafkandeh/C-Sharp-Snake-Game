namespace SnakeGame
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
            this.pbboard = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbboard)).BeginInit();
            this.SuspendLayout();
            // 
            // pbboard
            // 
            this.pbboard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbboard.Location = new System.Drawing.Point(12, 12);
            this.pbboard.Name = "pbboard";
            this.pbboard.Size = new System.Drawing.Size(485, 331);
            this.pbboard.TabIndex = 0;
            this.pbboard.TabStop = false;
            this.pbboard.Paint += new System.Windows.Forms.PaintEventHandler(this.pbboard_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 355);
            this.Controls.Add(this.pbboard);
            this.Name = "Form1";
            this.Text = "Snake Game";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbboard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbboard;
        private System.Windows.Forms.Timer timer1;
    }
}

