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
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.DataFactoryV2.Models;
using Microsoft.Azure.Commands.DataFactoryV2.Properties;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    [Cmdlet(VerbsLifecycle.Start,
        Constants.IntegrationRuntime,
        DefaultParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
        SupportsShouldProcess = true),
        OutputType(typeof(PSManagedIntegrationRuntimeStatus))]
    public class StartAzureDataFactoryIntegrationRuntimeCommand : IntegrationRuntimeCmdlet
    {
        [Parameter(Mandatory = false,
            HelpMessage = Constants.HelpDontAskConfirmation)]
        public SwitchParameter Force { get; set; }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            this.ByResourceId();
            this.ByIntegrationRuntimeObject();

            // Set HttpClient timeout to 3 minutes. This is workaround for AMS return "Internal Server Error" issue
            // which will make the client call timeout due to retry.
            try
            {
                DataFactoryClient.DataFactoryManagementClient.HttpClient.Timeout = TimeSpan.FromMinutes(3);
            }
            catch (Exception)
            {
                // In case running the senario tests, HttpClient will complain it is not the first time running,
                // the property can't be changed. Just suppress the excetion.
            }

            var integrationRuntime = this.DataFactoryClient.GetIntegrationRuntimeAsync(
                ResourceGroupName,
                DataFactoryName,
                Name).ConfigureAwait(true).GetAwaiter().GetResult();

            Action startIntegrationRuntime = () =>
            {
                PSManagedIntegrationRuntimeStatus response = null;
                var cancellationTokenSource = new CancellationTokenSource();

                var task = Task.Run(() =>
                {
                    response = this.DataFactoryClient.StartIntegrationRuntimeAsync(
                        ResourceGroupName,
                        DataFactoryName,
                        Name,
                        integrationRuntime.IntegrationRuntime).ConfigureAwait(true).GetAwaiter().GetResult();
                }, cancellationTokenSource.Token);

                UpdateProgress(task, new ProgressRecord(1, "Start", "Starting Progress"));

                if (response != null)
                {
                    WriteObject(response);
                }
            };

            ConfirmAction(
                Force.IsPresent,
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IntegrationRuntimeExists,
                    Name,
                    DataFactoryName),
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IntegrationRuntimeStarting,
                    Name,
                    DataFactoryName),
                Name,
                startIntegrationRuntime);
        }
    }
}