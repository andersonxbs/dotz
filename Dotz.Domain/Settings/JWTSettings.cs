namespace Dotz.Domain.Settings
{
    public class JWTSettings
    {
        public string Secret { get; set; }
        public int ExpiresInHours { get; set; }
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
    }
}
