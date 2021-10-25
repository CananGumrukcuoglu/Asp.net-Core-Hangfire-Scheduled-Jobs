using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchedulerService.Data.HfModel
{
    public partial class Jobqueue
    {
        public int Id { get; set; }
        public int Jobid { get; set; }
        public string Queue { get; set; }
        public DateTime? Fetchedat { get; set; }
        public int Updatecount { get; set; }
    }
}
