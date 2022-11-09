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
function PartnerTests {
    # Setup
    $partnerRegistrationName = Get-PartnerRegistrationName
    $partnerNamespaceName = Get-PartnerNamespaceName
    $channelName = Get-ChannelName
    $partnerTopicName = Get-PartnerTopicName
    $defaultMaxExpirationTimeInDays = 5
    $updatedMaxExpirationTimeInDays = 15

    $location = Get-LocationForEventGrid
    $eventSubscriptionName = Get-EventSubscriptionName
    $eventSubscriptionName2 = Get-EventSubscriptionName
    $eventSubscriptionName3 = Get-EventSubscriptionName
    $resourceGroupName = Get-ResourceGroupName
    $secondResourceGroup = Get-ResourceGroupName
    $subscriptionId = Get-SubscriptionId
    $source = Get-PartnerTopicSource

    New-ResourceGroup $resourceGroupName $location

    New-ResourceGroup $secondResourceGroup $location

    $eventSubscriptionStorageDestinationResourceId = Get-EventSubscriptionStorageQueueEndpoint

    try
    {
        Write-Debug "Creating a new EventGrid PartnerRegistration: $partnerRegistrationName in resource group $resourceGroupName"
        $result = New-AzEventGridPartnerRegistration -ResourceGroup $resourceGroupName -Name $partnerRegistrationName
        Assert-True {$result.ProvisioningState -eq "Succeeded"}

        Write-Debug "Getting the new EventGrid PartnerRegistration: $partnerRegistrationName in $resourceGroupName"
        $createdPartnerRegistration = Get-AzEventGridPartnerRegistration -ResourceGroup $resourceGroupName -Name $partnerRegistrationName
        Assert-True {$createdPartnerRegistration.Count -eq 1}
        Assert-True {$createdPartnerRegistration.PartnerRegistrationName -eq $partnerRegistrationName} "Partner registration created earlier is not found"

        Write-Debug "Getting EventGrid PartnerRegistrations within the subscription"
        $allCreatedPartnerRegistrations = Get-AzEventGridPartnerRegistration
        $countOfPR = $allCreatedPartnerRegistrations.PsPartnerRegistrationsList.Count
        Write-Debug "PsPartnerRegistrationsList count: $countOfPR"
        Assert-True {$createdPartnerRegistration.PsPartnerRegistrationsList.Count -ge 0}

        Write-Debug "Getting EventGrid PartnerRegistrations within the resource group"
        $allCreatedPartnerRegistrations = Get-AzEventGridPartnerRegistration -ResourceGroup $resourceGroupName
        $countOfPR = $allCreatedPartnerRegistrations.PsPartnerRegistrationsList.Count
        Write-Debug "PsPartnerRegistrationsList count: $countOfPR"
        Assert-True {$createdPartnerRegistration.Count -eq 1}
        $partnerRegistrationImmutableId = $createdPartnerRegistration.PartnerRegistrationImmutableId
        $partnerRegistrationFullyQualifiedId = $createdPartnerRegistration.Id

        Write-Debug "Creating a new EventGrid PartnerNamespace: $partnerNamespaceName in resource group $resourceGroupName"
        $createdPartnerNamespace = New-AzEventGridPartnerNamespace -ResourceGroup $resourceGroupName -Name $partnerNamespaceName -Location $location -PartnerRegistrationFullyQualifiedId $partnerRegistrationFullyQualifiedId -PartnerTopicRoutingMode "ChannelNameHeader"
        Assert-True {$createdPartnerNamespace.Count -eq 1}
        Assert-True {$createdPartnerNamespace.ProvisioningState -eq "Succeeded"}

        Write-Debug "Getting the new EventGrid PartnerNamespace"
        $createdPartnerNamespace = Get-AzEventGridPartnerNamespace -ResourceGroup $resourceGroupName -Name $partnerNamespaceName
        Assert-True {$createdPartnerNamespace.Count -eq 1}
        Assert-True {$createdPartnerNamespace.PartnerNamespaceName -eq $partnerNamespaceName} "Partner namespace created earlier is not found"

        Write-Debug "Getting EventGrid PartnerNamespaces within the subscription"
        $allCreatedPartnerNamespaces = Get-AzEventGridPartnerNamespace
        Assert-True {$allCreatedPartnerNamespaces.PsPartnerNamespacesList.Count -ge 0}

        Write-Debug "Getting EventGrid PartnerNamespaces within the resource group $resourceGroupName"
        $allCreatedPartnerNamespaces = Get-AzEventGridPartnerNamespace -ResourceGroup $resourceGroupName
        Assert-True {$allCreatedPartnerNamespaces.Count -ge 1}

        Write-Debug "Getting EventGrid PartnerNamespace Keys"
        $keys = Get-AzEventGridPartnerNamespaceKey -ResourceGroup $resourceGroupName -PartnerNamespaceName $partnerNamespaceName
        Assert-True {$keys.Key1 -ne ""}
        Assert-True {$keys.Key2 -ne ""}

        Write-Debug "Regenerating EventGrid PartnerNamespace Keys"
        $keys = New-AzEventGridPartnerNamespaceKey -ResourceGroup $resourceGroupName -PartnerNamespaceName $partnerNamespaceName -Name "key1"
        Assert-True {$keys.Key1 -ne ""}
        Assert-True {$keys.Key2 -ne ""}
        $keys = New-AzEventGridPartnerNamespaceKey -ResourceGroup $resourceGroupName -PartnerNamespaceName $partnerNamespaceName -Name "key2"
        Assert-True {$keys.Key1 -ne ""}
        Assert-True {$keys.Key2 -ne ""}

        Write-Debug "Creating EventGrid PartnerConfiguration in resource group $resourceGroupName"
        $authorizedPartner = @{"partnerRegistrationImmutableId"=$partnerRegistrationImmutableId; "authorizationExpirationTimeInUtc"=(Get-Date).AddDays(8)}
        $authorizedPartners = @($authorizedPartner)
        $createdPartnerConfiguration = New-AzEventGridPartnerConfiguration -ResourceGroup $resourceGroupName -AuthorizedPartner $authorizedPartners -MaxExpirationTimeInDays 15
        Assert-True {$createdPartnerConfiguration.Count -eq 1}
        Assert-True {$createdPartnerConfiguration.ProvisioningState -eq "Succeeded"}

        Write-Debug "Authorizing the EventGrid PartnerConfiguration"
        $result = Grant-AzEventGridPartnerConfiguration -ResourceGroup $resourceGroupName -PartnerRegistrationImmutableId $partnerRegistrationImmutableId
        Assert-True {$result.ProvisioningState -eq "Succeeded"}

        Write-Debug "Getting the new EventGrid PartnerConfiguration"
        $createdPartnerConfiguration = Get-AzEventGridPartnerConfiguration -ResourceGroup $resourceGroupName
        Assert-True {$createdPartnerConfiguration.PartnerAuthorization.DefaultMaximumExpirationTimeInDays -eq 15}
        Assert-True {$createdPartnerConfiguration.PartnerAuthorization.AuthorizedPartnersList[0].PartnerRegistrationImmutableId -eq $partnerRegistrationImmutableId}

        Write-Debug "Getting EventGrid PartnerConfigurations within the subscription"
        $allPartnerConfigurations = Get-AzEventGridPartnerConfiguration
        $countOfPc = $allPartnerConfigurations.PsPartnerConfigurationsList.Count
        $partnerConfigurationsType = $allPartnerConfigurations.GetType()
        Write-Debug "PsPartnerCnfigurationsList count: $countOfPc, type: $partnerConfigurationsType"
        Assert-True {$allPartnerConfigurations.PsPartnerConfigurationsList.Count -ge 0}

        Write-Debug "Unauthorizing the EventGrid PartnerConfiguration"
        $result = Revoke-AzEventGridPartnerConfiguration -ResourceGroup $resourceGroupName -PartnerRegistrationImmutableId $partnerRegistrationImmutableId
        Assert-True {$result.ProvisioningState -eq "Succeeded"}

        Write-Debug "Authorizing the EventGrid PartnerConfiguration"
        $result = Grant-AzEventGridPartnerConfiguration -ResourceGroup $resourceGroupName -PartnerRegistrationImmutableId $partnerRegistrationImmutableId
        Assert-True {$result.ProvisioningState -eq "Succeeded"}

        Write-Debug "Creating EventGrid Channel: $channelName in resource group $resourceGroupName"
        $createdChannel = New-AzEventGridChannel -ResourceGroup $resourceGroupName -PartnerNamespaceName $partnerNamespaceName -Name $channelName -ChannelType "partnerTopic" -PartnerTopicName $partnerTopicName -PartnerTopicSource $source
        Assert-True {$createdChannel.ProvisioningState -eq "Succeeded"}

        Write-Debug "Getting EventGrid Channel $channelName"
        $createdChannel = Get-AzEventGridChannel -ResourceGroup $resourceGroupName -PartnerNamespaceName $partnerNamespaceName -Name $channelName
        Assert-True {$createdChannel.Name -eq $channelName}

        Write-Debug "Getting EventGrid Channels within the partner namespace"
        $allCreatedChannels = Get-AzEventGridChannel -ResourceGroup $resourceGroupName -PartnerNamespaceName $partnerNamespaceName
        Assert-True {$allCreatedChannels.PsChannelsList.Count -eq 1}

        Write-Debug "Getting PartnerTopic: $partnerTopicName in resource group $resourceGroupName"
        $createdPartnerTopic = Get-AzEventGridPartnerTopic -ResourceGroup $resourceGroupName -Name $partnerTopicName
        Assert-True {$createdPartnerTopic.ProvisioningState -eq "Succeeded"}
        Assert-True {$createdPartnerTopic.Name -eq $partnerTopicName}

        Write-Debug "Getting all PartnerTopics in ResourceGroup"
        $allPartnerTopics = Get-AzEventGridPartnerTopic -ResourceGroup $resourceGroupName
        $partnerTopicsType = $allPartnerTopics.GetType()
        Write-Debug "PartnerTopicsList type: $partnerTopicsType"
        Assert-True {$allPartnerTopics.PsPartnerTopicsList.Count -eq 1}

        Write-Debug "Getting all PartnerTopics in the subscription"
        $allPartnerTopics = Get-AzEventGridPartnerTopic -ResourceGroup $resourceGroupName
        Assert-True {$allPartnerTopics.PsPartnerTopicsList.Count -ge 1}

        Write-Debug "Activating the PartnerTopic"
        $result = Enable-AzEventGridPartnerTopic -ResourceGroup $resourceGroupName -Name $partnerTopicName
        Assert-True {$result.ActivationState -eq "Activated"}
        Assert-True {$result.PartnerRegistrationImmutableId -eq $partnerRegistrationImmutableId}

        #Write-Debug "Updating PartnerTopic $partnerTopicName"
        #$createdPartnerTopic = Update-AzEventGridPartnerTopic -ResourceGroup $resourceGroupName -Name $partnerTopicName -Tag @{ "Dept"="IT"; "Environment"="Test" }

        Write-Debug "Creating PartnerTopic EventSubscription $eventSubscriptionName under partner topic $partnerTopicName"
        $createdEventSub = New-AzEventGridPartnerTopicEventSubscription -ResourceGroup $resourceGroupName -PartnerTopicName $partnerTopicName -Name $eventSubscriptionName -EndpointType "storagequeue" -Endpoint $eventSubscriptionStorageDestinationResourceId
        Assert-True {$createdEventSub.ProvisioningState -eq "Succeeded"}

        Write-Debug "Get EventSubscription created for partner topic $partnerTopicName"
        $createdEventSub = Get-AzEventGridPartnerTopicEventSubscription -ResourceGroup $resourceGroupName -PartnerTopicName $partnerTopicName -Name $eventSubscriptionName
        Assert-True {$createdEventSub.EventSubscriptionName -eq $eventSubscriptionName}

        Write-Debug "Creating 2nd EventSubscription $eventSubscriptionName2 to topic $partnerTopicName in resource group $resourceGroupName"
        $result = New-AzEventGridPartnerTopicEventSubscription -ResourceGroup $resourceGroupName -PartnerTopicName $partnerTopicName -EndpointType "storagequeue" -Endpoint $eventSubscriptionStorageDestinationResourceId -EventSubscriptionName $eventSubscriptionName2
        Assert-True {$result.ProvisioningState -eq "Succeeded"}

        Write-Debug "Get event subscription created for partner topic: $partnerTopicName"
        $createdEventSubscription2 = Get-AzEventGridPartnerTopicEventSubscription -ResourceGroup $resourceGroupName -PartnerTopicName $partnerTopicName
        Assert-True {$createdEventSubscription2.Count -ge 0} "Event subscription created earlier is not found in the list"

        Write-Debug "Get event subscription created for partner topic: $partnerTopicName"
        $createdEventSubscription = Get-AzEventGridPartnerTopicEventSubscription -ResourceGroup $resourceGroupName -PartnerTopicName $partnerTopicName -Top 1
        Assert-True {$createdEventSubscription.NextLink -ne $null } "NextLink should not be null as more event subscription should be available under partner topic"

        Write-Debug "Get event subscription created for partner topic: $partnerTopicName with nextlink"
        $createdEventSubscription = Get-AzEventGridPartnerTopicEventSubscription -ResourceGroup $resourceGroupName -PartnerTopicName $partnerTopicName -NextLink $createdEventSubscription.NextLink
        Assert-True {$createdEventSubscription -ne $null } "Event subscription should not be null as more event subscription should be available under partner topic"

        $labels = "Finance", "HR"
        Write-Debug "Updating a EventGrid PartnerTopic Eventsubscription with TopicName: $partnerTopicName in resource group $resourceGroupName and EventSubscriptionName: $eventSubscriptionName"
        $result = Update-AzEventGridPartnerTopicEventSubscription -EventSubscriptionName $eventSubscriptionName -ResourceGroup $resourceGroupName -PartnerTopicName $partnerTopicName -Label $labels
        Assert-True {$result.ProvisioningState -eq "Succeeded"}
        $updatedLabels = $result.Labels
        Assert-AreEqual 2 $updatedLabels.Count;
        Assert-AreEqual "Finance" $updatedLabels[0];
        Assert-AreEqual "HR" $updatedLabels[1];

        #Write-Debug "Get Delivery attributes for partner topic: $partnerTopicName and Eventsubscription $eventSubscriptionName"
        #$createdEventSubscriptionDa = Get-AzEventGridPartnerTopicEventSubscriptionDeliveryAttribute -ResourceGroup $resourceGroupName -PartnerTopicName $partnerTopicName -EventSubscriptionName $eventSubscriptionName

        #Write-Debug "Get full url for partner topic: $partnerTopicName and Eventsubscription $eventSubscriptionName"
        #$createdEventSubscriptionDa = Get-AzEventGridFullUrlForPartnerTopicEventSubscription -ResourceGroup $resourceGroupName -PartnerTopicName $partnerTopicName -EventSubscriptionName $eventSubscriptionName

        Write-Debug "Deleting event subscription :  $eventSubscriptionName for partner topic : $partnerTopicName"
        Remove-AzEventGridPartnerTopicEventSubscription -ResourceGroup $resourceGroupName -PartnerTopicName $partnerTopicName -EventSubscriptionName $eventSubscriptionName -Force

        Write-Debug "Deleting event subscription :  $eventSubscriptionName for partner topic : $partnerTopicName"
        Remove-AzEventGridPartnerTopicEventSubscription -ResourceGroup $resourceGroupName -PartnerTopicName $partnerTopicName -EventSubscriptionName $eventSubscriptionName2 -Force

        $verifiedPartners = Get-AzEventGridVerifiedPartner

        Remove-AzEventGridPartnerTopic -ResourceGroup $resourceGroupName -Name $partnerTopicName -Force
        Remove-AzEventGridChannel -ResourceGroup $resourceGroupName -PartnerNamespaceName $partnerNamespaceName -Name $channelName -Force
        Remove-AzEventGridPartnerConfiguration -ResourceGroup $resourceGroupName -Force
        Remove-AzEventGridPartnerRegistration -ResourceGroup $resourceGroupName -Name $partnerRegistrationName -Force
        Remove-AzEventGridPartnerNamespace -ResourceGroup $resourceGroupName -Name $partnerNamespaceName -Force
    }
    finally
    {
        Remove-ResourceGroup $resourceGroupName
        Remove-ResourceGroup $secondResourceGroup
    }
}

