namespace Tasklist {
    partial class Index {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>s
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Index));
            this.btnNewTask = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTasks = new System.Windows.Forms.TabPage();
            this.tabPriorities = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabTasks.SuspendLayout();
            this.tabPriorities.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNewTask
            // 
            this.btnNewTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewTask.Location = new System.Drawing.Point(936, 6);
            this.btnNewTask.Name = "btnNewTask";
            this.btnNewTask.Size = new System.Drawing.Size(131, 33);
            this.btnNewTask.TabIndex = 2;
            this.btnNewTask.Text = "Nova Tarefa";
            this.btnNewTask.UseVisualStyleBackColor = true;
            this.btnNewTask.Click += new System.EventHandler(this.btnNewTask_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTasks);
            this.tabControl1.Controls.Add(this.tabPriorities);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1095, 652);
            this.tabControl1.TabIndex = 3;
            // 
            // tabTasks
            // 
            this.tabTasks.AutoScroll = true;
            this.tabTasks.Controls.Add(this.btnNewTask);
            this.tabTasks.Location = new System.Drawing.Point(4, 25);
            this.tabTasks.Name = "tabTasks";
            this.tabTasks.Padding = new System.Windows.Forms.Padding(3);
            this.tabTasks.Size = new System.Drawing.Size(1087, 623);
            this.tabTasks.TabIndex = 0;
            this.tabTasks.Text = "Tarefas";
            this.tabTasks.UseVisualStyleBackColor = true;
            // 
            // tabPriorities
            // 
            this.tabPriorities.Controls.Add(this.button1);
            this.tabPriorities.Location = new System.Drawing.Point(4, 25);
            this.tabPriorities.Name = "tabPriorities";
            this.tabPriorities.Padding = new System.Windows.Forms.Padding(3);
            this.tabPriorities.Size = new System.Drawing.Size(1087, 623);
            this.tabPriorities.TabIndex = 1;
            this.tabPriorities.Text = "Prioridades";
            this.tabPriorities.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(936, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 33);
            this.button1.TabIndex = 4;
            this.button1.Text = "Nova Prioridade";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnNewPriority_Click);
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 676);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1137, 723);
            this.MinimumSize = new System.Drawing.Size(1137, 723);
            this.Name = "Index";
            this.Tag = "";
            this.Text = "Lista de Tarefas";
            this.tabControl1.ResumeLayout(false);
            this.tabTasks.ResumeLayout(false);
            this.tabPriorities.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnNewTask;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTasks;
        private System.Windows.Forms.TabPage tabPriorities;
        private System.Windows.Forms.Button button1;
    }
}

