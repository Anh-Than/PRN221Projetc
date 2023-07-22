using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using WPF_EF_SqlServer.Models;

namespace WPF_EF_SqlServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Person> People { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            using (TestContext _context = new TestContext())
            {
                People = _context.People.ToList();
            }

            PeopleList.ItemsSource = People;
        }
    }
}
