namespace SmartphoneAPIWebApp.Models
{
    public class Category
    {
        public Category()
        {
            Smartphones = new List<Smartphone>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Smartphone> Smartphones { get; set; }
    }
}
