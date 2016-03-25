using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.ResourceManager.Common;
using PSResourceManagerModels = Microsoft.Azure.Commands.Resources.Models;

namespace Microsoft.Azure.Commands.MachineLearning
{
    public abstract class WebServicesCmdletBase : AzureRMCmdlet //WebServicesCmdletBase
    {
        private PSResourceManagerModels.ResourcesClient _resourcesClient;

        [Parameter(
        Position = 0,
        Mandatory = true,
        HelpMessage = "The RP Service. For Example: foo.com")]
        [ValidateNotNullOrEmpty]
        public string RPService { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = "The Azure Subscription ID")]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            HelpMessage = "The Resource Group Name.")]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = true,
            HelpMessage = "The Web Service Name.")]
        public string WebServiceName { get; set; }

        public PSResourceManagerModels.ResourcesClient ResourceClient
        {
            get
            {
                if (_resourcesClient == null)
                {
                    _resourcesClient = new PSResourceManagerModels.ResourcesClient(DefaultProfile.Context)
                    {
                        VerboseLogger = WriteVerboseWithTimestamp,
                        ErrorLogger = WriteErrorWithTimestamp,
                        WarningLogger = WriteWarningWithTimestamp
                    };
                }
                return _resourcesClient;
            }
            set { _resourcesClient = value; }
        }


        protected bool isVerbose;
    }
}
