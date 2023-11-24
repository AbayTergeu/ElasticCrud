using ElasticCrudExample.Models;
using Nest;

namespace ElasticCrudExample.ElasticRepository;

/// <inheritdoc />
public class PlayersRepository : IPlayersRepository
{
    private readonly IElasticClient _client;

    public PlayersRepository(IElasticClient client)
    {
        _client = client;
    }

    /// <inheritdoc />
    public async Task CreateAsync(Players players)
    {
        var response = await _client.IndexAsync(players, p=>p.Index("players_index")); 

        if (response.IsValid) 
        {
            Console.WriteLine($"Index document with ID {response.Id} succeeded."); 
        }
    }

    /// <inheritdoc />
    public async Task<Players> GetAsync(int id)
    {
        var response = await _client.GetAsync<Players>(id, idx => idx.Index("players_index"));

        if (!response.IsValid)
        {
            throw new Exception("Invalid operation GetAsync");
        }
        var players = response.Source;
        return players;
    }

    /// <inheritdoc />
    public async Task<Players?> SearchAsync(string text)
    {
        var responseTst = await _client.GetAsync<Players>(1, idx => idx.Index("players_index"));
        var response = await _client.SearchAsync<Players>(s => s 
            .Index("players_index") 
            .From(0)
            .Size(10)
            .Query(q => q
                .Term(t => t.UserName, text) 
            )
        );

        if (!response.IsValid)
        {
            throw new Exception("Invalid operation SearchAsync");
        }
        var players = response.Documents.FirstOrDefault();
        return players;
    }

    /// <inheritdoc />
    public async Task UpdateAsync(Players players)
    {
        var response = await _client.UpdateAsync<Players, Players>(players.Id, idx => idx.Index("players_index").Doc(players));
        if (response.IsValid)
        {
            Console.WriteLine("Update document succeeded.");
        }
    }

    /// <inheritdoc />
    public async Task DeleteAsync(int id)
    {
        var response = await _client.DeleteAsync<Players>(id, idx => idx.Index("players_index"));

        if (response.IsValid)
        {
            Console.WriteLine("Delete document succeeded.");
        }
    }
}