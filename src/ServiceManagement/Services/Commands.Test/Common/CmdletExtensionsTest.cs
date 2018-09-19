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

using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.Test.Common
{
    
    public class CmdletExtensionsTest
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResolvePathTest()
        {
            StubCmdlet stubCmdlet = new StubCmdlet();

            // Null path
            Assert.Equal(null, stubCmdlet.ResolvePath(null));

            // No session state
            Assert.Equal(".\\", stubCmdlet.ResolvePath(".\\"));
        }
    }

    internal class StubCmdlet : PSCmdlet
    {
    }
}
