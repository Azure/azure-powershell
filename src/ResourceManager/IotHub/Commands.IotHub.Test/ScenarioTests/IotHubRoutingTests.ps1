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
	$IotHubName = getAssetName
	$ResourceGroupName = getAssetName
	$namespaceName = getAssetName 'eventHub'
	$eventHubName = getAssetName
	$authRuleName = getAssetName
	$endpointName = getAssetName
	$routeName = getAssetName
	$Sku = "S1"
	$EndpointTypeEventHub = [Microsoft.Azure.Commands.Management.IotHub.Models.PSEndpointType] "EventHub"
	$RoutingSourceTwinChangeEvents = [Microsoft.Azure.Commands.Management.IotHub.Models.PSRoutingSource] "TwinChangeEvents"
	$RoutingSourceDeviceMessages = [Microsoft.Azure.Commands.Management.IotHub.Models.PSRoutingSource] "DeviceMessages"

	# Create or Update Resource Group
	$resourceGroup = New-AzureRmResourceGroup -Name $ResourceGroupName -Location $Location 

	# Create Iot Hub
	$iothub = New-AzureRmIotHub -Name $IotHubName -ResourceGroupName $ResourceGroupName -Location $Location -SkuName $Sku -Units 1 

	# Create new eventHub namespace  
    $eventHubNamespace = New-AzureRmEventHubNamespace -ResourceGroup $ResourceGroupName -NamespaceName $namespaceName -Location $Location
	Wait-Seconds 15
	Assert-True {$eventHubNamespace.ProvisioningState -eq "Succeeded"}
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
	$newRoutingEndpoint = Add-AzureRmIotHubRoutingEndpoint -ResourceGroupName $ResourceGroupName -Name $IotHubName -EndpointName $endpointName -EndpointType $EndpointTypeEventHub -EndpointResourceGroup $eventHubResourceGroup -EndpointSubscriptionId $eventHubSubscriptionId -ConnectionString $ehConnectionString
	Assert-True { $newRoutingEndpoint.ResourceGroup -eq $eventHubResourceGroup}
	Assert-True { $newRoutingEndpoint.SubscriptionId -eq $eventHubSubscriptionId}
	Assert-True { $newRoutingEndpoint.Name -eq $endpointName}

	# Get all routing endpoints
	$updatedRoutingEndpoints = Get-AzureRmIotHubRoutingEndpoint -ResourceGroupName $ResourceGroupName -Name $IotHubName
	Assert-True { $updatedRoutingEndpoints.Count -eq 1}
	Assert-True { $updatedRoutingEndpoints[0].ResourceGroup -eq $eventHubResourceGroup}
	Assert-True { $updatedRoutingEndpoints[0].SubscriptionId -eq $eventHubSubscriptionId}
	Assert-True { $updatedRoutingEndpoints[0].Name -eq $endpointName}

	# Get all routes
	$routes = Get-AzureRmIotHubRoute -ResourceGroupName $ResourceGroupName -Name $IotHubName
	Assert-True { $routingEndpoints.Count -eq 0}

	# Add new route
	$newRoute = Add-AzureRmIotHubRoute -ResourceGroupName $ResourceGroupName -Name $IotHubName -RouteName $routeName -Source $RoutingSourceDeviceMessages -EndpointName $endpointName
	Assert-True { $newRoute.Name -eq $routeName}
	Assert-True { $newRoute.Source -eq $RoutingSourceDeviceMessages}
	Assert-True { $newRoute.EndpointNames -eq $endpointName}
	Assert-False { $newRoute.IsEnabled }

	# Get all routes
	$routes = Get-AzureRmIotHubRoute -ResourceGroupName $ResourceGroupName -Name $IotHubName
	Assert-True { $routes.Count -eq 1}
	Assert-True { $routes[0].Name -eq $routeName}
	Assert-True { $routes[0].Source -eq $RoutingSourceDeviceMessages}
	Assert-True { $routes[0].EndpointNames -eq $endpointName}
	Assert-False { $routes[0].IsEnabled }

	# Set route 
	$updatedRoute = Set-AzureRmIotHubRoute -ResourceGroupName $ResourceGroupName -Name $IotHubName -RouteName $routeName -Source $RoutingSourceTwinChangeEvents -Enabled
	Assert-True { $updatedRoute.Name -eq $routeName}
	Assert-True { $updatedRoute.Source -eq $RoutingSourceTwinChangeEvents}
	Assert-True { $updatedRoute.EndpointNames -eq $endpointName}
	Assert-True { $updatedRoute.IsEnabled }

	# Test All Routes
	$testRouteOutput = Test-AzureRmIotHubRoute -ResourceGroupName $ResourceGroupName -Name $IotHubName -Source $RoutingSourceTwinChangeEvents
	Assert-True { $testRouteOutput.Count -eq 1}
	Assert-True { $testRouteOutput[0].Name -eq $routeName}
	Assert-True { $testRouteOutput[0].Source -eq $RoutingSourceTwinChangeEvents}
	Assert-True { $testRouteOutput[0].EndpointNames -eq $endpointName}
	Assert-True { $testRouteOutput[0].IsEnabled }

	# Delete Route
	$result = Remove-AzureRmIotHubRoute -ResourceGroupName $ResourceGroupName -Name $IotHubName -RouteName $routeName -Passthru
	Assert-True { $result }

	# Delete routing endpoint
	$result = Remove-AzureRmIotHubRoutingEndpoint -ResourceGroupName $ResourceGroupName -Name $IotHubName -EndpointName $endpointName -Passthru
	Assert-True { $result }

	# Remove IotHub
	Remove-AzureRmIotHub -ResourceGroupName $ResourceGroupName -Name $IotHubName
}