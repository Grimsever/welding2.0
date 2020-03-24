using System.Collections.Generic;

namespace WeldingV2._0.Models
{
    public class Foremen
    {
        public int ForemenId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public ICollection<Workers> Workers { get; set; }

        public Foremen()
        {
            Workers = new List<Workers>();
        }
    }
}
