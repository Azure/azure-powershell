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
Get Rule name
#>
function Get-RuleName
{
    return "SBRule-" + (getAssetName)
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
Tests Rule Create List Remove operations.
#>
function ServiceBusRuleTests
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
    $result = New-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Location $location -Name $namespaceName
    

    Write-Debug "Get the created namespace within the resource group"
    $createdNamespace = Get-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName
   		
	Assert-AreEqual $createdNamespace.Name $namespaceName
	Assert-AreEqual $location.Replace(' ','') $createdNamespace.Location.Replace(' ','')

    Assert-True {$createdNamespace.Name -eq $namespaceName} "Namespace created earlier is not found."

	Write-Debug "Create Topic"
	$nameTopic = Get-TopicName
	$result = New-AzureRmServiceBusTopic -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $nameTopic -EnablePartitioning $TRUE
	Assert-True {$result.Name -eq $nameTopic} "In CreateTopic response Name not found"

	$resultGetTopic = Get-AzureRmServiceBusTopic -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $result.Name
	Assert-True {$resultGetTopic.Name -eq $result.Name} "In 'Get-AzureRmServiceBusTopic' response, Topic Name not found"
	
	$resultGetTopic.EnableExpress = $TRUE

	$resltSetTopic = Set-AzureRmServiceBusTopic -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $resultGetTopic.Name -InputObject $resultGetTopic
	Assert-True {$resltSetTopic.Name -eq $resultGetTopic.Name} "In GetTopic response, TopicName not found"

	# Get all Topics
	$ResulListTopic = Get-AzureRmServiceBusTopic -ResourceGroupName $resourceGroupName -Namespace $namespaceName
	Assert-True {$ResulListTopic.Count -gt 0} "no Topics were found in ListTopic"
	
	#Create Subscription
	$subName = Get-SubscriptionName
	$resltNewSub = New-AzureRmServiceBusSubscription -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $resultGetTopic.Name -Name $subName

	# Get Created Subscritpiton Name 
	$resultGetSub = Get-AzureRmServiceBusSubscription -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $resultGetTopic.Name -Name $subName

	# Create Rule
	$ruleName = Get-RuleName
	$createRule = New-AzureRmServiceBusRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $resultGetTopic.Name -Subscription $subName -Name $ruleName -SqlExpression "myproperty='test'"

	Assert-True {$createRule.Name -eq $ruleName} "Rule created earlier is not found."
	
	# Get Rule
	$getRule = Get-AzureRmServiceBusRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $resultGetTopic.Name -Subscription $subName -Name $ruleName

	# Update Rule
	$getRule.SqlFilter.SqlExpression = "myproperty='testing'"

	$setRule = Set-AzureRmServiceBusRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $resultGetTopic.Name -Subscription $subName -Name $ruleName -InputObject $getRule
	
	Assert-True {$setRule.SqlFilter.SqlExpression -eq "myproperty='testing'"} "Rule's SqlExpression updated earlier is not found."

	#remove Rule
	Remove-AzureRmServiceBusRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $resultGetTopic.Name -Subscription $subName -Name $ruleName -Force
	
	# Delete the created/Updated Subscription
	$ResultDeleteTopic = Remove-AzureRmServiceBusSubscription -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Topic $ResulListTopic[0].Name -Name $resultGetSub.Name
	Assert-True {$ResultDeleteTopic} "Topic not deleted"
		
	# Cleanup
	# Delete all Created Topic
	Write-Debug " Delete the Topic"
	for ($i = 0; $i -lt $ResulListTopic.Count; $i++)
	{
		$delete1 = Remove-AzureRmServiceBusTopic -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $ResulListTopic[$i].Name		
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