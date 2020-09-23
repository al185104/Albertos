using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Albertos.Models
{
    public class ApplicationProductList
    {
        public int Count { get; set; }
        public ObservableCollection<ProductModel> Items { get; set; } = new ObservableCollection<ProductModel>();
        public ApplicationProductList(ApplicationProductList list)
        {
            Count = list.Count;
            Items = new ObservableCollection<ProductModel>(list.Items);
        }
        public ApplicationProductList()
        {

        }
    }
}
