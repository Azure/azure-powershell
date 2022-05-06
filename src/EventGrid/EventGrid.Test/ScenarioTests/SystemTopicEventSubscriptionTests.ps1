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
function SystemTopicEventSubscriptionTests {
    # Setup
    $location = Get-LocationForEventGrid
    $topicName = Get-TopicName
    $topicName2 = Get-TopicName
    $topicName3 = Get-TopicName
    $topicName4 = Get-TopicName
    $eventSubscriptionName = Get-EventSubscriptionName
    $eventSubscriptionName2 = Get-EventSubscriptionName
    $eventSubscriptionName3 = Get-EventSubscriptionName
    $resourceGroupName = Get-ResourceGroupName
    $secondResourceGroup = Get-ResourceGroupName
    $subscriptionId = Get-SubscriptionId

    New-ResourceGroup $resourceGroupName $location

    New-ResourceGroup $secondResourceGroup $location

    $eventSubscriptionEndpoint = Get-EventSubscriptionWebhookEndpoint
    $eventSubscriptionEndpointCloudEvent = Get-EventSubscriptionWebhookEndpointWithCloudEvent

    $storageAccountName = Get-StorageAccountName
    $storageContainerName = Get-StorageBlobName

    New-StorageBlob $resourceGroupName $storageAccountName $storageContainerName $location
    $storageAccountResourceId = Get-StorageAccountResourceId $resourceGroupName $storageAccountName
    try
    {
        Write-Debug "Creating a new EventGrid SystemTopic: $topicName in resource group $resourceGroupName"
        Write-Debug "Topic: $topicName"
        $result = New-AzEventGridSystemTopic -ResourceGroup $resourceGroupName -Name $topicName -Source $storageAccountResourceId -TopicType 'microsoft.storage.storageaccounts' -Location $location
        Assert-True {$result.ProvisioningState -eq "Succeeded"}

        Write-Debug "Getting the created topic within the resource group"
        $createdTopic = Get-AzEventGridSystemTopic -ResourceGroup $resourceGroupName -Name $topicName
        Assert-True {$createdTopic.Count -eq 1}
        Assert-True {$createdTopic.TopicName -eq $topicName} "System Topic created earlier is not found."

        #Write-Debug "Creating a second EventGrid SystemTopic: $topicName2 in resource group $secondResourceGroup"
        #$result = New-AzEventGridSystemTopic -ResourceGroup $secondResourceGroup -Name $topicName2 -Source $sbNamespace1InRg2.Id -TopicType 'Microsoft.ServiceBus.Namespaces' -Location $location -Tag @{ Dept = "IT"; Environment = "Test" } 
        #Assert-True {$result.ProvisioningState -eq "Succeeded"}

        Write-Debug "Creating a new EventSubscription $eventSubscriptionName to topic $topicName in resource group $resourceGroupName"
        $result = New-AzEventGridSystemTopicEventSubscription -ResourceGroup $resourceGroupName -SystemTopicName $topicName -Endpoint $eventSubscriptionEndpoint -EventSubscriptionName $eventSubscriptionName
        Assert-True {$result.ProvisioningState -eq "Succeeded"}

        Write-Debug "Get event subscription created for system topic :  $topicName"
        $createdEventSubscription = Get-AzEventGridSystemTopicEventSubscription -ResourceGroup $resourceGroupName -SystemTopicName $topicName -EventSubscriptionName $eventSubscriptionName
        Assert-True {$createdEventSubscription.EventSubscriptionName -eq $eventSubscriptionName} "Event subscription created earlier is not found in the list"

        Write-Debug "Creating 2nd EventSubscription $eventSubscriptionName2 to topic $topicName in resource group $resourceGroupName"
        $result = New-AzEventGridSystemTopicEventSubscription -ResourceGroup $resourceGroupName -SystemTopicName $topicName -Endpoint $eventSubscriptionEndpoint -EventSubscriptionName $eventSubscriptionName2
        Assert-True {$result.ProvisioningState -eq "Succeeded"}

        Write-Debug "Get event subscription created for system topic :  $topicName"
        $createdEventSubscription2 = Get-AzEventGridSystemTopicEventSubscription -ResourceGroup $resourceGroupName -SystemTopicName $topicName
        Assert-True {$createdEventSubscription2.Count -ge 0} "Event subscription created earlier is not found in the list"

        Write-Debug "Get event subscription created for system topic :  $topicName"
        $createdEventSubscription = Get-AzEventGridSystemTopicEventSubscription -ResourceGroup $resourceGroupName -SystemTopicName $topicName -Top 1
        Assert-True {$createdEventSubscription.NextLink -ne $null } "NextLink should not be null as more event subscription should be available under system topic"

        Write-Debug "Get event subscription created for system topic :  $topicName with nextlink"
        $createdEventSubscription = Get-AzEventGridSystemTopicEventSubscription -ResourceGroup $resourceGroupName -SystemTopicName $topicName -NextLink $createdEventSubscription.NextLink
        Assert-True {$createdEventSubscription -ne $null } "Event subscription should not be null as more event subscription should be available under system topic"

        $labels = "Finance", "HR"
        Write-Debug "Updating a EventGrid SystemTopic Eventsubscription with TopicName: $topicName in resource group $resourceGroupName and EventSubscriptionName: $eventSubscriptionName"
        $result = Update-AzEventGridSystemTopicEventSubscription -EventSubscriptionName $eventSubscriptionName -ResourceGroup $resourceGroupName -SystemTopicName $topicName -Label $labels
        Assert-True {$result.ProvisioningState -eq "Succeeded"}
        $updatedLabels = $result.Labels
        Assert-AreEqual 2 $updatedLabels.Count;
        Assert-AreEqual "Finance" $updatedLabels[0];
        Assert-AreEqual "HR" $updatedLabels[1];

        Write-Debug "Get Delivery attributes for  topic:  $topicName and Eventsubscription $eventSubscriptionName"
        $createdEventSubscriptionDa = Get-AzEventGridSystemTopicEventSubscriptionDeliveryAttribute -ResourceGroup $resourceGroupName -SystemTopicName $topicName -EventSubscriptionName $eventSubscriptionName

        Write-Debug "Get full url for  topic:  $topicName and Eventsubscription $eventSubscriptionName"
        $createdEventSubscriptionDa = Get-AzEventGridFullUrlForSystemTopicEventSubscription -ResourceGroup $resourceGroupName -SystemTopicName $topicName -EventSubscriptionName $eventSubscriptionName




        Write-Debug "Deleting event subscription :  $eventSubscriptionName for system topic : $topicName"
        Remove-AzEventGridSystemTopicEventSubscription -ResourceGroup $resourceGroupName -SystemTopicName $topicName -EventSubscriptionName $eventSubscriptionName -Force

        Write-Debug "Deleting event subscription :  $eventSubscriptionName for system topic : $topicName"
        Remove-AzEventGridSystemTopicEventSubscription -ResourceGroup $resourceGroupName -SystemTopicName $topicName -EventSubscriptionName $eventSubscriptionName2 -Force


        Write-Debug "Deleting topic: $topicName"
        Remove-AzEventGridSystemTopic -ResourceGroup $resourceGroupName -Name $topicName -Force

        #Write-Debug "Deleting topic: $topicName"
        #Remove-AzEventGridSystemTopic -ResourceGroup $secondResourceGroup -Name $topicName2

       
    }
    finally
    {
        Remove-StorageContainerResources $resourceGroupName $storageAccountName $storageContainerName

        Remove-ResourceGroup $resourceGroupName
        Remove-ResourceGroup $secondResourceGroup
    }
}

