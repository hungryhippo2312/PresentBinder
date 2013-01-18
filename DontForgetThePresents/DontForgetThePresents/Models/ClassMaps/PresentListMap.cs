using DontForgetThePresents.Core;
using FluentNHibernate.Mapping;

namespace DontForgetThePresents.Models.ClassMaps
{
    [UsedImplicitly]
    public class PresentListMap : ClassMap<PresentList>
    {
        public PresentListMap()
        {
            Id(x => x.Id);

            Map(x => x.Name);
            Map(x => x.Notes)
                .Nullable();
            HasMany(x => x.Presents)
                .KeyColumn("ListId");
            
            Version(x => x.Version)
                .Generated.Always();
            OptimisticLock.Version();
        }
    }
}
