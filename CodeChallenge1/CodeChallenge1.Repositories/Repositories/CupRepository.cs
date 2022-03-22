using CodeChallenge1.Models.Entities;
using CodeChallenge1.Repositories.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge1.Repositories.Repositories
{
    public class CupRepository : ICupRepository
    {
        private readonly ApplicationDbContext _context;

        public CupRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Cup entity)
        {
            // Perform the add in-memory
            _context.Add(entity);
        }

        public async Task<Cup> GetById(int id)
        {
            // Get the entity
            var result = await _context.Cups.FirstAsync(cup => cup.Id == id);

            // Return the result
            return result;
        }

        public async Task<List<Cup>> GetAll()
        {
            // Get all entities
            var results = await _context.Cups.ToListAsync();

            // Return the results
            return results;
        }
        public void Update(Cup entity)
        {
            // Update the entity
            _context.Update(entity);
        }
        public void Delete(Cup entity)
        {
            // Delete the entity
            _context.Remove(entity);
        }
    }
}
