namespace GoodCompany.Data.Models
{
    public class PCComputer : ComputerModel
    {
        public PCComputer() : base()
        {
            this.TypeName = new ComputerType { Name = "Desktop" };
        }

        public int UsbPorts { get; set; }

        public int RamSlots { get; set; }

        public int Quantity { get; set; }
    }
}
