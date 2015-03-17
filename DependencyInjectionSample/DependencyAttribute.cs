using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using PostSharp.Aspects.Dependencies;

namespace DependencyInjectionSample
{
    [MulticastAttributeUsage(MulticastTargets.InstanceConstructor, TargetMemberAttributes=MulticastAttributes.Instance, Inheritance=MulticastInheritance.Multicast)]
    [ProvideAspectRole("Dependencies")]
    [AspectRoleDependency(AspectDependencyAction.Order, AspectDependencyPosition.After, "IoC")]
    [Serializable]
    class DependencyAttribute : OnMethodBoundaryAspect
    {
        public override bool CompileTimeValidate(System.Reflection.MethodBase method)
        {
            if (!method.CustomAttributes.Any(a => a.AttributeType == typeof(InjectDependenciesAttribute)))
            {
                Message.Write(SeverityType.Error, "InjectDependences", "No [InjectDependencies] declared on " + method.DeclaringType.FullName + "." + method.Name, method);
                return false;
            }
            return base.CompileTimeValidate(method);
        }
    }
}
