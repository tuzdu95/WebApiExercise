using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiExercise.Models;

namespace WebApiExercise.Services
{
    public class VideoService:IVideoService
    {
        private readonly WebApiExerciseContext _dbContext;
        public VideoService(WebApiExerciseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task UploadVideo(Video video)
        {
            video.UploadDate = DateTime.Now;
            _dbContext.Add(video);
            await _dbContext.SaveChangesAsync();
        }

        public async Task PublishVideo(int videoId)
        {
            var video = await GetVideoById(videoId);
            video.PublishDate = DateTime.Now;
            video.Status = 1;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteVideo(int videoId)
        {
            var video = await GetVideoById(videoId);
            _dbContext.Videos.Remove(video);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Video>> GetListVideoByPublisher(int publisherId)
        {
            var videos = await _dbContext.Videos
                .Include(video => video.Publisher)
                .Where(video => video.Publisher.PublisherId == publisherId)
                .ToListAsync();
            return videos;
        }

        public async Task<Video> GetVideoById(int videoId)
        {
            var video = await _dbContext.Videos
                .Include(video => video.Publisher)
                .FirstOrDefaultAsync(video => video.VideoId == videoId);
            return video;
        }
    }
}
