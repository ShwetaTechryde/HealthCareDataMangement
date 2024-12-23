using HealthCareDataMangement.Controllers;
using HealthCareDataMangement.Interfaces;
using HealthCareDataMangement.Response;
using Newtonsoft.Json;
using System.Data;
using System.Collections.Generic; 
using System.Globalization;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
namespace HealthCareDataMangement.Services
{
    public class RemoveExpiredDataService: RemoveExpiredDataServiceBase, IRemoveExpData
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly IDatabaseaccess databaseaccess;
        public RemoveExpiredDataService(ILogger logger, IDatabaseaccess databaseaccess) 
        {

            this._logger = _logger ?? throw new ArgumentNullException();
            this.databaseaccess = databaseaccess;
        }
        public  async Task<List<RemoveExpDataResponse>> RemoveExpData(int monthsttoexp)
        {
            using DataTable dt = this.databaseaccess.Removexpdata(monthsttoexp);
            string JsonResponseCompact = JsonConvert.SerializeObject(dt);
            var response = dt.AsEnumerable().Select(row => new RemoveExpDataResponse()
            {
                Id = (string)row["id"],
                ExpDate = (DateTime)row["ExpDate"],
            }.ToString() );
            
        }

    }
}
