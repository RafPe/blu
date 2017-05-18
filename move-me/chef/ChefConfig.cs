using System;
using System.IO;
using System.Reflection;

namespace Blu.api.chef
{
    public static class ChefConfig
    {
        /// <summary>
        /// Root is Assembly Location.
        /// </summary>
        public static string Root = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        /// <summary>
        /// URI of the Chef organization.
        /// </summary>
        public static Uri OrganizationUri = new Uri("https://organizationUri_is_undefined");
        
        /// <summary>
        /// Chef organization name.
        /// </summary>
        public static string Organization = "";

        /// <summary>
        /// Name of the Chef client.
        /// </summary>
        public static string ClientName = "";
        
        /// <summary>
        /// Name of the Chef node.
        /// </summary>
        public static string NodeName = "";
        
        /// <summary>
        /// The Chef validator.
        /// </summary>
        public static string Validator = "";
        
        /// <summary>
        /// The validation key.
        /// </summary>
        public static string ValidationKey = "UNSET";

        /// <summary>
        /// Absolute path of the client directory (normally the current directory).
        /// </summary>
        public static string ClientPath = "";

        /// <summary>
        /// Absolute path of the client.rb file.
        /// </summary>
        public static string ClientRb = "";

        /// <summary>
        /// Absolute path of the client.pem file.
        /// </summary>
        public static string ClientPem = "UNSET";

        /// <summary>
        /// Determines if we log API messages.
        /// </summary>
        public static bool ApiLog = true;

        /// <summary>
        /// Absolute path to the cookbook development folder.
        /// </summary>
        public static string DevPath = "UNSET";

        /// <summary>
        /// The cookbook structure. Subject to update when this sturcture changes by Chef community.
        /// </summary>
        public static string[] CookbookStructure =
        {
        "recipes",
        "definitions",
        "libraries",
        "attributes",
        "files",
        "templates",
        "resources",
        "providers",
        "root_files"
        };

        /// <summary>
        /// Know Chef attributes names
        /// </summary>
        public static string[] KnownAttributeNames =
        {
        "node",
        "default",
        "override"
        };

        /// <summary>
        /// Logo in ascii art format
        /// </summary>
        public static string BluLogo = @"

  __          __    __     
  \ \        / /_  / /_  __
   \ \      / __ \/ / / / /
    \ \    / /_/ / / /_/ / 
     \_\  /_.___/_/\__,_/  
═══════════════════════════════";

    }
  
    
}
