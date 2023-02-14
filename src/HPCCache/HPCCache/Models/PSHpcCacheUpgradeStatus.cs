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

namespace Microsoft.Azure.PowerShell.Cmdlets.HPCCache.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using StorageCacheModels = Microsoft.Azure.Management.StorageCache.Models;

    /// <summary>
    /// Cache upgrade status.
    /// </summary>
    public class PSHpcCacheUpgradeStatus
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSHpcCacheUpgradeStatus"/> class.
        /// </summary>
        /// <param name="upgradeStatus">Cache upgrade status object.</param>
        public PSHpcCacheUpgradeStatus(StorageCacheModels.CacheUpgradeStatus upgradeStatus)
        {
            this.CurrentFirmwareVersion = upgradeStatus.CurrentFirmwareVersion;
            this.FirmwareUpdateStatus = upgradeStatus.FirmwareUpdateStatus;
            this.FirmwareUpdateDeadline = upgradeStatus.FirmwareUpdateDeadline;
            this.LastFirmwareUpdate = upgradeStatus.LastFirmwareUpdate;
            this.PendingFirmwareVersion = upgradeStatus.PendingFirmwareVersion;
        }

        /// <summary>
        /// Gets version string of the firmware currently installed on this Cache.
        /// </summary>
        public string CurrentFirmwareVersion { get; private set; }

        /// <summary>
        /// Gets or sets true if there is a firmware update ready to install on this Cache. The firmware
        /// will automatically be installed after firmwareUpdateDeadline if not triggered
        /// earlier via the upgrade operation. Possible values include: 'available', 'unavailable'.
        /// </summary>
        public string FirmwareUpdateStatus { get; set; }

        /// <summary>
        /// Gets or sets time at which the pending firmware update will automatically be installed
        /// on the Cache.
        /// </summary>
        public DateTime? FirmwareUpdateDeadline { get; set; }

        /// <summary>
        /// Gets or Sets time of the last successful firmware update.
        /// </summary>
        public DateTime? LastFirmwareUpdate { get; set; }

        /// <summary>
        /// Gets or Sets when firmwareUpdateAvailable is true, this field holds the version string
        /// for the update.
        /// </summary>
        public string PendingFirmwareVersion { get; set; }
    }
}
