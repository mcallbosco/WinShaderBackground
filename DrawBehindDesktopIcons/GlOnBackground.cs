using DrawBehindDesktopIcons.Utils;
using Khronos;
using OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using static OpenGL.Wgl;


[StructLayout(LayoutKind.Sequential)]
public struct POINT
{
    public int X;
    public int Y;

    public static implicit operator Point(POINT point)
    {
        return new Point(point.X, point.Y);
    }
}


namespace DrawBehindDesktopIcons
{
    public class GlOnBackground
    {
        NativeWindow nativeWin = new NativeWindow();
        private DeviceContext _deviceContext;

        private uint _program;
        private Point _screenResolution;
        public bool pauseRendering = false;

        public GlOnBackground(Stream shader)
        {
            using (StreamReader sr = new StreamReader(shader))
            {
                _setupContext(sr.ReadToEnd());
            }
        }

        private static string GetShaderInfoLog(uint shader)
        {
            const int MaxLength = 1024;

            StringBuilder infoLog = new StringBuilder(MaxLength);
            int length;

            Gl.GetShaderInfoLog(shader, MaxLength, out length, infoLog);

            return (infoLog.ToString());
        }

        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out Point lpPoint);

        private void _setupContext(string shaderCode)
        {
            //make end all tasks run on thread abort
            AppDomain.CurrentDomain.ProcessExit += delegate (object sender, EventArgs e)
            {
                endAllTasks();
            };
            int screenCount = 1;


            IntPtr workerw = Utils.Windows.GetWindowsBackgroundHandle();


            var screen = Screen.PrimaryScreen;

            _screenResolution = new Point(screen.Bounds.Width, screen.Bounds.Height);

            var pfd = new PIXELFORMATDESCRIPTOR
            {
                nVersion = 1,
                dwFlags = (PixelFormatDescriptorFlags)(PFD_DRAW_TO_WINDOW | PFD_SUPPORT_OPENGL | PFD_DOUBLEBUFFER | PFD_TYPE_RGBA),
                cColorBits = 32,
                cDepthBits = 24,
                dwLayerMask = PFD_MAIN_PLANE


            };

            string envDebug = Environment.GetEnvironmentVariable("DEBUG");
            if (true)//envDebug == "GL")
            {
                Khronos.KhronosApi.Log += delegate (object sender, KhronosLogEventArgs e)
                {
                    Console.WriteLine("GLLog=>" + e.ToString());
                };
                Khronos.KhronosApi.LogEnabled = true;
            }


            Gl.Initialize();
            OpenGL.Egl.IsRequired = false;




            var cPar = new CreateParams();
            cPar.X = 0;
            cPar.Y = 0;
            cPar.Width = _screenResolution.X;
            cPar.Height = _screenResolution.Y;
            cPar.Style = Windows.WS_CHILD | Windows.WS_VISIBLE | Windows.WS_CLIPSIBLINGS | Windows.WS_CLIPCHILDREN;
            cPar.Parent = workerw;

            //create an event for if the window is covered

            nativeWin.CreateHandle(cPar);

            var subWinDC = W32.GetDC(nativeWin.Handle);

            int iPxlFmt = OpenGL.Wgl.ChoosePixelFormat(subWinDC, ref pfd);
            OpenGL.Wgl.SetPixelFormat(subWinDC, iPxlFmt, ref pfd);




            W32.SetParent(nativeWin.Handle, workerw);
            _deviceContext = DeviceContext.Create(IntPtr.Zero, nativeWin.Handle);
            //var pixFmt = new DevicePixelFormat(32);
            //deviceContext.ChoosePixelFormat(pixFmt);
            //deviceContext.SetPixelFormat(pixFmt);
            _deviceContext.MakeCurrent(subWinDC);

            IntPtr glContext2 = _deviceContext.CreateContext(IntPtr.Zero);
            
            if (glContext2 == IntPtr.Zero)
                throw new System.ComponentModel.Win32Exception(System.Runtime.InteropServices.Marshal.GetLastWin32Error());


            
            _deviceContext.MakeCurrent(glContext2);
          



         


            //detect the type of shader 
            uint shaderId = 0;
            String shaderType = "";

            if (shaderCode.Contains("gl_FragColor"))
            {
                shaderId = Gl.CreateShader(OpenGL.ShaderType.FragmentShader);
                shaderType = "Fragment";
            }

            else if (shaderCode.Contains("gl_Position"))
            {
                shaderId = Gl.CreateShader(OpenGL.ShaderType.VertexShader);
                shaderType = "Vertex";
            }
            else
            {
                throw new Exception("Invalid Shader");
            }


            var glslCode = shaderCode;
            var shader = new string[] { glslCode };
            Gl.ShaderSource(shaderId, shader);
            Gl.CompileShader(shaderId);
            int compileStatus;
            Gl.GetShader(shaderId, ShaderParameterName.CompileStatus, out compileStatus);
            if (compileStatus == 0)
                throw new InvalidOperationException("unable to compiler " + shaderType +" shader: " + GetShaderInfoLog(shaderId));

            _program = Gl.CreateProgram();


            Gl.AttachShader(_program, shaderId);

            int[] arr = new int[42];
            Gl.GetProgram(0, ProgramProperty.ActiveUniforms, arr);
            Gl.LinkProgram(_program);
            Gl.GetProgram(_program, ProgramProperty.LinkStatus, out compileStatus);
            if (compileStatus == 0)
                throw new InvalidOperationException("unable to link program");


            Gl.UseProgram(_program);
        }

        public void Render(float time, bool mouseTrack = true)
        {
            
            var timeLoc = Gl.GetUniformLocation(_program, "time");
            Gl.Uniform1(timeLoc, time);
            var mouseLoc = Gl.GetUniformLocation(_program, "mouse");
            Gl.Uniform2(mouseLoc, -1f, -1f);
            if (mouseTrack)
            {
                Point cursorPos;
                GetCursorPos(out cursorPos);
                //update the mouse position
                Gl.Uniform2(mouseLoc, (float)cursorPos.X / _screenResolution.X, (float)cursorPos.Y / _screenResolution.Y);
            }
            




            var resolutionLoc = Gl.GetUniformLocation(_program, "resolution");
            //Gl.UNIFORM
            Gl.Uniform2(resolutionLoc, (float)_screenResolution.X, (float)_screenResolution.Y);

            /*
             IMPLIMENT THESE
            uniform vec3 iResolution;
uniform float iTime;
uniform float iTimeDelta;
uniform float iFrame;
uniform float iChannelTime[4];
uniform vec4 iMouse;
uniform vec4 iDate;
uniform float iSampleRate;
uniform vec3 iChannelResolution[4];
uniform samplerXX iChanneli;*/

            Gl.Uniform2(Gl.GetUniformLocation(_program, "IResolution"), (float)_screenResolution.X, (float)_screenResolution.Y);
            Gl.Uniform1(Gl.GetUniformLocation(_program, "ITime"), time);
            Gl.Uniform1(Gl.GetUniformLocation(_program, "ITimeDelta"), 0.0f);
            Gl.Uniform1(Gl.GetUniformLocation(_program, "IFrame"), 0.0f);
            Gl.Uniform4(Gl.GetUniformLocation(_program, "IMouse"), -1.0f, -1.0f, 0.0f, 0.0f);
            Gl.Uniform4(Gl.GetUniformLocation(_program, "IDate"), 0.0f, 0.0f, 0.0f, 0.0f);
            Gl.Uniform1(Gl.GetUniformLocation(_program, "ISampleRate"), 0.0f);
            Gl.Uniform3(Gl.GetUniformLocation(_program, "IChannelResolution"), 0.0f, 0.0f, 0.0f);
            Gl.Uniform1(Gl.GetUniformLocation(_program, "IChannel0"), 0.0f);
            Gl.Uniform1(Gl.GetUniformLocation(_program, "IChannel1"), 0.0f);
            Gl.Uniform1(Gl.GetUniformLocation(_program, "IChannel2"), 0.0f);
            Gl.Uniform1(Gl.GetUniformLocation(_program, "IChannel3"), 0.0f);

            //Gl.Viewport(0, 0, _screenResolution.X, _screenResolution.Y);




            OpenGL.Gl.Rect(-1, -1, 1, 1);


            _deviceContext.SwapBuffers();


        }




        public static Bitmap ScaleUp(Bitmap original, int factor)
        {
            // Create the new Bitmap object
            Bitmap scaledUp = new Bitmap(original.Width * factor, original.Height * factor);

            // Loop through every pixel in the original image
            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    // Get the original pixel's color
                    Color pixelColor = original.GetPixel(x, y);

                    // Copy the pixel's color to the appropriate square of pixels in the scaled-up image
                    for (int xScaled = x * factor; xScaled < (x + 1) * factor; xScaled++)
                    {
                        for (int yScaled = y * factor; yScaled < (y + 1) * factor; yScaled++)
                        {
                            scaledUp.SetPixel(xScaled, yScaled, pixelColor);
                        }
                    }
                }
            }

            // Return the scaled-up image
            return scaledUp;
        }


        public void endAllTasks()
        {
            
            nativeWin.ReleaseHandle();
            _deviceContext.Dispose();
            _deviceContext = null;



        }
    }
}
