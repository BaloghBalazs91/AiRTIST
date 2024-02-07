using System.ComponentModel.DataAnnotations;

namespace AiRTIST.Contracts;

public record SetRoleRequest([Required] string UserName, [Required] string Role);
