namespace TrayBin
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            NotifyIcon = new NotifyIcon(components);
            ContextMenu = new ContextMenuStrip(components);
            openToolStripMenuItem = new ToolStripMenuItem();
            emptyToolStripMenuItem = new ToolStripMenuItem();
            doubleclickActionToolStripMenuItem = new ToolStripMenuItem();
            doubleClickActionEmptyToolStripMenuItem = new ToolStripMenuItem();
            doubleClickActionOpenToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            confirmationToolStripMenuItem = new ToolStripMenuItem();
            progressToolStripMenuItem = new ToolStripMenuItem();
            soundToolStripMenuItem = new ToolStripMenuItem();
            addToStartupToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            ContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // NotifyIcon
            // 
            NotifyIcon.ContextMenuStrip = ContextMenu;
            NotifyIcon.Text = "TrayBin";
            NotifyIcon.Visible = true;
            NotifyIcon.MouseDoubleClick += NotifyIcon_MouseDoubleClick;
            // 
            // ContextMenu
            // 
            ContextMenu.Items.AddRange(new ToolStripItem[] { openToolStripMenuItem, emptyToolStripMenuItem, doubleclickActionToolStripMenuItem, settingsToolStripMenuItem, closeToolStripMenuItem });
            ContextMenu.Name = "contextMenuStrip1";
            ContextMenu.Size = new Size(178, 114);
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(177, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // emptyToolStripMenuItem
            // 
            emptyToolStripMenuItem.Name = "emptyToolStripMenuItem";
            emptyToolStripMenuItem.Size = new Size(177, 22);
            emptyToolStripMenuItem.Text = "Empty";
            emptyToolStripMenuItem.Click += emptyToolStripMenuItem_Click;
            // 
            // doubleclickActionToolStripMenuItem
            // 
            doubleclickActionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { doubleClickActionEmptyToolStripMenuItem, doubleClickActionOpenToolStripMenuItem });
            doubleclickActionToolStripMenuItem.Name = "doubleclickActionToolStripMenuItem";
            doubleclickActionToolStripMenuItem.Size = new Size(177, 22);
            doubleclickActionToolStripMenuItem.Text = "Double-click action";
            // 
            // doubleClickActionEmptyToolStripMenuItem
            // 
            doubleClickActionEmptyToolStripMenuItem.Checked = true;
            doubleClickActionEmptyToolStripMenuItem.CheckState = CheckState.Checked;
            doubleClickActionEmptyToolStripMenuItem.Name = "doubleClickActionEmptyToolStripMenuItem";
            doubleClickActionEmptyToolStripMenuItem.Size = new Size(180, 22);
            doubleClickActionEmptyToolStripMenuItem.Text = "Empty";
            doubleClickActionEmptyToolStripMenuItem.Click += doubleClickActionEmptyToolStripMenuItem_Click;
            // 
            // doubleClickActionOpenToolStripMenuItem
            // 
            doubleClickActionOpenToolStripMenuItem.Name = "doubleClickActionOpenToolStripMenuItem";
            doubleClickActionOpenToolStripMenuItem.Size = new Size(180, 22);
            doubleClickActionOpenToolStripMenuItem.Text = "Open";
            doubleClickActionOpenToolStripMenuItem.Click += doubleClickActionOpenToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { confirmationToolStripMenuItem, progressToolStripMenuItem, soundToolStripMenuItem, addToStartupToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(177, 22);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // confirmationToolStripMenuItem
            // 
            confirmationToolStripMenuItem.Name = "confirmationToolStripMenuItem";
            confirmationToolStripMenuItem.Size = new Size(189, 22);
            confirmationToolStripMenuItem.Text = "Remove confirmation";
            confirmationToolStripMenuItem.Click += confirmationToolStripMenuItem_Click;
            // 
            // progressToolStripMenuItem
            // 
            progressToolStripMenuItem.Name = "progressToolStripMenuItem";
            progressToolStripMenuItem.Size = new Size(189, 22);
            progressToolStripMenuItem.Text = "Remove progress bar";
            progressToolStripMenuItem.Click += progressToolStripMenuItem_Click;
            // 
            // soundToolStripMenuItem
            // 
            soundToolStripMenuItem.Name = "soundToolStripMenuItem";
            soundToolStripMenuItem.Size = new Size(189, 22);
            soundToolStripMenuItem.Text = "Remove sound";
            soundToolStripMenuItem.Click += soundToolStripMenuItem_Click;
            // 
            // addToStartupToolStripMenuItem
            // 
            addToStartupToolStripMenuItem.Name = "addToStartupToolStripMenuItem";
            addToStartupToolStripMenuItem.Size = new Size(189, 22);
            addToStartupToolStripMenuItem.Text = "Add to startup";
            addToStartupToolStripMenuItem.Click += addToStartupToolStripMenuItem_Click;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(177, 22);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            ShowInTaskbar = false;
            Text = "Form1";
            WindowState = FormWindowState.Minimized;
            Load += Form1_Load;
            ContextMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private NotifyIcon NotifyIcon;
        private ContextMenuStrip ContextMenu;
        private ToolStripMenuItem doubleclickActionToolStripMenuItem;
        private ToolStripMenuItem doubleClickActionEmptyToolStripMenuItem;
        private ToolStripMenuItem doubleClickActionOpenToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem confirmationToolStripMenuItem;
        private ToolStripMenuItem progressToolStripMenuItem;
        private ToolStripMenuItem soundToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem emptyToolStripMenuItem;
        private ToolStripMenuItem addToStartupToolStripMenuItem;
    }
}
