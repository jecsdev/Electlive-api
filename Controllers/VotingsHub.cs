using ElectLive_API.Data.Model;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ElectLive_API.Controllers
{
    /// <summary>
    /// This class represents the WebSocket hub
    /// </summary>

    public class VotingsHub: Hub
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="voting">This is the model wich is refering the hub for connection</param>
        /// 
        /// <returns></returns>
        /// 

        private readonly ApplicationDbContext _dbContext;
        public VotingsHub(ApplicationDbContext dbContext)
        {
           _dbContext = dbContext;
        }

        public async Task GetDataFromDb()
        {
            var data = await _dbContext.Votings.ToListAsync();
            await Clients.All.SendAsync("Data", data);
        }
    }

       
    
}
