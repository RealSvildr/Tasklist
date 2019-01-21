using Library;
using System.Linq;
using System.Windows.Forms;

namespace Tasklist {
    public partial class NewPriority : Form {
        private PriorityBLL _priorityBLL = new PriorityBLL();
        protected PriorityVO priority = new PriorityVO();

        public NewPriority(object[] args) {
            this.Font = new System.Drawing.Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
            this.AutoScaleMode = AutoScaleMode.None;
            InitializeComponent();

            cbbLevel.Items.AddRange(new ComboboxItem[] {
                new ComboboxItem { Value = 1, Text = "1 - Sem Prioridade" },
                new ComboboxItem { Value = 2, Text = "2 - Prioridade Baixa" },
                new ComboboxItem { Value = 3, Text = "3 - Prioridade Média" },
                new ComboboxItem { Value = 4, Text = "4 - Prioridade Alta" },
                new ComboboxItem { Value = 5, Text = "5 - Prioridade Altissima" },
                new ComboboxItem { Value = 6, Text = "6 - Prioridade Máxima" }
            });

            priority = new PriorityVO();
            if (args != null && args.Length == 1) {
                priority = _priorityBLL.GetById((int)args[0]);
                UpdatePriority();
            } else {
                btnReset.Visible = false;
            }
        }

        private void UpdatePriority() {
            txtName.Text = priority.Name;
            txtDescription.Text = priority.Description;
            cbbLevel.SelectedItem = (cbbLevel.Items.Cast<ComboboxItem>()).Where(p => p.Value == priority.PriorityLevel).FirstOrDefault();
        }

        private void btnReset_Click(object sender, System.EventArgs e) {
            UpdatePriority();
        }

        private void btnSave_Click(object sender, System.EventArgs e) {
            if (string.IsNullOrEmpty(txtName.Text)) {
                MessageBox.Show("A tarefa deve possuir um nome.");
                return;
            }

            if (cbbLevel.SelectedItem == null) {
                MessageBox.Show("A tarefa deve possuir um nível de prioridade.");
                return;
            }

            priority.Name = txtName.Text;
            priority.Description = txtDescription.Text;

            priority.PriorityLevel = ((ComboboxItem)cbbLevel.SelectedItem).Value;

            if (priority.PriorityID > 0) {
                _priorityBLL.Update(priority);
            } else {
                _priorityBLL.Create(priority);
            }

            MessageBox.Show("Tarefa Criada com Sucesso!");
            this.Dispose();
        }
    }
}
