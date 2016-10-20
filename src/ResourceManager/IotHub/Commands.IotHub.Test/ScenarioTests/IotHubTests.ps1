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

	# Create Resource Group
	$resourceGroup = New-AzureRmResourceGroup -Name $global:resourceGroupName -Location $global:location -Confirm:$true

	# Create Iot Hub
	$newIothub1 = New-AzureRmIotHub -Name $global:iotHubName -ResourceGroupName $global:resourceGroupName -Location $global:location -SkuName $global:sku -Units 1

	# Get Iot Hub in resourcegroup
	$allIotHubsInResourceGroup =  Get-AzureRmIotHub -ResourceGroupName $resourceGroup.ResourceGroupName 
	
	# Get Iot Hub
	$iotHub = Get-AzureRmIotHub -ResourceGroupName $resourceGroup.ResourceGroupName -Name $global:iotHubName 

	Assert-True { $allIotHubsInResourceGroup.Count -eq 1 }
	Assert-True { $iotHub.Name -eq $global:iotHubName }
}
