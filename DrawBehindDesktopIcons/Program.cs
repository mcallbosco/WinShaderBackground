using DrawBehindDesktopIcons.Utils;
using Khronos;
using OpenGL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OpenGL.Wgl;


namespace DrawBehindDesktopIcons
{

    class Program
    {

        static ContextMenu contextMenu = new ContextMenu();
        static NotifyIcon taskbarIcon = new NotifyIcon();
        static Thread t = new Thread(new ParameterizedThreadStart(Worker));
        [StructLayout(LayoutKind.Sequential)]
        public struct NativeMessage
        {
            public IntPtr handle;
            public uint msg;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public System.Drawing.Point p;
        }


        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool PeekMessage(out NativeMessage lpMsg, HandleRef hWnd, uint wMsgFilterMin,
   uint wMsgFilterMax, uint wRemoveMsg);

        
        private static void Worker(object num)
        {

            
            int fpsValue =  int.Parse(GetSettingStateString("shaderFPS", "60"));
            float timeScale = float.Parse(GetSettingStateString("shaderTimeScale", "10"));
            string shaderPath = GetSettingStateString("shaderPath", "Shader2.glsl");
            GlOnBackground backgroundRenderer = null;

            try
            {
                backgroundRenderer = new GlOnBackground(File.Open(shaderPath, FileMode.Open, FileAccess.Read));


            }
            catch (Exception e)
            {
                Thread thread = new Thread(spawnSettings);

                // set the thread's apartment state to STA

                MessageBox.Show("Error loading shader Please Select New One\n " + e.Message);
                thread.SetApartmentState(ApartmentState.STA);

                // start the thread
                thread.Start();
                // wait for the thread to finish
                thread.Join();

                Application.Exit();
            }

            bool alive = true;
            var timer = new System.Timers.Timer(10000.0);
            timer.AutoReset = false;
            //timer.Elapsed += (_, __) => { alive = false; };
            timer.Start();
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            while (alive)
            {
                backgroundRenderer.Render((float)(stopWatch.Elapsed.TotalSeconds * (float)(timeScale/10.0f)));
                Thread.Sleep((1000 / fpsValue));
                NativeMessage nativeMsg = new NativeMessage();
                PeekMessage(out nativeMsg, new HandleRef(), 0, 0, 1);
            }
        }

        private static void spawnSettings()
        {
            Application.Run(new SettingsForm());
        }


        [STAThread]
        static void Main()
        {

            MenuItem contextItemSettings = new MenuItem();
            MenuItem contextItemExit = new MenuItem();
            //Setup the context menu items
            contextItemSettings.Text = "&Settings";
            contextItemExit.Text = "&Exit";
            contextItemSettings.Click += new EventHandler(contextMenuSettings_Click);
            contextItemExit.Click += new EventHandler(contextMenuExit_Click);
            //Add the context menu items to the context menu
            contextMenu.MenuItems.Add(contextItemSettings);
            contextMenu.MenuItems.Add(contextItemExit);
            //load in icon from resources
            Icon iconForTaskbar = Properties.Resources.icon;
            taskbarIcon.Icon = iconForTaskbar;
            taskbarIcon.ContextMenu = contextMenu;

            taskbarIcon.Visible = true;
            taskbarIcon.Text = "DrawBehindDesktopIcons";

            //create exit handler
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            //make thread sta mode

            t.IsBackground = true;







            //start shader thead
            t.Start();
            
            Application.Run();

        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            taskbarIcon.Visible = false;
            t.Abort();
        

        }


        private static void taskbarIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private static void contextMenuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();


        }

        private static void contextMenuSettings_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        private static string GetShaderInfoLog(uint shader)
        {
            const int MaxLength = 1024;

            StringBuilder infoLog = new StringBuilder(MaxLength);
            int length;

            Gl.GetShaderInfoLog(shader, MaxLength, out length, infoLog);

            return (infoLog.ToString());
        }
        private static bool GetSettingState(string settingName, bool defaultValueBool = false)
        {
            int defaultValue = defaultValueBool ? 1 : 0;
            var subKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\ShaderBackground");

            var keyValue = subKey.GetValue(settingName);

            if (keyValue == null)
            {
                subKey.SetValue(settingName, defaultValue);
                return defaultValueBool;
            }

            return (int)keyValue == 1;
        }

        private static String GetSettingStateString(string settingName, string defaultValue)
        {
            var subKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\ShaderBackground");

            var keyValue = subKey.GetValue(settingName);

            if (keyValue == null)
            {
                subKey.SetValue(settingName, defaultValue, Microsoft.Win32.RegistryValueKind.String);
                return defaultValue;
            }


            return keyValue.ToString();
        }

    }
}
