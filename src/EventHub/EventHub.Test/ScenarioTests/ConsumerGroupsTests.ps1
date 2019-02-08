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
Tests New Parameter for ConsumerGroup Create List Remove operations.
#>

function ConsumerGroupsTests
{ # Setup


    $location = Get-Location
	$resourceGroupName = getAssetName "RSG"
	$namespaceName = getAssetName "Namespace-"
	$eventHubName = getAssetName "EventHub-"
	$consumerGroupName = getAssetName "ConsumerGroup-"
    
    Write-Debug "  Create resource group"
    Write-Debug " Resource Group Name : $resourceGroupName"
    $Result11 = New-AzResourceGroup -Name $resourceGroupName -Location $location -Force
	
	Write-Debug "  Create new Evnethub namespace"
    Write-Debug " Namespace name : $namespaceName"
    $result = New-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName -Location $location
    
    Write-Debug " Get the created namespace within the resource group"
    $createdNamespace = Get-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName    
    Assert-AreEqual $createdNamespace.Name $namespaceName "New Namespace: Namespace created earlier is not found."

    Write-Debug " Create new eventHub "
	$msgRetentionInDays = 3
	$partionCount = 2
    $result = New-AzEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $eventHubName -MessageRetentionInDays $msgRetentionInDays -PartitionCount $partionCount
	
    Write-Debug " Get the created eventHub "
    $createdEventHub = Get-AzEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $result.Name 
    Assert-AreEqual $createdEventHub.Name $eventHubName "Get Namespace: Namespace created earlier is not found."	
	
	Write-Debug " Create a new ConsumerGroup "
	$result_ConsumerGroup = New-AzEventHubConsumerGroup -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHub $eventHubName -Name $consumerGroupName
	Assert-AreEqual $result_ConsumerGroup.Name $consumerGroupName "New ConsumerGroup: ConsumerGroup created earlier is not found."	
		
	Write-Debug " Get created ConsumerGroup "
	$GetConsumerGroup = Get-AzEventHubConsumerGroup -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHub $eventHubName -Name $result_ConsumerGroup.Name
	Assert-AreEqual $GetConsumerGroup.Name $consumerGroupName "Get ConsumerGroup: ConsumerGroup created earlier is not found."	
	
	Write-Debug " Get all created ConsumerGroup "
	$ListConsumerGroups = Get-AzEventHubConsumerGroup -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHub $result.Name
	Assert-True { $ListConsumerGroups.Count -ge 0 } "List ConsumerGroup: ConsumerGroup created earlier is not found."	

	# Cleanup
	Write-Debug " Delete created ConsumerGroup "
	Remove-AzEventHubConsumerGroup -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHub $result.Name -Name $GetConsumerGroup.Name

	Write-Debug " check the if consumergroup is deleted"
	$ListConsumerGroups_afterdelete = Get-AzEventHubConsumerGroup -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHub $result.Name
	Assert-True { $ListConsumerGroups_afterdelete.Count -lt 2 } "List ConsumerGroup: ConsumerGroup deleted earlier is found."	
	
    Write-Debug " Delete the EventHub"
    $delete1 = Remove-AzEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $result.Name  

    Write-Debug " Delete namespaces"
    Remove-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName

	Write-Debug " Delete resourcegroup" 
	Remove-AzResourceGroup -Name $resourceGroupName -Force
}