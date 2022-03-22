using CodeChallenge1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge1.Services.Services.Interfaces
{
    public interface ICupService
    {
        Task<List<CupVM>> Setup();
        Task<List<CupVM>> Swap(CupVM start, CupVM end);
        Task<CupVM> GetById(char id);
    }
}
