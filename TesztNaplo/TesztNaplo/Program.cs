using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesztNaplo
{
    class Program
    {
        private static readonly ILog logger = LogManager.GetLogger("TesztNaplo.Program");

        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

        }
    }
}
