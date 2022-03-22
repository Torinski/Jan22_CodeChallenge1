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
        public async Task<CupVM> Create(CupAddVM src)
        {
            var newEntity = new Cup(src);

            // Have the repository create the new game
            _uow.Cups.Create(newEntity);
            await _uow.SaveAsync();

            // Create CupVM to return
            var model = new CupVM(newEntity);

            // Return the CupVM
            return model;
        }

        public async Task Delete(int id)
        {
            // Get the entity
            var result = await _uow.Cups.GetById(id);

            // Delete the requested cup entity
            _uow.Cups.Delete(result);
            await _uow.SaveAsync();
        }

        public async Task<List<CupVM>> GetAll()
        {
            // Get entity list
            var results = await _uow.Cups.GetAll();

            // Create CupVM from entity list
            var models = results.Select(item => new CupVM(item)).ToList();

            // Return CupVM list
            return models;
        }

        public async Task<CupVM> GetById(int id)
        {
            // Get entity with given id
            var result = await _uow.Cups.GetById(id);

            // Create CupVM from entity
            var model = new CupVM(result);

            // Return the CupVM
            return model;
        }

        public async Task<CupVM> Update(CupUpdateVM src)
        {
            // Get cup entity by id
            var entity = await _uow.Cups.GetById(src.Id);

            // Update the ball status
            entity.HasBall = src.HasBall;

            // Save updates
            _uow.Cups.Update(entity);
            await _uow.SaveAsync();

            // Make CupVM from entity
            var model = new CupVM(entity);

            // Return the CupVM
            return model;
        }
    }
}
