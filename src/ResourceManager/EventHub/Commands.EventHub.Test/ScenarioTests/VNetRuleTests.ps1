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
Tests New Parameter names EventHubs Create List Remove operations.
#>

function VNetRuleTests
{
	# Setup    
	$location = Get-Location
	$resourceGroupName = getAssetName "RSG"
	$namespaceName = getAssetName "EH-NS-"
	$VNetRule = getAssetName "VNetRule-"
	$VNetRule2 = getAssetName "VNetRule-"

	# Create Resource Group
	Write-Debug "Create resource group"    
	Write-Debug " Resource Group Name : $resourceGroupName"
	New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force	
		
	# Create EventHub Namespace
	Write-Debug "  Create new eventhub namespace"
	Write-Debug " Namespace name : $namespaceName"
	$result = New-AzureRmEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName -Location $location

	# Assert
	Assert-AreEqual $result.Name $namespaceName	"New Namespace: Namespace created earlier is not found."

	# get the created Eventhub Namespace 
	Write-Debug " Get the created namespace within the resource group"
	$createdNamespace = Get-AzureRmEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName
	
	Assert-AreEqual $createdNamespace.Name $namespaceName "Get Namespace: Namespace created earlier is not found."
	
	# Create a VNetRule
	Write-Debug " Create new VNetRule "	
	$result = New-AzureRmEventHubVNetRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $VNetRule -VirtualNetworkSubnetId "/subscriptions/854d368f-1828-428f-8f3c-f2affa9b2f7d/resourceGroups/EventHubClusterRG/providers/Microsoft.Network/virtualNetworks/sbehvnettest1/subnets/default"
			
	Write-Debug " Get the created VNetRule "
	$createdVNetRule = Get-AzureRmEventHubVNetRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $result.Name

	# Assert
	Assert-AreEqual $createdVNetRule.Name $VNetRule "Get VNet Rule: VNet Rule created earlier is not found."	
	
	
	# Create a VNetRule	-2
	Write-Debug " Create new VNetRule "	
	$result2 = New-AzureRmEventHubVNetRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $VNetRule2 -VirtualNetworkSubnetId "/subscriptions/854d368f-1828-428f-8f3c-f2affa9b2f7d/resourceGroups/EventHubClusterRG/providers/Microsoft.Network/virtualNetworks/sbehvnettest1/subnets/default"
			
	Write-Debug " Get the created VNetRule "
	$createdVNetRule2 = Get-AzureRmEventHubVNetRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $result2.Name

	# Assert
	Assert-AreEqual $createdVNetRule2.Name $VNetRule2 "Get VNet Rule: VNet Rule created earlier is not found."    

	# Get all Created IP Filter Rule
	Write-Debug " Get all the created Filter rule "
	$ListAllVNetRule = Get-AzureRmEventHubVNetRule -ResourceGroup $resourceGroupName -Namespace $namespaceName

	# Assert
	Assert-AreEqual $ListAllVNetRule.Count 2 "List Eventhub: EventHub created earlier is not found in list"

	# Update the Created EventHub
	$updatedVNetRule = Set-AzureRmEventHubVNetRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $createdVNetRule2.Name  -InputObject $createdVNetRule
	
	# Assert
	Assert-AreEqual $updatedVNetRule.Name $createdVNetRule2.Name
	
	# Cleanup
	# Delete all Created Eventhub
	Write-Debug " Delete the EventHub"
	for ($i = 0; $i -lt $ListAllVNetRule.Count; $i++)
	{
		$delete1 = Remove-AzureRmEventHubVNetRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $ListAllVNetRule[$i].Name		
	}

	Write-Debug " Delete namespaces"
	Remove-AzureRmEventHubNamespace -ResourceGroup $resourceGroupName -Namespace $namespaceName

	Write-Debug " Delete resourcegroup"
	#Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}