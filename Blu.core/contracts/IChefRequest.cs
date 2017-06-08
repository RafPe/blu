using System.Collections.Generic;
using Blu.core.enums;

namespace Blu.core.contracts
{
    public interface IChefRequest
    {
        ChefRequestMethod ChefRequestMethod { get; set; }

        string SignMessage(ChefRequestMethod chefRequestMethod, IChefConfig chefConfig, string privateKey, string body_content_hash);

        Dictionary<string, string> CreateXopsMessage(string body, string resourceUri);
    }
}
