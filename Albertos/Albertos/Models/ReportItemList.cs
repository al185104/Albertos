﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Albertos.Models
{
    public class ReportItemList
    {
        public ObservableCollection<ProductModel> Result { get; set; } = new ObservableCollection<ProductModel>();
    }
}
