using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchedulerService.Data.Core
{
    public abstract class BaseEntity
    {
        [Column("id_user_create")]
        public int IdUserCreate { get; set; }
        [Column("dt_create")]
        public DateTime DtCreate { get; set; }
        [Column("id_user_update")]
        public int IdUserUpdate { get; set; }
        [Column("dt_update")]
        public DateTime DtUpdate { get; set; }
    }
}