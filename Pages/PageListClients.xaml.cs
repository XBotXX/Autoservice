using Autoservice.WinDows;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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

namespace Autoservice.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageListClients.xaml
    /// </summary>
    public partial class PageListClients : Page
    {

        List<string> countRows = new List<string>() { "10", "50", "200", "All Clients" };

        List<Client> buffClientList = new List<Client>();

        public int countPage = 0;

        public int skipData = 0;

        public PageListClients()
        {
            InitializeComponent();

            try
            {
                var gender = Entities.GetContext().Gender.Select(i => i.Name).ToList();
                gender.Insert(0, "All Genders");

                ComboNameGender.ItemsSource = gender;

                ComboNameGender.SelectedIndex = 0;

                DgClients.ItemsSource = Entities.GetContext().Client.ToList();

                string countRow = DgClients.Items.Count.ToString();

                LblCountRowFromAll.Content = countRow + " From " + countRow;

                ComboCountRow.ItemsSource = countRows.ToList();

                ComboCountRow.SelectedIndex = countRow.Length;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
            

        }

        private void ComboCountRow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string item = ComboCountRow.SelectedItem.ToString();

                int buf;

                if (Int32.TryParse(item, out buf))
                {
                    var clients = Entities.GetContext().Client;

                    DgClients.ItemsSource = clients.Take(buf).ToList();

                    countPage = (clients.Count() / buf) - 1;

                    skipData = buf;
                }
                else
                {
                    DgClients.ItemsSource = Entities.GetContext().Client.ToList();

                    countPage = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
            
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e) => Filters();

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e) => Filters();

        private void BtnNextList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (countPage > 0)
                {
                    var clients = Entities.GetContext().Client;

                    int buf = Int32.Parse(ComboCountRow.SelectedItem.ToString());

                    DgClients.ItemsSource = clients.OrderBy(i => i.IdClient).Skip(skipData).Take(buf).ToList();

                    countPage -= 1;

                    skipData += buf;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
            
        }

        private void BtnLastList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (countPage >= 0)
                {
                    var clients = Entities.GetContext().Client;

                    int buf = Int32.Parse(ComboCountRow.SelectedItem.ToString());

                    skipData -= buf;

                    if (skipData >= 0)
                    {
                        DgClients.ItemsSource = clients.OrderBy(i => i.IdClient).Skip(skipData).Take(buf).ToList();
                    }

                    countPage += 1;

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error");
            }
            
        }

        private void ComboNameGender_SelectionChanged(object sender, SelectionChangedEventArgs e) => Filters();

        private void BtnAddClents_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Classes.AddEditClass.StatusEditAdd = Classes.AddEditClass.EditAddClient.Greate;

                AddEditClients addEditClients = new AddEditClients();

                addEditClients.Owner = Classes.ParentMainWindow.parentWindow;

                addEditClients.ShowDialog();

                if (addEditClients.DialogResult.HasValue && addEditClients.DialogResult.Value)
                {
                    byte[] imgdata = System.IO.File.ReadAllBytes(Classes.FilePathFoto.path);

                    var Clientss = new Client()
                    {
                        LastName = addEditClients.TxtLastName.Text,
                        FirstName = addEditClients.TxtFirstName.Text,
                        MiddleName = addEditClients.TxtMiddleName.Text,
                        IdGender = Entities.GetContext().Gender.Where(i => i.Name == addEditClients.ComboGender.Text).FirstOrDefault()?.IdGender,
                        Phone = addEditClients.TxtPhone.Text,
                        BirhDate = addEditClients.DtPikerBithDate.SelectedDate.Value,
                        Email = addEditClients.TxtEmall.Text,
                        Photo = imgdata,
                        RegDate = DateTime.Now.Date
                    };

                    Entities.GetContext().Entry(Clientss).State = EntityState.Added;

                    Entities.GetContext().SaveChanges();
                }

                DgClients.ItemsSource = Entities.GetContext().Client.ToList();

                //DgClients.Items.Refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error");
            }
            

        }

        private void DgClients_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (DgClients.SelectedItem is Client client)
                {
                    Classes.AddEditClass.StatusEditAdd = Classes.AddEditClass.EditAddClient.Edit;

                    AddEditClients addEditClients = new AddEditClients();

                    addEditClients.Owner = Classes.ParentMainWindow.parentWindow;

                    addEditClients.TxtID.Text = client.IdClient.ToString();
                    addEditClients.TxtLastName.Text = client.LastName;
                    addEditClients.TxtFirstName.Text = client.FirstName;
                    addEditClients.TxtMiddleName.Text = client.MiddleName;
                    addEditClients.ComboGender.Text = client.Gender.Name;
                    addEditClients.TxtPhone.Text = client.Phone;
                    addEditClients.DtPikerBithDate.SelectedDate = client.BirhDate;
                    addEditClients.TxtEmall.Text = client.Email;
                    addEditClients.ImgFoto.Source = this.byteToImage(client.Photo);
                    addEditClients.DgTag.ItemsSource = client.ListTag;

                    addEditClients.ShowDialog();

                    if (addEditClients.DialogResult.HasValue && addEditClients.DialogResult.Value)
                    {
                        byte[] imgdata = null;

                        if (Classes.FilePathFoto.path != null)
                        {
                            imgdata = System.IO.File.ReadAllBytes(Classes.FilePathFoto.path);
                        }

                        var Clientss = Entities.GetContext().Client.Where(i => i.IdClient == client.IdClient).FirstOrDefault();

                        Clientss.LastName = addEditClients.TxtLastName.Text;
                        Clientss.FirstName = addEditClients.TxtFirstName.Text;
                        Clientss.MiddleName = addEditClients.TxtMiddleName.Text;
                        Clientss.IdGender = Entities.GetContext().Gender.Where(i => i.Name == addEditClients.ComboGender.Text).FirstOrDefault()?.IdGender;
                        Clientss.Phone = addEditClients.TxtPhone.Text;
                        Clientss.BirhDate = addEditClients.DtPikerBithDate.SelectedDate.Value;
                        Clientss.Email = addEditClients.TxtEmall.Text;

                        if (imgdata != null)
                        {
                            Clientss.Photo = imgdata;
                        }

                        Entities.GetContext().Entry(Clientss).State = EntityState.Modified;

                        Entities.GetContext().SaveChanges();
                    }

                    DgClients.SelectedItem = client;

                    DgClients.ItemsSource = Entities.GetContext().Client.ToList();

                    //DgClients.Items.Refresh();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error");
            }
            
        }

        private BitmapImage byteToImage(byte[] array)
        {
            using (MemoryStream ms = new MemoryStream(array, 0, array.Length))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = ms;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.EndInit();
                return image;
            }
        }

        private void BtnDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (DgClients.SelectedItem is Client client)
                {
                    MessageBoxResult result = MessageBox.Show("Удалить?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        var Client = Entities.GetContext().Client.Where(i => i.IdClient == client.IdClient).FirstOrDefault();

                        if (!Entities.GetContext().ClientService.Where(i => i.IdClient == Client.IdClient).Any())
                        {
                            Entities.GetContext().Entry(Client).State = EntityState.Deleted;

                            Entities.GetContext().SaveChanges();

                            DgClients.ItemsSource = Entities.GetContext().Client.ToList();

                            //DgClients.Items.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("Невозможно удалить");
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("Select item");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void TxtSearchClients_TextChanged(object sender, TextChangedEventArgs e) => Filters();

        private void DgClients_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            if (e.Row.GetIndex() == 0)
            {
                CounterRow(DgClients.Items.Count);
            }
        }

        public void CounterRow(int count)
        {
            LblCountRowFromAll.Content = count.ToString() + " From " + DgClients.Items.Count;
        }

        public void Filters()
        {
            buffClientList = Entities.GetContext().Client.ToList();

            // Combo Start
            try
            {
                if (ComboNameGender.SelectedItem.ToString() == "All Genders")
                {
                    buffClientList = Entities.GetContext().Client.ToList();
                }
                else if (ComboNameGender.SelectedItem.ToString() == "Женский")
                {
                    buffClientList = Entities.GetContext().Client.Where(i => i.IdGender == "ж").ToList();
                }
                else if (ComboNameGender.SelectedItem.ToString() == "Мужской")
                {
                    buffClientList = Entities.GetContext().Client.Where(i => i.IdGender == "м").ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
            // Combo End

            // Check Start
            try
            {
                if (checkMonth.IsChecked == true)
                {
                    DateTime d = DateTime.Now.Date;
                    buffClientList = buffClientList.Where(i => i.BirhDate.Month == d.Month).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
            // Check End

            // TextSearch Start
            buffClientList = buffClientList
                .Where(i =>
                i.FirstName.Contains(TxtSearchClients.Text) ||
                i.LastName.Contains(TxtSearchClients.Text) ||
                i.MiddleName.Contains(TxtSearchClients.Text) ||
                i.Email.Contains(TxtSearchClients.Text) ||
                i.Phone.Contains(TxtSearchClients.Text)).ToList();
            // TextSearch End

            DgClients.ItemsSource = buffClientList.ToList();
        }

        private void BtnViewVisitsClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DgClients.SelectedItem is Client client)
                {
                    if(client.ClientService.Count > 0)
                    {
                        VisitsClient visitsClient = new VisitsClient();

                        visitsClient.Owner = Classes.ParentMainWindow.parentWindow;

                        visitsClient.ListVisits.ItemsSource = client.ClientService;

                        visitsClient.ShowDialog();

                        if (visitsClient.DialogResult.HasValue && visitsClient.DialogResult.Value)
                        {

                        }

                        DgClients.SelectedItem = client;
                    }
                    else
                    {
                        MessageBox.Show("Do not History");
                    }

                }
                else
                {
                    MessageBox.Show("Select item");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error");
            }
            
        }
    }
}
