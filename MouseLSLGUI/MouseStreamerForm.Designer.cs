namespace MouseLSLGUI
{
    partial class MouseStreamerForm
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
            this.startLSLStream = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timestampCheckbox = new System.Windows.Forms.CheckBox();
            this.handleLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // startLSLStream
            // 
            this.startLSLStream.Appearance = System.Windows.Forms.Appearance.Button;
            this.startLSLStream.AutoSize = true;
            this.startLSLStream.Location = new System.Drawing.Point(3, 4);
            this.startLSLStream.Name = "startLSLStream";
            this.startLSLStream.Size = new System.Drawing.Size(97, 27);
            this.startLSLStream.TabIndex = 0;
            this.startLSLStream.Text = "Start Stream";
            this.startLSLStream.UseVisualStyleBackColor = true;
            this.startLSLStream.CheckedChanged += new System.EventHandler(this.startLSLStream_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.typeLabel);
            this.panel1.Controls.Add(this.handleLabel);
            this.panel1.Controls.Add(this.timestampCheckbox);
            this.panel1.Controls.Add(this.startLSLStream);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(251, 70);
            this.panel1.TabIndex = 1;
            // 
            // timestampCheckbox
            // 
            this.timestampCheckbox.AutoSize = true;
            this.timestampCheckbox.Checked = true;
            this.timestampCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.timestampCheckbox.Location = new System.Drawing.Point(106, 8);
            this.timestampCheckbox.Name = "timestampCheckbox";
            this.timestampCheckbox.Size = new System.Drawing.Size(143, 21);
            this.timestampCheckbox.TabIndex = 1;
            this.timestampCheckbox.Text = "Include timestamp";
            this.timestampCheckbox.UseVisualStyleBackColor = true;
            // 
            // handleLabel
            // 
            this.handleLabel.AutoSize = true;
            this.handleLabel.ForeColor = System.Drawing.Color.Crimson;
            this.handleLabel.Location = new System.Drawing.Point(3, 44);
            this.handleLabel.Name = "handleLabel";
            this.handleLabel.Size = new System.Drawing.Size(103, 17);
            this.handleLabel.TabIndex = 2;
            this.handleLabel.Text = "Handle: Mouse";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.ForeColor = System.Drawing.Color.Crimson;
            this.typeLabel.Location = new System.Drawing.Point(112, 44);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(114, 17);
            this.typeLabel.TabIndex = 3;
            this.typeLabel.Text = "Type: MousePos";
            this.typeLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // MouseStreamerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(275, 94);
            this.Controls.Add(this.panel1);
            this.Name = "MouseStreamerForm";
            this.Text = "Mouse LSL Streamer";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox startLSLStream;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox timestampCheckbox;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label handleLabel;
    }
}

