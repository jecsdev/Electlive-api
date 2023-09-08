using ElectLive_API.Data.Model;
using Microsoft.EntityFrameworkCore;
namespace ElectLive_API.Repository
{
    // This class represents the repository for handling Voting entities in the application.
    public class ElecLiveRepository : IElecLiveRepository
    {
        private readonly ApplicationDbContext _dbContext;

        // Constructor that takes an instance of ApplicationDbContext to work with the database.
        public ElecLiveRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Method for adding a new Voting entity to the database.
        // It uses asynchronous operations for better performance.
        public async Task<Voting> AddOrUpdateVoting(Voting voting)
        {
            // Check if exists this entity.
            var existingVoting = await _dbContext.Votings.SingleOrDefaultAsync(vot => vot.VatId == voting.VatId);

            if (existingVoting != null)
            {
                // Update current properties with new properties.
                existingVoting.School = voting.School;
                existingVoting.Census = voting.Census;
                existingVoting.IsRegistered = true;
                existingVoting.Name = voting.Name;

                // Save changes into database.
                await _dbContext.SaveChangesAsync();

                // Return updated entity.
                return existingVoting;
            }
            else
            {
                // Add new entity to DbContext.
                var addedVoting = await _dbContext.Votings.AddAsync(voting);

                // Save changes into database.
                await _dbContext.SaveChangesAsync();

                // Return new entity.
                return addedVoting.Entity;
            }
        }

        // Method for retrieving a Voting entity by its ID from the database.
        // It uses asynchronous operations to avoid blocking the thread.
        public async Task<Voting> GetVoting(int votingId)
        {
            // Use FirstOrDefaultAsync to retrieve the first matching entity with the provided ID.
            return await _dbContext.Votings.FirstOrDefaultAsync(v => v.Id == votingId);
        }
    }
}

