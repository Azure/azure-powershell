
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
using Microsoft.Azure.Commands.DataFactoryV2.Properties;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    [Cmdlet(VerbsLifecycle.Stop,
        Constants.IntegrationRuntime,
        DefaultParameterSetName = ParameterSetNames.ByIntegrationRuntimeName,
        SupportsShouldProcess = true)]
    public class StopAzureDataFactoryIntegrationRuntimeCommand : IntegrationRuntimeCmdlet
    {
        [Parameter(Mandatory = false,
            HelpMessage = Constants.HelpDontAskConfirmation)]
        public SwitchParameter Force { get; set; }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            this.ByResourceId();
            this.ByIntegrationRuntimeObject();

            Action stopIntegrationRuntime = () =>
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                var task = Task.Run(() =>
                {
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

                    this.DataFactoryClient.StopIntegrationRuntimeAsync(
                        ResourceGroupName,
                        DataFactoryName,
                        Name).ConfigureAwait(true).GetAwaiter().GetResult();
                }, cancellationTokenSource.Token);

                UpdateProgress(task, new ProgressRecord(1, "Stop", "Stopping Progress"));
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
                    Resources.IntegrationRuntimeStopping,
                    Name,
                    DataFactoryName),
                Name,
                stopIntegrationRuntime,
                () => this.DataFactoryClient.CheckIntegrationRuntimeExistsAsync(
                    ResourceGroupName,
                    DataFactoryName,
                    Name).ConfigureAwait(true).GetAwaiter().GetResult());
        }
    }
}