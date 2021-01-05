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

using Microsoft.Azure.Commands.ContainerRegistry.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.ContainerRegistry.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ContainerRegistry.Commands
{
    [Cmdlet("Import", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ContainerRegistryImage", DefaultParameterSetName = ImportImageByResourceId, SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class ImportAzureContainerRegistryImage : ContainerRegistryCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "Resource group name.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Target registry name.")]
        [ValidateNotNullOrEmpty]
        public string RegistryName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Repository name of the source image.\r\nSpecify an image by repository ('hello-world'). This will use the 'latest' tag.\r\nSpecify an image by tag ('hello-world:latest').\r\nSpecify an image by sha256-based manifest digest ('hello-world@sha256:abc123').")]
        [ValidateNotNullOrEmpty]
        public string SourceImage { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ImportImageByResourceId, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource identifier of the source Azure Container Registry.")]
        [Parameter(Mandatory = true, ParameterSetName = ImportImageByResourceIdWithCredential, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource identifier of the source Azure Container Registry.")]
        [ValidateNotNullOrEmpty]
        public string SourceRegistryResourceId { get; set; }
        
        [Parameter(Mandatory = true, ParameterSetName = ImportImageByRegistryUri, ValueFromPipelineByPropertyName = true, HelpMessage = "The address of the source registry (e.g. 'mcr.microsoft.com').")]
        [Parameter(Mandatory = true, ParameterSetName = ImportImageByRegistryUriWithCredential, ValueFromPipelineByPropertyName = true, HelpMessage = "The address of the source registry (e.g. 'mcr.microsoft.com').")]
        [ValidateNotNullOrEmpty]
        public string SourceRegistryUri { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "When Force, any existing target tags will be overwritten. When NoForce, any existing target tags will fail the operation before any copying begins.")]
        [ValidateSet("Force", "NoForce")]
        [ValidateNotNullOrEmpty]
        public string Mode { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "List of strings of the form repo[:tag]. When tag is omitted the source will be used (or 'latest' if source tag is also omitted).")]
        [ValidateNotNullOrEmpty]
        public string[] TargetTag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "List of strings of repository names to do a manifest only copy. No tag will be created.")]
        [ValidateNotNullOrEmpty]
        public string[] UntaggedTargetRepository { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ImportImageByRegistryUriWithCredential, HelpMessage = "The username to authenticate with the source registry.")]
        [Parameter(Mandatory = false, ParameterSetName = ImportImageByResourceIdWithCredential, HelpMessage = "The username to authenticate with the source registry.")]
        [ValidateNotNullOrEmpty]
        public string Username { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ImportImageByRegistryUriWithCredential, HelpMessage = "The password used to authenticate with the source registry.")]
        [Parameter(Mandatory = true, ParameterSetName = ImportImageByResourceIdWithCredential, HelpMessage = "The password used to authenticate with the source registry.")]
        [ValidateNotNullOrEmpty]
        public string Password { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!this.IsParameterBound(c => c.TargetTag))
            {
                int index = SourceImage.IndexOf('@');
                this.TargetTag = new string[] { index > 0 ? SourceImage.Substring(0, index) : SourceImage};

            }

            PSImportImageParameters parameter = new PSImportImageParameters(source: new PSImportSource(sourceImage: SourceImage,
                                                                                                       resourceId: SourceRegistryResourceId,
                                                                                                       registryUri: SourceRegistryUri,
                                                                                                       credentials: this.IsParameterBound(c => c.Password) ? new PSImportSourceCredentials(Username, Password) : null), 
                                                                            targetTags: new List<string>(TargetTag), 
                                                                            untaggedTargetRepositories: this.IsParameterBound(c => c.UntaggedTargetRepository) ?  new List<string>(UntaggedTargetRepository) : null, 
                                                                            mode: Mode);

            if (ShouldProcess(RegistryName, "Import image"))
            {
                RegistryClient.ImportImage(ResourceGroupName, RegistryName, parameter);
                WriteObject(true);
            }
        }
    }
}
