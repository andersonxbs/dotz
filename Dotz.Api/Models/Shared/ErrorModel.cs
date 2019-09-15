namespace Dotz.Api.Models.Shared
{
    public class ErrorModel
    {
        public ErrorModel(string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
                Description = message;
        }

        public string Description { get; }
    }
}
