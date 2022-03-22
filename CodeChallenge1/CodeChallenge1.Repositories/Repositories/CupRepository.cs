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

        public async Task<List<Cup>> Setup()
        {
            // Get current cup entities
            var oldCups = await _context.Cups.ToListAsync();
            // Delete all cups
            foreach (var cup in oldCups)
            {
                _context.Remove(cup);
            }

            // Initialize new cups
            List<Cup> newCups = new List<Cup>();

            Cup cupA = new Cup();
            Cup cupB = new Cup();
            Cup cupC = new Cup();

            cupB.HasBall = true;

            // Add cups to list
            newCups.Add(cupA);
            newCups.Add(cupB);
            newCups.Add(cupC);

            // Save cups in-memory
            _context.Add(newCups);

            // Return new cup list
            return newCups;

        }
        public async Task<List<Cup>> Swap(Cup start, Cup end)
        {
            // Get cup list
            var oldCups = await _context.Cups.ToListAsync();

            // Use temporary cup to swap ball status of given cups
            Cup tempCup = new Cup();

            tempCup.HasBall = end.HasBall;
            end.HasBall = start.HasBall;
            start.HasBall = tempCup.HasBall;

            // Update new cup statuses
            foreach (var cup in oldCups)
            {
                _context.Update(cup);
            }

            // Return updated cup list
            return oldCups;
        }
        public async Task<Cup> GetById(int id)
        {
            // Get the entity
            var result = await _context.Cups.FirstAsync(cup => cup.Id == id);

            // Return the result
            return result;
        }
        public void Update(Cup entity)
        {
            // Update the entity
            _context.Update(entity);
        }
    }
}
