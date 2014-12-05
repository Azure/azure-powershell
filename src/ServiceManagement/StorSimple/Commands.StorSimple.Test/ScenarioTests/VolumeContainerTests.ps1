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
Gets device name to use for the test
#>
function Get-DeviceName ()
{
    $deviceName = (Get-AzureStorSimpleDevice) | Where{$_.Status -eq "Online"} | Select-Object -first 1 | Select -ExpandProperty "FriendlyName"
	$deviceName
}

function Test-VolumeContainerSync
{
    echo "Executing Test-VolumeContainerSync"
    $dcName = Generate-Name("VolumeContainer")
    $deviceName = Get-DeviceName

    echo "Getting SAC"
	$sacToUse = Get-AzureStorSimpleStorageAccountCredential | Select-Object -first 1 -wait
	Assert-NotNull $sacToUse "SAC cannot be empty"

    echo "Creating new DC"
    $jobStatus = $sacToUse | New-AzureStorSimpleDeviceVolumeContainer -Name $dcName -DeviceName $deviceName -BandWidthRate 256 -WaitForComplete
	Assert-AreEqual $jobStatus.Status "Completed"
	Assert-AreEqual $jobStatus.Result "Succeeded"
	
    echo "Trying to retrieve new DC"
    $dcToUse = Get-AzureStorSimpleDeviceVolumeContainer -DeviceName $deviceName -VolumeContainerName $dcName
	Assert-NotNull $dcToUse "dc is not created properly"

    echo "Cleaning up DC"
    $jobStatus = $dcToUse| Remove-AzureStorSimpleDeviceVolumeContainer -DeviceName $deviceName -Force -WaitForComplete  -ErrorAction SilentlyContinue   
    echo "Existing the test"
}

function Test-VolumeContainerAsync
{
    echo "Executing Test-VolumeContainerAsync"
	$dcName = Generate-Name("VolumeContainer")
    $deviceName = Get-DeviceName

    echo "Getting SAC"
	$sacToUse = Get-AzureStorSimpleStorageAccountCredential | Select-Object -first 1 -wait
	Assert-NotNull $sacToUse "SAC cannot be empty"

    echo "Creating new DC in async mode"
    $jobStatus = $sacToUse | New-AzureStorSimpleDeviceVolumeContainer -Name $dcName -DeviceName $deviceName -BandWidthRate 256 -Verbose

    echo "Trying to get DC"
    [Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)
    [Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(30000)

    $dcToUse = Get-AzureStorSimpleDeviceVolumeContainer -DeviceName $deviceName -VolumeContainerName $dcName
    Assert-NotNull $dcToUse "DC is not created"

    echo "Cleaning up"
    $jobStatus = $dcToUse| Remove-AzureStorSimpleDeviceVolumeContainer -DeviceName $deviceName -Force -WaitForComplete  -ErrorAction SilentlyContinue   
    echo "Exiting test"
}


function Test-VolumeContainerSync_RepetitiveDCName
{
    echo "Executing Test-VolumeContainerSync_RepetitiveDCName"
	$dcName = Generate-Name("VolumeContainer")
    $deviceName = Get-DeviceName

    echo "Getting SAC"
    $sacToUse = Get-AzureStorSimpleStorageAccountCredential | Select-Object -first 1 -wait
	Assert-NotNull $sacToUse "SAC cannot be empty"

    echo "Creating new DC"
    $jobStatus = $sacToUse | New-AzureStorSimpleDeviceVolumeContainer -Name $dcName -DeviceName $deviceName -BandWidthRate 256 -WaitForComplete
	Assert-AreEqual $jobStatus.Status "Completed"
	Assert-AreEqual $jobStatus.Result "Succeeded"
	
    echo "Trying to create another DC with same name"
    $ExceptionOccurred = "false"
    $ErrorActionPreference = "Stop"
    try
    {
	    $jobStatus = $sacToUse | New-AzureStorSimpleDeviceVolumeContainer -Name $dcName -DeviceName $deviceName -BandWidthRate 256 -WaitForComplete
    }
    catch
    {
        echo "Expected exception occurred"
        $ErrorMessage = $_.Exception.Message
        $ExceptionOccurred = "true"
    }
    Assert-AreEqual $ExceptionOccurred "true"

    echo "Cleaning up"
    $jobStatus = $dcToUse| Remove-AzureStorSimpleDeviceVolumeContainer -DeviceName $deviceName -Force -WaitForComplete  -ErrorAction SilentlyContinue   
    echo "Exiting test"
}
