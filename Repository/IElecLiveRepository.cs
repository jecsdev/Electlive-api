using ElectLive_API.Data.Model;

namespace ElectLive_API.Repository
{
    // This interface defines the contract for the repository that handles Voting entities.
    public interface IElecLiveRepository
    {
        // Method for adding a new Voting entity to the repository.
        // It returns a Task representing the asynchronous operation.
        Task<Voting> AddVoting(Voting voting);

        // Method for retrieving a Voting entity by its ID from the repository.
        // It returns a Task representing the asynchronous operation.
        Task<Voting> GetVoting(int votingId);
    }
}

