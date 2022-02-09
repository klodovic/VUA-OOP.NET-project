using DAL.CentralSavings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socker.Constants
{
    public class Const
    {
        public const string COUNTRYMEN = @"http://world-cup-json-2018.herokuapp.com/teams/results";
        public const string COUNTRYWOMEN = @"http://worldcup.sfg.io/teams/results";

        public const string MATCHMEN = @"http://world-cup-json-2018.herokuapp.com/matches/country?fifa_code=";
        public const string MATCHWOMEN = @"http://worldcup.sfg.io/matches/country?fifa_code=";

        public static string GetCountriesByGender()
        {
            if (AllSavings.settings.Gender == "men")
            {
                return COUNTRYMEN;
            }
            else
            {
                return COUNTRYWOMEN;
            }
        }

        public static string GetMatchesByGender()
        {
            if (AllSavings.settings.Gender == "men")
            {
                return MATCHMEN;
            }
            else
            {
                return MATCHWOMEN;
            }

        }
    }
}
