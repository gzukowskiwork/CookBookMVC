using Models.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    public class Comment
    {
        public string Id { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public string Consent { get; set; }
        public int VotesUp { get; set; }
        public int VotesDown { get; set; }
        
        public string RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
