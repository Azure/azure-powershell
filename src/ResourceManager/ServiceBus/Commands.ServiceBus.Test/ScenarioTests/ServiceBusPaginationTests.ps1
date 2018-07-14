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
Tests Rule Create List Remove operations.
#>
function ServiceBusPaginationTests
{
    # Setup    
    $location = Get-Location
	$resourceGroupName = getAssetName "RGName-"
	$namespaceName = getAssetName "Namespace1-"
	$nameQueue = getAssetName "Queue-"
	$nameTopic = getAssetName "Topic-"
	$subName = getAssetName "Subscription-"
	$ruleName = getAssetName "Rule-"
	$ruleName1 = getAssetName "Rule-"
	$count = 0
	 
    Write-Debug "Create resource group"
	Write-Debug "ResourceGroup name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force
        
    Write-Debug " Create new Topic namespace"
    Write-Debug "NamespaceName : $namespaceName" 
    $result = New-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Location $location -Name $namespaceName
    
    Try
	{
		Write-Debug "Get the created namespace within the resource group"
		$createdNamespace = Get-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName

		Assert-AreEqual $createdNamespace.Name $namespaceName

		Assert-AreEqual $createdNamespace.Name $namespaceName "Namespace created earlier is not found."

		#Create Queue
		while($count -lt 50)
		{
			$queueNameNew = $nameQueue + "_" +$count
			New-AzureRmServiceBusQueue -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $queueNameNew
			$count = $count + 1
		}
	
		$get30Queue = Get-AzureRmServiceBusQueue -ResourceGroupName $resourceGroupName -Namespace $namespaceName -MaxCount 30
		Assert-AreEqual 30 $get30Queue.Count "Get Queue with MaxCount 30 not returned total 30"

		#Create Topic
		$count = 0
		$topicNameNew = $nameTopic + "_" +$count
		while($count -lt 50)
		{
			$topicNameNew = $nameTopic + "_" +$count
			New-AzureRmServiceBusTopic -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $topicNameNew -EnablePartitioning $TRUE
			$count = $count + 1
		}
	
		$get30Topic = Get-AzureRmServiceBusTopic -ResourceGroupName $resourceGroupName -Namespace $namespaceName -MaxCount 30	
		Assert-AreEqual 30 $get30Topic.Count "Get Topic with MaxCount 30 not returned total 30"

		#Create Subscription
		$count = 0
		$subscriptionNameNew = $subName + "_" +$count
		while($count -lt 50)
		{
			$subscriptionNameNew = $subName + "_" +$count
			New-AzureRmServiceBusSubscription -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $topicNameNew -Name $subscriptionNameNew
			$count = $count + 1
		}
	
		$get30Sub = Get-AzureRmServiceBusSubscription -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $topicNameNew -MaxCount 30	
		Assert-AreEqual 30 $get30Sub.Count "Get Subscription with MaxCount 30 not returned total 30"	

		#Create Rules
		$count = 0
		$ruleNameNew = $ruleName + "_" +$count
		while($count -lt 50)
		{
			$ruleNameNew = $ruleName + "_" +$count
			New-AzureRmServiceBusRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $topicNameNew -Subscription $subscriptionNameNew -Name $ruleNameNew -SqlExpression "myproperty='test'"
			$count = $count + 1
		}
	
		$get30Rule = Get-AzureRmServiceBusRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $topicNameNew -Subscription $subscriptionNameNew -MaxCount 25	
		Assert-AreEqual 25 $get30Rule.Count "Get Rules with MaxCount 30 not returned total 30"
	}
	Finally
	{
		# Cleanup
		# Delete namespace

		Write-Debug "Delete NameSpace"
		Remove-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName

		Write-Debug " Delete resourcegroup"
		Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
	}

	
}