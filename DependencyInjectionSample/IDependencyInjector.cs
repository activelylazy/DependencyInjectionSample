﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionSample
{
    interface IDependencyInjector
    {
        void InjectDependencies(object instance);
    }
}
