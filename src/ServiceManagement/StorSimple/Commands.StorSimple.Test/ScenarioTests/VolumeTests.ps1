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
Generates unique name with given prefix
#>
function Generate-Name ($prefix)
{
    $s = "Test" + $prefix
    #$s += "_"
    #$s += Get-Random
    $s
}

<#
.SYNOPSIS
Sets context to default resource
#>
function Set-DefaultResource
{
    $selectedResource = Select-AzureStorSimpleResource -ResourceName OneSDK-Resource -RegistrationKey "1975530557201809476:eOqMQdvHon3lGwKVYctxZVnwpZcqi8ZS1uyCLJAl6Wg=:JovQDqP1KyWdh4m3mYkdzQ==#4edfc1cde41104e5"
}


<#
.SYNOPSIS
Gets device name to use for the test
#>
function Get-DeviceName ()
{
    $deviceName = (Get-AzureStorSimpleDevice) | Where{$_.Status -eq "Online"} | Select-Object -first 1 | Select -ExpandProperty "FriendlyName"
	$deviceName
}

function Test-VolumeSync
{
    echo "Executing Test-VolumeSync"
    $dcName = Generate-Name("VolumeContainer")
    $vdName = Generate-Name("Volume")
    $acrName = Generate-Name("ACR")
    $iqn = Generate-Name("IQN")
    
    Set-DefaultResource

    $deviceName = Get-DeviceName

    echo "Creating new ACR"
    New-AzureStorSimpleAccessControlRecord -Name $acrName -iqn $iqn -WaitForComplete
    
    echo "Retrieving the ACR"
    $acrList = @()
    $acrList += Get-AzureStorSimpleAccessControlRecord -ACRName $acrName
    Assert-NotNull $acrList "ACRList cannot be empty"

    echo "Getting SAC"
	$sacToUse = (Get-AzureStorSimpleStorageAccountCredential) | Select-Object -first 1 -wait
	Assert-NotNull $sacToUse "SAC cannot be empty"

    echo "Creating new DC"
    $sacToUse | New-AzureStorSimpleDeviceVolumeContainer -Name $dcName -DeviceName $deviceName -BandWidthRate 256 -WaitForComplete
	
    echo "Trying to retrieve new DC"
    $dcToUse = Get-AzureStorSimpleDeviceVolumeContainer -DeviceName $deviceName -VolumeContainerName $dcName
	Assert-NotNull $dcToUse "dc is not created properly"

    echo "Creating new Volume"
    $dcToUse | New-AzureStorSimpleDeviceVolume -DeviceName $deviceName -Name $vdName -Size 2000000000 -AccessControlRecords $acrList -AppType PrimaryVolume -Online $true -EnableDefaultBackup $false -EnableMonitoring $false -WaitForComplete
	
    echo "Retrieving the volume"
    $vdToUse = Get-AzureStorSimpleDeviceVolume -DeviceName $deviceName -VolumeName $vdName
	Assert-NotNull $vdToUse "Volume is not created properly"

    echo "Setting volume offline"
    Set-AzureStorSimpleDeviceVolume -DeviceName $deviceName -VolumeName $vdName -Online $false -WaitForComplete

    echo "Verifying that volume is offline"
    $vdToUse = Get-AzureStorSimpleDeviceVolume -DeviceName $deviceName -VolumeName $vdName
	Assert-AreEqual $vdToUse.Online $false

    echo "Cleaning up the volume"
    Remove-AzureStorSimpleDeviceVolume -DeviceName $deviceName -VolumeName $vdName -Force -WaitForComplete -ErrorAction SilentlyContinue
    
    echo "Cleaning up DC"
    $dcToUse| Remove-AzureStorSimpleDeviceVolumeContainer -DeviceName $deviceName -Force -WaitForComplete  -ErrorAction SilentlyContinue   
    
    echo "Cleaning up the ACR"
    Remove-AzureStorSimpleAccessControlRecord -Name $acrName -Force -WaitForComplete  -ErrorAction SilentlyContinue
    echo "Existing the test"
}

function Test-NewVolumeRepetitiveName
{
	echo "Executing Test-NewVolumeRepetitiveName"
    $dcName = Generate-Name("VolumeContainer")
    $vdName = Generate-Name("Volume")
    $acrName = Generate-Name("ACR")
    $iqn = Generate-Name("IQN")
    
    Set-DefaultResource

    $deviceName = Get-DeviceName

    echo "Creating new ACR"
    New-AzureStorSimpleAccessControlRecord -Name $acrName -iqn $iqn -WaitForComplete
    
    echo "Retrieving the ACR"
    $acrList = @()
    $acrList += Get-AzureStorSimpleAccessControlRecord -ACRName $acrName
    Assert-NotNull $acrList "ACRList cannot be empty"

    echo "Getting SAC"
	$sacToUse = (Get-AzureStorSimpleStorageAccountCredential) | Select-Object -first 1 -wait
	Assert-NotNull $sacToUse "SAC cannot be empty"

    echo "Creating new DC"
    $sacToUse | New-AzureStorSimpleDeviceVolumeContainer -Name $dcName -DeviceName $deviceName -BandWidthRate 256 -WaitForComplete
	
    echo "Trying to retrieve new DC"
    $dcToUse = Get-AzureStorSimpleDeviceVolumeContainer -DeviceName $deviceName -VolumeContainerName $dcName
	Assert-NotNull $dcToUse "dc is not created properly"

    echo "Creating new Volume"
    $dcToUse | New-AzureStorSimpleDeviceVolume -DeviceName $deviceName -Name $vdName -Size 2000000000 -AccessControlRecords $acrList -AppType PrimaryVolume -Online $true -EnableDefaultBackup $false -EnableMonitoring $false -WaitForComplete
	
    echo "Retrieving the volume"
    $vdToUse = Get-AzureStorSimpleDeviceVolume -DeviceName $deviceName -VolumeName $vdName
	Assert-NotNull $vdToUse "Volume is not created properly"

    echo "Trying to create new volume with the same name - Expecting error here"
    $ExceptionOccurred = "false"
    $ErrorActionPreference = "Stop"
    try
    {
	    $dcToUse | New-AzureStorSimpleDeviceVolume -DeviceName $deviceName -Name $vdName -Size 2000000000 -AccessControlRecords $acrList -AppType PrimaryVolume -Online $true -EnableDefaultBackup $false -EnableMonitoring $false -WaitForComplete
    }
    catch
    {
        echo "Expected exception occurred"
        $ErrorMessage = $_.Exception.Message
        $ExceptionOccurred = "true"
    }
    Assert-AreEqual $ExceptionOccurred "true"
  
    echo "Cleaning up DC"
    $dcToUse| Remove-AzureStorSimpleDeviceVolumeContainer -DeviceName $deviceName -Force -WaitForComplete  -ErrorAction SilentlyContinue   
    
    echo "Cleaning up the ACR"
    Remove-AzureStorSimpleAccessControlRecord -Name $acrName -Force -WaitForComplete  -ErrorAction SilentlyContinue
    echo "Existing the test"
}

function Test-NewVolumeNoAccess
{
	echo "Executing Test-NewVolumeNoAccess"
    
    $dcName = Generate-Name("VolumeContainer")
    $vdName = Generate-Name("Volume")
    
    Set-DefaultResource

    $deviceName = Get-DeviceName
    
    echo "Getting SAC"
	$sacToUse = (Get-AzureStorSimpleStorageAccountCredential) | Select-Object -first 1 -wait
	Assert-NotNull $sacToUse "SAC cannot be empty"

    echo "Creating new DC"
    $sacToUse | New-AzureStorSimpleDeviceVolumeContainer -Name $dcName -DeviceName $deviceName -BandWidthRate 256 -WaitForComplete
	
    echo "Trying to retrieve new DC"
    $dcToUse = Get-AzureStorSimpleDeviceVolumeContainer -DeviceName $deviceName -VolumeContainerName $dcName
	Assert-NotNull $dcToUse "dc is not created properly"

    echo "Creating new Volume with no ACR"
    $dcToUse | New-AzureStorSimpleDeviceVolume -DeviceName $deviceName -Name $vdName -Size 2000000000 -AccessControlRecords @() -AppType PrimaryVolume -Online $true -EnableDefaultBackup $false -EnableMonitoring $false -WaitForComplete
	
    echo "Retrieving the volume"
    $vdToUse = Get-AzureStorSimpleDeviceVolume -DeviceName $deviceName -VolumeName $vdName
	Assert-NotNull $vdToUse "Volume is not created properly"

    echo "Setting volume offline"
    Set-AzureStorSimpleDeviceVolume -DeviceName $deviceName -VolumeName $vdName -Online $false -WaitForComplete

    echo "Verifying that volume is offline"
    $vdToUse = Get-AzureStorSimpleDeviceVolume -DeviceName $deviceName -VolumeName $vdName
	Assert-AreEqual $vdToUse.Online $false

    echo "Cleaning up the volume"
    Remove-AzureStorSimpleDeviceVolume -DeviceName $deviceName -VolumeName $vdName -Force -WaitForComplete -ErrorAction SilentlyContinue
  
    echo "Cleaning up DC"
    $dcToUse| Remove-AzureStorSimpleDeviceVolumeContainer -DeviceName $deviceName -Force -WaitForComplete  -ErrorAction SilentlyContinue   
    
    echo "Existing the test"
}

function Test-VolumeAsync
{
    echo "Executing Test-VolumeAsync"
    $dcName = Generate-Name("VolumeContainer")
    $vdName = Generate-Name("Volume")
    $acrName = Generate-Name("ACR")
    $iqn = Generate-Name("IQN")
    
    Set-DefaultResource

    $deviceName = Get-DeviceName

    echo "Creating new ACR"
    New-AzureStorSimpleAccessControlRecord -Name $acrName -iqn $iqn -WaitForComplete
    
    echo "Retrieving the ACR"
    $acrList = @()
    $acrList += Get-AzureStorSimpleAccessControlRecord -ACRName $acrName
    Assert-NotNull $acrList "ACRList cannot be empty"

    echo "Getting SAC"
	$sacToUse = (Get-AzureStorSimpleStorageAccountCredential) | Select-Object -first 1 -wait
	Assert-NotNull $sacToUse "SAC cannot be empty"

    echo "Creating new DC"
    $sacToUse | New-AzureStorSimpleDeviceVolumeContainer -Name $dcName -DeviceName $deviceName -BandWidthRate 256 -WaitForComplete
	
    echo "Trying to retrieve new DC"
    $dcToUse = Get-AzureStorSimpleDeviceVolumeContainer -DeviceName $deviceName -VolumeContainerName $dcName
	Assert-NotNull $dcToUse "dc is not created properly"

    echo "Creating new Volume"
    $dcToUse | New-AzureStorSimpleDeviceVolume -DeviceName $deviceName -Name $vdName -Size 2000000000 -AccessControlRecords $acrList -AppType PrimaryVolume -Online $true -EnableDefaultBackup $false -EnableMonitoring $false
	

    echo "Retrieving the volume"
    [Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)
    [Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)
    $vdToUse = Get-AzureStorSimpleDeviceVolume -DeviceName $deviceName -VolumeName $vdName
	Assert-NotNull $vdToUse "Volume is not created properly"

    echo "Setting volume offline"
    Set-AzureStorSimpleDeviceVolume -DeviceName $deviceName -VolumeName $vdName -Online $false

    echo "Verifying that volume is offline"
    [Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)
    $vdToUse = Get-AzureStorSimpleDeviceVolume -DeviceName $deviceName -VolumeName $vdName
	Assert-AreEqual $vdToUse.Online $false

    echo "Cleaning up the volume"
    Remove-AzureStorSimpleDeviceVolume -DeviceName $deviceName -VolumeName $vdName -Force -ErrorAction SilentlyContinue
    [Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)
    
    echo "Cleaning up DC"
    $dcToUse| Remove-AzureStorSimpleDeviceVolumeContainer -DeviceName $deviceName -Force -WaitForComplete  -ErrorAction SilentlyContinue   
    
    echo "Cleaning up the ACR"
    Remove-AzureStorSimpleAccessControlRecord -Name $acrName -Force -WaitForComplete  -ErrorAction SilentlyContinue
    echo "Existing the test"
}
