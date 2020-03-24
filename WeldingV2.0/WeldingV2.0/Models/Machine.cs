using System.ComponentModel.DataAnnotations.Schema;

namespace WeldingV2._0.Models
{
    public class Machine
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("MachineData")]
        public int MachineDataId { get; set; }
        public MachineData MachineData { get; set; }

        [ForeignKey("Task")] 
        public int? TaskId { get; set; }
        public Task Task { get; set; }
    }
}
