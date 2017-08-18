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
Get valid EventHub name
#>
function Get-DRConfigName
{
	return "DRConfig-" + (getAssetName)
}

<#
.SYNOPSIS
Get valid Namespace name
#>
function Get-NamespaceName
{
	return "Eventhub-Namespace-" + (getAssetName)
	
}


<#
.SYNOPSIS
Tests EventHubs DRConfiguration Create List Remove operations.
#>

function DRConfigurationTests
{
	# Setup    
	$location = Get-Location
	$resourceGroupName = Get-ResourceGroupName
	$namespaceName1 = Get-NamespaceName
	$namespaceName2 = Get-NamespaceName
	$drConfigName = Get-DRConfigName

	# Create Resource Group
	Write-Debug "Create resource group"    
	Write-Debug " Resource Group Name : $resourceGroupName"
	New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force
	
		
	# Create EventHub Namespace - 1
	Write-Debug "  Create new eventhub namespace 1"
	Write-Debug " Namespace 1 name : $namespaceName1"
	$result1 = New-AzureRmEventHubNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName1 -Location $location

	# Assert
	Assert-True {$result1.ProvisioningState -eq "Succeeded"}


	# Create EventHub Namespace - 2
	Write-Debug "  Create new eventhub namespace 2"
	Write-Debug " Namespace 2 name : $namespaceName2"
	$result2 = New-AzureRmEventHubNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName2 -Location $location

	# Assert
	Assert-True {$result2.ProvisioningState -eq "Succeeded"}	

	# get the created Eventhub Namespace  1
	Write-Debug " Get the created namespace within the resource group"
	$createdNamespace1 = Get-AzureRmEventHubNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName1
	
	Assert-True {$createdNamespace1.Name -eq $namespaceName1} "Namespace created earlier is not found."

	# get the created Eventhub Namespace  2
	Write-Debug " Get the created namespace within the resource group"
	$createdNamespace2 = Get-AzureRmEventHubNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName2
	
	Assert-True {$createdNamespace2.Name -eq $namespaceName2} "Namespace created earlier is not found."	

	# Create a DRConfiguration
	Write-Debug " Create new DRConfiguration"
	$result = New-AzureRmEventHubDRConfiguration -ResourceGroup $resourceGroupName -NamespaceName $namespaceName1 -Name $drConfigName -PartnerNamespace $namespaceName2
		
	Write-Debug " Get the created DRConfiguration"
	$createdDRConfig = Get-AzureRmEventHubDRConfiguration -ResourceGroup $resourceGroupName -NamespaceName $namespaceName1 -Name $drConfigName

	# Assert
	Assert-True {$createdEventHub.PartnerNamespace -eq $namespaceName2} "DRConfig created earlier is not found."

	# Get the Created DRConfiguration
	Write-Debug " Get all the created DRConfiguration"
	$createdEventHubDRConfigList = Get-AzureRmEventHubDRConfiguration -ResourceGroup $resourceGroupName -NamespaceName $namespaceName1

	# Assert
	Assert-True {$createdEventHubDRConfigList.Count -eq 1} "EventHub DRConfig created earlier is not found in list"

	# BreakPairing on Primary Namespace
	Write-Debug "BreakPairing on Primary Namespace"
	Set-AzureRmEventHubDRConfigurationBreakPairing -ResourceGroup $resourceGroupName -NamespaceName $namespaceName1 -Name $drConfigName

	# FailOver on Secondary Namespace
	Write-Debug "FailOver on Secondary Namespace"
	Set-AzureRmEventHubDRConfigurationFailOVer -ResourceGroup $resourceGroupName -NamespaceName $namespaceName2 -Name $drConfigName
	
	# Cleanup
	# Delete all Created Eventhub
	#Write-Debug " Delete the EventHub"
	#for ($i = 0; $i -lt $createdEventHubList.Count; $i++)
	#{
	#	$delete1 = Remove-AzureRmEventHub -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -EventHubName $createdEventHubList[$i].Name		
	#}
	#Write-Debug " Delete namespaces"
	#Remove-AzureRmEventHubNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName

	Write-Debug " Delete resourcegroup"
	Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}

<#
.SYNOPSIS
Tests New parameter names EventHubs Create List Remove operations.
#>

function DRConfigurationTests_BreakPairing
{
	# Setup    
	$location = Get-Location
	$resourceGroupName = Get-ResourceGroupName
	$namespaceName = Get-NamespaceName
	$eventHubName = Get-EventHubName

	# Create Resource Group
	Write-Debug "Create resource group"    
	Write-Debug " Resource Group Name : $resourceGroupName"
	New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force
	
		
	# Create EventHub Namespace
	Write-Debug "  Create new eventhub namespace"
	Write-Debug " Namespace name : $namespaceName"
	$result = New-AzureRmEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName -Location $location

	# Assert
	Assert-True {$result.ProvisioningState -eq "Succeeded"}
	

	# get the created Eventhub Namespace 
	Write-Debug " Get the created namespace within the resource group"
	$createdNamespace = Get-AzureRmEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName
	
	Assert-True {$createdNamespace.Name -eq $namespaceName} "Namespace created earlier is not found."
	
	# Create a EventHub
	Write-Debug " Create new eventHub "    
	$msgRetentionInDays = 3
	$partionCount = 2
	$result = New-AzureRmEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $eventHubName -MessageRetentionInDays $msgRetentionInDays -PartitionCount $partionCount
	
		
	Write-Debug " Get the created Eventhub "
	$createdEventHub = Get-AzureRmEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $result.Name

	# Assert
	Assert-True {$createdEventHub.Name -eq $eventHubName} "EventHub created earlier is not found."	    

	# Get the Created Eventhub
	Write-Debug " Get all the created EventHub "
	$createdEventHubList = Get-AzureRmEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName

	# Assert
	Assert-True {$createdEventHubList.Count -eq 1} "EventHub created earlier is not found in list"

	$createdEventHub.MessageRetentionInDays = 3
	Set-AzureRmEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $createdEventHub.Name  -InputObject $createdEventHub


	# Update the Created EventHub
	Write-Debug " Update the first EventHub"    
	$createdEventHub.MessageRetentionInDays = 4	
	$createdEventHub.CaptureDescription = New-Object -TypeName Microsoft.Azure.Commands.EventHub.Models.CaptureDescriptionAttributes
	$createdEventHub.CaptureDescription.Enabled = $true
	$createdEventHub.CaptureDescription.IntervalInSeconds  = 120
	$createdEventHub.CaptureDescription.Encoding  = "Avro"
	$createdEventHub.CaptureDescription.SizeLimitInBytes = 10485763
	$createdEventHub.CaptureDescription.Destination.Name = "EventHubArchive.AzureBlockBlob"
	$createdEventHub.CaptureDescription.Destination.BlobContainer = "container01"
	$createdEventHub.CaptureDescription.Destination.ArchiveNameFormat = "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}"
	$createdEventHub.CaptureDescription.Destination.StorageAccountResourceId = "/subscriptions/854d368f-1828-428f-8f3c-f2affa9b2f7d/resourceGroups/default-servicebus-westus/providers/Microsoft.Storage/storageAccounts/eventhubteststorage011"
		
	$result = Set-AzureRmEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $createdEventHub.Name  -InputObject $createdEventHub
	
	# Assert
	Assert-True {$result.MessageRetentionInDays -eq $createdEventHub.MessageRetentionInDays}
	Assert-True {$result.CaptureDescription.Destination.BlobContainer -eq "container01"}
	#Assert-True{$result.CaptureDescription.Destination.StorageAccountResourceId -eq "/subscriptions/854d368f-1828-428f-8f3c-f2affa9b2f7d/resourceGroups/Default-ServiceBus-WestUS/providers/Microsoft.ClassicStorage/storageAccounts/eventhubteststorage011"}


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
Tests EventHub AuthorizationRules Create List Remove operations.
#>
function DRConfigurationTests_FailOver
{
	# Setup    
	$location =  Get-Location
	$resourceGroupName = Get-ResourceGroupName
	$namespaceName = Get-NamespaceName    
	$eventHubName = Get-EventHubName	
	$authRuleName = Get-AuthorizationRuleName

	# Create ResourceGroup
	Write-Debug " Create resource group"    
	Write-Debug "Resource group name : $resourceGroupName"
	New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force
	   
	# Create EventHub Namespace 
	Write-Debug " Create new Eventhub namespace"
	Write-Debug "Namespace name : $namespaceName"
	$result = New-AzureRmEventHubNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -Location $location
	
	# Assert
	Assert-True {$result.ProvisioningState -eq "Succeeded"}

	# Get Created NameSpace
	Write-Debug " Get the created namespace within the resource group"
	$createdNamespace = Get-AzureRmEventHubNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName
	
	# Assert
	Assert-True {$createdNamespace.Name -eq $namespaceName} "Namespace created earlier is not found."

	# Create New EventHub
	Write-Debug " Create new eventHub "    
	$msgRetentionInDays = 3
	$partionCount = 2
	$result_eventHub = New-AzureRmEventHub -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -Location $location -EventHubName $eventHubName -MessageRetentionInDays $msgRetentionInDays -PartitionCount $partionCount
	
	Write-Debug "Get the created eventHub"
	$createdEventHub = Get-AzureRmEventHub -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -EventHubName $result_eventHub.Name

	# Assert
	Assert-True {$createdEventHub.Name -eq $eventHubName} "EventHub created earlier is not found."

	# Create Eventhub Authorization Rule
	Write-Debug "Create a EventHub Authorization Rule"
	$result = New-AzureRmEventHubAuthorizationRule -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -EventHubName $eventHubName -AuthorizationRuleName $authRuleName -Rights @("Listen","Send")

	# Assert
	Assert-AreEqual $authRuleName $result.Name
	Assert-AreEqual 2 $result.Rights.Count
	Assert-True { $result.Rights -Contains "Listen" }
	Assert-True { $result.Rights -Contains "Send" }

	# Get Created Eventhub Authorization Rule
	Write-Debug "Get created authorizationRule"
	$createdAuthRule = Get-AzureRmEventHubAuthorizationRule -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -EventHubName $eventHubName -AuthorizationRule $authRuleName

	# Assert
	Assert-AreEqual $authRuleName $createdAuthRule.Name
	Assert-AreEqual 2 $createdAuthRule.Rights.Count
	Assert-True { $createdAuthRule.Rights -Contains "Listen" }
	Assert-True { $createdAuthRule.Rights -Contains "Send" }

	# Get all Eventhub Authorization Rules
	Write-Debug "Get All eventHub AuthorizationRule"
	$result = Get-AzureRmEventHubAuthorizationRule -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -EventHubName $eventHubName
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
	Assert-True {$found -eq 1} "EventHub AuthorizationRule created earlier is not found."

	# Update the Eventhub Authorization Rule
	Write-Debug "Update eventHub AuthorizationRule"
	$createdAuthRule.Rights.Add("Manage")
	$updatedAuthRule = Set-AzureRmEventHubAuthorizationRule -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -EventHubName $eventHubName -AuthorizationRuleName $authRuleName -AuthRuleObj $createdAuthRule

	# Assert
	Assert-AreEqual $authRuleName $updatedAuthRule.Name
	Assert-AreEqual 3 $updatedAuthRule.Rights.Count
	Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
	Assert-True { $updatedAuthRule.Rights -Contains "Send" }
	Assert-True { $updatedAuthRule.Rights -Contains "Manage" }
	   
	# get the Updated Eventhub Authorization Rule
	$updatedAuthRule = Get-AzureRmEventHubAuthorizationRule -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -EventHubName $eventHubName -AuthorizationRuleName $authRuleName
	
	# Assert
	Assert-AreEqual $authRuleName $updatedAuthRule.Name
	Assert-AreEqual 3 $updatedAuthRule.Rights.Count
	Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
	Assert-True { $updatedAuthRule.Rights -Contains "Send" }
	Assert-True { $updatedAuthRule.Rights -Contains "Manage" }
	
	# Get the List Keys
	Write-Debug "Get Eventhub authorizationRules connectionStrings"
	$namespaceListKeys = Get-AzureRmEventHubKey -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -EventHubName $eventHubName -AuthorizationRuleName $authRuleName

	Assert-True {$namespaceListKeys.PrimaryConnectionString.Contains($updatedAuthRule.PrimaryKey)}
	Assert-True {$namespaceListKeys.SecondaryConnectionString.Contains($updatedAuthRule.SecondaryKey)}
	
	# Regentrate the Keys 
	$policyKey = "PrimaryKey"

	$namespaceRegenerateKeys = New-AzureRmEventHubKey -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -EventHubName $eventHubName -AuthorizationRuleName $authRuleName -RegenerateKey $policyKey
	Assert-True {$namespaceRegenerateKeys.PrimaryKey -ne $namespaceListKeys.PrimaryKey}

	$policyKey1 = "SecondaryKey"

	$namespaceRegenerateKeys1 = New-AzureRmEventHubKey -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -EventHubName $eventHubName -AuthorizationRuleName $authRuleName -RegenerateKey $policyKey1
	Assert-True {$namespaceRegenerateKeys1.SecondaryKey -ne $namespaceListKeys.SecondaryKey}


	# Cleanup
	Write-Debug "Delete the created EventHub AuthorizationRule"
	$result = Remove-AzureRmEventHubAuthorizationRule -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -EventHubName $eventHubName -AuthorizationRuleName $authRuleName -Force
	
	Write-Debug "Delete the Eventhub"
	Remove-AzureRmEventHub -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -EventHubName $eventHubName
	
	Write-Debug "Delete NameSpace"
	Remove-AzureRmEventHubNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName

	Write-Debug " Delete resourcegroup"
	#Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}
