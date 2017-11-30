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
Get valid EventHub name
#>
function Get-EventHubName
{
    return "EventHub-" + (getAssetName)
}

<#
.SYNOPSIS
Get ConsumerGroup name
#>
function Get-ConsumerGroupName
{
    return "ConsumerGroup-" + (getAssetName)
}

<#
.SYNOPSIS
Get valid Namespace name
#>
function Get-NamespaceName
{
    return "Namespace-" + (getAssetName)
}

<#
.SYNOPSIS
Tests New Parameter for ConsumerGroup Create List Remove operations.
#>
function ConsumerGroupsTests
{ # Setup


    $location = Get-Location
	$resourceGroupName = Get-ResourceGroupName
	$namespaceName = Get-NamespaceName
	$eventHubName = Get-EventHubName
	$consumerGroupName = Get-ConsumerGroupName
    
    Write-Debug "  Create resource group"
    Write-Debug " Resource Group Name : $resourceGroupName"
    $Result11 = New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force
	
	Write-Debug "  Create new Evnethub namespace"
    Write-Debug " Namespace name : $namespaceName"
    $result = New-AzureRmEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName -Location $location
    
    Write-Debug " Get the created namespace within the resource group"
    $createdNamespace = Get-AzureRmEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName
    
    Assert-True {$createdNamespace.Name -eq $namespaceName} "Namespace created earlier is not found."

    Write-Debug " Create new eventHub "
	$msgRetentionInDays = 3
	$partionCount = 2
    $result = New-AzureRmEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $eventHubName -MessageRetentionInDays $msgRetentionInDays -PartitionCount $partionCount
	
    Write-Debug " Get the created eventHub "
    $createdEventHub = Get-AzureRmEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $result.Name 
	
	$createdEventHub = Get-AzureRmEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $eventHubName
    Assert-True {$createdEventHub.Name -eq $eventHubName} "Namespace created earlier is not found."	
	
	Write-Debug " Create a new ConsumerGroup "
	$result_ConsumerGroup = New-AzureRmEventHubConsumerGroup -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHub $eventHubName -Name $consumerGroupName
		
	Write-Debug " Get created ConsumerGroup "
	$CreatedConsumerGroup = Get-AzureRmEventHubConsumerGroup -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHub $eventHubName -Name $result_ConsumerGroup.Name
	
	Write-Debug " Get all created ConsumerGroup "
	$CreatedConsumerGroups = Get-AzureRmEventHubConsumerGroup -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHub $result.Name
	
	# Cleanup
	Write-Debug " Delete created ConsumerGroup "
	Remove-AzureRmEventHubConsumerGroup -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHub $result.Name -Name $CreatedConsumerGroup.Name
	
    Write-Debug " Delete the EventHub"
    $delete1 = Remove-AzureRmEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $result.Name  

    Write-Debug " Delete namespaces"
    Remove-AzureRmEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName

	Write-Debug " Delete resourcegroup"
	Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}