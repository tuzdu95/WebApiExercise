using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebApiExercise.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IPublisherService _publisherService;
        private readonly IVideoService _videoService;
        public NotificationService(IPublisherService publisherService,IVideoService videoService)
        {
            _publisherService = publisherService;
        }
        public async Task EmailNotification(int publisherId, int videoId)
        {
            var publisher = await _publisherService.GetPublisherById(publisherId);
            var video = await _videoService.GetVideoById(publisherId);
            foreach (var subscriber in publisher.Subscribers)
            {
                await SendEmail(publisher.PublisherName,subscriber.SubscriberEmail, video.VideoName);
            }
        }
        private async Task SendEmail(string publisherName,string targetEmail, string content)
        {
            using (MailMessage mail = new MailMessage())
            {
                    mail.From = new MailAddress("ntd5995@gmail.com");
                    mail.To.Add(new MailAddress(targetEmail));
                    mail.Subject = $"New video on {publisherName}'s Chanel!";
                    mail.Body = $"Video {content} is now on {publisherName}'s Chanel! \n Watch with us!";
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("ntd5995@gmail.com", "tuzdu12021996");
                        smtp.EnableSsl = true;
                        await smtp.SendMailAsync(mail);
                    }
            }
        }
    }
}
