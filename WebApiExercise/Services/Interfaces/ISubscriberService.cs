using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiExercise.Models;

namespace WebApiExercise.Services
{
    public interface ISubscriberService
    {
        Task RegisterSubscriber(Subscriber subscriber);
        Task SubscribePublisher(int publisherId, int subscriberId);
        Task UnSubscribePublisher(int publisherId, int subscriberId);
        Task<Subscriber> GetSubscriberById(int subscriberId);
        Task<HashSet<Publisher>> GetListPublisherBySubscriberId(int subscriberId);
    }
}
