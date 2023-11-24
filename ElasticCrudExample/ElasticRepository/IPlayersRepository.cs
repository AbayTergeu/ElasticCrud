using ElasticCrudExample.Models;

namespace ElasticCrudExample.ElasticRepository;

/// <summary>
/// Elastic repository for Player.
/// </summary>
public interface IPlayersRepository
{
    /// <summary>
    /// Api for create Players model in Elastic.
    /// </summary>
    /// <param name="players"></param>
    Task CreateAsync(Players players);
    
    /// <summary>
    /// Api for get Players bu Id in Elastic.
    /// </summary>
    /// <param name="id">Players identify.</param>
    /// <returns><see cref="Players"/></returns>
    Task<Players> GetAsync(int id);
    
    /// <summary>
    /// Api for search by UserName in Elastic.
    /// </summary>
    /// <param name="userName">Players user name.</param>
    /// <returns><see cref="Players"/></returns>
    Task<Players?> SearchAsync(string userName);
    
    /// <summary>
    /// Api for update Players in Elastic.
    /// </summary>
    /// <param name="players"><see cref="Players"/></param>
    Task UpdateAsync(Players players);
    
    /// <summary>
    /// Api for remove Players in Elastic.
    /// </summary>
    /// <param name="id">Players identify.</param>
    Task DeleteAsync(int id);
}