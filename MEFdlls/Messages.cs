using System;
using System.Composition;

namespace MEFdlls
{
    public interface IMessageSender
    {
        void Send(string message);
    }
    public class Messages
    {
        [Export(typeof(IMessageSender))]
        public class EmailSender : IMessageSender
        {
            public void Send(string message)
            {
                Console.WriteLine(message);
            }
        }
    }
}
