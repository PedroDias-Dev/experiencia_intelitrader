using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QuickFix;
using QuickFix.Fields;

namespace IntelitraderFix
{
    public class Acceptor : IApplication
    {
        #region QuickFix.Application Methods

        public void FromApp(Message message, SessionID sessionID)
        {
            Console.WriteLine("FROMAPP IN:  " + message);
            //Crack(message, sessionID);
        }

        public void ToApp(Message message, SessionID sessionID)
        {
            Console.WriteLine("FROMAPP OUT: " + message);
        }

        public void FromAdmin(Message message, SessionID sessionID)
        {
            Console.WriteLine("FROMADMIN IN:  " + message);
        }

        public void ToAdmin(Message message, SessionID sessionID)
        {
            Console.WriteLine("FROMADMIN OUT:  " + message);
        }

        public void OnCreate(SessionID sessionID) { }
        public void OnLogout(SessionID sessionID) { }
        public void OnLogon(SessionID sessionID) { }
        #endregion
    }
}