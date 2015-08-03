﻿// ----------------------------------------------------------------------------------
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

using Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PowershellCore;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PIRCmdletInfo
{
    public class SetAzurePlatformExtensionCmdletInfo : CmdletsInfo
    {
        public SetAzurePlatformExtensionCmdletInfo(string imageName, string permission, string [] locations)
        {
            this.cmdletName = Utilities.SetAzurePlatformExtensionCmdletName;
            this.cmdletParams.Add(new CmdletParam("ImageName", imageName));
            if (permission != null)
            {
                this.cmdletParams.Add(new CmdletParam("Permission", permission));
            }
            if (locations != null)
            {
                this.cmdletParams.Add(new CmdletParam("ReplicaLocations", locations));
            }
        }

        public SetAzurePlatformExtensionCmdletInfo(string imageName, string permission, string[] locations, ComputeImageConfig compCfg, MarketplaceImageConfig marketCfg)
        {
            this.cmdletName = Utilities.SetAzurePlatformExtensionCmdletName;
            this.cmdletParams.Add(new CmdletParam("ImageName", imageName));

            if (permission != null)
            {
                this.cmdletParams.Add(new CmdletParam("Permission", permission));
            }

            if (locations != null)
            {
                this.cmdletParams.Add(new CmdletParam("ReplicaLocations", locations));
            }

            if (compCfg != null)
            {
                this.cmdletParams.Add(new CmdletParam("PlatformComputeImageConfig", compCfg));
            }

            if (marketCfg != null)
            {
                this.cmdletParams.Add(new CmdletParam("PlatformMarketplaceImageConfig", marketCfg));
            }
        }
    }
}
