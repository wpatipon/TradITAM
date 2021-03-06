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
    /// Interaction logic for UpdateSupplierWindow.xaml
    /// </summary>
    public partial class UpdateSelectedSupplierWindow : Window
    {
        public UpdateSelectedSupplierWindow(SupplierData SelectedSupplier, UserData UserList)
        {
            InitializeComponent();
            this.DataContext = new UpdateSelectedSupplierWindowViewModel(SelectedSupplier, UserList);
        }
    }
}
