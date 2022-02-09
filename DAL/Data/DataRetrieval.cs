using DAL.Interface;
using DAL.Model;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class DataRetrieval : IWorldCupRepo
    {
        public Task<List<Countries>> GetAllCountriesAsync(string country)
        {
            return Task.Run(() =>
            {
                var apiClient = new RestClient(country);
                var result = apiClient.Execute<List<Countries>>(new RestRequest());
                return JsonConvert.DeserializeObject<List<Countries>>(result.Content);
            });
        }

        public Task<List<SoccerMatch>> GetAllTeamPlayersAsync(string fifa_code)
        {
            return Task.Run(() =>
            {
                var apiClient = new RestClient(fifa_code);
                var result = apiClient.Execute<List<SoccerMatch>>(new RestRequest());
                return JsonConvert.DeserializeObject<List<SoccerMatch>>(result.Content);
            });
        }

        public Task<List<SoccerMatch>> GetStat(string fifa_code)
        {
            return Task.Run(() =>
            {
                var apiClient = new RestClient(fifa_code);
                var result = apiClient.Execute<List<SoccerMatch>>(new RestRequest());
                return JsonConvert.DeserializeObject<List<SoccerMatch>>(result.Content);
            });
        }
    }
}
