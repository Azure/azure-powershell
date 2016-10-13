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
    #return "RGName-" + (getAssetName)
	return "Default-ServiceBus-WestUS"
}

<#
.SYNOPSIS
Get valid EventHub name
#>
function Get-EventHubName
{
    return "EventHub-" + (getAssetName)
}

<#
.SYNOPSIS
Get valid Namespace name
#>
function Get-NamespaceName
{
    #return "Namespace-" + (getAssetName)
	return "sdk-Namespace"
}

<#
.SYNOPSIS
Tests EventHubs Create List Remove operations.
#>
function EventHubsTests
{
    # Setup    
    $location = "West US"
    
    Write-Debug "  Create resource group"
    $resourceGroupName = Get-ResourceGroupName
    Write-Debug " Resource Group Name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force

    $namespaceName = Get-NamespaceName
    
    Write-Debug "  Create new notificationHub namespace"
    Write-Debug " Namespace name : $namespaceName"
    $result = New-AzureRmEventHubsNamespace -ResourceGroup $resourceGroupName -Namespace $namespaceName -Location $location
    Wait-Seconds 15

    Write-Debug " Get the created namespace within the resource group"
    $createdNamespace = Get-AzureRmEventHubsNamespace -ResourceGroup $resourceGroupName -Namespace $namespaceName
    Assert-True {$createdNamespace.Count -eq 1}

    $found = 0
    for ($i = 0; $i -lt $createdNamespace.Count; $i++)
    {
        if ($createdNamespace[$i].Name -eq $namespaceName)
        {
            $found = 1
            Assert-AreEqual $location $createdNamespace[$i].Location
            Assert-AreEqual $resourceGroupName $createdNamespace[$i].ResourceGroupName
            Assert-AreEqual "EventHub" $createdNamespace[$i].NamespaceType
            break
        }
    }

    Assert-True {$found -eq 0} "Namespace created earlier is not found."

    Write-Debug " Create new eventHub "
    $eventHubName = "TestEH"
    $result = New-AzureRmEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $eventHubName -InputFile .\.\Resources\NewEventHub.json
	
	<# 
	$Test -as [EventHubAttributes]

	$Test.Name = Get-EventHubName
	$Test.MessageRetentionInDays = 3
	$Test.PartitionCount = 2
	$Test.PartitionIds.Add(0)
	$Test.PartitionIds.Add(1)

	$result = New-AzureRmEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $Test.Name -EventHubObj $Test
	#>
		
    Write-Debug " Get the created notificationHub "
    $createdEventHub = Get-AzureRmEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHubName $result.Name
    Assert-True {$createdEventHub.Count -eq 1}    

	<#
    Write-Debug " Create another new  "
    $eventHubName2 = Get-EventHubName
	[$createdEventHub]$createdEventHub1
    $createdEventHub1.Name = $eventHubName2
	$createdEventHub1.MessageRetentionInDays = 3
	$createdEventHub1.PartitionCount = 2
	$createdEventHub1.PartitionIds.Add(0)
	$createdEventHub1.PartitionIds.Add(1)
   
    $result = New-AzureRmEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHubObj $createdEventHub1
	#>

    Write-Debug " Get all the created notificationHub "
    $createdEventHubList = Get-AzureRmEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName

    $found = 0
    for ($i = 0; $i -lt $createdEventHubList.Count; $i++)
    {
        if ($createdEventHubList[$i].Name -eq $eventHubName)
        {
            $found = $found + 1
        }

        if ($createdEventHubList[$i].Name -eq $eventHubName2)
        {
            $found = $found + 1
        }
    }

    Assert-True {$found -eq 0} "EventHub created earlier is not found."

    Write-Debug " Update the first EventHub "    
	$createdEventHub.MessageRetentionInDays = 4	
   
    $result = Set-AzureRmEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHubName $createdEventHub.Name  -EventHubObj $createdEventHub
    Wait-Seconds 15
	
    Write-Debug " Delete the EventHub"
    $delete1 = Remove-AzureRmEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHubName $createdEventHubList[0].Name
    $delete2 = Remove-AzureRmEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHubName $createdEventHubList[1].Name

    Write-Debug " Delete namespaces"
    Remove-AzureRmEventHubsNamespace -ResourceGroup $resourceGroupName -Namespace $namespaceName

}

<#
.SYNOPSIS
Tests NotificationHub AuthorizationRules Create List Remove operations.
#>
function EventHubsAuthTests
{
    # Setup    
    $location = "West US"
    
    Write-Debug " Create resource group"
    $resourceGroupName = Get-ResourceGroupName
    Write-Debug "Resource group name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force

    $namespaceName = "sdk-Namespace"
	<#
	Get-NamespaceName
    
    Write-Debug " Create new notificationHub namespace"
    Write-Debug "Namespace name : $namespaceName"
    $result = New-AzureRmEventHubsNamespace -ResourceGroup $resourceGroupName -Namespace $namespaceName -Location $location
    Wait-Seconds 15
    #>
    Write-Debug " Get the created namespace within the resource group"
    $createdNamespace = Get-AzureRmEventHubsNamespace -ResourceGroup $resourceGroupName -Namespace $namespaceName
    Assert-True {$createdNamespace.Count -eq 1}

    $found = 0
    for ($i = 0; $i -lt $createdNamespace.Count; $i++)
    {
        if ($createdNamespace[$i].Name -eq $namespaceName)
        {
            $found = 1
            Assert-AreEqual $location $createdNamespace[$i].Location
            Assert-AreEqual $resourceGroupName $createdNamespace[$i].ResourceGroupName
            Assert-AreEqual "EventHub" $createdNamespace[$i].NamespaceType
            break
        }
    }

    Assert-True {$found -eq 0} "Namespace created earlier is not found."

    Write-Debug " Create new eventHub "
    $eventHubName = "TestNh"
    $result_eventHub = New-AzureRmEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $eventHubName -InputFile .\.\Resources\NewEventHub.json

    Write-Debug " Get the created eventHub "
    $createdEventHub = Get-AzureRmEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHubName $result_eventHub.Name
    Assert-True {$createdEventHub.Count -eq 1}

    Write-Debug "Create a notificationHub Authorization Rule"
    $authRuleName = "TestAuthRule"
    $result = New-AzureRmEventHubsAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHubName $result_eventHub.Name -InputFile .\.\Resources\NewAuthorizationRule.json

    Assert-AreEqual $authRuleName $result.Name
    Assert-AreEqual 2 $result.Rights.Count
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" }
    Wait-Seconds 15

    Write-Debug "Get created authorizationRule"
    $createdAuthRule = Get-AzureRmEventHubsAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHubName $result_eventHub.Name -AuthorizationRule $authRuleName

    Assert-AreEqual $authRuleName $createdAuthRule.Name
    Assert-AreEqual 2 $createdAuthRule.Rights.Count
    Assert-True { $createdAuthRule.Rights -Contains "Listen" }
    Assert-True { $createdAuthRule.Rights -Contains "Send" }


    Write-Debug "Get All eventHub AuthorizationRule"
    $result = Get-AzureRmEventHubsAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHubName $result_eventHub.Name 

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

    Assert-True {$found -eq 1} "EventHub AuthorizationRule created earlier is not found."

    Write-Debug "Update eventHub AuthorizationRules"
	$createdAuthRule.Rights.Add("Manage")

    $updatedAuthRule = Set-AzureRmEventHubsAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHubName $result_eventHub.Name -SASRule $createdAuthRule
    
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }

    Wait-Seconds 15
    
    $updatedAuthRule = Get-AzureRmEventHubsAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHubName $result_eventHub.Name -AuthorizationRule $authRuleName
    
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }


    Write-Debug "Get notificationHub authorizationRules connectionStrings"
    $namespaceListKeys = Get-AzureRmEventHubListKeys -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHubName $result_eventHub.Name -AuthorizationRule $authRuleName

    Assert-True {$namespaceListKeys.PrimaryConnectionString.Contains($updatedAuthRule.PrimaryKey)}
    Assert-True {$namespaceListKeys.SecondaryConnectionString.Contains($updatedAuthRule.SecondaryKey)}

    Write-Debug "Delete the created notificationHub AuthorizationRule"
    $result = Remove-AzureRmEventHubsAuthorizationRules -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHubName $result_eventHub.Name -AuthorizationRule $authRuleName
    
    Write-Debug "Delete the NotificationHub"
    Remove-AzureRmEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHubName $result_eventHub.Name
    
    Write-Debug "Delete namespaces"
    Remove-AzureRmEventHubsNamespace -ResourceGroup $resourceGroupName -Namespace $namespaceName
}