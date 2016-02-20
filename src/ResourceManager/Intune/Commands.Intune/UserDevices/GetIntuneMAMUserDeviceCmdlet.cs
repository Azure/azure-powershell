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
    /// Cmdlet to get Devices for MAM User.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmIntuneMAMUserDevice"), OutputType(typeof(List<Device>), typeof(Device))]
    public sealed class GetIntuneUserDeviceCmdlet : IntuneBaseCmdlet
    {
        /// <summary>
        /// Gets the User Name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the user to fetch the devices for.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets the Device name
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The device name for the user to fetch.")]
        [ValidateNotNullOrEmpty]
        public string DeviceName { get; set; }

        /// <summary>
        /// Contains the cmdlet's execution logic.
        /// </summary>
        public override void ExecuteCmdlet()
        {
           if (DeviceName != null)
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
            var device = this.IntuneClient.GetMAMUserDeviceByDeviceName(this.AsuHostName, this.Name, this.DeviceName, select: null);

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
                this.Name,
                filter: null,
                top: null,
                select: null);

            this.WriteObject(items, enumerateCollection: true);
        }
    }
}
