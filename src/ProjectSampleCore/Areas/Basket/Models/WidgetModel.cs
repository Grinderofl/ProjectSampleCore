using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectSampleCore.Core.Domain;

namespace ProjectSampleCore.Areas.Basket.Models
{
    public class WidgetModel
    {
        public IEnumerable<BasketListItem> Items { get; set; }
    }

    public class BasketListItem
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
