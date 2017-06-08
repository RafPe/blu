using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blu.api.chef;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 ** config 
            ChefConfig chefConfig = new ChefConfig();
            chefConfig.Load();




            ChefApi chefApi = new ChefApi();
        }
    }
}
