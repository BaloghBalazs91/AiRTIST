using System.ComponentModel.DataAnnotations;

namespace AiRTIST.Contracts;

public record RegistrationRequest([Required] string Email, [Required] string UserName, [Required] string Password);
