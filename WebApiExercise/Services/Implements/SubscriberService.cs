using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiExercise.Models;

namespace WebApiExercise.Services
{
    public class SubscriberService : ISubscriberService
    {
        private readonly WebApiExerciseContext _dbContext;
        public SubscriberService(WebApiExerciseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<HashSet<Publisher>> GetListPublisherBySubscriberId(int subscriberId)
        {
            var subscriber = await GetSubscriberById(subscriberId);
            return (HashSet<Publisher>)subscriber.Publishers;
        }

        public async Task<Subscriber> GetSubscriberById(int subscriberId)
        {
            var subscriber = await _dbContext.Subscribers
                .Include(sub => sub.Publishers)
                .FirstOrDefaultAsync(sub => sub.SubscriberId == subscriberId);
            return subscriber;
        }

        public async Task RegisterSubscriber(Subscriber subscriber)
        {
            _dbContext.Add(subscriber);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SubscribePublisher(Publisher publisher, Subscriber subscriber)
        {
            publisher.Subscribers.Add(subscriber);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UnSubscribePublisher(Publisher publisher, Subscriber subscriber)
        {
            publisher.Subscribers.Remove(subscriber);
            await _dbContext.SaveChangesAsync();
        }
    }
}
