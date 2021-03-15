﻿# ----------------------------------------------------------------------------------
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
Subscription resource usage
#>
function Test-SubscriptionGetResourceUsage
{
    $subscriptionResourceUsage = Get-AzCdnSubscriptionResourceUsage

    Assert-True {$subscriptionResourceUsage.Count -eq 1}
	Assert-True {$subscriptionResourceUsage[0].CurrentValue -eq 96}
}

<#
.SYNOPSIS
Edge node
#>
function Test-SubscriptionEdgeNode
{
    $edgeNodes = Get-AzCdnEdgeNodes

    Assert-False {$edgeNodes -eq $null}
}