using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProjectSampleCore.Infrastructure.Mvc.Models
{
    public class EntityIndexModel
    {
        public IEnumerable<string> Headers { get; set; }
        public virtual IEnumerable Items { get; set; }
    }

    public class EntityIndexModel<TLineModel> : EntityIndexModel
    {
        public virtual TLineModel[] LineItems { get; set; }
        public override IEnumerable Items => LineItems;
    }
}