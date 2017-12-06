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
using System.Security.Permissions;
using Microsoft.Azure.Commands.DataFactoryV2.Models;
using Microsoft.Azure.Commands.DataFactoryV2.Properties;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.Rest.Serialization;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    [Cmdlet(
        VerbsData.Update,
        Constants.IntegrationRuntime,
        DefaultParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
        SupportsShouldProcess = true),
     OutputType(typeof(PSSelfHostedIntegrationRuntimeStatus))]
    public class UpdateAzureDataFactoryIntegrationRuntimeCommand : IntegrationRuntimeCmdlet
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeAutoUpdate)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.IntegrationRuntimeAutoUpdateEnabled,
            Constants.IntegrationRuntimeAutoUpdateDisabled,
            IgnoreCase = true)]
        public string AutoUpdate { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.HelpIntegrationRuntimeAutoUpdateTime)]
        [ValidateNotNull]
        public TimeSpan? AutoUpdateDelayOffset { get; set; }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            this.ByResourceId();
            this.ByIntegrationRuntimeObject();

            if (AutoUpdate == null && !AutoUpdateDelayOffset.HasValue)
            {
                throw new PSArgumentException("No valid parameters.");
            }

            IntegrationRuntimeResource resource = DataFactoryClient.GetIntegrationRuntimeAsync(
                    ResourceGroupName,
                    DataFactoryName,
                    base.Name).ConfigureAwait(true).GetAwaiter().GetResult().IntegrationRuntime;
            WriteVerbose("Got integration runtime");

            Action updateIntegrationRuntime = () =>
            {
                var request = new UpdateIntegrationRuntimeRequest();
                if (!string.IsNullOrEmpty(AutoUpdate))
                {
                    request.AutoUpdate = AutoUpdate;
                }
                WriteVerbose("Handled AutoUpdate");

                if (AutoUpdateDelayOffset.HasValue)
                {
                    request.UpdateDelayOffset = SafeJsonConvert.SerializeObject(
                        AutoUpdateDelayOffset.Value,
                        DataFactoryClient.DataFactoryManagementClient.SerializationSettings);

                    WriteVerbose(request.UpdateDelayOffset);
                }

                WriteVerbose("Handled AutoUpdateDelayOffset");
                WriteObject(DataFactoryClient.UpdateIntegrationRuntimeAsync(ResourceGroupName,
                    DataFactoryName,
                    Name,
                    resource,
                    request).ConfigureAwait(false).GetAwaiter().GetResult());
            };

            ConfirmAction(
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IntegrationRuntimeUpdating,
                    Name,
                    DataFactoryName),
                Name,
                updateIntegrationRuntime);
        }
    }
}
