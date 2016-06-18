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

using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    /// <summary>
    /// Helper cmdlet to construct instance of Storage settings class
    /// </summary>
    [Cmdlet(
         VerbsCommon.New,
        AzureRmVMSqlServerConfigNoun),
     OutputType(
         typeof(AzureVMSqlServerSettings))]
    public class NewAzureRmVMSqlServerConfig : PSCmdlet
    {
        protected const string AzureRmVMSqlServerConfigNoun = "AzureRmVMSqlServerConfig";

        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The imageOffer name.")]
        [ValidateNotNullOrEmpty]
        public string ImageOffer { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ImageOfferSku name.")]
        [ValidateNotNullOrEmpty]
        public string ImageOfferSku { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ImageVersion name.")]
        [ValidateNotNullOrEmpty]
        public string ImageVersion { get; set; }

        /// <summary>
        /// Creates and returns <see cref="AzureVMSqlServerSettings"/> object.
        /// </summary>
        protected override void ProcessRecord()
        {
            AzureVMSqlServerSettings azureVMSqlServerSettings = new AzureVMSqlServerSettings();
            azureVMSqlServerSettings.ImageOffer = ImageOffer;
            azureVMSqlServerSettings.ImageOfferSku = ImageOfferSku;
            azureVMSqlServerSettings.ImageVersion = ImageVersion;
            WriteObject(azureVMSqlServerSettings);
        }
    }
}