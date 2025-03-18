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

using Microsoft.Azure.Commands.TrustedSigning.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.TrustedSigning
{
    [Alias("Get-" + ResourceManager.Common.AzureRMConstants.AzurePrefix + "CodeSigningCustomerEku")]
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzurePrefix + "TrustedSigningCustomerEku", DefaultParameterSetName = ByAccountProfileNameParameterSet)]
    [OutputType(typeof(string[]))]
    public class GetAzureTrustedSigningCustomerEku : CodeSigningCmdletBase
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
            HelpMessage = "The account name of Azure TrustedSigning.")]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = ByAccountProfileNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The certificate profile name of Azure TrustedSigning account.")]
        [ValidateNotNullOrEmpty()]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true,
            Position = 2,
            ParameterSetName = ByAccountProfileNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The endpoint url used to submit request to Azure TrustedSigning.")]
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

        #endregion

        public override void ExecuteCmdlet()
        {
            string[] eku = Array.Empty<string>();

            if (!string.IsNullOrEmpty(AccountName))
            {
                eku = CodeSigningServiceClient.GetCodeSigningEku(AccountName, ProfileName, EndpointUrl);
            }
            else if (!string.IsNullOrEmpty(MetadataFilePath))
            {
                eku = CodeSigningServiceClient.GetCodeSigningEku(MetadataFilePath);
            }

            WriteObject(eku);
        }
    }
}
