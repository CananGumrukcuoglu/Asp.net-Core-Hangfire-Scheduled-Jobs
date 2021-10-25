using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchedulerService.Data.Model
{
    [Table("user")]
    public class User
    {
        #region Public Properties
        [Key]
        [Column("id_user")]
        public int IdUser { get; set; }
        [Column("id_user_create")]
        public int IdUserCreate { get; set; }
        [Column("dt_create")]
        public DateTime DtCreate { get; set; }
        [Column("id_user_update")]
        public int IdUserUpdate { get; set; }
        [Column("dt_update")]
        public DateTime DtUpdate { get; set; }
        [Column("ds_name")]
        public string DsName { get; set; }
        [Column("ds_surname")]
        public string DsSurname { get; set; }
        [Column("ds_email")]
        public string DsEmail { get; set; }
        [Column("ds_phone")]
        public string DsPhone { get; set; }
        [Column("ds_password")]
        public string DsPassword { get; set; }
        [Column("fl_active")]
        public bool FlActive { get; set; }
        [Column("fl_deleted")]
        public bool FlDeleted { get; set; }
        [Column("dt_birthday")]
        public DateTime DtBirthday { get; set; }
        [Column("dt_last_login")]
        public DateTime DtLastLogin { get; set; }
        [Column("fl_validated")]
        public bool FlValidated { get; set; }
        #endregion
        
    }
}