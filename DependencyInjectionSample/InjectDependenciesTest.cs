using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFirst.Net;
using TestFirst.Net.Matcher;
using TestFirst.Net.Extensions.Moq;
using NUnit.Framework;

namespace DependencyInjectionSample
{
    [TestFixture]
    public class InjectDependenciesTest : AbstractNUnitMoqScenarioTest
    {
        [Test]
        public void InjectsDependencies()
        {
            User user;
            IAuthService authService;

            Scenario()
                .Given(authService = AMock<IAuthService>()
                    .WhereMethod(svc => svc.GetGroups("Mary")).Returns(new[] { "users", "administrators" })
                    .Instance)
                .Given(new DependencyInjector
                {
                    AuthService = authService,
                })
                .Given(user = new User("Mary"))

                .Then(user.Groups, Is(AList.InOrder().WithOnly(
                    AString.EqualTo("users"),
                    AString.EqualTo("administrators")
                )));
            ;
        }
    }
}
