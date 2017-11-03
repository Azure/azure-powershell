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
Get Queue name
#>
function Get-QueueName
{
    return "SBQueue-" + (getAssetName)
}

<#
.SYNOPSIS
Get  Namespace name
#>
function Get-NamespaceName
{
    return "SBNamespace-" + (getAssetName)
}

<#
.SYNOPSIS
Get valid AuthorizationRule name
#>
function Get-AuthorizationRuleName
{
    return "SBQueue-AuthorizationRule" + (getAssetName)
	
}

<#
.SYNOPSIS
Tests Queue Namespace Create List Remove operations.
#>
function ServiceBusQueueTests
{
    # Setup    
    $location = Get-Location
 
    Write-Debug "Create resource group"
    $resourceGroupName = Get-ResourceGroupName
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force
    Write-Debug "ResourceGroup name : $resourceGroupName" 

    $namespaceName = Get-NamespaceName
    
    Write-Debug " Create new Queue namespace"
    Write-Debug "NamespaceName : $namespaceName" 
    $result = New-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Location $location -Name $namespaceName
    

    Write-Debug "Get the created namespace within the resource group"
    $createdNamespace = Get-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName

    $found = 0
    
        if ($createdNamespace.Name -eq $namespaceName)
        {
            $found = 1
           Assert-AreEqual $location.Replace(' ','') $createdNamespace.Location.Replace(' ','')
           # Assert-AreEqual $resourceGroupName.ToLower() $createdNamespace.ResourceGroupName.ToLower()
           # Assert-AreEqual "Messaging" $createdNamespace.NamespaceType           
        }

    #Assert-True {$found -eq 0} "Namespace created earlier is not found."

	Write-Debug "Create Queue"
	$nameQueue = Get-QueueName
	$result = New-AzureRmServiceBusQueue -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $nameQueue
	Assert-True {$result.Name -eq $nameQueue} "In CreateQueue response Name not found"

	$resultGetQueue = Get-AzureRmServiceBusQueue -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $result.Name
	Assert-True {$resultGetQueue.Name -eq $result.Name} "In GetQueue response, QueueName not found"
	
	$resultGetQueue.EnableExpress = $True
	$resultGetQueue.DeadLetteringOnMessageExpiration = $True
	$resultGetQueue.MaxDeliveryCount = 5
	$resultGetQueue.MaxSizeInMegabytes = 1024

	$resltSetQueue = Set-AzureRmServiceBusQueue -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $resultGetQueue.Name -InputObject $resultGetQueue
	Assert-True {$resltSetQueue.Name -eq $resultGetQueue.Name} "In GetQueue response, QueueName not found"

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
    $location =  Get-Location
	$resourceGroupName = Get-ResourceGroupName
	$namespaceName = Get-NamespaceName    
	$queueName = Get-QueueName	
    $authRuleName = Get-AuthorizationRuleName

	# Create ResourceGroup
    Write-Debug " Create resource group"    
    Write-Debug "Resource group name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force
	   
    # Create Queue Namespace 
    Write-Debug " Create new ServiceBus namespace"
    Write-Debug "Namespace name : $namespaceName"
    $result = New-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Location $location -Name $namespaceName
    
    
	# Assert
	Assert-True {$result.ProvisioningState -eq "Succeeded"}

	# Get Created NameSpace
    Write-Debug " Get the created namespace within the resource group"
    $createdNamespace = Get-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName
    
	# Assert
	Assert-True {$createdNamespace.Count -eq 1}
    $found = 0
    for ($i = 0; $i -lt $createdNamespace.Count; $i++)
    {
        if ($createdNamespace[$i].Name -eq $namespaceName)
        {
            $found = 1
            Assert-AreEqual $location.Replace(' ','') $createdNamespace[$i].Location.Replace(' ','')
            #Assert-AreEqual $resourceGroupName $createdNamespace[$i].ResourceGroupName
            #Assert-AreEqual "Messaging" $createdNamespace[$i].NamespaceType
            break
        }
    }

	# Assert
   # Assert-True {$found -eq 0} "Namespace created earlier is not found."

	# Create New Queue
    Write-Debug " Create new Queue "    
	$msgRetentionInDays = 3
	$partionCount = 2
    $result_Queue = New-AzureRmServiceBusQueue -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $queueName -EnablePartitioning $TRUE
	
    Write-Debug "Get the created Queue"
    $createdQueue = Get-AzureRmServiceBusQueue -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $result_Queue.Name

	# Assert
    Assert-True {$createdQueue.Count -eq 1}

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
    $found = 0
    for ($i = 0; $i -lt $result.Count; $i++)
    {
        if ($result[$i].Name -eq $authRuleName)
        {
            $found = 1
            Assert-AreEqual 2 $result[$i].Rights.Count
            Assert-True { $result[$i].Rights -Contains "Listen" }
            Assert-True { $result[$i].Rights -Contains "Send" }         
            break
        }
    }
    Assert-True {$found -eq 1} "Queue AuthorizationRule created earlier is not found."

	# Update the Queue Authorization Rule
    Write-Debug "Update Queue AuthorizationRule"
	$createdAuthRule.Rights.Add("Manage")
    $updatedAuthRule = Set-AzureRmServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Queue $queueName -Name $authRuleName -InputObject $createdAuthRule
    

	# Assert
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
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