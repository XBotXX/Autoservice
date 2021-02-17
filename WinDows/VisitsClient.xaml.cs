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

namespace Autoservice.WinDows
{
    /// <summary>
    /// Логика взаимодействия для VisitsClient.xaml
    /// </summary>
    public partial class VisitsClient : Window
    {
        public VisitsClient()
        {
            InitializeComponent();
        }

        private void ListVisits_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListVisits.SelectedItem is ClientService clientService)
            {
                if(clientService.CountListClient > 0)
                {
                    ListDocClientWindow listDocClientWindow = new ListDocClientWindow();

                    listDocClientWindow.Owner = Classes.ParentMainWindow.parentWindow;

                    listDocClientWindow.ListFotoDoc.ItemsSource = clientService.ListClient.ToList();

                    listDocClientWindow.ShowDialog();

                    if (listDocClientWindow.DialogResult.HasValue && listDocClientWindow.DialogResult.Value)
                    {

                    }
                }
                else
                {
                    MessageBox.Show("No documents");
                }
                
            }
        }
    }
}
