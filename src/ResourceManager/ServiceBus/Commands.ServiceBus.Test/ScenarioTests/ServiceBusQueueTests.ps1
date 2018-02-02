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
Tests Queue Namespace Create List Remove operations.
#>
function ServiceBusQueueTests
{
    # Setup    
    $location = Get-Location
    $resourceGroupName = getAssetName "RGName-"
	$namespaceName = getAssetName "Namespace-"
	$nameQueue = getAssetName "Queue-"
    
	Write-Debug "ResourceGroup name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force
    
    Write-Debug " Create new Queue Namespace: $namespaceName"
    $result = New-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Location $location -Name $namespaceName
    
    Write-Debug "Get the created namespace within the resource group"
    $createdNamespace = Get-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName
	    
    Assert-AreEqual $createdNamespace.Name $namespaceName "Created Namespace not found"

	Write-Debug "Create Queue"	
	$result = New-AzureRmServiceBusQueue -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $nameQueue
	Assert-AreEqual $result.Name $nameQueue "In CreateQueue response Name not found"

	$resultGetQueue = Get-AzureRmServiceBusQueue -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $result.Name
	Assert-AreEqual $resultGetQueue.Name $result.Name "In GetQueue response, QueueName not found"
	
	$resultGetQueue.EnableExpress = $True
	$resultGetQueue.DeadLetteringOnMessageExpiration = $True
	$resultGetQueue.MaxDeliveryCount = 5
	$resultGetQueue.MaxSizeInMegabytes = 1024

	$resltSetQueue = Set-AzureRmServiceBusQueue -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $resultGetQueue.Name -InputObject $resultGetQueue
	Assert-AreEqual $resltSetQueue.Name $resultGetQueue.Name "In GetQueue response, QueueName not found"

	# Get all Queues
	$ResulListQueue = Get-AzureRmServiceBusQueue -ResourceGroupName $resourceGroupName -Namespace $namespaceName
	Assert-True {$ResulListQueue.Count -gt 0} "no queues were found in ListQueue"

	# Delete the created Queue
	$ResultDeleteQueue = Remove-AzureRmServiceBusQueue -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $ResulListQueue[0].Name
	Assert-True {$ResultDeleteQueue} "Queue not deleted"

	# Cleanup
	# Delete all Created Queue
	Write-Debug " Delete the Queue"
	for ($i = 0; $i -lt $ResulListQueue.Count; $i++)
	{
		$delete1 = Remove-AzureRmServiceBusQueue -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $ResulListQueue[$i].Name		
	}

    Write-Debug " Delete namespaces"
    Remove-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName

	Write-Debug " Delete resourcegroup"
	Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}


<#
.SYNOPSIS
Tests ServiceBus Queue AuthorizationRules Create List Remove operations.
#>
function ServiceBusQueueAuthTests
{
    # Setup    
    $location = Get-Location
    $resourceGroupName = getAssetName "RGName-"
	$namespaceName = getAssetName "Namespace-"
	$queueName = getAssetName "Queue-"
    $authRuleName = getAssetName "authorule-"

	# Create ResourceGroup
    Write-Debug " Create resource group"    
    Write-Debug "Resource group name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force
	   
    # Create Queue Namespace 
    Write-Debug " Create new ServiceBus namespace"
    Write-Debug "Namespace name : $namespaceName"
    $result = New-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Location $location -Name $namespaceName   
    
	# Assert
	Assert-AreEqual $result.ProvisioningState "Succeeded"

	# Get Created NameSpace
    Write-Debug " Get the created namespace within the resource group"
    $createdNamespace = Get-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName
    
	# Assert
    Assert-AreEqual $createdNamespace.Name $namespaceName "Created Namespace not found"

	# Create New Queue
    Write-Debug " Create new Queue "    
	$msgRetentionInDays = 3
	$partionCount = 2
    $result_Queue = New-AzureRmServiceBusQueue -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $queueName -EnablePartitioning $TRUE

	Assert-AreEqual $result_Queue.Name $queueName "Created Queue not found"

	
    Write-Debug "Get the created Queue"
    $getQueue = Get-AzureRmServiceBusQueue -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $result_Queue.Name

	# Assert
    Assert-AreEqual $getQueue.Name $queueName "Get-Queue, created queue not found"

	# Create Queue Authorization Rule
    Write-Debug "Create a Queue Authorization Rule"
    $result = New-AzureRmServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Queue $queueName -Name $authRuleName -Rights @("Listen","Send")

	# Assert
    Assert-AreEqual $authRuleName $result.Name
    Assert-AreEqual 2 $result.Rights.Count
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" }
    

	# Get Created Queue Authorization Rule
    Write-Debug "Get created authorizationRule"
    $createdAuthRule = Get-AzureRmServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Queue $queueName -Name $authRuleName

	# Assert
    Assert-AreEqual $authRuleName $createdAuthRule.Name
    Assert-AreEqual 2 $createdAuthRule.Rights.Count
    Assert-True { $createdAuthRule.Rights -Contains "Listen" }
    Assert-True { $createdAuthRule.Rights -Contains "Send" }

	# Get all Queue Authorization Rules
    Write-Debug "Get All Queue AuthorizationRule"
    $result = Get-AzureRmServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Queue $queueName
	# Assert
	Assert-AreEqual $result.Name $authRuleName
    Assert-AreEqual 2 $result.Rights.Count
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" }
    
	# Update the Queue Authorization Rule
    Write-Debug "Update Queue AuthorizationRule"
	$createdAuthRule.Rights.Add("Manage")
    $updatedAuthRule = Set-AzureRmServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Queue $queueName -Name $authRuleName -InputObject $createdAuthRule
    
	# Assert
    Assert-AreEqual $authRuleName $updatedAuthRule.Name "Queue AuthorizationRule created earlier is not found."
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }
	   
    # get the Updated Queue Authorization Rule
    $updatedAuthRule = Get-AzureRmServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Queue $queueName -Name $authRuleName
    
	# Assert
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }
	
	# Get the List Keys
    Write-Debug "Get Queue authorizationRules connectionStrings"
    $namespaceListKeys = Get-AzureRmServiceBusKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Queue $queueName -Name $authRuleName

    Assert-True {$namespaceListKeys.PrimaryConnectionString.Contains($updatedAuthRule.PrimaryKey)}
    Assert-True {$namespaceListKeys.SecondaryConnectionString.Contains($updatedAuthRule.SecondaryKey)}
	
	# Regentrate the Keys 
	$policyKey = "PrimaryKey"

	$namespaceRegenerateKeys = New-AzureRmServiceBusKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Queue $queueName -Name $authRuleName -RegenerateKey $policyKey
	Assert-True {$namespaceRegenerateKeys.PrimaryKey -ne $namespaceListKeys.PrimaryKey}

	$policyKey1 = "SecondaryKey"

	$namespaceRegenerateKeys1 = New-AzureRmServiceBusKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Queue $queueName -Name $authRuleName -RegenerateKey $policyKey1
	Assert-True {$namespaceRegenerateKeys1.SecondaryKey -ne $namespaceListKeys.SecondaryKey}
	
	# Cleanup
    Write-Debug "Delete the created Queue AuthorizationRule"
    $result = Remove-AzureRmServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Queue $queueName -Name $authRuleName -Force
    
    
	# Cleanup
	# Delete all Created Queue
	Write-Debug " Delete the Queue"

	Write-Debug "Get the created Queues"
    $createdQueues = Get-AzureRmServiceBusQueue -ResourceGroupName $resourceGroupName -Namespace $namespaceName 
	for ($i = 0; $i -lt $createdQueues.Count; $i++)
	{
		$delete1 = Remove-AzureRmServiceBusQueue -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $createdQueues[$i].Name		
	}
    

    Write-Debug "Delete NameSpace"
	 $createdNamespaces = Get-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName
	for ($i = 0; $i -lt $createdNamespaces.Count; $i++)
	{
		Remove-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $createdNamespaces[$i].Name
	}

	Write-Debug " Delete resourcegroup"
	Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}