using System;
using System.Collections.Generic;
using System.Text;

namespace Blu.api.chef
{
    public class ChefConfigurator
    {
        /// <summary>
        /// Saves Blu configuration to registry HKLM\\Software\\Blu\\Config
        /// </summary>
        /// <returns></returns>
        public Function SaveConfig()
        {
            ReturnType rt = new ReturnType();
            RegistryHelper rh = new RegistryHelper { SubKey = "SOFTWARE\\Blu\\Config" };

            try
            {
                rh.Write("OrganizationUri", ChefConfig.OrganizationUri.ToString());
                rh.Write("Organization", ChefConfig.Organization);
                rh.Write("ClientName", ChefConfig.ClientName);
                rh.Write("NodeName", ChefConfig.NodeName);
                rh.Write("Validator", ChefConfig.Validator);
                rh.Write("ValidationKey", ChefConfig.ValidationKey);
                rh.Write("ClientPath", ChefConfig.ClientPath);
                rh.Write("ClientRb", ChefConfig.ClientName);
                rh.Write("ClientPem", ChefConfig.ClientPem);
                rh.Write("DevPath", ChefConfig.DevPath);

                rt.Result = 0;
                rt.Data = String.Empty;
                rt.Object = null;
                rt.Message = "Configuration is saved to HKLM\\Software\\BluApi\\Config";
            }
            catch (Exception ex)
            {
                rt.Result = 3;
                rt.Data = String.Empty;
                rt.Object = null;
                rt.Message = "Unable to save configuration to registry. Error: " + ex.Message;
            }
            return rt;
        }

        /// <summary>
        /// Loads Blu configuration from registry HKLM\\Software\\Blu\\Config
        /// </summary>
        /// <returns></returns>
        public Function LoadConfig()
        {
            ReturnType rt = new ReturnType();
            RegistryHelper rh = new RegistryHelper { SubKey = "SOFTWARE\\Blu\\Config" };

            try
            {
                ChefConfig.OrganizationUri = new Uri(rh.Read("OrganizationUri"));
                ChefConfig.Organization = rh.Read("Organization");
                ChefConfig.ClientName = rh.Read("ClientName");
                ChefConfig.NodeName = rh.Read("NodeName");
                ChefConfig.Validator = rh.Read("Validator");
                ChefConfig.ValidationKey = rh.Read("ValidationKey");
                ChefConfig.ClientPath = rh.Read("ClientPath");
                ChefConfig.ClientRb = rh.Read("ClientRb");
                ChefConfig.ClientPem = rh.Read("ClientPem");
                ChefConfig.DevPath = rh.Read("DevPath");

                rt.Result = 0;
                rt.Data = String.Empty;
                rt.Object = null;
                rt.Message = "Configuration is loaded from HKLM\\Software\\BluApi\\Config";
            }
            catch (Exception ex)
            {
                rt.Result = 3;
                rt.Data = String.Empty;
                rt.Object = null;
                rt.Message = "Unable to load configuration from registry. Error: " + ex.Message;
            }
            return rt;
        }
    }
}
