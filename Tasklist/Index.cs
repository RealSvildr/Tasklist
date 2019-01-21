using Library;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Tasklist {
    public partial class Index : Form {
        private TaskBLL _taskBLL = new TaskBLL();
        private PriorityBLL _priorityBLL = new PriorityBLL();

        public Index() {
            this.Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
            this.AutoScaleMode = AutoScaleMode.None;

            InitializeComponent();

            loadTasks();
            loadPriorities();
        }

        #region Task
        private List<iControls> _listTaskControl = new List<iControls>();

        private void loadTasks() {
            List<TaskVO> listTask = _taskBLL.GetList();

            //Clear Actual
            while (_listTaskControl.Count > 0) {
                _listTaskControl[0].Panel.Controls.Clear();
                _listTaskControl[0].Panel.Dispose();
                _listTaskControl.RemoveAt(0);
            }

            foreach (var task in listTask) {
                Panel panel = CreateTaskPanel(task, _listTaskControl.Count);
                tabTasks.Controls.Add(panel);

                _listTaskControl.Add(new iControls() {
                    ControlerID = task.TaskID,
                    Panel = panel
                });
            }
        }

        private void btnNewTask_Click(object sender, EventArgs e) {
            NewTask newTask = new NewTask(new object[] { });
            newTask.ShowDialog();

            loadTasks();
        }
        private void btnEditTask_Click(object sender, EventArgs e) {
            int id = Convert.ToInt32(((PictureBox)sender).Tag);

            NewTask newTask = new NewTask(new object[] { id });
            newTask.ShowDialog();

            loadTasks();
        }
        private void btnDeleteTask_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Você têm certeza, que deseja deletar esta tarefa", "Deletar Tarefa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes) {

                int id = Convert.ToInt32(((PictureBox)sender).Tag);

                TaskVO item = _taskBLL.GetById(id);
                _taskBLL.Delete(item);
                MessageBox.Show("Tarefa deletada com sucesso.");

                loadTasks();
            }
        }

        private Panel CreateTaskPanel(TaskVO task, int nSize) {
            Panel newPanel = new Panel {
                AutoScroll = true,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(6, 45 + (186 * nSize)),
                Size = new Size(1060, 177)
            };

            Label title = new Label {
                AutoSize = true,
                Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
                Location = new Point(15, 12),
                Size = new Size(165, 29),
                Text = task.Name
            };

            Label statusPriority = new Label {
                AutoSize = true,
                Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Italic, GraphicsUnit.Point, ((byte)(0))),
                Location = new Point(17, 42),
                Size = new Size(239, 17),
                Text = "Prioridade: " + task.Priority.Name + "      Status: " + task.Status.Name
            };

            Label description = new Label {
                Location = new Point(17, 75),
                Size = new Size(977, 82),
                Text = task.Description
            };

            PictureBox delete = new PictureBox {
                Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right))),
                Cursor = Cursors.Hand,
                Image = global::Tasklist.Properties.Resources.closeButton,
                Location = new Point(1013, 3),
                Size = new Size(40, 40),
                TabStop = false,
                Tag = task.TaskID
            };
            delete.Click += new EventHandler(btnDeleteTask_Click);

            PictureBox edit = new PictureBox {
                Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right))),
                Cursor = Cursors.Hand,
                Image = global::Tasklist.Properties.Resources.editButton,
                Location = new Point(1013, 49),
                Size = new Size(40, 40),
                TabStop = false,
                Tag = task.TaskID
            };
            edit.Click += new EventHandler(btnEditTask_Click);

            newPanel.Controls.Add(title);
            newPanel.Controls.Add(statusPriority);
            newPanel.Controls.Add(description);
            newPanel.Controls.Add(delete);
            newPanel.Controls.Add(edit);

            /*Resize Description*/
            Size sz = new Size(description.Width, Int32.MaxValue);
            sz = TextRenderer.MeasureText(description.Text, description.Font, sz, TextFormatFlags.WordBreak);
            description.Height = sz.Height;

            return newPanel;
        }
        #endregion

        #region Priority
        private List<iControls> _listPriorityControl = new List<iControls>();

        private void loadPriorities() {
            List<PriorityVO> listPriority = _priorityBLL.GetList();

            //Clear Actual
            while (_listPriorityControl.Count > 0) {
                _listPriorityControl[0].Panel.Controls.Clear();
                _listPriorityControl[0].Panel.Dispose();
                _listPriorityControl.RemoveAt(0);
            }

            foreach (var priority in listPriority) {
                Panel panel = CreatePriorityPanel(priority, _listPriorityControl.Count);
                tabPriorities.Controls.Add(panel);

                _listPriorityControl.Add(new iControls() {
                    ControlerID = priority.PriorityID,
                    Panel = panel
                });
            }
        }

        private void btnNewPriority_Click(object sender, EventArgs e) {
            NewPriority newPriority = new NewPriority(new object[] { });
            newPriority.ShowDialog();

            loadPriorities();
        }
        private void btnEditPriority_Click(object sender, EventArgs e) {
            int id = Convert.ToInt32(((PictureBox)sender).Tag);

            NewPriority newPriority = new NewPriority(new object[] { id });
            newPriority.ShowDialog();

            loadPriorities();
        }
        private void btnDeletePriority_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Você têm certeza, que deseja deletar esta prioridade", "Deletar Prioridade",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes) {


                try {
                    int id = Convert.ToInt32(((PictureBox)sender).Tag);

                    PriorityVO item = _priorityBLL.GetById(id);
                    _priorityBLL.Delete(item);
                    MessageBox.Show("Prioridade deletada com sucesso.");

                    loadPriorities();
                } catch (Exception) {
                    MessageBox.Show("Não é possível deletar uma prioridade que já está sendo utilizada.");
                }

            }
        }

        private Panel CreatePriorityPanel(PriorityVO priority, int nSize) {
            Panel newPanel = new Panel {
                AutoScroll = true,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(6, 45 + (186 * nSize)),
                Size = new Size(1060, 145) // 177
            };

            Label title = new Label {
                AutoSize = true,
                Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
                Location = new Point(15, 12),
                Size = new Size(165, 29),
                Text = priority.Name
            };

            Label level = new Label {
                AutoSize = true,
                Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Italic, GraphicsUnit.Point, ((byte)(0))),
                Location = new Point(17, 40),
                Size = new Size(239, 17),
                Text = "Nível de Prioridade: " + priority.PriorityLevel
            };

            Label description = new Label {
                Location = new Point(17, 70),
                Size = new Size(977, 82),
                Text = priority.Description
            };

            PictureBox delete = new PictureBox {
                Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right))),
                Cursor = Cursors.Hand,
                Image = global::Tasklist.Properties.Resources.closeButton,
                Location = new Point(1013, 3),
                Size = new Size(40, 40),
                TabStop = false,
                Tag = priority.PriorityID
            };
            delete.Click += new EventHandler(btnDeletePriority_Click);

            PictureBox edit = new PictureBox {
                Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right))),
                Cursor = Cursors.Hand,
                Image = global::Tasklist.Properties.Resources.editButton,
                Location = new Point(1013, 49),
                Size = new Size(40, 40),
                TabStop = false,
                Tag = priority.PriorityID
            };
            edit.Click += new EventHandler(btnEditPriority_Click);

            newPanel.Controls.Add(title);
            newPanel.Controls.Add(level);
            newPanel.Controls.Add(description);
            newPanel.Controls.Add(delete);
            newPanel.Controls.Add(edit);

            /*Resize Description*/
            Size sz = new Size(description.Width, Int32.MaxValue);
            sz = TextRenderer.MeasureText(description.Text, description.Font, sz, TextFormatFlags.WordBreak);
            description.Height = sz.Height;

            return newPanel;
        }
        #endregion
    }

    internal class iControls {
        public int ControlerID { get; set; }
        public Panel Panel { get; set; }
    }
}
