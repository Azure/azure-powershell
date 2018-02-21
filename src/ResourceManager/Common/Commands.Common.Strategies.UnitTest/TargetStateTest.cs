using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.Threading;
using Xunit;
using System;
using System.Collections.Generic;

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
        }

        class Model
        {
            public string Location { get; set; }

            public IList<NestedModel> Nested { get; set; }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Test()
        {
            var rgStrategy = ResourceStrategy.Create<Model, Client, Client>(
                ResourceType.ResourceGroup,
                c => c,
                async (c, m) => new Model(),
                async (c, m) => new Model(),
                m => m.Location,
                (m, location) => m.Location = location,
                m => 0,
                false);

            var rgConfig = rgStrategy.CreateConfig(null, "rg");

            var nestedStrategy = NestedResourceStrategy.Create<NestedModel, Model>(
                "nested",
                m => m.Nested,
                (m, list) => m.Nested = list,
                nm => nm.Name,
                (nm, name) => nm.Name = name);

            var nestedConfig = rgConfig.CreateNested(nestedStrategy, "nested");

            var engine = new SdkEngine("s");

            var current = new StateOperationContext(new Client(), new CancellationToken())
                .Result;

            var state = rgConfig.GetTargetState(current, engine, "eastus");
            var model = state.Get(rgConfig);

            Assert.Equal("eastus", model.Location);
        }
    }
}
