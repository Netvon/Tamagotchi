namespace Tamagotchi.Web.Models
{
    public class HomeModel
    {
        public HomeModel(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; set; }
        public int Id { get; set; }
    }
}