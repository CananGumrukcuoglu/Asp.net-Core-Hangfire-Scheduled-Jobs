using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchedulerService.Data.HfModel
{
    public partial class Job
    {
        public Job()
        {
            Jobparameter = new HashSet<Jobparameter>();
            State = new HashSet<State>();
        }

        public int Id { get; set; }
        public int? Stateid { get; set; }
        public string Statename { get; set; }
        public string Invocationdata { get; set; }
        public string Arguments { get; set; }
        public DateTime Createdat { get; set; }
        public DateTime? Expireat { get; set; }
        public int Updatecount { get; set; }

        public virtual ICollection<Jobparameter> Jobparameter { get; set; }
        public virtual ICollection<State> State { get; set; }
    }
}
