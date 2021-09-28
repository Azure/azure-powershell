using Microsoft.Azure.Commands.DataFactoryV2.Properties;
using Microsoft.Azure.Management.DataFactory.Models;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    public static class SetAzureDataFactoryIntegrationRuntimeCommandHelper
    {
        public static void SetSubnetId(
            ManagedIntegrationRuntime integrationRuntime,
            string vNetInjectionMethod,
            string subnetId,
            string subnetName,
            string vnetId)
        {
            if (integrationRuntime == null)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(vnetId) ^ string.IsNullOrWhiteSpace(subnetName))
            {
                // Only one of the two paramaters is set
                throw new PSArgumentException(string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.IntegrationRuntimeInvalidVnet),
                    "Type");
            }

            if (!string.IsNullOrWhiteSpace(subnetId) && !string.IsNullOrWhiteSpace(vnetId))
            {
                // When subnetId as VNet property of Azure - SSIS integration runtime is provided, the other subnet and vnetId properties must be empty.
                throw new PSArgumentException(string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.AzureSSISIRSubnetAndVnetIdMustBeEmpty));
            }

            if (string.IsNullOrWhiteSpace(subnetId))
            {
                if (vNetInjectionMethod == Constants.IntegrationRuntimeVNectInjectionExpress)
                {
                    throw new PSArgumentException(
                        string.Format(CultureInfo.InvariantCulture,
                        Resources.AzureExpressSSISIRSubnetIdMustBePresent));
                }
                // Default to standard provision method.
                else if (string.IsNullOrWhiteSpace(vnetId))
                {
                    return;
                }
            }


            if (vNetInjectionMethod == Constants.IntegrationRuntimeVNectInjectionExpress)
            {
                if (integrationRuntime.CustomerVirtualNetwork == null)
                {
                   integrationRuntime.CustomerVirtualNetwork = new IntegrationRuntimeCustomerVirtualNetwork
                   {
                       SubnetId = subnetId
                   };
                }
                integrationRuntime.CustomerVirtualNetwork.SubnetId = subnetId;
            }
            else
            {
                integrationRuntime.CustomerVirtualNetwork = null;
                if (integrationRuntime.ComputeProperties == null)
                {
                    integrationRuntime.ComputeProperties = new IntegrationRuntimeComputeProperties();
                }

                if (string.IsNullOrWhiteSpace(subnetId))
                {
                    integrationRuntime.ComputeProperties.VNetProperties = new IntegrationRuntimeVNetProperties
                    {
                        Subnet = subnetName,
                        VNetId = vnetId
                    };
                }
                else
                {
                    integrationRuntime.ComputeProperties.VNetProperties = new IntegrationRuntimeVNetProperties
                    {
                        SubnetId = subnetId
                    };
                }
            }
        }
    }
}
