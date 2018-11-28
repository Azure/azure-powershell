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
    param([string] $prefix = [string]::Empty)

	return getAssetName $prefix
}

<#
.SYNOPSIS
Gets valid resource name
#>
function Get-ResourceName
{
    param([string] $prefix = [string]::Empty)

    return getAssetName $prefix
}

<#
.SYNOPSIS
Gets test mode - 'Record' or 'Playback'
#>
function Get-NetworkTestMode {
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
function Get-ProviderLocation($provider, $preferredLocation = "West Central US")
{
    if((Get-NetworkTestMode) -ne 'Playback')
    {
        if($env:AZURE_NRP_TEST_LOCATION)
        {
            return $env:AZURE_NRP_TEST_LOCATION;
        }
        if(-not $preferredLocation.Contains(" "))
        {
            # TODO: implement UseCanonical switch after PR is merged: https://github.com/Azure/azure-powershell-common/pull/90
            return $preferredLocation;
        }
        if($provider.Contains("/"))
        {
            $providerNamespace, $resourceType = $provider.Split("/");
            return Get-Location $providerNamespace $resourceType $preferredLocation;
        }
        else
        {
            return $preferredLocation;
        }
    }
    else
    {
        return $preferredLocation;
    }
}

<#
.SYNOPSIS
Cleans the created resource groups
#>
function Clean-ResourceGroup($rgname)
{
    if ((Get-NetworkTestMode) -ne 'Playback') {
        Remove-AzureRmResourceGroup -Name $rgname -Force
    }
}

<#
.SYNOPSIS
Sleeps but only during recording.
#>
function Start-TestSleep($milliseconds)
{
    if ((Get-NetworkTestMode) -ne 'Playback')
    {
        Start-Sleep -Milliseconds $milliseconds
    }
}
