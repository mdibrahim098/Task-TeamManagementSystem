

namespace TaskManagementInfrastructure.Repositories
{
    public  class CurrentUserService : ICurrentUserService
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int UserId => int.Parse(_httpContextAccessor.HttpContext?.User?.FindFirst("id")?.Value ?? "0");

        public UserRole Role => Enum.Parse<UserRole>(_httpContextAccessor.HttpContext?.User?.FindFirst("role")?.Value ?? "Employee");
    }

}
