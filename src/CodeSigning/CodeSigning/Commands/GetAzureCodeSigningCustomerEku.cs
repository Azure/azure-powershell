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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Runtime.InteropServices;
using System.Security;

namespace Microsoft.Azure.Commands.CodeSigning
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzurePrefix + "CodeSigningCustomerEku", DefaultParameterSetName = ByAccountProfileNameParameterSet)]
    [OutputType(typeof(string))]
    public class GetAzureCodeSigningCustomerEku : CodeSigningCmdletBase
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
        #endregion

        public override void ExecuteCmdlet()
        {
            string eku;

            if (!string.IsNullOrEmpty(AccountName))
            {
                eku = CodeSigningServiceClient.GetCodeSigningEku(AccountName, ProfileName, EndpointUrl);
                WriteEku(eku);
            }
            else if (!string.IsNullOrEmpty(MetadataFilePath))
            { 
                eku = CodeSigningServiceClient.GetCodeSigningEku(MetadataFilePath);
                WriteEku(eku);
            }
        }

        private void WriteEku(string eku)
        {
            WriteObject(eku.Split(','));
        }
    }
}
