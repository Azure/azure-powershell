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
using System.Net;
using System.Security.Permissions;
using Microsoft.Azure.Commands.DataFactoryV2.Properties;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataFactoryV2IntegrationRuntime",DefaultParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,SupportsShouldProcess = true), OutputType(typeof(void))]
    public class RemoveAzureDataFactoryIntegrationRuntimeCommand : IntegrationRuntimeCmdlet
    {
        [Parameter(Mandatory = false,
            HelpMessage = Constants.HelpLinkedFactoryName)]
        [ValidateNotNullOrEmpty]
        public string LinkedDataFactoryName { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = Constants.HelpDontAskConfirmation)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            this.ByResourceId();
            this.ByIntegrationRuntimeObject();

            Action removeLinks = () => { ExecuteRemoveLinks(LinkedDataFactoryName); };

            ConfirmAction(
                Force.IsPresent,
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IntegrationRuntimeConfirmationMessage,
                    Name,
                    DataFactoryName),
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IntegrationRuntimeRemoving,
                    Name,
                    DataFactoryName),
                Name,
                string.IsNullOrWhiteSpace(LinkedDataFactoryName) ? ExecuteDelete : removeLinks);
        }

        private void ExecuteDelete()
        {
            var response = DataFactoryClient.DeleteIntegrationRuntimeAsync(
                ResourceGroupName,
                DataFactoryName,
                Name).ConfigureAwait(true).GetAwaiter().GetResult();

            if (response == HttpStatusCode.NoContent)
            {
                WriteWarning(string.Format(
                    CultureInfo.InvariantCulture, Resources.IntegrationRuntimeNotFound, Name, DataFactoryName));
            }
        }

        private void ExecuteRemoveLinks(string linkedDataFactoryName)
        {
            DataFactoryClient.RemoveIntegrationRuntimeLinksAsync(
                ResourceGroupName,
                DataFactoryName,
                Name,
                linkedDataFactoryName).ConfigureAwait(true).GetAwaiter().GetResult();
        }
    }
}
