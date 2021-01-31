using System;

namespace GoodCompany.Data.Models
{
    public abstract class ComputerModel : IEquatable<ComputerModel>
    {
        public ComputerModel()
        {
            if (this.Id == Guid.Empty)
            {
                this.Id = Guid.NewGuid();
            }
        }

        public Guid Id { get; set; }
        public string TypeName { get; set; }
        public string Brand { get; set; }
        public string ProcessorName { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }

        public override int GetHashCode()
        {
            unchecked
            {
                return new HashCode().ToHashCode();
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ComputerModel)obj);
        }

        public bool Equals(ComputerModel obj)
        {
            if (obj == null) return false;

            if (this.Id == obj.Id && this.TypeName == obj.TypeName) return true;

            return false;
        }
    }
}
