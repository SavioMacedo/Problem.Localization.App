using Problem.Localization.Resources.Languages;
using System.Globalization;

namespace Problem.Localization.Services
{
    public static class SettingsService
    {
        public static string CultureInfo
        {
            set
            {
                Preferences.Set("CultureInfo", value);
                AppStrings.Culture = new CultureInfo(value);
                Thread.CurrentThread.CurrentCulture = new(value);
                Thread.CurrentThread.CurrentUICulture = new(value);
                System.Globalization.CultureInfo.DefaultThreadCurrentCulture = new(value);
                System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = new(value);
            }
            get
            {
                var pref = Preferences.Get("CultureInfo", string.Empty);

                if (string.IsNullOrEmpty(pref))
                    return "en";
                else
                    return pref;
            }
        }
    }
}
