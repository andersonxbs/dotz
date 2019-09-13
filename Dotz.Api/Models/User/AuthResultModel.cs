namespace Dotz.Api.Models.User
{
    public class AuthResultModel
    {
        public UserModel User { get; set; }

        public string Token { get; set; }
    }
}
