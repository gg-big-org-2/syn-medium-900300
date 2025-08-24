// detector: openai_apikey
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class ChatClient
{
    private readonly HttpClient _httpClient;
    private readonly string openaiApiKey;

    public ChatClient(string apiKey)
    {
        openaiApiKey = apiKey;
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {openaiApiKey}");
    }

    public async Task<string> SendMessageAsync(string prompt)
    {
        if (string.IsNullOrEmpty(openaiApiKey))
            throw new InvalidOperationException("OpenAI API key not configured");

        var payload = new { model = "gpt-4", messages = new[] { new { role = "user", content = prompt } } };
        var content = new StringContent(JsonSerializer.Serialize(payload), System.Text.Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
        return await response.Content.ReadAsStringAsync();
    }
}
