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
## IotHub Routing Cmdlets	   ##
#################################

<#
.SYNOPSIS
Test all iothub routing cmdlets
#>
function Test-AzureRmIotHubRoutingLifecycle
{
	##############################################################
	# Set these to the proper azure storage account information.
	$auzreStorageResourceGroupName = 'pshardcodedrg1234'
	$auzreStorageSubscriptionId = '91d12660-3dec-467a-be2a-213b5544ddc0'
	$ascConnectionString = 'DefaultEndpointsProtocol=https;AccountName=pshardcodedstorage1234;AccountKey=W1ujKNLtPmMtaNqZfOCUU5cnYMI8bQeF9ODce4riISyT2RSXiIxcwuwQhzCmIuwPWi82ParLfbq1bOF5ypUnPw==;EndpointSuffix=core.windows.net'
	$containerName1 = 'container1'
	$containerName2 = 'container2'
	##############################################################

	$Location = Get-Location "Microsoft.Devices" "IotHub" 
	$IotHubName = getAssetName
	$ResourceGroupName = getAssetName
	$namespaceName = getAssetName 'eventHub'
	$eventHubName = getAssetName
	$authRuleName = getAssetName
	$endpointName = getAssetName
	$endpointName1 = getAssetName
	$endpointName2 = getAssetName
	$routeName = getAssetName
	$Sku = "S1"
	$EndpointTypeEventHub = [Microsoft.Azure.Commands.Management.IotHub.Models.PSEndpointType] "EventHub"
	$EndpointTypeAzureStorage = [Microsoft.Azure.Commands.Management.IotHub.Models.PSEndpointType] "AzureStorageContainer"
	$RoutingSourceTwinChangeEvents = [Microsoft.Azure.Commands.Management.IotHub.Models.PSRoutingSource] "TwinChangeEvents"
	$RoutingSourceDeviceMessages = [Microsoft.Azure.Commands.Management.IotHub.Models.PSRoutingSource] "DeviceMessages"

	# Create or Update Resource Group
	$resourceGroup = New-AzResourceGroup -Name $ResourceGroupName -Location $Location 

	# Create Iot Hub
	$iothub = New-AzIotHub -Name $IotHubName -ResourceGroupName $ResourceGroupName -Location $Location -SkuName $Sku -Units 1 

	# Create new eventHub namespace  
    $eventHubNamespace = New-AzEventHubNamespace -ResourceGroup $ResourceGroupName -NamespaceName $namespaceName -Location $Location
	Wait-Seconds 15
	Assert-True {$eventHubNamespace.ProvisioningState -eq "Succeeded"}
	$regexMatches = $eventHubNamespace.Id | Select-String -Pattern '^/subscriptions/(.*)/resourceGroups/(.*)/providers/(.*)$'
	$eventHubSubscriptionId = $regexMatches.Matches.Groups[1].Value
	$eventHubResourceGroup = $regexMatches.Matches.Groups[2].Value

    # Create new eventHub     
	$msgRetentionInDays = 3
	$partionCount = 2
    $eventHub = New-AzEventHub -ResourceGroup $ResourceGroupName -NamespaceName $namespaceName -EventHubName $eventHubName -MessageRetentionInDays $msgRetentionInDays -PartitionCount $partionCount

	# Create AuthRule for eventhub
	$rights = "Listen","Send"
	$authRule = New-AzEventHubAuthorizationRule -ResourceGroup $ResourceGroupName -NamespaceName $namespaceName  -EventHubName $eventHubName -AuthorizationRuleName $authRuleName -Rights $rights
	$keys = Get-AzEventHubKey -ResourceGroup $ResourceGroupName -NamespaceName $namespaceName  -EventHubName $eventHubName -AuthorizationRuleName $authRuleName
	$ehConnectionString = $keys.PrimaryConnectionString

	# Get all routing endpoints
	$routingEndpoints = Get-AzIotHubRoutingEndpoint -ResourceGroupName $ResourceGroupName -Name $IotHubName
	Assert-True { $routingEndpoints.Count -eq 0}

	# Add event hub endpoint
	$newRoutingEndpoint = Add-AzIotHubRoutingEndpoint -ResourceGroupName $ResourceGroupName -Name $IotHubName -EndpointName $endpointName -EndpointType $EndpointTypeEventHub -EndpointResourceGroup $eventHubResourceGroup -EndpointSubscriptionId $eventHubSubscriptionId -ConnectionString $ehConnectionString
	Assert-True { $newRoutingEndpoint.ResourceGroup -eq $eventHubResourceGroup}
	Assert-True { $newRoutingEndpoint.SubscriptionId -eq $eventHubSubscriptionId}
	Assert-True { $newRoutingEndpoint.Name -eq $endpointName}

	# Add azure storage endpoint with encoding format "json"
	$newRoutingEndpoint1 = Add-AzureRmIotHubRoutingEndpoint -ResourceGroupName $ResourceGroupName -Name $IotHubName -EndpointName $endpointName1 -EndpointType $EndpointTypeAzureStorage -EndpointResourceGroup $auzreStorageResourceGroupName -EndpointSubscriptionId $auzreStorageSubscriptionId -ConnectionString $ascConnectionString -ContainerName $containerName1 -Encoding json
	Assert-True { $newRoutingEndpoint1.Name -eq $endpointName1}
	Assert-True { $newRoutingEndpoint1.ResourceGroup -eq $auzreStorageResourceGroupName}
	Assert-True { $newRoutingEndpoint1.SubscriptionId -eq $auzreStorageSubscriptionId}
	Assert-True { $newRoutingEndpoint1.Encoding -eq "json"}

	# Add azure storage endpoint with default encoding format
	$newRoutingEndpoint2 = Add-AzureRmIotHubRoutingEndpoint -ResourceGroupName $ResourceGroupName -Name $IotHubName -EndpointName $endpointName2 -EndpointType $EndpointTypeAzureStorage -EndpointResourceGroup $auzreStorageResourceGroupName -EndpointSubscriptionId $auzreStorageSubscriptionId -ConnectionString $ascConnectionString -ContainerName $containerName2
	Assert-True { $newRoutingEndpoint2.Name -eq $endpointName2}
	Assert-True { $newRoutingEndpoint2.ResourceGroup -eq $auzreStorageResourceGroupName}
	Assert-True { $newRoutingEndpoint2.SubscriptionId -eq $auzreStorageSubscriptionId}
	Assert-True { $newRoutingEndpoint2.Encoding -eq "avro"}

	# Get all routing endpoints
	$updatedRoutingEndpoints = Get-AzureRmIotHubRoutingEndpoint -ResourceGroupName $ResourceGroupName -Name $IotHubName
	Assert-True { $updatedRoutingEndpoints.Count -eq 3}
	Assert-True { $updatedRoutingEndpoints[0].Name -eq $endpointName}
	Assert-True { $updatedRoutingEndpoints[0].EndpointType -eq $EndpointTypeEventHub}
	Assert-True { $updatedRoutingEndpoints[1].Name -eq $endpointName1}
	Assert-True { $updatedRoutingEndpoints[1].EndpointType -eq $EndpointTypeAzureStorage}
	Assert-True { $updatedRoutingEndpoints[2].Name -eq $endpointName2}
	Assert-True { $updatedRoutingEndpoints[2].EndpointType -eq $EndpointTypeAzureStorage}

	# Delete routing endpoints
	$result = Remove-AzureRmIotHubRoutingEndpoint -ResourceGroupName $ResourceGroupName -Name $IotHubName -EndpointName $endpointName1 -Passthru
	Assert-True { $result }
	$result = Remove-AzureRmIotHubRoutingEndpoint -ResourceGroupName $ResourceGroupName -Name $IotHubName -EndpointName $endpointName2 -Passthru
	Assert-True { $result }

	# Get all routing endpoints
	$updatedRoutingEndpoints = Get-AzIotHubRoutingEndpoint -ResourceGroupName $ResourceGroupName -Name $IotHubName
	Assert-True { $updatedRoutingEndpoints.Count -eq 1}
	Assert-True { $updatedRoutingEndpoints[0].ResourceGroup -eq $eventHubResourceGroup}
	Assert-True { $updatedRoutingEndpoints[0].SubscriptionId -eq $eventHubSubscriptionId}
	Assert-True { $updatedRoutingEndpoints[0].Name -eq $endpointName}

	# Get all routes
	$routes = Get-AzIotHubRoute -ResourceGroupName $ResourceGroupName -Name $IotHubName
	Assert-True { $routes.Count -eq 0}

	# Add new route
	$newRoute = Add-AzIotHubRoute -ResourceGroupName $ResourceGroupName -Name $IotHubName -RouteName $routeName -Source $RoutingSourceDeviceMessages -EndpointName $endpointName
	Assert-True { $newRoute.Name -eq $routeName}
	Assert-True { $newRoute.Source -eq $RoutingSourceDeviceMessages}
	Assert-True { $newRoute.EndpointNames -eq $endpointName}
	Assert-False { $newRoute.IsEnabled }

	# Get all routes
	$routes = Get-AzIotHubRoute -ResourceGroupName $ResourceGroupName -Name $IotHubName
	Assert-True { $routes.Count -eq 1}
	Assert-True { $routes[0].Name -eq $routeName}
	Assert-True { $routes[0].Source -eq $RoutingSourceDeviceMessages}
	Assert-True { $routes[0].EndpointNames -eq $endpointName}
	Assert-False { $routes[0].IsEnabled }

	# Set route 
	$updatedRoute = Set-AzIotHubRoute -ResourceGroupName $ResourceGroupName -Name $IotHubName -RouteName $routeName -Source $RoutingSourceTwinChangeEvents -Enabled
	Assert-True { $updatedRoute.Name -eq $routeName}
	Assert-True { $updatedRoute.Source -eq $RoutingSourceTwinChangeEvents}
	Assert-True { $updatedRoute.EndpointNames -eq $endpointName}
	Assert-True { $updatedRoute.IsEnabled }

	# Test All Routes
	$testRouteOutput = Test-AzIotHubRoute -ResourceGroupName $ResourceGroupName -Name $IotHubName -Source $RoutingSourceTwinChangeEvents
	Assert-True { $testRouteOutput.Count -eq 1}
	Assert-True { $testRouteOutput[0].Name -eq $routeName}
	Assert-True { $testRouteOutput[0].Source -eq $RoutingSourceTwinChangeEvents}
	Assert-True { $testRouteOutput[0].EndpointNames -eq $endpointName}
	Assert-True { $testRouteOutput[0].IsEnabled }

	# Delete Route
	$result = Remove-AzIotHubRoute -ResourceGroupName $ResourceGroupName -Name $IotHubName -RouteName $routeName -Passthru
	Assert-True { $result }

	# Delete routing endpoint
	$result = Remove-AzIotHubRoutingEndpoint -ResourceGroupName $ResourceGroupName -Name $IotHubName -EndpointName $endpointName -Passthru
	Assert-True { $result }

	# Remove IotHub
	Remove-AzIotHub -ResourceGroupName $ResourceGroupName -Name $IotHubName
}