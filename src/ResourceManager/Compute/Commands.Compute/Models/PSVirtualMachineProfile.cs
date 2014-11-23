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
using System.Collections.Generic;
using System.Security;
using Microsoft.WindowsAzure;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Models
{
    /// <summary>
    /// Describes the properties of a Virtual Machine.
    /// </summary>
    public partial class PSVirtualMachineProfile
    {
        private HardwareProfile _hardwareProfile;

        /// <summary>
        /// Optional. The hardware profile.
        /// </summary>
        public HardwareProfile HardwareProfile
        {
            get { return this._hardwareProfile; }
            set { this._hardwareProfile = value; }
        }

        private NetworkProfile _networkProfile;

        /// <summary>
        /// Optional. The network profile.
        /// </summary>
        public NetworkProfile NetworkProfile
        {
            get { return this._networkProfile; }
            set { this._networkProfile = value; }
        }

        private OSProfile _oSProfile;

        /// <summary>
        /// Optional. The OS profile.
        /// </summary>
        public OSProfile OSProfile
        {
            get { return this._oSProfile; }
            set { this._oSProfile = value; }
        }

        private string _provisioningState;

        /// <summary>
        /// Optional. The provisioning state, which only appears in the
        /// response.
        /// </summary>
        public string ProvisioningState
        {
            get { return this._provisioningState; }
            set { this._provisioningState = value; }
        }

        private StorageProfile _storageProfile;

        /// <summary>
        /// Optional. The storage profile.
        /// </summary>
        public StorageProfile StorageProfile
        {
            get { return this._storageProfile; }
            set { this._storageProfile = value; }
        }

        /// <summary>
        /// Initializes a new instance of the VirtualMachineProperties class.
        /// </summary>
        public PSVirtualMachineProfile()
        {
        }
    }
}
