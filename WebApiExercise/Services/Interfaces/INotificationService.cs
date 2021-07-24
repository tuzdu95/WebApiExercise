using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiExercise.Services
{
    public interface INotificationService
    {
        Task EmailNotification(int publisherId,int videoId);
    }
}
