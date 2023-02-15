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
function TopicTests {
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

    try
    {
        Write-Debug "Creating a new EventGrid Topic: $topicName in resource group $resourceGroupName"
        Write-Debug "Topic: $topicName"
        $result = New-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName -Location $location
        Assert-True {$result.ProvisioningState -eq "Succeeded"}

        Write-Debug "Getting the created topic within the resource group"
        $createdTopic = Get-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName
        Assert-True {$createdTopic.Count -eq 1}
        Assert-True {$createdTopic.TopicName -eq $topicName} "Topic created earlier is not found."

        Write-Debug "Creating a second EventGrid topic: $topicName2 in resource group $secondResourceGroup"
        $result = New-AzEventGridTopic -ResourceGroup $secondResourceGroup -Name $topicName2 -Location $location -Tag @{ Dept = "IT"; Environment = "Test" }
        Assert-True {$result.ProvisioningState -eq "Succeeded"}

        Write-Debug "Creating a third EventGrid topic: $topicName3 in resource group $secondResourceGroup"
        $result = New-AzEventGridTopic -ResourceGroup $secondResourceGroup -Name $topicName3 -Location $location
        Assert-True {$result.ProvisioningState -eq "Succeeded"}

        Write-Debug "Getting the created topic $topicName3 within the resource group using the resourceId"
        $createdTopic = Get-AzEventGridTopic -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$secondResourceGroup/providers/Microsoft.EventGrid/topics/$topicName3"
        Assert-True {$createdTopic.Count -eq 1}
        Assert-True {$createdTopic.TopicName -eq $topicName3} "Topic created earlier is not found."

        Write-Debug "Listing all the topics created in the resourceGroup $secondResourceGroup"
        $allCreatedTopics = Get-AzEventGridTopic -ResourceGroup $secondResourceGroup
        Assert-True {$allCreatedTopics.PsTopicsList.Count -ge 0 } "Topic created earlier is not found in the list"

        Write-Debug "Listing the topics created in the resourceGroup $secondResourceGroup using Top option"
        $allCreatedTopics = Get-AzEventGridTopic -ResourceGroup $secondResourceGroup -Top 1
        # Assert-True {$allCreatedTopics.PsTopicsList.Count -le 1 } "Topic created earlier is not found in the list"
        Assert-True {$allCreatedTopics.NextLink -ne $null } "NextLink should not be null as more topics should be available under resource group.."

        Write-Debug "Listing the next topics created in the resourceGroup $secondResourceGroup using NextLink"
        $allCreatedTopics = Get-AzEventGridTopic -NextLink $allCreatedTopics.NextLink
        # Assert-True {$allCreatedTopics.PsTopicsList.Count -le 1 } "returned topics count is greater than top"
        # Assert-True {$allCreatedTopics.NextLink -ne $null } "NextLink should not be null."

        Write-Debug "Getting the first 1 topic created in the subscription using Top options"
        $allCreatedTopics = Get-AzEventGridTopic -Top 1
        Assert-True {$allCreatedTopics.PsTopicsList.Count -ge 0} "Topics created earlier are not found."
        Assert-True {$allCreatedTopics.NextLink -ne $null } "NextLink should not be null as more topics should be available under the azure subscription."

        Write-Debug "Listing the next topics created in the subscription using NextLink"
        $allCreatedTopics = Get-AzEventGridTopic -NextLink $allCreatedTopics.NextLink
        # Assert-True {$allCreatedTopics.PsTopicsList.Count -le 1 } "returned topics count is greater than top"
        # Assert-True {$allCreatedTopics.NextLink -ne $null } "NextLink should not be null."

        Write-Debug "Getting all the topics created in the subscription"
        $allCreatedTopics = Get-AzEventGridTopic
        Assert-True {$allCreatedTopics.PsTopicsList.Count -ge 0} "Topics created earlier are not found."

        Write-Debug "Deleting topic: $topicName"
        Remove-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName

        Write-Debug "Creating a new EventGrid Topic: $topicName4 in resource group $resourceGroupName"
        $result = New-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName4 -Location $location

        Write-Debug "Deleting topic: $topicName4 using the InputObject parameter set"
        Get-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName4 | Remove-AzEventGridTopic

        Write-Debug "Deleting topic: $topicName2 using the ResourceID parameter set"
        # Offline playback of tests is failing if I use Get-AzureRmResource, hence temporarily commenting this out
        # Get-AzureRmResource -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$secondResourceGroup/providers/Microsoft.EventGrid/topics/$topicName3" | Remove-AzEventGridTopic
        Remove-AzEventGridTopic -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$secondResourceGroup/providers/Microsoft.EventGrid/topics/$topicName2"

        Remove-AzEventGridTopic -ResourceGroup $secondResourceGroup -Name $topicName3

        # Verify that all topics have been deleted correctly
        $returnedTopics1 = Get-AzEventGridTopic -ResourceGroup $resourceGroupName
        Assert-True {$returnedTopics1.PsTopicsList.Count -eq 0}

        $returnedTopics2 = Get-AzEventGridTopic -ResourceGroup $secondResourceGroup
        Assert-True {$returnedTopics2.PsTopicsList.Count -eq 0}
    }
    finally
    {
        Remove-ResourceGroup $resourceGroupName
        Remove-ResourceGroup $secondResourceGroup
    }
}

<#
.SYNOPSIS
Tests EventGrid Topic Set operations.
#>
function TopicsIdentityTests {
    # Setup
    $location = Get-LocationForEventGrid
    $topicName = Get-TopicName
    $topicName2 = Get-TopicName
    $resourceGroupName = Get-ResourceGroupName
    $subscriptionId = Get-SubscriptionId

    New-ResourceGroup $resourceGroupName $location

    try
    {
        $ipRule1 = @{ "10.0.0.0/8" = "Allow"; "10.2.0.0/8" = "Allow" }
        $ipRule2 = @{ "10.3.0.0/16" = "Allow" }

        Write-Debug "Creating a new EventGrid Topic: $topicName in resource group $resourceGroupName"
        Write-Debug "Topic: $topicName"
        $result = New-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName -Location $location -IdentityType 'SystemAssigned'
        Assert-True {$result.ProvisioningState -eq "Succeeded"}
        Assert-True {$result.Identity.IdentityType -eq "SystemAssigned"}

        Write-Debug "Creating a new EventGrid Topic: $topicName2 in resource group $resourceGroupName"
        Write-Debug "Topic: $topicName2"
        $result = New-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName2 -Location $location -IdentityType 'None'
        Assert-True {$result.ProvisioningState -eq "Succeeded"}
        Assert-True {$result.Identity.IdentityType -eq "None"}

        $tags1 = @{test1 = "testval1"; test2 = "testval2" };
        Write-Debug "Calling Set-AzEventGridTopic on the created topic $topicName"
        $userIdentity = "/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/amh/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testIdentity1"
        $replacedTopic1 = Set-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName2 -Tag $tags1 -InboundIpRule $ipRule1 -PublicNetworkAccess "enabled" -IdentityType 'UserAssigned' -IdentityId $userIdentity
        Assert-True {$replacedTopic1.Count -eq 1}
        Assert-True {$replacedTopic1.TopicName -eq $topicName2} "Topic updated earlier is not found."
        Assert-True {$replacedTopic1.Identity.IdentityType -eq "UserAssigned"} "Topic updated earlier is not found."

        Write-Debug "Deleting topic: $topicName"
        Remove-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName

        Write-Debug "Deleting topic: $topicName2"
        Remove-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName2
    }
    finally
    {
        Remove-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Tests EventGrid Topic Set operations.
#>
function TopicSetTests {
    # Setup
    $location = Get-LocationForEventGrid
    $topicName = Get-TopicName
    $resourceGroupName = Get-ResourceGroupName
    $subscriptionId = Get-SubscriptionId

    New-ResourceGroup $resourceGroupName $location

    try
    {
        $ipRule1 = @{ "10.0.0.0/8" = "Allow"; "10.2.0.0/8" = "Allow" }
        $ipRule2 = @{ "10.3.0.0/16" = "Allow" }

        Write-Debug "Creating a new EventGrid Topic: $topicName in resource group $resourceGroupName"
        Write-Debug "Topic: $topicName"
        $result = New-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName -Location $location
        Assert-True {$result.ProvisioningState -eq "Succeeded"}

        Write-Debug "Calling Set-AzEventGridTopic on the created topic $topicName"
        $tags1 = @{test1 = "testval1"; test2 = "testval2" };
        $replacedTopic1 = Set-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName -Tag $tags1 -InboundIpRule $ipRule1 -PublicNetworkAccess "enabled"
        Assert-True {$replacedTopic1.Count -eq 1}
        Assert-True {$replacedTopic1.TopicName -eq $topicName} "Topic updated earlier is not found."


        Write-Debug "Calling Set-AzEventGridTopic on the created topic $topicName"
        $tags2 = @{test1 = "testval1"; test2 = "testval2" };
        $replacedTopic2 = Set-AzEventGridTopic -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventGrid/topics/$topicName" -Tag $tags2 -InboundIpRule $ipRule2 -PublicNetworkAccess "enabled"
        Assert-True {$replacedTopic2.Count -eq 1}
        Assert-True {$replacedTopic2.TopicName -eq $topicName} "Topic updated earlier is not found."
        $returned_tags2 = $replacedTopic2.Tags;
        Assert-AreEqual 2 $returned_tags2.Count;
        Assert-AreEqual $tags2["test1"] $returned_tags2["test1"];
        Assert-AreEqual $tags2["test2"] $returned_tags2["test2"];

        Write-Debug "Calling Set-AzEventGridTopic on the created topic $topicName"
        $tags3 = @{test1 = "testval10"; test2 = "testval20" };
        $replacedTopic3 = Get-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName | Set-AzEventGridTopic -Tag $tags3 -InboundIpRule $ipRule1 -PublicNetworkAccess "enabled"
        Assert-True {$replacedTopic3.Count -eq 1}
        Assert-True {$replacedTopic3.TopicName -eq $topicName} "Topic updated earlier is not found."
        $returned_tags3 = $replacedTopic3.Tags;
        Assert-AreEqual 2 $returned_tags3.Count;
        Assert-AreEqual $tags3["test1"] $returned_tags3["test1"];
        Assert-AreEqual $tags3["test2"] $returned_tags3["test2"];

        Write-Debug "Deleting topic: $topicName"
        Remove-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName
    }
    finally
    {
        Remove-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Tests EventGrid Topic Key retrieval related operations.
#>
function TopicGetKeyTests {
    # Setup
    $location = Get-LocationForEventGrid
    $topicName = Get-TopicName
    $resourceGroupName = Get-ResourceGroupName
    $subscriptionId = Get-SubscriptionId

    New-ResourceGroup $resourceGroupName $location

    try
    {
        Write-Debug "Creating a new EventGrid Topic: $topicName in resource group $resourceGroupName"
        $result = New-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName -Location $location
        Assert-True {$result.ProvisioningState -eq "Succeeded"}

        # Get the keys of the topic
        $sharedAccessKeys = Get-AzEventGridTopicKey -ResourceGroup $resourceGroupName -Name $topicName
        Assert-True {$sharedAccessKeys.Count -eq 1}

        # Get the keys of the topic using ResourceID parameter set
        $sharedAccessKeys = Get-AzEventGridTopicKey -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventGrid/topics/$topicName"
        Assert-True {$sharedAccessKeys.Count -eq 1}

        # Get the keys of the topic using the Topic Input object
        $sharedAccessKeys = Get-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName | Get-AzEventGridTopicKey
        Assert-True {$sharedAccessKeys.Count -eq 1}

        Write-Debug "Deleting topic: $topicName"
        Remove-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName
    }
    finally
    {
        Remove-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Tests EventGrid Topic Key regeneration related operations.
#>
function TopicNewKeyTests {
    # Setup
    $location = Get-LocationForEventGrid
    $topicName = Get-TopicName
    $resourceGroupName = Get-ResourceGroupName
    $subscriptionId = Get-SubscriptionId

    New-ResourceGroup $resourceGroupName $location

    try
    {
        Write-Debug "Creating a new EventGrid Topic: $topicName in resource group $resourceGroupName"
        $result = New-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName -Location $location
        Assert-True {$result.ProvisioningState -eq "Succeeded"}

        # Regenerate "key1"
        $sharedAccessKeys = New-AzEventGridTopicKey -ResourceGroup $resourceGroupName -TopicName $topicName -KeyName "key1"
        Assert-True {$sharedAccessKeys.Count -eq 1}

        # Regenerate "key2" using the ResourceId parameter set
        $sharedAccessKeys = New-AzEventGridTopicKey -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventGrid/topics/$topicName" -KeyName "key2"
        Assert-True {$sharedAccessKeys.Count -eq 1}

        # Regenerate "key2" using the Topic Input object
        $sharedAccessKeys = Get-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName | New-AzEventGridTopicKey -KeyName "key2"
        Assert-True {$sharedAccessKeys.Count -eq 1}

        Write-Debug "Deleting topic: $topicName"
        Remove-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName
    }
    finally
    {
        Remove-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Tests EventGrid Topic Create, Get and List operations with Input mapping
#>
function TopicInputMappingTests {
    # Setup
    $location = Get-LocationForEventGrid
    $topicName = Get-TopicName
    $topicName2 = Get-TopicName
    $topicName3 = Get-TopicName
    $topicName4 = Get-TopicName
    $topicName5 = Get-TopicName
    $topicName6 = Get-TopicName

    $resourceGroupName = Get-ResourceGroupName
    $subscriptionId = Get-SubscriptionId

    $expectedInputMappingEventGridSchema = "EventGridSchema"
    $expectedInputMappingCloudEventSchema = "CloudEventSchemaV1_0"
    $expectedInputMappingCustomEventSchema = "CustomEventSchema"

    $inputSchemaInvalid = "InvalidSchema"
    $inputSchemaEventGridSchema1 = "eventgriDSChemA"
    $inputSchemaEventGridSchema2 = "eventgridschema"
    $inputSchemaCloudEventSchema1 = "CloUdEvENtSchemaV1_0"
    $inputSchemaCloudEventSchema2 = "ClOUdEVentSchEMAv1_0"
    $inputSchemaCustomEventSchema1 = "cUsTomEVeNTSchEma"
    $inputSchemaCustomEventSchema2 = "customeventschema"

    New-ResourceGroup $resourceGroupName $location

    try
    {
        try
        {
            Write-Debug "Creating a new EventGrid Topic: $topicName in resource group $resourceGroupName with InputSchema $inputSchemaInvalid"
            $result = New-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName -Location $location -InputSchema $inputSchemaInvalid
            Assert-True {$false} "New-AzEventGridTopic succeeded while it is expected to fail"
        }
        catch
        {
            Assert-True {$true}
        }

        Write-Debug "Creating a new EventGrid Topic: $topicName in resource group $resourceGroupName with InputSchema $inputSchemaEventGridSchema1"
        $result = New-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName -Location $location -InputSchema $inputSchemaEventGridSchema1
        Assert-True {$result.ProvisioningState -eq "Succeeded"}
        Assert-True {$result.InputSchema -eq $expectedInputMappingEventGridSchema} "EventGridSchema is expected."

        Write-Debug "Getting the created topic within the resource group"
        $createdTopic = Get-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName
        Assert-True {$createdTopic.Count -eq 1}
        Assert-True {$createdTopic.TopicName -eq $topicName} "Topic created earlier is not found."
        Assert-True {$createdTopic.InputSchema -eq $expectedInputMappingEventGridSchema} "InputSchema is not correct. EventGridSchema is expected."

        Write-Debug "Creating a second EventGrid topic: $topicName2 in resource group $resourceGroupName with InputSchema $inputSchemaEventGridSchema2"
        $result = New-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName2 -Location $location -Tag @{ Dept = "IT"; Environment = "Test" } -InputSchema $inputSchemaEventGridSchema2
        Assert-True {$result.ProvisioningState -eq "Succeeded"}
        Assert-True {$result.InputSchema -eq $expectedInputMappingEventGridSchema} "InputSchema is not correct. EventGridSchema is expected"

        Write-Debug "Creating a third EventGrid topic: $topicName3 in resource group $resourceGroupName with InputSchema $inputSchemaCloudEventSchema1"
        $result = New-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName3 -Location $location -InputSchema $inputSchemaCloudEventSchema1
        Assert-True {$result.ProvisioningState -eq "Succeeded"}
        Assert-True {$result.InputSchema -eq $expectedInputMappingCloudEventSchema} "InputSchema is not correct. CloudEventSchema is expected."

        Write-Debug "Creating a fourth EventGrid topic: $topicName4 in resource group $resourceGroupName with InputSchema $inputSchemaCloudEventSchema2"
        $result = New-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName4 -Location $location -InputSchema $inputSchemaCloudEventSchema2
        Assert-True {$result.ProvisioningState -eq "Succeeded"}
        Assert-True {$result.InputSchema -eq $expectedInputMappingCloudEventSchema} "InputSchema is not correct. CloudEventSchema is expected."

        Write-Debug "Getting the created topic within the resource group"
        $createdTopic = Get-AzEventGridTopic -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventGrid/topics/$topicName3"
        Assert-True {$createdTopic.Count -eq 1}
        Assert-True {$createdTopic.TopicName -eq $topicName3} "$topicName3 created earlier is not found."

        Write-Debug "Listing all the topics created in the resourceGroup $resourceGroupName"
        $allCreatedTopics = Get-AzEventGridTopic -ResourceGroup $resourceGroupName
        Assert-True {$allCreatedTopics.PsTopicsList.Count -eq 4 } "Topics created earlier is not found in the list."

        Write-Debug "Getting all the topics created in the subscription"
        $allCreatedTopics = Get-AzEventGridTopic
        Assert-True {$allCreatedTopics.PsTopicsList.Count -ge 0} "Topics created earlier are not found."

        try
        {
            Write-Debug "Creating a fifth EventGrid topic: $topicName5 in resource group $resourceGroupName with InputSchema $inputSchemaEventGridSchema1"
            $result = New-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName5 -Location $location -InputSchema $inputSchemaEventGridSchema1 -InputMappingField @{ id = "MyIdField"; topic = "MyTopicField"; eventtime = "MyEventTimeField"; subject = "MySubjectField"; eventtype = "MyEventTypeField" }
            Assert-True {$false} "New-AzEventGridTopic succeeded while it is expected to fail as inputmapping parameters is not null for input mapping schema EventGridSchema"
        }
        catch
        {
            Assert-True {$true}
        }

        try
        {
            Write-Debug "Creating a fifth EventGrid topic: $topicName5 in resource group $resourceGroupName with InputSchema $inputSchemaCloudEventSchema1"
            $result = New-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName5 -Location $location -InputSchema $inputSchemaCloudEventSchema1 -InputMappingField @{ id = "MyIdField"; topic = "MyTopicField"; eventtime = "MyEventTimeField"; subject = "MySubjectField"; eventtype = "MyEventTypeField" }
            Assert-True {$false} "New-AzEventGridTopic succeeded while it is expected to fail as inputmapping parameters is not null for input mapping schema CloudEventSchema"
        }
        catch
        {
            Assert-True {$true}
        }

        try
        {
            Write-Debug "Creating a fifth EventGrid topic: $topicName5 in resource group $resourceGroupName with InputSchema $inputSchemaCustomEventSchema1"
            $result = New-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName5 -Location $location -InputSchema $inputSchemaCustomEventSchema1
            Assert-True {$false} "New-AzEventGridTopic succeeded while it is expected to fail as inputmapping parameters are null"
        }
        catch
        {
            Assert-True {$true}
        }

        Write-Debug "Creating a fifth EventGrid topic: $topicName5 in resource group $resourceGroupName with InputSchema $inputSchemaCustomEventSchema1"
        $result = New-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName5 -Location $location -InputSchema $inputSchemaCustomEventSchema1 -InputMappingField @{ id = "MyIdField"; topic = "MyTopicField"; eventtime = "MyEventTimeField"; subject = "MySubjectField"; eventtype = "MyEventTypeField"; dataversion = "MyDataVersionField" }
        Assert-True {$result.ProvisioningState -eq "Succeeded"}
        Assert-True {$result.InputSchema -eq $expectedInputMappingCustomEventSchema} "InputSchema is not correct. CustomEventSchema is expected"

        Write-Debug "Creating a sixth EventGrid topic: $topicName6 in resource group $resourceGroupName with InputSchema $inputSchemaCustomEventSchema2"
        $result = New-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName6 -Location $location -InputSchema $inputSchemaCustomEventSchema2 -InputMappingField @{ id = "MyIdField"; topic = "MyTopicField"; eventtime = "MyEventTimeField"; subject = "MySubjectField"; eventtype = "MyEventTypeField"; dataversion = "MyDataVersionField" } -InputMappingDefaultValue @{ subject = "MySubjectDefaultValue"; eventtype = "MyEventTypeDefaultValue"; dataversion = "MyDataVersionDefaultValue" }
        Assert-True {$result.ProvisioningState -eq "Succeeded"}
        Assert-True {$result.InputSchema -eq $expectedInputMappingCustomEventSchema} "InputSchema is not correct. CustomEventSchema is expected"

        Write-Debug "Getting the created topic within the resource group"
        $createdTopic = Get-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName5
        Assert-True {$createdTopic.Count -eq 1}
        Assert-True {$createdTopic.TopicName -eq $topicName5} "Topic created earlier is not found."
        Assert-True {$createdTopic.InputSchema -eq $expectedInputMappingCustomEventSchema} "InputSchema is not correct. CustomEventSchema is expected"

        Write-Debug "Deleting topic: $topicName"
        Remove-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName

        Write-Debug "Deleting topic: $topicName2 using the ResourceID parameter set"
        Remove-AzEventGridTopic -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventGrid/topics/$topicName2"

        Write-Debug "Deleting topic: $topicName3"
        Remove-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName3

        Write-Debug "Deleting topic: $topicName4"
        Remove-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName4

        Write-Debug "Deleting topic: $topicName5"
        Remove-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName5

        Write-Debug "Deleting topic: $topicName6"
        Remove-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName6

        # Verify that all topics have been deleted correctly
        $returnedTopics1 = Get-AzEventGridTopic -ResourceGroup $resourceGroupName
        Assert-True {$returnedTopics1.PsTopicsList.Count -eq 0}

        $returnedTopics2 = Get-AzEventGridTopic -ResourceGroup $resourceGroupName
        Assert-True {$returnedTopics2.PsTopicsList.Count -eq 0}
    }
    finally
    {
        Remove-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Tests EventGrid Topic with IpFiltering operations.
#>
function TopicIpFilteringTests {
    # Setup
    $location = Get-LocationForEventGrid
    $topicName = Get-TopicName
    $resourceGroupName = Get-ResourceGroupName
    $subscriptionId = Get-SubscriptionId

    New-ResourceGroup $resourceGroupName $location

    try
    {
        $tags1 = @{ test1 = "testval1"; test2 = "testval2" }
        $ipRule1 = @{ "10.0.0.0/8" = "Allow"; "10.2.0.0/8" = "Allow" }
        $ipRule2 = @{ "10.3.0.0/16" = "Allow" }

        Write-Debug "Creating a new EventGrid Topic: $topicName in resource group $resourceGroupName"
        Write-Debug "Topic: $topicName"
        $result = New-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName -Location $location -InboundIpRule $ipRule1 -PublicNetworkAccess "enabled"
        Assert-True {$result.ProvisioningState -eq "Succeeded"}
        Assert-True {$result.PublicNetworkAccess -eq "Enabled"}
        Assert-AreEqual 2 $result.InboundIpRule.Count;
        Assert-AreEqual $ipRule1["10.0.0.0/8"] $result.InboundIpRule["10.0.0.0/8"];
        Assert-AreEqual $ipRule1["10.2.0.0/8"] $result.InboundIpRule["10.2.0.0/8"];

        $result = Get-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName
        Assert-True {$result.ProvisioningState -eq "Succeeded"}
        Assert-True {$result.PublicNetworkAccess -eq "enabled"}
        $returned_ipRules2 = $result.InboundIpRule;
        Assert-AreEqual 2 $returned_ipRules2.Count;
        Assert-AreEqual $ipRule1["10.0.0.0/8"] $returned_ipRules2["10.0.0.0/8"];
        Assert-AreEqual $ipRule1["10.2.0.0/8"] $returned_ipRules2["10.2.0.0/8"];

        Write-Debug "Calling Set-AzEventGridTopic on the created topic $topicName"
        $tags2 = @{test1 = "testval1"; test2 = "testval2" };
        $replacedTopic2 = Set-AzEventGridTopic -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventGrid/topics/$topicName" -Tag $tags2 -InboundIpRule $ipRule2 -PublicNetworkAccess enabled
        Assert-True {$replacedTopic2.InboundIpRule.Count -eq 1}
        Assert-True {$replacedTopic2.PublicNetworkAccess -eq "enabled"}
        Assert-True {$replacedTopic2.TopicName -eq $topicName} "Topic updated earlier is not found."

        $returned_ipRules2 = $replacedTopic2.InboundIpRule;
        Assert-AreEqual 1 $returned_ipRules2.Count;
        Assert-AreEqual $ipRule2["10.3.0.0/16"] $returned_ipRules2["10.3.0.0/16"];

        Write-Debug "Calling Set-AzEventGridTopic on the created topic $topicName"
        $tags3 = @{test1 = "testval10"; test2 = "testval20" };
        $replacedTopic3 = Get-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName | Set-AzEventGridTopic -Tag $tags3 -PublicNetworkAccess enabled -InboundIpRule $ipRule1
        Assert-True {$replacedTopic3.Count -eq 1}
        Assert-True {$replacedTopic3.TopicName -eq $topicName} "Topic updated earlier is not found."
        Assert-True {$result.InboundIpRule.Count -eq 2}
        Assert-True {$result.PublicNetworkAccess -eq "enabled"}

        Write-Debug "Deleting topic: $topicName"
        Remove-AzEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName
    }
    finally
    {
        Remove-ResourceGroup $resourceGroupName
    }
}
