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
Gets the SASKey of a ServiceBus namespace, queue or topic.
.Description
Gets the SASKey of a ServiceBus namespace, queue or topic.
#>

function Get-AzServiceBusKey{
	[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api20221001Preview.IAccessKeys])]
    [CmdletBinding(DefaultParameterSetName = 'GetExpandedNamespace', PositionalBinding = $false, ConfirmImpact = 'Medium')]
	param(
        [Parameter(ParameterSetName = 'GetExpandedQueue', Mandatory, HelpMessage = "The name of the Authorization Rule")]
        [Parameter(ParameterSetName = 'GetExpandedTopic', Mandatory, HelpMessage = "The name of the Authorization Rule")]
        [Parameter(ParameterSetName = 'GetExpandedNamespace', Mandatory, HelpMessage = "The name of the Authorization Rule")]
        [Parameter(ParameterSetName = 'GetExpandedAlias', Mandatory, HelpMessage = "The name of the Authorization Rule")]
        [Alias('AuthorizationRuleName')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [System.String]
        # The name of the Authorization Rule.
        ${Name},

        [Parameter(ParameterSetName = 'GetExpandedQueue', Mandatory, HelpMessage = "The name of the ServiceBus queue.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [System.String]
        # The name of the ServiceBus queue.
        ${QueueName},

        [Parameter(ParameterSetName = 'GetExpandedTopic', Mandatory, HelpMessage = "The name of the ServiceBus topic.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [System.String]
        # The name of the ServiceBus entity.
        ${TopicName},

        [Parameter(ParameterSetName = 'GetExpandedAlias', Mandatory, HelpMessage = "The name of the Service Disaster Recovery Config.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [System.String]
        # The name of the Service Disaster Recovery Config.
        ${AliasName},

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

            if ($PSCmdlet.ParameterSetName -eq 'GetExpandedNamespace'){
                if ($PSCmdlet.ShouldProcess("ServiceBus Namespace Authorization Rule $($Name)", "List Keys")) {
                    Az.ServiceBus.private\Get-AzServiceBusNamespaceKey_List @PSBoundParameters
                }
            }

            elseif ($PSCmdlet.ParameterSetName -eq 'GetExpandedQueue'){
                if ($PSCmdlet.ShouldProcess("ServiceBus Queue Authorization Rule $($Name)", "List Keys")) {
                    Az.ServiceBus.private\Get-AzServiceBusQueueKey_List @PSBoundParameters
                }
            }

            elseif ($PSCmdlet.ParameterSetName -eq 'GetExpandedTopic'){
                if ($PSCmdlet.ShouldProcess("ServiceBus Topic Authorization Rule $($Name)", "List Keys")) {
                    Az.ServiceBus.private\Get-AzServiceBusTopicKey_List @PSBoundParameters
                }
            }

            elseif ($PSCmdlet.ParameterSetName -eq 'GetExpandedAlias'){
                $null = $PSBoundParameters.Remove('AliasName')
                $null = $PSBoundParameters.Remove('Name')
                if ($PSCmdlet.ShouldProcess("ServiceBus Alias Authorization Rule $($Name)", "List Keys")) {
                    Az.ServiceBus.private\Get-AzServiceBusDisasterRecoveryConfigKey_List -Alias $AliasName -AuthorizationRuleName $Name  @PSBoundParameters
                }
            }
		}
		catch{
			throw
		}
	}
}