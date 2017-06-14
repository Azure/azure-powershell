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

using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Test
{
    public class KeyVaultUnitTestBase : RMTestBase
    {
        protected const string subscriptionId = "subscriptionid";

        protected const string ResourceGroupName = "bar";

        protected const string Location = "centralus";

        protected const string VaultName = "vaultname";

        protected const string KeyName = "keyfoo";

        protected const string KeyName2 = "keyfoo2";

        protected const string KeyVersion = "keyVersion";

        protected const string SecretValue = "secval";

        protected const string SecretValue2 = "secval2";

        protected const string SecretName = "secfoo";

        protected const string SecretName2 = "secfoo2";

        protected const string SecretVersion = "secretVersion";

        protected Mock<IKeyVaultDataServiceClient> keyVaultClientMock;

        protected Mock<ICommandRuntime> commandRuntimeMock;

        public virtual void SetupTest()
        {
            keyVaultClientMock = new Mock<IKeyVaultDataServiceClient>();

            commandRuntimeMock = new Mock<ICommandRuntime>();
        }
    }
}
