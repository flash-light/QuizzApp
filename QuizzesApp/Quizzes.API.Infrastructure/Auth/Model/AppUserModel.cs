using Microsoft.AspNetCore.Identity;

namespace Quizzes.API.Infrastructure.Auth.Model
{
    public class AppUserModel: IdentityUser<int>
    {
        public int User_Id { get; set; }
    }
}
