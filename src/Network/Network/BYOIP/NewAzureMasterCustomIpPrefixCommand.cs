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
    using System.Linq;
    using System.Management.Automation;
    using MNM = Microsoft.Azure.Management.Network.Models;
    using System;

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
            HelpMessage = "The master custom IP prefix location.")]
        [LocationCompleter("Microsoft.Network/masterCustomIpPrefix")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The geography of edge routers this prefix range will be advertised on.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            MNM.RIR.NorthAmerica,
            MNM.RIR.Europe,
            MNM.RIR.Asia,
            MNM.RIR.SouthAmerica,
            MNM.RIR.Africa,
            MNM.RIR.Global,
            IgnoreCase = true)]
        public string Geography { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The CIDR of the master custom IP prefix")]
        [ValidateNotNullOrEmpty]
        public string Cidr { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The message for master custom IP prefix validation.")]
        [ValidateNotNullOrEmpty]
        public string ValidationMessage { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The message for master custom IP prefix validation signed with public key.")]
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
            var present = this.IsMasterCustomIpPrefixPresent(this.ResourceGroupName, this.Name);
            ConfirmAction(
                false,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var masterCustomIpPrefix = CreateMasterCustomIpPrefix();
                    if (masterCustomIpPrefix != null)
                    {
                        WriteObject(masterCustomIpPrefix);
                    }
                },
                () => present);
        }

        private PSMasterCustomIpPrefix CreateMasterCustomIpPrefix()
        {
            var masterCustomIpPrefix = new PSMasterCustomIpPrefix();
            masterCustomIpPrefix.Name = this.Name;
            masterCustomIpPrefix.Location = this.Location;
            masterCustomIpPrefix.Geography = this.Geography;
            masterCustomIpPrefix.Cidr = this.Cidr;
            masterCustomIpPrefix.OriginalValidationMessage = this.ValidationMessage;
            masterCustomIpPrefix.SignedValidationMessage = this.SignedValidationMessage;

            
            var theModel = NetworkResourceManagerProfile.Mapper.Map<MNM.MasterCustomIpPrefix>(masterCustomIpPrefix);

            theModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            if (this.ShouldProcess(this.Name, $"Creating a new PublicIpPrefix in ResourceGroup {this.ResourceGroupName} with Name {this.Name}"))
            {
                this.MasterCustomIpPrefixClient.CreateOrUpdate(this.ResourceGroupName, this.Name, theModel);

                var getMasterCustomIpPrefix = this.GetMasterCustomIpPrefix(this.ResourceGroupName, this.Name);

                return getMasterCustomIpPrefix;
            }

            return null;
        }
    }
}
