using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        
        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string ProfilePictureURL { get; set; }
        
        [Required(ErrorMessage = "Full Name is required")]
        [Display(Name = "Full Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Full Name must be between 3 to 50 characters.")]
        public string FullName { get; set; }
        
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]
        [StringLength(500, MinimumLength = 25, ErrorMessage = "Biography must be between 25 to 500 characters.")]
        public string Bio { get; set; }

        //Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }
    }
}
