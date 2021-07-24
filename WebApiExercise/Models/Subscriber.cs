using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiExercise.Models
{
    public class Subscriber
    {
        public Subscriber()
        {
            this.Publishers = new HashSet<Publisher>();
        }
        [Key]
        public int SubscriberId { get; set; }
        [Required]
        public string SubscriberName { get; set; }
        [Required]
        [EmailAddress]
        public string SubscriberEmail { get; set; }

        public ICollection<Publisher> Publishers { get; set; }
    }
}
