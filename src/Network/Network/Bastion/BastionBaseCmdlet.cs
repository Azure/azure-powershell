// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network.Bastion
{
    public abstract class BastionBaseCmdlet : NetworkBaseCmdlet
    {
        public IBastionHostsOperations BastionClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.BastionHosts;
            }
        }
        
        protected IVirtualNetworksOperations VirtualNetworkClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.VirtualNetworks;
            }
        }

        protected IPublicIPAddressesOperations PublicIPAddressesClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.PublicIPAddresses;
            }
        }

        public bool IsResourcePresent(string resourceGroupName, string name)
        {
            try
            {
                GetBastion(resourceGroupName, name);
            }
            catch (Microsoft.Rest.Azure.CloudException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Resource is not present
                    return false;
                }

                throw;
            }

            return true;
        }

        public PSBastion GetBastion(string resourceGroupName, string name)
        {
            var bastion = this.BastionClient.Get(resourceGroupName, name);

            var psBastion = NetworkResourceManagerProfile.Mapper.Map<PSBastion>(bastion);
            psBastion.ResourceGroupName = resourceGroupName;
            psBastion.Tag = TagsConversionHelper.CreateTagHashtable(bastion.Tags);

            return psBastion;
        }

        public PSBastion ToPsBastion(MNM.BastionHost host)
        {
            var bastion = NetworkResourceManagerProfile.Mapper.Map<PSBastion>(host);

            bastion.Tag = TagsConversionHelper.CreateTagHashtable(host.Tags);

            return bastion;
        }

        public List<PSBastion> ListBastions(string resourceGroupName)
        {
            var bastions = ShouldListBySubscription(resourceGroupName, null) ?
                 this.BastionClient.List() :                                              //// List by sub id
                 this.BastionClient.ListByResourceGroup(resourceGroupName);               //// List by RG name

            List<PSBastion> bastionsToReturn = new List<PSBastion>();
            if (bastions != null)
            {
                foreach (MNM.BastionHost bastion in bastions)
                {
                    PSBastion bastionToReturn = ToPsBastion(bastion);
                    bastionToReturn.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(bastion.Id);
                    bastionsToReturn.Add(bastionToReturn);
                }
            }

            return bastionsToReturn;
        }
    }
}
