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
function WaitforStatetoBeSucceded {
    param([string]$resourceGroupName, [string]$namespaceName, [string]$drConfigName)
	
    $createdMigrationConfig = Get-AzServiceBusMigration -ResourceGroup $resourceGroupName -Name $namespaceName

    while ($createdMigrationConfig.MigrationState -ne "Active" -and $createdMigrationConfig.ProvisioningState -ne "Succeeded") {
        Wait-Seconds 10
        $createdMigrationConfig = Get-AzServiceBusMigration -ResourceGroup $resourceGroupName -Name $namespaceName
    }

    while ($createdMigrationConfig.PendingReplicationOperationsCount -ne $null -and $createdMigrationConfig.PendingReplicationOperationsCount -gt 0) {
        Wait-Seconds 10
        $createdMigrationConfig = Get-AzServiceBusMigration -ResourceGroup $resourceGroupName -Name $namespaceName
    }

    return $createdMigrationConfig
}

<#
.SYNOPSIS
Check the Provisioning state of the namespace and wait till it get succeeded 
#>
function WaitforStatetoBeSucceded_namespace {
    param([string]$resourceGroupName, [string]$namespaceName)
	
    $Getnamespace = Get-AzServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName 

    while ($Getnamespace.ProvisioningState -ne "Succeeded") {
        Wait-Seconds 10
        $Getnamespace = Get-AzServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName
    }

}

<#
.SYNOPSIS
Tests ServiceBus MigrationConfiguration Create List Remove operations.
#>

function ServiceBusMigrationConfigurationTests {
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
    New-AzResourceGroup -Name $resourceGroupName -Location $location_south -Force	
		
    # Create ServiceBus Namespace - 1
    Write-Debug "  Create new ServiceBus namespace 1"
    Write-Debug " Namespace 1 name : $namespaceName1"
    $result1 = New-AzServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName1 -Location $location_south -SkuName Standard

    # Assert
    Assert-AreEqual $result1.Name $namespaceName1

    # Create ServiceBus Namespace - 2
    Write-Debug "  Create new ServiceBus namespace 2"
    Write-Debug " Namespace 2 name : $namespaceName2"
    $result2 = New-AzServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName2 -Location $location_north -SkuName Premium

    # Assert
    Assert-AreEqual $result2.Name $namespaceName2

    Try {
        # get the created ServiceBus Namespace  1
        Write-Debug " Get the created namespace within the resource group"
        $createdNamespace1 = Get-AzServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName1
	
        Assert-AreEqual $createdNamespace1.Name $namespaceName1 "Namespace created earlier is not found."

        # get the created ServiceBus Namespace  2
        Write-Debug " Get the created namespace within the resource group"
        $createdNamespace2 = Get-AzServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName2
	
        Assert-AreEqual $createdNamespace2.Name $namespaceName2 "Namespace created earlier is not found."

        # Create AuthorizationRule
        Write-Debug "Create a Namespace Authorization Rule"
        Write-Debug "Auth Rule name : $authRuleName"
        $result = New-AzServiceBusAuthorizationRule -ResourceGroup $resourceGroupName -Namespace $namespaceName1 -Name $authRuleName -Rights @("Listen", "Send")
																																	  
        Assert-AreEqual $authRuleName $result.Name
        Assert-AreEqual 2 $result.Rights.Count
        Assert-True { $result.Rights -Contains "Listen" }
        Assert-True { $result.Rights -Contains "Send" }
	
        # Create Queue in Stanradrd namespace
        for ($count = 0; $count -lt 20 ; $count++) {
            $queueName = getAssetName "Queue-"
            $resultQueue = New-AzServiceBusQueue -ResourceGroupName $resourceGroupName -Namespace $namespaceName1 -Name $queueName
        } 	
	
        # Create Topic in Stanradrd namespace
        for ($count = 0; $count -lt 20 ; $count++) {
            $topicName = getAssetName "Topic-"
            $resultTopic = New-AzServiceBusTopic -ResourceGroupName $resourceGroupName -Namespace $namespaceName1 -Name $topicName -EnablePartitioning $TRUE		
        } 
				
        # Create and Start MigrationConfiguration
        Write-Debug " Create and Start MigrationConfiguration"
        $result = Start-AzServiceBusMigration -ResourceGroupName $resourceGroupName -Name $namespaceName1 -TargetNameSpace $result2.Id -PostMigrationName $postmigrationName
	
        # Wait till the Migration Provisioning  state changes to succeeded
        WaitforStatetoBeSucceded $resourceGroupName $namespaceName1
																			  
        # Complete the Migration
        $completMigration = Complete-AzServiceBusMigration -ResourceGroupName $resourceGroupName -Name $namespaceName1

        # Wait till the Migration Provisioning  state changes to succeeded
        WaitforStatetoBeSucceded $resourceGroupName $namespaceName1
	
        # Get Premium Namespaces 
        $GetPremiumNamespace = Get-AzServiceBusNamespace -ResourceGroup $resourceGroupName -NamespaceName $namespaceName2
			
        # Get queues using Premium namespace to check migration
        $getQueueList = Get-AzServiceBusQueue -ResourceGroupName $resourceGroupName -Namespace $namespaceName2
        Assert-AreEqual $getQueueList.Count 20 "Total Queue count not 20"

        # Get Topic using Premium namespace to check migration			
        $getTopicList = Get-AzServiceBusTopic -ResourceGroupName $resourceGroupName -Namespace $namespaceName2
        Assert-AreEqual $getTopicList.Count 20 "Total Topic count not 20"

        # Wait till the Namespace Provisioning  state changes to succeeded
        WaitforStatetoBeSucceded_namespace $resourceGroupName $namespaceName2

        # Wait till the migrationConfiguration Provisioning  state changes to succeeded
        WaitforStatetoBeSucceded $resourceGroupName $namespaceName1
    }
    Finally {
        Write-Debug " Delete namespaces"
        Remove-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName1

        Write-Debug " Delete namespaces"
        Remove-AzServiceBusNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName2

        Write-Debug " Delete resourcegroup"
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }

	
}