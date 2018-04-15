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
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force
    Write-Debug "ResourceGroup name : $resourceGroupName" 

    
    Write-Debug " Create new Topic namespace"
    Write-Debug "NamespaceName : $namespaceName" 
    $result = New-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Location $location -Name $namespaceName     

    Write-Debug "Get the created namespace within the resource group"
    $createdNamespace = Get-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName
    
    Assert-AreEqual $createdNamespace.Name $namespaceName "Namespace created earlier is not found."

	Write-Debug "Create Topic"
	$result = New-AzureRmServiceBusTopic -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $nameTopic -EnablePartitioning $TRUE
	Assert-AreEqual $result.Name $nameTopic "In CreateTopic response Name not found"

	$resultGetTopic = Get-AzureRmServiceBusTopic -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $result.Name
	Assert-AreEqual $resultGetTopic.Name $result.Name "In 'Get-AzureRmServiceBusTopic' response, Topic Name not found"

	$resultGetTopic.EnableExpress = $TRUE
	$resltSetTopic = Set-AzureRmServiceBusTopic -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $resultGetTopic.Name -InputObject $resultGetTopic
	Assert-AreEqual $resltSetTopic.Name $resultGetTopic.Name "In GetTopic response, TopicName not found"

	# Get all Topics
	$ResulListTopic = Get-AzureRmServiceBusTopic -ResourceGroupName $resourceGroupName -Namespace $namespaceName
	Assert-True {$ResulListTopic.Count -gt 0} "no Topics were found in ListTopic"

	# Delete the created Topic
	$ResultDeleteTopic = Remove-AzureRmServiceBusTopic -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $ResulListTopic[0].Name
	Assert-True {$ResultDeleteTopic} "Topic not deleted"

	# Cleanup
	# Delete all Created Topic
	Write-Debug " Delete the Topic"
	for ($i = 0; $i -lt $ResulListTopic.Count; $i++)
	{
		$delete1 = Remove-AzureRmServiceBusTopic -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -TopicName $ResulListTopic[$i].Name		
	}
    Write-Debug " Delete namespaces"
    Remove-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName

	#Write-Debug " Delete resourcegroup"
	Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
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
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force
	   
    # Create Topic Namespace 
    Write-Debug " Create new ServiceBus namespace"
    Write-Debug "Namespace name : $namespaceName"
    $result = New-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Location $location -Name $namespaceName
	# Assert
	Assert-AreEqual $result.ProvisioningState "Succeeded"
	Assert-AreEqual $result.Name $namespaceName "New-AzureRmServiceBusNamespace: Created Namespace not found"

	# Get Created NameSpace
    Write-Debug " Get the created namespace within the resource group"
    $getNamespace = Get-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName
 
    Assert-AreEqual $getNamespace.Name $namespaceName "Get-AzureRmServiceBusNamespace: Namespace created earlier is not found."

	# Create New Topic
    Write-Debug " Create new Topic "    
	$msgRetentionInDays = 3
	$partionCount = 2
    $result_Topic = New-AzureRmServiceBusTopic -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $TopicName -EnablePartitioning $TRUE
	Assert-AreEqual $result_Topic.Name $TopicName "New-AzureRmServiceBusTopic: Created Namespace not found"
		
    Write-Debug "Get the created Topic"
    $getTopic = Get-AzureRmServiceBusTopic -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $result_Topic.Name

	# Assert
    Assert-AreEqual $getTopic.Name $TopicName "Get-AzureRmServiceBusTopic: Created Namespace not found"

	# Create Topic Authorization Rule
    Write-Debug "Create a Topic Authorization Rule"
    $result = New-AzureRmServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $TopicName -Name $authRuleName -Rights @("Listen","Send")

	# Assert
    Assert-AreEqual $result.Name $authRuleName "New-AzureRmServiceBusAuthorizationRule: Created Authorizationrule not found"
    Assert-AreEqual 2 $result.Rights.Count "New-AzureRmServiceBusAuthorizationRule: Rights count dont match"
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" }     

	# Get Created Topic Authorization Rule
    Write-Debug "Get created authorizationRule"
    $createdAuthRule = Get-AzureRmServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $TopicName -Name $authRuleName
	
	# Assert
	Assert-AreEqual $createdAuthRule.Name $authRuleName "Get-AzureRmServiceBusAuthorizationRule: Created Authorizationrule not found"
	Assert-AreEqual 2 $createdAuthRule.Rights.Count
    Assert-True { $createdAuthRule.Rights -Contains "Listen" }
    Assert-True { $createdAuthRule.Rights -Contains "Send" }

	# Get all Topic Authorization Rules
    Write-Debug "Get All Topic AuthorizationRule"
    $result = Get-AzureRmServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $TopicName
	# Assert
   
    Assert-AreEqual $result.Name $authRuleName "Topic AuthorizationRule created earlier is not found."
    Assert-AreEqual 2 $result.Rights.Count
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" } 

	# Update the Topic Authorization Rule
    Write-Debug "Update Topic AuthorizationRule"
	$createdAuthRule.Rights.Add("Manage")
    $updatedAuthRule = Set-AzureRmServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $TopicName -Name $authRuleName -InputObject $createdAuthRule
    
	# Assert
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }
	   
    # get the Updated Topic Authorization Rule
    $updatedAuthRule = Get-AzureRmServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $TopicName -Name $authRuleName
    
	# Assert
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }
	
	# Get the List Keys
    Write-Debug "Get Topic authorizationRules connectionStrings"
    $namespaceListKeys = Get-AzureRmServiceBusKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $TopicName -Name $authRuleName

    Assert-True {$namespaceListKeys.PrimaryConnectionString.Contains($updatedAuthRule.PrimaryKey)}
    Assert-True {$namespaceListKeys.SecondaryConnectionString.Contains($updatedAuthRule.SecondaryKey)}
	
	# Regentrate the Keys 
	$policyKey = "PrimaryKey"

	$namespaceRegenerateKeys = New-AzureRmServiceBusKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $TopicName -Name $authRuleName -RegenerateKey $policyKey
	Assert-True {$namespaceRegenerateKeys.PrimaryKey -ne $namespaceListKeys.PrimaryKey}

	$policyKey1 = "SecondaryKey"

	$namespaceRegenerateKeys1 = New-AzureRmServiceBusKey -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $TopicName -Name $authRuleName -RegenerateKey $policyKey1
	Assert-True {$namespaceRegenerateKeys1.SecondaryKey -ne $namespaceListKeys.SecondaryKey}

	# Cleanup
    Write-Debug "Delete the created Topic AuthorizationRule"
    $result = Remove-AzureRmServiceBusAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $TopicName -Name $authRuleName -Force
    
	# Cleanup
	# Delete all Created Topic
	Write-Debug " Delete the Topic"

	Write-Debug "Get the created Topics"
    $createdTopics = Get-AzureRmServiceBusTopic -ResourceGroupName $resourceGroupName -Namespace $namespaceName 
	for ($i = 0; $i -lt $createdTopics.Count; $i++)
	{
		$delete1 = Remove-AzureRmServiceBusTopic -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $createdTopics[$i].Name		
	}

    Write-Debug "Delete NameSpace"
	Remove-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName	

	Write-Debug " Delete resourcegroup"
	Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}