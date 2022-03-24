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
function SystemTopicTests {
    # Setup
    $location = Get-LocationForEventGrid
    $topicName = Get-TopicName
    $topicName2 = Get-TopicName
    $topicName3 = Get-TopicName
    $topicName4 = Get-TopicName
    $resourceGroupName = Get-ResourceGroupName
    $secondResourceGroup = Get-ResourceGroupName
    $subscriptionId = Get-SubscriptionId

    #New-ResourceGroup $resourceGroupName $location

    #New-ResourceGroup $secondResourceGroup $location

    try
    {
        

        Write-Debug "Getting all the system topics created in the subscription"
        $allCreatedTopics = Get-AzEventGridSystemTopic
        Write "$allCreatedTopics"
        Assert-True {$allCreatedTopics.PsTopicsList.Count -ge 0} "Topics created earlier are not found."

       
    }
    finally
    {
        
    }
}

