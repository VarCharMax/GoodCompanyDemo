namespace GoodCompany.Data.Models
{
    public class LaptopComputer : ComputerModel
    {
        public LaptopComputer() : base()
        {
            this.TypeName = new ComputerType { Name = "Laptop" };
        }
        public int ScreenSize { get; set; }
    }
}
