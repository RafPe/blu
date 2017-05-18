using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blu.core.enums;

namespace Blu.core.contracts
{
    public interface IChefApi
    {
        string Execute(ChefRequestMethod method, string client, string resource, string body);
    }
}
