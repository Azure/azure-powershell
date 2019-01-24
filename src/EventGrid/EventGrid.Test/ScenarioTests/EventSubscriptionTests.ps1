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
Tests EventGrid EventSubscription CRUD operations for Custom Topic.
#>
function EventSubscriptionTests_CustomTopic {
    # Setup
    $subscriptionId = Get-SubscriptionId
    $location = Get-LocationForEventGrid
    $topicName = Get-TopicName
    $eventSubscriptionName = Get-EventSubscriptionName
    $eventSubscriptionName2 = Get-EventSubscriptionName
    $eventSubscriptionName3 = Get-EventSubscriptionName
    $resourceGroupName = Get-ResourceGroupName

    Write-Debug "Creating resource group"
    Write-Debug "ResourceGroup name : $resourceGroupName"
    New-AzResourceGroup -Name $resourceGroupName -Location $location -Force

    Write-Debug "Creating a new EventGrid Topic: $topicName in resource group $resourceGroupName"
    Write-Debug "Topic: $topicName"
    $result = New-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName -Location $location
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    $eventSubscriptionEndpoint = Get-EventSubscriptionWebhookEndpoint
    $eventSubscriptionBaseEndpoint = Get-EventSubscriptionWebhookBaseEndpoint

    Write-Debug "Creating a new EventSubscription $eventSubscriptionName to topic $topicName in resource group $resourceGroupName"
    $result = New-AzEventGridSubscription -ResourceGroup $resourceGroupName -TopicName $topicName -Endpoint $eventSubscriptionEndpoint -EventSubscriptionName $eventSubscriptionName
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Creating a new EventSubscription $eventSubscriptionName2 to topic $topicName in resource group $resourceGroupName"
    $result = New-AzEventGridSubscription -ResourceGroup $resourceGroupName -TopicName $topicName -Endpoint $eventSubscriptionEndpoint -EventSubscriptionName $eventSubscriptionName2
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    try
    {
        Write-Debug "Creating a new EventSubscription $eventSubscriptionName3 to topic $topicName in resource group $resourceGroupName"
        $result = New-AzEventGridSubscription -ResourceGroup $resourceGroupName -TopicName $topicName -Endpoint $eventSubscriptionEndpoint -EventSubscriptionName $eventSubscriptionName3 -EventTtl 21300
        Assert-True {$false} "New-AzEventGridSubscription succeeded while it is expected to fail as EventTtl range is invalid"
    }
    catch
    {
        Assert-True {$true}
    }

    try
    {
        Write-Debug "Creating a new EventSubscription $eventSubscriptionName3 to topic $topicName in resource group $resourceGroupName"
        $result = New-AzEventGridSubscription -ResourceGroup $resourceGroupName -TopicName $topicName -Endpoint $eventSubscriptionEndpoint -EventSubscriptionName $eventSubscriptionName3 -MaxDeliveryAttempt 300
        Assert-True {$false} "New-AzEventGridSubscription succeeded while it is expected to fail as MaxDeliveryAttempt range is invalid"
    }
    catch
    {
        Assert-True {$true}
    }

    Write-Debug "Creating a new EventSubscription $eventSubscriptionName to topic $topicName in resource group $resourceGroupName"
    $result = New-AzEventGridSubscription -ResourceGroup $resourceGroupName -TopicName $topicName -Endpoint $eventSubscriptionEndpoint -EventSubscriptionName $eventSubscriptionName3 -EventTtl 50 -MaxDeliveryAttempt 20
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Getting the created event subscription $eventSubscriptionName3"
    $result = Get-AzEventGridSubscription -ResourceGroup $resourceGroupName -TopicName $topicName -EventSubscriptionName $eventSubscriptionName3 -IncludeFullEndpointUrl
    Assert-True {$result.EventSubscriptionName -eq $eventSubscriptionName3}
    Assert-True {$result.EventTtl -eq 50}
    Assert-True {$result.MaxDeliveryAttempt -eq 20}

    Write-Debug "Getting the created event subscription $eventSubscriptionName"
    $result = Get-AzEventGridSubscription -ResourceGroup $resourceGroupName -TopicName $topicName -EventSubscriptionName $eventSubscriptionName -IncludeFullEndpointUrl
    Assert-True {$result.EventSubscriptionName -eq $eventSubscriptionName}

    Write-Debug "Getting the created event subscription $eventSubscriptionName"
    $result = Get-AzEventGridTopic -ResourceGroup $resourceGroupName -TopicName $topicName | Get-AzEventGridSubscription -EventSubscriptionName $eventSubscriptionName -IncludeFullEndpointUrl
    Assert-True {$result.EventSubscriptionName -eq $eventSubscriptionName}

    Write-Debug "Updating eventSubscription $eventSubscriptionName to topic $topicName in resource group $resourceGroupName"
    $result = Update-AzEventGridSubscription -ResourceGroup $resourceGroupName -TopicName $topicName -Endpoint $eventSubscriptionEndpoint -EventSubscriptionName $eventSubscriptionName
    Assert-True {$result.ProvisioningState -eq "Succeeded"}
    $webHookDestination = $result.Destination -as [Microsoft.Azure.Management.EventGrid.Models.WebHookEventSubscriptionDestination]
    Assert-AreEqual $webHookDestination.EndpointBaseUrl $eventSubscriptionBaseEndpoint

    ## Comment this step until we fix a bug in service side where we force default value for DeliverySchema and fail the operation since we don't allow different values.
    #Write-Debug "Updating eventSubscription $eventSubscriptionName3 to topic $topicName in resource group $resourceGroupName"
    #$result = Update-AzEventGridSubscription -ResourceGroup $resourceGroupName -TopicName $topicName -Endpoint $eventSubscriptionEndpoint -EventSubscriptionName $eventSubscriptionName3 -EventTtl 40 -MaxDeliveryAttempt 10
    #Assert-True {$result.ProvisioningState -eq "Succeeded"}
    #$webHookDestination = $result.Destination -as [Microsoft.Azure.Management.EventGrid.Models.WebHookEventSubscriptionDestination]
    #Assert-AreEqual $webHookDestination.EndpointBaseUrl $eventSubscriptionBaseEndpoint
    #Assert-True {$result.EventTtl -eq 40}
    #Assert-True {$result.MaxDeliveryAttempt -eq 10}

    Write-Debug "Updating eventSubscription $eventSubscriptionName2 to topic $topicName in resource group $resourceGroupName"
    $result = Update-AzEventGridSubscription -ResourceGroup $resourceGroupName -TopicName $topicName -Endpoint $eventSubscriptionEndpoint -EventSubscriptionName $eventSubscriptionName2 -EventTtl 10 -MaxDeliveryAttempt 20
    Assert-True {$result.ProvisioningState -eq "Succeeded"}
    $webHookDestination = $result.Destination -as [Microsoft.Azure.Management.EventGrid.Models.WebHookEventSubscriptionDestination]
    Assert-AreEqual $webHookDestination.EndpointBaseUrl $eventSubscriptionBaseEndpoint
    Assert-True {$result.EventTtl -eq 10}
    Assert-True {$result.MaxDeliveryAttempt -eq 20}

    Write-Debug "Listing all the event subscriptions created for $topicName in the resourceGroup $resourceGroup"
    $allCreatedSubscriptions = Get-AzEventGridSubscription -ResourceGroup $resourceGroupName -TopicName $topicName -IncludeFullEndpointUrl
    Assert-True {$allCreatedSubscriptions.Count -eq 3 } "#1. Event Subscriptions created earlier are not found in the list"

    Write-Debug "Listing all the event subscriptions created for $topicName in the resourceGroup $resourceGroup"
    $allCreatedSubscriptions = Get-AzEventGridTopic -ResourceGroup $resourceGroupName -TopicName $topicName | Get-AzEventGridSubscription
    Assert-True {$allCreatedSubscriptions.Count -eq 3 } "Listing all event subscriptions using Input Object: Event Subscriptions created earlier are not found in the list"

    Write-Debug "Deleting event subscription: $eventSubscriptionName"
    Remove-AzEventGridSubscription -ResourceGroup $resourceGroupName -TopicName $topicName -EventSubscriptionName $eventSubscriptionName

    Write-Debug "Deleting event subscription: $eventSubscriptionName2"
    Get-AzEventGridTopic -ResourceGroup $resourceGroupName -TopicName $topicName | Remove-AzEventGridSubscription -EventSubscriptionName $eventSubscriptionName2

    Write-Debug "Deleting event subscription: $eventSubscriptionName3"
    Get-AzEventGridTopic -ResourceGroup $resourceGroupName -TopicName $topicName | Remove-AzEventGridSubscription -EventSubscriptionName $eventSubscriptionName3

    # Verify that all event subscriptions have been deleted correctly
    $returnedES = Get-AzEventGridSubscription -ResourceGroup $resourceGroupName -TopicName $topicName
    Assert-True {$returnedES.Count -eq 0}

    Write-Debug "Deleting resourcegroup $resourceGroupName"
    Remove-AzResourceGroup -Name $resourceGroupName -Force
}

<#
.SYNOPSIS
Tests EventGrid EventSubscription CRUD operations for Custom Topic using InputObject
#>
function EventSubscriptionTests_CustomTopic2 {
    # Setup
    $location = Get-LocationForEventGrid
    $topicName = Get-TopicName
    $eventSubscriptionName = Get-EventSubscriptionName
    $resourceGroupName = Get-ResourceGroupName
    $eventSubscriptionEndpoint = Get-EventSubscriptionWebhookEndpoint
    $eventSubscriptionBaseEndpoint = Get-EventSubscriptionWebhookBaseEndpoint

    Write-Host "Creating resource group"
    Write-Host "ResourceGroup name : $resourceGroupName"
    New-AzResourceGroup -Name $resourceGroupName -Location $location -Force

    Write-Host "Creating a new EventGrid Topic: $topicName in resource group $resourceGroupName"
    $result = New-AzEventGridTopic -ResourceGroupName $resourceGroupName -Name $topicName -Location $location
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Creating a new EventSubscription $eventSubscriptionName to topic $topicName in resource group $resourceGroupName"
    $result = Get-AzEventGridTopic -ResourceGroupName $resourceGroupName -Name $topicName | New-AzEventGridSubscription -Endpoint $eventSubscriptionEndpoint -EventSubscriptionName $eventSubscriptionName
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Getting the created event subscription $eventSubscriptionName"
    $result = Get-AzEventGridSubscription -ResourceGroupName $resourceGroupName -TopicName $topicName -EventSubscriptionName $eventSubscriptionName -IncludeFullEndpointUrl
    Assert-True {$result.EventSubscriptionName -eq $eventSubscriptionName}

    Write-Debug "Updating eventSubscription $eventSubscriptionName to topic $topicName in resource group $resourceGroupName"
    $updateResult = $result | Update-AzEventGridSubscription -Endpoint $eventSubscriptionEndpoint -SubjectEndsWith "NewSuffix"
    Assert-True {$updateResult.ProvisioningState -eq "Succeeded"}
    $webHookDestination = $updateResult.Destination -as [Microsoft.Azure.Management.EventGrid.Models.WebHookEventSubscriptionDestination]
    Assert-AreEqual $webHookDestination.EndpointBaseUrl $eventSubscriptionBaseEndpoint
    Assert-True {$updateResult.Filter.SubjectEndsWith -eq "NewSuffix"}

    Write-Debug "Deleting event subscription $eventSubscriptionName"
    Get-AzEventGridTopic -ResourceGroupName $resourceGroupName -Name $topicName | Remove-AzEventGridSubscription -EventSubscriptionName $eventSubscriptionName

    Write-Debug "Deleting topic $topicName"
    Remove-AzEventGridTopic -Name $topicName -ResourceGroupName $resourceGroupName

    Write-Debug "Deleting resourcegroup $resourceGroupName"
    Remove-AzResourceGroup -Name $resourceGroupName -Force
}

<#
.SYNOPSIS
Tests EventGrid EventSubscription CRUD operations for Resource Group.
#>
function EventSubscriptionTests_ResourceGroup {
    # Setup
    $subscriptionId = Get-SubscriptionId
    $location = Get-LocationForEventGrid
    $eventSubscriptionName = Get-EventSubscriptionName
    $eventSubscriptionName2 = Get-EventSubscriptionName
    $resourceGroupName = Get-ResourceGroupName
    $eventSubscriptionEndpoint = Get-EventSubscriptionWebhookEndpoint

    Write-Debug "Creating resource group"
    Write-Debug "ResourceGroup name : $resourceGroupName"
    New-AzResourceGroup -Name $resourceGroupName -Location $location -Force

    Write-Debug "Creating a new EventSubscription $eventSubscriptionName to resource group $resourceGroupName"
    $labels = "Finance", "HR"
    $result = New-AzEventGridSubscription -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName" -Endpoint $eventSubscriptionEndpoint -EventSubscriptionName $eventSubscriptionName -Label $labels
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Creating a new EventSubscription $eventSubscriptionName2 to resource group $resourceGroupName"
    $includedEventTypes = "Microsoft.Resources.ResourceWriteFailure", "Microsoft.Resources.ResourceWriteSuccess"
    $result = New-AzEventGridSubscription -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName" -Endpoint $eventSubscriptionEndpoint -EventSubscriptionName $eventSubscriptionName2 -IncludedEventType $includedEventTypes
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Getting the created event subscription $eventSubscriptionName"
    $result = Get-AzEventGridSubscription -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName" -EventSubscriptionName $eventSubscriptionName -IncludeFullEndpointUrl
    Assert-True {$result.EventSubscriptionName -eq $eventSubscriptionName}

    Write-Debug "Updating eventSubscription $eventSubscriptionName to resource group $resourceGroupName"
    $newLabels = "Marketing", "Sales"
    $updateResult = Update-AzEventGridSubscription -ResourceGroup $resourceGroupName -EventSubscriptionName $eventSubscriptionName -SubjectEndsWith "NewSuffix" -Label $newLabels
    Assert-True {$updateResult.ProvisioningState -eq "Succeeded"}
    Assert-True {$updateResult.Filter.SubjectEndsWith -eq "NewSuffix"}
    $updatedLabels = $updateResult.Labels
    Assert-AreEqual 2 $updatedLabels.Count;
    Assert-AreEqual "Marketing" $updatedLabels[0];
    Assert-AreEqual "Sales" $updatedLabels[1];

    Write-Debug "Listing all the event subscriptions created for resourceGroup $resourceGroup"
    $allCreatedSubscriptions = Get-AzEventGridSubscription -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName"

    Assert-True {$allCreatedSubscriptions.Count -eq 2 } "#1. Event Subscriptions created earlier are not found in the list"

    Write-Debug "Listing all the event subscriptions created for resourceGroup $resourceGroup"
    $allCreatedSubscriptions = Get-AzEventGridSubscription -ResourceGroupName $resourceGroupName

    Assert-True {$allCreatedSubscriptions.Count -eq 2 } "#2. Event Subscriptions created earlier are not found in the list"

    Write-Debug "Deleting event subscription: $eventSubscriptionName"
    Remove-AzEventGridSubscription -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName" -EventSubscriptionName $eventSubscriptionName

    Write-Debug "Deleting event subscription: $eventSubscriptionName2"
    Remove-AzEventGridSubscription -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName" -EventSubscriptionName $eventSubscriptionName2

    # Verify that all event subscriptions have been deleted correctly
    $returnedES = Get-AzEventGridSubscription -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName"
    Assert-True {$returnedES.Count -eq 0}

    Write-Debug "Deleting resourcegroup $resourceGroupName"
    Remove-AzResourceGroup -Name $resourceGroupName -Force
}

<#
.SYNOPSIS
Tests EventGrid EventSubscription CRUD operations for an Azure Subscription.
#>
function EventSubscriptionTests_Subscription {
    # Setup
    $subscriptionId = Get-SubscriptionId
    $eventSubscriptionName = Get-EventSubscriptionName
    $eventSubscriptionName2 = Get-EventSubscriptionName
    $eventSubscriptionName3 = Get-EventSubscriptionName
    $eventSubscriptionEndpoint = Get-EventSubscriptionWebhookEndpoint
    $eventSubscriptionBaseEndpoint = Get-EventSubscriptionWebhookBaseEndpoint
    $eventSubscriptionStorageDestinationResourceId = Get-StorageDestinationResourceId
    $eventSubscriptionHybridConnectionResourceId = Get-HybridConnectionResourceId

    Write-Debug "Creating a new EventSubscription $eventSubscriptionName to subscription $subscriptionId using webhook as a destination"
    $result = New-AzEventGridSubscription -ResourceId "/subscriptions/$subscriptionId" -Endpoint $eventSubscriptionEndpoint -EventSubscriptionName $eventSubscriptionName
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Creating a new EventSubscription $eventSubscriptionName2 to subscription $subscriptionId using storage queue as a destination"
    $includedEventTypes = "Microsoft.Resources.ResourceWriteFailure", "Microsoft.Resources.ResourceWriteSuccess"
    $result = New-AzEventGridSubscription -ResourceId "/subscriptions/$subscriptionId" -Endpoint $eventSubscriptionStorageDestinationResourceId -EndpointType "SToRageQUEue" -EventSubscriptionName $eventSubscriptionName2 -IncludedEventType $includedEventTypes
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Creating a new EventSubscription $eventSubscriptionName3 to subscription $subscriptionId using hybrid connections as a destination"
    $includedEventTypes = "Microsoft.Resources.ResourceWriteFailure", "Microsoft.Resources.ResourceWriteSuccess"
    $result = New-AzEventGridSubscription -ResourceId "/subscriptions/$subscriptionId" -Endpoint $eventSubscriptionHybridConnectionResourceId -EndpointType "hYbridConNECtIon" -EventSubscriptionName $eventSubscriptionName3 -IncludedEventType $includedEventTypes
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Getting the created event subscription $eventSubscriptionName"
    $result = Get-AzEventGridSubscription -ResourceId "/subscriptions/$subscriptionId" -EventSubscriptionName $eventSubscriptionName -IncludeFullEndpointUrl
    Assert-True {$result.EventSubscriptionName -eq $eventSubscriptionName}

    Write-Debug "Updating eventSubscription $eventSubscriptionName to Azure subscription $subscriptionId"
    $updateResult = Update-AzEventGridSubscription -ResourceId "/subscriptions/$subscriptionId" -EventSubscriptionName $eventSubscriptionName -SubjectEndsWith "NewSuffix" -Endpoint $eventSubscriptionEndpoint
    Assert-True {$updateResult.ProvisioningState -eq "Succeeded"}
    Assert-True {$updateResult.Filter.SubjectEndsWith -eq "NewSuffix"}
    $webHookDestination = $updateResult.Destination -as [Microsoft.Azure.Management.EventGrid.Models.WebHookEventSubscriptionDestination]
    Assert-AreEqual $webHookDestination.EndpointBaseUrl $eventSubscriptionBaseEndpoint

    Write-Debug "Listing all the event subscriptions created for subscription $subscriptionId"
    $allCreatedEventSubscriptions = Get-AzEventGridSubscription -ResourceId "/subscriptions/$subscriptionId"

    Assert-True {$allCreatedEventSubscriptions.Count -ge 3 } "#1. Event Subscriptions created earlier are not found in the list"

    Write-Debug "Listing all the event subscriptions created for subscription $subscriptionId"
    $allCreatedEventSubscriptions = Get-AzEventGridSubscription
    Assert-True {$allCreatedEventSubscriptions.Count -ge 3 } "#2. Event Subscriptions created earlier are not found in the list"

    Write-Debug "Deleting event subscription: $eventSubscriptionName"
    Remove-AzEventGridSubscription -ResourceId "/subscriptions/$subscriptionId" -EventSubscriptionName $eventSubscriptionName

    Write-Debug "Deleting event subscription: $eventSubscriptionName2"
    Remove-AzEventGridSubscription -ResourceId "/subscriptions/$subscriptionId" -EventSubscriptionName $eventSubscriptionName2

    Write-Debug "Deleting event subscription: $eventSubscriptionName3"
    Remove-AzEventGridSubscription -ResourceId "/subscriptions/$subscriptionId" -EventSubscriptionName $eventSubscriptionName2
}

<#
.SYNOPSIS
Tests EventGrid EventSubscription CRUD operations for a resource.
#>
function EventSubscriptionTests_Resource {
    # Setup
    $subscriptionId = Get-SubscriptionId
    $location = Get-LocationForEventGrid
    $namespaceName = Get-EventHubNamespaceName
    $eventSubscriptionName = Get-EventSubscriptionName
    $eventSubscriptionName2 = Get-EventSubscriptionName
    $resourceGroupName = Get-ResourceGroupName
    $eventSubscriptionEndpoint = Get-EventSubscriptionWebhookEndpoint
    $eventSubscriptionBaseEndpoint = Get-EventSubscriptionWebhookBaseEndpoint

    Write-Debug "Creating resource group"
    Write-Debug "ResourceGroup name : $resourceGroupName"
    New-AzResourceGroup -Name $resourceGroupName -Location $location -Force

    Write-Debug "Creating a new EventHub namespace"
    New-AzEventHubNamespace -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -Location $location

    Write-Debug "Creating a new EventSubscription $eventSubscriptionName to EH namespace $namespaceName"
    $result = New-AzEventGridSubscription -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$namespaceName" -Endpoint $eventSubscriptionEndpoint -EventSubscriptionName $eventSubscriptionName
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Creating a new EventSubscription $eventSubscriptionName2 to EH namespace $namespaceName"
    $result = New-AzEventGridSubscription -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$namespaceName" -Endpoint $eventSubscriptionEndpoint -EventSubscriptionName $eventSubscriptionName2
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Getting the created event subscription $eventSubscriptionName"
    $result = Get-AzEventGridSubscription -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$namespaceName" -EventSubscriptionName $eventSubscriptionName
    Assert-True {$result.EventSubscriptionName -eq $eventSubscriptionName}

    Write-Debug "Updating eventSubscription $eventSubscriptionName to Azure resource $subscriptionId"
    $updateResult = Update-AzEventGridSubscription -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$namespaceName" -EventSubscriptionName $eventSubscriptionName -SubjectEndsWith "NewSuffix" -Endpoint $eventSubscriptionEndpoint
    Assert-True {$updateResult.ProvisioningState -eq "Succeeded"}
    Assert-True {$updateResult.Filter.SubjectEndsWith -eq "NewSuffix"}
    $webHookDestination = $updateResult.Destination -as [Microsoft.Azure.Management.EventGrid.Models.WebHookEventSubscriptionDestination]
    Assert-AreEqual $webHookDestination.EndpointBaseUrl $eventSubscriptionBaseEndpoint

    Write-Debug "Getting the created event subscription $eventSubscriptionName with full endpoint URL"
    $result = Get-AzEventGridSubscription -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$namespaceName" -EventSubscriptionName $eventSubscriptionName -IncludeFullEndpointUrl
    Assert-True {$result.EventSubscriptionName -eq $eventSubscriptionName}

    Write-Debug "Listing all the event subscriptions created for EH namespace $namespaceName"
    $allCreatedSubscriptions = Get-AzEventGridSubscription -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$namespaceName"

    Assert-True {$allCreatedSubscriptions.Count -eq 2 } "#1. Event Subscriptions created earlier are not found in the list"

    Write-Debug "Listing all the GLOBAL event subscriptions in the subscription for all EventHub namespaces, there should be none"
    $allCreatedSubscriptions = Get-AzEventGridSubscription -TopicTypeName "Microsoft.EventHub.Namespaces"
    Assert-True {$allCreatedSubscriptions.Count -eq 0 } "#2. Unexpected global event subscriptions found for a regional topic type"

    Write-Debug "Listing all the event subscriptions in the subscription for all EventHub namespaces in a particular location"
    $allCreatedSubscriptions = Get-AzEventGridSubscription -TopicTypeName "Microsoft.EventHub.Namespaces" -Location $location
    Assert-True {$allCreatedSubscriptions.Count -ge 1 } "#3. Event Subscriptions created earlier are not found in the list"

    Write-Debug "Listing all the event subscriptions in the subscription in a particular location"
    $allCreatedSubscriptions = Get-AzEventGridSubscription -Location $location
    Assert-True {$allCreatedSubscriptions.Count -ge 1 } "#4. Event Subscriptions created earlier are not found in the list"

    Write-Debug "Listing all the event subscriptions in the Resource Group for all EventHub namespaces"
    $allCreatedSubscriptions = Get-AzEventGridSubscription -TopicTypeName "Microsoft.EventHub.Namespaces" -ResourceGroupName $resourceGroupName
    Assert-True {$allCreatedSubscriptions.Count -eq 0 } "#5. Unexpected global event subscriptions found for a regional topic type"

    Write-Debug "Listing all the event subscriptions in the Resource Group for all EventHub namespaces in a particular location"
    $allCreatedSubscriptions = Get-AzEventGridSubscription -TopicTypeName "Microsoft.EventHub.Namespaces" -Location $location -ResourceGroupName $resourceGroupName
    Assert-True {$allCreatedSubscriptions.Count -ge 1 } "#6. Event Subscriptions created earlier are not found in the list"

    Write-Debug "Listing all the event subscriptions in the Resource Group in a particular location"
    $allCreatedSubscriptions = Get-AzEventGridSubscription -Location $location -ResourceGroupName $resourceGroupName
    Assert-True {$allCreatedSubscriptions.Count -ge 1 } "#7. Event Subscriptions created earlier are not found in the list"

    Write-Debug "Deleting event subscription: $eventSubscriptionName"
    Remove-AzEventGridSubscription -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$namespaceName" -EventSubscriptionName $eventSubscriptionName

    Write-Debug "Deleting event subscription: $eventSubscriptionName2"
    Remove-AzEventGridSubscription -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$namespaceName" -EventSubscriptionName $eventSubscriptionName2

    # Verify that all event subscriptions have been deleted correctly
    $returnedES = Get-AzEventGridSubscription -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$namespaceName"
    Assert-True {$returnedES.Count -eq 0}

    Write-Debug "Deleting resourcegroup $resourceGroupName"
    Remove-AzResourceGroup -Name $resourceGroupName -Force
}

<#
.SYNOPSIS
Tests EventGrid EventSubscription CRUD operations for Resource Group, without using the ResourceId parameter set.
#>
function EventSubscriptionTests_ResourceGroup2 {
    # Setup
    $location = Get-LocationForEventGrid
    $eventSubscriptionName = Get-EventSubscriptionName
    $eventSubscriptionName2 = Get-EventSubscriptionName
    $resourceGroupName = Get-ResourceGroupName
    $eventSubscriptionEndpoint = Get-EventSubscriptionWebhookEndpoint

    Write-Debug "Creating resource group"
    Write-Debug "ResourceGroup name : $resourceGroupName"
    New-AzResourceGroup -Name $resourceGroupName -Location $location -Force

    Write-Debug "Creating a new EventSubscription $eventSubscriptionName to resource group $resourceGroupName"
    $labels = "Finance", "HR"
    $result = New-AzEventGridSubscription -ResourceGroupName $resourceGroupName -Endpoint $eventSubscriptionEndpoint -EventSubscriptionName $eventSubscriptionName -Label $labels
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Creating a new EventSubscription $eventSubscriptionName2 to resource group $resourceGroupName"
    $includedEventTypes = "Microsoft.Resources.ResourceWriteFailure", "Microsoft.Resources.ResourceWriteSuccess"
    $result = New-AzEventGridSubscription -ResourceGroup $resourceGroupName -Endpoint $eventSubscriptionEndpoint -EventSubscriptionName $eventSubscriptionName2 -IncludedEventType $includedEventTypes
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Getting the created event subscription $eventSubscriptionName"
    $result = Get-AzEventGridSubscription -ResourceGroupName $resourceGroupName -EventSubscriptionName $eventSubscriptionName -IncludeFullEndpointUrl
    Assert-True {$result.EventSubscriptionName -eq $eventSubscriptionName}

    Write-Debug "Listing all the event subscriptions created for resourceGroup $resourceGroup"
    $allCreatedSubscriptions = Get-AzEventGridSubscription -ResourceGroupName $resourceGroupName

    Assert-True {$allCreatedSubscriptions.Count -eq 2 } "#1. Event Subscriptions created earlier are not found in the list"

    Write-Debug "Deleting event subscription: $eventSubscriptionName"
    Remove-AzEventGridSubscription -ResourceGroupName $resourceGroupName -EventSubscriptionName $eventSubscriptionName

    Write-Debug "Deleting event subscription: $eventSubscriptionName2"
    Remove-AzEventGridSubscription -ResourceGroupName $resourceGroupName -EventSubscriptionName $eventSubscriptionName2

    # Verify that all event subscriptions have been deleted correctly
    $returnedES = Get-AzEventGridSubscription -ResourceGroupName $resourceGroupName
    Assert-True {$returnedES.Count -eq 0}

    Write-Debug "Deleting resourcegroup $resourceGroupName"
    Remove-AzResourceGroup -Name $resourceGroupName -Force
}

<#
.SYNOPSIS
Tests EventGrid EventSubscription CRUD operations for an Azure Subscription, without using the ResourceId parameter set.
#>
function EventSubscriptionTests_Subscription2 {
    # Setup
    $eventSubscriptionName = Get-EventSubscriptionName
    $eventSubscriptionName2 = Get-EventSubscriptionName
    $eventSubscriptionEndpoint = Get-EventSubscriptionWebhookEndpoint

    Write-Debug "Creating a new EventSubscription $eventSubscriptionName to Azure subscription"
    $labels = "Finance", "HR"
    $result = New-AzEventGridSubscription -Endpoint $eventSubscriptionEndpoint -EventSubscriptionName $eventSubscriptionName -Label $labels
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Creating a new EventSubscription $eventSubscriptionName2 to Azure subscription"
    $includedEventTypes = "Microsoft.Resources.ResourceWriteFailure", "Microsoft.Resources.ResourceWriteSuccess"
    $result = New-AzEventGridSubscription -Endpoint $eventSubscriptionEndpoint -EventSubscriptionName $eventSubscriptionName2 -IncludedEventType $includedEventTypes
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Getting the created event subscription $eventSubscriptionName"
    $result = Get-AzEventGridSubscription -EventSubscriptionName $eventSubscriptionName -IncludeFullEndpointUrl
    Assert-True {$result.EventSubscriptionName -eq $eventSubscriptionName}

    Write-Debug "Listing all the event subscriptions created for Azure subscription"
    $allCreatedSubscriptions = Get-AzEventGridSubscription

    Assert-True {$allCreatedSubscriptions.Count -ge 2 } "#1. Event Subscriptions created earlier are not found in the list"

    Write-Debug "Deleting event subscription: $eventSubscriptionName"
    Remove-AzEventGridSubscription -EventSubscriptionName $eventSubscriptionName

    Write-Debug "Deleting event subscription: $eventSubscriptionName2"
    Remove-AzEventGridSubscription -EventSubscriptionName $eventSubscriptionName2
}

<#
.SYNOPSIS
Tests EventGrid EventSubscription with deadletter destination
#>
function EventSubscriptionTests_Deadletter {
    # Setup
    $location = Get-LocationForEventGrid
    $topicName = Get-TopicName
    $subscriptionId = Get-SubscriptionId
    $eventSubscriptionName = Get-EventSubscriptionName
    $resourceGroupName = Get-ResourceGroupName
    $deadletterResourceId = Get-DeadletterResourceId
    $eventSubscriptionEndpoint = Get-EventSubscriptionWebhookEndpoint
    $eventSubscriptionEndpoint = Get-EventSubscriptionWebhookEndpoint

    Write-Host "Creating resource group"
    Write-Host "ResourceGroup name : $resourceGroupName"
    New-AzResourceGroup -Name $resourceGroupName -Location $location -Force

    # Custom topic operations
    Write-Host "Creating a new EventGrid Topic: $topicName in resource group $resourceGroupName"
    $result = New-AzEventGridTopic -ResourceGroupName $resourceGroupName -Name $topicName -Location $location
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Creating a new EventSubscription $eventSubscriptionName to topic $topicName in resource group $resourceGroupName"
    $result = Get-AzEventGridTopic -ResourceGroupName $resourceGroupName -Name $topicName | New-AzEventGridSubscription -Endpoint $eventSubscriptionEndpoint -EventSubscriptionName $eventSubscriptionName -DeadLetterEndpoint $deadletterResourceId
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Getting the created event subscription $eventSubscriptionName"
    $result = Get-AzEventGridSubscription -ResourceGroupName $resourceGroupName -TopicName $topicName -EventSubscriptionName $eventSubscriptionName -IncludeFullEndpointUrl
    Assert-True {$result.EventSubscriptionName -eq $eventSubscriptionName}

    Write-Debug "Deleting event subscription $eventSubscriptionName for custom topic $topicName"
    Get-AzEventGridTopic -ResourceGroupName $resourceGroupName -Name $topicName | Remove-AzEventGridSubscription -EventSubscriptionName $eventSubscriptionName

    Write-Debug "Deleting topic $topicName"
    Remove-AzEventGridTopic -Name $topicName -ResourceGroupName $resourceGroupName
}