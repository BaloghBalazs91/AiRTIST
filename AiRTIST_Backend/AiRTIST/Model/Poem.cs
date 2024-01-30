using Microsoft.AspNetCore.Identity;

namespace AiRTIST.Model
{
    public class Poem
    {
        public int PoemId { get; set; }
        public string GeneratedPoet { get; set; }
        public string UserId { get; set; } // Foreign key
        public IdentityUser User { get; set; } // Navigation property
        public int Rating { get; set; }
        public int Views { get; set; }
        public DateTime CreatedAt { get; set; }

        public Poem(string generatedPoet, string userId)
        {
            Rating = 0;
            Views = 0;
            GeneratedPoet = generatedPoet;
            UserId = userId;
            CreatedAt = DateTime.Now;
        }
    }
}