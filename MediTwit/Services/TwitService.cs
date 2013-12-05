using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MediTwit.Models;

namespace MediTwit.Services
{
    public class TwitService : ITwitService
    {
        private readonly ApplicationDbContext context;
        private readonly IIdentityService identityService;
        private readonly INotificationService notificationService;

        public TwitService(ApplicationDbContext context, IIdentityService identityService, INotificationService notificationService)
        {
            this.context = context;
            this.identityService = identityService;
            this.notificationService = notificationService;
        }

        public async Task CreateTwitForCurrentUser(string content)
        {
            var currentUserId = identityService.GetCurrentUserId();

            var twit = new Twit
            {
                Id = Guid.NewGuid(),
                TwitContent = content,
                CreatedAt = DateTime.UtcNow,
                User = await context.Users.SingleAsync(u => u.Id == currentUserId)
            };

            context.Twits.Add(twit);

            var saveTask = context.SaveChangesAsync();

            var notifyTask = notificationService.NotifyNewTwit(twit);

            await Task.WhenAll(saveTask, notifyTask);


        }

        public async Task<IEnumerable<Twit>> GetAllTwitsOrderedByDate()
        {
            return await context.Twits.OrderByDescending(t => t.CreatedAt).Include(t => t.User).ToListAsync();

        }

        public async Task<Twit> GetSingleTwit(Guid id)
        {
            return await context.Twits.FindAsync(id);

        }
    }

}