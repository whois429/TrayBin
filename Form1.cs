using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Shell32;

namespace TrayBin
{
    public partial class Form1 : Form
    {
        enum RecycleFlags : uint
        {
            SHRB_NOCONFIRMATION = 0x00000001,
            SHRB_NOPROGRESSUI = 0x00000002,
            SHRB_NOSOUND = 0x00000004
        }

        [DllImport("Shell32.dll", CharSet = CharSet.Unicode)]
        static extern uint SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, RecycleFlags dwFlags);

        static Shell shell = new Shell();
        Folder recycleBin = shell.NameSpace(10);

        public Form1()
        {
            InitializeComponent();

            FileSystemWatcher CDriveWatcher = new FileSystemWatcher(@"C:\\$Recycle.Bin");

            CDriveWatcher.Changed += OnChanged;
            CDriveWatcher.EnableRaisingEvents = true;

            FileSystemWatcher DDriveWatcher = new FileSystemWatcher(@"D:\\$Recycle.Bin");

            DDriveWatcher.Changed += OnChanged;
            DDriveWatcher.EnableRaisingEvents = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Visible = false;
            NotifyIcon.Visible = true;

            if (Properties.Settings.Default.DoubleClickAction == "empty")
            {
                doubleClickActionEmptyToolStripMenuItem.Checked = true;
                doubleClickActionOpenToolStripMenuItem.Checked = false;
            }
            else
            {
                doubleClickActionOpenToolStripMenuItem.Checked = true;
                doubleClickActionEmptyToolStripMenuItem.Checked = false;
            }

            if (Properties.Settings.Default.RemoveConfirmation)
            {
                confirmationToolStripMenuItem.Checked = true;
            }

            if (Properties.Settings.Default.RemoveProgressBar)
            {
                progressToolStripMenuItem.Checked = true;
            }

            if (Properties.Settings.Default.RemoveSound)
            {
                soundToolStripMenuItem.Checked = true;
            }

            if (Properties.Settings.Default.AddToStartup)
            {
                addToStartupToolStripMenuItem.Checked = true;
            }

            if (recycleBin.Items().Count == 0)
            {
                NotifyIcon.Icon = Properties.Resources.Empty;
            }
            else
            {
                NotifyIcon.Icon = Properties.Resources.Full;
            }
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (recycleBin.Items().Count == 0)
            {
                NotifyIcon.Icon = Properties.Resources.Empty;
            }
            else
            {
                NotifyIcon.Icon = Properties.Resources.Full;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "shell:RecycleBinFolder");
        }

        private void emptyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (confirmationToolStripMenuItem.Checked && progressToolStripMenuItem.Checked && soundToolStripMenuItem.Checked)
            {
                SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHRB_NOCONFIRMATION | RecycleFlags.SHRB_NOPROGRESSUI | RecycleFlags.SHRB_NOSOUND);
            }
            else if (confirmationToolStripMenuItem.Checked && progressToolStripMenuItem.Checked && !soundToolStripMenuItem.Checked)
            {
                SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHRB_NOCONFIRMATION | RecycleFlags.SHRB_NOPROGRESSUI);
            }
            else if (confirmationToolStripMenuItem.Checked && !progressToolStripMenuItem.Checked && soundToolStripMenuItem.Checked)
            {
                SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHRB_NOCONFIRMATION | RecycleFlags.SHRB_NOSOUND);
            }
            else if (!confirmationToolStripMenuItem.Checked && progressToolStripMenuItem.Checked && soundToolStripMenuItem.Checked)
            {
                SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHRB_NOPROGRESSUI | RecycleFlags.SHRB_NOSOUND);
            }
            else if (confirmationToolStripMenuItem.Checked && !progressToolStripMenuItem.Checked && !soundToolStripMenuItem.Checked)
            {
                SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHRB_NOCONFIRMATION);
            }
            else if (!confirmationToolStripMenuItem.Checked && progressToolStripMenuItem.Checked && !soundToolStripMenuItem.Checked)
            {
                SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHRB_NOPROGRESSUI);
            }
            else if (!confirmationToolStripMenuItem.Checked && !progressToolStripMenuItem.Checked && soundToolStripMenuItem.Checked)
            {
                SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHRB_NOSOUND);
            }
        }

        private void doubleClickActionEmptyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!doubleClickActionEmptyToolStripMenuItem.Checked)
            {
                doubleClickActionEmptyToolStripMenuItem.Checked = true;
                doubleClickActionOpenToolStripMenuItem.Checked = false;

                Properties.Settings.Default.DoubleClickAction = "empty";
                Properties.Settings.Default.Save();
            }
        }

        private void doubleClickActionOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!doubleClickActionOpenToolStripMenuItem.Checked)
            {
                doubleClickActionOpenToolStripMenuItem.Checked = true;
                doubleClickActionEmptyToolStripMenuItem.Checked = false;

                Properties.Settings.Default.DoubleClickAction = "open";
                Properties.Settings.Default.Save();
            }
        }

        private void confirmationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (confirmationToolStripMenuItem.Checked && (progressToolStripMenuItem.Checked || soundToolStripMenuItem.Checked))
            {
                confirmationToolStripMenuItem.Checked = false;
            }
            else
            {
                confirmationToolStripMenuItem.Checked = true;
            }

            Properties.Settings.Default.RemoveConfirmation = confirmationToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
        }

        private void progressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (progressToolStripMenuItem.Checked && (confirmationToolStripMenuItem.Checked || soundToolStripMenuItem.Checked))
            {
                progressToolStripMenuItem.Checked = false;
            }
            else
            {
                progressToolStripMenuItem.Checked = true;
            }

            Properties.Settings.Default.RemoveProgressBar = progressToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
        }

        private void soundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (soundToolStripMenuItem.Checked && (confirmationToolStripMenuItem.Checked || progressToolStripMenuItem.Checked))
            {
                soundToolStripMenuItem.Checked = false;
            }
            else
            {
                soundToolStripMenuItem.Checked = true;
            }

            Properties.Settings.Default.RemoveSound = soundToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
        }

        private void addToStartupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string keys = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run";
            string value = "TrayBin";

            if (!addToStartupToolStripMenuItem.Checked)
            {
                addToStartupToolStripMenuItem.Checked = true;
                if (Registry.GetValue(keys, value, null) == null)
                {
                    var regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    regKey.SetValue(value, Application.ExecutablePath);
                }
            }
            else
            {
                addToStartupToolStripMenuItem.Checked = false;
                if (Registry.GetValue(keys, value, null) != null)
                {
                    var regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    regKey.DeleteValue(value);
                }
            }

            Properties.Settings.Default.AddToStartup = addToStartupToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (doubleClickActionEmptyToolStripMenuItem.Checked)
            {
                if (confirmationToolStripMenuItem.Checked && progressToolStripMenuItem.Checked && soundToolStripMenuItem.Checked)
                {
                    SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHRB_NOCONFIRMATION | RecycleFlags.SHRB_NOPROGRESSUI | RecycleFlags.SHRB_NOSOUND);
                }
                else if (confirmationToolStripMenuItem.Checked && progressToolStripMenuItem.Checked && !soundToolStripMenuItem.Checked)
                {
                    SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHRB_NOCONFIRMATION | RecycleFlags.SHRB_NOPROGRESSUI);
                }
                else if (confirmationToolStripMenuItem.Checked && !progressToolStripMenuItem.Checked && soundToolStripMenuItem.Checked)
                {
                    SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHRB_NOCONFIRMATION | RecycleFlags.SHRB_NOSOUND);
                }
                else if (!confirmationToolStripMenuItem.Checked && progressToolStripMenuItem.Checked && soundToolStripMenuItem.Checked)
                {
                    SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHRB_NOPROGRESSUI | RecycleFlags.SHRB_NOSOUND);
                }
                else if (confirmationToolStripMenuItem.Checked && !progressToolStripMenuItem.Checked && !soundToolStripMenuItem.Checked)
                {
                    SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHRB_NOCONFIRMATION);
                }
                else if (!confirmationToolStripMenuItem.Checked && progressToolStripMenuItem.Checked && !soundToolStripMenuItem.Checked)
                {
                    SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHRB_NOPROGRESSUI);
                }
                else if (!confirmationToolStripMenuItem.Checked && !progressToolStripMenuItem.Checked && soundToolStripMenuItem.Checked)
                {
                    SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHRB_NOSOUND);
                }
            }
            else
            {
                System.Diagnostics.Process.Start("explorer.exe", "shell:RecycleBinFolder");
            }
        }
    }
}
