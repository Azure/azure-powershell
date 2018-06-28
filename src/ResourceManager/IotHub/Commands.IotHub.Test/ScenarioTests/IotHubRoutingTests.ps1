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
## IotHub Routing Cmdlets	   ##
#################################

<#
.SYNOPSIS
Test all iothub routing cmdlets
#>
function Test-AzureRmIotHubRoutingLifecycle
{
	$Location = Get-Location "Microsoft.Devices" "IotHub" 
	$IotHubName = 'sapan-iot-2' 
	$ResourceGroupName = 'sapan-iot-rg' 
	$namespaceName = getAssetName 
	$eventHubName = getAssetName
	$authRuleName = getAssetName
	$endpointName = getAssetName
	$routeName = getAssetName
	$Sku = "S1"

	# Create or Update Resource Group
	#$resourceGroup = New-AzureRmResourceGroup -Name $ResourceGroupName -Location $Location 

	# Create Iot Hub
	#$iothub = New-AzureRmIotHub -Name $IotHubName -ResourceGroupName $ResourceGroupName -Location $Location -SkuName $Sku -Units 1 

	# Create new eventHub namespace  
    $eventHubNamespace = New-AzureRmEventHubNamespace -ResourceGroup $ResourceGroupName -NamespaceName $namespaceName -Location $Location
	Assert-True {$result.ProvisioningState -eq "Succeeded"}
	$regexMatches = $eventHubNamespace.Id | Select-String -Pattern '^/subscriptions/(.*)/resourceGroups/(.*)/providers/(.*)$'
	$eventHubSubscriptionId = $regexMatches.Matches.Groups[1].Value
	$eventHubResourceGroup = $regexMatches.Matches.Groups[2].Value

    # Create new eventHub     
	$msgRetentionInDays = 3
	$partionCount = 2
    $eventHub = New-AzureRmEventHub -ResourceGroup $ResourceGroupName -NamespaceName $namespaceName -EventHubName $eventHubName -MessageRetentionInDays $msgRetentionInDays -PartitionCount $partionCount

	# Create AuthRule for eventhub
	$rights = "Listen","Send"
	$authRule = New-AzureRmEventHubAuthorizationRule -ResourceGroup $ResourceGroupName -NamespaceName $namespaceName  -EventHubName $eventHubName -AuthorizationRuleName $authRuleName -Rights $rights
	$keys = Get-AzureRmEventHubKey -ResourceGroup $ResourceGroupName -NamespaceName $namespaceName  -EventHubName $eventHubName -AuthorizationRuleName $authRuleName
	$ehConnectionString = $keys.PrimaryConnectionString

	# Get all routing endpoints
	$routingEndpoints = Get-AzureRmIotHubRoutingEndpoint -ResourceGroupName $ResourceGroupName -Name $IotHubName
	Assert-True { $routingEndpoints.Count -eq 0}

	# Add event hub endpoint
	$newRoutingEndpoint = Add-AzureRmIotHubRoutingEndpoint -ResourceGroupName $ResourceGroupName -Name $IotHubName -EndpointName $endpointName -EndpointType EventHub -EndpointResourceGroup $eventHubResourceGroup -EndpointSubscriptionId $eventHubSubscriptionId -ConnectionString $ehConnectionString
	Assert-True { $newRoutingEndpoint.ResourceGroupName -eq $eventHubResourceGroup}
	Assert-True { $newRoutingEndpoint.SubscriptionId -eq $eventHubSubscriptionId}
	Assert-True { $newRoutingEndpoint.EndpointName -eq $endpointName}

	# Get all routing endpoints
	$routingEndpoints = Get-AzureRmIotHubRoutingEndpoint -ResourceGroupName $ResourceGroupName -Name $IotHubName
	Assert-True { $routingEndpoints.Count -eq 1}
	Assert-True { $routingEndpoints[0].ResourceGroupName -eq $eventHubResourceGroup}
	Assert-True { $routingEndpoints[0].SubscriptionId -eq $eventHubSubscriptionId}
	Assert-True { $routingEndpoints[0].EndpointName -eq $endpointName}

	# Get all routes
	$routes = Get-AzureRmIotHubRoute -ResourceGroupName $ResourceGroupName -Name $IotHubName
	Assert-True { $routingEndpoints.Count -eq 0}

	# Add new route
	$routeDataSource = 'DeviceMessages'
	$newRoute = Add-AzureRmIotHubRoute -ResourceGroupName $ResourceGroupName -Name $IotHubName -RouteName $routeName -Source $routeDataSource -EndpointName $endpointName
	Assert-True { $newRoute.RouteName -eq $routeName}
	Assert-True { $newRoute.DataSource -eq $routeDataSource}
	Assert-True { $newRoute.EndpointNames -eq $endpointName}
	Assert-False { $newRoute.IsEnabled }

	# Get all routes
	$routes = Get-AzureRmIotHubRoute -ResourceGroupName $ResourceGroupName -Name $IotHubName
	Assert-True { $routes.Count -eq 1}
	Assert-True { $routes[0].RouteName -eq $routeName}
	Assert-True { $routes[0].DataSource -eq $routeDataSource}
	Assert-True { $routes[0].EndpointNames -eq $endpointName}
	Assert-False { $routes[0].IsEnabled }

	# Update route 
	$newRouteDataSource = 'TwinChangeEvents'
	$updatedRoute = Update-AzureRmIotHubRoute -ResourceGroupName $ResourceGroupName -Name $IotHubName -RouteName $routeName -Source $newRouteDataSource -Enabled
	Assert-True { $updatedRoute.RouteName -eq $routeName}
	Assert-True { $updatedRoute.DataSource -eq $newRouteDataSource}
	Assert-True { $updatedRoute.EndpointNames -eq $endpointName}
	Assert-True { $updatedRoute.IsEnabled }

	# Delete Route
	$result = Remove-AzureRmIotHubRoute -ResourceGroupName $ResourceGroupName -Name $IotHubName -RouteName $routeName -Passthru
	Assert-True { $result }

	# Delete routing endpoint
	$result = Remove-AzureRmIotHubRoutingEndpoint -ResourceGroupName $ResourceGroupName -Name $IotHubName -EndpointName $endpointName -Passthru
	Assert-True { $result }

	# Remove IotHub
	# Remove-AzureRmIotHub -ResourceGroupName $ResourceGroupName -Name $IotHubName
}