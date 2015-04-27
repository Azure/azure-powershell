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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.Azure.Commands.Compute.Models;
using System;
using Xunit;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class UtilityFunctionTests
    {
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

            Func<string, string> removeSpaces = delegate(string s)
            {
                return string.IsNullOrEmpty(s) ? s : s.Replace(" ", string.Empty).ToLower();
            };

            foreach (var loc in locations)
            {
                var s1 = loc.Standardize();
                var s2 = removeSpaces(loc);
                Assert.True(string.Equals(s1, s2));
            }
        }
    }
}
