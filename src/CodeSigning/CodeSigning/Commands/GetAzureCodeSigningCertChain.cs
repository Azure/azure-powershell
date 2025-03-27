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

using Microsoft.Azure.Commands.CodeSigning.Models;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Azure.Commands.CodeSigning
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzurePrefix + "CodeSigningCertChain", DefaultParameterSetName = ByAccountProfileNameParameterSet)]
    [OutputType(typeof(IEnumerable<PSSigningCertificate>))]
    public class GetAzureCodeSigningCertChain : CodeSigningCmdletBase
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
            Position = 0,
            ParameterSetName = ByAccountProfileNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The account name of Azure CodeSigning.")]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = ByAccountProfileNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The certificate profile name of Azure CodeSigning account.")]
        [ValidateNotNullOrEmpty()]
        public string ProfileName { get; set; }
        [Parameter(Mandatory = true,
            Position = 2,
            ParameterSetName = ByAccountProfileNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The endpoint url used to submit request to Azure CodeSigning.")]
        public string EndpointUrl { get; set; }


        /// <summary>
        /// Metadata File Path
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ByMetadataFileParameterSet,
             ValueFromPipelineByPropertyName = true,
            HelpMessage = "Metadata File path. Cmdlet constructs the FQDN of an account profile based on the Metadata File and currently selected environment.")]
        [ValidateNotNullOrEmpty]
        public string MetadataFilePath { get; set; }

        [Parameter(Mandatory = true,
          Position = 3,
          ParameterSetName = ByAccountProfileNameParameterSet,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "Downloaded Root Cert file full path, including file name")]
        [Parameter(Mandatory = true,
          Position = 1,
          ParameterSetName = ByMetadataFileParameterSet,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "Downloaded Root Cert file full path, including file name")]
        [ValidateNotNullOrEmpty]
        public string Destination { get; set; }
        #endregion

        public override void ExecuteCmdlet()
        {
            Stream certchain;

            if (!string.IsNullOrEmpty(AccountName))
            {
                certchain = CodeSigningServiceClient.GetCodeSigningCertChain(AccountName, ProfileName, EndpointUrl);
                WriteCertChain(certchain);
            }
            else if (!string.IsNullOrEmpty(MetadataFilePath))
            {
                certchain = CodeSigningServiceClient.GetCodeSigningCertChain(MetadataFilePath);
                WriteCertChain(certchain);
            }
        }

        private void WriteCertChain(Stream certchain)
        {
            var downloadPath = ResolvePath(Destination);

            var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write);
            certchain.CopyTo(fileStream);
            fileStream.Dispose();

            byte[] rawData = File.ReadAllBytes(downloadPath);

            var chain = new X509Certificate2Collection();
            chain.Import(rawData);

            WriteObject(downloadPath.Replace("\\", @"\"));

            var pschain = new List<PSSigningCertificate>();

            foreach (var cert in chain)
            {
                var pscert = new PSSigningCertificate()
                {
                    Issuer = cert.Issuer,
                    Subject = cert.Subject,
                    Thumbprint = cert.Thumbprint
                };

                pschain.Add(pscert);
            }

            WriteObject(pschain);
        }
    }
}
