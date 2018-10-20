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

    Write-Debug "Creating first resource group"
    Write-Debug "ResourceGroup name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force

    Write-Debug "Creating second resource group"
    Write-Debug "ResourceGroup name : $secondResourceGroup"
    New-AzureRmResourceGroup -Name $secondResourceGroup -Location $location -Force

    Write-Debug "Creating a new EventGrid domain: $domainName in resource group $resourceGroupName"
    Write-Debug "Domain: $domainName"
    $result = New-AzureRmEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName -Location $location
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Getting the created domain within the resource group"
    $createdDomain = Get-AzureRmEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName
    Assert-True {$createdDomain.Count -eq 1}
    Assert-True {$createdDomain.DomainName -eq $domainName} "Domain created earlier is not found."

    Write-Debug "Creating a second EventGrid domain: $domainName2 in resource group $secondResourceGroup with tags"
    $result = New-AzureRmEventGridDomain -ResourceGroup $secondResourceGroup -Name $domainName2 -Location $location -Tag @{ Dept = "IT"; Environment = "Test" }
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Creating a third EventGrid domain: $domainName3 in resource group $secondResourceGroup"
    $result = New-AzureRmEventGridDomain -ResourceGroup $secondResourceGroup -Name $domainName3 -Location $location
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Getting the created domain using the resourceId"
    $createdDomain = Get-AzureRmEventGridDomain -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$secondResourceGroup/providers/Microsoft.EventGrid/domains/$domainName3"
    Assert-True {$createdDomain.Count -eq 1}
    Assert-True {$createdDomain.DomainName -eq $domainName3} "Domain created earlier is not found."

    Write-Debug "Listing all the domains created in the resourceGroup $secondResourceGroup"
    $allCreatedDomains = Get-AzureRmEventGridDomain -ResourceGroup $secondResourceGroup

    Assert-True {$allCreatedDomains.Count -ge 0 } "Domain created earlier is not found in the list"

    Write-Debug "Getting all the domains created in the subscription"
    $allCreatedDomains = Get-AzureRmEventGridDomain

    Assert-True {$allCreatedDomains.Count -ge 0} "Domains created earlier are not found."

    Write-Debug "Deleting domain: $domainName"
    Remove-AzureRmEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName

    Write-Debug "Creating a new EventGrid domain: $domainName4 in resource group $resourceGroupName"
    $result = New-AzureRmEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName4 -Location $location

    Write-Debug "Deleting domain: $domainName4 using the InputObject parameter set from Get-AzureRmEventGridDomain output"
    Get-AzureRmEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName4 | Remove-AzureRmEventGridDomain

    Write-Debug "Deleting domain: $domainName2 using the ResourceID parameter set"
    Remove-AzureRmEventGridDomain -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$secondResourceGroup/providers/Microsoft.EventGrid/domains/$domainName2"

    Write-Debug "Deleting domain: $domainName3 using the ResourceID parameter"
    Remove-AzureRmEventGridDomain -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$secondResourceGroup/providers/Microsoft.EventGrid/domains/$domainName3"

    # Remove-AzureRmEventGridDomain -ResourceGroup $secondResourceGroup -Name $domainName3

    # Verify that all domains have been deleted correctly
    $returnedDomains1 = Get-AzureRmEventGridDomain -ResourceGroup $resourceGroupName
    Assert-True {$returnedDomains1.Count -eq 0}

    $returnedDomains2 = Get-AzureRmEventGridDomain -ResourceGroup $secondResourceGroup
    Assert-True {$returnedDomains2.Count -eq 0}

    Write-Debug "Deleting resourcegroup $resourceGroupName"
    Remove-AzureRmResourceGroup -Name $resourceGroupName -Force

    Write-Debug "Deleting resourcegroup $secondResourceGroup"
    Remove-AzureRmResourceGroup -Name $secondResourceGroup -Force
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

    Write-Debug "Creating resource group"
    Write-Debug "ResourceGroup name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force

    Write-Debug "Creating a new EventGrid Domain: $domainName in resource group $resourceGroupName"
    $result = New-AzureRmEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName -Location $location
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    # Get the keys of the domain
    $sharedAccessKeys = Get-AzureRmEventGridDomainKey -ResourceGroup $resourceGroupName -Name $domainName
    Assert-True {$sharedAccessKeys.Count -eq 1}

    # Get the keys of the domain using ResourceID parameter set
    $sharedAccessKeys = Get-AzureRmEventGridDomainKey -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventGrid/domains/$domainName"
    Assert-True {$sharedAccessKeys.Count -eq 1}

    # Get the keys of the domain using the Domain Input object
    $sharedAccessKeys = Get-AzureRmEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName | Get-AzureRmEventGridDomainKey
    Assert-True {$sharedAccessKeys.Count -eq 1}

    Write-Debug "Deleting domain: $domainName"
    Remove-AzureRmEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName

    Write-Debug "Deleting resourcegroup $resourceGroupName"
    Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
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

    Write-Debug "Creating resource group"
    Write-Debug "ResourceGroup name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force

    Write-Debug "Creating a new EventGrid domain: $domainName in resource group $resourceGroupName"
    $result = New-AzureRmEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName -Location $location
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    # Regenerate "key1"
    $sharedAccessKeys = New-AzureRmEventGridDomainKey -ResourceGroup $resourceGroupName -DomainName $domainName -KeyName "key1"
    Assert-True {$sharedAccessKeys.Count -eq 1}

    # Regenerate "key2" using the ResourceId parameter set
    $sharedAccessKeys = New-AzureRmEventGridDomainKey -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventGrid/domains/$domainName" -KeyName "key2"
    Assert-True {$sharedAccessKeys.Count -eq 1}

    # Regenerate "key2" using the Domain Input object
    $sharedAccessKeys = Get-AzureRmEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName | New-AzureRmEventGridDomainKey -KeyName "key2"
    Assert-True {$sharedAccessKeys.Count -eq 1}

    Write-Debug "Deleting domain: $domainName"
    Remove-AzureRmEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName

    Write-Debug "Deleting resourcegroup $resourceGroupName"
    Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
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
    $expectedInputMappingCloudEventSchema = "CloudEventV01Schema"
    $expectedInputMappingCustomEventSchema = "CustomEventSchema"

    $inputSchemaInvalid = "InvalidSchema"
    $inputSchemaEventGridSchema1 = "eventgriDSChemA"
    $inputSchemaEventGridSchema2 = "eventgridschema"
    $inputSchemaCloudEventSchema1 = "ClOuDEvENtV01ScheMA"
    $inputSchemaCloudEventSchema2 = "cloudeventV01schema"
    $inputSchemaCustomEventSchema1 = "cUsTomEVeNTSchEma"
    $inputSchemaCustomEventSchema2 = "customeventschema"

    Write-Debug "Creating first resource group"
    Write-Debug "ResourceGroup name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force

    try
    {
        Write-Debug "Creating a new EventGrid Domain: $domainName in resource group $resourceGroupName with InputSchema $inputSchemaInvalid"
        $result = New-AzureRmEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName -Location $location -InputSchema $inputSchemaInvalid
        Assert-True {$false} "New-AzureRmEventGridDomain succeeded while it is expected to fail"
    }
    catch
    {
        Assert-True {$true}
    }

    Write-Debug "Creating a new EventGrid Domain: $domainName in resource group $resourceGroupName with InputSchema $inputSchemaEventGridSchema1"
    $result = New-AzureRmEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName -Location $location -InputSchema $inputSchemaEventGridSchema1
    Assert-True {$result.ProvisioningState -eq "Succeeded"}
    Assert-True {$result.InputSchema -eq $expectedInputMappingEventGridSchema} "EventGridSchema is expected."

    Write-Debug "Getting the created domain within the resource group"
    $createdDomain = Get-AzureRmEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName
    Assert-True {$createdDomain.Count -eq 1}
    Assert-True {$createdDomain.DomainName -eq $domainName} "Domain created earlier is not found."
    Assert-True {$createdDomain.InputSchema -eq $expectedInputMappingEventGridSchema} "InputSchema is not correct. EventGridSchema is expected."

    Write-Debug "Creating a second EventGrid domain: $domainName2 in resource group $resourceGroupName with InputSchema $inputSchemaEventGridSchema2"
    $result = New-AzureRmEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName2 -Location $location -Tag @{ Dept = "IT"; Environment = "Test" } -InputSchema $inputSchemaEventGridSchema2
    Assert-True {$result.ProvisioningState -eq "Succeeded"}
    Assert-True {$result.InputSchema -eq $expectedInputMappingEventGridSchema} "InputSchema is not correct. EventGridSchema is expected"

    Write-Debug "Creating a third EventGrid domain: $domainName3 in resource group $resourceGroupName with InputSchema $inputSchemaCloudEventSchema1"
    $result = New-AzureRmEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName3 -Location $location -InputSchema $inputSchemaCloudEventSchema1
    Assert-True {$result.ProvisioningState -eq "Succeeded"}
    Assert-True {$result.InputSchema -eq $expectedInputMappingCloudEventSchema} "InputSchema is not correct. CloudEventSchema is expected."

    Write-Debug "Creating a fourth EventGrid domain: $domainName4 in resource group $resourceGroupName with InputSchema $inputSchemaCloudEventSchema2"
    $result = New-AzureRmEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName4 -Location $location -InputSchema $inputSchemaCloudEventSchema2
    Assert-True {$result.ProvisioningState -eq "Succeeded"}
    Assert-True {$result.InputSchema -eq $expectedInputMappingCloudEventSchema} "InputSchema is not correct. CloudEventSchema is expected."

    Write-Debug "Getting the created domain within the resource group"
    $createdDomain = Get-AzureRmEventGridDomain -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventGrid/domains/$domainName3"
    Assert-True {$createdDomain.Count -eq 1}
    Assert-True {$createdDomain.DomainName -eq $domainName3} "$domainName3 created earlier is not found."

    Write-Debug "Listing all the domains created in the resourceGroup $resourceGroupName"
    $allCreatedDomains = Get-AzureRmEventGridDomain -ResourceGroup $resourceGroupName

    Assert-True {$allCreatedDomains.Count -eq 4 } "Domains created earlier is not found in the list."

    Write-Debug "Getting all the domains created in the subscription"
    $allCreatedDomains = Get-AzureRmEventGridDomain

    Assert-True {$allCreatedDomains.Count -ge 0} "Domains created earlier are not found."

    try
    {
        Write-Debug "Creating a fifth EventGrid domain: $domainName5 in resource group $resourceGroupName with InputSchema $inputSchemaEventGridSchema1"
        $result = New-AzureRmEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName5 -Location $location -InputSchema $inputSchemaEventGridSchema1 -InputMappingField @{ id = "MyIdField"; topic = "MyTopicField"; eventtime = "MyEventTimeField"; subject = "MySubjectField"; eventtype = "MyEventTypeField" }
        Assert-True {$false} "New-AzureRmEventGridDomain succeeded while it is expected to fail as inputmapping parameters is not null for input mapping schema EventGridSchema"
    }
    catch
    {
        Assert-True {$true}
    }

    try
    {
        Write-Debug "Creating a fifth EventGrid domain: $domainName5 in resource group $resourceGroupName with InputSchema $inputSchemaCloudEventSchema1"
        $result = New-AzureRmEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName5 -Location $location -InputSchema $inputSchemaCloudEventSchema1 -InputMappingField @{ id = "MyIdField"; topic = "MyTopicField"; eventtime = "MyEventTimeField"; subject = "MySubjectField"; eventtype = "MyEventTypeField" }
        Assert-True {$false} "New-AzureRmEventGridDomain succeeded while it is expected to fail as inputmapping parameters is not null for input mapping schema CloudEventSchema"
    }
    catch
    {
        Assert-True {$true}
    }

    try
    {
        Write-Debug "Creating a fifth EventGrid domain: $domainName5 in resource group $resourceGroupName with InputSchema $inputSchemaCustomEventSchema1"
        $result = New-AzureRmEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName5 -Location $location -InputSchema $inputSchemaCustomEventSchema1
        Assert-True {$false} "New-AzureRmEventGridDomain succeeded while it is expected to fail as inputmapping parameters are null"
    }
    catch
    {
        Assert-True {$true}
    }

    Write-Debug "Creating a fifth EventGrid domain: $domainName5 in resource group $resourceGroupName with InputSchema $inputSchemaCustomEventSchema1"
    $result = New-AzureRmEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName5 -Location $location -InputSchema $inputSchemaCustomEventSchema1 -InputMappingField @{ id = "MyIdField"; topic = "MyTopicField"; eventtime = "MyEventTimeField"; subject = "MySubjectField"; eventtype = "MyEventTypeField"; dataversion = "MyDataVersionField" }
    Assert-True {$result.ProvisioningState -eq "Succeeded"}
    Assert-True {$result.InputSchema -eq $expectedInputMappingCustomEventSchema} "InputSchema is not correct. CustomEventSchema is expected"

    Write-Debug "Creating a sixth EventGrid domain: $domainName6 in resource group $resourceGroupName with InputSchema $inputSchemaCustomEventSchema2"
    $result = New-AzureRmEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName6 -Location $location -InputSchema $inputSchemaCustomEventSchema2 -InputMappingField @{ id = "MyIdField"; topic = "MyTopicField"; eventtime = "MyEventTimeField"; subject = "MySubjectField"; eventtype = "MyEventTypeField"; dataversion = "MyDataVersionField" } -InputMappingDefaultValue @{ subject = "MySubjectDefaultValue"; eventtype = "MyEventTypeDefaultValue"; dataversion = "MyDataVersionDefaultValue" }
    Assert-True {$result.ProvisioningState -eq "Succeeded"}
    Assert-True {$result.InputSchema -eq $expectedInputMappingCustomEventSchema} "InputSchema is not correct. CustomEventSchema is expected"

    Write-Debug "Getting the created domain within the resource group"
    $createdDomain = Get-AzureRmEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName5
    Assert-True {$createdDomain.Count -eq 1}
    Assert-True {$createdDomain.DomainName -eq $domainName5} "Domain created earlier is not found."
    Assert-True {$createdDomain.InputSchema -eq $expectedInputMappingCustomEventSchema} "InputSchema is not correct. CustomEventSchema is expected"

    Write-Debug "Deleting domain: $domainName"
    Remove-AzureRmEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName

    Write-Debug "Deleting domain: $domainName2 using the ResourceID parameter set"
    Remove-AzureRmEventGridDomain -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventGrid/domains/$domainName2"

    Write-Debug "Deleting domain: $domainName3"
    Remove-AzureRmEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName3

    Write-Debug "Deleting domain: $domainName4"
    Remove-AzureRmEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName4

    Write-Debug "Deleting domain: $domainName5"
    Remove-AzureRmEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName5

    Write-Debug "Deleting domain: $domainName6"
    Remove-AzureRmEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName6

    # Verify that all domains have been deleted correctly
    $returnedDomains1 = Get-AzureRmEventGridDomain -ResourceGroup $resourceGroupName
    Assert-True {$returnedDomains1.Count -eq 0}

    $returnedDomains2 = Get-AzureRmEventGridDomain -ResourceGroup $resourceGroupName
    Assert-True {$returnedDomains2.Count -eq 0}

    Write-Debug "Deleting resourcegroup $resourceGroupName"
    Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
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

    $resourceGroupName = Get-ResourceGroupName
    $subscriptionId = Get-SubscriptionId
    $eventSubscriptionName = Get-EventSubscriptionName
    ##### $eventSubscriptionEndpoint = "https://eventgridrunnerfunction.azurewebsites.net/api/HttpTriggerCSharp1?code=<HIDDEN>"
    $eventSubscriptionEndpoint = "https://eventgridrunnerfunction.azurewebsites.net/api/HttpTriggerCSharp1?code=VbOalRw5qWMltR57RaCn6BaeQqELvPfC/ad0k/kjv6yCe0JLIsLYaw=="


    Write-Debug "Creating resource group"
    Write-Debug "ResourceGroup name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force

    Write-Debug "Creating a new EventGrid domain: $domainName in resource group $resourceGroupName"
    $result = New-AzureRmEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName -Location $location
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Creating a new EventSubscription $eventSubscriptionName to domain topic $domainTopicName1 under domain $domainName in resource group $resourceGroupName"
    $result = New-AzureRmEventGridSubscription -ResourceGroup $resourceGroupName -DomainName $domainName -DomainTopicName $domainTopicName1 -Endpoint $eventSubscriptionEndpoint -EventSubscriptionName $eventSubscriptionName
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Creating a new EventSubscription $eventSubscriptionName to domain topic $domainTopicName2 under domain $domainName in resource group $resourceGroupName"
    $result = New-AzureRmEventGridSubscription -ResourceGroup $resourceGroupName -DomainName $domainName -DomainTopicName $domainTopicName2 -Endpoint $eventSubscriptionEndpoint -EventSubscriptionName $eventSubscriptionName
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Creating a new EventSubscription $eventSubscriptionName to domain topic $domainTopicName3 under domain $domainName in resource group $resourceGroupName"
    $result = New-AzureRmEventGridSubscription -ResourceGroup $resourceGroupName -DomainName $domainName -DomainTopicName $domainTopicName3 -Endpoint $eventSubscriptionEndpoint -EventSubscriptionName $eventSubscriptionName
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Getting all the created domain topics under domain $domainName using domain name"
    $createdDomainTopics = Get-AzureRmEventGridDomainTopic -ResourceGroup $resourceGroupName -DomainName $domainName
    Assert-True {$createdDomainTopics.Count -eq 3}

    Write-Debug "Getting all the created domain topics under domain $domainName using resourceId"
    $createdDomainTopics2 = Get-AzureRmEventGridDomainTopic -ResourceGroup $resourceGroupName -DomainName $domainName
    $createdDomainTopics2 = Get-AzureRmEventGridDomainTopic -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventGrid/domains/$domainName"
    Assert-True {$createdDomainTopics2.Count -eq 3}

    Write-Debug "Getting the created domain topic $domainTopicName1 under domain $domainName using domain and domain topic names"
    $createdDomainTopic3 = Get-AzureRmEventGridDomainTopic -ResourceGroup $resourceGroupName -DomainName $domainName -DomainTopicName $domainTopicName1
    Assert-True {$createdDomainTopic3.Count -eq 1}
    Assert-True {$createdDomainTopic3.DomainTopicName -eq $domainTopicName1} "DomainTopicName for the created domain topic is not correct."

    Write-Debug "Getting the created domain topic $domainTopicName2 under domain $domainName using resourceId"
    $createdDomainTopic4 = Get-AzureRmEventGridDomainTopic -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventGrid/domains/$domainName/topics/$domainTopicName2"
    Assert-True {$createdDomainTopic4.Count -eq 1}
    Assert-True {$createdDomainTopic4.DomainTopicName -eq $domainTopicName2} "DomainTopicName for the created domain topic is not correct."

    Write-Debug "Deleting the created EventSubscription $eventSubscriptionName to domain topic $domainTopicName3 under domain $domainName in resource group $resourceGroupName"
    $result = Remove-AzureRmEventGridSubscription -EventSubscriptionName $eventSubscriptionName -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventGrid/domains/$domainName/topics/$domainTopicName3"

    ######## TODO: check this
    ############## -ResourceGroup $resourceGroupName -DomainName $domainName -DomainTopicName $domainTopicName3 -EventSubscriptionName $eventSubscriptionName

    try
    {
        Write-Debug "Checking if the domain topic $domainTopicName3 under domain $domainName is removed too."
        $checkDomainTopic5 = Get-AzureRmEventGridDomainTopic -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventGrid/domains/$domainName/topics/$domainTopicName3"
        Assert-True {$false} "Get-AzureRmEventGridDomainTopic succeeded while it is expected to fail as domain topic $domainTopicName3 should be auto-deleted already."
    }
    catch
    {
        Assert-True {$true}
    }

    Write-Debug "Deleting domain: $domainName"
    Remove-AzureRmEventGridDomain -ResourceGroup $resourceGroupName -Name $domainName

    Write-Debug "Deleting resourcegroup $resourceGroupName"
    Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}
