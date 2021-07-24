using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiExercise.Models;

namespace WebApiExercise.Services
{
    public interface IPublisherService
    {
        Task RegisterPublisher(Publisher publisher);
        Task<Publisher> GetPublisherById(int publisherId);
        Task<HashSet<Subscriber>> GetSubscribersByPublisher(int publisherId);
    }
}
