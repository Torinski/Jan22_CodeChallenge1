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
        Task<CupVM> Create(CupAddVM src);         // Create a new cup
        Task<CupVM> GetById(int id);              // Get cup by id
        Task<List<CupVM>> GetAll();               // Get all cups
        Task<CupVM> Update(CupUpdateVM entity);   // Update cup
        Task Delete(int id);                      // Delete cup
    }
}
