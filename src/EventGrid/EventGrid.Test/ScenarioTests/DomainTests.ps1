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
Tests EventGrid Domain Identity
#>
function DomainIdentityTests {
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
        $result = New-AzEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName -Location $location -IdentityType 'SystemAssigned'
        Assert-True {$result.ProvisioningState -eq "Succeeded"}
        Assert-True {$result.Identity.IdentityType -eq "SystemAssigned"}

        Write-Debug "Creating a second EventGrid domain: $domainName2 in resource group $secondResourceGroup with tags and none Identity"
        $result = New-AzEventGridDomain -ResourceGroup $secondResourceGroup -Name $domainName2 -Location $location -Tag @{ Dept = "IT"; Environment = "Test" } -IdentityType 'None'
        Assert-True {$result.ProvisioningState -eq "Succeeded"}
        Assert-True {$result.Identity.IdentityType -eq "None"}

        Write-Debug "Creating a third EventGrid domain: $domainName3 in resource group $secondResourceGroup with user assigned identity"
        $userIdentity = "/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/amh/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testIdentity1"
        $result = New-AzEventGridDomain -ResourceGroup $secondResourceGroup -Name $domainName3 -Location $location -IdentityType 'UserAssigned' -IdentityId $userIdentity
        Assert-True {$result.ProvisioningState -eq "Succeeded"}
        Assert-True {$result.Identity.IdentityType -eq "UserAssigned"} "Domain not created with user identity"

       

        Write-Debug "Deleting domain: $domainName"
        Remove-AzEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName

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
Tests EventGrid Domain Create, Get and List operations with Input mapping
#>
function DomainInputMappingTests {
    # Setup
    $location = Get-LocationForEventGrid
    $domainName = Get-DomainName
    $domainName2 = Get-DomainName
    $domainName3 = Get-DomainName
    $domainName4 = Get-DomainName
    $domainName5 = Get-DomainName
    $domainName6 = Get-DomainName

    $resourceGroupName = Get-ResourceGroupName
    $subscriptionId = Get-SubscriptionId

    $expectedInputMappingEventGridSchema = "EventGridSchema"
    $expectedInputMappingCloudEventSchema = "CloudEventSchemaV1_0"
    $expectedInputMappingCustomEventSchema = "CustomEventSchema"

    $inputSchemaInvalid = "InvalidSchema"
    $inputSchemaEventGridSchema1 = "eventgriDSChemA"
    $inputSchemaEventGridSchema2 = "eventgridschema"
    $inputSchemaCloudEventSchema1 = "CloUDEventScHemaV1_0"
    $inputSchemaCloudEventSchema2 = "ClOudEveNtSCHemav1_0"
    $inputSchemaCustomEventSchema1 = "cUsTomEVeNTSchEma"
    $inputSchemaCustomEventSchema2 = "customeventschema"

    Write-Debug "Creating first resource group"
    Write-Debug "ResourceGroup name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force

    try
    {
        try
        {
            Write-Debug "Creating a new EventGrid Domain: $domainName in resource group $resourceGroupName with InputSchema $inputSchemaInvalid"
            $result = New-AzEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName -Location $location -InputSchema $inputSchemaInvalid
            Assert-True {$false} "New-AzEventGridDomain succeeded while it is expected to fail"
        }
        catch
        {
            Assert-True {$true}
        }

        Write-Debug "Creating a new EventGrid Domain: $domainName in resource group $resourceGroupName with InputSchema $inputSchemaEventGridSchema1"
        $result = New-AzEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName -Location $location -InputSchema $inputSchemaEventGridSchema1
        Assert-True {$result.ProvisioningState -eq "Succeeded"}
        Assert-True {$result.InputSchema -eq $expectedInputMappingEventGridSchema} "EventGridSchema is expected."

        Write-Debug "Getting the created domain within the resource group"
        $createdDomain = Get-AzEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName
        Assert-True {$createdDomain.Count -eq 1}
        Assert-True {$createdDomain.DomainName -eq $domainName} "Domain created earlier is not found."
        Assert-True {$createdDomain.InputSchema -eq $expectedInputMappingEventGridSchema} "InputSchema is not correct. EventGridSchema is expected."

        Write-Debug "Creating a second EventGrid domain: $domainName2 in resource group $resourceGroupName with InputSchema $inputSchemaEventGridSchema2"
        $result = New-AzEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName2 -Location $location -Tag @{ Dept = "IT"; Environment = "Test" } -InputSchema $inputSchemaEventGridSchema2
        Assert-True {$result.ProvisioningState -eq "Succeeded"}
        Assert-True {$result.InputSchema -eq $expectedInputMappingEventGridSchema} "InputSchema is not correct. EventGridSchema is expected"

        Write-Debug "Creating a third EventGrid domain: $domainName3 in resource group $resourceGroupName with InputSchema $inputSchemaCloudEventSchema1"
        $result = New-AzEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName3 -Location $location -InputSchema $inputSchemaCloudEventSchema1
        Assert-True {$result.ProvisioningState -eq "Succeeded"}
        Assert-True {$result.InputSchema -eq $expectedInputMappingCloudEventSchema} "InputSchema is not correct. CloudEventSchema is expected."

        Write-Debug "Creating a fourth EventGrid domain: $domainName4 in resource group $resourceGroupName with InputSchema $inputSchemaCloudEventSchema2"
        $result = New-AzEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName4 -Location $location -InputSchema $inputSchemaCloudEventSchema2
        Assert-True {$result.ProvisioningState -eq "Succeeded"}
        Assert-True {$result.InputSchema -eq $expectedInputMappingCloudEventSchema} "InputSchema is not correct. CloudEventSchema is expected."

        Write-Debug "Getting the created domain within the resource group"
        $createdDomain = Get-AzEventGridDomain -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventGrid/domains/$domainName3"
        Assert-True {$createdDomain.Count -eq 1}
        Assert-True {$createdDomain.DomainName -eq $domainName3} "$domainName3 created earlier is not found."

        Write-Debug "Listing all the domains created in the resourceGroup $resourceGroupName"
        $allCreatedDomains = Get-AzEventGridDomain -ResourceGroup $resourceGroupName
        Assert-True {$allCreatedDomains.PsDomainsList.Count -eq 4 } "Domains created earlier is not found in the list."

        Write-Debug "Getting all the domains created in the subscription"
        $allCreatedDomains = Get-AzEventGridDomain

        Assert-True {$allCreatedDomains.PsDomainsList.Count -ge 0} "Domains created earlier are not found."

        try
        {
            Write-Debug "Creating a fifth EventGrid domain: $domainName5 in resource group $resourceGroupName with InputSchema $inputSchemaEventGridSchema1"
            $result = New-AzEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName5 -Location $location -InputSchema $inputSchemaEventGridSchema1 -InputMappingField @{ id = "MyIdField"; topic = "MyTopicField"; eventtime = "MyEventTimeField"; subject = "MySubjectField"; eventtype = "MyEventTypeField" }
            Assert-True {$false} "New-AzEventGridDomain succeeded while it is expected to fail as inputmapping parameters is not null for input mapping schema EventGridSchema"
        }
        catch
        {
            Assert-True {$true}
        }

        try
        {
            Write-Debug "Creating a fifth EventGrid domain: $domainName5 in resource group $resourceGroupName with InputSchema $inputSchemaCloudEventSchema1"
            $result = New-AzEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName5 -Location $location -InputSchema $inputSchemaCloudEventSchema1 -InputMappingField @{ id = "MyIdField"; topic = "MyTopicField"; eventtime = "MyEventTimeField"; subject = "MySubjectField"; eventtype = "MyEventTypeField" }
            Assert-True {$false} "New-AzEventGridDomain succeeded while it is expected to fail as inputmapping parameters is not null for input mapping schema CloudEventSchema"
        }
        catch
        {
            Assert-True {$true}
        }

        try
        {
            Write-Debug "Creating a fifth EventGrid domain: $domainName5 in resource group $resourceGroupName with InputSchema $inputSchemaCustomEventSchema1"
            $result = New-AzEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName5 -Location $location -InputSchema $inputSchemaCustomEventSchema1
            Assert-True {$false} "New-AzEventGridDomain succeeded while it is expected to fail as inputmapping parameters are null"
        }
        catch
        {
            Assert-True {$true}
        }

        Write-Debug "Creating a fifth EventGrid domain: $domainName5 in resource group $resourceGroupName with InputSchema $inputSchemaCustomEventSchema1"
        $result = New-AzEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName5 -Location $location -InputSchema $inputSchemaCustomEventSchema1 -InputMappingField @{ id = "MyIdField"; topic = "MyTopicField"; eventtime = "MyEventTimeField"; subject = "MySubjectField"; eventtype = "MyEventTypeField"; dataversion = "MyDataVersionField" }
        Assert-True {$result.ProvisioningState -eq "Succeeded"}
        Assert-True {$result.InputSchema -eq $expectedInputMappingCustomEventSchema} "InputSchema is not correct. CustomEventSchema is expected"

        Write-Debug "Creating a sixth EventGrid domain: $domainName6 in resource group $resourceGroupName with InputSchema $inputSchemaCustomEventSchema2"
        $result = New-AzEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName6 -Location $location -InputSchema $inputSchemaCustomEventSchema2 -InputMappingField @{ id = "MyIdField"; topic = "MyTopicField"; eventtime = "MyEventTimeField"; subject = "MySubjectField"; eventtype = "MyEventTypeField"; dataversion = "MyDataVersionField" } -InputMappingDefaultValue @{ subject = "MySubjectDefaultValue"; eventtype = "MyEventTypeDefaultValue"; dataversion = "MyDataVersionDefaultValue" }
        Assert-True {$result.ProvisioningState -eq "Succeeded"}
        Assert-True {$result.InputSchema -eq $expectedInputMappingCustomEventSchema} "InputSchema is not correct. CustomEventSchema is expected"

        Write-Debug "Getting the created domain within the resource group"
        $createdDomain = Get-AzEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName5
        Assert-True {$createdDomain.Count -eq 1}
        Assert-True {$createdDomain.DomainName -eq $domainName5} "Domain created earlier is not found."
        Assert-True {$createdDomain.InputSchema -eq $expectedInputMappingCustomEventSchema} "InputSchema is not correct. CustomEventSchema is expected"

        Write-Debug "Deleting domain: $domainName"
        Remove-AzEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName

        Write-Debug "Deleting domain: $domainName2 using the ResourceID parameter set"
        Remove-AzEventGridDomain -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventGrid/domains/$domainName2"

        Write-Debug "Deleting domain: $domainName3"
        Remove-AzEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName3

        Write-Debug "Deleting domain: $domainName4"
        Remove-AzEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName4

        Write-Debug "Deleting domain: $domainName5"
        Remove-AzEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName5

        Write-Debug "Deleting domain: $domainName6"
        Remove-AzEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName6

        # Verify that all domains have been deleted correctly
        $returnedDomains1 = Get-AzEventGridDomain -ResourceGroup $resourceGroupName
        Assert-True {$returnedDomains1.PsDomainsList.Count -eq 0}

        $returnedDomains2 = Get-AzEventGridDomain -ResourceGroup $resourceGroupName
        Assert-True {$returnedDomains2.PsDomainsList.Count -eq 0}
    }
    finally
    {
        Write-Debug "Deleting resourcegroup $resourceGroupName"
        Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
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
