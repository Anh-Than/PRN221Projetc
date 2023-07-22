using System.Windows.Forms.VisualStyles;

namespace Q1
{
    public partial class Form1 : Form
    {
        private string studentID = "He160230";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbStudentID.Text = studentID;
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            try
            {
                int number = Int32.Parse(txtNumber.Text);
                string newStudentID = studentID.Substring(0, number);
                lbStudentID.Text = newStudentID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}