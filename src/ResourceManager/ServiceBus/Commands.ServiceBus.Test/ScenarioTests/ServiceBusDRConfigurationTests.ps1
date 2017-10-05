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

<#
.SYNOPSIS
Get valid resource group name
#>
function Get-ResourceGroupName
{
	return "RGName-" + (getAssetName)	 
}

<#
.SYNOPSIS
Get valid DR Config name
#>
function Get-SBDRConfigName
{
	return "SBDRConfig-" + (getAssetName)
}

<#
.SYNOPSIS
Get valid Namespace name
#>
function Get-NamespaceName
{
	return "ServiceBus-Namespace-" + (getAssetName)
	
}


<#
.SYNOPSIS
Tests EventHubs DRConfiguration Create List Remove operations.
#>

function ServiceBusDRConfigurationTests
{
	# Setup    
	$location = "South Central US"
	$resourceGroupName = "Default-EventHub-SouthCentralUS"
	$namespaceName1 = Get-NamespaceName
	$namespaceName2 = Get-NamespaceName
	$drConfigName = Get-SBDRConfigName

	# Create Resource Group
	Write-Debug "Create resource group"    
	Write-Debug " Resource Group Name : $resourceGroupName"
	#New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force
			
	# Create EventHub Namespace - 1
	Write-Debug "Create new eventhub namespace 1"
	Write-Debug " Namespace 1 name : $namespaceName1"
	$result1 = New-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName1 -Location $location -SkuName Premium

	# Assert
	Assert-True {$result1.ProvisioningState -eq "Succeeded"}

	$result1 = Set-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName1 -Location $location -SkuName Premium -SkuCapacity 1

	# Create EventHub Namespace - 2
	Write-Debug "  Create new eventhub namespace 2"
	Write-Debug " Namespace 2 name : $namespaceName2"
	$result2 = New-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName2 -Location $location -SkuName Premium

	# Assert
	Assert-True {$result2.ProvisioningState -eq "Succeeded"}	

	 $result2 = Set-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName2 -Location $location -SkuName Premium -SkuCapacity 1

	# get the created Eventhub Namespace  1
	Write-Debug " Get the created namespace within the resource group"
	$createdNamespace1 = Get-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName1
	
	Assert-True {$createdNamespace1.Name -eq $namespaceName1} "Namespace created earlier is not found."

	# get the created Eventhub Namespace  2
	Write-Debug " Get the created namespace within the resource group"
	$createdNamespace2 = Get-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName2
	
	Assert-True {$createdNamespace2.Name -eq $namespaceName2} "Namespace created earlier is not found."	

	# Create a DRConfiguration
	Write-Debug " Create new DRConfiguration"
	$result = New-AzureRmServiceBusDRConfigurations -ResourceGroup $resourceGroupName -NamespaceName $namespaceName1 -Name $drConfigName -PartnerNamespace $namespaceName2
		
	Write-Debug " Get the created DRConfiguration"
	$createdDRConfig = Get-AzureRmServiceBusDRConfigurations -ResourceGroup $resourceGroupName -NamespaceName $namespaceName1 -Name $drConfigName

	# Assert
	Assert-True {$createdDRConfig.PartnerNamespace -eq $namespaceName2} "DRConfig created earlier is not found."

	# Get the Created DRConfiguration
	Write-Debug " Get all the created DRConfiguration"
	$createdServiceBusDRConfigList = Get-AzureRmServiceBusDRConfigurations -ResourceGroup $resourceGroupName -NamespaceName $namespaceName1

	# Assert
	Assert-True {$createdServiceBusDRConfigList.Count -eq 1} "EventHub DRConfig created earlier is not found in list"

	# BreakPairing on Primary Namespace
	Write-Debug "BreakPairing on Primary Namespace"
	Set-AzureRmServiceBusDRConfigurationsBreakPairing -ResourceGroup $resourceGroupName -NamespaceName $namespaceName1 -Name $drConfigName

	# Create a DRConfiguration
	Write-Debug " Create new DRConfiguration"
	$DRresult = New-AzureRmServiceBusDRConfigurations -ResourceGroup $resourceGroupName -NamespaceName $namespaceName1 -Name $drConfigName -PartnerNamespace $namespaceName2

	# FailOver on Secondary Namespace
	Write-Debug "FailOver on Secondary Namespace"
	Set-AzureRmServiceBusDRConfigurationsFailOver -ResourceGroup $resourceGroupName -NamespaceName $namespaceName2 -Name $drConfigName
	
	# Remove created alias

	Remove-AzureRmServiceBusDRConfigurations -ResourceGroup $resourceGroupName -NamespaceName $namespaceName2 -Name $drConfigName
	
	# Cleanup
	# Delete all Created Eventhub
	#Write-Debug " Delete the EventHub"
	#for ($i = 0; $i -lt $createdEventHubList.Count; $i++)
	#{
	#	$delete1 = Remove-AzureRmEventHub -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -EventHubName $createdEventHubList[$i].Name		
	#}
	#Write-Debug " Delete namespaces"
	#Remove-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName

	Write-Debug " Delete resourcegroup"
	#Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}