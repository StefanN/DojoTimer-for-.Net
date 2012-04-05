using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DojoTimer
{

    public class Task
    {
        public string Description { get; set; }
        public bool Done { get; set; }

        public Task(string description)
        {
            Description = description;
            Done = false;
        }
    }




}
