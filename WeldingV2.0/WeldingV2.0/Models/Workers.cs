using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeldingV2._0.Models
{
    public class Workers
    {
        [Key]
        public int WorkerId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int ForemenId { get; set; }
        public Foremen Foremen { get; set; }
        public ICollection<Task> Task { get; set; }

    }
}
