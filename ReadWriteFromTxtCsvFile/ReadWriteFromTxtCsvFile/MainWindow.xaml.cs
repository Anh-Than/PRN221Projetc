using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace ReadWriteFromTxtCsvFile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Doc file txt,csv
        private void LoadData_Click(object sender, RoutedEventArgs e)
        {
            Dgv.Items.Clear();

            //Doc ghi 1 file chon trong may
            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.ShowDialog();

            //Doc ghi 1 file voi duong dan
            string fileName = "student.txt";


            string[] studentArray;
            List<Student> students = new List<Student>();

            //DataTable dt = new DataTable();
            //dt.Columns.Add("ID", typeof(int));
            //dt.Columns.Add("Last Name", typeof(string));
            //dt.Columns.Add("First Name", typeof(string));
            //using (StreamReader sr = new StreamReader(ofd.FileName))

            //Doc file
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    studentArray = sr.ReadLine().Split(";");

                    Student student = new Student();
                    student.Id = Convert.ToInt32(studentArray[0]);
                    student.LastName = Convert.ToString(studentArray[1]);
                    student.FirstName = Convert.ToString(studentArray[2]);

                    students.Add(student);

                    //Them 1 item vao Dgv
                    Dgv.Items.Add(student);

                    //Them vao DataTable
                    //dt.Rows.Add(studentArray);
                }
                //DataView dv = new DataView(dt);
                //Them 1 List vao Dgv.ItemSource se tu tao ra header cho bang
                //Dgv.ItemsSource = students;
                //Dgv.ItemsSource = dv;
            }
        }

        //Ghi file txt,csv
        private void WriteToFile_Click(object sender, RoutedEventArgs e)
        {
            //Doc ghi 1 file chon trong may
            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.ShowDialog();

            //Doc ghi 1 file voi duong dan
            string fileName = "student.txt";
            using (StreamWriter sw = File.AppendText(fileName))
            {
                string toWrite = txtToWrite.Text;
                sw.WriteLine(toWrite);
                txtToWrite.Text = "";
            }

            //using (StreamWriter sw = new StreamWriter(fileName))
            //{
            //    string toWrite = txtToWrite.Text;
            //    sw.WriteLine(toWrite);
            //    txtToWrite.Text = "";
            //}

        }

        //Ghi file xml
        private void SerializeObjectToXmlString()
        {
            string fileName = "studentXML.xml";

            List<Student> students = new List<Student>();
            var Student = new Student
            {
                Id = 1,
                FirstName = "Than",
                LastName = "Vinh Anh"
            };
            students.Add (Student);

            var xmlSerializer = new XmlSerializer(typeof(List<Student>));
            using (StreamWriter sw = File.AppendText(fileName))
            {
                xmlSerializer.Serialize(sw, students);
            }
        }

        //Doc file xml
        private List<Student> DeserializeXmlToObject()
        {
            string fileName = "studentXML.xml";

            var xmlSerializer = new XmlSerializer(typeof(List<Student>));
            using (StreamReader sr = new StreamReader(fileName))
            {
                var student = (List<Student>)xmlSerializer.Deserialize(sr);
                return student;
            }
        }



        private void ReadSerializedObject_Click(object sender, RoutedEventArgs e)
        {
            Dgv.Items.Clear();
            List<Student> students = DeserializeXmlToObject();
            var student = students[0];
            Dgv.Items.Add(student);
        }
        private void AddSerializedObject_Click(object sender, RoutedEventArgs e)
        {
            SerializeObjectToXmlString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        //Ghi file json
        private void SerializeToJsonObject()
        {
            string fileName = "studentJson.json";

            var Student = new Student
            {
                Id = 1,
                FirstName = "Than",
                LastName = "Vinh Anh"
            };
            List<Student> students = new List<Student>();
            students.Add(Student);
            string jsonString = JsonSerializer.Serialize(students);
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine(jsonString);
            }                       
        }

        //Doc file json
        private List<Student> DeserializeJsonToObject()
        {
            string fileName = "studentJson.json";
            List<Student> students = new List<Student>();
            using FileStream openStream = File.OpenRead(fileName);
            students = JsonSerializer.Deserialize<List<Student>>(openStream);
            return students;           
        }

        private void BtnSaveJson_Click(object sender, RoutedEventArgs e)
        {
            SerializeToJsonObject();
        }

        private void BtnReadJson_Click(object sender, RoutedEventArgs e)
        {
            Dgv.Items.Clear();
            List<Student> students = DeserializeJsonToObject();
            var student = students[0];
            Dgv.Items.Add(student);
        }
    }
}
