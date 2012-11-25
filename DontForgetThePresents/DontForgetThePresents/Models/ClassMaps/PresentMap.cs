using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace DontForgetThePresents.Models.ClassMaps
{
    public class PresentMap : ClassMap<Present>
    {
        public PresentMap()
        {
            Id(x => x.Id);
            Map(x => x.Description);
            References(x => x.List)
                .Column("ListId");
        }
    }
}
