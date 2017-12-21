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
    $location = Get-LocationForEventGrid
    $topicName = Get-TopicName
    $eventSubscriptionName = Get-EventSubscriptionName
    $eventSubscriptionName2 = Get-EventSubscriptionName
    $resourceGroupName = Get-ResourceGroupName

    Write-Debug "Creating resource group"
    Write-Debug "ResourceGroup name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force

    Write-Debug " Creating a new EventGrid Topic: $topicName in resource group $resourceGroupName"
    Write-Debug "Topic: $topicName"
    $result = New-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName -Location $location

    # Assert
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug " Creating a new EventSubscription $eventSubscriptionName to topic $topicName in resource group $resourceGroupName"
    $result = New-AzureRmEventGridSubscription -ResourceGroup $resourceGroupName -TopicName $topicName -Endpoint https://requestb.in/19qlscd1 -EventSubscriptionName $eventSubscriptionName
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug " Creating a new EventSubscription $eventSubscriptionName2 to topic $topicName in resource group $resourceGroupName"
    $result = New-AzureRmEventGridSubscription -ResourceGroup $resourceGroupName -TopicName $topicName -Endpoint https://requestb.in/19qlscd1 -EventSubscriptionName $eventSubscriptionName2
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Getting the created event subscription $eventSubscriptionName"
    $result = Get-AzureRmEventGridSubscription -ResourceGroup $resourceGroupName -TopicName $topicName -EventSubscriptionName $eventSubscriptionName -IncludeFullEndpointUrl
    Assert-True {$result.EventSubscriptionName -eq $eventSubscriptionName}

    Write-Debug "Getting the created event subscription $eventSubscriptionName"
    $result = Get-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -TopicName $topicName | Get-AzureRmEventGridSubscription -EventSubscriptionName $eventSubscriptionName -IncludeFullEndpointUrl
    Assert-True {$result.EventSubscriptionName -eq $eventSubscriptionName}

    Write-Debug "Updating eventSubscription $eventSubscriptionName to topic $topicName in resource group $resourceGroupName"
    $result = Update-AzureRmEventGridSubscription -ResourceGroup $resourceGroupName -TopicName $topicName -Endpoint https://requestb.in/1kxxoui1 -EventSubscriptionName $eventSubscriptionName
    Assert-True {$result.ProvisioningState -eq "Succeeded"}
    $webHookDestination = $result.Destination -as [Microsoft.Azure.Management.EventGrid.Models.WebHookEventSubscriptionDestination]
    Assert-AreEqual $webHookDestination.EndpointBaseUrl "https://requestb.in/1kxxoui1"

    Write-Debug "Listing all the event subscriptions created for $topicName in the resourceGroup $resourceGroup"
    $allCreatedSubscriptions = Get-AzureRmEventGridSubscription -ResourceGroup $resourceGroupName -TopicName $topicName -IncludeFullEndpointUrl
    Assert-True {$allCreatedSubscriptions.Count -eq 2 } "#1. Event Subscriptions created earlier are not found in the list"

    Write-Debug "Listing all the event subscriptions created for $topicName in the resourceGroup $resourceGroup"
    $allCreatedSubscriptions = Get-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -TopicName $topicName | Get-AzureRmEventGridSubscription
    Assert-True {$allCreatedSubscriptions.Count -eq 2 } "Listing all event subscriptions using Input Object: Event Subscriptions created earlier are not found in the list"

    Write-Debug " Deleting event subscription: $eventSubscriptionName"
    Remove-AzureRmEventGridSubscription -ResourceGroup $resourceGroupName -TopicName $topicName -EventSubscriptionName $eventSubscriptionName

    Write-Debug " Deleting event subscription: $eventSubscriptionName2"
    Get-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -TopicName $topicName | Remove-AzureRmEventGridSubscription -EventSubscriptionName $eventSubscriptionName2

    # Verify that all event subscriptions have been deleted correctly
    $returnedES = Get-AzureRmEventGridSubscription -ResourceGroup $resourceGroupName -TopicName $topicName
    Assert-True {$returnedES.Count -eq 0}

    Write-Debug " Deleting resourcegroup $resourceGroupName"
    Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
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

    Write-Debug "Creating resource group"
    Write-Debug "ResourceGroup name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force

    Write-Debug " Creating a new EventGrid Topic: $topicName in resource group $resourceGroupName"
    $result = New-AzureRmEventGridTopic -ResourceGroupName $resourceGroupName -Name $topicName -Location $location
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug " Creating a new EventSubscription $eventSubscriptionName to topic $topicName in resource group $resourceGroupName"
    $result = Get-AzureRmEventGridTopic -ResourceGroupName $resourceGroupName -Name $topicName | New-AzureRmEventGridSubscription -Endpoint https://requestb.in/19qlscd1 -EventSubscriptionName $eventSubscriptionName
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Getting the created event subscription $eventSubscriptionName"
    $result = Get-AzureRmEventGridSubscription -ResourceGroupName $resourceGroupName -TopicName $topicName -EventSubscriptionName $eventSubscriptionName -IncludeFullEndpointUrl
    Assert-True {$result.EventSubscriptionName -eq $eventSubscriptionName}

    Write-Debug "Updating eventSubscription $eventSubscriptionName to topic $topicName in resource group $resourceGroupName"
    $updateResult = $result | Update-AzureRmEventGridSubscription -Endpoint https://requestb.in/1kxxoui1 -SubjectEndsWith "NewSuffix"
    Assert-True {$updateResult.ProvisioningState -eq "Succeeded"}
	$webHookDestination = $updateResult.Destination -as [Microsoft.Azure.Management.EventGrid.Models.WebHookEventSubscriptionDestination]
    Assert-AreEqual $webHookDestination.EndpointBaseUrl "https://requestb.in/1kxxoui1"
    Assert-True {$updateResult.Filter.SubjectEndsWith -eq "NewSuffix"}

    Write-Debug " Deleting event subscription $eventSubscriptionName"
    Get-AzureRmEventGridTopic -ResourceGroupName $resourceGroupName -Name $topicName | Remove-AzureRmEventGridSubscription -EventSubscriptionName $eventSubscriptionName

    Write-Debug " Deleting topic $topicName"
    Remove-AzureRmEventGridTopic -Name $topicName -ResourceGroupName $resourceGroupName

    Write-Debug " Deleting resourcegroup $resourceGroupName"
    Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
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

    Write-Debug "Creating resource group"
    Write-Debug "ResourceGroup name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force

    Write-Debug " Creating a new EventSubscription $eventSubscriptionName to resource group $resourceGroupName"
    $labels = "Finance", "HR"
    $result = New-AzureRmEventGridSubscription -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName"  -Endpoint https://requestb.in/19qlscd1 -EventSubscriptionName $eventSubscriptionName -Label $labels
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug " Creating a new EventSubscription $eventSubscriptionName2 to resource group $resourceGroupName"
    $includedEventTypes = "Microsoft.Resources.ResourceWriteFailure", "Microsoft.Resources.ResourceWriteSuccess"
    $result = New-AzureRmEventGridSubscription -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName" -Endpoint https://requestb.in/19qlscd1 -EventSubscriptionName $eventSubscriptionName2  -IncludedEventType $includedEventTypes
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Getting the created event subscription $eventSubscriptionName"
    $result = Get-AzureRmEventGridSubscription -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName" -EventSubscriptionName $eventSubscriptionName -IncludeFullEndpointUrl
    Assert-True {$result.EventSubscriptionName -eq $eventSubscriptionName}

    Write-Debug "Updating eventSubscription $eventSubscriptionName to resource group $resourceGroupName"
    $newLabels = "Marketing", "Sales"
    $updateResult = Update-AzureRmEventGridSubscription -ResourceGroup $resourceGroupName -EventSubscriptionName $eventSubscriptionName -SubjectEndsWith "NewSuffix" -Label $newLabels
    Assert-True {$updateResult.ProvisioningState -eq "Succeeded"}
    Assert-True {$updateResult.Filter.SubjectEndsWith -eq "NewSuffix"}
	$updatedLabels = $updateResult.Labels
	Assert-AreEqual 2 $updatedLabels.Count;
    Assert-AreEqual "Marketing" $updatedLabels[0];
    Assert-AreEqual "Sales" $updatedLabels[1];

    Write-Debug "Listing all the event subscriptions created for resourceGroup $resourceGroup"
    $allCreatedSubscriptions = Get-AzureRmEventGridSubscription -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName"

    Assert-True {$allCreatedSubscriptions.Count -eq 2 } "#1. Event Subscriptions created earlier are not found in the list"

    Write-Debug "Listing all the event subscriptions created for resourceGroup $resourceGroup"
    $allCreatedSubscriptions = Get-AzureRmEventGridSubscription -ResourceGroupName $resourceGroupName

    Assert-True {$allCreatedSubscriptions.Count -eq 2 } "#2. Event Subscriptions created earlier are not found in the list"

    Write-Debug " Deleting event subscription: $eventSubscriptionName"
    Remove-AzureRmEventGridSubscription -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName" -EventSubscriptionName $eventSubscriptionName

    Write-Debug " Deleting event subscription: $eventSubscriptionName2"
    Remove-AzureRmEventGridSubscription -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName" -EventSubscriptionName $eventSubscriptionName2

    # Verify that all event subscriptions have been deleted correctly
    $returnedES = Get-AzureRmEventGridSubscription -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName"
    Assert-True {$returnedES.Count -eq 0}

    Write-Debug " Deleting resourcegroup $resourceGroupName"
    Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
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

    Write-Debug " Creating a new EventSubscription $eventSubscriptionName to subscription $subscriptionId"
    $result = New-AzureRmEventGridSubscription -ResourceId "/subscriptions/$subscriptionId"  -Endpoint https://requestb.in/19qlscd1 -EventSubscriptionName $eventSubscriptionName
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug " Creating a new EventSubscription $eventSubscriptionName2 to to subscription $subscriptionId"
    $includedEventTypes = "Microsoft.Resources.ResourceWriteFailure", "Microsoft.Resources.ResourceWriteSuccess"
    $result = New-AzureRmEventGridSubscription -ResourceId "/subscriptions/$subscriptionId" -Endpoint https://requestb.in/19qlscd1 -EventSubscriptionName $eventSubscriptionName2 -IncludedEventType $includedEventTypes
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Getting the created event subscription $eventSubscriptionName"
    $result = Get-AzureRmEventGridSubscription -ResourceId "/subscriptions/$subscriptionId" -EventSubscriptionName $eventSubscriptionName -IncludeFullEndpointUrl
    Assert-True {$result.EventSubscriptionName -eq $eventSubscriptionName}

    Write-Debug "Updating eventSubscription $eventSubscriptionName to Azure subscription $subscriptionId"
    $updateResult = Update-AzureRmEventGridSubscription -ResourceId "/subscriptions/$subscriptionId" -EventSubscriptionName $eventSubscriptionName -SubjectEndsWith "NewSuffix" -Endpoint https://requestb.in/1kxxoui1
    Assert-True {$updateResult.ProvisioningState -eq "Succeeded"}
    Assert-True {$updateResult.Filter.SubjectEndsWith -eq "NewSuffix"}
	$webHookDestination = $updateResult.Destination -as [Microsoft.Azure.Management.EventGrid.Models.WebHookEventSubscriptionDestination]
    Assert-AreEqual $webHookDestination.EndpointBaseUrl "https://requestb.in/1kxxoui1"

    Write-Debug "Listing all the event subscriptions created for subscription $subscriptionId"
    $allCreatedEventSubscriptions = Get-AzureRmEventGridSubscription -ResourceId "/subscriptions/$subscriptionId"

    Assert-True {$allCreatedEventSubscriptions.Count -ge 2 } "#1. Event Subscriptions created earlier are not found in the list"

    Write-Debug "Listing all the event subscriptions created for subscription $subscriptionId"
    $allCreatedEventSubscriptions = Get-AzureRmEventGridSubscription
    Assert-True {$allCreatedEventSubscriptions.Count -ge 2 } "#2. Event Subscriptions created earlier are not found in the list"

    Write-Debug " Deleting event subscription: $eventSubscriptionName"
    Remove-AzureRmEventGridSubscription -ResourceId "/subscriptions/$subscriptionId" -EventSubscriptionName $eventSubscriptionName

    Write-Debug " Deleting event subscription: $eventSubscriptionName2"
    Remove-AzureRmEventGridSubscription -ResourceId "/subscriptions/$subscriptionId" -EventSubscriptionName $eventSubscriptionName2
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

    Write-Debug "Creating resource group"
    Write-Debug "ResourceGroup name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force

    Write-Debug "Creating a new EventHub namespace"
    New-AzureRmEventHubNamespace -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -Location $location

    Write-Debug " Creating a new EventSubscription $eventSubscriptionName to EH namespace $namespaceName"
    $result = New-AzureRmEventGridSubscription -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$namespaceName" -Endpoint https://requestb.in/19qlscd1 -EventSubscriptionName $eventSubscriptionName
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug " Creating a new EventSubscription $eventSubscriptionName2 to EH namespace $namespaceName"
    $result = New-AzureRmEventGridSubscription -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$namespaceName" -Endpoint https://requestb.in/19qlscd1 -EventSubscriptionName $eventSubscriptionName2
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Getting the created event subscription $eventSubscriptionName"
    $result = Get-AzureRmEventGridSubscription -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$namespaceName" -EventSubscriptionName $eventSubscriptionName
    Assert-True {$result.EventSubscriptionName -eq $eventSubscriptionName}

    Write-Debug "Updating eventSubscription $eventSubscriptionName to Azure resource $subscriptionId"
    $updateResult = Update-AzureRmEventGridSubscription -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$namespaceName" -EventSubscriptionName $eventSubscriptionName -SubjectEndsWith "NewSuffix" -Endpoint https://requestb.in/1kxxoui1
    Assert-True {$updateResult.ProvisioningState -eq "Succeeded"}
    Assert-True {$updateResult.Filter.SubjectEndsWith -eq "NewSuffix"}
	$webHookDestination = $updateResult.Destination -as [Microsoft.Azure.Management.EventGrid.Models.WebHookEventSubscriptionDestination]
    Assert-AreEqual $webHookDestination.EndpointBaseUrl "https://requestb.in/1kxxoui1"

    Write-Debug "Getting the created event subscription $eventSubscriptionName with full endpoint URL"
    $result = Get-AzureRmEventGridSubscription -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$namespaceName" -EventSubscriptionName $eventSubscriptionName -IncludeFullEndpointUrl
    Assert-True {$result.EventSubscriptionName -eq $eventSubscriptionName}

    Write-Debug "Listing all the event subscriptions created for EH namespace $namespaceName"
    $allCreatedSubscriptions = Get-AzureRmEventGridSubscription -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$namespaceName"

    Assert-True {$allCreatedSubscriptions.Count -eq 2 } "#1. Event Subscriptions created earlier are not found in the list"

    Write-Debug "Listing all the GLOBAL event subscriptions in the subscription for all EventHub namespaces, there should be none"
    $allCreatedSubscriptions = Get-AzureRmEventGridSubscription -TopicTypeName "Microsoft.EventHub.Namespaces"
    Assert-True {$allCreatedSubscriptions.Count -eq 0 } "#2. Unexpected global event subscriptions found for a regional topic type"

    Write-Debug "Listing all the event subscriptions in the subscription for all EventHub namespaces in a particular location"
    $allCreatedSubscriptions = Get-AzureRmEventGridSubscription -TopicTypeName "Microsoft.EventHub.Namespaces" -Location $location
    Assert-True {$allCreatedSubscriptions.Count -ge 1 } "#3. Event Subscriptions created earlier are not found in the list"

    Write-Debug "Listing all the event subscriptions in the subscription in a particular location"
    $allCreatedSubscriptions = Get-AzureRmEventGridSubscription -Location $location
    Assert-True {$allCreatedSubscriptions.Count -ge 1 } "#4. Event Subscriptions created earlier are not found in the list"

    Write-Debug "Listing all the event subscriptions in the Resource Group for all EventHub namespaces"
    $allCreatedSubscriptions = Get-AzureRmEventGridSubscription -TopicTypeName "Microsoft.EventHub.Namespaces" -ResourceGroupName $resourceGroupName
    Assert-True {$allCreatedSubscriptions.Count -eq 0 } "#5. Unexpected global event subscriptions found for a regional topic type"

    Write-Debug "Listing all the event subscriptions in the Resource Group for all EventHub namespaces in a particular location"
    $allCreatedSubscriptions = Get-AzureRmEventGridSubscription -TopicTypeName "Microsoft.EventHub.Namespaces" -Location $location -ResourceGroupName $resourceGroupName
    Assert-True {$allCreatedSubscriptions.Count -ge 1 } "#6. Event Subscriptions created earlier are not found in the list"

    Write-Debug "Listing all the event subscriptions in the Resource Group in a particular location"
    $allCreatedSubscriptions = Get-AzureRmEventGridSubscription -Location $location -ResourceGroupName $resourceGroupName
    Assert-True {$allCreatedSubscriptions.Count -ge 1 } "#7. Event Subscriptions created earlier are not found in the list"

    Write-Debug " Deleting event subscription: $eventSubscriptionName"
    Remove-AzureRmEventGridSubscription -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$namespaceName" -EventSubscriptionName $eventSubscriptionName

    Write-Debug " Deleting event subscription: $eventSubscriptionName2"
    Remove-AzureRmEventGridSubscription -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$namespaceName" -EventSubscriptionName $eventSubscriptionName2

    # Verify that all event subscriptions have been deleted correctly
    $returnedES = Get-AzureRmEventGridSubscription -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventHub/namespaces/$namespaceName"
    Assert-True {$returnedES.Count -eq 0}

    Write-Debug " Deleting resourcegroup $resourceGroupName"
    Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
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

    Write-Debug "Creating resource group"
    Write-Debug "ResourceGroup name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force

    Write-Debug " Creating a new EventSubscription $eventSubscriptionName to resource group $resourceGroupName"
    $labels = "Finance", "HR"
    $result = New-AzureRmEventGridSubscription -ResourceGroupName $resourceGroupName -Endpoint https://requestb.in/19qlscd1 -EventSubscriptionName $eventSubscriptionName -Label $labels
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug " Creating a new EventSubscription $eventSubscriptionName2 to resource group $resourceGroupName"
    $includedEventTypes = "Microsoft.Resources.ResourceWriteFailure", "Microsoft.Resources.ResourceWriteSuccess"
    $result = New-AzureRmEventGridSubscription -ResourceGroup $resourceGroupName -Endpoint https://requestb.in/19qlscd1 -EventSubscriptionName $eventSubscriptionName2  -IncludedEventType $includedEventTypes
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Getting the created event subscription $eventSubscriptionName"
    $result = Get-AzureRmEventGridSubscription -ResourceGroupName $resourceGroupName -EventSubscriptionName $eventSubscriptionName -IncludeFullEndpointUrl
    Assert-True {$result.EventSubscriptionName -eq $eventSubscriptionName}

    Write-Debug "Listing all the event subscriptions created for resourceGroup $resourceGroup"
    $allCreatedSubscriptions = Get-AzureRmEventGridSubscription -ResourceGroupName $resourceGroupName

    Assert-True {$allCreatedSubscriptions.Count -eq 2 } "#1. Event Subscriptions created earlier are not found in the list"

    Write-Debug " Deleting event subscription: $eventSubscriptionName"
    Remove-AzureRmEventGridSubscription -ResourceGroupName $resourceGroupName -EventSubscriptionName $eventSubscriptionName

    Write-Debug " Deleting event subscription: $eventSubscriptionName2"
    Remove-AzureRmEventGridSubscription -ResourceGroupName $resourceGroupName -EventSubscriptionName $eventSubscriptionName2

    # Verify that all event subscriptions have been deleted correctly
    $returnedES = Get-AzureRmEventGridSubscription -ResourceGroupName $resourceGroupName
    Assert-True {$returnedES.Count -eq 0}

    Write-Debug " Deleting resourcegroup $resourceGroupName"
    Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}

<#
.SYNOPSIS
Tests EventGrid EventSubscription CRUD operations for an Azure Subscription, without using the ResourceId parameter set.
#>
function EventSubscriptionTests_Subscription2 {
    # Setup
    $eventSubscriptionName = Get-EventSubscriptionName
    $eventSubscriptionName2 = Get-EventSubscriptionName

    Write-Debug " Creating a new EventSubscription $eventSubscriptionName to Azure subscription"
    $labels = "Finance", "HR"
    $result = New-AzureRmEventGridSubscription -Endpoint https://requestb.in/19qlscd1 -EventSubscriptionName $eventSubscriptionName -Label $labels
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug " Creating a new EventSubscription $eventSubscriptionName2 to Azure subscription"
    $includedEventTypes = "Microsoft.Resources.ResourceWriteFailure", "Microsoft.Resources.ResourceWriteSuccess"
    $result = New-AzureRmEventGridSubscription -Endpoint https://requestb.in/19qlscd1 -EventSubscriptionName $eventSubscriptionName2  -IncludedEventType $includedEventTypes
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Getting the created event subscription $eventSubscriptionName"
    $result = Get-AzureRmEventGridSubscription -EventSubscriptionName $eventSubscriptionName -IncludeFullEndpointUrl
    Assert-True {$result.EventSubscriptionName -eq $eventSubscriptionName}

    Write-Debug "Listing all the event subscriptions created for Azure subscription"
    $allCreatedSubscriptions = Get-AzureRmEventGridSubscription

    Assert-True {$allCreatedSubscriptions.Count -ge 2 } "#1. Event Subscriptions created earlier are not found in the list"

    Write-Debug " Deleting event subscription: $eventSubscriptionName"
    Remove-AzureRmEventGridSubscription -EventSubscriptionName $eventSubscriptionName

    Write-Debug " Deleting event subscription: $eventSubscriptionName2"
    Remove-AzureRmEventGridSubscription -EventSubscriptionName $eventSubscriptionName2
}