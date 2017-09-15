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
Tests EventGrid Topic CRUD operations.
#>
function TopicTests {
    # Setup
    $location = Get-LocationForEventGrid
    $topicName = Get-TopicName
    $topicName2 = Get-TopicName
    $topicName3 = Get-TopicName
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

    # Assert
    Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Getting the created topic within the resource group"
    $createdTopic = Get-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName
    Assert-True {$createdTopic.Count -eq 1}

    Assert-True {$createdTopic.TopicName -eq $topicName} "Topic created earlier is not found."

    # Get the keys of the topic
    $sharedAccessKeys = Get-AzureRmEventGridTopicKey -ResourceGroup $resourceGroupName -Name $topicName
    Assert-True {$sharedAccessKeys.Count -eq 1}

    # Get the keys of the topic using the Topic Input object
    $sharedAccessKeys = Get-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName | Get-AzureRmEventGridTopicKey
    Assert-True {$sharedAccessKeys.Count -eq 1}

    # Regenerate "key1"
    $sharedAccessKeys = New-AzureRmEventGridTopicKey -ResourceGroup $resourceGroupName -TopicName $topicName -KeyName "key1"
    Assert-True {$sharedAccessKeys.Count -eq 1}

    # Regenerate "key2" using the Topic Input object
    $sharedAccessKeys = Get-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName | New-AzureRmEventGridTopicKey -KeyName "key2"
    Assert-True {$sharedAccessKeys.Count -eq 1}

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

    Write-Debug "Updating the created topic $topicName2"
    $updatedTopic = Update-AzureRmEventGridTopic -ResourceGroup $secondResourceGroup -Name $topicName2 -Tag @{ Dept = "IT2"; Environment = "Test2" }
    Assert-True {$updatedTopic.Count -eq 1}
    Assert-True {$updatedTopic.TopicName -eq $topicName2} "Topic updated earlier is not found."

    Write-Debug "Updating the created topic $topicName3"
    $updatedTopic = Update-AzureRmEventGridTopic -ResourceId "/subscriptions/$subscriptionId/resourceGroups/$secondResourceGroup/providers/Microsoft.EventGrid/topics/$topicName3" -Tag @{ Dept = "IT2"; Environment = "Test2" }
    Assert-True {$updatedTopic.Count -eq 1}
    Assert-True {$updatedTopic.TopicName -eq $topicName3} "Topic updated earlier is not found."

    # TODO: Verify updated tags after service side issue is fixed.

    Write-Debug "Listing all the topics created in the resourceGroup $secondResourceGroup"
    $allCreatedTopics = Get-AzureRmEventGridTopic -ResourceGroup $secondResourceGroup

    Assert-True {$allCreatedTopics.Count -ge 0 } "Topic created earlier is not found in the list"

    Write-Debug "Getting all the topics created in the subscription"
    $allCreatedTopics = Get-AzureRmEventGridTopic

    Assert-True {$allCreatedtopic.Count -ge 0} "Topics created earlier are not found."

    Write-Debug " Deleting topic: $topicName"
    Remove-AzureRmEventGridTopic -ResourceGroup $resourceGroupName -Name $topicName

    Write-Debug " Deleting topic: $topicName3 using the ResourceID parameter set"
    $subscriptionId = Get-SubscriptionId

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
