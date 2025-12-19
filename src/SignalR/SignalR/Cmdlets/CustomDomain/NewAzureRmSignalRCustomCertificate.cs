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
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.SignalR.Models;
using Microsoft.Azure.Commands.SignalR.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.SignalR.Models;

namespace Microsoft.Azure.Commands.SignalR.Cmdlets
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SignalRCustomCertificate", SupportsShouldProcess = true, DefaultParameterSetName = ResourceGroupParameterSet)]
    [OutputType(typeof(PSCustomCertificateResource))]
    public class NewAzureRmSignalRCustomCertificate : SignalRCmdletBase, ISignalRChildResource
    {
        [Parameter(Mandatory = false, ParameterSetName = ResourceGroupParameterSet, HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceGroupParameterSet, HelpMessage = "The SignalR service name.")]
        [ResourceNameCompleter(Constants.SignalRResourceType, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty()]
        public string SignalRName { get; set; }

        [Parameter(Mandatory = true, Position = 0, HelpMessage = "The custom certificate name.")]
        [ValidateNotNullOrEmpty()]
        [ResourceNameCompleter(Constants.SignalRCustomCertificateResourceType, nameof(ResourceGroupName), nameof(SignalRName))]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Base URI of the KeyVault that stores certificate.")]
        [ValidateNotNullOrEmpty()]
        public string KeyVaultBaseUri { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Certificate secret name.")]
        [ValidateNotNullOrEmpty()]
        public string KeyVaultSecretName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Certificate secret version.")]
        public string KeyVaultSecretVersion { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SignalRObjectParameterSet, ValueFromPipeline = true, HelpMessage = "The SignalR resource object.")]
        [ValidateNotNull]
        public PSSignalRResource SignalRObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run the cmdlet in background job.")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            RunCmdlet(() =>
            {
                switch (ParameterSetName)
                {
                    case ResourceGroupParameterSet:
                        ResolveResourceGroupName();
                        break;
                    case SignalRObjectParameterSet:
                        var signalRResourceId = new ResourceIdentifier(SignalRObject.Id);
                        ResourceGroupName = signalRResourceId.ResourceGroupName;
                        SignalRName = signalRResourceId.ResourceName;
                        break;
                    default:
                        throw new ArgumentException(Resources.ParameterSetError);
                }

                if (ShouldProcess($"SignalR custom certificate {ResourceGroupName}/{SignalRName}/{Name}", "create"))
                {
                    var cert = new CustomCertificate(KeyVaultBaseUri, KeyVaultSecretName, keyVaultSecretVersion: KeyVaultSecretVersion);
                    var result = Microsoft.Azure.Management.SignalR.SignalRCustomCertificatesOperationsExtensions.CreateOrUpdate(Client.SignalRCustomCertificates, ResourceGroupName, SignalRName, Name, cert);
                    WriteObject(new PSCustomCertificateResource(result));
                }
            });
        }
    }
}
