using Microsoft.Azure.Commands.Attestation.Models;
using Microsoft.Azure.Commands.Attestation.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Collections;
using System.Management.Automation;
using System.Runtime.InteropServices.ComTypes;
using System.Collections.Generic;
using System.Text;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Attestation
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Attestation", SupportsShouldProcess = true, DefaultParameterSetName = NameParameterSet)]
    [OutputType(typeof(PSAttestation))]
    public class GetAzureAttestation : AttestationManagementCmdletBase
    {
        #region Parameter Set Names

        private const string NameParameterSet = "NameParameterSet";
        private const string InputObjectParameterSet = "IdParameterSet";


        #endregion

        #region Input Parameter Definitions
        /// <summary>
        /// Attestation name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = NameParameterSet,
            HelpMessage = "Attestation Name.")]
        [ResourceNameCompleter("Microsoft.Attestation", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Attestation object
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Attestation object to be queried.")]
        [ValidateNotNullOrEmpty]
        public PSAttestation InputObject { get; set; }

        /// <summary>
        /// Resource group to which the attestation belongs.
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = NameParameterSet,
            HelpMessage = "Specifies the name of the resource group associated with the attestation being queried.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public string ResourceGroupName { get; set; }
        #endregion

        public override void ExecuteCmdlet()
        {
            if (InputObject != null)
            {
                Name = InputObject.Name;
                ResourceGroupName = InputObject.ResourceGroupName;
            }
            if (string.IsNullOrEmpty(Name))
            {
                throw new CloudException(string.Format("ResourceNotSpecified", Name));
            }

            if (string.IsNullOrEmpty(ResourceGroupName))
            {
                throw new CloudException(string.Format("ResourceGroupNotSpecified", ResourceGroupName));
            }

            PSAttestation attestation = AttestationClient.GetAttestation(Name, ResourceGroupName);
            this.WriteObject(attestation);
        }
    }
}