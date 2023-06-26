namespace SmartphoneAPIWebApp.Models
{
    public class Smartphone
    {
        public Smartphone()
        {

        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public virtual User? User { get; set; }
        public virtual Category? Category { get; set; }
    }
}
