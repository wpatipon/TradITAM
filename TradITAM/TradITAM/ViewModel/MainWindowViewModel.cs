﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using TradITAM.Helper;
using TradITAM.Model;
using TradITAM.View;

namespace TradITAM.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Global Variable
        public DelegateCommand<object> AddAssetEvent { get; set; }
        public DelegateCommand<object> AddStaffEvent { get; set; }
        public DelegateCommand<object> AddSupplierEvent { get; set; }

        public DelegateCommand<object> EditAssetEvent { get; set; }
        public DelegateCommand<object> EditStaffEvent { get; set; }
        public DelegateCommand<object> EditSupplierEvent { get; set; }

        public DelegateCommand<object> EditSelectedAssetEvent { get; set; }
        public DelegateCommand<object> EditSelectedStaffEvent { get; set; }
        public DelegateCommand<object> EditSelectedSupplierEvent { get; set; }

        public DelegateCommand<object> ReportViewCommand { get; set; }
        public DelegateCommand<object> UlogViewCommand { get; set; }
        public DelegateCommand<object> RegisterCommand { get; set; }
        public DelegateCommand<object> LoginCommand { get; set; }

        public DelegateCommand<UserData> ReportAssetEvent { get; set; }

        public Action CloseAction { get; set; }
        private UserData UserInfo { get; set; }
        #endregion

        public MainWindowViewModel(UserData UserList)
        {
            UserInfo = new UserData();
            UserInfo = UserList;

            /* Define AddEvent using DelegateCommand */
            AddAssetEvent = new DelegateCommand<object>(AddAsset);
            AddStaffEvent = new DelegateCommand<object>(AddStaff);
            AddSupplierEvent = new DelegateCommand<object>(AddSupplier);

            /* Define EditEvent using DelegateCommand */
            EditAssetEvent = new DelegateCommand<object>(EditAsset);
            EditStaffEvent = new DelegateCommand<object>(EditStaff);
            EditSupplierEvent = new DelegateCommand<object>(EditSupplier);

            /* Define EditSelectedEvent using DelegateCommand */
            EditSelectedAssetEvent = new DelegateCommand<object>(EditSelectedAsset);
            EditSelectedStaffEvent = new DelegateCommand<object>(EditSelectedStaff);
            EditSelectedSupplierEvent = new DelegateCommand<object>(EditSelectedSupplier);

            /* Define 'ReportViewCommand' to authenticate using DelegateCommand */
            ReportViewCommand = new DelegateCommand<object>(ReportView);

            /* Define 'UlogViewCommand' to authenticate using DelegateCommand */
            UlogViewCommand = new DelegateCommand<object>(UlogView);

            /* Define 'LoginCommand' to authenticate using DelegateCommand */
            LoginCommand = new DelegateCommand<object>(Login);

            /* Define 'RegisterCommand' to authenticate using DelegateCommand */
            RegisterCommand = new DelegateCommand<object>(Register);

            /* Define GetEvent using DelegateCommand */
            ReportAssetEvent = new DelegateCommand<UserData>(ReportAsset);

            LoadStaff();            // Load 'Staff' from database to get '*' into DataGrid
            LoadAsset();            // Load 'Asset' from database to get '*' into DataGrid
            LoadSupplier();         // Load 'Supplier' from database to get '*' into DataGrid
            LoadUser(UserList);     // Load user information from 'UserList'
        }

        #region Call DataAccess
        private DataAccess _DataAccess;
        public DataAccess DataAccess
        {
            get
            {
                if (_DataAccess == null)
                    _DataAccess = new DataAccess();
                return _DataAccess;
            }
        }
        #endregion

        #region Asset Properties
        private ObservableCollection<AssetData> _listasset = new ObservableCollection<AssetData>();
        public ObservableCollection<AssetData> AssetList
        {
            get => _listasset;
            set
            {
                _listasset = value;
                OnPropertyChanged(nameof(AssetList));
            }
        }

        private AssetData _SelectedAsset;
        public AssetData SelectedAsset
        {
            get { return _SelectedAsset; }
            set
            {
                _SelectedAsset = value;
            }
        }

        private ICollectionView _AssetCollectionView;
        public ICollectionView AssetCollectionView
        {
            get { return _AssetCollectionView; }
            set { _AssetCollectionView = value; }
        }

        #endregion

        #region Staff Properties

        private ObservableCollection<StaffData> _liststaff = new ObservableCollection<StaffData>();
        public ObservableCollection<StaffData> StaffList
        {
            get => _liststaff;
            set
            {
                _liststaff = value;
                OnPropertyChanged(nameof(StaffList));
            }
        }

        private StaffData _SelectedStaff;
        public StaffData SelectedStaff
        {
        get { return _SelectedStaff; }
        set
            {
                _SelectedStaff = value;
            }
        }

        private ICollectionView _StaffCollectionView;
        public ICollectionView StaffCollectionView
        {
            get { return _StaffCollectionView; }
            set { _StaffCollectionView = value; }
        }

        #endregion

        #region Supplier Properties
        private ObservableCollection<SupplierData> _listsupplier = new ObservableCollection<SupplierData>();
        public ObservableCollection<SupplierData> SupplierList
        {
            get => _listsupplier;
            set
            {
                _listsupplier = value;
                OnPropertyChanged(nameof(SupplierList));
            }
        }

        private SupplierData _SelectedSupplier;
        public SupplierData SelectedSupplier
        {
            get { return _SelectedSupplier; }
            set
            {
                _SelectedSupplier = value;
            }
        }

        private ICollectionView _SupplierCollectionView;
        public ICollectionView SupplierCollectionView
        {
            get { return _SupplierCollectionView; }
            set { _SupplierCollectionView = value; }
        }
        #endregion

        #region Load User
        private int _user_id;
        public int User_id
        {
            get { return _user_id; }
            set
            {
                _user_id = value;
                OnPropertyChanged("User_id");
            }
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }
        #endregion

        #region Methods 
        public void LoadAsset()
        {
            AssetList = DataAccess.GetAsset();
            AssetCollectionView = CollectionViewSource.GetDefaultView(AssetList);

           // AssetCollectionView.MoveCurrentToFirst();
            SelectedAsset = (AssetData)AssetCollectionView.CurrentItem;  
        }

        public void LoadStaff()
        {
            StaffList = DataAccess.GetStaff();
            StaffCollectionView = CollectionViewSource.GetDefaultView(StaffList);

            //StaffCollectionView.MoveCurrentToFirst();
            SelectedStaff = (StaffData)StaffCollectionView.CurrentItem;
        }

        public void LoadSupplier()
        {
            SupplierList = DataAccess.GetSupplier();
            SupplierCollectionView = CollectionViewSource.GetDefaultView(SupplierList);

            //SupplierCollectionView.MoveCurrentToFirst();
            SelectedSupplier = (SupplierData)SupplierCollectionView.CurrentItem;
        }

        public void LoadUser(UserData Userlist)
        {
            User_id = Userlist.user_id;
            Username = Userlist.username;
        }
        #endregion

        #region Send UserList Data to other form

        #region Add
        public void AddAsset(object obj)
        {
            AddAssetWindow n = new AddAssetWindow(UserInfo);
            n.ShowDialog();
        }

        public void AddStaff(object obj)
        {
            AddStaffWindow n = new AddStaffWindow(UserInfo);
            n.ShowDialog();
        }

        public void AddSupplier(object obj)
        {
            AddSupplierWindow n = new AddSupplierWindow(UserInfo);
            n.ShowDialog();
        }
        #endregion

        #region Edit
        public void EditAsset(Object obj)
        {
            if (SelectedStaff != null)
            {
                UpdateAssetWindow n = new UpdateAssetWindow(UserInfo);
                n.ShowDialog();
            }
        }

        public void EditStaff(Object obj)
        {
            if (SelectedStaff != null)
            {
                UpdateStaffWindow n = new UpdateStaffWindow(UserInfo);
                n.ShowDialog();
            }
        }

        public void EditSupplier(Object obj)
        {
            if (SelectedStaff != null)
            {
                UpdateSupplierWindow n = new UpdateSupplierWindow(UserInfo);
                n.ShowDialog();
            }
        }
        #endregion

        #region EditSelected
        public void EditSelectedAsset(Object obj)
        {
            if (SelectedStaff != null)
            {
                UpdateSelectedAssetWindow n = new UpdateSelectedAssetWindow(SelectedAsset, UserInfo);
                n.ShowDialog();
            }
        }

        public void EditSelectedStaff(Object obj)
        {
            if (SelectedStaff != null)
            {
                UpdateSelectedStaffWindow n = new UpdateSelectedStaffWindow(SelectedStaff, UserInfo);
                n.ShowDialog();
            }
        }

        public void EditSelectedSupplier(Object obj)
        {
            if (SelectedStaff != null)
            {
                UpdateSelectedSupplierWindow n = new UpdateSelectedSupplierWindow(SelectedSupplier, UserInfo);
                n.ShowDialog();
            }
        }
        #endregion

        public void ReportView(object obj)
        {
            ReportViewWindow n = new ReportViewWindow();
            n.ShowDialog();
        }

        public void UlogView(object obj)
        {
            HistoryWindow n = new HistoryWindow();
            n.ShowDialog();
        }

        public void Login(object obj)
        {
            LoginWindow n = new LoginWindow();
            CloseAction();
            n.Show();
        }

        public void Register(object obj)
        {
            RegisterWindow n = new RegisterWindow(UserInfo);
            n.ShowDialog();
        }


        public void ReportAsset(Object obj)
        {
            ReportWindow n = new ReportWindow(UserInfo);
            n.ShowDialog();
        }
        #endregion
    }
}
