using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TesztNaplo
{
    class Program
    {
        private static readonly ILog logger = LogManager.GetLogger("TesztNaplo.Program");

        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            //naplóírás 
            var r = new Random();

            Console.WriteLine("Megállításhoz egy gombot kell nyomni...");
            while (!Console.KeyAvailable)
            {
                var val = r.Next(100);

                if (val<60)
                {
                    logger.Debug("Ez egy debug");
                    Thread.Sleep(100);
                }
                else if (val < 80)
                {
                    logger.Info("Ez egy info");
                    Thread.Sleep(200);
                }
                else if (val < 90)
                {
                    logger.Warn("Warning");
                    Thread.Sleep(300);
                }
                else if (val < 97)
                {
                    logger.Error("Error");
                    Thread.Sleep(400);
                }
                else 
                {
                    logger.Fatal("Fatal");
                    Thread.Sleep(400);
                }
            }

            log4net.LogManager.Shutdown();

        }
    }
}
