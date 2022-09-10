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
Removes an ServiceBus Namespace, Queue or Topic Authorization Rule
.Description
Removes an ServiceBus Namespace, Queue or Topic Authorization Rule
#>

function Remove-AzServiceBusAuthorizationRule{
	[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.ISbAuthorizationRule])]
    [CmdletBinding(DefaultParameterSetName = 'RemoveExpandedNamespace', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
	param(
        [Parameter(Mandatory, HelpMessage = "The name of the Authorization Rule")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [System.String]
        # The name of the Authorization Rule.
        ${Name},

        [Parameter(ParameterSetName = 'RemoveExpandedQueue', Mandatory, HelpMessage = "The name of the ServiceBus Queue entity.")]
        [Alias('Queue')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [System.String]
        # The name of the ServiceBus Queue entity.
        ${QueueName},

        [Parameter(ParameterSetName = 'RemoveExpandedTopic', Mandatory, HelpMessage = "The name of the ServiceBus Topic entity.")]
        [Alias('Topic')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [System.String]
        # The name of the ServiceBus Topic entity.
        ${TopicName},

        [Parameter(ParameterSetName = 'RemoveExpandedQueue', Mandatory, HelpMessage = "The name of Service Bus namespace")]
        [Parameter(ParameterSetName = 'RemoveExpandedTopic', Mandatory, HelpMessage = "The name of Service Bus namespace")]
        [Parameter(ParameterSetName = 'RemoveExpandedNamespace', Mandatory, HelpMessage = "The name of Service Bus namespace")]
        [Alias('Namespace')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [System.String]
        # The name of ServiceBus namespace
        ${NamespaceName},

        [Parameter(Mandatory, HelpMessage = "The name of the resource group. The name is case insensitive.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [System.String]
        # The name of the resource group.
        # The name is case insensitive.
        ${ResourceGroupName},

        [Parameter(HelpMessage = "The ID of the target subscription.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter(ParameterSetName = 'RemoveViaIdentityExpanded', Mandatory, ValueFromPipeline, HelpMessage = "Identity parameter. To construct, see NOTES section for INPUTOBJECT properties and create a hash table.")]
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

        [Parameter(HelpMessage = "Run the command as a job")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},

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

        [Parameter(HelpMessage = "Run the command asynchronously")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},

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

            if ($PSCmdlet.ParameterSetName -eq 'RemoveExpandedNamespace'){
                if ($PSCmdlet.ShouldProcess("ServiceBus Namespace Authorization Rule $($Name)", "Deleting")) {
                    Az.ServiceBus.private\Remove-AzServiceBusNamespaceAuthorizationRule_Delete @PSBoundParameters
                }
            }

            elseif ($PSCmdlet.ParameterSetName -eq 'RemoveExpandedQueue'){
                if ($PSCmdlet.ShouldProcess("ServiceBus Queue Authorization Rule $($Name)", "Deleting")) {
                    Az.ServiceBus.private\Remove-AzServiceBusQueueAuthorizationRule_Delete @PSBoundParameters
                }
            }

            elseif ($PSCmdlet.ParameterSetName -eq 'RemoveExpandedTopic'){
                if ($PSCmdlet.ShouldProcess("ServiceBus Topic Authorization Rule $($Name)", "Deleting")) {
                    Az.ServiceBus.private\Remove-AzServiceBusTopicAuthorizationRule_Delete @PSBoundParameters
                }
            }

            elseif ($PSCmdlet.ParameterSetName -eq 'RemoveViaIdentityExpanded'){
                
                if($InputObject.Id -ne $null){
                    $ResourceHashTable = ParseResourceId -ResourceId $InputObject.Id
                }
                else{
                    $ResourceHashTable = ParseResourceId -ResourceId $InputObject
                }
                
                if ($ResourceHashTable['QueueName'] -ne $null){
                    if ($PSCmdlet.ShouldProcess("ServiceBus Queue Authorization Rule $($ResourceHashTable['AuthorizationRuleName'])", "Deleting")) {
                        Az.ServiceBus.private\Remove-AzServiceBusQueueAuthorizationRule_DeleteViaIdentity @PSBoundParameters
                    }
                }
                elseif ($ResourceHashTable['TopicName'] -ne $null){
                    if ($PSCmdlet.ShouldProcess("ServiceBus Entity Authorization Rule $($ResourceHashTable['AuthorizationRuleName'])", "Deleting")) {
                        Az.ServiceBus.private\Remove-AzServiceBusTopicAuthorizationRule_DeleteViaIdentity @PSBoundParameters
                    }
                }
                elseif ($ResourceHashTable['NamespaceName'] -ne $null){
                    if ($PSCmdlet.ShouldProcess("ServiceBus Namespace Authorization Rule $($ResourceHashTable['AuthorizationRuleName'])", "Deleting")) {
                        Az.ServiceBus.private\Remove-AzServiceBusNamespaceAuthorizationRule_DeleteViaIdentity @PSBoundParameters
                    }
                }
                else{
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
    $indexResourceGroup = 0..($array.Length -1) | where {$array[$_] -eq 'resourcegroups'}
    $indexNamespace = 0..($array.Length -1) | where {$array[$_] -eq 'namespaces'}
    $indexQueue = 0..($array.Length -1) | where {$array[$_] -eq 'queues'}
    $indexTopic = 0..($array.Length -1) | where {$array[$_] -eq 'topics'}
    $indexAuthRule = 0..($array.Length -1) | where {$array[$_] -eq 'authorizationrules'}

    if(($indexResourceGroup -eq $null) -or ($indexNamespace -eq $null) -or ($indexAuthRule -eq $null)){
        throw 'Invalid -InputObject Id'
    }
    
    if (($indexResourceGroup+1) > $array.Length){
        throw 'Invalid -InputObject Id'
    }
    if (($indexNamespace+1) > $array.Length){
        throw 'Invalid -InputObject Id'
    }
    if (($indexAuthRule+1) > $array.Length){
        throw 'Invalid -InputObject Id'
    }

    $result = @{
        'ResourceGroupName' = $array.get($indexResourceGroup+1)
        'NamespaceName' = $array.get($indexNamespace+1)
        'AuthorizationRuleName' = $array.get($indexAuthRule+1)
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

    return $result
}
