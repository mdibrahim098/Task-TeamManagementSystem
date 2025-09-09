using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementDomain.Enums;

namespace TaskManagementApplication.Dtos
{
    public class TaskFilterDto
    {
        public int? AssignedToUserId { get; set; }
        public int? TeamId { get; set; }
        public TasksStatus? Status { get; set; }
        public DateTime? DueDateFrom { get; set; }
        public DateTime? DueDateTo { get; set; }


    }
}
