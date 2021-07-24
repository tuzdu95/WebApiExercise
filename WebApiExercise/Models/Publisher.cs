using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiExercise.Models
{
    public class Publisher
    {
        public Publisher()
        {
            this.Subscribers = new HashSet<Subscriber>();
        }
        [Key]
        public int PublisherId { get; set; }
        [Required]
        public string PublisherName { get; set; }
        public virtual ICollection<Subscriber> Subscribers { get; set; }
    }
}
