using System;
using System.IO;
using System.Collections.Generic;
using ReturnType = Blu.core.common.Function;

namespace Blu.core.common
{
    public class RubyHelper
    {
        public Function DictToClientRb(Dictionary<string, string> dict)
        {
            ReturnType rt = new ReturnType();
            try
            {
                StreamWriter sw = new StreamWriter(ChefConfig.ClientRb);
                foreach (var param in dict)
                {
                    sw.WriteLine("{0} {1}", param.Key, param.Value);
                    rt.Result = 0;
                    rt.Data = String.Empty;
                    rt.Object = null;
                    rt.Message = "client.rb is created.";
                }
                sw.Close();
                return rt;

            }
            catch (Exception ex)
            {
                rt.Result = 2;
                rt.Data = String.Empty;
                rt.Object = null;
                rt.Message = "Error writing client.rb file. Error: " + ex.Message;
                return rt;
            }
        }
    }
}
