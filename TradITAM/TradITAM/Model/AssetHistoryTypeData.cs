﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradITAM.Model
{
    public class AssetHistoryTypeData
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        private int _asset_history_type_id;
        public int Asset_history_type_id
        {
            get { return _asset_history_type_id; }
            set { _asset_history_type_id = value; OnPropertyChanged(new PropertyChangedEventArgs("Asset_history_type_id")); }
        }

        private string _type_code;
        public string Type_code
        {
            get { return _type_code; }
            set { _type_code = value; OnPropertyChanged(new PropertyChangedEventArgs("Type_code")); }
        }

        private string _type_description;
        public string Type_description
        {
            get { return _type_description; }
            set { _type_description = value; OnPropertyChanged(new PropertyChangedEventArgs("Type_description")); }
        }

        private bool _is_active;
        public bool Is_active
        {
            get { return _is_active; }
            set { _is_active = value; OnPropertyChanged(new PropertyChangedEventArgs("Is_active")); }
        }

        private DateTime _create_date;
        public DateTime Create_date
        {
            get { return _create_date; }
            set { _create_date = value; OnPropertyChanged(new PropertyChangedEventArgs("Create_date")); }
        }

        private DateTime _modified_date;
        public DateTime Modified_date
        {
            get { return _modified_date; }
            set { _modified_date = value; OnPropertyChanged(new PropertyChangedEventArgs("Modified_date")); }
        }
    }
}
