using System.Net.Http.Headers;
using System.Net.Http.Json;

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

    public async Task<string> SignUp(string email, string password)
    {
        var response = await _httpClient.PostAsJsonAsync($"{_supabaseUrl}/auth/v1/signup", new { email, password });
        return await response.Content.ReadAsStringAsync();
    }
}