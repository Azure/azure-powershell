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
using System.IO;
using System.Management.Automation;
using System.Xml.Linq;

namespace Microsoft.Azure.Commands.CodeSigning
{
    [Cmdlet(VerbsLifecycle.Invoke, ResourceManager.Common.AzureRMConstants.AzurePrefix + "CodeSigningCIPolicySigning", DefaultParameterSetName = ByAccountProfileNameParameterSet)]
    [OutputType(typeof(string))]
    public class InvokeCIPolicySigning : CodeSigningCmdletBase
    {
        #region Parameter Set Names

        private const string ByAccountProfileNameParameterSet = "ByAccountProfileNameParameterSet";
        private const string ByMetadataFileParameterSet = "ByMetadataFileParameterSet";
        /// <summary>
        /// The root element inside an SI Policy XML file.
        /// </summary>
        private static readonly XName SiPolicyRootElementName = XName.Get("SiPolicy", "urn:schemas-microsoft-com:sipolicy");

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
            ValidateFileType(ResolvePath(Path));


            WriteMessage("CI Policy signing in progress....");

            if (!string.IsNullOrEmpty(AccountName))
            {
                CodeSigningServiceClient.SubmitCIPolicySigning(AccountName, ProfileName, EndpointUrl, ResolvePath(Path), ResolvePath(Destination), TimeStamperUrl);
            }
            else if (!string.IsNullOrEmpty(MetadataFilePath))
            {
                CodeSigningServiceClient.SubmitCIPolicySigning(MetadataFilePath, ResolvePath(Path), ResolvePath(Destination), TimeStamperUrl);
            }

            WriteMessage("CI Policy is successfully signed. " + ResolvePath(Destination));
        }
        private void WriteMessage(string message)
        {
            WriteObject(message);
        }

        private void ValidateFileType(string fullInPath)
        {
            if (string.Equals(System.IO.Path.GetExtension(fullInPath), ".bin", StringComparison.OrdinalIgnoreCase))
            {
                WriteMessage(Environment.NewLine);
                WriteMessage("CI Policy file submitted");
            }
            else
            {
                // Is this an XML policy file?
                // We can display a better error message here.
                XDocument doc;
                try
                {
                    var fullInContents = File.ReadAllBytes(fullInPath);
                    doc = XmlUtil.SafeLoadXDocument(fullInContents);
                }
                catch
                {
                    doc = null;
                }

                if (doc?.Root.Name == SiPolicyRootElementName)
                {
                    WriteWarning("Input file is an XML-based policy file.");
                    WriteWarning("Please run 'ConvertFrom-CiPolicy' to create a .bin file before running this command.");
                }

                try
                {
                    throw new InvalidOperationException($"File '{fullInPath}' is of a type that cannot be signed.");
                }
                catch (Exception ex)
                {
                    throw new TerminatingErrorException(ex, ErrorCategory.InvalidData);
                }
            }
        }
    }
}
