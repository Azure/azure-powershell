//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Commands
{
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models;
    using System;
    using System.IO;
    using System.Management.Automation;
    using System.Security.Cryptography.X509Certificates;

    [Cmdlet(VerbsCommon.Set, Constants.ApiManagementCertificate, DefaultParameterSetName = FromFile)]
    [OutputType(typeof(PsApiManagementCertificate))]
    public class SetAzureApiManagementCertificate : AzureApiManagementCmdletBase
    {
        private const string FromFile = "LoadFromFile";
        private const string Raw = "Raw";

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of certificate. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String CertificateId { get; set; }

        [Parameter(
            ParameterSetName = FromFile,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Path to the certificate file in .pfx format to be created/uploaded. " +
                          "This parameter is required if -PfxBytes not specified.")]
        public String PfxFilePath { get; set; }

        [Parameter(
            ParameterSetName = Raw,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Bytes of the certificate file in .pfx format to be created/uploaded. " +
                          "This parameter is required if -PfxFilePath not specified.")]
        public Byte[] PfxBytes { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Password for the certificate. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String PfxPassword { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "If specified then instance of " +
                          "Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementCertificate type " +
                          " representing the modified certificate.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            byte[] rawBytes;
            if (ParameterSetName.Equals(FromFile))
            {
                using (var certStream = File.OpenRead(PfxFilePath))
                {
                    rawBytes = new byte[certStream.Length];
                    certStream.Read(rawBytes, 0, rawBytes.Length);
                }
            }
            else if (ParameterSetName.Equals(Raw))
            {
                rawBytes = PfxBytes;
            }
            else
            {
                throw new InvalidOperationException(string.Format("Parameter set name '{0}' is not supported.", ParameterSetName));
            }

            // check for valid certificate file/bytes
            new X509Certificate2(rawBytes, PfxPassword);

            var certificate = Client.CertificateSet(Context, CertificateId, rawBytes, PfxPassword);
            if (PassThru)
            {
                WriteObject(certificate);
            }
        }
    }
}
