using HealthCareDataMangement.Response;
using System.Data;

namespace HealthCareDataMangement.Services
{
    public class RemoveExpiredDataServiceBase
    {
        public async Task<List<RemoveExpDataResponse>> RemoveExpData()
        {
            using DataTable dt = new DataTable();
            var response = "sweta";

        }
    }
}