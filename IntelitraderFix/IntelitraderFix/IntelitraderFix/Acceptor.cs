using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using QuickFix.FIX44;
using QuickFix;
using QuickFix.Fields;

namespace IntelitraderFix
{
    public class Acceptor : MessageCracker, IApplication
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static readonly decimal DEFAULT_MARKET_PRICE = 10;

        public void OnMessage(QuickFix.FIX44.NewOrderSingle n, SessionID s)
        {
            Symbol symbol = n.Symbol;
            Side side = n.Side;
            OrdType ordType = n.OrdType;
            OrderQty orderQty = n.OrderQty;
            Price price = new Price(DEFAULT_MARKET_PRICE);
            ClOrdID clOrdID = n.ClOrdID;

            var ordTypes = new Dictionary<string, string>(){
                {"1", "market"},
                {"2", "limit"},
                {"3", "stop"}
            };

            var sideTypes = new Dictionary<string, string>(){
                {"1", "buy"},
                {"2", "sell"},
                {"8", "cross"}
            };

            log4net.LogicalThreadContext.Properties["sessionId"] = s;
            log4net.LogicalThreadContext.Properties["symbol"] = symbol.Obj;
            log4net.LogicalThreadContext.Properties["side"] = sideTypes[side.Obj.ToString()];
            log4net.LogicalThreadContext.Properties["ordType"] = ordTypes[ordType.Obj.ToString()];
            log4net.LogicalThreadContext.Properties["ordQty"] = orderQty.Obj;
            log4net.LogicalThreadContext.Properties["price"] = price.Obj;
            log4net.LogicalThreadContext.Properties["clOrdID"] = clOrdID.Obj;

            log.Info("New Single Order!");
        }

        public void FromApp(Message message, SessionID sessionID)
        {
            Crack(message, sessionID);
        }


        public void ToApp(Message message, SessionID sessionID)
        {
            Console.WriteLine("FROMAPP OUT: " + message);
        }

        public void FromAdmin(Message message, SessionID sessionID) { }
        public void ToAdmin(Message message, SessionID sessionID) { }
        public void OnCreate(SessionID sessionID) { }
        public void OnLogout(SessionID sessionID)
        {
            Console.WriteLine("Disconnected: " + sessionID);
        }
        public void OnLogon(SessionID sessionID)
        {
            Console.WriteLine("New Connection: " + sessionID);
        }

    }
}