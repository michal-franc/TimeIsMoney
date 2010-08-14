﻿namespace TimeIsMoney.Settings
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxRemindList = new System.Windows.Forms.TextBox();
            this.complexListBox = new TimeIsMoney.ComplexListBox.ComplexListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(28, 202);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxRemindList
            // 
            this.textBoxRemindList.Location = new System.Drawing.Point(152, 25);
            this.textBoxRemindList.Name = "textBoxRemindList";
            this.textBoxRemindList.Size = new System.Drawing.Size(100, 20);
            this.textBoxRemindList.TabIndex = 3;
            this.textBoxRemindList.Click += new System.EventHandler(this.textBoxRemindList_Click);
            // 
            // complexListBox
            // 
            this.complexListBox.Location = new System.Drawing.Point(-2, 2);
            this.complexListBox.Name = "complexListBox";
            this.complexListBox.Size = new System.Drawing.Size(155, 194);
            this.complexListBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Remind List";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 262);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxRemindList);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.complexListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SettingsForm";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        public ComplexListBox.ComplexListBox complexListBox;

        #endregion
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxRemindList;
        private System.Windows.Forms.Label label1;
    }
}