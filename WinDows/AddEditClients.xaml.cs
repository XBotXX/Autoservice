using Autoservice.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            if(TxtFirstName.Text.Length <= 50 && TxtLastName.Text.Length <= 50)
            {
                if (RegexUtilities.IsValidEmail(TxtEmall.Text))
                {
                    string pattern = @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";

                    Match znach = Regex.Match(TxtPhone.Text, pattern);

                    if (znach.Success)
                    {
                        string pattern1 = @"^[\p{L} \.'\-]+$";

                        Match znach1 = Regex.Match(TxtFirstName.Text, pattern1);
                        Match znach2 = Regex.Match(TxtLastName.Text, pattern1);
                        Match znach3 = Regex.Match(TxtMiddleName.Text, pattern1);

                        if (znach1.Success && znach2.Success && znach3.Success)
                        {
                            if(TxtFirstName.Text[0] != ' ' && TxtLastName.Text[0] != ' ' && TxtMiddleName.Text[0] != ' ')
                            {
                                this.DialogResult = true;
                            }
                            else
                            {
                                MessageBox.Show("Error FIO Probel");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error FIO");
                        }
                            
                    }
                    else
                    {
                        MessageBox.Show("Error Phone");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Error Email");
                }
            }
            else
            {
                MessageBox.Show("Error Lenght string");
            }
            
        }

        private void BtnOpenFileDialog_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.ShowDialog();

            var filePath = openFileDialog.FileName;

            FilePathFoto.path = filePath.ToString();

            ImgFoto.Source = new BitmapImage(new Uri(filePath, UriKind.RelativeOrAbsolute));
        }

        private void BtnAddTag_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Classes.AddEditClass.StatusEditAdd = Classes.AddEditClass.EditAddClient.Greate;

                AddTagsWindow addTagsWindow = new AddTagsWindow();

                addTagsWindow.Owner = Classes.ParentMainWindow.parentWindow;

                addTagsWindow.ComboTypeTag.ItemsSource = Entities.GetContext().Tag.Select(i => i.NameTag).ToList();

                addTagsWindow.ShowDialog();

                int id = Int32.Parse(TxtID.Text);

                if (addTagsWindow.DialogResult.HasValue && addTagsWindow.DialogResult.Value)
                {

                    var tag = new ClientTag()
                    {
                        IdClient = id,
                        IdTag = Entities.GetContext().Tag.Where(i=>i.NameTag == addTagsWindow.ComboTypeTag.SelectedItem.ToString()).FirstOrDefault().IdTag
                    };

                    Entities.GetContext().Entry(tag).State = EntityState.Added;

                    Entities.GetContext().SaveChanges();
                }

                Client client = Entities.GetContext().Client.Where(i => i.IdClient == id).FirstOrDefault();
                DgTag.ItemsSource = client.ListTag;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void BtnDelateTag_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Удалить?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    int id = Int32.Parse(TxtID.Text);

                    if (DgTag.SelectedItem is Tag clientTag)
                    {
                        var ClientTg = Entities.GetContext().ClientTag.Where(i => i.IdClient == id && i.IdTag == clientTag.IdTag).FirstOrDefault();

                        if (ClientTg != null)
                        {
                            Entities.GetContext().Entry(ClientTg).State = EntityState.Deleted;

                            Entities.GetContext().SaveChanges();

                            Client client = Entities.GetContext().Client.Where(i => i.IdClient == id).FirstOrDefault();
                            DgTag.ItemsSource = client.ListTag;

                            //DgClients.Items.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("Невозможно удалить");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

        class RegexUtilities
        {
            public static bool IsValidEmail(string email)
            {
                if (string.IsNullOrWhiteSpace(email))
                    return false;

                try
                {
                    // Normalize the domain
                    email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                          RegexOptions.None, TimeSpan.FromMilliseconds(200));

                    // Examines the domain part of the email and normalizes it.
                    string DomainMapper(Match match)
                    {
                        // Use IdnMapping class to convert Unicode domain names.
                        var idn = new IdnMapping();

                        // Pull out and process domain name (throws ArgumentException on invalid)
                        string domainName = idn.GetAscii(match.Groups[2].Value);

                        return match.Groups[1].Value + domainName;
                    }
                }
                catch (RegexMatchTimeoutException e)
                {
                    return false;
                }
                catch (ArgumentException e)
                {
                    return false;
                }

                try
                {
                    return Regex.IsMatch(email,
                        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                        RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
                }
                catch (RegexMatchTimeoutException)
                {
                    return false;
                }
            }
        }
    }
}
