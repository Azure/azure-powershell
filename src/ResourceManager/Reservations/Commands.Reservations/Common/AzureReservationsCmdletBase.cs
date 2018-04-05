using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.Reservations;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.Reservations.Common
{
    /// <summary>
    /// Base class of Azure Reservations Cmdlet.
    /// </summary>
    public abstract class AzureReservationsCmdletBase : AzureRMCmdlet
    {
        private IAzureReservationAPIClient _azureReservationAPI;

        private Dictionary<string, List<string>> _defaultRequestHeaders;

        /// <summary>
        /// Gets or sets the Reservations management client.
        /// </summary>
        public IAzureReservationAPIClient AzureReservationAPIClient
        {
            get
            {
                return _azureReservationAPI ??
                       (_azureReservationAPI =
                           AzureSession.Instance.ClientFactory.CreateArmClient<AzureReservationAPIClient>(DefaultProfile.DefaultContext,
                               AzureEnvironment.Endpoint.ResourceManager));
            }
            set { _azureReservationAPI = value; }
        }
    }
}