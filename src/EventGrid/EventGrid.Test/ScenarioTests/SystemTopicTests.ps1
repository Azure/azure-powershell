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
Tests EventGrid Topic Create, Get and List operations.
#>
function SystemTopicTests {
    # Setup
    $location = Get-LocationForEventGrid
    $topicName = Get-TopicName
    $topicName2 = Get-TopicName
    $topicName3 = Get-TopicName
    $topicName4 = Get-TopicName
    $resourceGroupName = Get-ResourceGroupName
    $secondResourceGroup = Get-ResourceGroupName
    $subscriptionId = Get-SubscriptionId

    New-ResourceGroup $resourceGroupName $location

    New-ResourceGroup $secondResourceGroup $location

    $sbNamespaceName = Get-ServiceBusNameSpaceName
    $sbNamespaceName2 = Get-ServiceBusNameSpaceName
    $sbNamespaceName3 = Get-ServiceBusNameSpaceName
    $sbQueueName = Get-ServiceBusQueueName
    $sbTopicName = Get-ServiceBusTopicName

    $sbNamespaceInRg1 = New-ServiceBusNamespace $ResourceGroupName $sbNamespaceName $Location

    $sbNamespace1InRg2 = New-ServiceBusNamespace $secondResourceGroup $sbNamespaceName2 $Location

    $sbNamespace2InRg2 = New-ServiceBusNamespace $secondResourceGroup $sbNamespaceName3 $Location

    try
    {
        Write-Debug "Creating a new EventGrid SystemTopic: $topicName in resource group $resourceGroupName"
        Write-Debug "Topic: $topicName"
        $result = New-AzEventGridSystemTopic -ResourceGroup $resourceGroupName -Name $topicName -Location $location -Source $sbNamespaceInRg1.Id -TopicType 'Microsoft.ServiceBus/Namespaces'
        Assert-True {$result.ProvisioningState -eq "Succeeded"}

        Write-Debug "Getting the created topic within the resource group"
        $createdTopic = Get-AzEventGridSystemTopic -ResourceGroup $resourceGroupName -Name $topicName
        Assert-True {$createdTopic.Count -eq 1}
        Assert-True {$createdTopic.TopicName -eq $topicName} "System Topic created earlier is not found."

        Write-Debug "Creating a second EventGrid SystemTopic: $topicName2 in resource group $secondResourceGroup"
        $result = New-AzEventGridSystemTopic -ResourceGroup $secondResourceGroup -Name $topicName2 -Location $location -Tag @{ Dept = "IT"; Environment = "Test" } -Source $sbNamespace1InRg2.Id -TopicType 'Microsoft.ServiceBus/Namespaces'
        Assert-True {$result.ProvisioningState -eq "Succeeded"}

        Write-Debug "Creating a third EventGrid SystemTopic: $topicName3 in resource group $secondResourceGroup"
        $result = New-AzEventGridSystemTopic -ResourceGroup $secondResourceGroup -Name $topicName3 -Location $location -Source $sbNamespace1InRg2.Id -TopicType 'Microsoft.ServiceBus/Namespaces'
        Assert-True {$result.ProvisioningState -eq "Succeeded"}

        Write-Debug "Listing all the system topics created in the resourceGroup $secondResourceGroup"
        $allCreatedTopics = Get-AzEventGridSystemTopic -ResourceGroup $secondResourceGroup
        Assert-True {$allCreatedTopics.PsSystemTopicsList.Count -ge 0 } "Topic created earlier is not found in the list"

        Write-Debug "Listing the topics created in the resourceGroup $secondResourceGroup using Top option"
        $allCreatedTopics = Get-AzEventGridSystemTopic -ResourceGroup $secondResourceGroup -Top 1
        Assert-True {$allCreatedTopics.NextLink -ne $null } "NextLink should not be null as more topics should be available under resource group.."

        Write-Debug "Listing the next topics created in the resourceGroup $secondResourceGroup using NextLink"
        $allCreatedTopics = Get-AzEventGridSystemTopic -NextLink $allCreatedTopics.NextLink

        Write-Debug "Getting the first 1 topic created in the subscription using Top options"
        $allCreatedTopics = Get-AzEventGridSystemTopic -Top 1
        Assert-True {$allCreatedTopics.PsSystemTopicsList.Count -ge 0} "SystemTopics created earlier are not found."
        Assert-True {$allCreatedTopics.NextLink -ne $null } "NextLink should not be null as more SystemTopics should be available under the azure subscription."

        Write-Debug "Getting all the SystemTopics created in the subscription"
        $allCreatedTopics = Get-AzEventGridSystemTopic
        Assert-True {$allCreatedTopics.PsSystemTopicsList.Count -ge 0} "Topics created earlier are not found."

        Write-Debug "Deleting topic: $topicName"
        Remove-AzEventGridSystemTopic -ResourceGroup $resourceGroupName -Name $topicName

        Write-Debug "Deleting topic: $topicName"
        Remove-AzEventGridSystemTopic -ResourceGroup $secondResourceGroup -Name $topicName2

        Write-Debug "Deleting topic: $topicName"
        Remove-AzEventGridSystemTopic -ResourceGroup $secondResourceGroup -Name $topicName3

       
    }
    finally
    {
        Remove-AzServiceBusNamespace -ResourceGroup $resourceGroupName -Name $sbNamespaceInRg1
        Remove-AzServiceBusNamespace -ResourceGroup $secondResourceGroup -Name $sbNamespace1InRg2
        Remove-AzServiceBusNamespace -ResourceGroup $secondResourceGroup -Name $sbNamespace2InRg2

        Remove-ResourceGroup $resourceGroupName
        Remove-ResourceGroup $secondResourceGroup
    }
}

