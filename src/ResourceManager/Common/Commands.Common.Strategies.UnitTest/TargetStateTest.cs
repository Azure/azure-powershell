using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.Threading;
using Xunit;

namespace Microsoft.Azure.Commands.Common.Strategies.UnitTest
{
    public class TargetStateTest
    {
        class Client : ServiceClient<Client>, IClient
        {
            public T GetClient<T>() where T : ServiceClient<T>
                => this as T;
        }

        class Model
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Test()
        {
            var strategy = ResourceStrategy.Create<Model, Client, Client>(
                new ResourceType("ns", "p"),
                c => "1.0",
                c => c,
                async (c, m) => new Model(),
                async (c, m) => new Model(),
                m => "eastus",
                (m, location) => { },
                m => 0,
                false);
            var config = strategy.CreateConfig(null, "n");
            var engine = new SdkEngine("s");
            var current = new StateOperationContext(new Client(), new CancellationToken())
                .Result;
            var state = config.GetTargetState(current, engine, "eastus");
        }
    }
}
