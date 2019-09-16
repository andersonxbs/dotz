namespace Dotz.Domain.Transients
{
    public class OperationResult
    {
        public bool Succeeded => string.IsNullOrWhiteSpace(ErrorDescription);

        public string ErrorDescription { get; internal set; }
    }
}
