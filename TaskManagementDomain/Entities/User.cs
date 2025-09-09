

namespace TaskManagementDomain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserRole Role { get; set; }

        [JsonIgnore]
        public ICollection<TaskItem> AssignedTasks { get; set; } = new List<TaskItem>();

        [JsonIgnore]
        public ICollection<TaskItem> CreatedTasks { get; set; } = new List<TaskItem>();
    }


}
