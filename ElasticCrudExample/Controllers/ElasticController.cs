using ElasticCrudExample.ElasticRepository;
using ElasticCrudExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElasticCrudExample.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ElasticController : ControllerBase
{
    private readonly IPlayersRepository _playersRepository;

    public ElasticController(IPlayersRepository playersRepository)
    {
        _playersRepository = playersRepository;
    }

    [HttpPut(Name = "CreatePlayers")]
    public async Task<bool> CreatePlayers(Players players)
    {
        await _playersRepository.CreateAsync(players);
        return true;
    }

    [HttpGet(Name = "GetPlayers")]
    public async Task<Players> GetPlayers(int id)
    {
        var players = await _playersRepository.GetAsync(id);
        return players;
    }
    
    [HttpGet(Name = "SearchPlayers")]
    public async Task<Players?> SearchPlayers(string userName)
    {
        var players = await _playersRepository.SearchAsync(userName);
        return players;
    }
    
    [HttpPost(Name = "UpdatePlayers")]
    public async Task<Players?> UpdatePlayers(Players players)
    {
        await _playersRepository.UpdateAsync(players);
        var updPlayers = await _playersRepository.GetAsync(players.Id);
        return updPlayers;
    }
    
    [HttpDelete(Name = "DeletePlayers")]
    public async Task<bool> DeletePlayers(int id)
    {
        await _playersRepository.DeleteAsync(id);
        return true;
    }
}