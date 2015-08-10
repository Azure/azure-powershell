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

using Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PowershellCore;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PIRCmdletInfo
{
    public class NewAzurePlatformComputeImageConfigCmdletInfo : CmdletsInfo
    {
        public NewAzurePlatformComputeImageConfigCmdletInfo(string offer, string sku, string version)
        {
            this.cmdletName = Utilities.NewAzurePlatformComputeImageConfigCmdletName;

            if (!string.IsNullOrEmpty(offer))
            {
                this.cmdletParams.Add(new CmdletParam("Offer", offer));
            }

            if (!string.IsNullOrEmpty(sku))
            {
                this.cmdletParams.Add(new CmdletParam("Sku", sku));
            }

            if (!string.IsNullOrEmpty(version))
            {
                this.cmdletParams.Add(new CmdletParam("Version", version));
            }
        }
    }

    public class NewAzurePlatformMarketplaceImageConfigCmdletInfo : CmdletsInfo
    {
        public NewAzurePlatformMarketplaceImageConfigCmdletInfo(string planName, string product, string publisher, string publisherId)
        {
            this.cmdletName = Utilities.NewAzurePlatformMarketplaceImageConfigCmdletName;

            if (!string.IsNullOrEmpty(planName))
            {
                this.cmdletParams.Add(new CmdletParam("PlanName", planName));
            }

            if (!string.IsNullOrEmpty(product))
            {
                this.cmdletParams.Add(new CmdletParam("Product", product));
            }

            if (!string.IsNullOrEmpty(publisher))
            {
                this.cmdletParams.Add(new CmdletParam("Publisher", publisher));
            }

            if (!string.IsNullOrEmpty(publisherId))
            {
                this.cmdletParams.Add(new CmdletParam("PublisherId", publisherId));
            }
        }
    }

    public class SetAzurePlatformVMImageCmdletInfo : CmdletsInfo
    {
        public SetAzurePlatformVMImageCmdletInfo(string imageName, string permission, string [] locations)
        {
            this.cmdletName = Utilities.SetAzurePlatformVMImageCmdletName;
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

        public SetAzurePlatformVMImageCmdletInfo(string imageName, string permission, string[] locations, ComputeImageConfig compCfg, MarketplaceImageConfig marketCfg)
        {
            this.cmdletName = Utilities.SetAzurePlatformVMImageCmdletName;
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
