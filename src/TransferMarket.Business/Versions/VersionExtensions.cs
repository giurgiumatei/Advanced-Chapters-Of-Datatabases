using TransferMarket.Business.Versions.Models;
using System.Linq;
using TransferMarket.Data.Models.ApplicationVersions;

namespace TransferMarket.Business.Versions
{
    public static class VersionExtensions
    {
        public static IQueryable<VersionCode> ToVersionCode(this IQueryable<ApplicationVersion> query)
        {
            return query.Select(q => new VersionCode
            {
                Version = q.Version
            });
        }
    }
}
