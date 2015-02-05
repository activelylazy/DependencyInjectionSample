using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp;
using PostSharp.Aspects;

namespace DependencyInjectionSample
{
    [Serializable]
    public class InjectDependencies : OnMethodBoundaryAspect
    {

        public override void OnEntry(MethodExecutionArgs args)
        {
            DependencyInjector.CurrentInjector.InjectDependencies(args.Instance);
            base.OnEntry(args);
        }
    }
}
