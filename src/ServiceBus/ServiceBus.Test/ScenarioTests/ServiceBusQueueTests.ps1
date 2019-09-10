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
function ServiceBusQueueTests {
    # Setup    
    $location = Get-Location
    $resourceGroupName = getAssetName "RGName-"
    $namespaceName = getAssetName "Namespace-"
    $nameQueue = getAssetName "Queue-"
    
    Write-Debug "ResourceGroup name : $resourceGroupName"
    New-AzResourceGroup -Name $resourceGroupName -Location $location -Force
    
    Write-Debug " Create new Queue Namespace: $namespaceName"
    $result = New-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Location $location -Name $namespaceName
    
    Write-Debug "Get the created namespace within the resource group"
    $createdNamespace = Get-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName
	    
    Assert-AreEqual $createdNamespace.Name $namespaceName "Created Namespace not found"
	
    $test = Test-AzServiceBusNameAvailability -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $nameQueue -Queue
    Assert-True { $test }
	
    Write-Debug "Create Queue"	
    $result = New-AzServiceBusQueue -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $nameQueue
    Assert-AreEqual $result.Name $nameQueue "In CreateQueue response Name not found"
	
    $test = Test-AzServiceBusNameAvailability -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $nameQueue -Queue
    Assert-False { $test }

    $resultGetQueue = Get-AzServiceBusQueue -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $result.Name
    Assert-AreEqual $resultGetQueue.Name $result.Name "In GetQueue response, QueueName not found"
	
    $resultGetQueue.EnableExpress = $True
    $resultGetQueue.DeadLetteringOnMessageExpiration = $True
    $resultGetQueue.MaxDeliveryCount = 5
    $resultGetQueue.MaxSizeInMegabytes = 1024
    $resultGetQueue.EnableBatchedOperations = $True

    $resltSetQueue = Set-AzServiceBusQueue -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $resultGetQueue.Name -InputObject $resultGetQueue
    Assert-AreEqual $resltSetQueue.Name $resultGetQueue.Name "In GetQueue response, QueueName not found"

    # Get all Queues
    $ResulListQueue = Get-AzServiceBusQueue -ResourceGroupName $resourceGroupName -Namespace $namespaceName
    Assert-True { $ResulListQueue.Count -gt 0 } "no queues were found in ListQueue"

    # Delete the created Queue
    $ResultDeleteQueue = Remove-AzServiceBusQueue -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $ResulListQueue[0].Name -PassThru
    Assert-True { $ResultDeleteQueue } "Queue not deleted"

    # Cleanup
    # Delete all Created Queue
    Write-Debug " Delete the Queue"
    for ($i = 0; $i -lt $ResulListQueue.Count; $i++) {
        $delete1 = Remove-AzServiceBusQueue -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $ResulListQueue[$i].Name		
    }

    Write-Debug " Delete namespaces"
    Remove-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName

    Write-Debug " Delete resourcegroup"
    Remove-AzResourceGroup -Name $resourceGroupName -Force
}


<#
.SYNOPSIS
Tests ServiceBus Queue AuthorizationRules Create List Remove operations.
#>
function ServiceBusQueueAuthTests {
    # Setup    
    $location = Get-Location
    $resourceGroupName = getAssetName "RGName-"
    $namespaceName = getAssetName "Namespace-"
    $queueName = getAssetName "Queue-"
    $authRuleName = getAssetName "authorule-"
    $authRuleNameListen = getAssetName "authorule-"
    $authRuleNameSend = getAssetName "authorule-"
    $authRuleNameAll = getAssetName "authorule-"

    # Create ResourceGroup
    Write-Debug " Create resource group"    
    Write-Debug "Resource group name : $resourceGroupName"
    New-AzResourceGroup -Name $resourceGroupName -Location $location -Force
	   
    # Create Queue Namespace 
    Write-Debug " Create new ServiceBus namespace"
    Write-Debug "Namespace name : $namespaceName"
    $result = New-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Location $location -Name $namespaceName   
    
    # Assert
    Assert-AreEqual $result.ProvisioningState "Succeeded"

    # Get Created NameSpace
    Write-Debug " Get the created namespace within the resource group"
    $createdNamespace = Get-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName
    
    # Assert
    Assert-AreEqual $createdNamespace.Name $namespaceName "Created Namespace not found"

    # Create New Queue
    Write-Debug " Create new Queue "    
    $msgRetentionInDays = 3
    $partionCount = 2
    $result_Queue = New-AzServiceBusQueue -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $queueName -EnablePartitioning $TRUE

    Assert-AreEqual $result_Queue.Name $queueName "Created Queue not found"

	
    Write-Debug "Get the created Queue"
    $getQueue = Get-AzServiceBusQueue -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $result_Queue.Name

    # Assert
    Assert-AreEqual $getQueue.Name $queueName "Get-Queue, created queue not found"

    # Create Queue Authorization Rule
    Write-Debug "Create a Queue Authorization Rule"
    $result = New-AzServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Queue $queueName -Name $authRuleName -Rights @("Listen", "Send")

    # Assert
    Assert-AreEqual $authRuleName $result.Name
    Assert-AreEqual 2 $result.Rights.Count
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" }
    
    $resultListen = New-AzServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Queue $queueName -Name $authRuleNameListen -Rights @("Listen")
    Assert-AreEqual $authRuleNameListen $resultListen.Name
    Assert-AreEqual 1 $resultListen.Rights.Count
    Assert-True { $resultListen.Rights -Contains "Listen" }

    $resultSend = New-AzServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Queue $queueName -Name $authRuleNameSend -Rights @("Send")
    Assert-AreEqual $authRuleNameSend $resultSend.Name
    Assert-AreEqual 1 $resultSend.Rights.Count
    Assert-True { $resultSend.Rights -Contains "Send" }

    $resultAll3 = New-AzServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Queue $queueName -Name $authRuleNameAll -Rights @("Listen", "Send", "Manage")
    Assert-AreEqual $authRuleNameAll $resultAll3.Name
    Assert-AreEqual 3 $resultAll3.Rights.Count
    Assert-True { $resultAll3.Rights -Contains "Send" }
    Assert-True { $resultAll3.Rights -Contains "Listen" }
    Assert-True { $resultAll3.Rights -Contains "Manage" }

    # Get Created Queue Authorization Rule
    Write-Debug "Get created authorizationRule"
    $createdAuthRule = Get-AzServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Queue $queueName -Name $authRuleName

    # Assert
    Assert-AreEqual $authRuleName $createdAuthRule.Name
    Assert-AreEqual 2 $createdAuthRule.Rights.Count
    Assert-True { $createdAuthRule.Rights -Contains "Listen" }	
    Assert-True { $createdAuthRule.Rights -Contains "Send" }

    # Get all Queue Authorization Rules
    Write-Debug "Get All Queue AuthorizationRule"
    $result = Get-AzServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Queue $queueName
    # Assert
    Assert-True { $result.Count -ge 2 }
    
    # Update the Queue Authorization Rule
    Write-Debug "Update Queue AuthorizationRule"
    $createdAuthRule.Rights.Add("Manage")
    $updatedAuthRule = Set-AzServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Queue $queueName -Name $authRuleName -InputObject $createdAuthRule
    
    # Assert
    Assert-AreEqual $authRuleName $updatedAuthRule.Name "Queue AuthorizationRule created earlier is not found."
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }
	   
    # get the Updated Queue Authorization Rule
    $updatedAuthRule = Get-AzServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Queue $queueName -Name $authRuleName
    
    # Assert
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }
	
    # Get the List Keys
    Write-Debug "Get Queue authorizationRules connectionStrings"
    $namespaceListKeys = Get-AzServiceBusKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Queue $queueName -Name $authRuleName

    Assert-True { $namespaceListKeys.PrimaryConnectionString -like "*$($updatedAuthRule.PrimaryKey)*" }
    Assert-True { $namespaceListKeys.SecondaryConnectionString -like "*$($updatedAuthRule.SecondaryKey)*" }
	
    # Regentrate the Keys 
    $policyKey = "PrimaryKey"

    $StartTime = Get-Date
    $EndTime = $StartTime.AddHours(2.0)
    $SasToken = New-AzServiceBusAuthorizationRuleSASToken -ResourceId $updatedAuthRule.Id  -KeyType Primary -ExpiryTime $EndTime -StartTime $StartTime

    $namespaceRegenerateKeysDefault = New-AzServiceBusKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Queue $queueName -Name $authRuleName -RegenerateKey $policyKey
    Assert-True { $namespaceRegenerateKeysDefault.PrimaryKey -ne $namespaceListKeys.PrimaryKey }

    $namespaceRegenerateKeys = New-AzServiceBusKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Queue $queueName -Name $authRuleName -RegenerateKey $policyKey -KeyValue $namespaceListKeys.PrimaryKey
    Assert-AreEqual $namespaceRegenerateKeys.PrimaryKey $namespaceListKeys.PrimaryKey

    $policyKey1 = "SecondaryKey"

    $namespaceRegenerateKeys1 = New-AzServiceBusKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Queue $queueName -Name $authRuleName -RegenerateKey $policyKey1 -KeyValue $namespaceListKeys.PrimaryKey
    Assert-AreEqual $namespaceRegenerateKeys1.SecondaryKey $namespaceListKeys.PrimaryKey

    $namespaceRegenerateKeys1 = New-AzServiceBusKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Queue $queueName -Name $authRuleName -RegenerateKey $policyKey1
    Assert-True { $namespaceRegenerateKeys1.SecondaryKey -ne $namespaceListKeys.PrimaryKey }
    Assert-True { $namespaceRegenerateKeys1.SecondaryKey -ne $namespaceListKeys.SecondaryKey }
	
    # Cleanup
    Write-Debug "Delete the created Queue AuthorizationRule"
    $result = Remove-AzServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Queue $queueName -Name $authRuleName -Force
    
    
    # Cleanup
    # Delete all Created Queue
    Write-Debug " Delete the Queue"

    Write-Debug "Get the created Queues"
    $createdQueues = Get-AzServiceBusQueue -ResourceGroupName $resourceGroupName -Namespace $namespaceName 
    for ($i = 0; $i -lt $createdQueues.Count; $i++) {
        $delete1 = Remove-AzServiceBusQueue -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $createdQueues[$i].Name		
    }
    

    Write-Debug "Delete NameSpace"
    $createdNamespaces = Get-AzServiceBusNamespace -ResourceGroupName $resourceGroupName
    for ($i = 0; $i -lt $createdNamespaces.Count; $i++) {
        Remove-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $createdNamespaces[$i].Name
    }

    Write-Debug " Delete resourcegroup"
    Remove-AzResourceGroup -Name $resourceGroupName -Force
}