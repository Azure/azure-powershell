using Microsoft.Azure.Commands.Management.CognitiveServices.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CognitiveServices;
using Microsoft.Azure.Management.CognitiveServices.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.CognitiveServices
{
    /// <summary>
    /// Get Cognitive Services CommitmentTier
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CognitiveServicesCommitmentTier", DefaultParameterSetName = DefaultParameterSet),OutputType(typeof(CommitmentTier))]
    public class GetAzureCognitiveServicesCommitmentTierCommand : CognitiveServicesAccountBaseCmdlet
    {
        protected const string DefaultParameterSet = "DefaultParameterSet";

        [Parameter(
            Position = 0,
            ParameterSetName = DefaultParameterSet,
            Mandatory = true,
            HelpMessage = "Cognitive Services Account Location.")]
        [LocationCompleter("Microsoft.CognitiveServices/accounts")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            RunCmdLet(() =>
            {
                var commitmentTiers = new List<CommitmentTier>(this.CognitiveServicesClient.CommitmentTiers.List(Location));

                if (commitmentTiers != null)
                {
                    WriteObject(commitmentTiers, true);
                }
            });
        }
    }
}
