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

namespace Microsoft.Azure.Commands.NetAppFiles.Models
{
    /// <summary>
    /// ARM tracked resource
    /// </summary>
    public class PSNetAppFilesSnapshotPolicy
    {
        /// <summary>
        /// Gets or sets the Resource group name
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets Resource location
        /// </summary>
        public string Location { get; set; }
        
        /// <summary>
        /// Gets resource Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets resource name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets resource type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets resource etag
        /// </summary>
        /// <remarks>
        /// A unique read-only string that changes whenever the resource is updated.
        /// </remarks>
        public string Etag { get; set; }

        /// <summary>
        /// Gets or sets resource tags
        /// </summary>
        public object Tags { get; set; }

        /// <summary>
        /// Gets snapshotId
        /// </summary>
        /// <remarks>
        /// UUID v4 used to identify the Snapshot Policy
        /// </remarks>
        public string SnapshotPolicyId { get; set; }

        /// <summary>
        ///     Gets or sets hourlySchedule
        /// </summary>
        /// <remarks>
        ///     Schedule for hourly snapshots
        /// </remarks>
        public PSNetAppFilesHourlySchedule HourlySchedule { get; set; }

        /// <summary>
        ///     Gets or sets dailySchedule
        ///
        /// </summary>
        /// <remarks>
        ///     Schedule for daily snapshots
        /// </remarks>
        public PSNetAppFilesDailySchedule DailySchedule { get; set; }

        ///
        /// <summary>
        ///     Gets or sets weeklySchedule
        /// </summary>
        /// <remarks>
        ///     Schedule for weekly snapshots
        /// </remarks>
        public PSNetAppFilesWeeklySchedule WeeklySchedule { get; set; }

        /// <summary>
        ///     Gets or sets monthlySchedule
        /// </summary>
        /// <remarks>
        ///      Schedule for monthly snapshots
        /// </remarks>
        public PSNetAppFilesMonthlySchedule MonthlySchedule { get; set; }

        /// <summary>
        ///     Gets or sets the property to decide policy is enabled or not
        /// </summary>
        /// <remarks>
        /// The property to decide policy is enabled or not
        /// </remarks>
        public bool? Enabled { get; set; }

        /// <summary>
        /// Gets azure lifecycle management
        /// </summary>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets or sets System Data
        /// </summary>
        public PSSystemData SystemData { get; set; }
    }
}