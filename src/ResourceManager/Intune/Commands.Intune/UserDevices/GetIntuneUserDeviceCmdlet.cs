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

namespace Microsoft.Azure.Commands.Intune
{
    using System.Management.Automation;
    using Management.Intune;
    using Management.Intune.Models;
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>
    /// Cmdlet to get apps for User.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmIntuneUserApp"), OutputType(typeof(PSObject))]
    public sealed class GetIntuneUserDeviceCmdlet : IntuneBaseCmdlet
    {
        /// <summary>
        /// Gets the Devices Name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The Device name to fetch.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets the User name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The User name for the Devices to fetch.")]
        [ValidateNotNullOrEmpty]
        public string Username { get; set; }

        /// <summary>
        /// Contains the cmdlet's execution logic.
        /// </summary>
        protected override void ProcessRecord()
        {
           if (Name != null)
            {
                GetUserDeviceByName();
            }
            else
            {
                GetUserDevices();
            }
        }

        /// <summary>
        /// Get GetUserDevice by device name.
        /// </summary>
        private void GetUserDeviceByName()
        {
            var device = this.IntuneClient.GetMAMUserDeviceByDeviceName(this.AsuHostName, this.Username, this.Name, select: null);

            this.WriteObject(device);
        }

        /// <summary>
        /// Get all GetUserDevices
        /// </summary>
        private void GetUserDevices()
        {
            MultiPageGetter<Device> mpg = new MultiPageGetter<Device>();

            List<Device> items = mpg.GetAllResources(
                this.IntuneClient.GetMAMUserDevices,
                this.IntuneClient.GetMAMUserDevicesNext,
                this.AsuHostName,
                this.Username,
                filter: null,
                top: null,
                select: null);

            this.WriteObject(items, enumerateCollection: true);
        }
    }
}
