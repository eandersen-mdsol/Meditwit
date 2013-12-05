using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediTwit.Models;

namespace MediTwit.Services
{
    public interface ITwitService
    {
        Task CreateTwitForCurrentUser(string content);
        Task<IEnumerable<Twit>> GetAllTwitsOrderedByDate();
        Task<Twit> GetSingleTwit(Guid id);
    }
}