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
Get Topic name
#>
function Get-TopicName
{
    return "SBTopic-" + (getAssetName)
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
    return "SBTopic-AuthorizationRule" + (getAssetName)
	
}

<#
.SYNOPSIS
Tests Topic Namespace Create List Remove operations.
#>
function ServiceBusTopicTests
{
    # Setup    
    $location = Get-Location
 
    Write-Debug "Create resource group"
    $resourceGroupName = Get-ResourceGroupName
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force
    Write-Debug "ResourceGroup name : $resourceGroupName" 

    $namespaceName = Get-NamespaceName
    
    Write-Debug " Create new Topic namespace"
    Write-Debug "NamespaceName : $namespaceName" 
    $result = New-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -Location $location
    Wait-Seconds 15

    Write-Debug "Get the created namespace within the resource group"
    $createdNamespace = Get-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName
    #Assert-True {$createdNamespace.Count -eq 1}

    $found = 0
    
        if ($createdNamespace.Name -eq $namespaceName)
        {
            $found = 1
            Assert-AreEqual $location.Replace(' ','') $createdNamespace.Location.Replace(' ','')
           # Assert-AreEqual $resourceGroupName.ToLower() $createdNamespace.ResourceGroupName.ToLower()
           # Assert-AreEqual "Messaging" $createdNamespace.NamespaceType
            break
        }
    

    Assert-True {$found -eq 0} "Namespace created earlier is not found."

	Write-Debug "Create Topic"
	$nameTopic = Get-TopicName
	$result = New-AzureRmServiceBusTopic -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -TopicName $nameTopic -EnablePartitioning $TRUE
	Assert-True {$result.Name -eq $nameTopic} "In CreateTopic response Name not found"

	$resultGetTopic = Get-AzureRmServiceBusTopic -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -TopicName $result.Name
	Assert-True {$resultGetTopic.Name -eq $result.Name} "In 'Get-AzureRmServiceBusTopic' response, Topic Name not found"
	
	$resultGetTopic.EnableExpress = $TRUE

	$resltSetTopic = Set-AzureRmServiceBusTopic -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -TopicName $resultGetTopic.Name -TopicObj $resultGetTopic
	Assert-True {$resltSetTopic.Name -eq $resultTopic.Name} "In GetTopic response, TopicName not found"

	# Get all Topics
	$ResulListTopic = Get-AzureRmServiceBusTopic -ResourceGroup $resourceGroupName -NamespaceName $namespaceName
	Assert-True {$ResulListTopic.Count -gt 0} "no Topics were found in ListTopic"

	# Delete the created Topic
	$ResultDeleteTopic = Remove-AzureRmServiceBusTopic -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -TopicName $ResulListTopic[0].Name
	Assert-True {$ResultDeleteTopic} "Topic not deleted"

	# Cleanup
	# Delete all Created Topic
	Write-Debug " Delete the Topic"
	for ($i = 0; $i -lt $ResulListTopic.Count; $i++)
	{
		$delete1 = Remove-AzureRmServiceBusTopic -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -TopicName $ResulListTopic[$i].Name		
	}
    Write-Debug " Delete namespaces"
    Remove-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName

	Write-Debug " Delete resourcegroup"
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
	$resourceGroupName = Get-ResourceGroupName
	$namespaceName = Get-NamespaceName    
	$TopicName = Get-TopicName	
    $authRuleName = Get-AuthorizationRuleName

	# Create ResourceGroup
    Write-Debug " Create resource group"    
    Write-Debug "Resource group name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force
	   
    # Create Topic Namespace 
    Write-Debug " Create new ServiceBus namespace"
    Write-Debug "Namespace name : $namespaceName"
    $result = New-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -Location $location
    Wait-Seconds 15
    
	# Assert
	Assert-True {$result.ProvisioningState -eq "Succeeded"}

	# Get Created NameSpace
    Write-Debug " Get the created namespace within the resource group"
    $createdNamespace = Get-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName
    
	# Assert
	Assert-True {$createdNamespace.Count -eq 1}
    $found = 0
    for ($i = 0; $i -lt $createdNamespace.Count; $i++)
    {
        if ($createdNamespace[$i].Name -eq $namespaceName)
        {
            $found = 1
            Assert-AreEqual $location.Replace(' ','') $createdNamespace[$i].Location.Replace(' ','')
           # Assert-AreEqual $resourceGroupName $createdNamespace[$i].ResourceGroupName
            #Assert-AreEqual "Messaging" $createdNamespace[$i].NamespaceType
            break
        }
    }

	# Assert
   # Assert-True {$found -eq 0} "Namespace created earlier is not found."

	# Create New Topic
    Write-Debug " Create new Topic "    
	$msgRetentionInDays = 3
	$partionCount = 2
    $result_Topic = New-AzureRmServiceBusTopic -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -TopicName $TopicName -EnablePartitioning $TRUE
	
    Write-Debug "Get the created Topic"
    $createdTopic = Get-AzureRmServiceBusTopic -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -TopicName $result_Topic.Name

	# Assert
    Assert-True {$createdTopic.Count -eq 1}

	# Create Topic Authorization Rule
    Write-Debug "Create a Topic Authorization Rule"
    $result = New-AzureRmServiceBusTopicAuthorizationRule -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -TopicName $TopicName -AuthorizationRuleName $authRuleName -Rights @("Listen","Send")

	# Assert
    Assert-AreEqual $authRuleName $result.Name
    Assert-AreEqual 2 $result.Rights.Count
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" }
    Wait-Seconds 15

	# Get Created Topic Authorization Rule
    Write-Debug "Get created authorizationRule"
    $createdAuthRule = Get-AzureRmServiceBusTopicAuthorizationRule -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -TopicName $TopicName -AuthorizationRule $authRuleName

	# Assert
    Assert-AreEqual $authRuleName $createdAuthRule.Name
    Assert-AreEqual 2 $createdAuthRule.Rights.Count
    Assert-True { $createdAuthRule.Rights -Contains "Listen" }
    Assert-True { $createdAuthRule.Rights -Contains "Send" }

	# Get all Topic Authorization Rules
    Write-Debug "Get All Topic AuthorizationRule"
    $result = Get-AzureRmServiceBusTopicAuthorizationRule -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -TopicName $TopicName
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
    Assert-True {$found -eq 1} "Topic AuthorizationRule created earlier is not found."

	# Update the Topic Authorization Rule
    Write-Debug "Update Topic AuthorizationRule"
	$createdAuthRule.Rights.Add("Manage")
    $updatedAuthRule = Set-AzureRmServiceBusTopicAuthorizationRule -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -TopicName $TopicName -AuthorizationRuleName $authRuleName -AuthRuleObj $createdAuthRule
    Wait-Seconds 15

	# Assert
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }
	   
    # get the Updated Topic Authorization Rule
    $updatedAuthRule = Get-AzureRmServiceBusTopicAuthorizationRule -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -TopicName $TopicName -AuthorizationRuleName $authRuleName
    
	# Assert
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }
	
	# Get the List Keys
    Write-Debug "Get Topic authorizationRules connectionStrings"
    $namespaceListKeys = Get-AzureRmServiceBusTopicKey -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -TopicName $TopicName -AuthorizationRuleName $authRuleName

    Assert-True {$namespaceListKeys.PrimaryConnectionString.Contains($updatedAuthRule.PrimaryKey)}
    Assert-True {$namespaceListKeys.SecondaryConnectionString.Contains($updatedAuthRule.SecondaryKey)}
	
	# Regentrate the Keys 
	$policyKey = "PrimaryKey"

	$namespaceRegenerateKeys = New-AzureRmServiceBusTopicKey -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -TopicName $TopicName -AuthorizationRuleName $authRuleName -RegenerateKey $policyKey
	Assert-True {$namespaceRegenerateKeys.PrimaryKey -ne $namespaceListKeys.PrimaryKey}

	$policyKey1 = "SecondaryKey"

	$namespaceRegenerateKeys1 = New-AzureRmServiceBusTopicKey -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -TopicName $TopicName -AuthorizationRuleName $authRuleName -RegenerateKey $policyKey1
	Assert-True {$namespaceRegenerateKeys1.SecondaryKey -ne $namespaceListKeys.SecondaryKey}


	# Cleanup
    Write-Debug "Delete the created Topic AuthorizationRule"
    $result = Remove-AzureRmServiceBusTopicAuthorizationRule -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -TopicName $TopicName -AuthorizationRuleName $authRuleName
    
    
	# Cleanup
	# Delete all Created Topic
	Write-Debug " Delete the Topic"

	Write-Debug "Get the created Topics"
    $createdTopics = Get-AzureRmServiceBusTopic -ResourceGroup $resourceGroupName -NamespaceName $namespaceName 
	for ($i = 0; $i -lt $createdTopics.Count; $i++)
	{
		$delete1 = Remove-AzureRmServiceBusTopic -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -TopicName $createdTopics[$i].Name		
	}
    

    Write-Debug "Delete NameSpace"
	 $createdNamespaces = Get-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName
	for ($i = 0; $i -lt $createdNamespaces.Count; $i++)
	{
		Remove-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $createdNamespaces[$i].Name
	}

	Write-Debug " Delete resourcegroup"
	Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}