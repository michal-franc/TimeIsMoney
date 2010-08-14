namespace TimeIsMoney
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIconUnsortedItems = new System.Windows.Forms.NotifyIcon(this.components);
            this.listBoxTasks = new TimeIsMoney.ColorableListBox();
            this.notifyIconTasks = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // notifyIconUnsortedItems
            // 
            this.notifyIconUnsortedItems.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconUnsortedItems.Icon")));
            this.notifyIconUnsortedItems.Text = "notifyIcon1";
            this.notifyIconUnsortedItems.Visible = true;
            this.notifyIconUnsortedItems.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // listBoxTasks
            // 
            this.listBoxTasks.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBoxTasks.FormattingEnabled = true;
            this.listBoxTasks.Location = new System.Drawing.Point(12, 16);
            this.listBoxTasks.Name = "listBoxTasks";
            this.listBoxTasks.Size = new System.Drawing.Size(125, 238);
            this.listBoxTasks.TabIndex = 0;
            // 
            // notifyIconTasks
            // 
            this.notifyIconTasks.Text = "notifyIconTasks";
            this.notifyIconTasks.Visible = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(146, 266);
            this.Controls.Add(this.listBoxTasks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "TimeIsMoney";
            this.TopMost = true;
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private ColorableListBox listBoxTasks;
        private System.Windows.Forms.NotifyIcon notifyIconUnsortedItems;
        private System.Windows.Forms.NotifyIcon notifyIconTasks;
    }
}

