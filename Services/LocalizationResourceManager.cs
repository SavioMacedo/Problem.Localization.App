using Problem.Localization.Resources.Languages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.Localization.Services
{
    public class LocalizationResourceManager : INotifyPropertyChanged
    {
        private LocalizationResourceManager()
        {
            AppStrings.Culture = new CultureInfo(SettingsService.CultureInfo);
        }

        public static LocalizationResourceManager Instance { get; } = new();

        public object this[string resourceKey] =>
            AppStrings.ResourceManager.GetObject(resourceKey, AppStrings.Culture) ?? Array.Empty<byte>();

        public event PropertyChangedEventHandler PropertyChanged;

        public void SetCulture(CultureInfo culture)
        {
            AppStrings.Culture = culture;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}
