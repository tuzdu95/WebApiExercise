using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiExercise.Models;

namespace WebApiExercise.Services
{
    public interface IVideoService
    {
        Task UploadVideo(Video video);
        Task PublishVideo(int videoId);
        Task DeleteVideo(int videoId);
        Task<Video> GetVideoById(int videoId);
        Task<List<Video>> GetListVideoByPublisher(int publisherId);
    }
}
