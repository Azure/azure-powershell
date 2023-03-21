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
.Synopsis
Gets the Authorization Rule of a ServiceBus namespace, queue or topic.
.Description
Gets the Authorization Rule of a ServiceBus namespace, queue or topic.
#>

function Get-AzServiceBusAuthorizationRule{
	[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ISbAuthorizationRule])]
    [CmdletBinding(DefaultParameterSetName = 'GetExpandedNamespace', PositionalBinding = $false, ConfirmImpact = 'Medium')]
	param(
        [Parameter(ParameterSetName = 'GetExpandedQueue', HelpMessage = "The name of the Authorization Rule")]
        [Parameter(ParameterSetName = 'GetExpandedTopic', HelpMessage = "The name of the Authorization Rule")]
        [Parameter(ParameterSetName = 'GetExpandedNamespace', HelpMessage = "The name of the Authorization Rule")]
        [Parameter(ParameterSetName = 'GetExpandedAlias', HelpMessage = "The name of the Authorization Rule")]
        [Alias('AuthorizationRuleName')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [System.String]
        # The name of the Authorization Rule.
        ${Name},

        [Parameter(ParameterSetName = 'GetExpandedAlias', Mandatory, HelpMessage = "The name of the disaster recovery config")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [System.String]
        # The name of the disaster recovery config
        ${AliasName},

        [Parameter(ParameterSetName = 'GetExpandedQueue', Mandatory, HelpMessage = "The name of the Service Bus queue.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [System.String]
        # The name of the Service Bus queue.
        ${QueueName},

        [Parameter(ParameterSetName = 'GetExpandedTopic', Mandatory, HelpMessage = "The name of the Service Bus topic.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [System.String]
        # The name of the Service Bus topic.
        ${TopicName},

        [Parameter(ParameterSetName = 'GetExpandedNamespace', Mandatory, HelpMessage = "The name of ServiceBus namespace")]
        [Parameter(ParameterSetName = 'GetExpandedQueue', Mandatory, HelpMessage = "The name of the ServiceBus namespace.")]
        [Parameter(ParameterSetName = 'GetExpandedTopic', Mandatory, HelpMessage = "The name of the ServiceBus namespace.")]
        [Parameter(ParameterSetName = 'GetExpandedAlias', Mandatory, HelpMessage = "The name of the ServiceBus namespace.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [System.String]
        # The name of ServiceBus namespace
        ${NamespaceName},

        [Parameter(ParameterSetName = 'GetExpandedNamespace', Mandatory, HelpMessage = "The name of the resource group. The name is case insensitive.")]
        [Parameter(ParameterSetName = 'GetExpandedQueue', Mandatory, HelpMessage = "The name of the resource group. The name is case insensitive.")]
        [Parameter(ParameterSetName = 'GetExpandedTopic', Mandatory, HelpMessage = "The name of the resource group. The name is case insensitive.")]
        [Parameter(ParameterSetName = 'GetExpandedAlias', Mandatory, HelpMessage = "The name of the resource group. The name is case insensitive.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [System.String]
        # The name of the resource group.
        # The name is case insensitive.
        ${ResourceGroupName},

        [Parameter(ParameterSetName = 'GetExpandedNamespace', HelpMessage = "The ID of the target subscription.")]
        [Parameter(ParameterSetName = 'GetExpandedQueue', HelpMessage = "The ID of the target subscription.")]
        [Parameter(ParameterSetName = 'GetExpandedTopic', HelpMessage = "The ID of the target subscription.")]
        [Parameter(ParameterSetName = 'GetExpandedAlias', HelpMessage = "The ID of the target subscription.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        [System.String[]]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter(ParameterSetName = 'GetViaIdentityExpanded', Mandatory, ValueFromPipeline, HelpMessage = "Identity parameter. To construct, see NOTES section for INPUTOBJECT properties and create a hash table.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IServiceBusIdentity]
        # Identity Parameter
        # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
        ${InputObject},
		
        [Parameter(HelpMessage = "The credentials, account, tenant, and subscription used for communication with Azure.")]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
	)
	process{
		try{
            $null = $PSBoundParameters.Remove('WhatIf')
            $null = $PSBoundParameters.Remove('Confirm')

            if ($PSCmdlet.ParameterSetName -eq 'GetExpandedNamespace') {
                if(-not $PSBoundParameters.ContainsKey('Name')) {
                    Az.ServiceBus.private\Get-AzServiceBusNamespaceAuthorizationRule_List @PSBoundParameters
                }
                else {
                    Az.ServiceBus.private\Get-AzServiceBusNamespaceAuthorizationRule_Get @PSBoundParameters
                }
            }

            elseif ($PSCmdlet.ParameterSetName -eq 'GetExpandedQueue'){
                if (-not $PSBoundParameters.ContainsKey('Name')) {
                    Az.ServiceBus.private\Get-AzServiceBusQueueAuthorizationRule_List @PSBoundParameters
                }
                else {
                    Az.ServiceBus.private\Get-AzServiceBusQueueAuthorizationRule_Get @PSBoundParameters
                }
            }

            elseif ($PSCmdlet.ParameterSetName -eq 'GetExpandedTopic'){
                if (-not $PSBoundParameters.ContainsKey('Name')) {
                    Az.ServiceBus.private\Get-AzServiceBusTopicAuthorizationRule_List @PSBoundParameters
                }
                else {
                    Az.ServiceBus.private\Get-AzServiceBusTopicAuthorizationRule_Get @PSBoundParameters
                }
            }

            elseif ($PSCmdlet.ParameterSetName -eq 'GetExpandedAlias'){
                $null = $PSBoundParameters.Remove('AliasName')
                if (-not $PSBoundParameters.ContainsKey('Name')) {
                    Az.ServiceBus.private\Get-AzServiceBusDisasterRecoveryConfigAuthorizationRule_List -Alias $AliasName @PSBoundParameters
                }
                else {
                    Az.ServiceBus.private\Get-AzServiceBusDisasterRecoveryConfigAuthorizationRule_Get -Alias $AliasName @PSBoundParameters
                }
            }

            elseif ($PSCmdlet.ParameterSetName -eq 'GetViaIdentityExpanded'){

                if($InputObject.Id -ne $null) {
                    $ResourceHashTable = ParseResourceId -ResourceId $InputObject.Id
                }
                else {
                    $ResourceHashTable = ParseResourceId -ResourceId $InputObject
                }

                if ($ResourceHashTable['QueueName'] -ne $null) {
                    Az.ServiceBus.private\Get-AzServiceBusQueueAuthorizationRule_GetViaIdentity @PSBoundParameters
                }
                elseif ($ResourceHashTable['TopicName'] -ne $null) {
                    Az.ServiceBus.private\Get-AzServiceBusTopicAuthorizationRule_GetViaIdentity @PSBoundParameters
                }
                elseif ($ResourceHashTable['AliasName'] -ne $null) {
                    Az.ServiceBus.private\Get-AzServiceBusDisasterRecoveryConfigAuthorizationRule_GetViaIdentity @PSBoundParameters
                }
                elseif ($ResourceHashTable['NamespaceName'] -ne $null) {
                    Az.ServiceBus.private\Get-AzServiceBusNamespaceAuthorizationRule_GetViaIdentity @PSBoundParameters
                }
                else {
                    throw 'Invalid -InputObject'
                }

            }
		}
		catch{
			throw
		}
	}
}

function ParseResourceId{
    param (
        [string]$ResourceId
    )
    $array = $resourceID.ToLower().Split('/')
    $indexSubscription = 0..($array.Length -1) | where {$array[$_] -eq 'subscriptions'}
    $indexResourceGroup = 0..($array.Length -1) | where {$array[$_] -eq 'resourcegroups'}
    $indexNamespace = 0..($array.Length -1) | where {$array[$_] -eq 'namespaces'}
    $indexQueue = 0..($array.Length -1) | where {$array[$_] -eq 'queues'}
    $indexTopic = 0..($array.Length -1) | where {$array[$_] -eq 'topics'}
    $indexAlias = 0..($array.Length -1) | where {$array[$_] -eq 'disasterrecoveryconfigs'}
    $indexAuthRule = 0..($array.Length -1) | where {$array[$_] -eq 'authorizationrules'}
    
    if (($indexResourceGroup+1) > $array.Length){
        throw 'Invalid -InputObject Id'
    }
    if (($indexNamespace+1) > $array.Length){
        throw 'Invalid -InputObject Id'
    }

    $result = @{
        'ResourceGroupName' = $array.get($indexResourceGroup+1)
        'NamespaceName' = $array.get($indexNamespace+1)
    }

    if ($indexQueue -ne $null){
        if (($indexQueue+1) > $array.Length){
            throw 'Invalid -InputObject Id'
        }
        else{
            $result.add('QueueName', $array.get($indexQueue+1))
        }
    }

    if ($indexTopic -ne $null){
        if (($indexTopic+1) > $array.Length){
            throw 'Invalid -InputObject Id'
        }
        else{
            $result.add('TopicName', $array.get($indexTopic+1))
        }
    }

    if ($indexSubscription -ne $null){
        if (($indexSubscription+1) > $array.Length){
            throw 'Invalid -InputObject Id'
        }
        else{
            $result.add('SubscriptionName', $array.get($indexSubscription+1))
        }
    }

    if ($indexAuthRule -ne $null){
        if (($indexAuthRule+1) > $array.Length){
            throw 'Invalid -InputObject Id'
        }
        else{
            $result.add('AuthorizationRuleName', $array.get($indexAuthRule+1))
        }
    }

    if ($indexAlias -ne $null){
        if (($indexAlias+1) > $array.Length){
            throw 'Invalid -InputObject Id'
        }
        else{
            $result.add('AliasName', $array.get($indexAlias+1))
        }
    }

    return $result
}
