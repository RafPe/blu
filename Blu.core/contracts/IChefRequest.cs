using System.Collections.Generic;
using Blu.core.enums;

namespace Blu.core.contracts
{
    public interface IChefRequest
    {
        Dictionary<string, string> XopsHeaders { get; set; }
        string body { get; set; }
        ChefRequestMethod method { get; set; }
    }
}
