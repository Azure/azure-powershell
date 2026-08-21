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
using Microsoft.Azure.Management.ServiceFabricManagedClusters.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Models
{
    public class PSManagedMaintenanceWindowStatus
    {
        public PSManagedMaintenanceWindowStatus(ManagedMaintenanceWindowStatus status)
        {
            IsWindowEnabled = status.IsWindowEnabled;
            IsWindowActive = status.IsWindowActive;
            CanApplyUpdates = status.CanApplyUpdates;
            LastWindowStatusUpdateAtUtc = status.LastWindowStatusUpdateAtUtc;
            LastWindowStartTimeUtc = status.LastWindowStartTimeUtc;
            LastWindowEndTimeUtc = status.LastWindowEndTimeUtc;
        }

        public bool? IsWindowEnabled { get; }
        public bool? IsWindowActive { get; }
        public bool? CanApplyUpdates { get; }
        public DateTime? LastWindowStatusUpdateAtUtc { get; }
        public DateTime? LastWindowStartTimeUtc { get; }
        public DateTime? LastWindowEndTimeUtc { get; }
    }
}
