using ElectLive_API.Data.Model;
using Microsoft.AspNetCore.SignalR;

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
        /// <returns></returns>
        public async Task Send(Voting voting)
        {
            await Clients.All.SendAsync("Recieve", voting);
        }
    }
}
