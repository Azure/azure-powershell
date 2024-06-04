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
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.CodeSigning
{
    [Cmdlet(VerbsLifecycle.Invoke, ResourceManager.Common.AzureRMConstants.AzurePrefix + "CodeSigningPKCSSigning", DefaultParameterSetName = ByAccountProfileNameParameterSet)]
    [OutputType(typeof(string))]
    public class InvokePKCSSigning : CodeSigningCmdletBase
    {
        private const string ByAccountProfileNameParameterSet = "ByAccountProfileNameParameterSet";
        private const string ByMetadataFileParameterSet = "ByMetadataFileParameterSet";

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
            HelpMessage = "Metadata File path.")]
        [ValidateNotNullOrEmpty]
        public string MetadataFilePath { get; set; }

        //common parameters
        [Parameter(Mandatory = true,
           Position = 3,
           ParameterSetName = ByAccountProfileNameParameterSet,
            ValueFromPipelineByPropertyName = true,
           HelpMessage = "Original unsigned CI policy file path.")]
        [Parameter(Mandatory = true,
           Position = 1,
           ParameterSetName = ByMetadataFileParameterSet,
            ValueFromPipelineByPropertyName = true,
           HelpMessage = "Original unsigned CI policy file path.")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(Mandatory = true,
           ParameterSetName = ByAccountProfileNameParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Signed CI policy file path")]
        [Parameter(Mandatory = true,
           Position = 2,
           ParameterSetName = ByMetadataFileParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Signed CI policy file path")]
        [ValidateNotNullOrEmpty]
        public string Destination { get; set; }

        [Parameter(Mandatory = true,
           ParameterSetName = ByAccountProfileNameParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Object Identifier (OId)")]
        [Parameter(Mandatory = true,
           ParameterSetName = ByMetadataFileParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Object Identifier (OId)")]
        [ValidateNotNullOrEmpty]
        public string ContentType { get; set; }

        [Parameter(Mandatory = false,
           ParameterSetName = ByAccountProfileNameParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Specifies whether to detach the signature.")]
        [Parameter(Mandatory = false,
           ParameterSetName = ByMetadataFileParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Specifies whether to detach the signature.")]
        public SwitchParameter Detached { get; set; } = false;

        [Parameter(Mandatory = false,
                   ParameterSetName = ByAccountProfileNameParameterSet,
                    ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Time Stamper Url.")]
        [Parameter(Mandatory = false,
                   Position = 3,
                   ParameterSetName = ByMetadataFileParameterSet,
                    ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Time Stamper Url.")]
        public string TimeStamperUrl { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            ValidateContentType(ContentType);
            WriteObject("PKCS signing in progress...");

            if (!string.IsNullOrEmpty(AccountName))
            {
                CodeSigningServiceClient.SubmitPKCSSigning(AccountName, ProfileName, EndpointUrl, ResolvePath(Path), ResolvePath(Destination), ContentType, Detached.IsPresent, TimeStamperUrl);
            }
            else if (!string.IsNullOrEmpty(MetadataFilePath))
            {
                CodeSigningServiceClient.SubmitPKCSSigning(MetadataFilePath, ResolvePath(Path), ResolvePath(Destination), ContentType, Detached.IsPresent, TimeStamperUrl);
            }

            WriteObject("Command Executed Successfully. Signed PKCS envelope stored at " + ResolvePath(Destination));
        }

        private void ValidateContentType(string contentType)
        {
            if (string.IsNullOrEmpty(ContentType) || !IsValidOid(contentType))
            {
                try
                {
                    throw new InvalidOperationException($"Invalid content type '{contentType}'.");
                }
                catch (Exception ex)
                {
                    throw new TerminatingErrorException(ex, ErrorCategory.InvalidData);
                }
            }
        }

        private static bool IsValidOid(string oid)
        {
            // Regular expression for OID validation
            string oidPattern = @"^(0|1)\.(0|[1-9][0-9]?)|(2\.\d+)(\.\d+)*$";

            // Use Regex to check if the OID matches the pattern
            return Regex.IsMatch(oid, oidPattern);
        }
    }
}
