using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLMTTemplate.Models.AppSettings
{
    public class AuthenticationConfig
    {
        public string ClientId { get; set; }
        public string[] Scopes { get; set; }
    }

}
