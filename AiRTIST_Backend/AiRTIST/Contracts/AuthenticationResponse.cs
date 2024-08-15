namespace AiRTIST.Contracts
{
    public record AuthenticationResponse(string Email, string UserName, string Token, string Id);
}