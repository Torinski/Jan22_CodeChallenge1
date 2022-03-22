using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge1.Models.ViewModels
{
    public class CupVM
    {
        public CupVM()
        {

        }

        public CupVM(Entities.Cup src)
        {
            Id = src.Id;
            HasBall = src.HasBall;
        }

        public char Id { get; set; }
        public Boolean HasBall { get; set; }
    }
}
