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
using System.Globalization;
using System.Management.Automation;
using Microsoft.Azure.Commands.DataFactoryV2.Models;
using Microsoft.Azure.Commands.DataFactoryV2.Properties;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    [Cmdlet(VerbsCommon.New,
        Constants.IntegrationRuntimeKey,
        DefaultParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
        SupportsShouldProcess = true),
        OutputType(typeof(PSIntegrationRuntimeKeys))]
    public class NewAzureDataFactoryIntegrationRuntimeKeyCommand : IntegrationRuntimeCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.HelpIntegrationRuntimeKeyName)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("AuthKey1", "AuthKey2", IgnoreCase = true)]
        public string KeyName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.HelpDontAskConfirmation)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            this.ByResourceId();
            this.ByIntegrationRuntimeObject();

            if (string.IsNullOrWhiteSpace(KeyName))
            {
                throw new PSArgumentNullException("KeyName");
            }

            PSIntegrationRuntimeKeys authKey = null;
            Action regenerateIntegrationRuntimeAuthKey = () =>
            {
                authKey = DataFactoryClient.RegenerateIntegrationRuntimeAuthKeyAsync(
                    ResourceGroupName,
                    DataFactoryName,
                    Name,
                    KeyName).ConfigureAwait(true).GetAwaiter().GetResult();
            };

            ConfirmAction(
                Force.IsPresent,
                // prompt only if the integration runtime exists
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.ContinueRegenerateAuthKey,
                    KeyName,
                    Name),
                // Process message, 
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.RegenerateAuthKey,
                    KeyName,
                    Name),
                // Target
                Name,
                regenerateIntegrationRuntimeAuthKey,
                () => DataFactoryClient.CheckIntegrationRuntimeExistsAsync(
                    ResourceGroupName,
                    DataFactoryName,
                    Name).ConfigureAwait(true).GetAwaiter().GetResult());

            WriteObject(authKey);
        }
    }
}
