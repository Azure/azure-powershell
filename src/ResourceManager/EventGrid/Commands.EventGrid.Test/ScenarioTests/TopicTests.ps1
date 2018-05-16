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

    Write-Debug "Creating first resource group"
    Write-Debug "ResourceGroup name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force

    Write-Debug "Creating second resource group"
    Write-Debug "ResourceGroup name : $secondResourceGroup"
    New-AzureRmResourceGroup -Name $secondResourceGroup -Location $location -Force

    Write-Debug " Creating a new EventGrid Topic: $topicName in resource group $resourceGroupName"
    Write-Debug "Topic: $topicName"
    $result = New-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName -Location $location
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Getting the created topic within the resource group"
    $createdTopic = Get-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName
    Assert-True {$createdTopic.Count -eq 1}
    Assert-True {$createdTopic.TopicName -eq $topicName} "Topic created earlier is not found."

    Write-Debug "Creating a second EventGrid topic: $topicName2 in resource group $secondResourceGroup"
    $result = New-AzureRmEventGridTopic -ResourceGroup $secondResourceGroup -Name $topicName2 -Location $location -Tag @{ Dept = "IT"; Environment = "Test" }
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Creating a third EventGrid topic: $topicName3 in resource group $secondResourceGroup"
    $result = New-AzureRmEventGridTopic -ResourceGroup $secondResourceGroup -Name $topicName3 -Location $location
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Getting the created topic within the resource group"
    $createdTopic = Get-AzureRmEventGridTopic -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$secondResourceGroup/providers/Microsoft.EventGrid/topics/$topicName3"
    Assert-True {$createdTopic.Count -eq 1}
    Assert-True {$createdTopic.TopicName -eq $topicName3} "Topic created earlier is not found."

    Write-Debug "Listing all the topics created in the resourceGroup $secondResourceGroup"
    $allCreatedTopics = Get-AzureRmEventGridTopic -ResourceGroup $secondResourceGroup

    Assert-True {$allCreatedTopics.Count -ge 0 } "Topic created earlier is not found in the list"

    Write-Debug "Getting all the topics created in the subscription"
    $allCreatedTopics = Get-AzureRmEventGridTopic

    Assert-True {$allCreatedtopic.Count -ge 0} "Topics created earlier are not found."

    Write-Debug " Deleting topic: $topicName"
    Remove-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName

    Write-Debug " Creating a new EventGrid Topic: $topicName4 in resource group $resourceGroupName"
    $result = New-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName4 -Location $location

    Write-Debug " Deleting topic: $topicName4 using the InputObject parameter set"
    Get-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName4 | Remove-AzureRmEventGridTopic

    Write-Debug " Deleting topic: $topicName2 using the ResourceID parameter set"
    # Offline playback of tests is failing if I use Get-AzureRmResource, hence temporarily commenting this out
    # Get-AzureRmResource -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$secondResourceGroup/providers/Microsoft.EventGrid/topics/$topicName3" | Remove-AzureRmEventGridTopic
    Remove-AzureRmEventGridTopic -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$secondResourceGroup/providers/Microsoft.EventGrid/topics/$topicName2"

    Remove-AzureRmEventGridTopic -ResourceGroup $secondResourceGroup -Name $topicName3

    # Verify that all topics have been deleted correctly
    $returnedTopics1 = Get-AzureRmEventGridTopic -ResourceGroup $resourceGroupName
    Assert-True {$returnedTopics1.Count -eq 0}

    $returnedTopics2 = Get-AzureRmEventGridTopic -ResourceGroup $secondResourceGroup
    Assert-True {$returnedTopics2.Count -eq 0}

    Write-Debug " Deleting resourcegroup $resourceGroupName"
    Remove-AzureRmResourceGroup -Name $resourceGroupName -Force

    Write-Debug " Deleting resourcegroup $secondResourceGroup"
    Remove-AzureRmResourceGroup -Name $secondResourceGroup -Force
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

    Write-Debug "Creating resource group"
    Write-Debug "ResourceGroup name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force

    Write-Debug " Creating a new EventGrid Topic: $topicName in resource group $resourceGroupName"
    Write-Debug "Topic: $topicName"
    $result = New-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName -Location $location
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Calling Set-AzureRmEventGridTopic on the created topic $topicName"
    $tags1 = @{test1 = "testval1"; test2 = "testval2" };
    $replacedTopic1 = Set-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName -Tag $tags1
    Assert-True {$replacedTopic1.Count -eq 1}
    Assert-True {$replacedTopic1.TopicName -eq $topicName} "Topic updated earlier is not found."

    Write-Debug "Calling Set-AzureRmEventGridTopic on the created topic $topicName"
    $tags2 = @{test1 = "testval1"; test2 = "testval2" };
    $replacedTopic2 = Set-AzureRmEventGridTopic -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventGrid/topics/$topicName" -Tag $tags2
    Assert-True {$replacedTopic2.Count -eq 1}
    Assert-True {$replacedTopic2.TopicName -eq $topicName} "Topic updated earlier is not found."
    $returned_tags2 = $replacedTopic2.Tags;
    Assert-AreEqual 2 $returned_tags2.Count;
    Assert-AreEqual $tags2["test1"] $returned_tags2["test1"];
    Assert-AreEqual $tags2["test2"] $returned_tags2["test2"];

    Write-Debug "Calling Set-AzureRmEventGridTopic on the created topic $topicName"
    $tags3 = @{test1 = "testval10"; test2 = "testval20" };
    $replacedTopic3 = Get-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName | Set-AzureRmEventGridTopic -Tag $tags3
    Assert-True {$replacedTopic3.Count -eq 1}
    Assert-True {$replacedTopic3.TopicName -eq $topicName} "Topic updated earlier is not found."
    $returned_tags3 = $replacedTopic3.Tags;
    Assert-AreEqual 2 $returned_tags3.Count;
    Assert-AreEqual $tags3["test1"] $returned_tags3["test1"];
    Assert-AreEqual $tags3["test2"] $returned_tags3["test2"];

    Write-Debug " Deleting topic: $topicName"
    Remove-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName

    Write-Debug " Deleting resourcegroup $resourceGroupName"
    Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
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

    Write-Debug "Creating resource group"
    Write-Debug "ResourceGroup name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force

    Write-Debug " Creating a new EventGrid Topic: $topicName in resource group $resourceGroupName"
    $result = New-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName -Location $location    
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    # Get the keys of the topic
    $sharedAccessKeys = Get-AzureRmEventGridTopicKey -ResourceGroup $resourceGroupName -Name $topicName
    Assert-True {$sharedAccessKeys.Count -eq 1}

    # Get the keys of the topic using ResourceID parameter set
    $sharedAccessKeys = Get-AzureRmEventGridTopicKey -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventGrid/topics/$topicName"
    Assert-True {$sharedAccessKeys.Count -eq 1}

    # Get the keys of the topic using the Topic Input object
    $sharedAccessKeys = Get-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName | Get-AzureRmEventGridTopicKey
    Assert-True {$sharedAccessKeys.Count -eq 1}

    Write-Debug " Deleting topic: $topicName"
    Remove-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName

    Write-Debug " Deleting resourcegroup $resourceGroupName"
    Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
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

    Write-Debug "Creating resource group"
    Write-Debug "ResourceGroup name : $resourceGroupName"
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force

    Write-Debug " Creating a new EventGrid Topic: $topicName in resource group $resourceGroupName"
    $result = New-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName -Location $location    
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    # Regenerate "key1"
    $sharedAccessKeys = New-AzureRmEventGridTopicKey -ResourceGroup $resourceGroupName -TopicName $topicName -KeyName "key1"
    Assert-True {$sharedAccessKeys.Count -eq 1}

    # Regenerate "key2" using the ResourceId parameter set
    $sharedAccessKeys = New-AzureRmEventGridTopicKey -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventGrid/topics/$topicName" -KeyName "key2"
    Assert-True {$sharedAccessKeys.Count -eq 1}

    # Regenerate "key2" using the Topic Input object
    $sharedAccessKeys = Get-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName | New-AzureRmEventGridTopicKey -KeyName "key2"
    Assert-True {$sharedAccessKeys.Count -eq 1}

    Write-Debug " Deleting topic: $topicName"
    Remove-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName

    Write-Debug " Deleting resourcegroup $resourceGroupName"
    Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
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
        Write-Debug " Creating a new EventGrid Topic: $topicName in resource group $resourceGroupName with InputSchema $inputSchemaInvalid"
        $result = New-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName -Location $location -InputSchema $inputSchemaInvalid
        Assert-True {$false} "New-AzureRmEventGridTopic succeeded while it is expected to fail"
    }
    catch
    {
        Assert-True {$true}
    }

    Write-Debug " Creating a new EventGrid Topic: $topicName in resource group $resourceGroupName with InputSchema $inputSchemaEventGridSchema1"
    $result = New-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName -Location $location -InputSchema $inputSchemaEventGridSchema1
    Assert-True {$result.ProvisioningState -eq "Succeeded"}
    Assert-True {$result.InputSchema -eq $expectedInputMappingEventGridSchema} "EventGridSchema is expected."

    Write-Debug "Getting the created topic within the resource group"
    $createdTopic = Get-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName
    Assert-True {$createdTopic.Count -eq 1}
    Assert-True {$createdTopic.TopicName -eq $topicName} "Topic created earlier is not found."
    Assert-True {$createdTopic.InputSchema -eq $expectedInputMappingEventGridSchema} "InputSchema is not correct. EventGridSchema is expected."

    Write-Debug "Creating a second EventGrid topic: $topicName2 in resource group $resourceGroupName with InputSchema $inputSchemaEventGridSchema2"
    $result = New-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName2 -Location $location -Tag @{ Dept = "IT"; Environment = "Test" } -InputSchema $inputSchemaEventGridSchema2
    Assert-True {$result.ProvisioningState -eq "Succeeded"}
    Assert-True {$result.InputSchema -eq $expectedInputMappingEventGridSchema} "InputSchema is not correct. EventGridSchema is expected"

    Write-Debug "Creating a third EventGrid topic: $topicName3 in resource group $resourceGroupName with InputSchema $inputSchemaCloudEventSchema1"
    $result = New-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName3 -Location $location -InputSchema $inputSchemaCloudEventSchema1
    Assert-True {$result.ProvisioningState -eq "Succeeded"}
    Assert-True {$result.InputSchema -eq $expectedInputMappingCloudEventSchema} "InputSchema is not correct. CloudEventSchema is expected."

    Write-Debug "Creating a fourth EventGrid topic: $topicName4 in resource group $resourceGroupName with InputSchema $inputSchemaCloudEventSchema2"
    $result = New-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName4 -Location $location -InputSchema $inputSchemaCloudEventSchema2
    Assert-True {$result.ProvisioningState -eq "Succeeded"}
    Assert-True {$result.InputSchema -eq $expectedInputMappingCloudEventSchema} "InputSchema is not correct. CloudEventSchema is expected."

    Write-Debug "Getting the created topic within the resource group"
    $createdTopic = Get-AzureRmEventGridTopic -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventGrid/topics/$topicName3"
    Assert-True {$createdTopic.Count -eq 1}
    Assert-True {$createdTopic.TopicName -eq $topicName3} "$topicName3 created earlier is not found."

    Write-Debug "Listing all the topics created in the resourceGroup $resourceGroupName"
    $allCreatedTopics = Get-AzureRmEventGridTopic -ResourceGroup $resourceGroupName

    Assert-True {$allCreatedTopics.Count -eq 4 } "Topics created earlier is not found in the list."

    Write-Debug "Getting all the topics created in the subscription"
    $allCreatedTopics = Get-AzureRmEventGridTopic

    Assert-True {$allCreatedtopic.Count -ge 0} "Topics created earlier are not found."

    try
    {
        Write-Debug "Creating a fifth EventGrid topic: $topicName5 in resource group $resourceGroupName with InputSchema $inputSchemaEventGridSchema1"
        $result = New-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName5 -Location $location -InputSchema $inputSchemaEventGridSchema1 -InputMappingFields @{ id = "MyIdField"; topic = "MyTopicField"; eventtime = "MyEventTimeField"; subject = "MySubjectField"; eventtype = "MyEventTypeField" }
        Assert-True {$false} "New-AzureRmEventGridTopic succeeded while it is expected to fail as inputmapping parameters is not null for input mapping schema EventGridSchema"
    }
    catch
    {
        Assert-True {$true}
    }

    try
    {
        Write-Debug "Creating a fifth EventGrid topic: $topicName5 in resource group $resourceGroupName with InputSchema $inputSchemaCloudEventSchema1"
        $result = New-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName5 -Location $location -InputSchema $inputSchemaCloudEventSchema1 -InputMappingFields @{ id = "MyIdField"; topic = "MyTopicField"; eventtime = "MyEventTimeField"; subject = "MySubjectField"; eventtype = "MyEventTypeField" }
        Assert-True {$false} "New-AzureRmEventGridTopic succeeded while it is expected to fail as inputmapping parameters is not null for input mapping schema CloudEventSchema"
    }
    catch
    {
        Assert-True {$true}
    }

    try
    {
        Write-Debug "Creating a fifth EventGrid topic: $topicName5 in resource group $resourceGroupName with InputSchema $inputSchemaCustomEventSchema1"
        $result = New-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName5 -Location $location -InputSchema $inputSchemaCustomEventSchema1
        Assert-True {$false} "New-AzureRmEventGridTopic succeeded while it is expected to fail as inputmapping parameters are null"
    }
    catch
    {
        Assert-True {$true}
    }

    Write-Debug "Creating a fifth EventGrid topic: $topicName5 in resource group $resourceGroupName with InputSchema $inputSchemaCustomEventSchema1"
    $result = New-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName5 -Location $location -InputSchema $inputSchemaCustomEventSchema1 -InputMappingFields @{ id = "MyIdField"; topic = "MyTopicField"; eventtime = "MyEventTimeField"; subject = "MySubjectField"; eventtype = "MyEventTypeField"; dataversion = "MyDataVersionField" }
    Assert-True {$result.ProvisioningState -eq "Succeeded"}
    Assert-True {$result.InputSchema -eq $expectedInputMappingCustomEventSchema} "InputSchema is not correct. CustomEventSchema is expected"

    Write-Debug "Creating a sixth EventGrid topic: $topicName6 in resource group $resourceGroupName with InputSchema $inputSchemaCustomEventSchema2"
    $result = New-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName6 -Location $location -InputSchema $inputSchemaCustomEventSchema2 -InputMappingFields @{ id = "MyIdField"; topic = "MyTopicField"; eventtime = "MyEventTimeField"; subject = "MySubjectField"; eventtype = "MyEventTypeField"; dataversion = "MyDataVersionField" } -InputMappingDefaultValues @{ subject = "MySubjectDefaultValue"; eventtype = "MyEventTypeDefaultValue"; dataversion = "MyDataVersionDefaultValue" }
    Assert-True {$result.ProvisioningState -eq "Succeeded"}
    Assert-True {$result.InputSchema -eq $expectedInputMappingCustomEventSchema} "InputSchema is not correct. CustomEventSchema is expected"

    Write-Debug "Getting the created topic within the resource group"
    $createdTopic = Get-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName5
    Assert-True {$createdTopic.Count -eq 1}
    Assert-True {$createdTopic.TopicName -eq $topicName5} "Topic created earlier is not found."
    Assert-True {$createdTopic.InputSchema -eq $expectedInputMappingCustomEventSchema} "InputSchema is not correct. CustomEventSchema is expected"

    Write-Debug " Deleting topic: $topicName"
    Remove-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName

    Write-Debug " Deleting topic: $topicName2 using the ResourceID parameter set"
    # Offline playback of tests is failing if I use Get-AzureRmResource, hence temporarily commenting this out
    # Get-AzureRmResource -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventGrid/topics/$topicName3" | Remove-AzureRmEventGridTopic
    Remove-AzureRmEventGridTopic -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.EventGrid/topics/$topicName2"

    Write-Debug " Deleting topic: $topicName3"
    Remove-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName3

    Write-Debug " Deleting topic: $topicName4"
    Remove-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName4

    Write-Debug " Deleting topic: $topicName5"
    Remove-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName5

    Write-Debug " Deleting topic: $topicName6"
    Remove-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName6

    # Verify that all topics have been deleted correctly
    $returnedTopics1 = Get-AzureRmEventGridTopic -ResourceGroup $resourceGroupName
    Assert-True {$returnedTopics1.Count -eq 0}

    $returnedTopics2 = Get-AzureRmEventGridTopic -ResourceGroup $resourceGroupName
    Assert-True {$returnedTopics2.Count -eq 0}

    Write-Debug " Deleting resourcegroup $resourceGroupName"
    Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}
