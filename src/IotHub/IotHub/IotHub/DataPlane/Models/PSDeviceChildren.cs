﻿// Copyright Microsoft Corporation
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

namespace Microsoft.Azure.Commands.Management.IotHub.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Child devices of an edge device.
    /// </summary>

    public class PSDeviceChildren
    {
        /// <summary>
        /// Edge Device ID.
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// Non-edge Device Id.
        /// </summary>
        public IList<string> ChildrenDeviceId { get; set; }
    }

    public class PSDevicesChildren : PSDeviceChildren
    { }
}
