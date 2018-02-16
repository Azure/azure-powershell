// ----------------------------------------------------------------------------------
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace RepoTasks.Cmdlets.Tests
{
    using System;
    using System.Collections.Generic;
    using RemoteWorker;
    using Xunit;

    public class AppDomainWorkerShould : IDisposable
    {
        private readonly AppDomain _domain;
        private readonly IReflectionWorker _reflectionWorker;

        // Setup
        public AppDomainWorkerShould()
        {
            _domain = AppDomain.CreateDomain("AppDomainIsolation: " + Guid.NewGuid());
            var type = typeof(AppDomainWorker);
            Assert.NotNull(type.FullName);
            _reflectionWorker = (IReflectionWorker)_domain.CreateInstanceFromAndUnwrap(type.Assembly.Location, type.FullName);
        }

        // TearDown
        public void Dispose()
        {
            if (_domain != null) AppDomain.Unload(_domain);
        }

        [Fact]
        public void ReturnCmdletTypesAndAssemblyNameWithCmdlets()
        {
            var cmdlets = new[] {"Test-Dummy"};
            ReturnCmdletTypesAndAssemblyName(cmdlets);
        }

        [Fact]
        public void ReturnCmdletTypesAndAssemblyNameWithoutCmdlets()
        {
            ReturnCmdletTypesAndAssemblyName(null);
        }

        [Fact]
        public void ReturnCmdletTypesAndAssemblyNameWithEmptyCmdlets()
        {
            var cmdlets = new string[] {};
            ReturnCmdletTypesAndAssemblyName(cmdlets);
        }

        [Fact]
        public void BuildConfiguration()
        {
            var cmdlets = new[] { "Test-Dummy" };
            var types = ReturnCmdletTypesAndAssemblyName(cmdlets);
            var conf = new AppDomainWorker().BuildXmlConfiguration(types);
            Assert.Equal(4, conf.ViewDefinitions.Views.Length);

            var view0 = conf.ViewDefinitions.Views[0];
            Assert.Equal("RepoTasks.Cmdlets.Models.PsDummyOutput1", view0?.ViewSelectedBy?.TypeName);

            var expecterProps1 = new[] { "RequestId", "StatusCode", "Id", "Name", "Type" };
            var columnItems = view0?.TableControl?.TableRowEntries[0]?.TableColumnItems;
            Assert.NotNull(columnItems);
            Assert.Equal(expecterProps1.Length, columnItems.Length);
            foreach (var expectedProp in expecterProps1)
            {
                Assert.Contains(columnItems, ci => ci.PropertyName == expectedProp);
            }
        }

        [Fact]
        public void DoWorkRemotelyAndReturnFilname()
        {
            var assemblyPath = typeof(TestDummyCommand).Assembly.Location;
            var cmdlets = new[] { "Test-Dummy" };
            var filename =_reflectionWorker.BuildFormatPs1Xml(assemblyPath, cmdlets);
            Assert.NotNull(filename);
            Assert.Equal("RepoTasks.Cmdlets.generated.format.ps1xml", filename);
        }

        private static IList<Type> ReturnCmdletTypesAndAssemblyName(string[] cmdlets)
        {
            var assemblyPath = typeof(TestDummyCommand).Assembly.Location;
            string assembyName;
            var types = AppDomainWorker.GetCmdletTypes(assemblyPath, cmdlets, out assembyName);
            Assert.Equal("RepoTasks.Cmdlets", assembyName);
            Assert.True(types.Count >= 1);
            Assert.Contains(types, t => t.FullName == "RepoTasks.Cmdlets.TestDummyCommand");
            if (cmdlets != null && cmdlets?.Length == 1)
            {
                Assert.DoesNotContain(types, t => t.FullName == "RepoTasks.Cmdlets.TestDummyTwoCommand");
            }

            return types;
        }
    }
}
