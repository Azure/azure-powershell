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

$ServerIdLookup = @{}
$ServerIdLookup["Test-NewRegisteredServerParentObject"] = "aa86ff9c-6191-4145-b7e2-fd674a7a60b4"
$ServerIdLookup["Test-NewRegisteredServerParentResourceId"] = "b218026d-45d4-4e0e-94c1-7101e0c19e71"
$ServerIdLookup["Test-RegisteredServer"] = @("251c5af7-25f5-48e0-9cea-a1ce5332c552","edb903a8-b51e-49a9-8841-0401ab326144", "a259e889-a9c7-422d-b1b8-d5fdfa338f98")
$ServerIdLookup["Test-RemoveRegisteredServer"] = "ae80a828-ffaf-4b91-8b4b-241a5a611bb1"
$ServerIdLookup["Test-RemoveRegisteredServerInputObject"] = "c0b9056c-27fd-4bc3-abaf-ca7913a87c17"
$ServerIdLookup["Test-RemoveRegisteredServerResourceId"] = "9bd2a8e3-dcb8-49ac-a4f1-4de5f53e0a09"
$ServerIdLookup["Test-GetRegisteredServer"] = "80cbc767-51b0-49de-9378-a0105ea0e660"
$ServerIdLookup["Test-GetRegisteredServerParentObject"] = "c1198372-7618-4d59-933c-caf09ec5a84b"
$ServerIdLookup["Test-GetRegisteredServerParentResourceId"] = "1628499e-0616-4181-afd1-dd8906700527"
$ServerIdLookup["Test-GetRegisteredServers"] = "88fa2470-8afa-424b-823e-0d33687f4d77"
$ServerIdLookup["Test-NewRegisteredServer"] = "66a8e786-2f91-4552-b802-ecca80b95ac7"
$ServerIdLookup["Test-ServerEndpoint"] = "83cb0baf-db95-4b95-9eea-1a9d88d49c41"

<#
.SYNOPSIS
Gets test mode - 'Record' or 'Playback'
#>
function Get-StorageTestMode {
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
Cleans the created resource groups
#>
function Clean-ResourceGroup($rgname)
{
    if ((Get-StorageTestMode) -ne 'Playback') {
        Remove-AzResourceGroup -Name $rgname -Force
    }
}

######################
#
# Retry the given code block until it succeeds or times out.
#
#    param [ScriptBlock] $script : The code to test
#    param [int] $times          : The times of running the code
#    param [string] $message     : The text of the exception that should be thrown
#######################
function Retry-IfException
{
    param([ScriptBlock] $script, [int] $times = 30, [string] $message = "*")

    if ($times -le 0)
    {
        throw 'Retry time(s) should not be equal to or less than 0.';
    }

    $oldErrorActionPreferenceValue = $ErrorActionPreference;
    $ErrorActionPreference = "SilentlyContinue";

    $iter = 0;
    $succeeded = $false;
    while (($iter -lt $times) -and (-not $succeeded))
    {
        $iter += 1;

        try
        {
            &$script;
        }
        catch
        {

        }

        if ($Error.Count -gt 0)
        {
            $actualMessage = $Error[0].Exception.Message;

            Write-Output ("Caught exception: '$actualMessage'");

            if (-not ($actualMessage -like $message))
            {
                $ErrorActionPreference = $oldErrorActionPreferenceValue;
                throw "Expected exception not received: '$message' the actual message is '$actualMessage'";
            }

            $Error.Clear();
            Wait-Seconds 10;
            continue;
        }

        $succeeded = $true;
    }

    $ErrorActionPreference = $oldErrorActionPreferenceValue;
}

<#
.SYNOPSIS
Gets random resource name
#>
function Get-RandomItemName
{
    param([string] $prefix = "pslibtest")
    
    if ($prefix -eq $null -or $prefix -eq '')
    {
        $prefix = "pslibtest";
    }

    $str = $prefix + (([guid]::NewGuid().ToString() -replace '-','')[0..9] -join '');
    return $str;
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
Gets valid resource name
#>
function Get-ResourceName($prefix)
{
    return $prefix + (getAssetName)
}

<#
.SYNOPSIS
Gets valid resource name for compute test
#>
function Get-StorageManagementTestResourceName
{
    $stack = Get-PSCallStack
    $testName = $null;
    foreach ($frame in $stack)
    {
        if ($frame.Command.StartsWith("Test-", "CurrentCultureIgnoreCase"))
        {
            $testName = $frame.Command;
        }
    }
    
    try
    {
        $assetName = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::GetAssetName($testName, "pstestrg")
    }
    catch
    {
        if ($PSItem.Exception.Message -like '*Unable to find type*')
        {
            $assetName = Get-RandomItemName;
        }
        else
        {
            throw;
        }
    }

    return $assetName
}

<#
.SYNOPSIS
Gets the default location for a provider
#>
function Get-StorageSyncLocation($provider)
{
    $defaultLocation = "West Central US"
    if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
    {
        $namespace = $provider.Split("/")[0]
        if($provider.Contains("/"))
        {
            $type = $provider.Substring($namespace.Length + 1)
            $location = Get-AzResourceProvider -ProviderNamespace $namespace | where {$_.ResourceTypes[0].ResourceTypeName -eq $type}

            if ($location -eq $null)
            {
                return $defaultLocation
            } else
            {
                return $location.Locations[0].ToLower() -replace '\s',''
            }
        }

        return $defaultLocation
    }

    return $defaultLocation
}

<#
.SYNOPSIS
Gets the Canary location for a provider
#>
function Get-StorageSyncLocation_Canary($provider)
{
    "eastus2euap"
}


<#
.SYNOPSIS
Gets the Stage location for a provider
#>
function Get-StorageSyncLocation_Stage($provider)
{
    "eastus2(stage)"
}

<#
.SYNOPSIS
Normalize Location
#>
function Normalize-Location($location)
{
    if(-not [string]::IsNullOrEmpty($location))
    {
        return $location.ToLower().Replace(" ", "") 
    }

    return $location
}

<#
.SYNOPSIS
is running live in target environment
#>
function IsLive
{
    return [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback
}