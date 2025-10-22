// detector: github_app_keys
using System;
using System.Net.Http;
using System.Threading.Tasks;

public class GitHubClient
{
    private readonly HttpClient _httpClient;

    public GitHubClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Repository> GetRepositoryAsync(string owner, string repo)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.github.com/repos/{owner}/{repo}");
        request.Headers.Add("Authorization", $"Bearer {githubToken}");
        request.Headers.Add("Accept", "application/vnd.github+json");

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return Repository.FromJson(content);
    }
}
