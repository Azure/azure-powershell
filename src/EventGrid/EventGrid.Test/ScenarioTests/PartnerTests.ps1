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

        Remove-AzEventGridPartnerConfiguration -ResourceGroup $resourceGroupName
        Remove-AzEventGridPartnerRegistration -ResourceGroup $resourceGroupName -Name $partnerRegistrationName
        Remove-AzEventGridPartnerNamespace -ResourceGroup $resourceGroupName -Name $partnerNamespaceName
    }
    finally
    {
        Remove-ResourceGroup $resourceGroupName
    }
}

