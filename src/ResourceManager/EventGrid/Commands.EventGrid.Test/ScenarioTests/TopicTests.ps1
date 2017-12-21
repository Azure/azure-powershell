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
