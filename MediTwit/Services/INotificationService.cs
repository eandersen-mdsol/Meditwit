using System.Threading.Tasks;
using MediTwit.Models;

namespace MediTwit.Services
{
    public interface INotificationService
    {
        Task NotifyNewTwit(Twit twit);
    }
}