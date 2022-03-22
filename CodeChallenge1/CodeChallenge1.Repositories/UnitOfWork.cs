using CodeChallenge1.Repositories.Repositories;
using CodeChallenge1.Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge1.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        public ICupRepository Cups { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Cups = new CupRepository(context);
        }

        // Saving to database
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
