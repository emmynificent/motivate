using System.Net.Http.Headers;
using System.Text;  
using System.Text.Json;


public class OpenAiService
{
    private readonly HttpClient _httpClient;
    private readonly string _apikey;
    public OpenAiService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apikey = configuration["OpenAI:ApiKey"];

    }
    public async Task<string> GenerateMotivationalQupteAsync(string emotion)
    {
        var prompt = $"Provide a motivational quote for someone feeling {emotion}.";
        var request = new{
            model = "text-davinci-003",
            prompt = prompt,
            max_tokens = 100,
            temperature = 0.7
        };

        var jsonRequest = JsonSerializer.Serialize(request);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("https://api.openai.com/v1/engines/text-davinci-003/completions", content);
        response.EnsureSuccessStatusCode();

        var jsonresponse = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<OpenAiResponse>(jsonresponse);
        return result?.Choices.FirstOrDefault()?.Text.Trim()?? "No quote generated";
    }
}

public class OpenAiResponse
{

    public List<Choice> Choices {get; set;}
}

public class Choice 
{
    public string Text {get; set;}
    
}