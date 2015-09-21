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
Sets the default storage account
#>
function Set-CurrentStorageAccountName
{
    param([string] $storageAccountName)
    $currentSubscription = Get-AzureSubscription -Current

    Set-AzureSubscription -SubscriptionId $currentSubscription.SubscriptionId -CurrentStorageAccountName $storageAccountName
}

<#
.SYNOPSIS
Gets the default location
#>
function Get-DefaultLocation
{
    return (Get-AzureLocation)[0].Name
}

<#
.SYNOPSIS
Gets the default image
#>
function Get-DefaultImage
{
    param([string] $loc)
    return (Get-AzureVMImage | where {$_.OS -eq "Windows"} | where {$_.Location.Contains($loc)})[0].ImageName
}


<#
.SYNOPSIS
Gets valid and available cloud service name.
#>
function Get-CloudServiceName
{
    return getAssetName
}

<#
.SYNOPSIS
Cleanup cloud service
#>
function Cleanup-CloudService
{
    param([string] $name)
    try
    {
         Remove-AzureService -ServiceName $name -Force
    }
    catch
    {
         Write-Warning "Cannot Remove the Cloud Service"
    }
}

<#
.SYNOPSIS
Cleanup storage
#>
function Cleanup-Storage
{
    param([string] $name)
    Remove-AzureStorageAccount -StorageAccountName $name
    try
    {
         Remove-AzureStorageAccount -StorageAccountName $name
    }
    catch
    {
         Write-Warning "Cannot Remove the Storage Account"
    }
}

<#
.SYNOPSIS
Gets test mode - 'Record' or 'Playback'
#>
function Get-ComputeTestMode
{
    $oldErrorActionPreferenceValue = $ErrorActionPreference;
    $ErrorActionPreference = "SilentlyContinue";
    
    try
    {
        $testMode = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode;
        $testMode = $testMode.ToString();
    }
    catch
    {
        if (($Error.Count -gt 0) -and ($Error[0].Exception.Message -like '*Unable to find type*'))
        {
            $testMode = 'Record';
        }
        else
        {
            throw;
        }
    }
    finally
    {
        $ErrorActionPreference = $oldErrorActionPreferenceValue;
    }

    return $testMode;
}