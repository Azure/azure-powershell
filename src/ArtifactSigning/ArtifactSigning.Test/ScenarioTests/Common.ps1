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
Get Subscription ID
#>
function Get-SubscriptionID
{
    $context = Get-AzContext
    return $context.Subscription.SubscriptionId
}

<#
.SYNOPSIS
Get ResourceGroup name
#>
function Get-ResourceGroupName
{
    return "RGName-" + (getAssetName)
}

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
Create new ResourceGroup
#>
function New-ResourceGroup($ResourceGroupName, $Location)
{
    Write-Debug "Creating resource group name $ResourceGroupName in location $Location"
    New-AzResourceGroup -Name $ResourceGroupName -Location $Location -Force
}

<#
.SYNOPSIS
Remove ResourceGroup
#>
function Remove-ResourceGroup($ResourceGroupName)
{
    Write-Debug "Deleting resource group name $ResourceGroupName"
    Remove-AzResourceGroup -Name $ResourceGroupName -Force
}

<#
.SYNOPSIS
Gets valid resource name
#>
function Get-VaultName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets test mode - 'Record' or 'Playback'
#>
function Get-KeyVaultTestMode {
    try {
        $testMode = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode;
        $testMode = $testMode.ToString();
    } catch {
        if ($PSItem.Exception.Message -like '*Unable to find type*') {
            $testMode = 'Record';
        } else {
            throw;
        }
    }

    return $testMode
}

<#
.SYNOPSIS
Gets the default location for a provider
#>
function Get-ProviderLocation($provider)
{
	if ((Get-KeyVaultTestMode) -ne 'Playback')
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
				return $location.Locations[0]
			}
		}

		return "East US"
	}

	return "East US"
}

<#
.SYNOPSIS
Cleans the created resource groups
#>
function Clean-ResourceGroup($rgname)
{
    if ((Get-KeyVaultTestMode) -ne 'Playback') {
        Remove-AzResourceGroup -Name $rgname -Force
    }
}
