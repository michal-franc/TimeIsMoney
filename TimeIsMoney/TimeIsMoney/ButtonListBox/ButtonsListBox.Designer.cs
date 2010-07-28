namespace TimeIsMoney
{
    partial class ButtonsListBox
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
            this.textBoxTodoTitle = new System.Windows.Forms.TextBox();
            this.textBoxTodoPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxMain
            // 
            this.listBoxMain.FormattingEnabled = true;
            this.listBoxMain.Location = new System.Drawing.Point(4, 4);
            this.listBoxMain.Name = "listBoxMain";
            this.listBoxMain.Size = new System.Drawing.Size(140, 186);
            this.listBoxMain.TabIndex = 0;
            // 
            // buttonAddItem
            // 
            this.buttonAddItem.Image = global::TimeIsMoney.Properties.Resources.plus;
            this.buttonAddItem.Location = new System.Drawing.Point(171, 85);
            this.buttonAddItem.Name = "buttonAddItem";
            this.buttonAddItem.Size = new System.Drawing.Size(22, 23);
            this.buttonAddItem.TabIndex = 1;
            this.buttonAddItem.UseVisualStyleBackColor = true;
            this.buttonAddItem.Click += new System.EventHandler(this.buttonAddItem_Click);
            // 
            // buttonEleteItem
            // 
            this.buttonEleteItem.Image = global::TimeIsMoney.Properties.Resources.minus;
            this.buttonEleteItem.Location = new System.Drawing.Point(199, 85);
            this.buttonEleteItem.Name = "buttonEleteItem";
            this.buttonEleteItem.Size = new System.Drawing.Size(23, 23);
            this.buttonEleteItem.TabIndex = 2;
            this.buttonEleteItem.UseVisualStyleBackColor = true;
            this.buttonEleteItem.Click += new System.EventHandler(this.buttonEleteItem_Click);
            // 
            // textBoxTodoTitle
            // 
            this.textBoxTodoTitle.Location = new System.Drawing.Point(150, 20);
            this.textBoxTodoTitle.Name = "textBoxTodoTitle";
            this.textBoxTodoTitle.Size = new System.Drawing.Size(100, 20);
            this.textBoxTodoTitle.TabIndex = 3;
            // 
            // textBoxTodoPath
            // 
            this.textBoxTodoPath.Location = new System.Drawing.Point(150, 59);
            this.textBoxTodoPath.Name = "textBoxTodoPath";
            this.textBoxTodoPath.Size = new System.Drawing.Size(100, 20);
            this.textBoxTodoPath.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(147, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Todo List Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Todo List Path";
            // 
            // ButtonsListBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxTodoPath);
            this.Controls.Add(this.textBoxTodoTitle);
            this.Controls.Add(this.buttonEleteItem);
            this.Controls.Add(this.buttonAddItem);
            this.Controls.Add(this.listBoxMain);
            this.Name = "ButtonsListBox";
            this.Size = new System.Drawing.Size(263, 194);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxMain;
        private System.Windows.Forms.Button buttonAddItem;
        private System.Windows.Forms.Button buttonEleteItem;
        private System.Windows.Forms.TextBox textBoxTodoTitle;
        private System.Windows.Forms.TextBox textBoxTodoPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
