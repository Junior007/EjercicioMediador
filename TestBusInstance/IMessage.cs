﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.TestBusInstance
{
    internal interface IMessage<IData>
    {
        IData Data { get; }
    }
}
