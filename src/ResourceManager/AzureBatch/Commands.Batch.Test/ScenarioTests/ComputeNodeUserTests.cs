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

using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class ComputeNodeUserTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private const string poolId = ScenarioTestHelpers.SharedPool;

        public ComputeNodeUserTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestComputeNodeUserEndToEnd()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string computeNodeId = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ComputeNodeUserEndToEnd '{0}' '{1}'", poolId, computeNodeId) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    computeNodeId = ScenarioTestHelpers.GetComputeNodeId(controller, context, poolId);
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());

        }
    }
}
