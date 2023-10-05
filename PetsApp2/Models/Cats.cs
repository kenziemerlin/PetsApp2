using System.ComponentModel;

namespace PetsApp2.Models
{
    public class Cat
    {
        public int CatId { get; set; }

        [DisplayName("File Name")]
        public string FileName { get; set; } = string.Empty;
        public string PetName { get; set; } = string.Empty;
        public string Breed { get; set; } = string.Empty;
        public string Weight { get; set; } = string.Empty;
        public string FaveToy { get; set; } = string.Empty;
    }
}
