using CodeChallenge1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge1.Models.Entities
{
    public class Cup
    {
        public Cup()
        {

        }

        public Cup(CupAddVM src)
        {
            HasBall = src.HasBall;
        }

        public Cup(char id, bool hasball)
        {
            Id = id;
            HasBall = hasball;
        }

        // Using int for Id tag, there are only ever 3 cups
        [Key]
        public char Id { get; set; }

        // Boolean for whether cup has the ball or not
        [Required]
        public Boolean HasBall { get; set; } = false;
    }
}
