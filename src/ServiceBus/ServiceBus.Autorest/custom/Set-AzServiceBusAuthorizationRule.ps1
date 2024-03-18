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
Updates the authorization rule of a ServiceBus namespace, queue or topic.
.Description
Updates the authorization rule of a ServiceBus namespace, queue or topic.
#>

function Set-AzServiceBusAuthorizationRule{
	[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api20221001Preview.ISbAuthorizationRule])]
    [CmdletBinding(DefaultParameterSetName = 'SetExpandedNamespace', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
	param(
        [Parameter(ParameterSetName = 'SetExpandedTopic', Mandatory, HelpMessage = "The name of the Authorization Rule")]
        [Parameter(ParameterSetName = 'SetExpandedQueue', Mandatory, HelpMessage = "The name of the Authorization Rule")]
        [Parameter(ParameterSetName = 'SetExpandedNamespace', Mandatory, HelpMessage = "The name of the Authorization Rule")]
        [Alias('AuthorizationRuleName')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [System.String]
        # The name of the Authorization Rule.
        ${Name},

        [Parameter(ParameterSetName = 'SetExpandedQueue', Mandatory, HelpMessage = "The name of the ServiceBus queue.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [System.String]
        # The name of the ServiceBus queue.
        ${QueueName},

        [Parameter(ParameterSetName = 'SetExpandedTopic', Mandatory, HelpMessage = "The name of the ServiceBus topic.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [System.String]
        # The name of the ServiceBus queue.
        ${TopicName},

        [Parameter(ParameterSetName = 'SetExpandedTopic', Mandatory, HelpMessage = "The name of the ServiceBus namespace.")]
        [Parameter(ParameterSetName = 'SetExpandedQueue', Mandatory, HelpMessage = "The name of the ServiceBus namespace.")]
        [Parameter(ParameterSetName = 'SetExpandedNamespace', Mandatory, HelpMessage = "The name of the ServiceBus namespace.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [System.String]
        # The name of ServiceBus namespace
        ${NamespaceName},

        [Parameter(ParameterSetName = 'SetExpandedTopic', Mandatory, HelpMessage = "The name of the resource group. The name is case insensitive.")]
        [Parameter(ParameterSetName = 'SetExpandedQueue', Mandatory, HelpMessage = "The name of the resource group. The name is case insensitive.")]
        [Parameter(ParameterSetName = 'SetExpandedNamespace', Mandatory, HelpMessage = "The name of the resource group. The name is case insensitive.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [System.String]
        # The name of the resource group.
        # The name is case insensitive.
        ${ResourceGroupName},

        [Parameter(ParameterSetName = 'SetExpandedTopic', HelpMessage = "The ID of the target subscription.")]
        [Parameter(ParameterSetName = 'SetExpandedQueue', HelpMessage = "The ID of the target subscription.")]
        [Parameter(ParameterSetName = 'SetExpandedNamespace', HelpMessage = "The ID of the target subscription.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter(ParameterSetName = 'SetViaIdentityExpanded', Mandatory, ValueFromPipeline, HelpMessage = "Identity parameter. To construct, see NOTES section for INPUTOBJECT properties and create a hash table.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IServiceBusIdentity]
        # Identity Parameter
        # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
        ${InputObject},

        [Parameter(Mandatory, HelpMessage = "The rights associated with the rule.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Support.AccessRights[]]
        # The rights associated with the rule.
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Runtime.ParameterBreakingChangeAttribute("Rights","12.0.0", "4.0.0","2024-05-21" )]
        ${Rights},
		
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
            $hasRights = $PSBoundParameters.Remove('Rights')
            $hasAsJob = $PSBoundParameters.Remove('AsJob')
            $null = $PSBoundParameters.Remove('WhatIf')
            $null = $PSBoundParameters.Remove('Confirm')

            if ($PSCmdlet.ParameterSetName -eq 'SetExpandedQueue'){
                $authRule = Az.ServiceBus.private\Get-AzServiceBusQueueAuthorizationRule_Get @PSBoundParameters
            }

            elseif ($PSCmdlet.ParameterSetName -eq 'SetExpandedTopic'){
                $authRule = Az.ServiceBus.private\Get-AzServiceBusTopicAuthorizationRule_Get @PSBoundParameters
            }

            elseif ($PSCmdlet.ParameterSetName -eq 'SetExpandedNamespace'){
                $authRule = Az.ServiceBus.private\Get-AzServiceBusNamespaceAuthorizationRule_Get @PSBoundParameters
            }

            if ($hasAsJob) {
                $PSBoundParameters.Add('AsJob', $true)
            }

            elseif ($PSCmdlet.ParameterSetName -eq 'SetViaIdentityExpanded'){
                
                if($InputObject.Id -ne $null){
                    $ResourceHashTable = ParseResourceId -ResourceId $InputObject.Id
                }
                else{
                    $ResourceHashTable = ParseResourceId -ResourceId $InputObject
                }

                if ($ResourceHashTable['QueueName'] -ne $null){
                    $authRule = Az.ServiceBus.private\Get-AzServiceBusQueueAuthorizationRule_GetViaIdentity @PSBoundParameters
                }
                elseif ($ResourceHashTable['TopicName'] -ne $null){
                    $authRule = Az.ServiceBus.private\Get-AzServiceBusTopicAuthorizationRule_GetViaIdentity @PSBoundParameters
                }
                elseif ($ResourceHashTable['NamespaceName'] -ne $null){
                    $authRule = Az.ServiceBus.private\Get-AzServiceBusNamespaceAuthorizationRule_GetViaIdentity @PSBoundParameters
                }
                else{
                    throw 'Invalid -InputObject. Please Check ResourceId'
                }

            }
            
            # 2. PUT
            $null = $PSBoundParameters.Remove('InputObject')
            $null = $PSBoundParameters.Remove('ResourceGroupName')
            $null = $PSBoundParameters.Remove('NamespaceName')
            $null = $PSBoundParameters.Remove('QueueName')
            $null = $PSBoundParameters.Remove('TopicName')
            $null = $PSBoundParameters.Remove('Name')
            $null = $PSBoundParameters.Remove('SubscriptionId')

            if ($hasRights) {
                $authRule.Rights = $Rights
            }
            if ($hasAsJob) {
                $PSBoundParameters.Add('AsJob', $true)
            }

            if ($PSCmdlet.ParameterSetName -eq 'SetExpandedNamespace'){
                if ($PSCmdlet.ShouldProcess("ServiceBus Namespace Authorization Rule $($authRule.Name)", "Create or update")) {
                    Az.ServiceBus.private\New-AzServiceBusNamespaceAuthorizationRule_CreateViaIdentity -InputObject $authRule -Parameter $authRule @PSBoundParameters
                }
            }

            elseif ($PSCmdlet.ParameterSetName -eq 'SetExpandedQueue'){
                if ($PSCmdlet.ShouldProcess("ServiceBus Queue Authorization Rule $($authRule.Name)", "Create or update")) {
                    Az.ServiceBus.private\New-AzServiceBusQueueAuthorizationRule_CreateViaIdentity -InputObject $authRule -Parameter $authRule @PSBoundParameters
                }
            }

            elseif ($PSCmdlet.ParameterSetName -eq 'SetExpandedTopic'){
                if ($PSCmdlet.ShouldProcess("ServiceBus Topic Authorization Rule $($authRule.Name)", "Create or update")) {
                    Az.ServiceBus.private\New-AzServiceBusTopicAuthorizationRule_CreateViaIdentity -InputObject $authRule -Parameter $authRule @PSBoundParameters
                }
            }

            elseif ($PSCmdlet.ParameterSetName -eq 'SetViaIdentityExpanded'){
                
                if ($ResourceHashTable['QueueName'] -ne $null){
                    if ($PSCmdlet.ShouldProcess("ServiceBus Queue Authorization Rule $($ResourceHashTable['AuthorizationRuleName'])", "Create or update")) {
                        Az.ServiceBus.private\New-AzServiceBusQueueAuthorizationRule_CreateViaIdentity -InputObject $authRule -Parameter $authRule @PSBoundParameters
                    }
                }

                elseif ($ResourceHashTable['TopicName'] -ne $null){
                    if ($PSCmdlet.ShouldProcess("ServiceBus Topic Authorization Rule $($ResourceHashTable['AuthorizationRuleName'])", "Create or update")) {
                        Az.ServiceBus.private\New-AzServiceBusTopicAuthorizationRule_CreateViaIdentity -InputObject $authRule -Parameter $authRule @PSBoundParameters
                    }
                }

                elseif ($ResourceHashTable['NamespaceName'] -ne $null){
                    if ($PSCmdlet.ShouldProcess("ServiceBus Namespace Authorization Rule $($ResourceHashTable['AuthorizationRuleName'])", "Create or update")) {
                        Az.ServiceBus.private\New-AzServiceBusNamespaceAuthorizationRule_CreateViaIdentity -InputObject $authRule -Parameter $authRule @PSBoundParameters
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
