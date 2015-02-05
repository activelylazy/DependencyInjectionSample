using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionSample
{
    class User : IRequireAuthService
    {
        public IAuthService AuthService { set; private get; }

        public string Id { get; private set; }

        [InjectDependencies]
        public User(string id)
        {
            Id = id;
        }

        public IList<string> Groups
        {
            get { return AuthService.GetGroups(Id); }
        }
    }
}
