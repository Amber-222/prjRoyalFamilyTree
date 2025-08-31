namespace prjRoyalTreeGUI
{
    partial class RoyalTree
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnBFS = new Button();
            txtName = new TextBox();
            SuspendLayout();
            // 
            // btnBFS
            // 
            btnBFS.Location = new Point(91, 382);
            btnBFS.Name = "btnBFS";
            btnBFS.Size = new Size(90, 28);
            btnBFS.TabIndex = 0;
            btnBFS.Text = "BF Search";
            btnBFS.UseVisualStyleBackColor = true;
            btnBFS.Click += btnBFS_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(507, 296);
            txtName.Name = "txtName";
            txtName.Size = new Size(120, 26);
            txtName.TabIndex = 1;
            // 
            // RoyalTree
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(1179, 472);
            Controls.Add(txtName);
            Controls.Add(btnBFS);
            Name = "RoyalTree";
            Text = "Royal Tree GUI";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBFS;
        private TextBox txtName;
    }
}
