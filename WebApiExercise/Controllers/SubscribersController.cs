using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiExercise.Models;
using WebApiExercise.Services;

namespace WebApiExercise.Controllers
{
    [Route("subscriber")]
    public class SubscribersController : Controller
    {
        private readonly ISubscriberService _subscriberService;
        private readonly IPublisherService _publisherService;
        public SubscribersController(ISubscriberService subscriberService, IPublisherService publisherService)
        {
            _subscriberService = subscriberService;
            _publisherService = publisherService;
        }
        [HttpPost]
        public async Task<ObjectResult> RegisterSubscriber([FromBody]Subscriber subscriber)
        {
            if (ModelState.IsValid)
            {
                await _subscriberService.RegisterSubscriber(subscriber);
                return new OkObjectResult($"Register Successfully {subscriber.SubscriberName}");
            }
            return new BadRequestObjectResult("Error Occupied! Check input data!");
        }

        [HttpGet("publisher/{subscriberId}")]
        public async Task<ObjectResult> GetListPublisherBySubscriber (int subscriberId)
        {
            var publishers = await _subscriberService.GetListPublisherBySubscriberId(subscriberId);
            if (publishers.Count>0)
            {
                return new OkObjectResult(publishers);
            }
            return new NotFoundObjectResult("Subscriber does not follow any Publisher!");
        }

        [HttpPost("subscribe")]
        public async Task<ObjectResult> SubscribePublisher(int publisherId, int subscriberId)
        {
            var subscriber = await _subscriberService.GetSubscriberById(subscriberId);
            if (subscriber is not null)
            {
                var publisher = await _publisherService.GetPublisherById(publisherId);
                if (publisher is not null)
                {
                    await _subscriberService.SubscribePublisher(publisher, subscriber);
                    return new OkObjectResult("Subscribed!");
                }
                return new NotFoundObjectResult("Not Exist Publisher with given Id!");
            }
            return new NotFoundObjectResult("Not Exist Subscriber with given Id!");
        }

        [HttpPost("unsubscribe")]
        public async Task<ObjectResult> UnSubscribePublisher(int publisherId, int subscriberId)
        {
            var subscriber = await _subscriberService.GetSubscriberById(subscriberId);
            if (subscriber is not null)
            {
                var publisher = await _publisherService.GetPublisherById(publisherId);
                if (publisher is not null)
                {
                    await _subscriberService.UnSubscribePublisher(publisher, subscriber);
                    return new OkObjectResult("UnSubscribed!");
                }
                return new NotFoundObjectResult("Not Exist Publisher with given Id!");
            }
            return new NotFoundObjectResult("Not Exist Subscriber with given Id!");
        }
    }
}
