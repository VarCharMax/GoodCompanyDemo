namespace GoodCompany.Data.Models
{
    public class LaptopComputer : ComputerModel
    {
        public LaptopComputer() : base()
        {
            this.TypeName = "Laptop";
        }
        public int ScreenSize { get; set; }
    }
}
