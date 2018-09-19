﻿// ----------------------------------------------------------------------------------
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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public partial class ContainerServiceTests
    {
        public ContainerServiceTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
        }

        [Fact(Skip = "TODO: LinuxProfile.ssh.publicKeys.keyData is invalid.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestContainerService()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-ContainerService");
        }

        [Fact(Skip = "TODO: LinuxProfile.ssh.publicKeys.keyData is invalid.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestContainerServiceUpdate()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-ContainerServiceUpdate");
        }
    }
}
