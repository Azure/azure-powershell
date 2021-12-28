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
Gets a SignalR service name
#>
function Get-RandomSignalRName
{
	param([string]$prefix = "signalrps-test-")
	return $prefix + (getAssetName)
}

<#
.SYNOPSIS
Gets a resource group name
#>
function Get-RandomResourceGroupName
{
	param([string]$prefix = "signalrps-test-rg-")
	return $prefix + (getAssetName)
}

<#
.SYNOPSIS
Assert if two locations refer to the same region (lowercased, space removed)
#>
function Assert-LocationEqual
{
	param([string]$loc1, [string]$loc2)

	$loc1 = $loc1.ToLower().Replace(" ", "")
	$loc2 = $loc2.ToLower().Replace(" ", "")
	Assert-AreEqual $loc1 $loc2
}

<#
.SYNOPSIS
Gets the default location for a provider
#>
function Get-ProviderLocation([string]$provider)
{
	if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
	{
		$namespace = $provider.Split("/")[0]
		if($provider.Contains("/"))
		{
			$type = $provider.Substring($namespace.Length + 1)
			$location = Get-AzResourceProvider -ProviderNamespace $namespace | where {$_.ResourceTypes[0].ResourceTypeName -eq $type}

			if ($location -eq $null)
			{
				return "East US"
			}
			else
			{
				return $location.Locations[0].ToLower() -replace '\s',''
			}
		}

		return "East US"
	}

	return "East US"
}
