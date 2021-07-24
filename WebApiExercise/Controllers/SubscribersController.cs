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
        public SubscribersController(ISubscriberService subscriberService)
        {
            _subscriberService = subscriberService;
        }
        [HttpPost]
        public async Task<ObjectResult> RegisterSubscriber([FromBody]Subscriber subscriber)
        {
            await _subscriberService.RegisterSubscriber(subscriber);
            return new OkObjectResult($"Register Successfully {subscriber.SubscriberName}");
        }

        [HttpGet("publisher/{subscriberId}")]
        public async Task<ObjectResult> GetListPublisherBySubscriber (int subscriberId)
        {
            var publishers = await _subscriberService.GetListPublisherBySubscriberId(subscriberId);
            return new OkObjectResult(publishers);
        }

        [HttpPost("subscribe")]
        public async Task<ObjectResult> SubscribePublisher(int publisherId, int subscriberId)
        {
            await _subscriberService.SubscribePublisher(publisherId, subscriberId);
            return new OkObjectResult("Subscribed!");
        }

        [HttpPost("unsubscribe")]
        public async Task<ObjectResult> UnSubscribePublisher(int publisherId, int subscriberId)
        {
            await _subscriberService.UnSubscribePublisher(publisherId, subscriberId);
            return new OkObjectResult("UnSubscribed!");
        }
    }
}
