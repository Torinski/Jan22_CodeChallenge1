using CodeChallenge1.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge1.Repositories.Repositories.Interfaces
{
    public interface ICupRepository
    {
        Task<List<Cup>> Setup();
        Task<List<Cup>> Swap(Cup start, Cup end);
        Task<Cup> GetById(char id);
        void Update(Cup entity);
    }
}
