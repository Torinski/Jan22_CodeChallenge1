using CodeChallenge1.Models.Entities;
using CodeChallenge1.Models.ViewModels;
using CodeChallenge1.Repositories;
using CodeChallenge1.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge1.Services.Services
{
    public class CupService : ICupService
    {
        private readonly IUnitOfWork _uow;

        public CupService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<CupVM>> Setup()
        {
            // Run setup routine for cups and save changes
            var results = await _uow.Cups.Setup();
            await _uow.SaveAsync();

            // Create list of CupVMs
            var models = results.Select(item => new CupVM(item)).ToList();

            // Return CupVM list
            return models;
        }
        public async Task<List<CupVM>> Swap(CupVM start, CupVM end)
        {
            // Get start cup entity by id
            var cup1 = await _uow.Cups.GetById(start.CupId);

            // Update the ball status of start cup
            cup1.HasBall = start.HasBall;

            // Get end cup entity by id
            var cup2 = await _uow.Cups.GetById(end.CupId);

            // Update the ball status of end cup
            cup2.HasBall = end.HasBall;

            // Save updates
            _uow.Cups.Update(cup1);
            _uow.Cups.Update(cup2);

            await _uow.SaveAsync();

            // Make CupVMs from entities
            var models = new List<CupVM>();
            models.Add(new CupVM(cup1));
            models.Add(new CupVM(cup2));

            // Return the CupVM list
            return models;
        }

        public async Task<CupVM> GetById(char id)
        {
            // Get entity with given id
            var result = await _uow.Cups.GetById(id);

            // Create CupVM from entity
            var model = new CupVM(result);

            // Return the CupVM
            return model;
        }

    }
}
