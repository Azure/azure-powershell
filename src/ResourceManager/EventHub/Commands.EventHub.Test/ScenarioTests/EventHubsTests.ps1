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
Tests New Parameter names EventHubs Create List Remove operations.
#>

function EventHubsTests
{
	# Setup    
	$location = Get-Location
	$resourceGroupName = getAssetName "RSG"
	$namespaceName = getAssetName "Eventhub-Namespace-"
	$eventHubName = getAssetName "EventHub-"
	$eventHubName2 = getAssetName "EventHub-"

	# Create Resource Group
	Write-Debug "Create resource group"    
	Write-Debug " Resource Group Name : $resourceGroupName"
	New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force
	
		
	# Create EventHub Namespace
	Write-Debug "  Create new eventhub namespace"
	Write-Debug " Namespace name : $namespaceName"
	$result = New-AzureRmEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName -Location $location

	# Assert
	Assert-AreEqual $result.Name $namespaceName	"New Namespace: Namespace created earlier is not found."

	# get the created Eventhub Namespace 
	Write-Debug " Get the created namespace within the resource group"
	$createdNamespace = Get-AzureRmEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName
	
	Assert-AreEqual $createdNamespace.Name $namespaceName "Get Namespace: Namespace created earlier is not found."
	
	# Create a EventHub
	Write-Debug " Create new eventHub "	
	$result = New-AzureRmEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $eventHubName
			
	Write-Debug " Get the created Eventhub "
	$createdEventHub = Get-AzureRmEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $result.Name

	# Assert
	Assert-AreEqual $createdEventHub.Name $eventHubName "Get Eventhub: EventHub created earlier is not found."	    

	# Get the Created Eventhub
	Write-Debug " Get all the created EventHub "
	$createdEventHubList = Get-AzureRmEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName

	# Assert
	Assert-AreEqual $createdEventHubList.Count 1 "List Eventhub: EventHub created earlier is not found in list"

	$createdEventHub.MessageRetentionInDays = 3
	Set-AzureRmEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $createdEventHub.Name  -InputObject $createdEventHub
	
	# Update the Created EventHub
	Write-Debug " Update the first EventHub"
	$createdEventHub.MessageRetentionInDays = 4	
	$createdEventHub.CaptureDescription = New-Object -TypeName Microsoft.Azure.Commands.EventHub.Models.PSCaptureDescriptionAttributes
	$createdEventHub.CaptureDescription.Enabled = $true
	$createdEventHub.CaptureDescription.IntervalInSeconds  = 120
	$createdEventHub.CaptureDescription.Encoding  = "Avro"
	$createdEventHub.CaptureDescription.SizeLimitInBytes = 10485763
	$createdEventHub.CaptureDescription.Destination.Name = "EventHubArchive.AzureBlockBlob"
	$createdEventHub.CaptureDescription.Destination.BlobContainer = "container01"
	$createdEventHub.CaptureDescription.Destination.ArchiveNameFormat = "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}"
	$createdEventHub.CaptureDescription.Destination.StorageAccountResourceId = "/subscriptions/e2f361f0-3b27-4503-a9cc-21cfba380093/resourceGroups/Default-Storage-SouthCentralUS/providers/Microsoft.ClassicStorage/storageAccounts/arjunteststorage"
		
	$result = Set-AzureRmEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $createdEventHub.Name  -InputObject $createdEventHub
	
	# Assert
	Assert-AreEqual $result.MessageRetentionInDays $createdEventHub.MessageRetentionInDays
	Assert-AreEqual $result.CaptureDescription.Destination.BlobContainer "container01"

	# Create New EventHub with InputObject
	$resultNew = New-AzureRmEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $createdEventHub.Name  -InputObject $result

	# Assert
	Assert-AreEqual $resultNew.MessageRetentionInDays $createdEventHub.MessageRetentionInDays
	Assert-AreEqual $resultNew.CaptureDescription.Destination.BlobContainer "container01"
	
	# Cleanup
	# Delete all Created Eventhub
	Write-Debug " Delete the EventHub"
	for ($i = 0; $i -lt $createdEventHubList.Count; $i++)
	{
		$delete1 = Remove-AzureRmEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $createdEventHubList[$i].Name		
	}
	Write-Debug " Delete namespaces"
	Remove-AzureRmEventHubNamespace -ResourceGroup $resourceGroupName -Namespace $namespaceName

	Write-Debug " Delete resourcegroup"
	#Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}

<#
.SYNOPSIS
Tests New EventHub AuthorizationRules cmdlets to Create List Remove operations.
#>
function EventHubsAuthTests
{
	# Setup    
	$location =  Get-Location
	$resourceGroupName = getAssetName "RSG"
	$namespaceName = getAssetName "Eventhub-Namespace-"
	$eventHubName = getAssetName "EventHub-"
	$authRuleName = getAssetName "Eventhub-Namespace-AuthorizationRule"

	# Create ResourceGroup
	Write-Debug " Create resource group"    
	Write-Debug "Resource group name : $resourceGroupName"
	New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force
	   
	# Create EventHub Namespace 
	Write-Debug " Create new Eventhub namespace"
	Write-Debug "Namespace name : $namespaceName"
	$result = New-AzureRmEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName -Location $location

	# Assert
	Assert-AreEqual $result.Name $namespaceName "New Namespace: Namespace created earlier is not found."

	# Get Created NameSpace
	Write-Debug " Get the created namespace within the resource group"
	$createdNamespace = Get-AzureRmEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName
	
	# Assert
	Assert-AreEqual $createdNamespace.Name $namespaceName "Get Namespace: Namespace created earlier is not found."

	# Create New EventHub
	Write-Debug " Create new eventHub "    
	$msgRetentionInDays = 3
	$partionCount = 2
	$result_eventHub = New-AzureRmEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $eventHubName -MessageRetentionInDays $msgRetentionInDays -PartitionCount $partionCount
	
	Write-Debug "Get the created eventHub"
	$createdEventHub = Get-AzureRmEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $result_eventHub.Name

	# Assert
	Assert-AreEqual $createdEventHub.Name $eventHubName "Get Eventhub: EventHub created earlier is not found."
	Assert-AreEqual $createdEventHub.PartitionCount $partionCount "Get Eventhub: PartionCount dosent match with the creation value"

	# Create Eventhub Authorization Rule
	Write-Debug "Create a EventHub Authorization Rule"
	$result = New-AzureRmEventHubAuthorizationRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHub $eventHubName -Name $authRuleName -Rights @("Listen","Send")

	# Assert
	Assert-AreEqual $authRuleName $result.Name
	Assert-AreEqual 2 $result.Rights.Count
	Assert-True { $result.Rights -Contains "Listen" }
	Assert-True { $result.Rights -Contains "Send" }

	# Get Created Eventhub Authorization Rule
	Write-Debug "Get created authorizationRule"
	$createdAuthRule = Get-AzureRmEventHubAuthorizationRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHub $eventHubName -Name $authRuleName

	# Assert
	Assert-AreEqual $authRuleName $createdAuthRule.Name "Get Authorizationrule: Authorizationrule name do not match"
	Assert-AreEqual 2 $createdAuthRule.Rights.Count  "Get Authorizationrule: rights count do not match"
	Assert-True { $createdAuthRule.Rights -Contains "Listen" }
	Assert-True { $createdAuthRule.Rights -Contains "Send" }

	# Get all Eventhub Authorization Rules
	Write-Debug "Get All eventHub AuthorizationRule"
	$result = Get-AzureRmEventHubAuthorizationRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHub $eventHubName
	# Assert
	for ($i = 0; $i -lt $result.Count; $i++)
	{
		if ($result[$i].Name -eq $authRuleName)
		{			
			Assert-AreEqual 2 $result[$i].Rights.Count
			Assert-True { $result[$i].Rights -Contains "Listen" }
			Assert-True { $result[$i].Rights -Contains "Send" }         
			break
		}
	}

	Assert-True { $result.Count -ge 0 } "List Eventhub Autorizationrule: EventHub AuthorizationRule created earlier is not found."

	# Update the Eventhub Authorization Rule
	Write-Debug "Update eventHub AuthorizationRule"
	$createdAuthRule.Rights.Add("Manage")
	$updatedAuthRule = Set-AzureRmEventHubAuthorizationRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHub $eventHubName -Name $authRuleName -InputObj $createdAuthRule

	# Assert
	Assert-AreEqual $authRuleName $updatedAuthRule.Name "Set Authorizationrule: Authorizationrule name do not match"
	Assert-AreEqual 3 $updatedAuthRule.Rights.Count
	Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
	Assert-True { $updatedAuthRule.Rights -Contains "Send" }
	Assert-True { $updatedAuthRule.Rights -Contains "Manage" }
	   
	# get the Updated Eventhub Authorization Rule
	$updatedAuthRule = Get-AzureRmEventHubAuthorizationRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHub $eventHubName -Name $authRuleName
	
	# Assert
	Assert-AreEqual $authRuleName $updatedAuthRule.Name "Get Authorization rule after Set (updated): Autho rule name dosent match"
	Assert-AreEqual 3 $updatedAuthRule.Rights.Count
	Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
	Assert-True { $updatedAuthRule.Rights -Contains "Send" }
	Assert-True { $updatedAuthRule.Rights -Contains "Manage" }
	
	# Get the List Keys
	Write-Debug "Get Eventhub authorizationRules connectionStrings"
	$namespaceListKeys = Get-AzureRmEventHubKey -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHub $eventHubName -Name $authRuleName

	Assert-True {$namespaceListKeys.PrimaryConnectionString.Contains($updatedAuthRule.PrimaryKey)}
	Assert-True {$namespaceListKeys.SecondaryConnectionString.Contains($updatedAuthRule.SecondaryKey)}
	
	# Regentrate the Keys 
	$policyKey = "PrimaryKey"

	$namespaceRegenerateKeysDefault = New-AzureRmEventHubKey -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHub $eventHubName -Name $authRuleName -RegenerateKey $policyKey
	Assert-True {$namespaceRegenerateKeysDefault.PrimaryKey -ne $namespaceListKeys.PrimaryKey}

	$namespaceRegenerateKeys = New-AzureRmEventHubKey -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHub $eventHubName -Name $authRuleName -RegenerateKey $policyKey -KeyValue $namespaceListKeys.PrimaryKey
	Assert-AreEqual $namespaceRegenerateKeys.PrimaryKey $namespaceListKeys.PrimaryKey

	$policyKey1 = "SecondaryKey"

	$namespaceRegenerateKeys1 = New-AzureRmEventHubKey -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHub $eventHubName -Name $authRuleName -RegenerateKey $policyKey1 -KeyValue $namespaceListKeys.PrimaryKey
	Assert-AreEqual $namespaceRegenerateKeys1.SecondaryKey $namespaceListKeys.PrimaryKey

	$namespaceRegenerateKeys1 = New-AzureRmEventHubKey -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHub $eventHubName -Name $authRuleName -RegenerateKey $policyKey1
	Assert-True {$namespaceRegenerateKeys1.SecondaryKey -ne $namespaceListKeys.PrimaryKey}	

	# Cleanup
	Write-Debug "Delete the created EventHub AuthorizationRule"
	$result = Remove-AzureRmEventHubAuthorizationRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHub $eventHubName -Name $authRuleName -Force
	
	Write-Debug "Delete the Eventhub"
	Remove-AzureRmEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $eventHubName 
	
	Write-Debug "Delete NameSpace"
	Remove-AzureRmEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName

	Write-Debug " Delete resourcegroup"
	Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}