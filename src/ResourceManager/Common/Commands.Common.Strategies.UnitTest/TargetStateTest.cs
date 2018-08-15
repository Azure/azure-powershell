using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.Threading;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Strategies.UnitTest
{
    public class TargetStateTest
    {
        class Client : ServiceClient<Client>, IClient
        {
            public T GetClient<T>() where T : ServiceClient<T>
                => this as T;
        }

        class NestedModel
        {
            public string Name { get; set; }

            public string Id { get; set; }
        }

        class Model
        {
            public string Location { get; set; }

            public IList<NestedModel> Nested { get; set; }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDependencyGraph()
        {
            // resource group
            var rgStrategy = ResourceStrategy.Create<Model, Client, Client>(
                ResourceType.ResourceGroup,
                c => c,
                async (c, m) => null,
                async (c, m) => new Model(),
                m => m.Location,
                (m, location) => m.Location = location,
                m => 0,
                false);

            var rgConfig = rgStrategy.CreateResourceConfig(null, "rgname");
            var rgConfig2 = rgStrategy.CreateResourceConfig(null, "rgname2");

            // resource
            var resourceStrategy = ResourceStrategy.Create<Model, Client, Client>(
                new ResourceType("Company.Namespace", "resourceProvider"),
                c => c,
                async (c, m) => null,
                async (c, m) => new Model(),
                m => m.Location,
                (m, location) => m.Location = location,
                m => 0,
                false);

            var resource = resourceStrategy.CreateResourceConfig(rgConfig, "res");

            // nested resource
            var rgNestedStrategy = NestedResourceStrategy.Create<NestedModel, Model>(
                "rgnested",
                m => m.Nested,
                (m, list) => m.Nested = list,
                nm => nm.Name,
                (nm, name) => nm.Name = name);

            // add the nested resource to the resource group.
            var rgNestedConfig = rgConfig.CreateNested(rgNestedStrategy, "rgnestedname");

            // nested resource
            var nestedStrategy = NestedResourceStrategy.Create<NestedModel, Model>(
                "nested",
                m => m.Nested,
                (m, list) => m.Nested = list,
                nm => nm.Name,
                (nm, name) => nm.Name = name);

            // add the nested resource to a resource.
            var nestedConfig = resource.CreateNested(
                nestedStrategy,
                "nestedname",
                e => new NestedModel
                {
                    Id = e.GetId(rgConfig2)
                });

            //
            var engine = new SdkEngine("s");

            // empty state.
            var current = new StateOperationContext(new Client(), new CancellationToken())
                .Result;

            var state = resource.GetTargetState(current, engine, "eastus");
            var rgModel = state.Get(rgConfig);

            Assert.Equal("eastus", rgModel.Location);

            var rgNestedModel = rgModel.Nested.First() as NestedModel;
            Assert.Equal("rgnestedname", rgNestedModel.Name);

            var rgModel2 = state.Get(rgConfig2);
            Assert.NotNull(rgModel2);
        }
    }
}
