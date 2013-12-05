using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MediTwit.Hubs;
using MediTwit.Models;
using Microsoft.AspNet.SignalR;

namespace MediTwit.Services
{
    public class HubNotificationService : INotificationService
    {
        public async Task NotifyNewTwit(Twit twit)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<TwitHub>();
            await context.Clients.All.NewTwit(twit.Id);
        }
    }

}