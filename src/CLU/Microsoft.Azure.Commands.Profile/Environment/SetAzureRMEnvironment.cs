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

using System;
using System.Globalization;
using System.Management.Automation;
using Microsoft.Azure.Commands.Models;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.Common;

namespace Microsoft.Azure.Commands.Profile
{
    /// <summary>
    /// Cmdlet to set Azure Environment in Profile.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmEnvironment")]
    [OutputType(typeof(PSAzureEnvironment))]
    [CliCommandAlias("env set")]
    public class SetAzureRMEnvironmentCommand : AzureRMCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Alias("n")]
        public string Name { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = "The storage endpoint")]
        [Alias("StorageEndpointSuffix", "storage")]
        public string StorageEndpoint { get; set; }

        [Parameter(Position = 5, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Active directory endpoint")]
        [Alias("AdEndpointUrl", "ActiveDirectory", "ActiveDirectoryAuthority", "ad")]
        public string ActiveDirectoryEndpoint { get; set; }

        [Parameter(Position = 6, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The cloud service endpoint")]
        [Alias("ResourceManager", "ResourceManagerUrl", "arm")]
        public string ResourceManagerEndpoint { get; set; }

        [Parameter(Position = 7, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The public gallery endpoint")]
        [Alias("Gallery", "GalleryUrl")]
        public string GalleryEndpoint { get; set; }

        [Parameter(Position = 8, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Identifier of the target resource that is the recipient of the requested token.")]
        [Alias("audience", "aud")]
        public string ActiveDirectoryServiceEndpointResourceId { get; set; }

        [Parameter(Position = 9, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The AD Graph Endpoint.")]
        [Alias("Graph", "GraphUrl")]
        public string GraphEndpoint { get; set; }

        [Parameter(Position = 16, Mandatory = false, ValueFromPipelineByPropertyName = true,
           HelpMessage = "Determines whether to enable ADFS authentication, or to use AAD authentication instead. This value is normally true only for Azure Stack endpoints.")]
        [Alias("OnPremise", "adfs")]
        public SwitchParameter EnableAdfsAuthentication { get; set; }

        [Parameter(Position = 17, Mandatory = false, ValueFromPipelineByPropertyName = true,
           HelpMessage = "The default tenant for this environment.")]
        public string AdTenant { get; set; }

        protected override void BeginProcessing()
        {
            // do not call begin processing there is no context needed for this cmdlet
        }


        protected override void ProcessRecord()
        {
            var profileClient = new RMProfileClient(AuthenticationFactory, ClientFactory, DefaultProfile);
            
            if ((Name == "AzureCloud") || 
                (Name == "AzureChinaCloud") ||
                (Name == "AzureUSGovernment"))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture,
                    "Cannot change built-in environment {0}.", Name));
            }

            var newEnvironment = new AzureEnvironment { Name = Name, OnPremise = EnableAdfsAuthentication };
            if (DefaultProfile.Environments.ContainsKey(Name))
            {
                newEnvironment = DefaultProfile.Environments[Name];
            }
            SetEndpointIfProvided(newEnvironment, AzureEnvironment.Endpoint.ResourceManager, ResourceManagerEndpoint);
            SetEndpointIfProvided(newEnvironment, AzureEnvironment.Endpoint.StorageEndpointSuffix, StorageEndpoint);
            SetEndpointIfProvided(newEnvironment, AzureEnvironment.Endpoint.ActiveDirectory, ActiveDirectoryEndpoint);
            SetEndpointIfProvided(newEnvironment, AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId, ActiveDirectoryServiceEndpointResourceId);
            SetEndpointIfProvided(newEnvironment, AzureEnvironment.Endpoint.Gallery, GalleryEndpoint);
            SetEndpointIfProvided(newEnvironment, AzureEnvironment.Endpoint.Graph, GraphEndpoint);
            SetEndpointIfProvided(newEnvironment, AzureEnvironment.Endpoint.AdTenant, AdTenant);

            profileClient.AddOrSetEnvironment(newEnvironment);

            WriteObject((PSAzureEnvironment)newEnvironment);
        }

        private void SetEndpointIfProvided(AzureEnvironment newEnvironment, AzureEnvironment.Endpoint endpoint, string property)
        {
            if (!string.IsNullOrEmpty(property))
            {
                newEnvironment.Endpoints[endpoint] = property;
            }
        }
    }
}
