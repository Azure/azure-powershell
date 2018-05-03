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

namespace Microsoft.Azure.Commands.Management.IotHub
{
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Management.IotHub.Common;
    using Microsoft.Azure.Commands.Management.IotHub.Models;
    using Microsoft.Azure.Management.IotHub;
    using Microsoft.Azure.Management.IotHub.Models;
    using ResourceManager.Common.ArgumentCompleters;

    [Cmdlet(VerbsCommon.Get, "AzureRmIotHubCertificateVerificationCode", DefaultParameterSetName = ResourceParameterSet)]
    [OutputType(typeof(PSCertificateWithNonceDescription))]
    [Alias("Get-AzureRmIotHubCVC")]
    public class GetAzureRmIotHubCertificateVerificationCode : IotHubBaseCmdlet
    {
        private const string ResourceIdParameterSet = "ResourceIdSet";
        private const string ResourceParameterSet = "ResourceSet";
        private const string InputObjectParameterSet = "InputObjectSet";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Certificate Object")]
        [ValidateNotNullOrEmpty]
        public PSCertificateDescription InputObject { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Resource Group")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Certificate Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = ResourceParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Iot Hub")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ParameterSetName = ResourceParameterSet,
            HelpMessage = "Name of the Certificate")]
        [ValidateNotNullOrEmpty]
        public string CertificateName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "Etag of the Certificate")]
        [Parameter(
            Position = 3,
            Mandatory = true,
            ParameterSetName = ResourceParameterSet,
            HelpMessage = "Etag of the Certificate")]
        [ValidateNotNullOrEmpty]
        public string Etag { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(InputObjectParameterSet))
            {
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.Name = this.InputObject.Name;
                this.CertificateName = this.InputObject.CertificateName;
                this.Etag = this.InputObject.Etag;
            }

            if (ParameterSetName.Equals(ResourceIdParameterSet))
            {
                this.ResourceGroupName = IotHubUtils.GetResourceGroupName(this.ResourceId);
                this.Name = IotHubUtils.GetIotHubName(this.ResourceId);
                this.CertificateName = IotHubUtils.GetIotHubCertificateName(this.ResourceId);
            }

            CertificateWithNonceDescription certificateWithNonceDescription = this.IotHubClient.Certificates.GenerateVerificationCode(this.ResourceGroupName, this.Name, this.CertificateName, this.Etag);
            this.WriteObject(IotHubUtils.ToPSCertificateWithNonceDescription(certificateWithNonceDescription));
        }
    }
}

