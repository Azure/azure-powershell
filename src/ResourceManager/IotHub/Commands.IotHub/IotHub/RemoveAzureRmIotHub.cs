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

namespace Microsoft.Azure.Commands.Management.IotHub
{
    using System;
    using System.Globalization;
    using System.Management.Automation;
    using Microsoft.Azure.Management.IotHub;
    using PSIotHubProperties = Microsoft.Azure.Commands.Management.IotHub.Properties;

    [Cmdlet(VerbsCommon.Remove, "AzureRmIotHub", SupportsShouldProcess = true)]
    public class RemoveAzureRmIotHub : IotHubBaseCmdlet
    {

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Resource Group")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Iot Hub")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// If present, do not ask for confirmation
        /// </summary>
        [Parameter(Mandatory = false,
           HelpMessage = "Indicates that the cmdlet does not prompt you for confirmation. By default, this cmdlet prompts you to confirm that you want to delete the IotHub.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                ConfirmAction(
                    Force.IsPresent,
                    string.Format(
                        CultureInfo.InvariantCulture,
                        PSIotHubProperties.Resources.RemoveIotHubWarning,
                        this.Name),
                    string.Format(
                        CultureInfo.InvariantCulture,
                        PSIotHubProperties.Resources.RemoveIotHubWhatIfMessage,
                        this.Name),
                    this.Name,
                    () =>
                    {
                        this.IotHubClient.IotHubResource.Delete(this.ResourceGroupName, this.Name);
                    });
            }
            catch (Exception e)
            {
                // This is because the underlying IotHubClient sdk currently throws an exception when it receives a 404 during the 
                // long running delete operation. Remove this once the sdk is fixed to handle this.

                if (!e.Message.Contains("NotFound"))
                {
                    throw e;
                }
            }

            this.WriteObject("Iot Hub Deleted");
        }
    }
}
