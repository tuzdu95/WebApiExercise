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
    [Route("video")]
    public class VideosController : Controller
    {
        private readonly IVideoService _videoService;

        public VideosController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpGet("publisher/{publisherId}")]
        public async Task<ObjectResult> GetVideosByPublisher(int publisherId)
        {
            var videos = await _videoService.GetListVideoByPublisher(publisherId);
            if (videos.Count > 0)
            {
                return new OkObjectResult(videos);
            }
            else
            {
                return new NotFoundObjectResult("No video uploaded for the Publisher");
            }
        }

        [HttpGet("{videoId}")]
        public async Task<ObjectResult> GetVideoById(int videoId)
        {
            var video = await _videoService.GetVideoById(videoId);
            if (video is not null)
            {
                return new OkObjectResult(video);
            }
            else
            {
                return new NotFoundObjectResult("No video uploaded for the Publisher");
            }
        }
    }
}
