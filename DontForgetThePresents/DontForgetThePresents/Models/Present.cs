namespace DontForgetThePresents.Models
{
    public class Present
    {
        public virtual int Id { get; set; }
        public virtual PresentList List { get; set; }
        public virtual string Description { get; set; }
    }
}
