using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiExercise.Models;

    public class WebApiExerciseContext : DbContext
    {
        public WebApiExerciseContext (DbContextOptions<WebApiExerciseContext> options)
            : base(options)
        {
        }

        public DbSet<Video> Videos { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
    }
