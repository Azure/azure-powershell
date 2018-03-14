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

namespace Microsoft.Azure.Commands.Management.DeviceProvisioningServices
{
    using System;
    using System.Management.Automation;
    using Azure.Management.DeviceProvisioningServices;
    using Microsoft.Azure.Commands.DeviceProvisioningServices.Properties;
    using Microsoft.Azure.Commands.Management.DeviceProvisioningServices.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.DeviceProvisioningServices.Models;

    [Cmdlet(VerbsCommon.Get, "AzureRmIotDeviceProvisioningServiceCertificateVerificationCode", DefaultParameterSetName = ResourceParameterSet)]
    [OutputType(typeof(PSVerificationCodeResponse))]
    [Alias("Get-AzureRmIotDpsCVC")]
    public class GetAzureRmIotDeviceProvisioningServiceCertificateVerificationCode : IotDpsBaseCmdlet
    {
        private const string ResourceParameterSet = "ResourceSet";
        private const string InputObjectParameterSet = "InputObjectSet";
        private const string ResourceIdParameterSet = "ResourceIdSet";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "IoT Device Provisioning Service Certificate Object")]
        [ValidateNotNullOrEmpty]
        public PSCertificateResponse InputObject { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "IoT Device Provisioning Service Certificate Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Resource Group")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = ResourceParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the IoT Device Provisioning Service")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ParameterSetName = ResourceParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Iot device provisioning service certificate")]
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
            switch (ParameterSetName)
            {
                case InputObjectParameterSet:
                    this.ResourceGroupName = this.InputObject.ResourceGroupName;
                    this.Name = this.InputObject.Name;
                    this.CertificateName = this.InputObject.CertificateName;
                    this.Etag = this.InputObject.Etag;
                    this.GetIotDpsCertificateVerificationCode();
                    break;

                case ResourceIdParameterSet:
                    this.ResourceGroupName = IotDpsUtils.GetResourceGroupName(this.ResourceId);
                    this.Name = IotDpsUtils.GetIotDpsName(this.ResourceId);
                    this.CertificateName = IotDpsUtils.GetIotDpsCertificateName(this.ResourceId);
                    this.GetIotDpsCertificateVerificationCode();
                    break;

                case ResourceParameterSet:
                    this.GetIotDpsCertificateVerificationCode();
                    break;

                default:
                    throw new ArgumentException("BadParameterSetName");
            }
        }

        private void GetIotDpsCertificateVerificationCode()
        {
            try
            {
                VerificationCodeResponse verificationCodeResponse = this.IotDpsClient.DpsCertificate.GenerateVerificationCode(this.CertificateName, this.Etag, this.ResourceGroupName, this.Name);
                this.WriteObject(IotDpsUtils.ToPSVerificationCodeResponse(verificationCodeResponse));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}


