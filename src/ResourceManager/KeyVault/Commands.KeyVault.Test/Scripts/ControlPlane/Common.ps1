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
Gets the location for the Vault. Default to West US if none found.
#>
function Get-Location
{
	if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::GetCurrentMode() -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
	{
		$namespace = "Microsoft.KeyVault"  
		$type = "vaults"
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

<#
.SYNOPSIS
Gets the default location for a provider
#>
function Get-ProviderLocation($provider)
{
	if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::GetCurrentMode() -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
	{
		$namespace = $provider.Split("/")[0]  
		if($provider.Contains("/"))  
		{  
			$type = $provider.Substring($namespace.Length + 1)  
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

	return "East US"
}
