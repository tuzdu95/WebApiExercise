using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiExercise.Models;

namespace WebApiExercise.Services
{
    public class PublisherService:IPublisherService
    {
        private readonly WebApiExerciseContext _dbContext;
        public PublisherService(WebApiExerciseContext dbContext)
        {
            _dbContext = dbContext;
        } 
        public async Task RegisterPublisher(Publisher publisher)
        {
            _dbContext.Add(publisher);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Publisher> GetPublisherById(int publisherId)
        {
            var publisher = await _dbContext.Publishers
                            .Include(pub=>pub.Subscribers)
                            .FirstOrDefaultAsync(pub => pub.PublisherId == publisherId);
            return publisher;
        }

        public async Task<HashSet<Subscriber>> GetSubscribersByPublisher(int publisherId)
        {
            var publisher = await GetPublisherById(publisherId);
            return (HashSet<Subscriber>)publisher.Subscribers;
        }
    }
}
