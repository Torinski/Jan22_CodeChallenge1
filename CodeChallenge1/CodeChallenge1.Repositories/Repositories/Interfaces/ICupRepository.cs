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
        void Create(Cup entity);
        Task<Cup> GetById(int id);
        Task<List<Cup>> GetAll();
        void Update(Cup entity);
        void Delete(Cup entity);
    }
}
