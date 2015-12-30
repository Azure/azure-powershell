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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Common.ScenarioTest
{
    [Collection("SampleCollection")]
    public class SampleTest
    {
        ScenarioTestFixture _collectionState;
        public SampleTest(ScenarioTestFixture fixture)
        {
            _collectionState = fixture;
        }

        [Fact]
        public void ResourceGroupsTest()
        {
            var helper = _collectionState.GetRunner("resource-management");
            helper.RunScript("01-ResourceGroups");
        }

        [Fact]
        public void VirtualHardDisksTest()
        {
            var helper = _collectionState.GetRunner("virtual-hard-disk");
            helper.RunScript("01-VirtualHardDisks");
        }
    }
}
