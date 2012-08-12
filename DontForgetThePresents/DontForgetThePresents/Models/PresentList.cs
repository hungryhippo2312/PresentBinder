using System.Collections.Generic;
namespace DontForgetThePresents.Models
{
    public class PresentList
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Notes { get; set; }

        public virtual List<Present> Presents { get; set; }

        public PresentList()
        {
        }
    }
}
