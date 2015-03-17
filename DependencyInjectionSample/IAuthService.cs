using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionSample
{
    public interface IAuthService
    {
        IList<string> GetGroups(string userId);
    }

    [Dependency]
    public interface IRequireAuthService
    {
        IAuthService AuthService { set; }
    }
}
