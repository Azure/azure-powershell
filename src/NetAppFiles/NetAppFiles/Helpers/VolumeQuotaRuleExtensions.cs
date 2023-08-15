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

using Azure.Core;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using Microsoft.Azure.Management.NetApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.Commands.NetAppFiles.Helpers
{
    public static class VolumeQuotaRuleExtensions
    {
        public static PSNetAppFilesVolumeQuotaRule ConvertToPs(this VolumeQuotaRule volumeQuotaRule)
        {
            var psNetAppFilesVolumeQuotaRule = new PSNetAppFilesVolumeQuotaRule()
            {
                Id = volumeQuotaRule.Id,
                Location = volumeQuotaRule.Location,
                Name = volumeQuotaRule.Name,
                Tags = volumeQuotaRule.Tags,
                Type = volumeQuotaRule.Type,
                ResourceGroupName = new ResourceIdentifier(volumeQuotaRule.Id).ResourceGroupName,                
                ProvisioningState = volumeQuotaRule.ProvisioningState.ToString(),
                QuotaSize = volumeQuotaRule.QuotaSizeInKiBs,
                QuotaTarget = volumeQuotaRule.QuotaTarget,
                QuotaType = volumeQuotaRule.QuotaType
            };
            return psNetAppFilesVolumeQuotaRule;
        }

        public static List<PSNetAppFilesVolumeQuotaRule> ConvertToPS(this List<VolumeQuotaRule> volumeQuotaRulesList)
        {
            return volumeQuotaRulesList.Select(e => e.ConvertToPs()).ToList();
        }
    }
}
