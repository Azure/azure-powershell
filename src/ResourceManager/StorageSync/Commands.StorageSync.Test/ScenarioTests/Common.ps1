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
$ServerIdLookup["Test-NewRegisteredServerParentObject"] = "cc1acdd7-9ba4-48e8-9a2b-d11d51fdb9a8"
$ServerIdLookup["Test-NewRegisteredServerParentResourceId"] = "9c9bbf76-6b9e-41ae-ac25-62a5fa0ee87c"
$ServerIdLookup["Test-RegisteredServer"] = @("6e47b502-766b-4609-977a-f54f3d2a1414","b0116785-567e-43d6-bccd-c875b0dc0e88", "d80a603c-e0ef-40b2-84e3-8ef6216ac2df")
$ServerIdLookup["Test-RemoveRegisteredServer"] = "411bd5fb-1aee-4604-8c57-22b4b548e7d8"
$ServerIdLookup["Test-RemoveRegisteredServerInputObject"] = "57f039df-4cce-42c7-9efa-e1229d4a3c7b"
$ServerIdLookup["Test-RemoveRegisteredServerResourceId"] = "408b1927-a310-492e-9c0a-ef9fcb44c321"
$ServerIdLookup["Test-GetRegisteredServer"] = "63495a03-9831-4ece-bc24-b6aede400488"
$ServerIdLookup["Test-GetRegisteredServerParentObject"] = "dd71fe90-f292-4b64-85a8-355843a75149"
$ServerIdLookup["Test-GetRegisteredServerParentResourceId"] = "0afd78e3-5df8-440d-b33a-632443cee1ce"
$ServerIdLookup["Test-GetRegisteredServers"] = "ff26f36b-cd82-43f4-a26b-94c86820a552"
$ServerIdLookup["Test-NewRegisteredServer"] = "4136bfec-4873-48da-93a9-65a8019c7ce7"
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
        Remove-AzureRMResourceGroup -Name $rgname -Force
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
            $location = Get-AzureRmResourceProvider -ProviderNamespace $namespace | where {$_.ResourceTypes[0].ResourceTypeName -eq $type}

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