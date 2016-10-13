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
Tests querying for Batch service quotas for the subscription at the specified region
#>
function Test-GetLocationQuotas
{
    $location = Get-BatchAccountProviderLocation
    $quotas = Get-AzureRmBatchLocationQuotas $location

    Assert-AreEqual $location $quotas.Location
    Assert-True { $quotas.AccountQuota -gt 0 }
}
