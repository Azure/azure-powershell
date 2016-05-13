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
Gets a resource group name for testing.
#>
function Get-ResourceGroupName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets a commitment plan name for testing.
#>
function Get-CommitmentPlanName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets a web service name for testing.
#>
function Get-WebServiceName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets the default location for a provider
#>
function Get-ProviderLocation($providerNamespace, $resourceType)
{
	if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
	{
		$provider = Get-AzureRmResourceProvider -ProviderNamespace $providerNamespace
		$resourceType = $provider.ResourceTypes | where {$_.ResourceTypeName -eq $resourceType}
  		if ($resourceType -eq $null) 
		{  
			return "southcentralus"  
		} else 
		{  
			return $resourceType.Locations[0]  
		} 
	}

	return "southcentralus"
}

<#
.SYNOPSIS
Gets the latest API Version for the resource type
#>
function Get-ProviderAPIVersion($providerNamespace, $resourceType)
{ 
    $provider = Get-AzureRmResourceProvider -ProviderNamespace $providerNamespace
	$resourceType = $provider.ResourceTypes | where {$_.ResourceTypeName -eq $resourceType}
	return $resourceType.ApiVersions[$resourceType.ApiVersions.Count -1]
}

<#
.SYNOPSIS
Cleans the website
#>
function Clean-WebService($resourceGroup, $webServiceName)
{
    if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback) 
	{
		$result = Remove-AzureRmMlWebService -ResourceGroupName $resourceGroup.ToString() -WebsiteName $websiteName.ToString() -Force
    }
}

<#
.SYNOPSIS
Cleans the created resource groups
#>
function Clean-ResourceGroup($rgname)
{
    if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback) {
        Remove-AzureRmResourceGroup -Name $rgname -Force
    }
}