using System.Collections.Generic;

namespace ProjectSampleCore.Features.Basket.Models
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
