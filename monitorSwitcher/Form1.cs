using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace monitorSwitcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            RegisterHotKey();
            Hide();
        }

        private void RegisterHotKey()
        {
            // WIN+~ hotkey isn't going to be used anytime soon
            // plus its easy to hit in the dark
            RegisterGlobalHotKey(Keys.Oemtilde, MOD_WIN);
        }

        private void SwitchMode(string args)
        {
            if (m_countdown > 0) return; // we are already in a mode switch

            Process p = Process.Start(@"rundll32",args);
            p.WaitForExit();

            Show();
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;

            CenterToScreen();

            m_countdown = COUNTDOWNMAX;
            m_timer.Enabled = true;
            Show();
        }

        private void SwitchToProjectorMode()
        {
            if (m_countdown > 0) return; // we are already in a mode switch
            m_lblCurMode.Text = "Projector Mode (1280x720)";
            // aka make digital device B the primary.
            SwitchMode(@"nvcpl.dll,dtcfg setview 0 clone DB DA");

            // disable screen saver
            SystemParametersInfo(SPI_SETSCREENSAVEACTIVE, 0, IntPtr.Zero, 0);
        }

        private void SwitchToMonitorMode()
        {
            if (m_countdown > 0) return; // we are already in a mode switch
            m_lblCurMode.Text = "Monitor Mode (1600x1200)";
            // aka make digital device A the primary.
            SwitchMode(@"nvcpl.dll,dtcfg setview 0 clone DA DB");
            // enable screen saver
            SystemParametersInfo(SPI_SETSCREENSAVEACTIVE, 1, IntPtr.Zero, 0);
        }

        int m_countdown = 0;
        const int COUNTDOWNMAX = 50;

        private void ToggleDisplayMode_Click(object sender, EventArgs e)
        {
            DoToggleDisplayMode();
        }

        bool IsInMonitorMode()
        {
            return Screen.PrimaryScreen.Bounds.Width > 1280;
        }

        private void DoToggleDisplayMode()
        {
            if (IsInMonitorMode())
            {
                // we are currently in monitor mode.  switch to projector mode.
                SwitchToProjectorMode();
            }
            else
            {
                // we are currently in projector mode.  switch to projector mode.
                SwitchToMonitorMode();
            }
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            UnregisterGlobalHotKey();
            Close();
        }

        private void OnTick(object sender, EventArgs e)
        {
            m_countdown--;

            float f = (float)m_countdown / (float)COUNTDOWNMAX;
            Opacity = f;
            Refresh();
            CenterToScreen();

            if (m_countdown <= 1)
            {
                WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;
                m_timer.Enabled = false;
                m_countdown = 0;
                UnregisterGlobalHotKey();
                RegisterHotKey();
                Hide();
            }
        }

        private void forceSwitchMonitor_Click(object sender, EventArgs e)
        {
            SwitchToMonitorMode();
        }

        private void forceSwitchProjector_Click(object sender, EventArgs e)
        {
            SwitchToProjectorMode();
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            // let the base class process the message
            base.WndProc(ref m);

            // if this is a WM_HOTKEY message, notify the parent object
            const int WM_HOTKEY = 0x312;
            const int WM_SYSCOMMAND = 0x0112;
            const Int32 SC_SCREENSAVE = 0xF140;
            const int SC_MONITORPOWER = 0xF170;

            if (m.Msg == WM_HOTKEY)
            {
                // do whatever you wish to do when the hotkey is pressed
                // in this example we activate the form and display a messagebox
                DoToggleDisplayMode();
            }
            else if (m.Msg == WM_SYSCOMMAND)
            {
                if ((int)m.WParam == SC_SCREENSAVE ||
                    (int)m.WParam == SC_MONITORPOWER)
                {
                    if (!IsInMonitorMode())
                    {
                        // disable going into monitor power save
                        m.Result = IntPtr.Zero;
                    }
                }
            }
                    
        }

        #region hotkey registration and unregistration

        // Windows API functions and constants
        [DllImport("user32", SetLastError = true)]
        private static extern int RegisterHotKey(IntPtr hwnd, int id, int fsModifiers, int vk);
        [DllImport("user32", SetLastError = true)]
        private static extern int UnregisterHotKey(IntPtr hwnd, int id);
        [DllImport("kernel32", SetLastError = true)]
        private static extern short GlobalAddAtom(string lpString);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SystemParametersInfo(uint uiAction, uint uiParam, IntPtr pvParam, uint fWinIni);

        public const uint SPI_SETSCREENSAVEACTIVE = 0x0011;
        
        // the id for the hotkey
        short hotkeyID;

        private const int MOD_ALT = 1;
        private const int MOD_CONTROL = 2;
        private const int MOD_SHIFT = 4;
        private const int MOD_WIN = 8;

        // register a global hot key
        void RegisterGlobalHotKey(Keys hotkey, int modifiers)
        {
            try
            {
                // use the GlobalAddAtom API to get a unique ID (as suggested by MSDN docs)
                //string atomName = System.Threading.Thread.CurrentThread.ManagedThreadId.ToString("X8") + this.Name;
                hotkeyID = 1; // GlobalAddAtom(atomName);
                if (hotkeyID == 0)
                {
                    throw new Exception("Unable to generate unique hotkey ID. Error code: " +
                       Marshal.GetLastWin32Error().ToString());
                }

                // register the hotkey, throw if any error
                if (RegisterHotKey(this.Handle, hotkeyID, modifiers, (int)hotkey) == 0)
                {
                    throw new Exception("Unable to register hotkey. Error code: " + Marshal.GetLastWin32Error()
                       .ToString());
                }
            }
            catch (Exception)
            {
                // clean up if hotkey registration failed
                MessageBox.Show("Couldn't register global hotkey.  Owned!  Probably you have another instance already running.  This instance will now exit.");
                UnregisterGlobalHotKey();
                Close();
            }
        }

        // unregister a global hotkey
        void UnregisterGlobalHotKey()
        {
            if (this.hotkeyID != 0)
            {
                UnregisterHotKey(this.Handle, hotkeyID);
                // clean up the atom list
                //GlobalDeleteAtom(hotkeyID);
                hotkeyID = 0;
            }
        }

        #endregion

        ~Form1()
        {
            UnregisterGlobalHotKey();
        }

        private void about_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }
    }
}