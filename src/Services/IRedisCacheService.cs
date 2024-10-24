namespace Movies.Api.Docker.Services
{
    public interface IRedisCacheService
    {
        Task<T?> GetDataAsync<T>(string key, 
            CancellationToken cancellationToken);
        Task RemoveDataAsync(string key, CancellationToken cancellationToken);
        Task SetDataAsync<T>(string key, T data, CancellationToken cancellationToken);
    }
}
