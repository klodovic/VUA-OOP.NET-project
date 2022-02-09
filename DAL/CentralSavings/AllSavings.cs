using DAL.Model;
using System.Globalization;
using System.Threading;

namespace DAL.CentralSavings
{
    public class AllSavings
    {

        public static Settings settings = new Settings();

        public static void SetCulture(string lang)
        {
            var culture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }
    }
}
