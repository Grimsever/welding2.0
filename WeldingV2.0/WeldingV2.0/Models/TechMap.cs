using System.Collections.Generic;

namespace WeldingV2._0.Models
{
    public class TechMap
    {
        public int TechMapId { get; set; }
        public double MinValueAmp { get; set; }
        public double MaxValueAmp { get; set; }
        public double MinValueVolt { get; set; }
        public double MaxValueVolt { get; set; }

        public ICollection<Task> Tasks { get; set; }

        public TechMap()
        {
            Tasks = new List<Task>();
        }
    }
}
