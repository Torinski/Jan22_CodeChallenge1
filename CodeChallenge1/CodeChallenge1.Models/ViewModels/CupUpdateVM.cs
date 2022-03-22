using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge1.Models.ViewModels
{
    public class CupUpdateVM
    {
        [Required]
        public char Id { get; set; }

        [Required]
        public Boolean HasBall { get; set; }
    }
}
