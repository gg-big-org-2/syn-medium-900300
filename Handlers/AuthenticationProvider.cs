using System;
using System.Net.Http.Headers;

public class AuthenticationProvider
{
    private readonly string _token;

    public AuthenticationProvider(string token)
    {
        _token = token ?? throw new ArgumentNullException(nameof(token));
    }

    public void ApplyAuthentication(HttpClient client)
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
    }

    public bool IsValid() => !string.IsNullOrEmpty(_token) && _token.Length > 20;
}
