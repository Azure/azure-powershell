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
Tests Topic Namespace Create List Remove operations.
#>
function ServiceBusTopicTests
{
    # Setup    
    $location = Get-Location
    $resourceGroupName = getAssetName "RGName-"
    $namespaceName = getAssetName "Namespace-"
	$nameTopic = getAssetName "Topic-"
 
    Write-Debug "Create resource group"
    New-AzResourceGroup -Name $resourceGroupName -Location $location -Force
    Write-Debug "ResourceGroup name : $resourceGroupName" 

    
    Write-Debug " Create new Topic namespace"
    Write-Debug "NamespaceName : $namespaceName" 
    $result = New-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Location $location -Name $namespaceName     

    Write-Debug "Get the created namespace within the resource group"
    $createdNamespace = Get-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName
    
    Assert-AreEqual $createdNamespace.Name $namespaceName "Namespace created earlier is not found."

	Write-Debug "Create Topic"
	$result = New-AzServiceBusTopic -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $nameTopic -EnablePartitioning $TRUE
	Assert-AreEqual $result.Name $nameTopic "In CreateTopic response Name not found"

	$resultGetTopic = Get-AzServiceBusTopic -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $result.Name
	Assert-AreEqual $resultGetTopic.Name $result.Name "In 'Get-AzServiceBusTopic' response, Topic Name not found"

	$resultGetTopic.EnableExpress = $TRUE
	$resltSetTopic = Set-AzServiceBusTopic -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $resultGetTopic.Name -InputObject $resultGetTopic
	Assert-AreEqual $resltSetTopic.Name $resultGetTopic.Name "In GetTopic response, TopicName not found"

	# Get all Topics
	$ResulListTopic = Get-AzServiceBusTopic -ResourceGroupName $resourceGroupName -Namespace $namespaceName
	Assert-True {$ResulListTopic.Count -gt 0} "no Topics were found in ListTopic"
		
	# Cleanup
	# Delete all Created Topic
	Write-Debug " Delete the Topic"
	
	Remove-AzServiceBusTopic -ResourceId $resltSetTopic.Id

    Write-Debug " Delete namespaces"
    Remove-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName

	#Write-Debug " Delete resourcegroup"
	Remove-AzResourceGroup -Name $resourceGroupName -Force
}


<#
.SYNOPSIS
Tests ServiceBus Topic AuthorizationRules Create List Remove operations.
#>
function ServiceBusTopicAuthTests
{
    # Setup    
    $location =  Get-Location
	$resourceGroupName = getAssetName "RGName-"
	$namespaceName = getAssetName "Namespace-"
	$TopicName = getAssetName "Topic-"
    $authRuleName = getAssetName "authorule-"

	# Create ResourceGroup
    Write-Debug " Create resource group"    
    Write-Debug "Resource group name : $resourceGroupName"
    New-AzResourceGroup -Name $resourceGroupName -Location $location -Force
	   
    # Create Topic Namespace 
    Write-Debug " Create new ServiceBus namespace"
    Write-Debug "Namespace name : $namespaceName"
    $result = New-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Location $location -Name $namespaceName
	# Assert
	Assert-AreEqual $result.ProvisioningState "Succeeded"
	Assert-AreEqual $result.Name $namespaceName "New-AzServiceBusNamespace: Created Namespace not found"

	# Get Created NameSpace
    Write-Debug " Get the created namespace within the resource group"
    $getNamespace = Get-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName
 
    Assert-AreEqual $getNamespace.Name $namespaceName "Get-AzServiceBusNamespace: Namespace created earlier is not found."

	# Create New Topic
    Write-Debug " Create new Topic "    
	$msgRetentionInDays = 3
	$partionCount = 2
    $result_Topic = New-AzServiceBusTopic -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $TopicName -EnablePartitioning $TRUE
	Assert-AreEqual $result_Topic.Name $TopicName "New-AzServiceBusTopic: Created Namespace not found"
		
    Write-Debug "Get the created Topic"
    $getTopic = Get-AzServiceBusTopic -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $result_Topic.Name

	# Assert
    Assert-AreEqual $getTopic.Name $TopicName "Get-AzServiceBusTopic: Created Namespace not found"

	# Create Topic Authorization Rule
    Write-Debug "Create a Topic Authorization Rule"
    $result = New-AzServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $TopicName -Name $authRuleName -Rights @("Listen","Send")

	# Assert
    Assert-AreEqual $result.Name $authRuleName "New-AzServiceBusAuthorizationRule: Created Authorizationrule not found"
    Assert-AreEqual 2 $result.Rights.Count "New-AzServiceBusAuthorizationRule: Rights count dont match"
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" }     

	# Get Created Topic Authorization Rule
    Write-Debug "Get created authorizationRule"
    $createdAuthRule = Get-AzServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $TopicName -Name $authRuleName
	
	# Assert
	Assert-AreEqual $createdAuthRule.Name $authRuleName "Get-AzServiceBusAuthorizationRule: Created Authorizationrule not found"
	Assert-AreEqual 2 $createdAuthRule.Rights.Count
    Assert-True { $createdAuthRule.Rights -Contains "Listen" }
    Assert-True { $createdAuthRule.Rights -Contains "Send" }

	# Get all Topic Authorization Rules
    Write-Debug "Get All Topic AuthorizationRule"
    $result = Get-AzServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $TopicName
	# Assert
   
    Assert-AreEqual $result.Name $authRuleName "Topic AuthorizationRule created earlier is not found."
    Assert-AreEqual 2 $result.Rights.Count
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" } 

	# Update the Topic Authorization Rule
    Write-Debug "Update Topic AuthorizationRule"
	$createdAuthRule.Rights.Add("Manage")
    $updatedAuthRule = Set-AzServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $TopicName -Name $authRuleName -InputObject $createdAuthRule
    
	# Assert
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }
	   
    # get the Updated Topic Authorization Rule
    $updatedAuthRule = Get-AzServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $TopicName -Name $authRuleName
    
	# Assert
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }
	
	# Get the List Keys
    Write-Debug "Get Topic authorizationRules connectionStrings"
    $namespaceListKeys = Get-AzServiceBusKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $TopicName -Name $authRuleName

    Assert-True {$namespaceListKeys.PrimaryConnectionString -like "*$($updatedAuthRule.PrimaryKey)*"}
    Assert-True {$namespaceListKeys.SecondaryConnectionString -like "*$($updatedAuthRule.SecondaryKey)*"}
	
	# Regentrate the Keys 
	$policyKey = "PrimaryKey"

	$StartTime = Get-Date
	$EndTime = $StartTime.AddHours(2.0)
	$SasToken = New-AzServiceBusAuthorizationRuleSASToken -ResourceId $updatedAuthRule.Id  -KeyType Primary -ExpiryTime $EndTime -StartTime $StartTime	

	$namespaceRegenerateKeysDefault = New-AzServiceBusKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $TopicName -Name $authRuleName -RegenerateKey $policyKey
	Assert-True {$namespaceRegenerateKeysDefault.PrimaryKey -ne $namespaceListKeys.PrimaryKey}

	$namespaceRegenerateKeys = New-AzServiceBusKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $TopicName -Name $authRuleName -RegenerateKey $policyKey -KeyValue $namespaceListKeys.PrimaryKey
	Assert-AreEqual $namespaceRegenerateKeys.PrimaryKey $namespaceListKeys.PrimaryKey

	$policyKey1 = "SecondaryKey"

	$namespaceRegenerateKeys1 = New-AzServiceBusKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $TopicName -Name $authRuleName -RegenerateKey $policyKey1 -KeyValue $namespaceListKeys.PrimaryKey
	Assert-AreEqual $namespaceRegenerateKeys1.SecondaryKey $namespaceListKeys.PrimaryKey

	$namespaceRegenerateKeys1 = New-AzServiceBusKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $TopicName -Name $authRuleName -RegenerateKey $policyKey1
	Assert-True {$namespaceRegenerateKeys1.SecondaryKey -ne $namespaceListKeys.PrimaryKey}
	Assert-True {$namespaceRegenerateKeys1.SecondaryKey -ne $namespaceListKeys.SecondaryKey}

	# Cleanup
    Write-Debug "Delete the created Topic AuthorizationRule"
    $result = Remove-AzServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $TopicName -Name $authRuleName -Force
    
	# Cleanup
	# Delete all Created Topic
	Write-Debug " Delete the Topic"

	Write-Debug "Get the created Topics"
    $createdTopics = Get-AzServiceBusTopic -ResourceGroupName $resourceGroupName -Namespace $namespaceName 
	for ($i = 0; $i -lt $createdTopics.Count; $i++)
	{
		#$delete1 = Remove-AzServiceBusTopic -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $createdTopics[$i].Name		
		$delete1 = Remove-AzServiceBusTopic -InputObject $createdTopics[$i]	
	}

    Write-Debug "Delete NameSpace"
	Remove-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName	

	Write-Debug " Delete resourcegroup"
	Remove-AzResourceGroup -Name $resourceGroupName -Force
}

