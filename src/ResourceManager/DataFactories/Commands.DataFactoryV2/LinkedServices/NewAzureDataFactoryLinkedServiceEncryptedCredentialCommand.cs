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

using System;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Globalization;
using Microsoft.Azure.Commands.DataFactoryV2.Properties;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    [Cmdlet(VerbsCommon.New, Constants.LinkedServiceEncryptedCredential, DefaultParameterSetName = ParameterSetNames.ByFactoryName, SupportsShouldProcess = true),
        OutputType(typeof(string))]
    public class NewAzureDataFactoryLinkedServiceEncryptedCredentialCommand : DataFactoryContextBaseCmdlet
    {
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpIntegrationRuntimeName)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObject, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpIntegrationRuntimeName)]
        [ValidateNotNullOrEmpty]
        public string IntegrationRuntimeName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryName, Position = 3, Mandatory = true,
            HelpMessage = Constants.HelpJsonFilePath)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryObject, Position = 2, Mandatory = true,
            HelpMessage = Constants.HelpJsonFilePath)]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.File)]
        public string DefinitionFile { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.HelpDontAskConfirmation)]
        public SwitchParameter Force { get; set; }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            ByFactoryObject();

            // ValidationNotNullOrEmpty doesn't handle whitespaces well
            if (IntegrationRuntimeName.IsEmptyOrWhiteSpace())
            {
                throw new PSArgumentNullException("IntegrationRuntimeName");
            }

            string rawJsonContent = DataFactoryClient.ReadJsonFileContent(this.TryResolvePath(DefinitionFile));
            string encrypted = null;

            ConfirmAction(
                Force.IsPresent,
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.EncryptConfirm),
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.Encrypting),
                DefinitionFile,
                () =>
                {
                    encrypted = DataFactoryClient.IntegrationRuntimeEncryptCredential(ResourceGroupName, DataFactoryName, IntegrationRuntimeName, rawJsonContent);
                });

            WriteObject(encrypted);
        }
    }
}
