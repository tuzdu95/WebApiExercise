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
        Task SubscribePublisher(Publisher publisher, Subscriber subscriber);
        Task UnSubscribePublisher(Publisher publisher, Subscriber subscriber);
        Task<Subscriber> GetSubscriberById(int subscriberId);
        Task<HashSet<Publisher>> GetListPublisherBySubscriberId(int subscriberId);
    }
}
