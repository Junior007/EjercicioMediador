using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.TestBusInstance
{
    internal class MyHandler : IHandler
    {
        public void Handle<M, D>(M message)
            where M : IMessage<D>
            where D : IData
        {
                MyMessage myMessage = message as MyMessage;
                MyData myData = myMessage.Data as MyData;

        }
    }
}
