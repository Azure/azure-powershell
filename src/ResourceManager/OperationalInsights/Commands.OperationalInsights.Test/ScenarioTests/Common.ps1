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
    $subscription = (Get-AzureRmContext).Subscription.SubscriptionId
    return "/subscriptions/$subscription/resourcegroups/$rgname/providers/microsoft.storage/storageaccounts/$resourcename"
}

<#
.SYNOPSIS
Gets the default location for Operational Insights
#>
function Get-ProviderLocation()
{
	if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
	{
		$namespace = "Microsoft.OperationalInsights"  
		$type = "workspaces"
		$location = Get-AzureRmResourceProvider -ProviderNamespace $namespace | where {$_.ResourceTypes[0].ResourceTypeName -eq $type}  
  
		if ($location -eq $null) 
		{  
			return "East US"  
		} else 
		{  
			return $location.Locations[0]  
		}  
	}

	return "East US"
}
