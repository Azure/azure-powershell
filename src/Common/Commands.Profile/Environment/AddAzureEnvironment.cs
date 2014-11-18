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

using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.WindowsAzure.Commands.Common.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Profile;
using System.Collections.Generic;
using System;

namespace Microsoft.WindowsAzure.Commands.Profile
{


    /// <summary>
    /// Adds a new Microsoft Azure environment.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "AzureEnvironment"), OutputType(typeof(AzureEnvironment))]
    public class AddAzureEnvironmentCommand : SubscriptionCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        [Parameter(Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string PublishSettingsFileUrl { get; set; }

        [Parameter(Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string ServiceEndpoint { get; set; }

        [Parameter(Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string ManagementPortalUrl { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = "The storage endpoint")]
        public string StorageEndpoint { get; set; }

        [Parameter(Position = 5, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The URI for the Active Directory service for this environment")]
        public string ActiveDirectoryEndpoint { get; set; }

        [Parameter(Position = 6, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The cloud service endpoint")]
        public string ResourceManagerEndpoint { get; set; }

        [Parameter(Position = 7, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The public gallery endpoint")]
        public string GalleryEndpoint { get; set; }

        [Parameter(Position = 8, Mandatory = false, ValueFromPipelineByPropertyName = true, 
            HelpMessage = "Identifier of the target resource that is the recipient of the requested token.")]
        public string ActiveDirectoryServiceEndpointResourceId { get; set; }

        [Parameter(Position = 9, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The AD Graph Endpoint.")]
        public string GraphEndpoint { get; set; }

        public AddAzureEnvironmentCommand() : base(true) { }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            var newEnvironment = new AzureEnvironment {Name = Name};
            newEnvironment.Endpoints[AzureEnvironment.Endpoint.PublishSettingsFileUrl] = PublishSettingsFileUrl;
            newEnvironment.Endpoints[AzureEnvironment.Endpoint.ServiceManagement] = ServiceEndpoint;
            newEnvironment.Endpoints[AzureEnvironment.Endpoint.ResourceManager] = ResourceManagerEndpoint;
            newEnvironment.Endpoints[AzureEnvironment.Endpoint.ManagementPortalUrl] = ManagementPortalUrl;
            newEnvironment.Endpoints[AzureEnvironment.Endpoint.StorageEndpointSuffix] = StorageEndpoint;
            newEnvironment.Endpoints[AzureEnvironment.Endpoint.ActiveDirectory] = ActiveDirectoryEndpoint;
            newEnvironment.Endpoints[AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId] = ActiveDirectoryServiceEndpointResourceId;
            newEnvironment.Endpoints[AzureEnvironment.Endpoint.Gallery] = GalleryEndpoint;
            newEnvironment.Endpoints[AzureEnvironment.Endpoint.Graph] = GraphEndpoint;

            ProfileClient.AddOrSetEnvironment(newEnvironment);
            List<object> args = new List<object> { "Name", newEnvironment.Name };
            foreach (AzureEnvironment.Endpoint property in Enum.GetValues(typeof(AzureEnvironment.Endpoint)))
            {
                args.AddRange(new object[] { property, newEnvironment.GetEndpoint(property) });
            }
            WriteObject(base.ConstructPSObject(null, args.ToArray()));
        }
    }
}