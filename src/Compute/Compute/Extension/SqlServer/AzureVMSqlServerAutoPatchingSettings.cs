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

namespace Microsoft.Azure.Commands.Compute
{
    /// <summary>
    /// AutoPatching settings to configure auto-patching on SQL VM
    /// </summary>
    public class AutoPatchingSettings
    {
        /// <summary>
        /// Enable / Disable auto patching
        /// </summary>
        public bool Enable { get; set; }

        /// <summary>
        /// Day of the week
        /// </summary>
        public string DayOfWeek { get; set; }

        /// <summary>
        /// Maintainance Windows Start hour ( 0 to 23 ) 
        /// </summary>
        public int MaintenanceWindowStartingHour { get; set; }

        /// <summary>
        /// Maintainance window duration in minutes
        /// </summary>
        public int MaintenanceWindowDuration { get; set; }

        /// <summary>
        /// Patch category returned as string
        /// </summary>
        public string PatchCategory { get; set; }
    }
}
