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


####################################
## IotHub Configuration Cmdlets	  ##
####################################

<#
.SYNOPSIS
Test all iothub configuration cmdlets
#>
function Test-AzureRmIotHubConfigurationLifecycle
{
	$Location = Get-Location "Microsoft.Devices" "IotHubs"
	$IotHubName = getAssetName
	$ResourceGroupName = getAssetName
	$Sku = "S1"
	$device1 = getAssetName
	$config1 = getAssetName
	$config2 = getAssetName

	# Create Resource Group
	$resourceGroup = New-AzResourceGroup -Name $ResourceGroupName -Location $Location 

	# Create Iot Hub
	$iothub = New-AzIotHub -Name $IotHubName -ResourceGroupName $ResourceGroupName -Location $Location -SkuName $Sku -Units 1

	# Add iot device 
	$newDevice1 = Add-AzIotHubDevice -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1 -AuthMethod 'shared_private_key'
	Assert-True { $newDevice1.Id -eq $device1 }
	Assert-False { $newDevice1.Capabilities.IotEdge }

	# Update device twin
	$tags = @{}
	$tags.Add('location', 'US')
	$deviceTwin = Update-AzIotHubDeviceTwin -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -DeviceId $device1 -tag $tags
	Assert-True { $deviceTwin.DeviceId -eq $device1}
	Assert-True { $deviceTwin.tags.Count -eq 1}

	# Assign device configuration parameters
	$labels = @{}
	$labels.add("key0","value0")
	$metrics = @{}
	$metrics.add("query1", "select deviceId from devices where tags.location='US'")
	$prop = @{}
	$prop.add("Location", "US")
	$content = @{}
	$content.add("properties.desired.Region", $prop)
	$condition = "tags.location='US'"
	$priority = 10
	$updatedPriority = 8

	# Add device configuration
	$newConfiguration = Add-AzIotHubConfiguration -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -Name $config1 -Priority $priority -TargetCondition $condition -Label $labels -Metric $metrics -DeviceContent $content
	Assert-True { $newConfiguration.Id -eq $config1}

	# Get device configuration details
	$configuration = Get-AzIotHubConfiguration -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -Name $config1
	Assert-True { $configuration.Id -eq $config1}
	Assert-True { $configuration.TargetCondition -eq $condition}
	Assert-True { $configuration.Priority -eq $priority}
	Assert-True { $configuration.Labels.Count -eq 1}
	Assert-True { $configuration.Metrics.Count -eq 1}

	# Set device configuration
	$updatedConfiguration = Set-AzIotHubConfiguration -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -Name $config1 -Priority $updatedPriority
	Assert-True { $updatedConfiguration.Id -eq $config1}
	Assert-True { $updatedConfiguration.Priority -eq $updatedPriority}

	# Invoke configuration metric query
	$customMetricResult = Invoke-AzIotHubConfigurationMetricsQuery -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -Name $config1 -MetricName "query1"
	Assert-True { $customMetricResult.Name -eq "query1"}
	Assert-True { $customMetricResult.Criteria -eq "select deviceId from devices where tags.location='US'"}

	$systemMetricResult = Invoke-AzIotHubConfigurationMetricsQuery -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -Name $config1 -MetricName "targeted" -MetricType "System"
	Assert-True { $systemMetricResult.Name -eq "targeted"}
	Assert-True { $systemMetricResult.Criteria -eq "select deviceId from devices where tags.location='US'"}

	# Expected error while executing configuration metric query
	$errorMessage = "The configuration doesn't exist."
	Assert-ThrowsContains { Invoke-AzIotHubConfigurationMetricsQuery -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -Name "InvalidConfig" -MetricName "InvalidMetricName" } $errorMessage
	
	# Expected error while executing configuration metric query
	$errorMessage = "The metric 'InvalidMetricName' is not defined in the configuration '$config1'"
	Assert-ThrowsContains { Invoke-AzIotHubConfigurationMetricsQuery -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -Name $config1 -MetricName "InvalidMetricName" } $errorMessage
	
	# Delete all configuration
	$result = Remove-AzIotHubConfiguration -ResourceGroupName $ResourceGroupName -IotHubName $IotHubName -Passthru
	Assert-True { $result }

	# Remove IotHub
	Remove-AzIotHub -ResourceGroupName $ResourceGroupName -Name $IotHubName
}