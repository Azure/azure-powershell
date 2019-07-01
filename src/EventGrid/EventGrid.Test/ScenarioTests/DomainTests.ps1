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
Tests EventGrid Domain Create, Get and List operations.
#>
function DomainTests {
    # Setup
    $location = Get-LocationForEventGrid
    $domainName = Get-DomainName
    $domainName2 = Get-DomainName
    $domainName3 = Get-DomainName
    $domainName4 = Get-DomainName

    $resourceGroupName = Get-ResourceGroupName
    $secondResourceGroup = Get-ResourceGroupName

    $subscriptionId = Get-SubscriptionId

    New-ResourceGroup $resourceGroupName $location

    New-ResourceGroup $secondResourceGroup $location

    try
    {
        Write-Debug "Creating a new EventGrid domain: $domainName in resource group $resourceGroupName"
        Write-Debug "Domain: $domainName"
        $result = New-AzEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName -Location $location
        Assert-True {$result.ProvisioningState -eq "Succeeded"}

        Write-Debug "Getting the created domain within the resource group"
        $createdDomain = Get-AzEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName
        Assert-True {$createdDomain.Count -eq 1}
        Assert-True {$createdDomain.DomainName -eq $domainName} "Domain created earlier is not found."

        Write-Debug "Creating a second EventGrid domain: $domainName2 in resource group $secondResourceGroup with tags"
        $result = New-AzEventGridDomain -ResourceGroup $secondResourceGroup -Name $domainName2 -Location $location -Tag @{ Dept = "IT"; Environment = "Test" }
        Assert-True {$result.ProvisioningState -eq "Succeeded"}

        Write-Debug "Creating a third EventGrid domain: $domainName3 in resource group $secondResourceGroup"
        $result = New-AzEventGridDomain -ResourceGroup $secondResourceGroup -Name $domainName3 -Location $location
        Assert-True {$result.ProvisioningState -eq "Succeeded"}

        Write-Debug "Getting the created domain using the resourceId"
        $createdDomain = Get-AzEventGridDomain -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$secondResourceGroup/providers/Microsoft.EventGrid/domains/$domainName3"
        Assert-True {$createdDomain.Count -eq 1}
        Assert-True {$createdDomain.DomainName -eq $domainName3} "Domain created earlier is not found."

        Write-Debug "Listing top 1 domain created in the resourceGroup $secondResourceGroup"
        $allCreatedDomains = Get-AzEventGridDomain -ResourceGroup $secondResourceGroup -Top 1
        Assert-True {$allCreatedDomains.PsDomainsList.Count -le 1} "Returned number of domains is greater than top"
        Assert-True {$allCreatedDomains.NextLink -ne $null} "More domains are expected under resource group $secondResourceGroup"

        Write-Debug "Listing next page of domains created in the resourceGroup $secondResourceGroup"
        $allCreatedDomains = Get-AzEventGridDomain -NextLink $allCreatedDomains.NextLink
        Assert-True {$allCreatedDomains.PsDomainsList.Count -le 1} "Returned number of domains is greater than top"

        Write-Debug "Getting all the domains created in the subscription"
        $allCreatedDomains = Get-AzEventGridDomain
        Assert-True {$allCreatedDomains.Count -ge 0} "Domains created earlier are not found."

        Write-Debug "Listing top 1 domain created in Azure Subscription"
        $allCreatedDomains = Get-AzEventGridDomain -Top 1
        # Assert-True {$allCreatedDomains.PsDomainsList.Count -le 1} "Returned number of domains is greater than top"
        Assert-True {$allCreatedDomains.PsDomainsList.Count -gt 0} "Returned number of domains is greater than top"
        Assert-True {$allCreatedDomains.NextLink -ne $null} "More domains are expected under Azure Subscription"

        Write-Debug "Listing next page of domains created in the Azure Subscription"
        $allCreatedDomains = Get-AzEventGridDomain -NextLink $allCreatedDomains.NextLink
        # Assert-True {$allCreatedDomains.PsDomainsList.Count -gt 0} "Returned number of domains is greater than top"
        # Assert-True {$allCreatedDomains.PsDomainsList.Count -le 1} "Returned number of domains is greater than top"

        Write-Debug "Deleting domain: $domainName"
        Remove-AzEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName

        Write-Debug "Creating a new EventGrid domain: $domainName4 in resource group $resourceGroupName"
        $result = New-AzEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName4 -Location $location

        Write-Debug "Deleting domain: $domainName4 using the InputObject parameter set from Get-AzEventGridDomain output"
        Get-AzEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName4 | Remove-AzEventGridDomain

        Write-Debug "Deleting domain: $domainName2 using the ResourceID parameter set"
        Remove-AzEventGridDomain -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$secondResourceGroup/providers/Microsoft.EventGrid/domains/$domainName2"

        Write-Debug "Deleting domain: $domainName3 using the ResourceID parameter"
        Remove-AzEventGridDomain -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$secondResourceGroup/providers/Microsoft.EventGrid/domains/$domainName3"

        # Remove-AzEventGridDomain -ResourceGroup $secondResourceGroup -Name $domainName3

        # Verify that all domains have been deleted correctly
        $returnedDomains1 = Get-AzEventGridDomain -ResourceGroup $resourceGroupName
        Assert-True {$returnedDomains1.PsDomainsList.Count -eq 0}

        $returnedDomains2 = Get-AzEventGridDomain -ResourceGroup $secondResourceGroup
        Assert-True {$returnedDomains2.PsDomainsList.Count -eq 0}
    }
    finally
    {
        Remove-ResourceGroup $resourceGroupName
        Remove-ResourceGroup $secondResourceGroup
    }
}

<#
.SYNOPSIS
Tests EventGrid Domain Key retrieval related operations.
#>
function DomainGetKeyTests {
    # Setup
    $location = Get-LocationForEventGrid
    $domainName = Get-DomainName
    $resourceGroupName = Get-ResourceGroupName
    $subscriptionId = Get-SubscriptionId

    New-ResourceGroup $resourceGroupName $location

    try
    {
        Write-Debug "Creating a new EventGrid Domain: $domainName in resource group $resourceGroupName"
        $result = New-AzEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName -Location $location
        Assert-True {$result.ProvisioningState -eq "Succeeded"}

        # Get the keys of the domain
        $sharedAccessKeys = Get-AzEventGridDomainKey -ResourceGroup $resourceGroupName -Name $domainName
        Assert-True {$sharedAccessKeys.Count -eq 1}

        # Get the keys of the domain using ResourceID parameter set
        $sharedAccessKeys = Get-AzEventGridDomainKey -DomainResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventGrid/domains/$domainName"
        Assert-True {$sharedAccessKeys.Count -eq 1}

        # Get the keys of the domain using the Domain Input object
        $sharedAccessKeys = Get-AzEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName | Get-AzEventGridDomainKey
        Assert-True {$sharedAccessKeys.Count -eq 1}

        Write-Debug "Deleting domain: $domainName"
        Remove-AzEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName
    }
    finally
    {
        Remove-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Tests EventGrid Domain Key regeneration related operations.
#>
function DomainNewKeyTests {
    # Setup
    $location = Get-LocationForEventGrid
    $domainName = Get-DomainName
    $resourceGroupName = Get-ResourceGroupName
    $subscriptionId = Get-SubscriptionId

    New-ResourceGroup $resourceGroupName $location

    try
    {
        Write-Debug "Creating a new EventGrid domain: $domainName in resource group $resourceGroupName"
        $result = New-AzEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName -Location $location
        Assert-True {$result.ProvisioningState -eq "Succeeded"}

        # Regenerate "key1"
        $sharedAccessKeys = New-AzEventGridDomainKey -ResourceGroup $resourceGroupName -DomainName $domainName -KeyName "key1"
        Assert-True {$sharedAccessKeys.Count -eq 1}

        # Regenerate "key2" using the ResourceId parameter set
        $sharedAccessKeys = New-AzEventGridDomainKey -DomainResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventGrid/domains/$domainName" -KeyName "key2"
        Assert-True {$sharedAccessKeys.Count -eq 1}

        # Regenerate "key2" using the Domain Input object
        $sharedAccessKeys = Get-AzEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName | New-AzEventGridDomainKey -KeyName "key2"
        Assert-True {$sharedAccessKeys.Count -eq 1}

        Write-Debug "Deleting domain: $domainName"
        Remove-AzEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName
    }
    finally
    {
        Remove-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Tests EventGrid domain topic Get operations.
#>
function DomainTopicTests {
    # Setup
    $location = Get-LocationForEventGrid
    $domainName = Get-DomainName
    $domainTopicName1 = Get-DomainTopicName
    $domainTopicName2 = Get-DomainTopicName
    $domainTopicName3 = Get-DomainTopicName
    $domainTopicName4 = Get-DomainTopicName

    $resourceGroupName = Get-ResourceGroupName
    $subscriptionId = Get-SubscriptionId
    $eventSubscriptionName = Get-EventSubscriptionName
    $eventSubscriptionEndpoint = Get-EventSubscriptionWebhookEndpoint

    New-ResourceGroup $resourceGroupName $location

    try
    {
        Write-Debug "Creating a new EventGrid domain: $domainName in resource group $resourceGroupName"
        $result = New-AzEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName -Location $location
        Assert-True {$result.ProvisioningState -eq "Succeeded"}

        Write-Debug "Creating a new EventSubscription $eventSubscriptionName to domain topic $domainTopicName1 under domain $domainName in resource group $resourceGroupName"
        $result = New-AzEventGridSubscription -ResourceGroup $resourceGroupName -DomainName $domainName -DomainTopicName $domainTopicName1 -Endpoint $eventSubscriptionEndpoint -EventSubscriptionName $eventSubscriptionName
        Assert-True {$result.ProvisioningState -eq "Succeeded"}

        Write-Debug "Creating a new EventSubscription $eventSubscriptionName to domain topic $domainTopicName2 under domain $domainName in resource group $resourceGroupName"
        $result = New-AzEventGridSubscription -ResourceGroup $resourceGroupName -DomainName $domainName -DomainTopicName $domainTopicName2 -Endpoint $eventSubscriptionEndpoint -EventSubscriptionName $eventSubscriptionName
        Assert-True {$result.ProvisioningState -eq "Succeeded"}

        Write-Debug "Creating a new EventSubscription $eventSubscriptionName to domain topic $domainTopicName3 under domain $domainName in resource group $resourceGroupName"
        $result = New-AzEventGridSubscription -ResourceGroup $resourceGroupName -DomainName $domainName -DomainTopicName $domainTopicName3 -Endpoint $eventSubscriptionEndpoint -EventSubscriptionName $eventSubscriptionName
        Assert-True {$result.ProvisioningState -eq "Succeeded"}

        Write-Debug "Creating a new DomainTopic $domainTopicName4 under domain $domainName in resource group $resourceGroupName"
        $result = New-AzEventGridDomainTopic -ResourceGroup $resourceGroupName -DomainName $domainName -Name $domainTopicName4
        Assert-True {$result.ProvisioningState -eq "Succeeded"}

        Write-Debug "Getting all the created domain topics under domain $domainName using domain name"
        $createdDomainTopics = Get-AzEventGridDomainTopic -ResourceGroup $resourceGroupName -DomainName $domainName
        Assert-True {$createdDomainTopics.PsDomainTopicsList.Count -eq 4}

        $oDataFilter = "Name ne '$domainTopicName4'"
        Write-Debug "Getting first 2 created domain topics under domain $domainName using domain name and Top and oDataQuery"
        $createdDomainTopics2 = Get-AzEventGridDomainTopic -ResourceGroup $resourceGroupName -DomainName $domainName -Top 2 -oDataQuery $oDataFilter
        Assert-True {$createdDomainTopics2.PsDomainTopicsList.Count -le 2}
        Assert-True {$createdDomainTopics2.NextLink -ne $null}

        Write-Debug "Getting remaining 2 created domain topics under domain $domainName using nextLink"
        $createdDomainTopics2 = Get-AzEventGridDomainTopic -NextLink $createdDomainTopics2.NextLink
        Assert-True {$createdDomainTopics2.PsDomainTopicsList.Count -le 2}
        # Assert-True {$createdDomainTopics2.NextLink -eq $null}

        Write-Debug "Getting all the created domain topics under domain $domainName using resourceId"
        $createdDomainTopics3 = Get-AzEventGridDomainTopic -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventGrid/domains/$domainName"
        Assert-True {$createdDomainTopics3.PsDomainTopicsList.Count -eq 4}

        Write-Debug "Getting the created domain topic $domainTopicName1 under domain $domainName using domain and domain topic names"
        $createdDomainTopic4 = Get-AzEventGridDomainTopic -ResourceGroup $resourceGroupName -DomainName $domainName -DomainTopicName $domainTopicName1
        Assert-True {$createdDomainTopic4.Count -eq 1}
        Assert-True {$createdDomainTopic4.DomainTopicName -eq $domainTopicName1} "DomainTopicName for the created domain topic is not correct."

        Write-Debug "Getting the created domain topic $domainTopicName2 under domain $domainName using resourceId"
        $createdDomainTopic5 = Get-AzEventGridDomainTopic -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventGrid/domains/$domainName/topics/$domainTopicName2"
        Assert-True {$createdDomainTopic5.Count -eq 1}
        Assert-True {$createdDomainTopic5.DomainTopicName -eq $domainTopicName2} "DomainTopicName for the created domain topic is not correct."

        Write-Debug "Deleting the created EventSubscription $eventSubscriptionName to domain topic $domainTopicName3 under domain $domainName in resource group $resourceGroupName"
        $result = Remove-AzEventGridSubscription -EventSubscriptionName $eventSubscriptionName -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventGrid/domains/$domainName/topics/$domainTopicName3"

        try
        {
            Write-Debug "Checking if the domain topic $domainTopicName3 under domain $domainName is removed too."
            $checkDomainTopic5 = Get-AzEventGridDomainTopic -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventGrid/domains/$domainName/topics/$domainTopicName3"
            Assert-True {$false} "Get-AzEventGridDomainTopic succeeded while it is expected to fail as domain topic $domainTopicName3 should be auto-deleted already."
        }
        catch
        {
            Assert-True {$true}
        }

        Write-Debug "Deleting DomainTopic $domainTopicName1 under domain $domainName in resource group $resourceGroupName using resource Name"
        $result = Remove-AzEventGridDomainTopic -ResourceGroupName $resourceGroupName -DomainName $domainName -Name $domainTopicName1

        Write-Debug "Deleting DomainTopic $domainTopicName2 under domain $domainName in resource group $resourceGroupName using resourceId"
        $result = Remove-AzEventGridDomainTopic -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventGrid/domains/$domainName/topics/$domainTopicName2"

        Write-Debug "Deleting domain: $domainName"
        Remove-AzEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName
    }
    finally
    {
        Remove-ResourceGroup $resourceGroupName
    }
}
