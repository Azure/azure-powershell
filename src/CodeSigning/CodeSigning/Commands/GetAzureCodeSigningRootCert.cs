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

using Microsoft.Azure.Commands.CodeSigning.Helpers;
using Microsoft.Azure.Commands.CodeSigning.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Azure.Commands.CodeSigning
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzurePrefix + "CodeSigningRootCert", DefaultParameterSetName = ByAccountProfileNameParameterSet)]
    [OutputType(typeof(string))]
    public class GetAzureCodeSigningRootCert : CodeSigningCmdletBase
    {
        #region Parameter Set Names

        private const string ByAccountProfileNameParameterSet = "ByAccountProfileNameParameterSet";
        private const string ByMetadataFileParameterSet = "ByMetadataFileParameterSet";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// Account Profile name
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ByAccountProfileNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The account name of Azure CodeSigning.")]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = ByAccountProfileNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The certificate profile name of Azure CodeSigning account.")]
        [ValidateNotNullOrEmpty()]
        public string ProfileName { get; set; }
        [Parameter(Mandatory = true,
            ParameterSetName = ByAccountProfileNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The endpoint url used to submit request to Azure CodeSigning.")]
        public string EndpointUrl { get; set; }


        /// <summary>
        /// Metadata File Path
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = ByMetadataFileParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Metadata File path. Cmdlet constructs the FQDN of an account profile based on the Metadata File and currently selected environment.")]
        [ValidateNotNullOrEmpty]
        public string MetadataFilePath { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = ByAccountProfileNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Downloaded Root Cert file full path, including file name")]
        [Parameter(Mandatory = true,
            ParameterSetName = ByMetadataFileParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Downloaded Root Cert file full path, including file name")]
        [ValidateNotNullOrEmpty]
        public string Destination { get; set; }
        #endregion

        public override void ExecuteCmdlet()
        {
            Stream rootcert;

            if (!string.IsNullOrEmpty(AccountName))
            {
                rootcert = CodeSigningServiceClient.GetCodeSigningRootCert(AccountName, ProfileName, EndpointUrl);
                WriteRootCert(rootcert);
            }
            else if (!string.IsNullOrEmpty(MetadataFilePath))
            {
                rootcert = CodeSigningServiceClient.GetCodeSigningRootCert(MetadataFilePath);
                WriteRootCert(rootcert);
            }
        }
        private void WriteRootCert(Stream rootcert)
        {
            var downloadPath = ResolvePath(Destination);

            var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write);
            rootcert.CopyTo(fileStream);
            fileStream.Dispose();

            //read thumbprint and subject namme
            byte[] rawData = File.ReadAllBytes(downloadPath);
            X509Certificate2 x509 = new X509Certificate2(rawData);

            WriteObject(downloadPath.Replace("\\", @"\"));

            PSSigningCertificate pscert = new PSSigningCertificate();
            pscert.Subject = x509.Subject;
            pscert.Thumbprint = x509.Thumbprint;

            WriteObject(pscert, false);
        }
    }   
}
