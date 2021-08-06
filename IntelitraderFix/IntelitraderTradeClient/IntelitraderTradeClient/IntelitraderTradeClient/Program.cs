using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntelitraderTradeClient
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Fix TradeClient");

            try
            {
                QuickFix.SessionSettings settings = new QuickFix.SessionSettings("../../../tradeclient.cfg");
                TradeClientApp application = new TradeClientApp();
                QuickFix.IMessageStoreFactory storeFactory = new QuickFix.FileStoreFactory(settings);
                QuickFix.ILogFactory logFactory = new QuickFix.ScreenLogFactory(settings);
                QuickFix.Transport.SocketInitiator initiator = new QuickFix.Transport.SocketInitiator(application, storeFactory, settings, logFactory);

                application.MyInitiator = initiator;

                initiator.Start();
                application.Run();
                initiator.Stop();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            Environment.Exit(1);
        }
    }
}