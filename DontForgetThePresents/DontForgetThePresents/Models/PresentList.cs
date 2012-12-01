using System.Collections.Generic;
using System;
namespace DontForgetThePresents.Models
{
    public class PresentList
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Notes { get; set; }
        public virtual byte[] Version { get; set; }

        public virtual IList<Present> Presents { get; set; }

        public PresentList()
        {
        }
    }
}
