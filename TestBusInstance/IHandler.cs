using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.TestBusInstance
{
    internal interface IHandler 
    {
        void Handle<M, D>(M message) where D : IData where M : IMessage<D>;
    }
}
