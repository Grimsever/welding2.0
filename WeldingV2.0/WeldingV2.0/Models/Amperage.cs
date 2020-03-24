namespace WeldingV2._0.Models
{
    public class Amperage
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public int MachineDataId { get; set; }
        public MachineData MachineData { get; set; }
    }
}
