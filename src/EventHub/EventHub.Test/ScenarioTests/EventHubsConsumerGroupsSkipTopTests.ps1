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
Tests -MaxCount parameter for the List operations.
#>

function SkipTopTests
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

	$count = 0

    while($count -lt 10)
	{
		Write-Debug "Create new eventHub "
		$msgRetentionInDays = 3
		$partionCount = 2
		$eventHubName_new = $eventHubName +"_" + $count
		$result = New-AzEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $eventHubName_new -MessageRetentionInDays $msgRetentionInDays -PartitionCount $partionCount
		$count = $count + 1
	}
			
    Write-Debug " Get the created eventHub "
    $listEventHub = Get-AzEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName
    Assert-True { $listEventHub.Count -eq 10 } "List EventHub: EventHub created earlier is not found."
	
	Write-Debug " Get created 5 eventHub "
    $listEventHub = Get-AzEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -MaxCount 5
    Assert-True { $listEventHub.Count -eq 5 } "List EventHub: EventHub created earlier is not found."
	
	$eventHubName_consumer = $eventHubName+"_0"

	$count = 0
	while($count -lt 10 )
	{
		Write-Debug " Create a new ConsumerGroup "		
		$consumerGroupName_new = $consumerGroupName + "_" + $count
		$result_ConsumerGroup = New-AzEventHubConsumerGroup -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHub $eventHubName_consumer -Name $consumerGroupName_new
		Assert-AreEqual $result_ConsumerGroup.Name $consumerGroupName_new "New ConsumerGroup: ConsumerGroup created earlier is not found."	
		$count = $count + 1
	}
	
	Write-Debug " Get all created ConsumerGroup "
	$ListConsumerGroups = Get-AzEventHubConsumerGroup -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHub $eventHubName_consumer -MaxCount 5
	Assert-True { $ListConsumerGroups.Count -eq 5} "List ConsumerGroup: ConsumerGroup created earlier is not found."
		
    Write-Debug " Delete namespaces"
    Remove-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName

	Write-Debug " Delete resourcegroup" 
	Remove-AzResourceGroup -Name $resourceGroupName -Force
}