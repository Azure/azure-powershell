// ----------------------------------------------------------------------------------
//
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

using System.Reflection;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.Azure.ServiceManagemenet.Common.Models;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class ComputeNodeUserTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private const string poolId = ScenarioTestHelpers.SharedPool;
        public XunitTracingInterceptor _logger;

        public ComputeNodeUserTests(Xunit.Abstractions.ITestOutputHelper output)
        {
#if NET472
            string libDirectory = null;
            System.IO.DirectoryInfo currentDirectory = new System.IO.DirectoryInfo(System.AppDomain.CurrentDomain.BaseDirectory);
            while (!string.Equals("src", currentDirectory.Name, System.StringComparison.OrdinalIgnoreCase) && currentDirectory.Exists)
            {
                currentDirectory = System.IO.Directory.GetParent(currentDirectory.FullName);
            }

            if (string.Equals("src", currentDirectory.Name, System.StringComparison.OrdinalIgnoreCase))
            {
                libDirectory = System.IO.Path.Combine(currentDirectory.FullName, "lib");
            }

            System.AppDomain.CurrentDomain.Load(System.IO.File.ReadAllBytes(System.IO.Path.Combine(libDirectory, "Newtonsoft.Json.9.dll")));
            System.AppDomain.CurrentDomain.Load(System.IO.File.ReadAllBytes(System.IO.Path.Combine(libDirectory, "Newtonsoft.Json.10.dll")));
#endif
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestComputeNodeUserEndToEnd()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string computeNodeId = null;
            controller.RunPsTestWorkflow(
                _logger,
                () => { return new string[] { string.Format("Test-ComputeNodeUserEndToEnd '{0}' '{1}'", poolId, computeNodeId) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    computeNodeId = ScenarioTestHelpers.GetComputeNodeId(controller, context, poolId);
                },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);

        }
    }
}
