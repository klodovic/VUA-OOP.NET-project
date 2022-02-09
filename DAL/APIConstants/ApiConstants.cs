using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.APIConstants
{
    public class ApiConstants
    {
        public const char DEL = '|';

        public const string HR = "hr";
        public const string EN = "en";
        public const string MEN = "men";
        public const string WOMEN = "women";

        public const string FAVTEAM_MEN = @"../../TextFiles/favTeamMen.txt";
        public const string FAVPLAYERS_MEN = @"../../TextFiles/favPlayersMen.txt";

        public const string FAVTEAM_WOMEN = @"../../TextFiles/favTeamWoman.txt";
        public const string FAVPLAYERS_WOMEN = @"../../TextFiles/favPlayersWoman.txt";

        public const string PREF_LANG = @"../../TextFiles/pref_lang.txt";
        public const string PREF_CUP = @"../../TextFiles/pref_cup.txt";


        public const string PREF_RESOLUTION = @"../../TextFiles/resolution.txt";
        public const string PREF_LANG_WPF = @"\Socker\TextFiles\pref_lang.txt";
        public const string PREF_CUP_WPF = @"\Socker\TextFiles\pref_cup.txt";
        public const string FAVTEAM_MEN_WPF = @"\Socker\TextFiles\favTeamMen.txt";
        public const string FAVTEAM_WOMEN_WPF = @"\Socker\TextFiles\favTeamWoman.txt";

        public const string PLAYERS_IMAGES = @"Players_images";
        public const string PLAYERS_IMAGES_WPF = @"\Socker\bin\Debug\Players_images";


        public const string DEFAULT_WOMEN_IMAGE = @"../../Image/female_player.png";
    }
}
