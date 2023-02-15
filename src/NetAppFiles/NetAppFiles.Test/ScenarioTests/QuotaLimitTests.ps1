# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
Test QuotaLimits
#>
function Test-QuotaLimit
{
    $resourceLocation = Get-ProviderLocation "Microsoft.NetApp"
    $quotaLimitName = "totalTiBsPerSubscription"
    try
    {        
        # get limits list 
        $retrievedLimits = Get-AzNetAppFilesQuotaLimit -Location $resourceLocation
        Assert-NotNull $retrievedLimits
        Assert-True {$retrievedLimits.Length -gt 0}

        # get limit by name 
        $retrievedLimit = Get-AzNetAppFilesQuotaLimit -Location $resourceLocation -Name $quotaLimitName 
        Assert-NotNull $retrievedLimit
        Assert-AreEqual "$resourceLocation/$quotaLimitName" $retrievedLimit.Name
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}
