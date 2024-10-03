using System.Net.Http.Headers;

namespace ResumeBlazorWASMApp.Services;

public class SupabaseService
{
    private readonly HttpClient _httpClient;

    public SupabaseService(HttpClient httpClient, string supabaseUrl, string supabaseKey)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(supabaseUrl);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", supabaseKey);
    }

    public async Task<string> GetDataAsync()
    {
        var response = await _httpClient.GetAsync(_httpClient.BaseAddress);
        return await response.Content.ReadAsStringAsync();
    }
}