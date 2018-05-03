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
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Management.IotHub.Common;
    using Microsoft.Azure.Commands.Management.IotHub.Models;
    using Microsoft.Azure.Management.IotHub;
    using Microsoft.Azure.Management.IotHub.Models;
    using ResourceManager.Common.ArgumentCompleters;

    [Cmdlet(VerbsCommon.Get, "AzureRmIotHubCertificate", DefaultParameterSetName = ResourceParameterSet)]
    [OutputType(typeof(PSCertificateDescription), typeof(List<PSCertificate>))]
    public class GetAzureRmIotHubCertificate : IotHubBaseCmdlet
    {
        private const string ResourceIdParameterSet = "ResourceIdSet";
        private const string ResourceParameterSet = "ResourceSet";
        private const string InputObjectParameterSet = "InputObjectSet";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "IotHub Object")]
        [ValidateNotNullOrEmpty]
        public PSIotHub InputObject { get; set; }

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
            HelpMessage = "IotHub Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = ResourceParameterSet,
            HelpMessage = "Name of the Iot Hub")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Name of the Certificate")]
        [ValidateNotNullOrEmpty]
        public string CertificateName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(InputObjectParameterSet))
            {
                this.ResourceGroupName = this.InputObject.Resourcegroup;
                this.Name = this.InputObject.Name;
            }

            if (ParameterSetName.Equals(ResourceIdParameterSet))
            {
                this.ResourceGroupName = IotHubUtils.GetResourceGroupName(this.ResourceId);
                this.Name = IotHubUtils.GetIotHubName(this.ResourceId);
            }

            if (!string.IsNullOrEmpty(CertificateName))
            {
                CertificateDescription certificateDescription = this.IotHubClient.Certificates.Get(this.ResourceGroupName, this.Name, this.CertificateName);
                this.WriteObject(IotHubUtils.ToPSCertificateDescription(certificateDescription));
            }
            else
            {
                CertificateListDescription certificateDescriptions = this.IotHubClient.Certificates.ListByIotHub(this.ResourceGroupName, this.Name);
                if (certificateDescriptions.Value.Count == 1)
                {
                    this.WriteObject(IotHubUtils.ToPSCertificateDescription(certificateDescriptions.Value[0]));
                }
                else
                {
                    this.WriteObject(IotHubUtils.ToPSCertificates(certificateDescriptions), true);
                }
            }
        }
    }
}

