
namespace WeldingV2._0.Models
{
    public class Voltage
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public int MachineDataId { get; set; }
        public MachineData MachineData { get; set; }
    }
}
