using System;
using System.IO;
using System.Reflection;
using Blu.core.contracts;

namespace Blu.api.chef
{
    public class ChefConfig :
    {
        public Uri    OrganizationUri  { get; set; }
        public string Organization     { get; set; }
        public string ClientName       { get; set; }
        public string NodeName         { get; set; }
        public string Validator        { get; set; }
        public string ValidationKey    { get; set; }
        public string ClientPath       { get; set; }
        public string ClientRb         { get; set; }
        public string ClientPem        { get; set; }
        public string DevPath          { get; set; }

        public ChefConfig()
        {
            ValidationKey = "UNSET";
            ClientPem     = "UNSET";
            DevPath       = "UNSET";
        }

        // This has to go into Nlog
        public  bool   ApiLog = true;


        public  static string[] CookbookStructure =
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

        public  static string[] KnownAttributeNames =
        {
        "node",
        "default",
        "override"
        };

        public static string BluLogo = @"

          __          __    __     
          \ \        / /_  / /_  __
           \ \      / __ \/ / / / /
            \ \    / /_/ / / /_/ / 
             \_\  /_.___/_/\__,_/  
        ═══════════════════════════════";

        public void Load()
        {
            throw new NotImplementedException();
        }

        public void Load(string regKey)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Save(string regKey)
        {
            throw new NotImplementedException();
        }
    }
  
    
}
