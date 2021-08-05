using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickFix;
using QuickFix.Transport;

namespace IntelitraderFix
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("=============");
            Console.WriteLine("ACCEPTOR");
            Console.WriteLine("TargetCompID = 'SIMPLE' and SenderCompID = 'CLIENT1' or 'CLIENT2'.");
            Console.WriteLine("Port 5001.");
            Console.WriteLine("=============");

            try
            {
                SessionSettings settings = new SessionSettings("../../../sample_acceptor.cfg");
                IApplication app = new Acceptor();
                IMessageStoreFactory storeFactory = new FileStoreFactory(settings);
                ILogFactory logFactory = new FileLogFactory(settings);
                IAcceptor acceptor = new ThreadedSocketAcceptor(app, storeFactory, settings, logFactory);

                acceptor.Start();
                Console.WriteLine("press <enter> to quit");
                Console.Read();
                acceptor.Stop();
            }
            catch (System.Exception e)
            {
                Console.WriteLine("==FATAL ERROR==");
                Console.WriteLine(e.ToString());
            }
        }
    }
}
