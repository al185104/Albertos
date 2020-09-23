using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Albertos.Models
{
    public class ReportCartList
    {
        public ObservableCollection<ReportCartModel> Result { get; set; } = new ObservableCollection<ReportCartModel>();
    }
}
