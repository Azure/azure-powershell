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

namespace Microsoft.Azure.Commands.Sql.Location_Capabilities.Model
{
    /// <summary>
    /// Represents a supported Azure SQL Database Maximum size
    /// </summary>
    public class MaxSizeRangeCapabilityModel
    {
        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        public MaxSizeCapabilityModel MinValue { get; set; }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        public MaxSizeCapabilityModel MaxValue { get; set; }

        /// <summary>
        /// Gets or sets the scale/step size for discrete values between the minimum value and the maximum value.
        /// </summary>
        public MaxSizeCapabilityModel ScaleSize { get; set; }

        /// <summary>
        /// Gets or sets the size of transaction log.
        /// </summary>
        public Management.Sql.Models.LogSizeCapability LogSize { get; set; }

        /// <summary>
        /// Gets or sets the status of capability. Possible values include:
        /// 'Visible', 'Available', 'Default', 'Disabled'
        /// </summary>
        public Management.Sql.Models.CapabilityStatus? Status { get; set; }
    }
}
