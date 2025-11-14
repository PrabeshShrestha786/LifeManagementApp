namespace LifeManagementApp.Interfaces;

using LifeManagementApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IJokeService
{
    Task<List<Joke>> GetJokesAsync();
}
