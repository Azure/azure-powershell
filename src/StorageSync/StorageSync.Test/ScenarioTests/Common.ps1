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

# TODO : Remove this function once testfx do not mock the tenant in playback mode.
function Get-TenantId {

    $tenantId = $null
    if ((Get-StorageTestMode) -ne 'Playback') 
        {
            $tenantId = (Get-Azcontext).Tenant.Id
        }
        else 
        {
            $tenantId = "0483643a-cb2f-462a-bc27-1a270e5bdc0a"
        }
    return $tenantId
}

<#
.SYNOPSIS
Cleans the created resource groups
#>
function Clean-ResourceGroup($rgname)
{
    if ((Get-StorageTestMode) -ne 'Playback') {
        try 
        {
            Write-Verbose "Attempting to remove StorageSync resources from resource group $rgname"
            $syncServices = Get-AzStorageSyncService -ResourceGroup $rgname
            foreach ($syncService in $syncServices)
            {                
                Get-AzStorageSyncServer -ParentObject $syncService | Unregister-AzStorageSyncServer -Force
                
                $syncGroups = Get-AzStorageSyncGroup -ParentObject $syncService
                foreach ($syncGroup in $syncGroups)
                {
                    Get-AzStorageSyncCloudEndpoint -ParentObject $syncGroup | Remove-AzStorageSyncCloudEndpoint -Force
                }
                $syncGroups | Remove-AzStorageSyncGroup -Force
            }
            $syncServices | Remove-AzStorageSyncService -Force
        }
        catch
        {
            Write-Verbose "Exception $($_.Exception.ToString())"
        }
        Write-Verbose "Attempting to remove resource group $rgname"
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
    $defaultLocation = "Central US EUAP"
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
Gets the default location for a resource group
#>
function Get-ResourceGroupLocation()
{
    return Get-Location -providerNamespace "Microsoft.Resources"  -resourceType "resourceGroups" -preferredLocation "West US"
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

<#
.SYNOPSIS
Create Azure file share if recording else return given azure file share name.
#>
function Create-StorageShare
{
    param (
        [Parameter(Position = 0)]
        $Name, 
        [Parameter(Position = 1)]
        $Context)
    
    if ([string]::IsNullOrEmpty($Name))
    {
        throw "Invalid argument: Name"
    }

    if(IsLive)
    {
        if ($null -eq $Context)
        {
            throw "Invalid argument: Context"
        }

        $azureFileShare = $null
        if (gcm New-AzStorageShare -ErrorAction SilentlyContinue)
        {
            Write-Verbose "Using New-AzStorageShare cmdlet to create share: $($Name) in storage account: $($Context.StorageAccountName)"
            $azureFileShare = New-AzStorageShare -Name $Name -Context $Context
        }
        elseif (gcm New-AzureStorageShare -ErrorAction SilentlyContinue)
        {
            Write-Verbose "Using New-AzureStorageShare cmdlet to create share: $($Name) in storage account: $($Context.StorageAccountName)"
            $azureFileShare = New-AzureStorageShare -Name $Name -Context $Context            
        }
        else 
        {
            throw "Neither New-AzStorageShare nor New-AzureStorageShare cmdlet is available"
        }
        return $azureFileShare.Name
    }
    else 
    {
        return $azureFileShareName
    }
}

function Remove-StorageShare
{
    param (
        [Parameter(Position = 0)]
        $Name, 
        [Parameter(Position = 1)]
        $Context)
    
    if ([string]::IsNullOrEmpty($Name))
    {
        throw "Invalid argument: Name"
    }
    
    if(IsLive)
    {
        if ($null -eq $Context)
        {
            throw "Invalid argument: Context"
        }

        $result = $null
        if (gcm Remove-AzStorageShare -ErrorAction SilentlyContinue)
        {
            Write-Verbose "Using Remove-AzStorageShare cmdlet"
            $result = Remove-AzStorageShare -Name $Name -Context $Context -Force
        }
        elseif (gcm Remove-AzureStorageShare -ErrorAction SilentlyContinue)
        {
            Write-Verbose "Using Remove-AzureStorageShare cmdlet"
            $result = Remove-AzureStorageShare -Name $Name -Context $Context -Force
        }
        else 
        {
            throw "Neither Remove-AzStorageShare nor Remove-AzureStorageShare cmdlet is available"
        }
        return $result
    }
}

function Create-StorageContext
{
    param ($StorageAccountName, $StorageAccountKey)

    if ([string]::IsNullOrEmpty($StorageAccountName))
    {
        throw "Invalid argument: StorageAccountName"
    }

    if ([string]::IsNullOrEmpty($StorageAccountKey))
    {
        throw "Invalid argument: StorageAccountKey"
    }

    $result = $null

    if(IsLive)
    {
        if (gcm New-AzStorageContext -ErrorAction SilentlyContinue)
        {
            Write-Verbose "Using New-AzStorageContext cmdlet"
            $result = New-AzStorageContext -StorageAccountName $StorageAccountName -StorageAccountKey $StorageAccountKey -Protocol https -Endpoint core.windows.net
        }
        elseif (gcm New-AzureStorageContext -ErrorAction SilentlyContinue)
        {
            Write-Verbose "Using New-AzureStorageContext cmdlet"
            $result = New-AzureStorageContext -StorageAccountName $StorageAccountName -StorageAccountKey $StorageAccountKey -Protocol https -Endpoint core.windows.net
        }
        else 
        {
            throw "Neither New-AzStorageContext nor New-AzureStorageContext cmdlet is available"
        }
    }
    
    return $result
}