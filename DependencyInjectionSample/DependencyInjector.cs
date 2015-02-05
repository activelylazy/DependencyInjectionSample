using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DependencyInjectionSample
{
    class DependencyInjector : IDependencyInjector
    {
        private static ThreadLocal<IDependencyInjector> _currentInjector = new ThreadLocal<IDependencyInjector>();

        public static IDependencyInjector CurrentInjector
        {
            get 
            {
                if (!_currentInjector.IsValueCreated)
                    throw new Exception("No dependency injector configured on current thread");
                return _currentInjector.Value; 
            }
        }

        public IAuthService AuthService { get; set; }

        public DependencyInjector()
        {
            _currentInjector.Value = this;
        }

        public void InjectDependencies(object instance)
        {
            if (instance is IRequireAuthService)
                ((IRequireAuthService)instance).AuthService = AuthService;
        }
    }
}
