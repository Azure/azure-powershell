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
Gets valid resource group name
#>
function Get-ResourceGroupName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets valid resource name
#>
function Get-ResourceName
{
    return "AzTest" + (getAssetName)
}

<#
.SYNOPSIS
Gets a valid storage account resource id
#>
function Get-StorageResourceId($rgname, $resourcename)
{
    $subscription = (Get-AzureRMSubscription -Default).SubscriptionId
    return "/subscriptions/$subscription/resourcegroups/$rgname/providers/microsoft.storage/storageaccounts/$resourcename"
}

<#
.SYNOPSIS
Gets the default location for Operational Insights
#>
function Get-ProviderLocation()
{
    $location = Get-AzureRMLocation | where {$_.Name -eq "Microsoft.OperationalInsights\workspaces"}
    if ($location -eq $null) {
        "East US"
    } else {
        $location.Locations[0]
    }
}
