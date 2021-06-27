using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMaster.DataAccess.Models
{
    public class TaskForEmployee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        //public int ExecutorId { get; set; }
        public DateTime DeadLine { get; set; }

        
       
        public Employee Employee { get; set; }
        public bool Done { get; set; } = false;
        public bool Failed { get; set; } = false;
    }
}
