using Library.DataAccess;
using Library.Repository;

namespace Employees
{
    public partial class Employees : Form
    {
        IEmployeeRepository employeeRepository = new EmployeeRepository();
        BindingSource source;
        public Employees()
        {
            InitializeComponent();
        }

        private void Employees_Load(object sender, EventArgs e)
        {
            LoadEmployeesToDgv();
            LoadPositionToCbo();
            dgvEmployees.SelectionChanged += new EventHandler(dgvEmployees_SelectionChanged);
            foreach (DataGridViewRow row in dgvEmployees.SelectedRows)
            {
                txtID.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                if (row.Cells[3].Value.ToString() == "Male")
                {
                    optMale.Checked = true;
                    optFemale.Checked = false;
                }
                else
                {
                    optMale.Checked = false;
                    optFemale.Checked = true;
                }
                dtDOB.Text = row.Cells[2].Value.ToString();
                cboPosition.Text = row.Cells[4].Value.ToString();
            }
        }

        private void dgvEmployees_SelectionChanged(object? sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvEmployees.SelectedRows)
            {
                txtID.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                if (row.Cells[3].Value.ToString() == "Male")
                {
                    optMale.Checked = true;
                    optFemale.Checked = false;
                }
                else
                {
                    optMale.Checked = false;
                    optFemale.Checked = true;
                }
                dtDOB.Text = row.Cells[2].Value.ToString();
                cboPosition.Text = row.Cells[4].Value.ToString();
            }
        }

        private void LoadEmployeesToDgv()
        {
            var employees = employeeRepository.GetEmployees();
            try
            {
                source = new BindingSource();
                source.DataSource = employees;

                dgvEmployees.DataSource = null;
                dgvEmployees.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load employees list");
            }
        }

        private void LoadPositionToCbo()
        {
            List<String> positions = employeeRepository.GetPosition();
            source = new BindingSource();
            source.DataSource = positions;
            cboPosition.DataSource = null;
            cboPosition.DataSource = source;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.Name = txtName.Text;
            emp.Position = cboPosition.Text;
            emp.Dob = dtDOB.Value;
            if (optFemale.Checked)
            {
                emp.Sex = optFemale.Text;
            }
            else
            {
                emp.Sex = optMale.Text;
            }
            employeeRepository.AddNew(emp);
            LoadEmployeesToDgv();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.Id = Int32.Parse(txtID.Text);
            emp.Name = txtName.Text;
            if (optMale.Checked)
            {
                emp.Sex = optMale.Text;
            }
            else
            {
                emp.Sex = optFemale.Text;
            }
            emp.Dob = dtDOB.Value;
            emp.Position = cboPosition.Text;
            emp.Department = (int?)dgvEmployees.SelectedRows[0].Cells[5].Value;

            employeeRepository.Update(emp);
            LoadEmployeesToDgv();
        }
    }
}