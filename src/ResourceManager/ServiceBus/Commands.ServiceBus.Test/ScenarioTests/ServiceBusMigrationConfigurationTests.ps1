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
Check the Provisioning state of the created alias and wait till it get succeeded 
#>
function WaitforStatetoBeSucceded
{
	param([string]$resourceGroupName,[string]$namespaceName,[string]$drConfigName)
	
	$createdMigrationConfig = Get-AzureRmServiceBusMigration -ResourceGroup $resourceGroupName -Name $namespaceName

	while($createdMigrationConfig.ProvisioningState -ne "Succeeded")
	{
		Wait-Seconds 10
		$createdMigrationConfig = Get-AzureRmServiceBusMigration -ResourceGroup $resourceGroupName -Name $namespaceName
	}

	return $createdMigrationConfig
}

<#
.SYNOPSIS
Check the Provisioning state of the namespace and wait till it get succeeded 
#>
function WaitforStatetoBeSucceded_namespace
{
	param([string]$resourceGroupName,[string]$namespaceName)
	
	$Getnamespace = Get-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName 

	while($Getnamespace.ProvisioningState -ne "Succeeded")
	{
		Wait-Seconds 10
		$Getnamespace = Get-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName
	}

}

<#
.SYNOPSIS
Check the Provisioning state of the created alias and wait till it get succeeded 
#>
function WaitforStatetoBeSuccededGeoDR 
{
	param([string]$resourceGroupName,[string]$namespaceName,[string]$drConfigName)
	
	$createdDRConfig = Get-AzureRmServiceBusGeoDRConfiguration -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $drConfigName

	while($createdDRConfig.ProvisioningState -ne "Succeeded")
	{
		Wait-Seconds 10
		$createdDRConfig = Get-AzureRmServiceBusGeoDRConfiguration -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $drConfigName
	}

	return $createdDRConfig
}

<#
.SYNOPSIS
Tests ServiceBus MigrationConfiguration Create List Remove operations.
#>

function ServiceBusMigrationConfigurationTests
{
	# Setup    
	$location_south = "South Central US" #Get-Location "Microsoft.ServiceBus" "namespaces" "South Central US"
	$location_north = "North Central US" #Get-Location "Microsoft.ServiceBus" "namespaces" "North Central US"
	$resourceGroupName = getAssetName
	$namespaceName1 = getAssetName "ServiceBus-STDNamespace-"
	$namespaceName2 = getAssetName "ServiceBus-PRENamespace-"	
	$authRuleName = getAssetName "ServiceBus-Namespace-AuthorizationRule"
	$postmigrationName = getAssetName "PostMigration-Name-"
	$nameQueue = getAssetName "Queue-"
	$nameTopic = getAssetName "Topic-"

	# Create Resource Group
	Write-Debug "Create resource group"
	Write-Debug " Resource Group Name : $resourceGroupName"
	New-AzureRmResourceGroup -Name $resourceGroupName -Location $location_south -Force	
		
	# Create ServiceBus Namespace - 1
	Write-Debug "  Create new ServiceBus namespace 1"
	Write-Debug " Namespace 1 name : $namespaceName1"
	$result1 = New-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName1 -Location $location_south -SkuName Standard

	# Assert
	Assert-AreEqual $result1.Name $namespaceName1

	# Create ServiceBus Namespace - 2
	Write-Debug "  Create new ServiceBus namespace 2"
	Write-Debug " Namespace 2 name : $namespaceName2"
	$result2 = New-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName2 -Location $location_north -SkuName Premium

	# Assert
	Assert-AreEqual $result2.Name $namespaceName2

	# get the created ServiceBus Namespace  1
	Write-Debug " Get the created namespace within the resource group"
	$createdNamespace1 = Get-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName1
	
	Assert-AreEqual $createdNamespace1.Name $namespaceName1 "Namespace created earlier is not found."

	# get the created ServiceBus Namespace  2
	Write-Debug " Get the created namespace within the resource group"
	$createdNamespace2 = Get-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName2
	
	Assert-AreEqual $createdNamespace2.Name $namespaceName2 "Namespace created earlier is not found."

	# Create AuthorizationRule
	Write-Debug "Create a Namespace Authorization Rule"
    Write-Debug "Auth Rule name : $authRuleName"
    $result = New-AzureRmServiceBusAuthorizationRule -ResourceGroup $resourceGroupName -Namespace $namespaceName1 -Name $authRuleName -Rights @("Listen","Send")
																																	  
    Assert-AreEqual $authRuleName $result.Name
    Assert-AreEqual 2 $result.Rights.Count
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" }

	# Create Queue in Stanradrd namespace 
	$resultQueue = New-AzureRmServiceBusQueue -ResourceGroupName $resourceGroupName -Namespace $namespaceName1 -Name $nameQueue
	Assert-AreEqual $resultQueue.Name $nameQueue "In CreateQueue response Name not found"

	# Create Topic in Standard namespace
	Write-Debug "Create Topic"
	$resultTopic = New-AzureRmServiceBusTopic -ResourceGroupName $resourceGroupName -Namespace $namespaceName1 -Name $nameTopic -EnablePartitioning $TRUE
	Assert-AreEqual $resultTopic.Name $nameTopic "In CreateTopic response Name not found"
				
	# Create and Start MigrationConfiguration
	Write-Debug " Create and Start MigrationConfiguration"
	$result = New-AzureRmServiceBusStartMigration -ResourceGroupName $resourceGroupName -Name $namespaceName1 -TargetNameSpace $result2.Id -PostMigrationName $postmigrationName

	# Wait till the Migration Provisioning  state changes to succeeded
	WaitforStatetoBeSucceded $resourceGroupName $namespaceName1

	# Complete the Migration
	$completMigration = Set-AzureRmServiceBusCompleteMigration -ResourceGroupName $resourceGroupName -Name $namespaceName1
	
	# Get Premium Namespaces 
	$GetPremiumNamespace = Get-AzureRmServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName2
			
	# Get queue using Premium namespace to check migration
	$getQueue = Get-AzureRmServiceBusQueue -ResourceGroupName $resourceGroupName -Namespace $namespaceName2 -Name $nameQueue
	Assert-AreEqual $getQueue.Name $nameQueue "In CreateQueue response Name not found"

	# Get Topic using Premium namespace to check migration
	Write-Debug "Create Topic"
	$getTopic = Get-AzureRmServiceBusTopic -ResourceGroupName $resourceGroupName -Namespace $namespaceName2 -Name $nameTopic
	Assert-AreEqual $getTopic.Name $nameTopic "In CreateTopic response Name not found"

	# Wait till the Namespace Provisioning  state changes to succeeded
	WaitforStatetoBeSucceded_namespace $resourceGroupName $namespaceName2

	# Wait till the migrationConfiguration Provisioning  state changes to succeeded
	WaitforStatetoBeSuccededGeoDR $resourceGroupName $namespaceName2 $namespaceName1

	Write-Debug " Delete namespaces"
    Remove-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName1

	Write-Debug " Delete namespaces"
    Remove-AzureRmServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName2

	Write-Debug " Delete resourcegroup"
	Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}