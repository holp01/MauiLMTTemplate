using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLMTTemplate.Services.Settings
{
    public class SettingsService : ISettingsService
    {
        private const string _Location = "location";
        private const string LocationDefault = "pt";

        public SettingsService()
        {
            
        }

        public string Location
        {
            get => Preferences.Get(_Location, LocationDefault);
            set => Preferences.Set(_Location, value);
        }
    }
}
