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
    $s = $prefix
    $s += "_"
    $s += Get-Random
    $s
}

<#
.SYNOPSIS
Sets context to default resource
#>
function Set-DefaultResource
{
    $selectedResource = Select-AzureStorSimpleResource -ResourceName OneSDK-Resource
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

function Get-DefaultValue ($key)
{
    $defaults = @{
		StorageAccountName = "wuscisclcis1mdsj5sy409";
		StorageAccountPrimaryAccessKey = "OKVxOKV5wDZ98Dq6ehBC29+R05XBXAEVvLOwpK6vh6PaOxRUocQXPY7WhLumiVo8osk/o4elSJR79USWtgSyCA==";
		StorageAccountSecondaryAccessKey = "lSNa58WEo/Nabrt0L+UCnVlQPdzq4kIUITVs5HzOb4ZZ7lsNdOR1wmcVQOWBLSR/OHy2qoM/90DTrSHWhrixGw=="
	}

	return $defaults[$key];
}


function Test-VolumeContainerSync
{
    echo "Executing Test-VolumeContainerSync"
    $dcName = Generate-Name("VolumeContainer")

    Set-DefaultResource

    $deviceName = Get-DeviceName

    echo "Getting SAC"
	$sacToUse = Get-AzureStorSimpleStorageAccountCredential | Select-Object -first 1 -wait
	Assert-NotNull $sacToUse "SAC cannot be empty"

    echo "Creating new DC"
    $sacToUse | New-AzureStorSimpleDeviceVolumeContainer -Name $dcName -DeviceName $deviceName -BandWidthRate 256 -WaitForComplete
	
    echo "Trying to retrieve new DC"
    $dcToUse = Get-AzureStorSimpleDeviceVolumeContainer -DeviceName $deviceName -VolumeContainerName $dcName
	Assert-NotNull $dcToUse "dc is not created properly"

    echo "Cleaning up DC"
    $dcToUse| Remove-AzureStorSimpleDeviceVolumeContainer -DeviceName $deviceName -Force -WaitForComplete  -ErrorAction SilentlyContinue   
    echo "Existing the test"
}

function Test-VolumeContainerAsync
{
    echo "Executing Test-VolumeContainerAsync"
	$dcName = Generate-Name("VolumeContainer")

    Set-DefaultResource

    $deviceName = Get-DeviceName

    echo "Getting SAC"
	$sacToUse = Get-AzureStorSimpleStorageAccountCredential | Select-Object -first 1 -wait
	Assert-NotNull $sacToUse "SAC cannot be empty"

    echo "Creating new DC in async mode"
    $sacToUse | New-AzureStorSimpleDeviceVolumeContainer -Name $dcName -DeviceName $deviceName -BandWidthRate 256 -Verbose

    echo "Trying to get DC"
    [Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)
    [Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)

    $dcToUse = Get-AzureStorSimpleDeviceVolumeContainer -DeviceName $deviceName -VolumeContainerName $dcName
    Assert-NotNull $dcToUse "DC is not created"

    echo "Cleaning up"
    $dcToUse| Remove-AzureStorSimpleDeviceVolumeContainer -DeviceName $deviceName -Force -WaitForComplete  -ErrorAction SilentlyContinue   
    echo "Exiting test"
}


function Test-VolumeContainerSync_RepetitiveDCName
{
    echo "Executing Test-VolumeContainerSync_RepetitiveDCName"
	$dcName = Generate-Name("VolumeContainer")

    Set-DefaultResource

    $deviceName = Get-DeviceName

    echo "Getting SAC"
    $sacToUse = Get-AzureStorSimpleStorageAccountCredential | Select-Object -first 1 -wait
	Assert-NotNull $sacToUse "SAC cannot be empty"

    echo "Creating new DC"
    $sacToUse | New-AzureStorSimpleDeviceVolumeContainer -Name $dcName -DeviceName $deviceName -BandWidthRate 256 -WaitForComplete
	
    echo "Trying to create another DC with same name"
    $ExceptionOccurred = "false"
    $ErrorActionPreference = "Stop"
    try
    {
	    $sacToUse | New-AzureStorSimpleDeviceVolumeContainer -Name $dcName -DeviceName $deviceName -BandWidthRate 256 -WaitForComplete
    }
    catch
    {
        echo "Expected exception occurred"
        $ErrorMessage = $_.Exception.Message
        $ExceptionOccurred = "true"
    }
    Assert-AreEqual $ExceptionOccurred "true"

    echo "Cleaning up"
    $dcToUse| Remove-AzureStorSimpleDeviceVolumeContainer -DeviceName $deviceName -Force -WaitForComplete  -ErrorAction SilentlyContinue   
    echo "Exiting test"
}

function Test-VolumeContainerSync_InlineSac
{
    echo "Executing Test-VolumeContainerSync"
    $dcName = Generate-Name("VolumeContainer")

    Set-DefaultResource

    $deviceName = Get-DeviceName

    echo "Creating DC with inline SAC"
    $storageAccountName = Get-DefaultValue -key "StorageAccountName"
    $storageAccountKey = Get-DefaultValue -Key "StorageAccountPrimaryAccessKey"
	$inlineSac = New-AzureStorSimpleInlineStorageAccountCredential -Name $storageAccountName -Key $storageAccountKey
    $inlineSac | New-AzureStorSimpleDeviceVolumeContainer -Name $dcName -DeviceName $deviceName -BandWidthRate 256 -EncryptionEnabled $true -EncryptionKey "testkey" -WaitForComplete
	
    echo "Trying to retrieve new DC"
    $dcToUse = Get-AzureStorSimpleDeviceVolumeContainer -DeviceName $deviceName -VolumeContainerName $dcName
	Assert-NotNull $dcToUse "dc is not created properly"

    echo "Cleaning up DC"
    $dcToUse| Remove-AzureStorSimpleDeviceVolumeContainer -DeviceName $deviceName -Force -WaitForComplete

    echo "Cleaning up SAC"
    Remove-AzureStorSimpleStorageAccountCredential -Name $storageAccountName -Force -WaitForComplete -ErrorAction SilentlyContinue

    echo "Existing the test"
}

function Test-VolumeContainerSync_InlineSac_InvalidCreds
{
    echo "Executing Test-VolumeContainerSync"
    $dcName = Generate-Name("VolumeContainer")

    Set-DefaultResource

    $deviceName = Get-DeviceName

    echo "Creating DC with inline SAC"
    $storageAccountName = Get-DefaultValue -key "StorageAccountName"
    $storageAccountKey = Get-DefaultValue -Key "StorageAccountPrimaryAccessKey"

    $storageAccountName_Wrong = $storageAccountName.SubString(3)
    $storageAccountKey_Wrong = $storageAccountKey.SubString(3)

	$inlineSac1 = New-AzureStorSimpleInlineStorageAccountCredential -Name $storageAccountName_Wrong -Key $storageAccountKey
    $inlineSac1 | New-AzureStorSimpleDeviceVolumeContainer -Name $dcName -DeviceName $deviceName -BandWidthRate 256 -EncryptionEnabled $true -EncryptionKey "testkey" -WaitForComplete -ErrorAction SilentlyContinue
	$dcToUse1 = Get-AzureStorSimpleDeviceVolumeContainer -DeviceName $deviceName -VolumeContainerName $dcName
	Assert-Null $dcToUse1
    
    $dcName2 = Generate-Name("VolumeContainer")
    $inlineSac2 = New-AzureStorSimpleInlineStorageAccountCredential -Name $storageAccountName -Key $storageAccountKey_Wrong
    $inlineSac2 | New-AzureStorSimpleDeviceVolumeContainer -Name $dcName2 -DeviceName $deviceName -BandWidthRate 256 -EncryptionEnabled $true -EncryptionKey "testkey" -WaitForComplete -ErrorAction SilentlyContinue
	$dcToUse2 = Get-AzureStorSimpleDeviceVolumeContainer -DeviceName $deviceName -VolumeContainerName $dcName2
	Assert-Null $dcToUse2

    echo "Existing the test"
}
