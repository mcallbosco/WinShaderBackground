namespace DrawBehindDesktopIcons
{
    partial class SettingsForm
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
            System.Windows.Forms.TabPage tabPagePerf;
            this.numericUpDownFPS = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.textBoxShaderPath = new System.Windows.Forms.TextBox();
            this.ButtonShaderOpen = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownTimeScale = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxAutorun = new System.Windows.Forms.CheckBox();
            this.tabPageAbout = new System.Windows.Forms.TabPage();
            this.linkLabelGitHub = new System.Windows.Forms.LinkLabel();
            this.labelContribute = new System.Windows.Forms.Label();
            this.labelSuggestions = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelTaskplay = new System.Windows.Forms.Label();
            this.openFileDialogShader = new System.Windows.Forms.OpenFileDialog();
            tabPagePerf = new System.Windows.Forms.TabPage();
            tabPagePerf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFPS)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeScale)).BeginInit();
            this.tabPageAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPagePerf
            // 
            tabPagePerf.Controls.Add(this.numericUpDownFPS);
            tabPagePerf.Controls.Add(this.label1);
            tabPagePerf.Location = new System.Drawing.Point(4, 29);
            tabPagePerf.Name = "tabPagePerf";
            tabPagePerf.Padding = new System.Windows.Forms.Padding(3);
            tabPagePerf.Size = new System.Drawing.Size(346, 407);
            tabPagePerf.TabIndex = 2;
            tabPagePerf.Text = "Performance";
            tabPagePerf.UseVisualStyleBackColor = true;
            // 
            // numericUpDownFPS
            // 
            this.numericUpDownFPS.Location = new System.Drawing.Point(256, 49);
            this.numericUpDownFPS.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownFPS.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownFPS.Name = "numericUpDownFPS";
            this.numericUpDownFPS.Size = new System.Drawing.Size(86, 26);
            this.numericUpDownFPS.TabIndex = 4;
            this.numericUpDownFPS.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Framerate";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(190, 458);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(271, 458);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageGeneral);
            this.tabControl.Controls.Add(tabPagePerf);
            this.tabControl.Controls.Add(this.tabPageAbout);
            this.tabControl.Location = new System.Drawing.Point(0, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(354, 440);
            this.tabControl.TabIndex = 4;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.textBoxShaderPath);
            this.tabPageGeneral.Controls.Add(this.ButtonShaderOpen);
            this.tabPageGeneral.Controls.Add(this.label3);
            this.tabPageGeneral.Controls.Add(this.numericUpDownTimeScale);
            this.tabPageGeneral.Controls.Add(this.label2);
            this.tabPageGeneral.Controls.Add(this.checkBoxAutorun);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 29);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(346, 407);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "General";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // textBoxShaderPath
            // 
            this.textBoxShaderPath.Location = new System.Drawing.Point(78, 74);
            this.textBoxShaderPath.Name = "textBoxShaderPath";
            this.textBoxShaderPath.Size = new System.Drawing.Size(212, 26);
            this.textBoxShaderPath.TabIndex = 11;
            // 
            // ButtonShaderOpen
            // 
            this.ButtonShaderOpen.Location = new System.Drawing.Point(296, 72);
            this.ButtonShaderOpen.Name = "ButtonShaderOpen";
            this.ButtonShaderOpen.Size = new System.Drawing.Size(32, 31);
            this.ButtonShaderOpen.TabIndex = 10;
            this.ButtonShaderOpen.Text = "...";
            this.ButtonShaderOpen.UseVisualStyleBackColor = true;
            this.ButtonShaderOpen.Click += new System.EventHandler(this.ButtonShaderOpen_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Shader:";
            // 
            // numericUpDownTimeScale
            // 
            this.numericUpDownTimeScale.DecimalPlaces = 1;
            this.numericUpDownTimeScale.Location = new System.Drawing.Point(244, 42);
            this.numericUpDownTimeScale.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownTimeScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownTimeScale.Name = "numericUpDownTimeScale";
            this.numericUpDownTimeScale.Size = new System.Drawing.Size(84, 26);
            this.numericUpDownTimeScale.TabIndex = 8;
            this.numericUpDownTimeScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Timescale";
            // 
            // checkBoxAutorun
            // 
            this.checkBoxAutorun.AutoSize = true;
            this.checkBoxAutorun.Location = new System.Drawing.Point(6, 6);
            this.checkBoxAutorun.Name = "checkBoxAutorun";
            this.checkBoxAutorun.Size = new System.Drawing.Size(312, 24);
            this.checkBoxAutorun.TabIndex = 0;
            this.checkBoxAutorun.Text = "Start ShaderBackground with Windows";
            this.checkBoxAutorun.UseVisualStyleBackColor = true;
            // 
            // tabPageAbout
            // 
            this.tabPageAbout.Controls.Add(this.linkLabelGitHub);
            this.tabPageAbout.Controls.Add(this.labelContribute);
            this.tabPageAbout.Controls.Add(this.labelSuggestions);
            this.tabPageAbout.Controls.Add(this.labelVersion);
            this.tabPageAbout.Controls.Add(this.labelTaskplay);
            this.tabPageAbout.Location = new System.Drawing.Point(4, 29);
            this.tabPageAbout.Name = "tabPageAbout";
            this.tabPageAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAbout.Size = new System.Drawing.Size(346, 407);
            this.tabPageAbout.TabIndex = 1;
            this.tabPageAbout.Text = "About";
            this.tabPageAbout.UseVisualStyleBackColor = true;
            // 
            // linkLabelGitHub
            // 
            this.linkLabelGitHub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabelGitHub.AutoSize = true;
            this.linkLabelGitHub.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelGitHub.Location = new System.Drawing.Point(214, 137);
            this.linkLabelGitHub.Name = "linkLabelGitHub";
            this.linkLabelGitHub.Size = new System.Drawing.Size(60, 20);
            this.linkLabelGitHub.TabIndex = 8;
            this.linkLabelGitHub.TabStop = true;
            this.linkLabelGitHub.Text = "GitHub";
            // 
            // labelContribute
            // 
            this.labelContribute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelContribute.AutoSize = true;
            this.labelContribute.Location = new System.Drawing.Point(6, 137);
            this.labelContribute.Name = "labelContribute";
            this.labelContribute.Size = new System.Drawing.Size(288, 20);
            this.labelContribute.TabIndex = 7;
            this.labelContribute.Text = "Feel free to contribute to the project on ";
            // 
            // labelSuggestions
            // 
            this.labelSuggestions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSuggestions.AutoSize = true;
            this.labelSuggestions.Location = new System.Drawing.Point(6, 120);
            this.labelSuggestions.Name = "labelSuggestions";
            this.labelSuggestions.Size = new System.Drawing.Size(247, 20);
            this.labelSuggestions.TabIndex = 5;
            this.labelSuggestions.Text = "Got a suggestion or found a bug?";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(6, 24);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(86, 20);
            this.labelVersion.TabIndex = 4;
            this.labelVersion.Text = "Version {0}";
            // 
            // labelTaskplay
            // 
            this.labelTaskplay.AutoSize = true;
            this.labelTaskplay.Location = new System.Drawing.Point(6, 7);
            this.labelTaskplay.Name = "labelTaskplay";
            this.labelTaskplay.Size = new System.Drawing.Size(147, 20);
            this.labelTaskplay.TabIndex = 2;
            this.labelTaskplay.Text = "ShaderBackground";
            // 
            // openFileDialogShader
            // 
            this.openFileDialogShader.AddExtension = false;
            this.openFileDialogShader.FileName = "openFileDialog1";
            this.openFileDialogShader.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogShader_FileOk);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 488);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.tabControl);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            tabPagePerf.ResumeLayout(false);
            tabPagePerf.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFPS)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeScale)).EndInit();
            this.tabPageAbout.ResumeLayout(false);
            this.tabPageAbout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.CheckBox checkBoxAutorun;
        private System.Windows.Forms.NumericUpDown numericUpDownFPS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPageAbout;
        private System.Windows.Forms.LinkLabel linkLabelGitHub;
        private System.Windows.Forms.Label labelContribute;
        private System.Windows.Forms.Label labelSuggestions;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelTaskplay;
        private System.Windows.Forms.NumericUpDown numericUpDownTimeScale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxShaderPath;
        private System.Windows.Forms.Button ButtonShaderOpen;
        private System.Windows.Forms.OpenFileDialog openFileDialogShader;
    }
}