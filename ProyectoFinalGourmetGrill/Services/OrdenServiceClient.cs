using Shared.Interfaces;
using Shared.Models;

namespace ProyectoFinalGourmetGrill.Services;

public class OrdenServiceClient(HttpClient httpClient) : IClient<Ordenes>
{
    public async Task<List<Ordenes>> GetAllObject() {
        var response = await httpClient.GetAsync("api/Ordenes");

        if (response.IsSuccessStatusCode) {
            return await response.Content.ReadFromJsonAsync<List<Ordenes>>();
        }

        return null;
    }

    public async Task<Ordenes> AddObject(Ordenes orden) {
        var response = await httpClient.PostAsJsonAsync("api/Ordenes", orden);

        if (response.IsSuccessStatusCode) {
            return await response.Content.ReadFromJsonAsync<Ordenes>();
        }

        return null;
    }

    public async Task<Ordenes> GetObject(int id) {
        var response = await httpClient.GetAsync($"api/Ordenes/{id}");

        if (response.IsSuccessStatusCode) {
            return await response.Content.ReadFromJsonAsync<Ordenes>();
        }

        return null;
    }

    public async Task<bool> UpdateObject(Ordenes orden) {
        var response = await httpClient.PutAsJsonAsync($"api/Ordenes/{orden.OrdenId}", orden);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteObject(int id) {
        var response = await httpClient.DeleteAsync($"api/Ordenes/{id}");
        return response.IsSuccessStatusCode;
    }
}
