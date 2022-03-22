using CodeChallenge1.Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge1.Repositories
{
    public interface IUnitOfWork
    {
        // Repositories
        ICupRepository Cups { get; }

        // Save method
        Task SaveAsync();
    }
}
