using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp;
using PostSharp.Aspects;
using PostSharp.Aspects.Dependencies;

namespace DependencyInjectionSample
{
    [Serializable]
    [ProvideAspectRole("IoC")]
    public class InjectDependencies : OnMethodBoundaryAspect
    {

        public sealed override void OnEntry(MethodExecutionArgs args)
        {
            DependencyInjector.CurrentInjector.InjectDependencies(args.Instance);
            base.OnEntry(args);
        }
    }
}
