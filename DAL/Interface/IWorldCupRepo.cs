using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IWorldCupRepo
    {
        Task<List<Countries>> GetAllCountriesAsync(string country);
        Task<List<SoccerMatch>> GetAllTeamPlayersAsync(string fifa_code);
        Task<List<SoccerMatch>> GetStat(string fifa_code);
    }
}
