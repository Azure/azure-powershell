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
Sets a ServiceBus Topic
.Description
Sets a ServiceBus Topic
#>

function Set-AzServiceBusSubscription{
	[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api202201Preview.ISbSubscription])]
    [CmdletBinding(DefaultParameterSetName = 'SetExpanded', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
	param(
		[Parameter(ParameterSetName = 'SetExpanded', Mandatory, HelpMessage = "The name of the Subscription.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [System.String]
        # The name of the Subscription.
        ${Name},

        [Parameter(ParameterSetName = 'SetExpanded', Mandatory, HelpMessage = "The name of the Topic.")]
        [Alias('Topic')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [System.String]
        # The name of the Topic.
        ${TopicName},

        [Parameter(ParameterSetName = 'SetExpanded', Mandatory, HelpMessage = "The name of ServiceBus namespace")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [System.String]
        # The name of ServiceBus namespace
        ${NamespaceName},

        [Parameter(ParameterSetName = 'SetExpanded', Mandatory, HelpMessage = "The name of the resource group. The name is case insensitive.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [System.String]
        # The name of the resource group.
        # The name is case insensitive.
        ${ResourceGroupName},

        [Parameter(ParameterSetName = 'SetExpanded', HelpMessage = "The ID of the target subscription.")]
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

        [Parameter(HelpMessage = "ISO 8061 timeSpan idle interval after which the subscription is automatically deleted. The minimum duration is 5 minutes.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.TimeSpan]
        # timeSpan.
        ${AutoDeleteOnIdle},

        [Parameter(HelpMessage = "ISO 8601 default message timespan to live value. This is the duration after which the message expires, starting from when the message is sent to Service Bus. This is the default value used when TimeToLive is not set on a message itself.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.TimeSpan]
        # timeSpan.
        ${DefaultMessageTimeToLive},

        [Parameter(HelpMessage = "ISO 8601 timeSpan structure that defines the duration of the duplicate detection history. The default value is 10 minutes.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.TimeSpan]
        # timeSpan.
        ${DuplicateDetectionHistoryTimeWindow},

        [Parameter(HelpMessage = "Value that indicates whether server-side batched operations are enabled.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # Value that indicates whether server-side batched operations are enabled.
        ${EnableBatchedOperation},

        [Parameter(HelpMessage = "Enumerates the possible values for the status of a messaging entity.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Support.EntityStatus]
        # Enumerates the possible values for the status of a messaging entity.
        ${Status},

        [Parameter(HelpMessage = "Queue/Topic name to forward the messages")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.String]
        # Queue/Topic name to forward the messages
        ${ForwardTo},

        [Parameter(HelpMessage = "Queue/Topic name to forward the Dead Letter message")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.String]
        # Queue/Topic name to forward the Dead Letter message
        ${ForwardDeadLetteredMessagesTo},

        [Parameter(HelpMessage = "The maximum delivery count. A message is automatically deadlettered after this number of deliveries. default value is 10.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.Int32]
        # The maximum delivery count. A message is automatically deadlettered after this number of deliveries. default value is 10.
        ${MaxDeliveryCount},

        [Parameter(HelpMessage = "A value that indicates whether the subscription supports the concept of sessions.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # A value that indicates whether the subscription supports the concept of sessions.
        ${RequiresSession},

        [Parameter(HelpMessage = "Value that indicates whether a subscription has dead letter support on filter evaluation exceptions.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # Value that indicates whether a subscription has dead letter support on filter evaluation exceptions.
        ${DeadLetteringOnFilterEvaluationException},

        [Parameter(HelpMessage = "Value that indicates whether a subscription has dead letter support when a message expires.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # Value that indicates whether a subscription has dead letter support on filter evaluation exceptions.
        ${DeadLetteringOnMessageExpiration},

        [Parameter(HelpMessage = "Value that indicates whether the subscription has an affinity to the client id.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # Value that indicates whether the subscription has an affinity to the client id.
        ${IsClientAffine},

        [Parameter(HelpMessage = "Indicates the Client ID of the application that created the client-affine subscription.")]
		[Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
		[System.String]
		# Indicates the Client ID of the application that created the client-affine subscription.
		${ClientId},

        [Parameter(HelpMessage = "For client-affine subscriptions, this value indicates whether the subscription is shared or not.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # For client-affine subscriptions, this value indicates whether the subscription is shared or not.
        ${IsShared},

        [Parameter(HelpMessage = "For client-affine subscriptions, this value indicates whether the subscription is durable or not.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # For client-affine subscriptions, this value indicates whether the subscription is durable or not.
        ${IsDurable},
        
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
            $hasAutoDeleteOnIdle = $PSBoundParameters.Remove('AutoDeleteOnIdle')
            $hasDefaultMessageTimeToLive = $PSBoundParameters.Remove('DefaultMessageTimeToLive')
            $hasLockDuration = $PSBoundParameters.Remove('LockDuration')
            $hasDuplicateDetectionHistoryTimeWindow = $PSBoundParameters.Remove('DuplicateDetectionHistoryTimeWindow')
            $hasEnableBatchedOperation = $PSBoundParameters.Remove('EnableBatchedOperation')
            $hasRequiresSession = $PSBoundParameters.Remove('RequiresSession')
            $hasIsClientAffine = $PSBoundParameters.Remove('IsClientAffine')
            $hasClientId = $PSBoundParameters.Remove('ClientId')
            $hasIsShared = $PSBoundParameters.Remove('IsShared')
            $hasIsDurable = $PSBoundParameters.Remove('IsDurable')
            $hasDeadLetteringOnFilterEvaluationException = $PSBoundParameters.Remove('DeadLetteringOnFilterEvaluationException')
            $hasMaxDeliveryCount = $PSBoundParameters.Remove('MaxDeliveryCount')
            $hasForwardTo = $PSBoundParameters.Remove('ForwardTo')
            $hasForwardDeadLetteredMessagesTo = $PSBoundParameters.Remove('ForwardDeadLetteredMessagesTo')
            $hasStatus = $PSBoundParameters.Remove('Status')
            $hasDeadLetteringOnMessageExpiration = $PSBoundParameters.Remove('DeadLetteringOnMessageExpiration')
            $hasAsJob = $PSBoundParameters.Remove('AsJob')
            $null = $PSBoundParameters.Remove('WhatIf')
            $null = $PSBoundParameters.Remove('Confirm')

            $subscription = Get-AzServiceBusSubscription @PSBoundParameters

            # 2. PUT
            $null = $PSBoundParameters.Remove('InputObject')
            $null = $PSBoundParameters.Remove('ResourceGroupName')
            $null = $PSBoundParameters.Remove('NamespaceName')
            $null = $PSBoundParameters.Remove('TopicName')
            $null = $PSBoundParameters.Remove('Name')
            $null = $PSBoundParameters.Remove('SubscriptionId')
            if ($hasAutoDeleteOnIdle) {
                $subscription.AutoDeleteOnIdle = $AutoDeleteOnIdle
            }
            if ($hasDefaultMessageTimeToLive) {
                $subscription.DefaultMessageTimeToLive = $DefaultMessageTimeToLive
            }
            if($hasLockDuration){
	            $subscription.LockDuration = $LockDuration
            }
            if ($hasDuplicateDetectionHistoryTimeWindow) {
                $subscription.DuplicateDetectionHistoryTimeWindow = $DuplicateDetectionHistoryTimeWindow
            }
            if ($hasEnableBatchedOperation) {
                $subscription.EnableBatchedOperation = $EnableBatchedOperation
            }
            if ($hasRequiresSession) {
                $subscription.RequiresSession = $RequiresSession
            }
            if ($hasStatus) {
                $subscription.Status = $Status
            }
            if ($hasIsClientAffine) {
                $subscription.IsClientAffine = $IsClientAffine
            }
            if ($hasIsShared) {
                $subscription.IsShared = $IsShared
            }
            if ($hasStatus) {
                $subscription.IsDurable = $IsDurable
            }
            if ($hasClientId) {
                $subscription.ClientId = $ClientId
            }
            if ($hasDeadLetteringOnMessageExpiration) {
                $subscription.DeadLetteringOnMessageExpiration = $DeadLetteringOnMessageExpiration
            }
            if ($hasDeadLetteringOnFilterEvaluationException) {
                $subscription.DeadLetteringOnFilterEvaluationException = $DeadLetteringOnFilterEvaluationException
            }
            if ($hasMaxDeliveryCount) {
                $subscription.MaxDeliveryCount = $MaxDeliveryCount
            }
            if ($hasForwardDeadLetteredMessagesTo) {
                $subscription.ForwardDeadLetteredMessagesTo = $ForwardDeadLetteredMessagesTo
            }
            if ($hasForwardTo) {
                $subscription.ForwardTo = $ForwardTo
            }
            if ($hasAsJob) {
                $PSBoundParameters.Add('AsJob', $true)
            }

            if ($PSCmdlet.ShouldProcess("ServiceBus Subscription $($subscription.Name)", "Create or update")) {
                Az.ServiceBus.private\New-AzServiceBusSubscription_CreateViaIdentity -InputObject $subscription -Parameter $subscription @PSBoundParameters
            }
        }
        catch{
            throw
        }
    }
}
