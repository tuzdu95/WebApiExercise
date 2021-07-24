using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiExercise.Models
{
    public class MyEventArgs:EventArgs
    {
        public string VideoName { get; set; }
    }
}
