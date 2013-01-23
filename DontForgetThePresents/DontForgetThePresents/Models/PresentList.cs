using System.Collections.Generic;
using DontForgetThePresents.Core;

namespace DontForgetThePresents.Models
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class PresentList
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Notes { get; set; }
        public virtual byte[] Version { get; set; }

        public virtual IList<Present> Presents { get; set; }

        public virtual void AddPresent(Present present)
        {
            Presents.Add(present);
            present.List = this;
        }
    }
}
