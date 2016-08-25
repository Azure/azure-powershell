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
using System;
using Xunit;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class UtilityFunctionTests
    {
        public UtilityFunctionTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLocationStringExtension()
        {
            string[] locations = new string[]
            {
                "West US",
                "eastus",
                "East Asia 2"
            };

            Func<string, string> normalize = delegate (string s)
            {
                return string.IsNullOrEmpty(s) ? s : s.Replace(" ", string.Empty).ToLower();
            };

            foreach (var loc in locations)
            {
                var s1 = loc.Canonicalize();
                var s2 = normalize(loc);
                Assert.True(string.Equals(s1, s2));
            }
        }
    }
}
