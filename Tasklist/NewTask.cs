using Library;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Tasklist {
    public partial class NewTask : Form {
        private PriorityBLL _priorityBLL = new PriorityBLL();
        private StatusBLL _statusBLL = new StatusBLL();
        private TaskBLL _taskBLL = new TaskBLL();

        protected List<PriorityVO> listPriority;
        protected List<StatusVO> listStatus;
        protected TaskVO task;


        public NewTask(object[] args) {
            this.Font = new System.Drawing.Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
            this.AutoScaleMode = AutoScaleMode.None;

            InitializeComponent();

            listPriority = _priorityBLL.GetList();
            listStatus = _statusBLL.GetList();
            
            cbbPriority.Items.AddRange(listPriority.Select(p=> new ComboboxItem() { Text = p.Name, Value = p.PriorityID } ).ToArray());
            cbbStatus.Items.AddRange(listStatus.Select(p => new ComboboxItem() { Text = p.Name, Value = p.StatusID }).ToArray());


            task = new TaskVO();
            if (args != null && args.Length == 1) {
                task = _taskBLL.GetById((int)args[0]);
                UpdateTask();
            } else {
                btnReset.Visible = false;
            }
        }


        private void UpdateTask() {
            txtName.Text = task.Name;
            txtDescription.Text = task.Description;

            cbbPriority.SelectedItem = (cbbPriority.Items.Cast<ComboboxItem>()).Where(p => p.Value == task.PriorityID).FirstOrDefault();
            cbbStatus.SelectedItem = (cbbStatus.Items.Cast<ComboboxItem>()).Where(p => p.Value == task.StatusID).FirstOrDefault();
        }

        private void btnSave_Click(object sender, System.EventArgs e) {
            if (string.IsNullOrEmpty(txtName.Text)) {
                MessageBox.Show("A tarefa deve possuir um nome.");
                return;
            }

            if (cbbStatus.SelectedItem == null) {
                MessageBox.Show("A tarefa deve possuir um status.");
                return;
            }

            if (cbbPriority.SelectedItem == null) {
                MessageBox.Show("A tarefa deve possuir uma prioridade.");
                return;
            }

            task.Name = txtName.Text;
            task.Description = txtDescription.Text;

            task.StatusID = ((ComboboxItem)cbbStatus.SelectedItem).Value;
            task.PriorityID = ((ComboboxItem)cbbPriority.SelectedItem).Value;

            if (task.TaskID > 0) {
                _taskBLL.Update(task);
            } else {
                _taskBLL.Create(task);
            }

            MessageBox.Show("Tarefa Criada com Sucesso!");
            this.Dispose();
        }

        private void btnReset_Click(object sender, System.EventArgs e) {
            UpdateTask();
        }
    }

    public class ComboboxItem {
        public string Text { get; set; }
        public int Value { get; set; }

        public override string ToString() {
            return Text;
        }
    }
}
