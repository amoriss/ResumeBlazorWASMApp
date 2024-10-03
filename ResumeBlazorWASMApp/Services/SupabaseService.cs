using System.Net.Http.Headers;

namespace ResumeBlazorWASMApp.Services;

public class SupabaseService
{
    private readonly HttpClient _httpClient;
    private string _supabaseUrl;
    private string _supabaseKey;

    public SupabaseService(HttpClient httpClient, string supabaseUrl, string supabaseKey)
    {
        _httpClient = httpClient;
        _supabaseUrl = supabaseUrl;
        _supabaseKey = supabaseKey;
    }

    public async Task<string> GetDataAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync(_supabaseUrl);
            return await response.Content.ReadAsStringAsync();
        }
        catch (Exception e)
        {
            return e.Message;
        }
        
    }
}