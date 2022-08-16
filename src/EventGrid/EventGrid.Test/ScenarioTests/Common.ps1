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
Get Subscription ID
#>
function Get-SubscriptionID
{
    $context = Get-AzContext
    return $context.Subscription.SubscriptionId
}

<#
.SYNOPSIS
Get ResourceGroup name
#>
function Get-ResourceGroupName
{
    return "RGName-" + (getAssetName)
}

<#
.SYNOPSIS
Create new ResourceGroup
#>
function New-ResourceGroup($ResourceGroupName, $Location)
{
    Write-Debug "Creating resource group name $ResourceGroupName in location $Location"
    New-AzResourceGroup -Name $ResourceGroupName -Location $Location -Force
}

<#
.SYNOPSIS
Remove ResourceGroup
#>
function Remove-ResourceGroup($ResourceGroupName)
{
    Write-Debug "Deleting resource group name $ResourceGroupName"
    Remove-AzResourceGroup -Name $ResourceGroupName -Force
}

<#
.SYNOPSIS
Get EventSubscription name
#>
function Get-EventSubscriptionName
{
    return "EventSubscription-" + (getAssetName)
}

<#
.SYNOPSIS
Get EventSubscription Azure Function Endpoint
#>
function Get-EventSubscriptionAzureFunctionEndpoint
{
    return "/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/DevExpRg/providers/Microsoft.Web/sites/eventgridclitestapp/functions/EventGridTrigger1"
}

<#
.SYNOPSIS
Get EventSubscription Webhook Endpoint
#>
function Get-EventSubscriptionWebhookEndpoint
{
    return "https://devexpfuncappdestination.azurewebsites.net/runtime/webhooks/EventGrid?functionName=EventGridTrigger1&code=<HIDDEN>"
}

<#
.SYNOPSIS
Get EventSubscription Webhook Endpoint
#>
function Get-EventSubscriptionWebhookBaseEndpoint
{
    return "https://devexpfuncappdestination.azurewebsites.net/runtime/webhooks/EventGrid"
}

<#
.SYNOPSIS
Get EventSubscription Webhook Endpoint With Cloud Event
#>
function Get-EventSubscriptionWebhookEndpointWithCloudEvent
{
    return "https://eventgridclitestapp.azurewebsites.net/api/cloudeventfunc?code=<HIDDEN>"
}

<#
.SYNOPSIS
Get EventSubscription Webhook Endpoint With Cloud Event
#>
function Get-EventSubscriptionWebhookBaseEndpointWithCloudEvent
{
    return "https://eventgridclitestapp.azurewebsites.net/api/cloudeventfunc"
}

<#
.SYNOPSIS
Get location
#>
function Get-LocationForEventGrid
{
    return "westcentralus"
}

<#
.SYNOPSIS
Get EventHub namespace name
#>
function Get-EventHubNamespaceName
{
    return "PSTestEH-" + (getAssetName)
}

<#
.SYNOPSIS
Get HybridConnection NameSpace Name
#>
function Get-HybridConnNameSpaceName
{
    return "hcnamespace-" + (getAssetName)
}

<#
.SYNOPSIS
Get HybridConnection Name
#>
function Get-HybridConnName
{
    return "hcname-" + (getAssetName)
}

<#
.SYNOPSIS
Get Hybrid Connection ResourceId
#>
function Get-HybridConnectionResourceId($ResourceGroupName, $NamespaceName, $HybridConnectionName)
{
    $subId = Get-SubscriptionID
    return "/subscriptions/$subId/resourceGroups/$ResourceGroupName/providers/Microsoft.Relay/namespaces/$NamespaceName/hybridConnections/$HybridConnectionName"
}

<#
.SYNOPSIS
Create new HybridConnection
#>
function New-HybridConnection($ResourceGroupName, $NamespaceName, $HybridConnectionName, $Location)
{
    Write-Debug "Creating namespace $NamespaceName in resource group $ResourceGroupName and location $Location"
    New-AzRelayNamespace -ResourceGroupName $ResourceGroupName -Name $NamespaceName -Location $Location
    Write-Debug "Creating hybridconnection $HybridConnectionName in Namespace $NamespaceName in resource group $ResourceGroupName and location $Location"
    New-AzRelayHybridConnection -ResourceGroupName $ResourceGroupName -Namespace $NamespaceName -Name $HybridConnectionName -RequiresClientAuthorization $True
}

<#
.SYNOPSIS
Remove HybridConnection
#>
function Remove-HybridConnectionResources($ResourceGroupName, $NamespaceName, $HybridConnectionName)
{
    Write-Debug "Deleting hybridconnection $HybridConnectionName in Namespace $NamespaceName in resource group $ResourceGroupName and location $Location"
    Remove-AzRelayHybridConnection -ResourceGroupName $ResourceGroupName -Namespace $NamespaceName -Name $HybridConnectionName
    Write-Debug "Deleting namespace $NamespaceName in resource group $ResourceGroupName and location $Location"
    Remove-AzRelayNamespace -ResourceGroupName $ResourceGroupName -Name $NamespaceName
}

<#
.SYNOPSIS
Get ServiceBus NameSpace Name
#>
function Get-ServiceBusNameSpaceName
{
    return "sbnamespace-" + (getAssetName)
}

<#
.SYNOPSIS
Get ServiceBus Queue Name
#>
function Get-ServiceBusQueueName
{
    return "sbqueuename-" + (getAssetName)
}

<#
.SYNOPSIS
Get ServiceBus Topic Name
#>
function Get-ServiceBusTopicName
{
    return "sbtopicname-" + (getAssetName)
}

<#
.SYNOPSIS
Get ServiceBus Queue ResourceId
#>
function Get-ServiceBusQueueResourceId($ResourceGroupName, $NamespaceName, $QueueName)
{
    $subId = Get-SubscriptionID
    return "/subscriptions/$subId/resourceGroups/$ResourceGroupName/providers/Microsoft.ServiceBus/namespaces/$NamespaceName/queues/$QueueName"
}

<#
.SYNOPSIS
Create new ServiceBus Queue
#>
function New-ServiceBusQueue($ResourceGroupName, $NamespaceName, $QueueName, $Location)
{
    $DefaultMessageTimeToLiveTimeSpan = New-TimeSpan -Minute 1
    Write-Debug "Creating ServiceBus queue $QueueName in Namespace $NamespaceName in resource group $ResourceGroupName and location $Location"
    New-AzServiceBusQueue -ResourceGroupName $ResourceGroupName -Namespace $NamespaceName -Name $QueueName -RequiresSession $False -EnablePartitioning $True -DefaultMessageTimeToLive $DefaultMessageTimeToLiveTimeSpan
}

<#
.SYNOPSIS
Remove ServiceBus Queue
#>
function Remove-ServiceBusQueueResources($ResourceGroupName, $NamespaceName, $QueueName)
{
    Write-Debug "Deleting ServiceBus queue $QueueName in Namespace $NamespaceName in resource group $ResourceGroupName"
    Remove-AzServiceBusQueue -ResourceGroupName $ResourceGroupName -Namespace $NamespaceName -Name $QueueName
}

<#
.SYNOPSIS
Get ServiceBus Topic ResourceId
#>
function Get-ServiceBusTopicResourceId($ResourceGroupName, $NamespaceName, $TopicName)
{
    $subId = Get-SubscriptionID
    return "/subscriptions/$subId/resourceGroups/$ResourceGroupName/providers/Microsoft.ServiceBus/namespaces/$NamespaceName/topics/$TopicName"
}

<#
.SYNOPSIS
Create new ServiceBus Namespace
#>
function New-ServiceBusNamespace($ResourceGroupName, $NamespaceName, $Location)
{
    Write-Debug "Creating ServiceBus namespace $NamespaceName in resource group $ResourceGroupName and location $Location"
    New-AzServiceBusNamespace -ResourceGroupName $ResourceGroupName -Name $NamespaceName -Location $Location
}

<#
.SYNOPSIS
Remove ServiceBus Topic
#>
function Remove-ServiceBusTopicResources($ResourceGroupName, $NamespaceName, $TopicName)
{
    Write-Debug "Deleting ServiceBus topic $TopicName in Namespace $NamespaceName in resource group $ResourceGroupName"
    Remove-AzServiceBusTopic -ResourceGroupName $ResourceGroupName -NamespaceName $NamespaceName -TopicName $TopicName
}

<#
.SYNOPSIS
Remove ServiceBus Namespace
#>
function Remove-ServiceBusNamespaceResources($ResourceGroupName, $NamespaceName)
{
    Write-Debug "Deleting ServiceBus namespace $NamespaceName in resource group $ResourceGroupName"
    Remove-AzServiceBusNamespace -ResourceGroupName $ResourceGroupName -Name $NamespaceName
}

<#
.SYNOPSIS
Create new ServiceBus Topic
#>
function New-ServiceBusTopic($ResourceGroupName, $NamespaceName, $TopicName)
{
    Write-Debug "Creating ServiceBus topic $TopicName in Namespace $NamespaceName in resource group $ResourceGroupName"
    New-AzServiceBusTopic -ResourceGroup $ResourceGroupName -NamespaceName $NamespaceName -TopicName $TopicName -EnablePartitioning $True
}

<#
.SYNOPSIS
Get Storage Account Name
#>
function Get-StorageAccountName
{
    # Storage account name must be between 3 and 24 characters in length and use numbers and lower-case letters only.
    return "storagename" + (getAssetName)
}

<#
.SYNOPSIS
Get StorageQueue Name
#>
function Get-StorageQueueName
{
    return "storagequeuename" + (getAssetName)
}

<#
.SYNOPSIS
Get Storage Queue Destination ResourceId
#>
function Get-StorageDestinationResourceId($ResourceGroupName, $StorageAccountName, $QueueName)
{
    $subId = Get-SubscriptionID
    return "/subscriptions/$subId/resourceGroups/$ResourceGroupName/providers/Microsoft.Storage/storageAccounts/$StorageAccountName/queueServices/default/queues/$QueueName"
}

<#
.SYNOPSIS
Create new Storage Queue
#>
function New-StorageQueue($ResourceGroupName, $StorageAccountName, $QueueName, $Location)
{
    Write-Debug "Creating Storage Account $StorageAccountName in resource group $ResourceGroupName and location $Location"
    $StorageAccount = New-AzStorageAccount -Name $StorageAccountName -ResourceGroupName $ResourceGroupName -SkuName Standard_LRS -Location $Location -Kind StorageV2 -AccessTier Hot
    $storageAccountKeyValue = $(Get-AzStorageAccountKey -ResourceGroupName $ResourceGroupName -Name $StorageAccountName)[0].Value
    $cxt = New-AzStorageContext -StorageAccountName $StorageAccountName -StorageAccountKey $storageAccountKeyValue

    # NOTE: Uncomment when live recording
    #### New-AzStorageQueue -Name $StorageQueueName -Context $cxt
}

<#
.SYNOPSIS
Remove Storage Resources (Queue and Account)
#>
function Remove-StorageResources($ResourceGroupName, $StorageAccountName, $QueueName)
{
    Write-Debug "Deleting Storage queue $QueueName in Storage Account $StorageAccountName"
    $StorageAccount = Get-AzStorageAccount -ResourceGroupName $ResourceGroupName -AccountName $StorageAccountName
    $storageAccountKeyValue = $(Get-AzStorageAccountKey -ResourceGroupName $ResourceGroupName -Name $StorageAccountName)[0].Value
    $cxt = New-AzStorageContext -StorageAccountName $StorageAccountName -StorageAccountKey $storageAccountKeyValue

    # NOTE: Uncomment when live recording
    #### Remove-AzStorageQueue -Name $QueueName -Context $cxt -Force

    Write-Debug "Deleting storage account $StorageAccount in resource group $ResourceGroupName"
    Remove-AzStorageAccount -ResourceGroupName $ResourceGroupName -Name $StorageAccountName -Force
}

<#
.SYNOPSIS
Get StorageBlob Name
#>
function Get-StorageBlobName
{
    return "storageblobname" + (getAssetName)
}

<#
.SYNOPSIS
Get Storage Blob Container Deadletter ResourceId
#>
function Get-DeadletterResourceId($ResourceGroupName, $StorageAccountName, $ContainerName)
{
    $subId = Get-SubscriptionID
    return "/subscriptions/$subId/resourceGroups/$ResourceGroupName/providers/Microsoft.Storage/storageAccounts/$StorageAccountName/blobServices/default/containers/$ContainerName"
}

<#
.SYNOPSIS
Get Storage Account ResourceId
#>
function Get-StorageAccountResourceId($ResourceGroupName, $StorageAccountName)
{
    $subId = Get-SubscriptionID
    return "/subscriptions/$subId/resourceGroups/$ResourceGroupName/providers/Microsoft.Storage/storageAccounts/$StorageAccountName"
}

<#
.SYNOPSIS
Create new Storage Blob
#>
function New-StorageBlob($ResourceGroupName, $StorageAccountName, $ContainerName, $Location)
{
    Write-Debug "Creating Storage Account $StorageAccountName in resource group $ResourceGroupName and location $Location"
    $storageAccount = New-AzStorageAccount -Name $StorageAccountName -ResourceGroupName $ResourceGroupName -SkuName Standard_LRS -Location $Location
    $storageAccountKeyValue = $(Get-AzStorageAccountKey -ResourceGroupName $ResourceGroupName -Name $StorageAccountName)[0].Value
    $cxt = New-AzStorageContext -StorageAccountName $storageAccountName -StorageAccountKey $storageAccountKeyValue

    # NOTE: Uncomment when live recording
    #### New-AzStoragecontainer -Name $ContainerName -Context $cxt
}

<#
.SYNOPSIS
Remove Storage Resources (Queue and Account)
#>
function Remove-StorageContainerResources($ResourceGroupName, $StorageAccountName, $ContainerName)
{
    Write-Debug "Deleting Storage blob $ContainerName in Storage Account $StorageAccountName"
    $StorageAccount = Get-AzStorageAccount -ResourceGroupName $ResourceGroupName -AccountName $StorageAccountName
    $storageAccountKeyValue = $(Get-AzStorageAccountKey -ResourceGroupName $ResourceGroupName -Name $StorageAccountName)[0].Value
    $cxt = New-AzStorageContext -StorageAccountName $StorageAccountName -StorageAccountKey $storageAccountKeyValue
    # NOTE: Uncomment when live recording
    #### Remove-AzStorageContainer -Name $ContainerName -Context $cxt
    Write-Debug "Deleting storage account $StorageAccount in resource group $ResourceGroupName"
    Remove-AzStorageAccount -ResourceGroupName $ResourceGroupName -Name $StorageAccountName -Force
}

<#
.SYNOPSIS
Get topic name
#>
function Get-TopicName
{
    return "PSTestTopic-" + (getAssetName)
}

<#
.SYNOPSIS
Get domain name
#>
function Get-DomainName
{
    return "PSTestDomain-" + (getAssetName)
}

<#
.SYNOPSIS
Get domain topic name
#>
function Get-DomainTopicName
{
    return "PSTestDomainTopic-" + (getAssetName)
}
