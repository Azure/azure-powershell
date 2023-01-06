// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Net;
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
            psBastion.Sku.Name = bastion.Sku.Name;
            psBastion.ScaleUnit = bastion.ScaleUnits;
            psBastion.Tag = TagsConversionHelper.CreateTagHashtable(bastion.Tags);
            psBastion.DisableCopyPaste = bastion.DisableCopyPaste;
            psBastion.EnableTunneling = bastion.EnableTunneling;
            psBastion.EnableIpConnect = bastion.EnableIpConnect;
            psBastion.EnableShareableLink = bastion.EnableShareableLink;

            return psBastion;
        }

        public PSBastion ToPsBastion(MNM.BastionHost host)
        {
            var bastion = NetworkResourceManagerProfile.Mapper.Map<PSBastion>(host);
            bastion.Sku.Name = host.Sku.Name;
            bastion.ScaleUnit = host.ScaleUnits;
            bastion.Tag = TagsConversionHelper.CreateTagHashtable(host.Tags);
            bastion.DisableCopyPaste = host.DisableCopyPaste;
            bastion.EnableTunneling = host.EnableTunneling;
            bastion.EnableIpConnect = host.EnableIpConnect;
            bastion.EnableShareableLink = host.EnableShareableLink;

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

        public bool IsSkuDowngrade(PSBastion bastion, string sku)
        {
            return bastion.IsStandard() && sku.Equals(MNM.BastionHostSkuName.Basic);
        }

        public bool IsSkuDowngrade(PSBastion existingBastion, PSBastion newBastion)
        {
            return existingBastion.IsStandard() && newBastion.IsBasic();
        }

        public void ValidateBastionFeatures(PSBastion bastion, int? scaleUnits = null, bool? enableKerberos = null, bool? disableCopyPaste = null, bool? enableTunneling = null, bool? enableIpConnect = null, bool? enableShareableLink = null)
        {
            if (bastion.IsBasic())
            {
                // Features allowed for Basic SKU
                // Add after updating schema
                //if (enableKerberos.HasValue)
                //{
                //    bastion.EnableKerberos = enableKerberos;
                //}

                // Features NOT allowed for Basic SKU
                if (scaleUnits.HasValue && scaleUnits != PSBastion.MinimumScaleUnits)
                {
                    throw new ArgumentException("Scale Units cannot be updated with Basic Sku");
                }

                if (disableCopyPaste.HasValue)
                {
                    throw new ArgumentException("Copy/Paste cannot be updated with Basic SKU");
                }

                if (enableTunneling.HasValue)
                {
                    throw new ArgumentException("Native client cannot be updated with Basic SKU");
                }

                if (enableIpConnect.HasValue)
                {
                    throw new ArgumentException("IP connect cannot be updated with Basic SKU");
                }

                if (enableShareableLink.HasValue)
                {
                    throw new ArgumentException("Shareable link cannot be updated with Basic SKU");
                }
            }
            else if (bastion.IsStandard())
            {
                if (scaleUnits.HasValue)
                {
                    if (scaleUnits < PSBastion.MinimumScaleUnits || scaleUnits > PSBastion.MaximumScaleUnits)
                    {
                        throw new ArgumentException($"Please select scale units value between {PSBastion.MinimumScaleUnits} and {PSBastion.MaximumScaleUnits}");
                    }

                    bastion.ScaleUnit = scaleUnits;
                }

                // Add after updating schema
                //if (enableKerberos.HasValue)
                //{
                //    bastion.EnableKerberos = this.EnableKerberos;
                //}

                if (disableCopyPaste.HasValue)
                {
                    bastion.DisableCopyPaste = disableCopyPaste;
                }

                if (enableTunneling.HasValue)
                {
                    bastion.EnableTunneling = enableTunneling;
                }

                if (enableIpConnect.HasValue)
                {
                    bastion.EnableIpConnect = enableIpConnect;
                }

                if (enableShareableLink.HasValue)
                {
                    bastion.EnableShareableLink = enableShareableLink;
                }
            }
        }
    }
}
