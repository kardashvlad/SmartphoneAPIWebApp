namespace SmartphoneAPIWebApp.Models
{
    public class User
    {
        public User()
        {
            Smartphones = new List<Smartphone>();
            Favorites = new List<Favorite>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Smartphone> Smartphones { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
    }
}
