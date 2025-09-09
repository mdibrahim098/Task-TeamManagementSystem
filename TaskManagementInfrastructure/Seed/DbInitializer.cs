namespace TaskManagementInfrastructure.Seed
{
    public class DbInitializer
    {


        public static void Initialize(AppDbContext db)
        {
            // Apply migrations
            db.Database.Migrate();

            // Seed demo data only if tables are empty
            if (!db.Users.Any() && !db.Teams.Any() && !db.Tasks.Any())
            {
                // Users
                var admin = new User { FullName = "Admin User", Email = "admin@example.com", Role = TaskManagementDomain.Enums.UserRole.Admin };
                var manager = new User { FullName = "Manager User", Email = "manager@example.com", Role = TaskManagementDomain.Enums.UserRole.Manager };
                var employee = new User { FullName = "Employee User", Email = "employee@example.com", Role = TaskManagementDomain.Enums.UserRole.Employee };

                db.Users.AddRange(admin, manager, employee);

                // Teams
                var devTeam = new Team { Name = "Development", Description = "Dev team" };
                var marketingTeam = new Team { Name = "Marketing", Description = "Marketing team" };

                db.Teams.AddRange(devTeam, marketingTeam);

                db.SaveChanges(); // Save to generate IDs

                // Tasks
                var task1 = new TaskItem
                {
                    Description = "Initial Dev Task",
                    Status = TaskManagementDomain.Enums.TasksStatus.Todo,
                    AssignedToUserId = employee.Id,
                    CreatedByUserId = admin.Id,
                    TeamId = devTeam.Id
                };

                var task2 = new TaskItem
                {
                    Description = "Marketing Kickoff",
                    Status = TaskManagementDomain.Enums.TasksStatus.InProgress,
                    AssignedToUserId = manager.Id,
                    CreatedByUserId = admin.Id,
                    TeamId = marketingTeam.Id
                };

                db.Tasks.AddRange(task1, task2);
                db.SaveChanges();
            }
        }



    }
}
