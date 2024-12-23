using HealthCareDataMangement.Response;
namespace HealthCareDataMangement.Interfaces
{
    public interface IRemoveExpData
    {
        public Task<List<RemoveExpDataResponse>> RemoveExpData(int monthsttoexp);

    }
}
