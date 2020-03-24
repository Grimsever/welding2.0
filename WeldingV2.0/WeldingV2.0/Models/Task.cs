
namespace WeldingV2._0.Models
{
    public class Task
    {
        public int TaskId { get; set; }


        public int TechMapId { get; set; }
        public TechMap TechMap { get; set; }

        public int MachineId { get; set; }
        public Machine Machine { get; set; }

        public int WorkerId { get; set; }
        public Workers Worker { get; set; }
    }
}
