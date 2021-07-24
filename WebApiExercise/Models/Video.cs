using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiExercise.Models
{
    public class Video
    {
        [Key]
        public int VideoId { get; set; }
        [Required]
        public string VideoName { get; set; }
        [Range(0, 1, ErrorMessage = "Please enter valid integer Number in range (0,1)")]
        public int Status { get; set; } = 0;
        public DateTime UploadDate { get; set; }
        public DateTime PublishDate { get; set; }
        [Required]
        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
