using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchedulerService.Data.HfModel
{
    public partial class User
    {
        public int IdUser { get; set; }
        public string DsName { get; set; }
        public string DsSurname { get; set; }
        public string DsEmail { get; set; }
        public string DsPhone { get; set; }
        public string DsPassword { get; set; }
        public bool FlActive { get; set; }
        public bool FlDeleted { get; set; }
        public DateTime DtBirthday { get; set; }
        public DateTime DtLastLogin { get; set; }
        public bool FlValidated { get; set; }
    }
}
