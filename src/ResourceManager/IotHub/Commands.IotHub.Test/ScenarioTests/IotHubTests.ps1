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

$global:iotHubName = "powershelliothub"
$global:location = "northeurope"
$global:sku = "S1"
$global:resourceType = "Microsoft.Devices/IotHubs"
$global:resourceGroupName = "powershellrg"

<#
.SYNOPSIS
Test Get-AzureRmIotHub for listing all iothubs in a subscription
#>
function Test-AzureRmIotHubLifecycle
{
	# Get all Iot hubs in the subscription
	$allIotHubs = Get-AzureRmIotHub

	Assert-True { $allIotHubs[0].Type -eq $global:resourceType }
	Assert-True { $allIotHubs.Count -gt 1 }

	# Create or Update Resource Group
	$resourceGroup = New-AzureRmResourceGroup -Name $global:resourceGroupName -Location $global:location -Force:$true

	# Create Iot Hub
	$newIothub1 = New-AzureRmIotHub -Name $global:iotHubName -ResourceGroupName $global:resourceGroupName -Location $global:location -SkuName $global:sku -Units 1

	# Get Iot Hub in resourcegroup
	$allIotHubsInResourceGroup =  Get-AzureRmIotHub -ResourceGroupName $resourceGroup.ResourceGroupName 
	
	# Get Iot Hub
	$iotHub = Get-AzureRmIotHub -ResourceGroupName $resourceGroup.ResourceGroupName -Name $global:iotHubName 

	Assert-True { $allIotHubsInResourceGroup.Count -eq 1 }
	Assert-True { $iotHub.Name -eq $global:iotHubName }

	# Get Quota Metrics
	$quotaMetrics = Get-AzureRmIotHubQuotaMetric -ResourceGroupName $resourceGroup.ResourceGroupName -Name $global:iotHubName
	Assert-True { $quotaMetrics.Count -eq 2 }

	# Get Registry Statistics
	$registryStats = Get-AzureRmIotHubRegistryStatistic -ResourceGroupName $resourceGroup.ResourceGroupName -Name $global:iotHubName
	Assert-True { $registryStats.TotalDeviceCount -eq 0 }
	Assert-True { $registryStats.EnabledDeviceCount -eq 0 }
	Assert-True { $registryStats.DisabledDeviceCount -eq 0 }

	# Get Valid Skus
	$validSkus = Get-AzureRmIotHubValidSku -ResourceGroupName $resourceGroup.ResourceGroupName -Name $global:iotHubName
	Assert-True { $validSkus.Count -gt 1 }

	# Get EventHub Consumer group for events
	$eventubConsumerGroup = Get-AzureRmIotHubEventHubConsumerGroup -ResourceGroupName $resourceGroup.ResourceGroupName -Name $global:iotHubName -EventHubEndpointName events
	Assert-True { $eventubConsumerGroup.Count -eq 1 }

	# Get EventHub Consumer group for operationsmonitoring
	$eventubConsumerGroupOpMon = Get-AzureRmIotHubEventHubConsumerGroup -ResourceGroupName $resourceGroup.ResourceGroupName -Name $global:iotHubName -EventHubEndpointName operationsMonitoringEvents
	Assert-True { $eventubConsumerGroupOpMon.Count -eq 1 }

	# Get Keys
	$keys = Get-AzureRmIotHubKey -ResourceGroupName $resourceGroup.ResourceGroupName -Name $global:iotHubName 
	Assert-True { $keys.Count -eq 5 }

	# Get Key for iothubowner
	$key = Get-AzureRmIotHubKey -ResourceGroupName $resourceGroup.ResourceGroupName -Name $global:iotHubName -KeyName iothubowner
	Assert-True { $key.KeyName -eq "iothubowner" }

	# Get Connection strings
	$connectionstrings = Get-AzureRmIotHubConnectionString -ResourceGroupName $resourceGroup.ResourceGroupName -Name $global:iotHubName
	Assert-True { $connectionstrings.Count -eq 5 }

	# Get Connection string
	$connectionstring = Get-AzureRmIotHubConnectionString -ResourceGroupName $resourceGroup.ResourceGroupName -Name $global:iotHubName -KeyName iothubowner
	Assert-True { $key.KeyName -eq "iothubowner" }

	# Add consumer group
	Add-AzureRmIotHubEventHubConsumerGroup -ResourceGroupName $resourceGroup.ResourceGroupName -Name $global:iotHubName -EventHubEndpointName events -EventHubConsumerGroupName cg1

	# Get consumer group
	$eventubConsumerGroup = Get-AzureRmIotHubEventHubConsumerGroup -ResourceGroupName $resourceGroup.ResourceGroupName -Name $global:iotHubName -EventHubEndpointName events
	Assert-True { $eventubConsumerGroup.Count -eq 2 }

	# Delete consumer group
	Remove-AzureRmIotHubEventHubConsumerGroup -ResourceGroupName $resourceGroup.ResourceGroupName -Name $global:iotHubName -EventHubEndpointName events -EventHubConsumerGroupName cg1

	# Get consumer group
	$eventubConsumerGroup = Get-AzureRmIotHubEventHubConsumerGroup -ResourceGroupName $resourceGroup.ResourceGroupName -Name $global:iotHubName -EventHubEndpointName events
	Assert-True { $eventubConsumerGroup.Count -eq 1 }

	# Add Key
	Add-AzureRmIotHubKey -ResourceGroupName $resourceGroup.ResourceGroupName -Name $global:iotHubName -KeyName iothubowner1 -PrimaryKey 4GT/3sQXHYLDVOG5c8GQCpxIAw+OQtE5RxpdFC6O5Jk= -SecondaryKey 4GT/3sQXHYLDVOG5c8GQCpxIAw+OQtE5RxpdFC6O5Jk= -Rights RegistryRead

	# Get Keys
	$keys = Get-AzureRmIotHubKey -ResourceGroupName $resourceGroup.ResourceGroupName -Name $global:iotHubName 
	Assert-True { $keys.Count -eq 6 }

	# Remove Key
	Remove-AzureRmIotHubKey -ResourceGroupName $resourceGroup.ResourceGroupName -Name $global:iotHubName -KeyName iothubowner1 -Force:$true

	# Get Keys
	$keys = Get-AzureRmIotHubKey -ResourceGroupName $resourceGroup.ResourceGroupName -Name $global:iotHubName 
	Assert-True { $keys.Count -eq 5 }

	# Set Sku
	$iothub = Get-AzureRmIotHub -ResourceGroupName $resourceGroup.ResourceGroupName -Name $global:iotHubName 
	$iothubUpdated = Set-AzureRmIotHub -ResourceGroupName $resourceGroup.ResourceGroupName -Name $global:iotHubName -SkuName S1 -Units 5
	Assert-True { $iothubUpdated.Sku.Capacity -eq 5 }

	# Event Hub Properties Update
	$iothubUpdated = Set-AzureRmIotHub -ResourceGroupName $resourceGroup.ResourceGroupName -Name $global:iotHubName -EventHubRetentionTimeInDays 5
	Assert-True { $iothubUpdated.Properties.EventHubEndpoints.events.RetentionTimeInDays -eq 5 }

	# Cloud To Device Properties Update
	$cloudToDevice = $iothubUpdated.Properties.CloudToDevice
	$cloudToDevice.MaxDeliveryCount = 25
	$iotHubUpdated = Set-AzureRmIotHub -ResourceGroupName $resourceGroup.ResourceGroupName -Name $global:iotHubName -CloudToDevice $cloudToDevice
	Assert-True { $iothubUpdated.Properties.CloudToDevice.MaxDeliveryCount -eq 25 }

	# Operations Monitoring properties update
	$op= $iotHubUpdated.Properties.OperationsMonitoringProperties
	$op.OperationMonitoringEvents["Connections"] = "Information"
	$iotHubUpdated = Set-AzureRmIotHub -ResourceGroupName $resourceGroup.ResourceGroupName -Name $global:iotHubName -OperationsMonitoringProperties $op
	Assert-True { $iothubUpdated.Properties.OperationsMonitoringProperties.OperationMonitoringEvents["Connections"] -eq "Information" }

	# Remove IotHub
	Remove-AzureRmIotHub -ResourceGroupName $resourceGroup.ResourceGroupName -Name $global:iotHubName -Force:$true
}