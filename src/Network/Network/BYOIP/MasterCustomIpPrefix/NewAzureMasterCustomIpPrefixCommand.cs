// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Network
{
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;
    using System.Collections;
    using System.Management.Automation;
    using MNM = Microsoft.Azure.Management.Network.Models;

    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "MasterCustomIpPrefix", SupportsShouldProcess = true), OutputType(typeof(PSMasterCustomIpPrefix))]
    public class NewAzureMasterCustomIpPrefixCommand : MasterCustomIpPrefixBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The MasterCustomIpPrefix location.")]
        [LocationCompleter("Microsoft.Network/masterCustomIpPrefix")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The CIDR of the MasterCustomIpPrefix")]
        [ValidateNotNullOrEmpty]
        public string Cidr { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The message for MasterCustomIpPrefix validation.")]
        [ValidateNotNullOrEmpty]
        public string ValidationMessage { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The message for MasterCustomIpPrefix validation signed with public key.")]
        [ValidateNotNullOrEmpty]
        public string SignedValidationMessage { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            var resourceExists = NetworkBaseCmdlet.IsResourcePresent(() => GetMasterCustomIpPrefix(this.ResourceGroupName, this.Name));

            if (resourceExists)
            {
                throw new System.Exception(string.Format("A MasterCustomIpPrefix with name '{0}' in resource group '{1}' already exists. Please use Set-AzMasterCustomIpPrefix to update an existing MasterCustomIpPrefix.", this.Name, this.ResourceGroupName));
            }

            var psModel = CreateMasterCustomIpPrefix();
            if (psModel != null)
            {
                WriteObject(psModel);
            }
        }

        private PSMasterCustomIpPrefix CreateMasterCustomIpPrefix()
        {
            var psModel = new PSMasterCustomIpPrefix()
            {
                Name = this.Name,
                ResourceGroupName = this.ResourceGroupName,
                Location = this.Location,
                Cidr = this.Cidr,
                OriginalValidationMessage = this.ValidationMessage,
                SignedValidationMessage = this.SignedValidationMessage
            };
            
            var sdkModel = NetworkResourceManagerProfile.Mapper.Map<MNM.MasterCustomIpPrefix>(psModel);

            sdkModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            if (this.ShouldProcess($"Name: {this.Name} ResourceGroup: {this.ResourceGroupName}", "Creating a new MasterCustomIpPrefix"))
            {
                var createdSdkModel = this.MasterCustomIpPrefixClient.CreateOrUpdate(this.ResourceGroupName, this.Name, sdkModel);
                return this.ToPsMasterCustomIpPrefix(createdSdkModel);
            }

            return null;
        }
    }
}