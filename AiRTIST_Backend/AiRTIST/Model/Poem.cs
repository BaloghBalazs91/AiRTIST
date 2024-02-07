using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace AiRTIST.Model
{
    public class Poem
    {
        public int PoemId { get; set; }
        public string GeneratedPoem { get; set; }
        public string UserId { get; set; }
        public int Rating { get; set; }
        public int Views { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation property for the related User
        public IdentityUser User { get; set; }

        public Poem(string generatedPoem, string userId)
        {
            Rating = 0;
            Views = 0;
            GeneratedPoem = generatedPoem;
            UserId = userId;
            CreatedAt = DateTime.Now.ToUniversalTime();
        }
    }
}