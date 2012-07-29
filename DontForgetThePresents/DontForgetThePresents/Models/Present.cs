namespace DontForgetThePresents.Models
{
    public class Present
    {
        public int Id { get; set; }
        public int ListId { get; set; }
        public string Description { get; set; }

        public Present()
        {
        }
    }
}
