// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Management.Automation;
using System.Runtime.Serialization.Formatters;
using Microsoft.Azure.Commands.KeyVault;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.Azure.Commands.Resources.Models.ActiveDirectory;
using ManagementApi = Microsoft.Azure.Management.KeyVault;
using Moq;
using Newtonsoft.Json;
using Xunit;
using System;

namespace Microsoft.Azure.Commands.KeyVault.Test.UnitTests
{
    public class GetAzureKeyVaultTests
    {
        private GetAzureKeyVault getVaultCmdlet;

        private Mock<ResourcesClient> resourcesClientMock;

        private Mock<ICommandRuntime> commandRuntimeMock;

        private Mock<ManagementClient> keyVaultMgmtClientMock;

        private Mock<ActiveDirectoryClient> adClientMock;

        private string vaultName = "myvault";
        private string resourceGroupName = "myresourcegroup";
        private Guid tenantId = new Guid("72f988bf-86f1-41af-91ab-2d7cd011db47");
        private Guid objectId = new Guid("5a8c75a2-cc4c-4298-b8ad-65ff65541911");

        public GetAzureKeyVaultTests()
        {
            resourcesClientMock = new Mock<ResourcesClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            keyVaultMgmtClientMock = new Mock<ManagementClient>();
            adClientMock = new Mock<ActiveDirectoryClient>();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanGetSingleVaultTest()
        {
            getVaultCmdlet = new GetAzureKeyVault()
            {
                CommandRuntime = commandRuntimeMock.Object,
                ResourcesClient = resourcesClientMock.Object,
                KeyVaultManagementClient = keyVaultMgmtClientMock.Object,
                ActiveDirectoryClient = adClientMock.Object,
                VaultName = vaultName,
                ResourceGroupName = resourceGroupName
            };

            ManagementApi.Vault mgmtVault = new ManagementApi.Vault()
            {
                Id = "/subscriptions/aaaa/resourceGroups/" + resourceGroupName + "/providers/Microsoft.KeyVault/vaults/" + vaultName,
                Location = "East US",
                Name = vaultName,
                Type = "Microsoft.KeyVault/vaults",
                Properties = new ManagementApi.VaultProperties()
                {
                    EnabledForDeployment = true,
                    Sku = new ManagementApi.Sku() { Family = "A", Name = "Standard" },
                    TenantId = tenantId,
                    VaultUri = "https://" + vaultName + ".vault.azure.net",
                    AccessPolicies = new List<ManagementApi.AccessPolicyEntry>(){
                               new ManagementApi.AccessPolicyEntry()
                               {
                                   TenantId = tenantId,
                                   ObjectId = objectId,
                                   PermissionsToKeys = new string[]{"all"},
                                   PermissionsToSecrets = new string[] {"all"}
                               }
                           }
                }
            };

            keyVaultMgmtClientMock.Setup(kv => kv.GetVault(vaultName, resourceGroupName, adClientMock.Object)).Returns(new Vault(mgmtVault, adClientMock.Object));
            adClientMock.Setup(ad => ad.GetADObject(new ADObjectFilterOptions()
                {
                    Id = objectId.ToString(),
                    Paging = true,
                })).Returns(new PSADServicePrincipal()
                {
                    Id = objectId,
                    DisplayName = "Test App",
                    ServicePrincipalName = "http://contoso.com",
                });

            getVaultCmdlet.ExecuteCmdlet();
            keyVaultMgmtClientMock.VerifyAll();
            adClientMock.VerifyAll();
        }

    }
}
