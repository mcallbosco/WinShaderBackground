using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawBehindDesktopIcons
{
    public partial class SettingsForm : Form
    {
        Microsoft.Win32.RegistryKey autorun;
        Microsoft.Win32.RegistryKey settings;
        public SettingsForm()
        {
            InitializeComponent();
            autorun = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            settings = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\ShaderBackground");
            numericUpDownTimeScale.Value = decimal.Parse(settings.GetValue("shaderTimeScale").ToString());
            numericUpDownFPS.Value = int.Parse(settings.GetValue("shaderFPS").ToString());
            textBoxShaderPath.Text = settings.GetValue("shaderPath").ToString();

        }



        private void buttonOK_Click(object sender, EventArgs e)
        {

            if (checkBoxAutorun.Checked)
                autorun.SetValue("ShaderBackground", Application.ExecutablePath);
            else
                autorun.DeleteValue("ShaderBackground", false);
           
            settings.SetValue("shaderTimeScale", numericUpDownTimeScale.Value);
            settings.SetValue("shaderFPS", numericUpDownFPS.Value);
            //check if the shader is a valid file
            if (System.IO.File.Exists(textBoxShaderPath.Text) && textBoxShaderPath.Text.EndsWith(".glsl"))
            {
                settings.SetValue("shaderPath", textBoxShaderPath.Text);
            }
            else
            {
                MessageBox.Show("Please select a valid shader file");
            }


            Application.Restart();
            this.Close();




        }

        private void ButtonShaderOpen_Click(object sender, EventArgs e)
        {
            //open the file dialog
            openFileDialogShader.ShowDialog();
        }

        private void openFileDialogShader_FileOk(object sender, CancelEventArgs e)
        {
            //allow it to only open glsl files
            if (openFileDialogShader.FileName.EndsWith(".glsl"))
            {
                settings.SetValue("shaderPath", openFileDialogShader.FileName);
                textBoxShaderPath.Text = openFileDialogShader.FileName;
            }
            else
            {
                MessageBox.Show("Please select a .glsl file");
            }
        }
    }
}
