using System.Collections.Generic;

namespace ProjectSampleCore.Infrastructure.Mvc.Models
{
    public class EntityIndexModel
    {
        public IEnumerable<string> Headers { get; set; }
        public dynamic Items { get; set; }
    }
}