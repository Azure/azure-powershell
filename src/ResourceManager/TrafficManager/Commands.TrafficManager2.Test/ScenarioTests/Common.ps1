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
    return getAssetName
}

<#
.SYNOPSIS
Gets the default location for a provider
#>
function Get-ProviderLocation($provider)
{
	if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
	{
		$namespace = $provider.Split("/")[0]  
		if($provider.Contains("/"))  
		{  
			$type = $provider.Substring($namespace.Length + 1)  
			$location = Get-AzureRmResourceProvider -ProviderNamespace $namespace | where {$_.ResourceTypes[0].ResourceTypeName -eq $type}  
  
			if ($location -eq $null) 
			{  
				return "West US"  
			} else 
			{  
				return $location.Locations[0]  
			}  
		}
		
		return "West US"
	}

	return "WestUS"
}

<#
.SYNOPSIS
Creates a resource group to use in tests
#>
function TestSetup-CreateResourceGroup
{
    $resourceGroupName = getAssetName
	$rglocation = Get-ProviderLocation "North Europe"
    $resourceGroup = New-AzureRmResourceGroup -Name $resourceGroupName -location $rglocation -Force
	return $resourceGroup
}

<#
.SYNOPSIS
Creates a resource group to use in tests
#>
function TestSetup-CreateProfile($profileName, $resourceGroupName)
{
	$relativeName = getAssetName

	$profile = New-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroupName -RelativeDnsName $relativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" 

	return $profile
}

<#
.SYNOPSIS
Creates a resource group to use in tests
#>
function TestSetup-AddEndpoint($endpointName, $profile)
{
	$profile = Add-AzureRmTrafficManagerEndpointConfig -EndpointName $endpointName -TrafficManagerProfile $profile -Type "ExternalEndpoints" -Target "www.contoso.com" -EndpointStatus "Enabled" -EndpointLocation "North Europe"

	return $profile
}