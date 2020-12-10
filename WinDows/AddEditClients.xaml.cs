using Autoservice.Classes;
using Microsoft.Win32;
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
    /// Логика взаимодействия для AddEditClients.xaml
    /// </summary>
    public partial class AddEditClients : Window
    {
        public AddEditClients()
        {
            InitializeComponent();

            ComboGender.ItemsSource = Entities.GetContext().Gender.ToList();

            ComboGender.SelectedIndex = 0;

            if (Classes.AddEditClass.StatusEditAdd == Classes.AddEditClass.EditAddClient.Edit)
            {

            }
            else
            {
                TxtID.Visibility = Visibility.Hidden;
                LblID.Visibility = Visibility.Hidden;
            }

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void BtnOpenFileDialog_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.ShowDialog();

            var filePath = openFileDialog.FileName;

            FilePathFoto.path = filePath.ToString();

            ImgFoto.Source = new BitmapImage(new Uri(filePath, UriKind.RelativeOrAbsolute));
        }
    }
}
