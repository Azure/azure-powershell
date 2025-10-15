// -----------------------------------------------------------------------------
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
// -----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.Azure.Commands.Batch.Utils;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class PSOSDisk
    {
        internal Management.Batch.Models.OSDisk toMgmtOSDisk()
        {
            OSDisk osDisk = new OSDisk();
            osDisk.ManagedDisk = this.ManagedDisk?.ToMgmtManagedDisk();
            osDisk.DiskSizeGb = this.DiskSizeGB;
            osDisk.EphemeralOSDiskSettings = this.EphemeralOSDiskSettings?.ToMgmtEphemeralOSDiskSettings();
            osDisk.Caching =  Utils.Utils.toMgmtCaching(this.Caching);
            osDisk.WriteAcceleratorEnabled = this.WriteAcceleratorEnabled;

            return osDisk;
        }

        internal static PSOSDisk fromMgmtOSDisk(Management.Batch.Models.OSDisk osDisk)
        {
            if (osDisk == null)
            {
                return null;
            }


            PSOSDisk psOSDisk = new PSOSDisk();
            psOSDisk.ManagedDisk = PSManagedDisk.FromMgmtManagedDisk(osDisk.ManagedDisk);
            psOSDisk.DiskSizeGB = osDisk.DiskSizeGb;
            psOSDisk.EphemeralOSDiskSettings = PSDiffDiskSettings.FromMgmtDiffDiskSettings(osDisk.EphemeralOSDiskSettings);
            psOSDisk.Caching = Utils.Utils.fromMgmtCaching(osDisk.Caching);
            psOSDisk.WriteAcceleratorEnabled = osDisk.WriteAcceleratorEnabled;

            return psOSDisk;
        }
    }
}
