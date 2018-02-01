using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.ManagementPartner;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.Resources
{
    public abstract class AzureManagementPartnerCmdletsBase:AzureRMCmdlet
    {
        private IACEProvisioningManagementPartnerAPIClient aceProvisioningManagementPartnerApiClient;

        public IACEProvisioningManagementPartnerAPIClient AceProvisioningManagementPartnerApiClient
        {
            get
            {
                return aceProvisioningManagementPartnerApiClient ?? (aceProvisioningManagementPartnerApiClient =
                           AzureSession.Instance.ClientFactory.CreateArmClient<ACEProvisioningManagementPartnerAPIClient>(
                               DefaultProfile.DefaultContext, AzureEnvironment.Endpoint.ResourceManager));
            }

            set { aceProvisioningManagementPartnerApiClient = value; }
        }
    }
}
