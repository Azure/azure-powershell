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

using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class ComputeCloudExceptionTests
    {
        public ComputeCloudExceptionTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RunComputeCloudExceptionTests()
        {
            // Message Only
            var ex1 = new Rest.Azure.CloudException("Test1");
            var cx1 = new ComputeCloudException(ex1);
            Assert.True(string.Equals(cx1.Message, ex1.Message));
            Assert.True(cx1.InnerException is Rest.Azure.CloudException);
            Assert.True(string.Equals(cx1.InnerException.Message, ex1.Message));

            // Message + Inner Exception
            var ex2 = new Rest.Azure.CloudException("Test2", ex1);
            var cx2 = new ComputeCloudException(ex2);
            Assert.True(string.Equals(cx2.Message, ex2.Message));
            Assert.True(cx2.InnerException is Rest.Azure.CloudException);
            Assert.True(string.Equals(cx2.InnerException.Message, ex2.Message));

            // Empty Message
            var ex3 = new Rest.Azure.CloudException(string.Empty);
            var cx3 = new ComputeCloudException(ex3);
            Assert.True(string.IsNullOrEmpty(cx3.Message));
            Assert.True(cx3.InnerException is Rest.Azure.CloudException);
            Assert.True(string.IsNullOrEmpty(cx3.InnerException.Message));

            // Default message is used, if 'null' passed to the constructor.
            var ex4 = new Rest.Azure.CloudException(null);
            var cx4 = new ComputeCloudException(ex4);
            Assert.True(!string.IsNullOrEmpty(cx4.Message));
            Assert.True(cx4.InnerException is Rest.Azure.CloudException);
            Assert.True(!string.IsNullOrEmpty(cx4.InnerException.Message));

            ComputeTestController.NewInstance.RunPsTest("Run-ComputeCloudExceptionTests");
        }
    }
}
