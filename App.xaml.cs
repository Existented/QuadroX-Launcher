using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

public class EpicGamesApi
{
    private const string ClientId = "YOUR_CLIENT_ID";
    private const string ClientSecret = "YOUR_CLIENT_SECRET";
    private const string RedirectUri = "YOUR_REDIRECT_URI";
    private const string AuthBaseUrl = "https://www.epicgames.com/id/api/redirect";
    private const string TokenUrl = "https://www.epicgames.com/id/api/token";

    private readonly HttpClient _httpClient = new HttpClient();
    private readonly string accessToken;

    public static async Task<string> GetAuthorizationUrl()
    {
        return $"{AuthBaseUrl}?response_type=code&client_id={ClientId}&redirect_uri={RedirectUri}&scope=basic";
    }

    public async Task<string> GetAccessToken(string authorizationCode)
    {
        var requestContent = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("grant_type", "authorization_code"),
            new KeyValuePair<string, string>("code", authorizationCode),
            new KeyValuePair<string, string>("client_id", ClientId),
            new KeyValuePair<string, string>("client_secret", ClientSecret),
            new KeyValuePair<string, string>("redirect_uri", RedirectUri)
        });

        var response = await _httpClient.PostAsync(TokenUrl, requestContent);
        var content = await response.Content.ReadAsStringAsync();

        // Parse JSON response to get access token
        // Handle errors and return access token
        return accessToken;
    }
}
