using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLMTTemplate.Services.Settings
{
    public interface ISettingsService
    {
        string Location { get; set; }
    }
}
