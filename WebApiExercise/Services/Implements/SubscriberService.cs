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
        private readonly IPublisherService _publisherService;
        public SubscriberService(WebApiExerciseContext dbContext, IPublisherService publisherService)
        {
            _dbContext = dbContext;
            _publisherService = publisherService;
        }

        public async Task<HashSet<Publisher>> GetListPublisherBySubscriberId(int subscriberId)
        {
            var subscriber = await GetSubscriberById(subscriberId);
            return (HashSet<Publisher>)subscriber.Publishers;
        }

        public async Task<Subscriber> GetSubscriberById(int subscriberId)
        {
            return await _dbContext.Subscribers
                .Include(sub => sub.Publishers)
                .FirstOrDefaultAsync(sub => sub.SubscriberId == subscriberId);
        }

        public async Task RegisterSubscriber(Subscriber subscriber)
        {
            _dbContext.Add(subscriber);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SubscribePublisher(int publisherId, int subscriberId)
        {
            var subscriber = await GetSubscriberById(subscriberId);
            var publisher = await _publisherService.GetPublisherById(publisherId);
            publisher.Subscribers.Add(subscriber);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UnSubscribePublisher(int publisherId, int subscriberId)
        {
            var subscriber = await GetSubscriberById(subscriberId);
            var publisher = await _publisherService.GetPublisherById(publisherId);
            publisher.Subscribers.Remove(subscriber);
            await _dbContext.SaveChangesAsync();
        }
    }
}
