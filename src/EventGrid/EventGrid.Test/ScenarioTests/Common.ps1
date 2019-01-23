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
Get EventSubscription name
#>
function Get-EventSubscriptionName
{
    return "EventSubscription-" + (getAssetName)
}

<#
.SYNOPSIS
Get EventSubscription Webhook Endpoint
#>
function Get-EventSubscriptionWebhookEndpoint
{
    return "https://eventgridrunnerfunction.azurewebsites.net/api/HttpTriggerCSharp1?code=<HIDDEN>"
}

<#
.SYNOPSIS
Get Hybrid Connection ResourceId
#>
function Get-HybridConnectionResourceId
{
    return "/subscriptions/$subscriptionId/resourceGroups/<ResourceGroupName>/providers/Microsoft.Relay/namespaces/<NameSpace>/hybridConnections/<HybridConnectionName>"
}

<#
.SYNOPSIS
Get Storage Destination ResourceId
#>
function Get-StorageDestinationResourceId
{
    return "/subscriptions/$subscriptionId/resourceGroups/<ResourceGroupName>/providers/Microsoft.Storage/storageAccounts/<StorageAccountName>/queueServices/default/queues/<QueueName>"
}

<#
.SYNOPSIS
Get EventSubscription Webhook Endpoint
#>
function Get-EventSubscriptionWebhookBaseEndpoint
{
    return "https://eventgridrunnerfunction.azurewebsites.net/api/HttpTriggerCSharp1"
}

<#
.SYNOPSIS
Get Deadletter ResourceId
#>
function Get-DeadletterResourceId
{
    return "/subscriptions/$subscriptionId/resourceGroups/<ResourceGroupName>/providers/microsoft.Storage/storageAccounts/<StorageAccountName>/blobServices/default/containers/<ContainerName>"
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
Get location
#>
function Get-LocationForEventGrid
{
    return "westus2"
}

<#
.SYNOPSIS
Get EventHub namespace name
#>
function Get-EventHubNamespaceName
{
  return "PSTestEH-" + (getAssetName)
}