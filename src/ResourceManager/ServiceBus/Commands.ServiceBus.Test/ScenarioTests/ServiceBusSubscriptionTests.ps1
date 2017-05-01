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
	#return "Default-ServiceBus-WestUS"
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
Get Topic name
#>
function Get-SubscriptionName
{
    return "SBSubscription-" + (getAssetName)
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
function ServiceBusSubscriptionTests
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
   		
		Assert-AreEqual $createdNamespace.Name $namespaceName
		Assert-AreEqual $location.Replace(' ','') $createdNamespace.Location.Replace(' ','')            

    Assert-True {$createdNamespace.Name -eq $namespaceName} "Namespace created earlier is not found."

	Write-Debug "Create Topic"
	$nameTopic = Get-TopicName
	$result = New-AzureRmServiceBusTopic -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -TopicName $nameTopic -EnablePartitioning $TRUE
	Assert-True {$result.Name -eq $nameTopic} "In CreateTopic response Name not found"

	$resultGetTopic = Get-AzureRmServiceBusTopic -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -TopicName $result.Name
	Assert-True {$resultGetTopic.Name -eq $result.Name} "In 'Get-AzureRmServiceBusTopic' response, Topic Name not found"
	
	$resultGetTopic.EnableExpress = $TRUE

	$resltSetTopic = Set-AzureRmServiceBusTopic -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -TopicName $resultGetTopic.Name -TopicObj $resultGetTopic
	Assert-True {$resltSetTopic.Name -eq $resultGetTopic.Name} "In GetTopic response, TopicName not found"

	# Get all Topics
	$ResulListTopic = Get-AzureRmServiceBusTopic -ResourceGroup $resourceGroupName -NamespaceName $namespaceName
	Assert-True {$ResulListTopic.Count -gt 0} "no Topics were found in ListTopic"
	
	#Create Topic
	$subName = Get-SubscriptionName
	$resltNewSub = New-AzureRmServiceBusSubscription -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -TopicName $resultGetTopic.Name -SubscriptionName $subName

	# Get Created Subscritpiton Name 
	$resultGetSub = Get-AzureRmServiceBusSubscription -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -TopicName $resultGetTopic.Name -SubscriptionName $subName
		
    Assert-True {$resultGetSub.Name -eq $subName} "Subscription created earlier is not found."

	# Update the subscription.
	$resultGetSub.IsReadOnly = $True
	$resultSetSub = Set-AzureRmServiceBusSubscription -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -TopicName $resultGetTopic.Name -SubscriptionObj $resultGetSub
		
	Assert-True {$resultSetSub.Name -eq $resultGetSub.Name} "Subscription Updated earlier is not found."

	# Delete the created/Updated Subscription
	$ResultDeleteTopic = Remove-AzureRmServiceBusSubscription -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -TopicName $ResulListTopic[0].Name -SubscriptionName $resultSetSub.Name
	Assert-True {$ResultDeleteTopic} "Topic not deleted"
		
	# Cleanup
	# Delete all Created Topic
	Write-Debug " Delete the Topic"
	for ($i = 0; $i -lt $ResulListTopic.Count; $i++)
	{
		$delete1 = Remove-AzureRmServiceBusTopic -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -TopicName $ResulListTopic[$i].Name		
	}

	Write-Debug "Delete NameSpace"
	 $createdNamespaces = Get-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName
	for ($i = 0; $i -lt $createdNamespaces.Count; $i++)
	{
		Remove-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $createdNamespaces[$i].Name
	}

	Write-Debug " Delete resourcegroup"
	#Remove-AzureRmResourceGroup -Name $resourceGroupName -Force

}