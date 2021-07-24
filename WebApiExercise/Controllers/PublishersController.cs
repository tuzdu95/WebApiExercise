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
            return new BadRequestObjectResult("Error Occupied! Check the input data");
        }
        [HttpPost("upload-video")]
        public async Task<ObjectResult> UploadVideo([FromBody] Video video)
        {
            if (ModelState.IsValid)
            {
                await _videoService.UploadVideo(video);
                return new OkObjectResult($"Successfully Upload {video.VideoName}!");
            }
            return new BadRequestObjectResult("Error Occupied! Check the input data");
        }

        [HttpPost("publish-video/{videoId}")]
        public async Task<ObjectResult> PublishVideo(int videoId)
        {
            var video = await _videoService.GetVideoById(videoId);
            if (video is not null)
            {
                if (video.Status ==0)
                {
                    await _videoService.PublishVideo(video);
                    await _notificationService.EmailNotification(video);
                    return new OkObjectResult("Successfully Publish!");
                }
                return new BadRequestObjectResult("Video is already Published!");
            }
            else
            {
                return new NotFoundObjectResult("Not exist video with given Id");
            }
        }
    }
}
