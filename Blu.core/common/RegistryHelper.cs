using System;
using Microsoft.Win32;

namespace Blu.core.common
{
    public class RegistryHelper
    {
        private string _subKey = "SOFTWARE\\Blu";
        public string SubKey
        {
            get => _subKey;
            set => _subKey = value;
        }

        private RegistryKey _baseRegistryKey = Registry.LocalMachine;
        public RegistryKey BaseRegistryKey
        {
            get => _baseRegistryKey;
            set => _baseRegistryKey = value;
        }

        public string ReadRegistryKey(string keyName)
        {
            RegistryKey rk = _baseRegistryKey;
            RegistryKey sk1 = rk.OpenSubKey(_subKey);
            if (sk1 == null)
            {
                return null;
            }
            try
            {
                return (string)sk1.GetValue(keyName);
            }
            catch (Exception ex)
            {
                Logger.log("error", "Error reading registry key " + keyName + " - " + ex.Message);
                return null;
            }
        }

        public bool WriteRegistryKey(string keyName, object value)
        {
            try
            {
                RegistryKey rk = _baseRegistryKey;
                RegistryKey sk1 = rk.CreateSubKey(_subKey);
                sk1?.SetValue(keyName, value);
                return true;
            }
            catch (Exception ex)
            {
                Logger.log("error", "Error writing registry key " + keyName + " - " + ex.Message);
                return false;
            }
        }

        public bool DeleteSubKeyTree()
        {
            try
            {
                RegistryKey rk = _baseRegistryKey;
                RegistryKey sk1 = rk.OpenSubKey(_subKey);
                if (sk1 != null) rk.DeleteSubKeyTree(_subKey);
                return true;
            }
            catch (Exception ex)
            {
                Logger.log("error", "Error deleting registry key " + _subKey + " - " + ex.Message);
                return false;
            }
        }
    }
}