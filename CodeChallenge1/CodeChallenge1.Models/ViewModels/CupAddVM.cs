using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge1.Models.ViewModels
{
    public class CupAddVM
    {
        [Required]
        public Boolean HasBall { get; set; }
    }
}
