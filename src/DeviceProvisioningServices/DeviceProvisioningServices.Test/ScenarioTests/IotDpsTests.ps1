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


#################################
## Manage IotDps Cmdlets	   ##
#################################

$global:resourceType = "Microsoft.Devices/ProvisioningServices"

<#
.SYNOPSIS
Test Iot Hub Device Provisioning Service cmdlets for CRUD operations 
#>

function Test-AzureIotDpsLifeCycle
{
	$Location = Get-Location "Microsoft.Devices" "Device Provisioning Service" 
	$IotDpsName = getAssetName 
	$ResourceGroupName = getAssetName 
	$Sku = "S1"

	# Constant variable
	$CurrentAllocationPolicy = "Hashed"
	$NewAllocationPolicy = "GeoLatency"
	$Tag1Key = "key1"
	$Tag2Key = "key2"
	$Tag1Value = "value1"
	$Tag2Value = "value2"

	# Get all Iot hubs in the subscription
	$allIotDps = Get-AzIotDps
	
	If ($allIotDps.Count -gt 1) {
		Assert-True { $allIotDps[0].Type -eq $global:resourceType }
	}

	# Create or Update Resource Group
	$resourceGroup = New-AzResourceGroup -Name $ResourceGroupName -Location $Location 

	# Add Tags to Iot Hub Device Provisioning Service
	$tags = @{}
	$tags.Add($Tag1Key, $Tag1Value)

	# Create Iot Hub Device Provisioning Service
	$newIotDps1 = New-AzIoTDps -ResourceGroupName $ResourceGroupName -Name $IotDpsName -Location $Location -Tag $tags
	Assert-True { $newIotDps1.Name -eq $IotDpsName }
	Assert-True { $newIotDps1.Tags.Count -eq 1 }
	Assert-True { $newIotDps1.Tags.Item($Tag1Key) -eq $Tag1Value }	

	# Get Iot Hub Device Provisioning Service
	$iotDps = Get-AzIoTDps -ResourceGroupName $ResourceGroupName -Name $IotDpsName 
	Assert-True { $iotDps.Name -eq $IotDpsName }
	Assert-True { $iotDps.Properties.AllocationPolicy -eq $CurrentAllocationPolicy }
	Assert-True { $iotDps.Sku.Name -eq $Sku }

	# Update Iot Hub Device Provisioning Service Allocation Policy
	$updatedIotDps1 = Get-AzIoTDps -ResourceGroupName $ResourceGroupName -Name $IotDpsName | Update-AzIotDps -AllocationPolicy $NewAllocationPolicy
	Assert-True { $updatedIotDps1.Properties.AllocationPolicy -eq $NewAllocationPolicy }

	# Add more Tags to Iot Hub Device Provisioning Service
	$tags.Clear()
	$tags.Add($Tag2Key, $Tag2Value)
	$updatedIotDps3 = Update-AzIoTDps -ResourceGroupName $ResourceGroupName -Name $IotDpsName -Tag $tags
	Assert-True { $updatedIotDps3.Tags.Count -eq 2 }
	Assert-True { $updatedIotDps3.Tags.Item($Tag1Key) -eq $Tag1Value }
	Assert-True { $updatedIotDps3.Tags.Item($Tag2Key) -eq $Tag2Value }

	# Add Tags to Iot Hub Device Provisioning Service with Reset option
	$tags.Clear()
	$tags.Add($Tag1Key, $Tag1Value)
	$updatedIotDps4 = Update-AzIoTDps -ResourceGroupName $ResourceGroupName -Name $IotDpsName -Tag $tags -Reset
	Assert-True { $updatedIotDps4.Tags.Count -eq 1 }
	Assert-True { $updatedIotDps4.Tags.Item($Tag1Key) -eq $Tag1Value }

	# Remove Iot Hub Device Provisioning Service
	$result = Remove-AzIoTDps -ResourceGroupName $ResourceGroupName -Name $IotDpsName -PassThru
	Assert-True { $result }

	# Remove Resource Group
	Remove-AzResourceGroup -Name $ResourceGroupName -force
}
