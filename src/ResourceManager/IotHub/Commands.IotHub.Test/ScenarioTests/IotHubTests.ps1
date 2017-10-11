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

	Write-Debug " Create new eventHub " 
	$namespaceName = "IotHubPSEHNamespace1Test"
    $result = New-AzureRmEventHubNamespace -ResourceGroup $ResourceGroupName -NamespaceName $namespaceName -Location $Location

	Wait-Seconds 15
    
	# Assert
	Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug " Create new eventHub "    
	$eventHubName = "IotHubPSEHTest"
	$msgRetentionInDays = 3
	$partionCount = 2
    $result = New-AzureRmEventHub -ResourceGroup $ResourceGroupName -NamespaceName $namespaceName -Location $Location -EventHubName $eventHubName -MessageRetentionInDays $msgRetentionInDays -PartitionCount $partionCount

	# Create AuthRule
	$authRuleName = "IotHubPSEHAuthRule"
	$rights = "Listen","Send"
	$authRule = New-AzureRmEventHubAuthorizationRule -ResourceGroup $ResourceGroupName -NamespaceName $namespaceName  -EventHubName $eventHubName -AuthorizationRuleName $authRuleName -Rights $rights
	$keys = Get-AzureRmEventHubKey -ResourceGroup $ResourceGroupName -NamespaceName $namespaceName  -EventHubName $eventHubName -AuthorizationRuleName $authRuleName
	$ehConnectionString = $keys.PrimaryConnectionString

	# Create Iot Hub
	$properties = New-Object Microsoft.Azure.Commands.Management.IotHub.Models.PSIotHubInputProperties
	$routingProperties = New-Object Microsoft.Azure.Commands.Management.IotHub.Models.PSRoutingProperties
	$routingEndpoints = New-Object Microsoft.Azure.Commands.Management.IotHub.Models.PSRoutingEndpoints
	$routingEndpoints.EventHubs = New-Object 'System.Collections.Generic.List[Microsoft.Azure.Commands.Management.IotHub.Models.PSRoutingEventHubProperties]'
	$eventHubRouting = New-Object Microsoft.Azure.Commands.Management.IotHub.Models.PSRoutingEventHubProperties
	$eventHubRouting.Name = "eh1"
	$eventHubRouting.ConnectionString = $ehConnectionString
	$routingEndpoints.EventHubs.Add($eventHubRouting)
	$routingProperties.Endpoints = $routingEndpoints

	$routeProp = New-Object Microsoft.Azure.Commands.Management.IotHub.Models.PSRouteMetadata
	$routeProp.Name = "route"
	$routeProp.Condition = "true"
	$routeProp.IsEnabled = 1
	$routeProp.EndpointNames = New-Object 'System.Collections.Generic.List[String]'
	$routeProp.EndpointNames.Add("eh1")
	$routeProp.Source = "DeviceMessages"
	$routingProperties.Routes = New-Object 'System.Collections.Generic.List[Microsoft.Azure.Commands.Management.IotHub.Models.PSRouteMetadata]'
	$routingProperties.Routes.Add($routeProp)
	$properties.Routing = $routingProperties
	$newIothub1 = New-AzureRmIotHub -Name $IotHubName -ResourceGroupName $ResourceGroupName -Location $Location -SkuName $Sku -Units 1 -Properties $properties

	# Get Iot Hub in resourcegroup
	$allIotHubsInResourceGroup =  Get-AzureRmIotHub -ResourceGroupName $ResourceGroupName 
	
	# Get Iot Hub
	$iotHub = Get-AzureRmIotHub -ResourceGroupName $ResourceGroupName -Name $IotHubName 

	Assert-True { $allIotHubsInResourceGroup.Count -eq 1 }
	Assert-True { $iotHub.Name -eq $IotHubName }
	Assert-True { $iotHub.Properties.Routing.Routes.Count -eq 1}
    Assert-True { $iotHub.Properties.Routing.Routes[0].Name -eq "route"}
    Assert-True { $iotHub.Properties.Routing.Endpoints.EventHubs[0].Name -eq "eh1"}

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
	Add-AzureRmIotHubKey -ResourceGroupName $ResourceGroupName -Name $IotHubName -KeyName iothubowner1 -Rights RegistryRead

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

	# Routing Properties Update
	$routingProperties = New-Object Microsoft.Azure.Commands.Management.IotHub.Models.PSRoutingProperties
	$routeProp = New-Object Microsoft.Azure.Commands.Management.IotHub.Models.PSRouteMetadata
	$routeProp.Name = "route1"
	$routeProp.Condition = "true"
	$routeProp.IsEnabled = 1
	$routeProp.EndpointNames = New-Object 'System.Collections.Generic.List[String]'
	$routeProp.EndpointNames.Add("events")
	$routeProp.Source = "DeviceMessages"
	$routingProperties.Routes = New-Object 'System.Collections.Generic.List[Microsoft.Azure.Commands.Management.IotHub.Models.PSRouteMetadata]'
	$routingProperties.Routes.Add($routeProp)
	$iotHubUpdated = Set-AzureRmIotHub -ResourceGroupName $ResourceGroupName -Name $IotHubName -RoutingProperties $routingProperties
    Assert-True { $iotHubUpdated.Properties.Routing.Routes.Count -eq 1}
    Assert-True { $iotHubUpdated.Properties.Routing.Routes[0].Name -eq "route1"}

	# Route Properties Update
	$routeProp1 = New-Object Microsoft.Azure.Commands.Management.IotHub.Models.PSRouteMetadata
	$routeProp1.Name = "route2"
	$routeProp1.Condition = "true"
	$routeProp1.IsEnabled = 1
	$routeProp1.EndpointNames = New-Object 'System.Collections.Generic.List[String]'
	$routeProp1.EndpointNames.Add("events")
	$routeProp1.Source = "DeviceMessages"

	$routeProp2 = New-Object Microsoft.Azure.Commands.Management.IotHub.Models.PSRouteMetadata
	$routeProp2.Name = "route3"
	$routeProp2.Condition = "true"
	$routeProp2.IsEnabled = 1
	$routeProp2.EndpointNames = New-Object 'System.Collections.Generic.List[String]'
	$routeProp2.EndpointNames.Add("events")
	$routeProp2.Source = "DeviceMessages"

	$routes = New-Object 'System.Collections.Generic.List[Microsoft.Azure.Commands.Management.IotHub.Models.PSRouteMetadata]'
	$routes.Add($routeProp1)
	$routes.Add($routeProp2)
	$iotHubUpdated = Set-AzureRmIotHub -ResourceGroupName $ResourceGroupName -Name $IotHubName -Routes $routes	
    Assert-True { $iotHubUpdated.Properties.Routing.Routes.Count -eq 2}
    Assert-True { $iotHubUpdated.Properties.Routing.Routes[0].Name -eq "route2"}
	Assert-True { $iotHubUpdated.Properties.Routing.FallbackRoute.IsEnabled -eq 0}

	$iothub = Get-AzureRmIotHub -ResourceGroupName $ResourceGroupName -Name $IotHubName 
	$iothub.Properties.Routing.FallbackRoute.IsEnabled = 1
	$iotHubUpdated = Set-AzureRmIotHub -ResourceGroupName $ResourceGroupName -Name $IotHubName -FallbackRoute $iothub.Properties.Routing.FallbackRoute	
    Assert-True { $iotHubUpdated.Properties.Routing.FallbackRoute.IsEnabled -eq 1}

	# Remove IotHub
	Remove-AzureRmIotHub -ResourceGroupName $ResourceGroupName -Name $IotHubName
}