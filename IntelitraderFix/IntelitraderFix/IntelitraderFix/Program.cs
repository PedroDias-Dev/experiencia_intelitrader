using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickFix;
using QuickFix.Transport;
using log4net;
using log4net.Config;

namespace IntelitraderFix
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [STAThread]
        static void Main(string[] args)
        {

            Console.WriteLine("ACCEPTOR");
            Console.WriteLine("TargetCompID = 'SIMPLE' and SenderCompID = 'CLIENT1' or 'CLIENT2'.");
            Console.WriteLine("Running on Port 5001.");

            try
            {
                SessionSettings settings = new SessionSettings("../../../acceptor.cfg");
                IApplication app = new Acceptor();
                IMessageStoreFactory storeFactory = new FileStoreFactory(settings);
                ILogFactory logFactory = new FileLogFactory(settings);
                IAcceptor acceptor = new ThreadedSocketAcceptor(app, storeFactory, settings, logFactory);

                acceptor.Start();
                Console.Read();
                acceptor.Stop();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
