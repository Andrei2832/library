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
using System.Windows.Shapes;

namespace library
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        Entities1 context = new Entities1();

        List<int> CountTest = new List<int>();
        List<int> PassedTest = new List<int>();
        public Menu()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            surName.Text = context.Customer.Where(i => i.Login == MainViewModel.LoginCust).Select(j => j.Name).FirstOrDefault();
            furtName.Text = context.Customer.Where(i => i.Login == MainViewModel.LoginCust).Select(j => j.Surname).FirstOrDefault();
            Patr.Text = context.Customer.Where(i => i.Login == MainViewModel.LoginCust).Select(j => j.Patronymic).FirstOrDefault();

            CountTest.AddRange(context.Test.Select(i => i.idTest).ToList());
            ProgressTest.Maximum = CountTest.Count();

            PassedTest.AddRange(context.testsCustomer.Where(i => i.Passed == true).Select(j => j.idTest).ToList());
            ProgressTest.Value = PassedTest.Count();
        }
    }
}
