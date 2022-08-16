using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.KeyVault.Commands.Key
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultRandomNumber", DefaultParameterSetName = GetByHsmNameParameterSet)]
    [OutputType(typeof(string), typeof(byte))]
    public class GetAzKeyVaultRandomNumber: KeyVaultCmdletBase
    {
        #region Parameter Set Names
        
        private const string GetByHsmNameParameterSet = "GetByHsmName";
        private const string GetByHsmInputObjectNameParameterSet = "GetByHsmInputObject";
        private const string GetByHsmResourceIdParameterSet = "GetByHsmResourceId";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// HSM Name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = GetByHsmNameParameterSet,
            HelpMessage = "HSM name. Cmdlet constructs the FQDN of a managed HSM based on the name and currently selected environment.")]
        [ResourceNameCompleter("Microsoft.KeyVault/managedHSMs", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string HsmName;

        /// <summary>
        /// HSM Input Object
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ParameterSetName = GetByHsmInputObjectNameParameterSet,
            HelpMessage = "HSM object.")]
        [ValidateNotNullOrEmpty]
        public PSManagedHsm InputObject;

        /// <summary>
        /// HSM Resource Id
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = GetByHsmResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "HSM resource id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, 
            HelpMessage = "The requested number of random bytes.")]
        [ValidateRange(1, 128)]
        public int Count;

        [Parameter(Mandatory = false,
            HelpMessage = "If specified, return random number as base-64 digit. By default, this command retruns random number as byte array.")]
        public SwitchParameter AsBase64String;

        #endregion

        public override void ExecuteCmdlet()
        {
            NormalizeKeySourceParameters();
            var result = Track2DataClient.GetManagedHsmRandomNumber(HsmName, Count);
            if(AsBase64String.IsPresent)
            {
                this.WriteObject(Convert.ToBase64String(result));
            }
            else
            {
                this.WriteObject(result, true);
            }
        }

        private void NormalizeKeySourceParameters()
        {
            if (InputObject != null)
            {
                HsmName = InputObject.Name;
            }
            else if (ResourceId != null)
            {
                var resourceIdentifier = new ResourceIdentifier(ResourceId);
                HsmName = resourceIdentifier.ResourceName;
            }
        }
    }
}
