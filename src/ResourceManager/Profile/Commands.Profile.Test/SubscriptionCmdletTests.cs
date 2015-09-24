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

using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Profile;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.Linq;
using Xunit;
using System;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Hyak.Common;
using System.Management.Automation;
using Microsoft.Azure.Commands.Resources.Test.ScenarioTests;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public class SubscriptionCmdletTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AllParameterSetsSucceed()
        {
            ProfileController.NewInstance.RunPsTest("db1ab6f0-4769-4b27-930e-01e2ef9c123c", "Test-GetSubscriptionsEndToEnd");
        }
    }
}
