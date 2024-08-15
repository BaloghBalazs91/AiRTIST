namespace AiRTIST.Service.Authentication
{
    public record AuthenticationResult(
    bool Success,
    string Email,
    string UserName,
    string Token,
    string Id)
    {
        //Error code - error message
        public readonly Dictionary<string, string> ErrorMessages = new();
    }
}
