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
using System.Windows.Shapes;
using TradITAM.Model;
using TradITAM.ViewModel;

namespace TradITAM.View
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public ReportWindow(UserData UserList)
        {
            InitializeComponent();
            this.DataContext = new ReportWindowViewModel(UserList);
        }

        private void Button_Add_ReportType(object sender, RoutedEventArgs e)
        {
            ManageAssetHistoryWindow n = new ManageAssetHistoryWindow();
            n.Show();
        }
    }
}
