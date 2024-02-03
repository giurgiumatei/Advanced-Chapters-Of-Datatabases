using TransferMarket.Business.Versions.Queries;

namespace TransferMarket.API.Requests.Versions
{
    public static class VersionExtensions
    {
        public static GetVersionQuery ToQuery(this GetVersionRequest request)
        {
            return new GetVersionQuery
            {
                Name = request.Name
            };
        }
    }
}
