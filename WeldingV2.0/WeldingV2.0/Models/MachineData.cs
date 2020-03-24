using System.Collections.Generic;

namespace WeldingV2._0.Models
{
    public class MachineData
    {
        public int Id { get; set; }

        public int MachineId { get; set; }
        public Machine Machine { get; set; }
        public ICollection<Amperage> Amperages { get; set; }
        public ICollection<Voltage> Voltages { get; set; }

        public MachineData()
        {
            Amperages = new List<Amperage>();
            Voltages = new List<Voltage>();
        }

    }
}
