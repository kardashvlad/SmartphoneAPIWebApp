namespace SmartphoneAPIWebApp.Models
{
    public class Favorite
    {
        public Favorite()
        {

        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SmartphoneId { get; set; }
        public virtual User? User { get; set; }
        public virtual Smartphone? Smartphone { get; set; }
    }
}
