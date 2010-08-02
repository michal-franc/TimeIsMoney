namespace TimeIsMoney
{
    partial class ComplexListBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxMain = new System.Windows.Forms.ListBox();
            this.buttonAddItem = new System.Windows.Forms.Button();
            this.buttonEleteItem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxMain
            // 
            this.listBoxMain.FormattingEnabled = true;
            this.listBoxMain.Location = new System.Drawing.Point(4, 4);
            this.listBoxMain.Name = "listBoxMain";
            this.listBoxMain.Size = new System.Drawing.Size(140, 160);
            this.listBoxMain.TabIndex = 0;
            // 
            // buttonAddItem
            // 
            this.buttonAddItem.Image = global::TimeIsMoney.Properties.Resources.plus;
            this.buttonAddItem.Location = new System.Drawing.Point(52, 168);
            this.buttonAddItem.Name = "buttonAddItem";
            this.buttonAddItem.Size = new System.Drawing.Size(22, 23);
            this.buttonAddItem.TabIndex = 1;
            this.buttonAddItem.UseVisualStyleBackColor = true;
            this.buttonAddItem.Click += new System.EventHandler(this.buttonAddItem_Click);
            // 
            // buttonEleteItem
            // 
            this.buttonEleteItem.Image = global::TimeIsMoney.Properties.Resources.minus;
            this.buttonEleteItem.Location = new System.Drawing.Point(80, 168);
            this.buttonEleteItem.Name = "buttonEleteItem";
            this.buttonEleteItem.Size = new System.Drawing.Size(23, 23);
            this.buttonEleteItem.TabIndex = 2;
            this.buttonEleteItem.UseVisualStyleBackColor = true;
            this.buttonEleteItem.Click += new System.EventHandler(this.buttonDeleteItem_Click);
            // 
            // ButtonsListBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonEleteItem);
            this.Controls.Add(this.buttonAddItem);
            this.Controls.Add(this.listBoxMain);
            this.Name = "ButtonsListBox";
            this.Size = new System.Drawing.Size(151, 194);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxMain;
        private System.Windows.Forms.Button buttonAddItem;
        private System.Windows.Forms.Button buttonEleteItem;
    }
}
