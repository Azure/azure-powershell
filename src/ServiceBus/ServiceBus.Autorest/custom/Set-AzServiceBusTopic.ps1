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
Updates a ServiceBus Topic
.Description
Updates a ServiceBus Topic
#>

function Set-AzServiceBusTopic{
	[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ISbTopic])]
    [CmdletBinding(DefaultParameterSetName = 'SetExpanded', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
	param(
		[Parameter(ParameterSetName = 'SetExpanded', Mandatory, HelpMessage = "The name of the Topic.")]
        [Alias('TopicName')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [System.String]
        # The name of the Topic.
        ${Name},

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

        [Parameter(HelpMessage = "ISO 8061 timeSpan idle interval after which the topic is automatically deleted. The minimum duration is 5 minutes.")]
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
        ${EnableBatchedOperations},

        [Parameter(HelpMessage = "A value that indicates whether Express Entities are enabled. An express topic holds a message in memory temporarily before writing it to persistent storage.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # A value that indicates whether Express Entities are enabled. An express topic holds a message in memory temporarily before writing it to persistent storage.
        ${EnableExpress},

        [Parameter(HelpMessage = "Value that indicates whether the topic supports ordering.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # Value that indicates whether the topic supports ordering.
        ${SupportOrdering},

        [Parameter(HelpMessage = "The maximum delivery count. A message is automatically deadlettered after this number of deliveries. default value is 10.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.Int32]
        # The maximum delivery count. A message is automatically deadlettered after this number of deliveries. default value is 10.
        ${MaxSizeInMegabytes},

        [Parameter(HelpMessage = "Maximum size (in KB) of the message payload that can be accepted by the topic. This property is only used in Premium today and default is 1024.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.Int64]
        # Maximum size (in KB) of the message payload that can be accepted by the topic. This property is only used in Premium today and default is 1024.
        ${MaxMessageSizeInKilobytes},

        [Parameter(HelpMessage = "Enumerates the possible values for the status of a messaging entity.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.String]
        ${Status},
        
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
            $hasDuplicateDetectionHistoryTimeWindow = $PSBoundParameters.Remove('DuplicateDetectionHistoryTimeWindow')
            $hasEnableBatchedOperations = $PSBoundParameters.Remove('EnableBatchedOperations')
            $hasEnableExpress = $PSBoundParameters.Remove('EnableExpress')
            $hasMaxMessageSizeInKilobytes = $PSBoundParameters.Remove('MaxMessageSizeInKilobytes')
            $hasMaxSizeInMegabytes = $PSBoundParameters.Remove('MaxSizeInMegabytes')
            $hasRequiresDuplicateDetection = $PSBoundParameters.Remove('RequiresDuplicateDetection')
            $hasSupportOrdering = $PSBoundParameters.Remove('SupportOrdering')
            $hasStatus = $PSBoundParameters.Remove('Status')
            $hasAsJob = $PSBoundParameters.Remove('AsJob')
            $null = $PSBoundParameters.Remove('WhatIf')
            $null = $PSBoundParameters.Remove('Confirm')

            $topic = Get-AzServiceBusTopic @PSBoundParameters

            # 2. PUT
            $null = $PSBoundParameters.Remove('InputObject')
            $null = $PSBoundParameters.Remove('ResourceGroupName')
            $null = $PSBoundParameters.Remove('NamespaceName')
            $null = $PSBoundParameters.Remove('Name')
            $null = $PSBoundParameters.Remove('SubscriptionId')

            $hasProperty = $false

            if ($hasAutoDeleteOnIdle) {
                $topic.AutoDeleteOnIdle = $AutoDeleteOnIdle
                $hasProperty = $true
            }
            if ($hasDefaultMessageTimeToLive) {
                $topic.DefaultMessageTimeToLive = $DefaultMessageTimeToLive
                $hasProperty = $true
            }
            if ($hasDuplicateDetectionHistoryTimeWindow) {
                $topic.DuplicateDetectionHistoryTimeWindow = $DuplicateDetectionHistoryTimeWindow
                $hasProperty = $true
            }
            if ($hasEnableBatchedOperations) {
                $topic.EnableBatchedOperations = $EnableBatchedOperations
                $hasProperty = $true
            }
            if ($hasEnableExpress) {
                $topic.EnableExpress = $EnableExpress
                $hasProperty = $true
            }
            if ($hasEnablePartitioning) {
                $topic.EnablePartitioning = $EnablePartitioning
                $hasProperty = $true
            }
            if ($hasMaxMessageSizeInKilobytes) {
                $topic.MaxMessageSizeInKilobytes = $MaxMessageSizeInKilobytes
                $hasProperty = $true
            }
            if ($hasMaxSizeInMegabytes) {
                $topic.MaxSizeInMegabytes = $MaxSizeInMegabytes
                $hasProperty = $true
            }
            if ($hasStatus) {
                $topic.Status = $Status
                $hasProperty = $true
            }
            if ($hasSupportOrdering) {
                $topic.SupportOrdering = $SupportOrdering
                $hasProperty = $true
            }

            if (($hasProperty -eq $false) -and ($PSCmdlet.ParameterSetName -eq 'SetViaIdentityExpanded')){
                throw 'Please specify the property you want to update on the -InputObject. Refer https://go.microsoft.com/fwlink/?linkid=2204584#behavior-of--inputobject for example.'
            }

            if ($hasAsJob) {
                $PSBoundParameters.Add('AsJob', $true)
            }

            if ($PSCmdlet.ShouldProcess("ServiceBus Topic $($topic.Name)", "Create or update")) {
                Az.ServiceBus.private\New-AzServiceBusTopic_CreateViaIdentity -InputObject $topic -Parameter $topic @PSBoundParameters
            }
        }
        catch{
            throw
        }
    }
}
