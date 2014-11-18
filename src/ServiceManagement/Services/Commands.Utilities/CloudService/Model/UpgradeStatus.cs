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

namespace Microsoft.WindowsAzure.Commands.Utilities.CloudService.Model
{
    public class UpgradeStatus
    {
        public UpgradeStatus()
        {
            
        }

        public UpgradeStatus(Management.Compute.Models.UpgradeStatus status)
        {
            UpgradeType = status.UpgradeType.ToString();
            CurrentUpgradeDomainState = status.CurrentUpgradeDomainState.ToString();
            CurrentUpgradeDomain = status.CurrentUpgradeDomain;
        }

        public string UpgradeType { get; set; }
        public string CurrentUpgradeDomainState { get; set; }
        public int CurrentUpgradeDomain { get; set; }
    }
}
