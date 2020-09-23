using Newtonsoft.Json;
using Albertos.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Albertos.Models
{
    public class ProductModel : ExtendedBindableObject
    {
        #region Properties
        [JsonProperty("transactionId")]
        public int TransactionId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        private double totalPrice;

        public double TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; RaisePropertyChanged(() => TotalPrice); }
        }

        [JsonProperty("itemCode")]
        public string ItemCode { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        private double unitPrice;
        [JsonProperty("unitPrice")]
        public double UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; RaisePropertyChanged(() => UnitPrice); }
        }

        [JsonProperty("originalPrice")]
        public double OriginalPrice { get; set; }

        private int quantity;
        [JsonProperty("quantity")]
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; RaisePropertyChanged(() => Quantity); }
        }
        
        private int stockCount;
        [JsonProperty("stockCount")]
        public int StockCount
        {
            get { return stockCount; }
            set { stockCount = value; RaisePropertyChanged(() => StockCount); }
        }

        [JsonProperty("isQuantityRequired")]
        public bool IsQuantityRequired { get; set; }

        [JsonProperty("isPriceRequired")]
        public bool IsPriceRequired { get; set; }

        
        private string image = "settings_productimage_placeholder.png";
        [JsonProperty("image")]
        public string Image { get; set; } = "settings_productimage_placeholder.png";

        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        public bool IsEditing { get; set; } = false;
        public string CardBGColor { get; set; }
        public int EntryId { get; set; }
        #endregion

        #region Constructor
        public ProductModel(ProductModel obj)
        {
            TransactionId = obj.TransactionId;
            Type = obj.Type;
            TotalPrice = obj.TotalPrice;
            ItemCode = obj.ItemCode;
            Name = obj.Name;
            Description = obj.Description;
            UnitPrice = obj.UnitPrice;
            OriginalPrice = obj.OriginalPrice;
            Quantity = obj.Quantity;
            StockCount = obj.StockCount;
            IsQuantityRequired = obj.IsQuantityRequired;
            IsPriceRequired = obj.IsPriceRequired;
            Image = obj.Image;
            CreatedBy = obj.CreatedBy;
            CreatedDate = obj.CreatedDate;
            IsEditing = obj.IsEditing;
            CardBGColor = obj.CardBGColor;
            EntryId = obj.EntryId;
        }
        public ProductModel() { } 
        #endregion
    }
}
