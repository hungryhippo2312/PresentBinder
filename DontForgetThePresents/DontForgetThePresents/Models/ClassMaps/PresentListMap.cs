using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace DontForgetThePresents.Models.ClassMaps
{
    public class PresentListMap : ClassMap<PresentList>
    {
        public PresentListMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Notes)
                .Nullable();
            HasMany(x => x.Presents);
                //.KeyColumn("ListId");
        }
    }
}
