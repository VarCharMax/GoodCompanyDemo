namespace GoodCompany.Data.Models
{
    public class PCComputer : ComputerModel
    {
        public PCComputer() : base()
        {
            this.TypeName = "Desktop";
        }

        public int UsbPorts { get; set; }

        public int RamSlots { get; set; }
    }
}
