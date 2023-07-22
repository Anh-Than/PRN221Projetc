using Library.DataAccess;
using Library.Repository;
using System.Diagnostics.Tracing;

namespace Q2
{
    public partial class Form1 : Form
    {
        BindingSource source;
        IRepository repository = new Repository();
        IEnumerable<Project> projects;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            projects = repository.getProjectList();
            LoadTypes();
            LoadProjectsSource();
            dgvProjects.SelectionChanged += new EventHandler(dgvProjects_SelectionChanged);
        }

        private void LoadTypes()
        {
            List<string> types = repository.getTypes();
            source = new BindingSource();
            source.DataSource = types;
            cboType.DataSource = source;

        }

        private void LoadProjectsSource()
        {
            source = new BindingSource();
            var projectsSource = repository.getProjectList();
            source.DataSource = projectsSource;
            dgvProjects.DataSource = source;
            foreach (DataGridViewRow row in dgvProjects.SelectedRows)
            {
                txtID.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtDescription.Text = row.Cells[2].Value.ToString();
                dtpStartTime.Text = row.Cells[3].Value.ToString();
                cboType.Text = row.Cells[4].Value.ToString();
            }
        }

        private void dgvProjects_SelectionChanged(object sender, EventArgs e)
        {
            Clear();
            foreach (DataGridViewRow row in dgvProjects.SelectedRows)
            {
                if (row.Cells[0].Value != null)
                {
                    txtID.Text = row.Cells[0].Value.ToString();
                }
                if (row.Cells[1].Value != null)
                {
                    txtName.Text = row.Cells[1].Value.ToString();
                }
                if (row.Cells[2].Value != null)
                {
                    txtDescription.Text = row.Cells[2].Value.ToString();
                }
                if (row.Cells[3].Value != null)
                {
                    dtpStartTime.Text = row.Cells[3].Value.ToString();
                }
                if (row.Cells[4].Value != null)
                {
                    cboType.Text = row.Cells[4].Value.ToString();
                }
            }
        }
        private void Clear()
        {
            txtID.Text = String.Empty;
            txtName.Text = String.Empty;
            txtDescription.Text = String.Empty;
            dtpStartTime.Text = String.Empty;
            cboType.Text = String.Empty;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            foreach (Project project in projects)
            {
                if (project.Id == Int32.Parse(txtID.Text))
                {
                    project.Name = txtName.Text;
                    project.Description = txtDescription.Text;
                    project.StartDate = dtpStartTime.Value;
                    project.Type = cboType.Text;
                }
            }
            Reload();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProjectsSource();
        }

        private void Reload()
        {
            source = new BindingSource();
            source.DataSource = projects;
            dgvProjects.DataSource = source;
            foreach (DataGridViewRow row in dgvProjects.SelectedRows)
            {
                txtID.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtDescription.Text = row.Cells[2].Value.ToString();
                dtpStartTime.Text = row.Cells[3].Value.ToString();
                cboType.Text = row.Cells[4].Value.ToString();
            }
        }
    }
}