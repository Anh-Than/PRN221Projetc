using Library.BussinessObject;
using Library.Repository;

namespace WinApp
{
    public partial class Form1 : Form
    {
        IEmployeeRepository employeeRepository = new EmployeeRepository();
        BindingSource source;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadEmployeeList();
            LoadPositionList();
            this.cboPosition.SelectedIndexChanged += new System.EventHandler(cboPosition_SelectedIndexChanged);
            this.optMaleFemale.CheckedChanged += new System.EventHandler(optSex_CheckedChanged);
            this.optMale.CheckedChanged += new System.EventHandler(optSex_CheckedChanged);
            this.optFemale.CheckedChanged += new System.EventHandler(optSex_CheckedChanged);
            optMaleFemale.Checked = true;
            optMale.Checked = false;
            optFemale.Checked = false;

        }

        private void optSex_CheckedChanged(object? sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            var employees = employeeRepository.GetEmployees();
            List<Employee> curList = new List<Employee>();
            source = new BindingSource();
            if (optMale.Checked)
            {
                foreach(Employee emp in employees)
                {
                    if (emp.EmployeeSex.Equals(optMale.Text))
                    {
                        curList.Add(emp);
                    }
                }
                source.DataSource = curList;
            }
            else if (optFemale.Checked)
            {
                foreach (Employee emp in employees)
                {
                    if (emp.EmployeeSex.Equals(optFemale.Text))
                    {
                        curList.Add(emp);
                    }
                }
                source.DataSource = curList;
            }
            else
            {
                source.DataSource = employees;
            }
            dgvEmployee.DataSource = null;
            dgvEmployee.DataSource = source;
        }

        private void cboPosition_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            string selectedPosition = (string)cboPosition.SelectedItem;
            List<Employee> curList = new List<Employee>();
            var employees = employeeRepository.GetEmployees();
            foreach (var employee in employees)
            {
                if (employee.EmployeePosition == selectedPosition)
                {
                    curList.Add(employee);
                }
            }
            source = new BindingSource();
            source.DataSource = curList;

            dgvEmployee.DataSource = null;
            dgvEmployee.DataSource = curList;

        }

        public void LoadEmployeeList()
        {
            var employees = employeeRepository.GetEmployees();
            try
            {
                source = new BindingSource();
                source.DataSource = employees;

                dgvEmployee.DataSource = null;
                dgvEmployee.DataSource = source;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load employees list");
            }
        }

        public void LoadPositionList()
        {
            List<String> positions = employeeRepository.GetPositions();
            try
            {
                positions.Insert(0, "All positions");
                source = new BindingSource();
                source.DataSource = positions;
                cboPosition.DataSource = null;
                cboPosition.DataSource = source;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load positions list");
            }
        }


    }
}