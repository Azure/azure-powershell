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

function ServiceBusSubscriptionTests
{
    # Setup    
    $location = Get-Location
	$resourceGroupName = getAssetName "RGName-"
	$namespaceName = getAssetName "Namespace-"
	$nameTopic = getAssetName "Topic-"
	$subName = getAssetName "Subscription-"

    Write-Debug "Create resource group"    
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force
    Write-Debug "ResourceGroup name : $resourceGroupName"   
    
    Write-Debug " Create new Topic namespace"
    Write-Debug "NamespaceName : $namespaceName" 
    $result = New-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Location $location -Name $namespaceName     

    Write-Debug "Get the created namespace within the resource group"
    $createdNamespace = Get-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName
   		
	Assert-AreEqual $createdNamespace.Name $namespaceName "Namespace created earlier is not found"
	Assert-AreEqual $location.Replace(' ','') $createdNamespace.Location.Replace(' ','')

	Write-Debug "Create Topic"	
	$result = New-AzureRmServiceBusTopic -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $nameTopic -EnablePartitioning $TRUE
	Assert-AreEqual $result.Name $nameTopic "In CreateTopic response Name not found"

	$resultGetTopic = Get-AzureRmServiceBusTopic -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $result.Name
	Assert-AreEqual $resultGetTopic.Name $result.Name "In 'Get-AzureRmServiceBusTopic' response, Topic Name not found"
	
	$resultGetTopic.EnableExpress = $TRUE

	$resltSetTopic = Set-AzureRmServiceBusTopic -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $resultGetTopic.Name -InputObject $resultGetTopic
	Assert-AreEqual $resltSetTopic.Name $resultGetTopic.Name "In GetTopic response, TopicName not found"
	Assert-True {$resltSetTopic.EnableExpress} "Set-AzureRmServiceBusTopic: "

	# Get all Topics
	$ResulListTopic = Get-AzureRmServiceBusTopic -ResourceGroupName $resourceGroupName -Namespace $namespaceName
	Assert-True {$ResulListTopic.Count -gt 0} "no Topics were found in ListTopic"
	
	#Create Topic
	Write-Debug " Create new SB Topic-Subscription"
    Write-Debug " SB Topic-Subscription Name : $subName"
	$resltNewSub = New-AzureRmServiceBusSubscription -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $resultGetTopic.Name -Name $subName
	Assert-AreEqual $resltNewSub.Name $subName "Subscription created earlier is not found"

	# Get Created Subscritpiton Name 
	$resultGetSub = Get-AzureRmServiceBusSubscription -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $resultGetTopic.Name -Name $subName		
    Assert-AreEqual $resultGetSub.Name $subName "Get-Subscription: Subscription created earlier is not found"

	# Update the subscription.
	$resultSetSub = Set-AzureRmServiceBusSubscription -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $resultGetTopic.Name -InputObject $resultGetSub
		
	Assert-AreEqual $resultSetSub.Name $resultGetSub.Name "Subscription Updated earlier is not found"

	# Delete the created/Updated Subscription
	$ResultDeleteTopic = Remove-AzureRmServiceBusSubscription -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $ResulListTopic[0].Name -Name $resultSetSub.Name
	Assert-True {$ResultDeleteTopic} "Topic not deleted"
		
	# Cleanup
	# Delete all Created Topic
	Write-Debug " Delete the Topic"
	for ($i = 0; $i -lt $ResulListTopic.Count; $i++)
	{
		$delete1 = Remove-AzureRmServiceBusTopic -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $ResulListTopic[$i].Name		
	}

	Write-Debug "Delete NameSpace"
	Remove-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName
	
	Write-Debug " Delete resourcegroup"
	Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}