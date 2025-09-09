namespace TaskManagementDomain.Entities
{
    public class TaskItem
    {

        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public TasksStatus Status { get; set; } = TasksStatus.Todo;
        public DateTime DueDate { get; set; }

        public int AssignedToUserId { get; set; }

        [JsonIgnore]
        public User AssignedToUser { get; set; } = null!;

        public int CreatedByUserId { get; set; }

        [JsonIgnore]
        public User CreatedByUser { get; set; } = null!;

        public int TeamId { get; set; }
        public Team Team { get; set; } = null!;


    }
}
