using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLMTTemplate
{
    public static class Constants
    {
        //The Application or Client ID will be generated while registering the app in the Azure portal. Copy and paste the GUID.
        public static readonly string ClientId = "06844977-ca38-4b99-90f5-52e49c199176";

        //Leaving the scope to its default values.
        public static readonly string[] Scopes = new string[] { "openid", "offline_access" };
    }
}
