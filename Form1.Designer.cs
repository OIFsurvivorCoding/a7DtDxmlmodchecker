namespace ModConflictChecker
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Button btnSelectFolder;
        private Button btnScan;
        private Label lblFolder;
        private RichTextBox txtOutput;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnSelectFolder = new Button();
            btnScan = new Button();
            lblFolder = new Label();
            txtOutput = new RichTextBox();
            btnNorm = new Button();
            btnDark = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnSelectFolder
            // 
            btnSelectFolder.Location = new Point(15, 15);
            btnSelectFolder.Margin = new Padding(4);
            btnSelectFolder.Name = "btnSelectFolder";
            btnSelectFolder.Size = new Size(180, 38);
            btnSelectFolder.TabIndex = 0;
            btnSelectFolder.Text = "Select Folder...";
            btnSelectFolder.UseVisualStyleBackColor = true;
            btnSelectFolder.Click += btnSelectFolder_Click;
            // 
            // btnScan
            // 
            btnScan.BackColor = SystemColors.ButtonFace;
            btnScan.Location = new Point(206, 15);
            btnScan.Margin = new Padding(4);
            btnScan.Name = "btnScan";
            btnScan.Size = new Size(154, 38);
            btnScan.TabIndex = 1;
            btnScan.Text = "Scan Mods";
            btnScan.UseVisualStyleBackColor = false;
            btnScan.Click += btnScan_Click;
            // 
            // lblFolder
            // 
            lblFolder.AutoSize = true;
            lblFolder.Location = new Point(15, 63);
            lblFolder.Margin = new Padding(4, 0, 4, 0);
            lblFolder.Name = "lblFolder";
            lblFolder.Size = new Size(131, 19);
            lblFolder.TabIndex = 2;
            lblFolder.Text = "No folder selected";
            // 
            // txtOutput
            // 
            txtOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtOutput.BackColor = SystemColors.ButtonShadow;
            txtOutput.Location = new Point(15, 95);
            txtOutput.Margin = new Padding(4);
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.Size = new Size(1178, 510);
            txtOutput.TabIndex = 3;
            txtOutput.Text = "";
            // 
            // btnNorm
            // 
            btnNorm.BackColor = SystemColors.ButtonFace;
            btnNorm.Location = new Point(1034, 53);
            btnNorm.Margin = new Padding(4);
            btnNorm.Name = "btnNorm";
            btnNorm.Size = new Size(73, 29);
            btnNorm.TabIndex = 4;
            btnNorm.Text = "Normal";
            btnNorm.UseVisualStyleBackColor = false;
            btnNorm.Click += btnNorm_Click;
            // 
            // btnDark
            // 
            btnDark.BackColor = SystemColors.ButtonFace;
            btnDark.ForeColor = SystemColors.ControlText;
            btnDark.Location = new Point(1115, 53);
            btnDark.Margin = new Padding(4);
            btnDark.Name = "btnDark";
            btnDark.Size = new Size(73, 29);
            btnDark.TabIndex = 5;
            btnDark.Text = "Dark";
            btnDark.UseVisualStyleBackColor = false;
            btnDark.Click += btnDark_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1081, 34);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(55, 19);
            label1.TabIndex = 6;
            label1.Text = "Theme";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1168, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 31);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonShadow;
            ClientSize = new Size(1210, 646);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(btnDark);
            Controls.Add(btnNorm);
            Controls.Add(btnSelectFolder);
            Controls.Add(btnScan);
            Controls.Add(lblFolder);
            Controls.Add(txtOutput);
            Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MinimumSize = new Size(1221, 623);
            Name = "Form1";
            Text = "7DtD Mod Conflict Checker ";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Button btnNorm;
        private Button btnDark;
        private Label label1;
        private PictureBox pictureBox1;
    }
}
