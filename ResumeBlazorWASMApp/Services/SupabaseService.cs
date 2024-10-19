using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using UglyToad.PdfPig.Fonts.Encodings;
using Encoding = System.Text.Encoding;
using Supabase.Gotrue;



namespace ResumeBlazorWASMApp.Services;

public class SupabaseService
{
     private readonly HttpClient _httpClient;
     private string _supabaseUrl;
     private string _supabaseKey;
    //private readonly GotrueClient _gotrueClient;

    public SupabaseService(HttpClient httpClient, string supabaseUrl)
    {
        _httpClient = httpClient;
        _supabaseUrl = supabaseUrl;
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

    // public async Task<string> Login(string email, string password)
    // {
    //     var requestBody = new
    //     {
    //         email, password
    //     };
    //     var response = await _httpClient.PostAsync("auth/v1/token",
    //         new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json"));
    //
    //     var content = await response.Content.ReadAsStringAsync();
    //
    //     var token = JsonDocument.Parse(content).RootElement.GetProperty("access_token").GetString();
    //     _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    //     return token;
    // }

    public async Task<string> SignIn(string email, string password)
    {
        //var response = await _httpClient.PostAsJsonAsync($"{_supabaseUrl}/auth/v1/token", new { email, password });

        var payload = new
        {
            grant_type = "password",
            email,
            password
        };
        var response = await _httpClient.PostAsJsonAsync($"{_supabaseUrl}/auth/v1/token", payload);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }
        else
        {
            throw new Exception("Error signing in");
        }
    }

    public async Task SignOut()
    {
        await _httpClient.PostAsync($"{_supabaseUrl}/auth/v1/logout", null);
    }
}