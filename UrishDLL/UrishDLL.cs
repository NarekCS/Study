using MEFdlls;
using System;
using System.Composition;

namespace UrishDLL
{
    [Export(typeof(IMessageSender))]
    public class EmailSender : IMessageSender
    {
        public void Send(string message)
        {
            Console.WriteLine("Es el urish " + message);
        }
    }
}
