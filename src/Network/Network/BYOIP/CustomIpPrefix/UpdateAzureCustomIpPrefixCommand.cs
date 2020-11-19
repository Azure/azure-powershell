﻿// ----------------------------------------------------------------------------------
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
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.Network;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using System;
    using System.Collections;
    using System.Management.Automation;
    using MNM = Microsoft.Azure.Management.Network.Models;

    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CustomIpPrefix", SupportsShouldProcess = true, DefaultParameterSetName = UpdateByNameParameterSet), OutputType(typeof(PSCustomIpPrefix))]
    public class UpdateAzureCustomIpPrefixCommand : CustomIpPrefixBaseCmdlet
    {
        private const string UpdateByNameParameterSet = "UpdateByNameParameterSet";
        private const string UpdateByInputObjectParameterSet = "UpdateByInputObjectParameterSet";
        private const string UpdateByResourceIdParameterSet = "UpdateByResourceIdParameterSet";

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.", ParameterSetName = UpdateByNameParameterSet)]
        [ResourceNameCompleter("Microsoft.Network/customIpPrefix", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.", ParameterSetName = UpdateByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The CustomIpPrefix to set.", ParameterSetName = UpdateByInputObjectParameterSet)]
        public PSCustomIpPrefix InputObject { get; set; }

        [Parameter(
                    Mandatory = true,
                    ValueFromPipelineByPropertyName = true,
                    HelpMessage = "The resource Id.", ParameterSetName = UpdateByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter Commission { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter Decomission { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable which represents resource tags.",
            ParameterSetName = UpdateByNameParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = UpdateByResourceIdParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = UpdateByInputObjectParameterSet)]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceInfo = new ResourceIdentifier(ResourceId);
                this.ResourceGroupName = resourceInfo.ResourceGroupName;
                this.Name = resourceInfo.ResourceName;
            }
            else if (this.IsParameterBound(c => c.InputObject))
            {
                this.ResourceGroupName = InputObject.ResourceGroupName;
                this.Name = InputObject.Name;
            }

            var existingResourcePsModel = GetCustomIpPrefix(this.ResourceGroupName, this.Name);
            if (existingResourcePsModel == null)
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            if (Commission && Decomission)
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.CommissioningStateConflict);
            }

            PSCustomIpPrefix customIpPrefixToUpdate = this.GetCustomIpPrefix(this.ResourceGroupName, this.Name);

            if (customIpPrefixToUpdate == null)
            {
                throw new PSArgumentException(Properties.Resources.ResourceNotFound, this.Name);
            }

            if (Commission || Decomission)
            {
                customIpPrefixToUpdate.CommissionedState = Commission ? "Commissioning" : "Decomissioning";
            }

            var sdkModel = NetworkResourceManagerProfile.Mapper.Map<MNM.CustomIpPrefix>(customIpPrefixToUpdate);

            if (this.IsParameterBound(c => c.InputObject))
            {
                sdkModel.Tags = TagsConversionHelper.CreateTagDictionary(this.IsParameterBound(c => c.Tag) ? this.Tag : InputObject.Tag, validate: true);
            }
            else
            {
                sdkModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);
            }

            if (this.ShouldProcess($"Name: {this.Name} ResourceGroup: {this.ResourceGroupName}", "Update existing CustomIpPrefix"))
            {
                // Execute the PUT MasterCustomIpPrefix Policy call
                this.CustomIpPrefixClient.CreateOrUpdate(this.ResourceGroupName, this.Name, sdkModel);

                var customIpPrefix = this.GetCustomIpPrefix(this.ResourceGroupName, this.Name);

                WriteObject(customIpPrefix);
            }
        }
    }
}
