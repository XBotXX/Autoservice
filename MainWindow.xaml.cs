﻿using System;
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
using CompanyCoreLib;

namespace Autoservice
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Classes.ParentMainWindow.parentWindow = this;

            MainFrame.Navigate(new Pages.PageListClients());

            Classes.Manager.MainFrame = MainFrame;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {

            if (MainFrame.CanGoBack)
            {
                BackBtn.Visibility = Visibility.Visible;
            }
            else
            {
                BackBtn.Visibility = Visibility.Hidden;
            }

        }

        private void ClientBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.ClientPage());
        }
    }
}
