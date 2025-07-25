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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.Network.Models.NetworkManager;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerManagementGroupConnection", SupportsShouldProcess = true), OutputType(typeof(PSNetworkManagerConnection))]
    public class NewAzNetworkManagerManagementGroupConnectionCommand : NetworkManagerManagementGroupConnectionBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The management group ID.")]
        public virtual string ManagementGroupId { get; set; }

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
           HelpMessage = "Network Manager Id of the resource you'd like to manage.")]
        public string NetworkManagerId { get; set; }

        [Parameter(
         Mandatory = false,
         ValueFromPipelineByPropertyName = true,
         HelpMessage = "Description.")]
        public virtual string Description { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background.")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource.")]
        public SwitchParameter Force { get; set; }

        public override void Execute()
        {
            base.Execute();
            var present = this.IsNetworkManagerManagementGroupConnectionPresent(this.ManagementGroupId, this.Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var networkManagerManagementGroupConnection = this.CreateNetworkManagerManagementGroupConnection();
                    WriteObject(networkManagerManagementGroupConnection);
                },
                () => present);
        }

        private PSNetworkManagerConnection CreateNetworkManagerManagementGroupConnection()
        {
            var mncc = new PSNetworkManagerConnection();
            mncc.NetworkManagerId = this.NetworkManagerId;

            if (!string.IsNullOrEmpty(this.Description))
            {
                mncc.Description = this.Description;
            }

            // Map to the sdk object
            var mnccModel = NetworkResourceManagerProfile.Mapper.Map<MNM.NetworkManagerConnection>(mncc);
            this.NullifyNetworkManagerManagementGroupConnectionIfAbsent(mnccModel);

            // Execute the Create NetworkManagerManagementGroupConnection call
            this.NetworkManagerManagementGroupConnectionClient.CreateOrUpdate(this.ManagementGroupId, this.Name, mnccModel);
            var psNetworkManagerManagementGroupConnection = this.GetNetworkManagerManagementGroupConnection(this.ManagementGroupId, this.Name);
            return psNetworkManagerManagementGroupConnection;
        }
    }
}
