using BrendUz.Entity;

namespace BrendUz.Dtos
{
    public class GetClothDto

    {
        public GetClothDto(Cloth entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Brend = entity.Brend;
            Price = entity.Price;
            Size = entity.Size;
            Made = entity.Made;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Brend { get; set; }
        public double Price { get; set; }
        public string Size { get; set; }
        public string Made { get; set; }
    }
}
