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
// ---------------------------------------------------------------------------------

using System;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Storage.Blob.Cmdlet;
using Microsoft.WindowsAzure.Storage.Blob;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Blob.Cmdlet
{
    public class NewAzureStorageContainerSasTest : StorageBlobTestBase
    {
        public NewAzureStorageContainerSasTokenCommand command = null;

        public NewAzureStorageContainerSasTest()
        {
            command = new NewAzureStorageContainerSasTokenCommand(BlobMock)
            {
                CommandRuntime = MockCmdRunTime
            };
            CurrentBlobCmd = command;
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetupAccessPolicyPermissionTest()
        {
            SharedAccessBlobPolicy accessPolicy = new SharedAccessBlobPolicy();
            command.SetupAccessPolicyPermission(accessPolicy, "");
            Assert.Equal(accessPolicy.Permissions, SharedAccessBlobPermissions.None);
            accessPolicy.Permissions = SharedAccessBlobPermissions.Read;
            command.SetupAccessPolicyPermission(accessPolicy, "");
            Assert.Equal(accessPolicy.Permissions, SharedAccessBlobPermissions.Read);
            command.SetupAccessPolicyPermission(accessPolicy, "D");
            Assert.Equal(accessPolicy.Permissions, SharedAccessBlobPermissions.Delete);
            command.SetupAccessPolicyPermission(accessPolicy, "rrR");
            Assert.Equal(accessPolicy.Permissions, SharedAccessBlobPermissions.Read);
            command.SetupAccessPolicyPermission(accessPolicy, "DR");
            Assert.Equal(accessPolicy.Permissions, SharedAccessBlobPermissions.Delete | SharedAccessBlobPermissions.Read);
            command.SetupAccessPolicyPermission(accessPolicy, "rwDl");
            Assert.Equal(accessPolicy.Permissions, SharedAccessBlobPermissions.Delete |
                SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.List | SharedAccessBlobPermissions.Write);
            command.SetupAccessPolicyPermission(accessPolicy, "Dlrw");
            Assert.Equal(accessPolicy.Permissions, SharedAccessBlobPermissions.Delete |
                SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.List | SharedAccessBlobPermissions.Write);
            AssertThrows<ArgumentException>(() => command.SetupAccessPolicyPermission(accessPolicy, "x"));
            AssertThrows<ArgumentException>(() => command.SetupAccessPolicyPermission(accessPolicy, "rwx"));
            AssertThrows<ArgumentException>(() => command.SetupAccessPolicyPermission(accessPolicy, "ABC"));
        }
    }
}
