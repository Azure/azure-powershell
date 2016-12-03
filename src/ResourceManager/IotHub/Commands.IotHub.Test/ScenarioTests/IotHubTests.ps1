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
## IotHub Cmdlets			   ##
#################################

$global:resourceType = "Microsoft.Devices/IotHubs"

<#
.SYNOPSIS
Test Get-AzureRmIotHub for listing all iothubs in a subscription
#>

function Test-AzureRmIotHubLifecycle
{
	Param($Location, $IotHubName, $ResourceGroupName, $Sku)

	# Get all Iot hubs in the subscription
	$allIotHubs = Get-AzureRmIotHub

	Assert-True { $allIotHubs[0].Type -eq $global:resourceType }
	Assert-True { $allIotHubs.Count -gt 1 }

	# Create or Update Resource Group
	$resourceGroup = New-AzureRmResourceGroup -Name $ResourceGroupName -Location $Location 

	# Create Iot Hub
	$newIothub1 = New-AzureRmIotHub -Name $IotHubName -ResourceGroupName $ResourceGroupName -Location $Location -SkuName $Sku -Units 1

	# Get Iot Hub in resourcegroup
	$allIotHubsInResourceGroup =  Get-AzureRmIotHub -ResourceGroupName $ResourceGroupName 
	
	# Get Iot Hub
	$iotHub = Get-AzureRmIotHub -ResourceGroupName $ResourceGroupName -Name $IotHubName 

	Assert-True { $allIotHubsInResourceGroup.Count -eq 1 }
	Assert-True { $iotHub.Name -eq $IotHubName }

	# Get Quota Metrics
	$quotaMetrics = Get-AzureRmIotHubQuotaMetric -ResourceGroupName $ResourceGroupName -Name $IotHubName
	Assert-True { $quotaMetrics.Count -eq 2 }

	# Get Registry Statistics
	$registryStats = Get-AzureRmIotHubRegistryStatistic -ResourceGroupName $ResourceGroupName -Name $IotHubName
	Assert-True { $registryStats.TotalDeviceCount -eq 0 }
	Assert-True { $registryStats.EnabledDeviceCount -eq 0 }
	Assert-True { $registryStats.DisabledDeviceCount -eq 0 }

	# Get Valid Skus
	$validSkus = Get-AzureRmIotHubValidSku -ResourceGroupName $ResourceGroupName -Name $IotHubName
	Assert-True { $validSkus.Count -gt 1 }

	# Get EventHub Consumer group for events
	$eventubConsumerGroup = Get-AzureRmIotHubEventHubConsumerGroup -ResourceGroupName $ResourceGroupName -Name $IotHubName -EventHubEndpointName events
	Assert-True { $eventubConsumerGroup.Count -eq 1 }

	# Get EventHub Consumer group for operationsmonitoring
	$eventubConsumerGroupOpMon = Get-AzureRmIotHubEventHubConsumerGroup -ResourceGroupName $ResourceGroupName -Name $IotHubName -EventHubEndpointName operationsMonitoringEvents
	Assert-True { $eventubConsumerGroupOpMon.Count -eq 1 }

	# Get Keys
	$keys = Get-AzureRmIotHubKey -ResourceGroupName $ResourceGroupName -Name $IotHubName 
	Assert-True { $keys.Count -eq 5 }

	# Get Key for iothubowner
	$key = Get-AzureRmIotHubKey -ResourceGroupName $ResourceGroupName -Name $IotHubName -KeyName iothubowner
	Assert-True { $key.KeyName -eq "iothubowner" }

	# Get Connection strings
	$connectionstrings = Get-AzureRmIotHubConnectionString -ResourceGroupName $ResourceGroupName -Name $IotHubName
	Assert-True { $connectionstrings.Count -eq 5 }

	# Get Connection string
	$connectionstring = Get-AzureRmIotHubConnectionString -ResourceGroupName $ResourceGroupName -Name $IotHubName -KeyName iothubowner
	Assert-True { $key.KeyName -eq "iothubowner" }

	# Add consumer group
	Add-AzureRmIotHubEventHubConsumerGroup -ResourceGroupName $ResourceGroupName -Name $IotHubName -EventHubEndpointName events -EventHubConsumerGroupName cg1

	# Get consumer group
	$eventubConsumerGroup = Get-AzureRmIotHubEventHubConsumerGroup -ResourceGroupName $ResourceGroupName -Name $IotHubName -EventHubEndpointName events
	Assert-True { $eventubConsumerGroup.Count -eq 2 }

	# Delete consumer group
	Remove-AzureRmIotHubEventHubConsumerGroup -ResourceGroupName $ResourceGroupName -Name $IotHubName -EventHubEndpointName events -EventHubConsumerGroupName cg1

	# Get consumer group
	$eventubConsumerGroup = Get-AzureRmIotHubEventHubConsumerGroup -ResourceGroupName $ResourceGroupName -Name $IotHubName -EventHubEndpointName events
	Assert-True { $eventubConsumerGroup.Count -eq 1 }

	# Add Key
	Add-AzureRmIotHubKey -ResourceGroupName $ResourceGroupName -Name $IotHubName -KeyName iothubowner1 -PrimaryKey 4GT/3sQXHYLDVOG5c8GQCpxIAw+OQtE5RxpdFC6O5Jk= -SecondaryKey 4GT/3sQXHYLDVOG5c8GQCpxIAw+OQtE5RxpdFC6O5Jk= -Rights RegistryRead

	# Get Keys
	$keys = Get-AzureRmIotHubKey -ResourceGroupName $ResourceGroupName -Name $IotHubName 
	Assert-True { $keys.Count -eq 6 }

	# Remove Key
	Remove-AzureRmIotHubKey -ResourceGroupName $ResourceGroupName -Name $IotHubName -KeyName iothubowner1

	# Get Keys
	$keys = Get-AzureRmIotHubKey -ResourceGroupName $ResourceGroupName -Name $IotHubName 
	Assert-True { $keys.Count -eq 5 }

	# Set Sku
	$iothub = Get-AzureRmIotHub -ResourceGroupName $ResourceGroupName -Name $IotHubName 
	$iothubUpdated = Set-AzureRmIotHub -ResourceGroupName $ResourceGroupName -Name $IotHubName -SkuName S1 -Units 5
	Assert-True { $iothubUpdated.Sku.Capacity -eq 5 }

	# Event Hub Properties Update
	$iothubUpdated = Set-AzureRmIotHub -ResourceGroupName $ResourceGroupName -Name $IotHubName -EventHubRetentionTimeInDays 5
	Assert-True { $iothubUpdated.Properties.EventHubEndpoints.events.RetentionTimeInDays -eq 5 }

	# Cloud To Device Properties Update
	$cloudToDevice = $iothubUpdated.Properties.CloudToDevice
	$cloudToDevice.MaxDeliveryCount = 25
	$iotHubUpdated = Set-AzureRmIotHub -ResourceGroupName $ResourceGroupName -Name $IotHubName -CloudToDevice $cloudToDevice
	Assert-True { $iothubUpdated.Properties.CloudToDevice.MaxDeliveryCount -eq 25 }

	# Operations Monitoring properties update
	$op= $iotHubUpdated.Properties.OperationsMonitoringProperties
	$op.OperationMonitoringEvents["Connections"] = "Information"
	$iotHubUpdated = Set-AzureRmIotHub -ResourceGroupName $ResourceGroupName -Name $IotHubName -OperationsMonitoringProperties $op
	Assert-True { $iothubUpdated.Properties.OperationsMonitoringProperties.OperationMonitoringEvents["Connections"] -eq "Information" }

	# Remove IotHub
	Remove-AzureRmIotHub -ResourceGroupName $ResourceGroupName -Name $IotHubName
}