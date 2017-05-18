using System;

namespace Blu.core.contracts
{
    public interface IChefConfig
    {
        Uri OrganizationUri { get; set; }
        string Organization { get; set; }
        string ClientName { get; set; }
        string NodeName { get; set; }
        string Validator { get; set; }
        string ValidationKey { get; set; }
        string ClientPath { get; set; }
        string ClientRb { get; set; }
        string ClientPem { get; set; }
        string DevPath { get; set; }

        // TODO: stop using void :) 
        void Load();
        void Load(string regKey);
        void Save();
        void Save(string regKey);
    }
}
