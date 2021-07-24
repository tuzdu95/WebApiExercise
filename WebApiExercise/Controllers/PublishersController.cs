using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApiExercise.Models;
using WebApiExercise.Services;

namespace WebApiExercise.Controllers
{
    [Route("publisher")]
    public class PublishersController : Controller
    {
        private readonly IPublisherService _publisherService;
        private readonly IVideoService _videoService;
        private readonly INotificationService _notificationService;

        public PublishersController(IPublisherService publisherService, IVideoService videoService,INotificationService notificationService)
        {
            _publisherService = publisherService;
            _videoService = videoService;
            _notificationService = notificationService;
        }

        [HttpPost("create")]
        public async Task<ObjectResult> Create([FromBody]Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                await _publisherService.RegisterPublisher(publisher);
                return new OkObjectResult($"Publisher {publisher.PublisherName} Created!");
            }
            return new BadRequestObjectResult("Error Occupied!");
        }
        [HttpPost("upload-video")]
        public async Task<ObjectResult> UploadVideo([FromBody] Video video)
        {
            if (ModelState.IsValid)
            {
                await _videoService.UploadVideo(video);
                return new OkObjectResult($"Successfully Upload {video.VideoName}!");
            }
            return new BadRequestObjectResult("Error Occupied!");
        }

        [HttpPost("publish-video/{publisherId}/{videoId}")]
        public async Task<ObjectResult> PublishVideo(int publisherId, int videoId)
        {
            await _videoService.PublishVideo(videoId);
            await _notificationService.EmailNotification(publisherId,videoId);
            return new OkObjectResult("Successfully Publish!");
        }
    }
}
