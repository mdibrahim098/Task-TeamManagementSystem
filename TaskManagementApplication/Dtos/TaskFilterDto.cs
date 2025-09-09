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


        // Pagination
        public int PageNumber { get; set; } = 1; // default first page
        public int PageSize { get; set; } = 10;  // default 10 items per page

        // Sorting
        public string? SortBy { get; set; } = "Id";       // default sort column
        public string SortDirection { get; set; } = "asc"; // "asc" or "desc"


    }
}
