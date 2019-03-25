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
Get Hybrid Connection ResourceId
#>
function Get-HybridConnectionResourceId
{
    return "/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/DevExpRg/providers/Microsoft.Relay/namespaces/DevExpRelayNamespace/hybridConnections/hydbridconnectiondestination"
}

<#
.SYNOPSIS
Get Storage Destination ResourceId
#>
function Get-StorageDestinationResourceId
{
    return "/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/DevExpRg/providers/Microsoft.Storage/storageAccounts/devexpstg/queueServices/default/queues/stogqueuedestination"
}

<#
.SYNOPSIS
Get ServiceBus Queue ResourceId
#>
function Get-ServiceBusQueueResourceId
{
    return "/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/DevExpRg/providers/Microsoft.ServiceBus/namespaces/devexpservicebus/queues/devexpdestination"
}

<#
.SYNOPSIS
Get Deadletter ResourceId
#>
function Get-DeadletterResourceId
{
    return "/subscriptions/5b4b650e-28b9-4790-b3ab-ddbd88d727c4/resourceGroups/DevExpRg/providers/Microsoft.Storage/storageAccounts/devexpstg/blobServices/default/containers/dlq"
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

<#
.SYNOPSIS
Get location
#>
function Get-LocationForEventGrid
{
    return "centraluseuap"
}

<#
.SYNOPSIS
Get EventHub namespace name
#>
function Get-EventHubNamespaceName
{
  return "PSTestEH-" + (getAssetName)
}