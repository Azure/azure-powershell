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
Get ConsumerGroup name
#>
function Get-ConsumerGroupName
{
    return "ConsumerGroup-" + (getAssetName)
}

<#
.SYNOPSIS
Get valid Namespace name
#>
function Get-NamespaceName
{
    return "Namespace-" + (getAssetName)
}

<#
.SYNOPSIS
Tests EventHub Namespace Create List Remove operations.
#>
function ConsumerGroupsTests
{ # Setup    
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
    $eventHubName = "eventhub11"
	
    $result = New-AzureRmEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $eventHubName -InputFile .\.\Resources\NewEventHub.json
			
    Write-Debug " Get the created eventHub "
    $createdEventHub = Get-AzureRmEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHubName $result.Name 
	
	$createdEventHub = Get-AzureRmEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHubName $eventHubName
    Assert-True {$createdEventHub.Count -eq 1}

	$consumerGroupName = "consumergroup1" #Get-ConsumerGroupName

	
	Write-Debug " Create a new ConsumerGroup "
	$result_ConsumerGroup = New-AzureRmEventHubConsumerGroup -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHubName $result.Name -ConsumerGroupName $consumerGroupName -InputFile .\.\Resources\NewConsumerGroup.json
		
	Write-Debug " Get created ConsumerGroup "
	$CreatedConsumerGroup = Get-AzureRmEventHubConsumerGroup -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHubName $result.Name -ConsumerGroupName $result_ConsumerGroup.Name
	
	Write-Debug " Get all created ConsumerGroup "
	$CreatedConsumerGroup = Get-AzureRmEventHubConsumerGroup -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHubName $result.Name

	Write-Debug " Delete created ConsumerGroup "
	Remove-AzureRmEventHubConsumerGroup -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHubName $result.Name -ConsumerGroupName $consumerGroupName

	
    Write-Debug " Delete the EventHub"
    $delete1 = Remove-AzureRmEventHub -ResourceGroup $resourceGroupName -Namespace $namespaceName -EventHubName $result.Name  

    Write-Debug " Delete namespaces"
    Remove-AzureRmEventHubsNamespace -ResourceGroup $resourceGroupName -Namespace $namespaceName
}