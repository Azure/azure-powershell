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


#################################
## IotHub Tracing Cmdlets	   ##
#################################

<#
.SYNOPSIS
Test all iothub device tracing cmdlets
#>
function Test-AzureRmIotHubTracing
{
	$Location = Get-Location "Microsoft.Devices" "IotHubs" "WEST US 2"
	$IotHubName = getAssetName
	$ResourceGroupName = getAssetName
	$Sku = "S1"
	$device1 = getAssetName

	# Create Resource Group
	$resourceGroup = New-AzResourceGroup -Name $ResourceGroupName -Location $Location 

	# Create Iot Hub
	$iothub = New-AzIotHub -Name $IotHubName -ResourceGroupName $ResourceGroupName -Location $Location -SkuName $Sku -Units 1

	# Add iot device 
	$newDevice1 = Add-AzIotHubDevice -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1 -AuthMethod 'shared_private_key'
	Assert-True { $newDevice1.Id -eq $device1 }
	Assert-False { $newDevice1.Capabilities.IotEdge }

	# Get device tracing detail
	$deviceTracing = Get-AzIotHubDistributedTracing -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1
	Assert-True { $deviceTracing.DeviceId -eq $device1}
	Assert-True { $deviceTracing.TracingOption.SamplingMode -eq 'Disabled'}
	Assert-True { $deviceTracing.TracingOption.SamplingRate -eq ''}
	Assert-False { $deviceTracing.IsSynced}

	# Set device tracing option
	$updatedDeviceTracing = Set-AzIotHubDistributedTracing -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1 -mode 'Enabled' -rate 45
	Assert-True { $updatedDeviceTracing.DeviceId -eq $device1}
	Assert-True { $updatedDeviceTracing.TracingOption.SamplingMode -eq 'Enabled'}
	Assert-True { $updatedDeviceTracing.TracingOption.SamplingRate -eq 45}
	Assert-False { $updatedDeviceTracing.IsSynced}

	# Delete all devices
	$result = Remove-AzIotHubDevice -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -Passthru
	Assert-True { $result }
}