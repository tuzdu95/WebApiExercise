using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiExercise.Models;

namespace WebApiExercise.Services
{
    public interface INotificationService
    {
        Task EmailNotification(Video video);
    }
}
