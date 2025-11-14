using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using LifeManagementApp.Interfaces;
using LifeManagementApp.Models;

namespace LifeManagementApp.Services;

public class JokeApiService : IJokeService
{
    private readonly HttpClient httpClient;

    private const string Url =
        "https://v2.jokeapi.dev/joke/Programming" +
        "?blacklistFlags=nsfw,religious,political,racist,sexist,explicit&amount=3";

    public JokeApiService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<List<Joke>> GetJokesAsync()
    {
        HttpResponseMessage response = await httpClient.GetAsync(Url);
        response.EnsureSuccessStatusCode();

        string json = await response.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        JokeApiResponse apiResponse =
            JsonSerializer.Deserialize<JokeApiResponse>(json, options)!;

        var jokes = new List<Joke>();

        foreach (var j in apiResponse.Jokes)
        {
            if (j.Type == "single")
            {
                jokes.Add(new Joke { Content = j.Joke ?? string.Empty });
            }
            else
            {
                jokes.Add(new Joke
                {
                    Content = (j.Setup ?? "") + Environment.NewLine + (j.Delivery ?? "")
                });
            }
        }

        return jokes;
    }

    // DTOs for JokeAPI response
    private class JokeApiResponse
    {
        public List<JokeApiItem> Jokes { get; set; } = new();
    }

    private class JokeApiItem
    {
        public string Type { get; set; } = string.Empty;
        public string? Joke { get; set; }
        public string? Setup { get; set; }
        public string? Delivery { get; set; }
    }
}
