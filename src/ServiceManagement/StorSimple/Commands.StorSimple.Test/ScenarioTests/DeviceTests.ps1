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
Tests creating new resource group and a simple resource.
#>
function Test-GetDevices
{
	# Setup
	$selectedResource = (Get-AzureStorSimpleResource) | Select-Object -first 1
	
	echo $selectedResource
	
	$selectedResource | Select-AzureStorSimpleResource 
	
	# Test
	$list = Get-AzureStorSimpleDevice

	# Assert
	Assert-AreNotEqual 0 @($list).Count	
}

function Test-GetDevices_ByDeviceId
{
	# Selecting a resource
	$selectedResource = (Get-AzureStorSimpleResource) | Select-Object -first 1
	$selectedResource | Select-AzureStorSimpleResource

	# Make get devices call
	$deviceList = Get-AzureStorSimpleDevice
	
	# Select a deviceId and use it to make get device call with deviceId
	$deviceId = $deviceList[0].DeviceId
	$filteredDeviceList = Get-AzureStorSimpleDevice -DeviceId $deviceId

	Assert-AreEqual 1 @($filteredDeviceList).Count	
	Assert-AreEqual $deviceId $filteredDeviceList[0].DeviceId
}

function Test-GetDevices_ByDeviceName
{
	# Selecting a resource
	$selectedResource = (Get-AzureStorSimpleResource) | Select-Object -first 1
	$selectedResource | Select-AzureStorSimpleResource

	# Make get devices call
	$deviceList = Get-AzureStorSimpleDevice
	
	# Select a deviceName and use it to make get device call
	$deviceName = $deviceList[0].FriendlyName
	$filteredDeviceList = Get-AzureStorSimpleDevice -DeviceName $deviceName

	Assert-AreEqual 1 @($filteredDeviceList).Count	
	Assert-AreEqual $deviceName $filteredDeviceList[0].FriendlyName
}

function Test-GetDevices_ByType
{
	# Selecting a resource
	$selectedResource = (Get-AzureStorSimpleResource) | Select-Object -first 1
	$selectedResource | Select-AzureStorSimpleResource

	# Make get devices call
	$deviceList = Get-AzureStorSimpleDevice
	
	# Select a type and use it to make get device call
	$deviceType = $deviceList[0].Type
	$filteredDeviceList = Get-AzureStorSimpleDevice -Type $deviceType

	Assert-AreNotEqual 0 @($filteredDeviceList).Count	
}

function Test-GetDevices_ByModel
{
	# Selecting a resource
	$selectedResource = (Get-AzureStorSimpleResource) | Select-Object -first 1
	$selectedResource | Select-AzureStorSimpleResource

	# Make get devices call
	$deviceList = Get-AzureStorSimpleDevice
	
	# Select a modelDescription
	$model = $deviceList[0].ModelDescription
	$filteredDeviceList = Get-AzureStorSimpleDevice -ModelId $model

	Assert-AreNotEqual 0 @($filteredDeviceList).Count
	Assert-AreEqual $model $filteredDeviceList[0].ModelDescription
}

function Test-GetDevices_IncorrectParameters
{
	# Selecting a resource
	$selectedResource = (Get-AzureStorSimpleResource) | Select-Object -first 1
	$selectedResource | Select-AzureStorSimpleResource

	# Make get devices call
	$deviceList = Get-AzureStorSimpleDevice -DeviceName "someRandomName"
	
	Assert-AreEqual 0 @($deviceList).Count
}

function Test-GetDevices_DetailedResult
{
	# Selecting a resource
	$selectedResource = (Get-AzureStorSimpleResource) | Select-Object -first 1
	$selectedResource | Select-AzureStorSimpleResource

	# Make get devices call
	$detailedList = Get-AzureStorSimpleDevice -Detailed
	
	# check for 2 sample properties in the result set
	Assert-NotNull $detailedList[0].AlertNotification "AlertNotification does not exist"
	Assert-NotNull $detailedList[0].Snapshot "SnapshotSettings does not exist"
}
