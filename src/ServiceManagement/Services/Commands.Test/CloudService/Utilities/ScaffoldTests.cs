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
using Xunit;
using Microsoft.WindowsAzure.Commands.Common.Test.Properties;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService.Scaffolding;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.Test.CloudService.Utilities
{
    
    public class ScaffoldTests : SMTestBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ParseTests()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                string path = files.CreateEmptyFile("Scaffold.xml");
                FileUtilities.DataStore.WriteFile(path, Resources.ValidScaffoldXml);

                Scaffold scaffold = Scaffold.Parse(path);

                Assert.Equal(scaffold.Files.Count, 6);
                Assert.Equal(scaffold.Files[0].PathExpression, "modules\\.*");
                Assert.Equal(scaffold.Files[1].Path, @"bin/node123dfx65.exe");
                Assert.Equal(scaffold.Files[1].TargetPath, @"/bin/node.exe");
                Assert.Equal(scaffold.Files[2].Path, @"bin/iisnode.dll");
                Assert.Equal(scaffold.Files[3].Path, @"bin/setup.cmd");
                Assert.Equal(scaffold.Files[4].Path, "Web.config");
                Assert.Equal(scaffold.Files[4].Rules.Count, 1);
                Assert.Equal(scaffold.Files[5].Path, "WebRole.xml");
                Assert.Equal(scaffold.Files[5].Copy, false);
                Assert.Equal(scaffold.Files[5].Rules.Count, 1);
            }
        }
    }
}
