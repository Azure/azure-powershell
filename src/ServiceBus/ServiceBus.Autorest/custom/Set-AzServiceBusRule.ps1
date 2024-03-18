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
Updates a ServiceBus Rule
.Description
Updates a ServiceBus Rule
#>

function Set-AzServiceBusRule{
	[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api20221001Preview.IRule])]
    [CmdletBinding(DefaultParameterSetName = 'SetExpanded', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
	param(
		[Parameter(ParameterSetName = 'SetExpanded', Mandatory, HelpMessage = "The name of the Rule.")]
        [Alias('RuleName')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [System.String]
        # The name of the Rule.
        ${Name},

        [Parameter(ParameterSetName = 'SetExpanded', Mandatory, HelpMessage = "The name of the Topic.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [System.String]
        # The name of the Topic.
        ${TopicName},

        [Parameter(ParameterSetName = 'SetExpanded', Mandatory, HelpMessage = "The name of the SubscriptionName.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
        [System.String]
        # The name of the SubscriptionName.
        ${SubscriptionName},

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

        [Parameter(HelpMessage = "SQL expression. e.g. MyProperty='ABC'")]
		[Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
		[System.String]
		# SQL expression. e.g. MyProperty='ABC'
		${SqlExpression},

        [Parameter(HelpMessage = "Value that indicates whether the rule action requires preprocessing.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # Value that indicates whether the rule action requires preprocessing.
        ${SqlFilterRequiresPreprocessing},

        [Parameter(HelpMessage = "Content type of the message.")]
		[Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
		[System.String]
		# Content type of the message.
		${ContentType},

        [Parameter(HelpMessage = "Identifier of the correlation.")]
		[Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
		[System.String]
		# Identifier of the correlation.
		${CorrelationId},

        [Parameter(HelpMessage = "Application specific label.")]
		[Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
		[System.String]
		# Application specific label.
		${Label},

        [Parameter(HelpMessage = "Identifier of the message.")]
		[Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
		[System.String]
		# Identifier of the message.
		${MessageId},

        [Parameter(HelpMessage = "dictionary object for custom filters")]
		[Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
		[System.Collections.Hashtable]
		# dictionary object for custom filters
		${CorrelationFilterProperty},

        [Parameter(HelpMessage = "Address of the queue to reply to.")]
		[Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
		[System.String]
		# Address of the queue to reply to.
		${ReplyTo},

        [Parameter(HelpMessage = "Session identifier to reply to.")]
		[Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
		[System.String]
		# Session identifier to reply to.
		${ReplyToSessionId},

        [Parameter(HelpMessage = "Value that indicates whether the rule action requires preprocessing.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # Value that indicates whether the rule action requires preprocessing.
        ${CorrelationFilterRequiresPreprocessing},

        [Parameter(HelpMessage = "Session identifier.")]
		[Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
		[System.String]
		# Session identifier.
		${SessionId},

        [Parameter(HelpMessage = "Address to send to.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.String]
        # Address to send to.
        ${To},

        [Parameter(HelpMessage = "Filter type that is evaluated against a BrokeredMessage.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Support.FilterType]
        # Filter type that is evaluated against a BrokeredMessage.
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Runtime.ParameterBreakingChangeAttribute("FilterType","12.0.0", "4.0.0","2024-05-21" )]
        ${FilterType},

        [Parameter(HelpMessage = "Value that indicates whether the rule action requires preprocessing.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # Value that indicates whether the rule action requires preprocessing. 
        ${ActionRequiresPreprocessing},

        [Parameter(HelpMessage = "SQL expression. e.g. MyProperty='ABC'")]
		[Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
		[System.String]
		# SQL expression. e.g. MyProperty='ABC'
		${ActionSqlExpression},

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
            $hasSqlExpression = $PSBoundParameters.Remove('SqlExpression')
            $hasSqlFilterRequiresPreprocessing = $PSBoundParameters.Remove('SqlFilterRequiresPreprocessing')
            $hasContentType = $PSBoundParameters.Remove('ContentType')
            $hasCorrelationId = $PSBoundParameters.Remove('CorrelationId')
            $hasLabel = $PSBoundParameters.Remove('Label')
            $hasMessageId = $PSBoundParameters.Remove('MessageId')
            $hasCorrelationFilterProperty = $PSBoundParameters.Remove('CorrelationFilterProperty')
            $hasReplyTo = $PSBoundParameters.Remove('ReplyTo')
            $hasReplyToSessionId = $PSBoundParameters.Remove('ReplyToSessionId')
            $hasCorrelationFilterRequiresPreprocessing = $PSBoundParameters.Remove('CorrelationFilterRequiresPreprocessing')
            $hasSessionId = $PSBoundParameters.Remove('SessionId')
            $hasTo = $PSBoundParameters.Remove('To')
            $hasFilterType = $PSBoundParameters.Remove('FilterType')
            $hasActionSqlExpression = $PSBoundParameters.Remove('ActionSqlExpression')
            $hasActionRequiresPreprocessing = $PSBoundParameters.Remove('ActionRequiresPreprocessing')

            $rule = Get-AzServiceBusRule @PSBoundParameters

            # 2. PUT
            $null = $PSBoundParameters.Remove('InputObject')
            $null = $PSBoundParameters.Remove('ResourceGroupName')
            $null = $PSBoundParameters.Remove('NamespaceName')
            $null = $PSBoundParameters.Remove('TopicName')
            $null = $PSBoundParameters.Remove('SubscriptionName')
            $null = $PSBoundParameters.Remove('Name')
            $null = $PSBoundParameters.Remove('SubscriptionId')

            $hasProperty = $false

            if ($hasSqlExpression) {
                $rule.SqlExpression = $SqlExpression
                $hasProperty = $true
            }
            if ($hasSqlFilterRequiresPreprocessing) {
                $rule.SqlFilterRequiresPreprocessing = $SqlFilterRequiresPreprocessing
                $hasProperty = $true
            }
            if ($hasContentType) {
                $rule.ContentType = $ContentType
                $hasProperty = $true
            }
            if ($hasCorrelationId) {
                $rule.CorrelationId = $CorrelationId
                $hasProperty = $true
            }
            if ($hasLabel) {
                $rule.Label = $Label
                $hasProperty = $true
            }
            if ($hasMessageId) {
                $rule.MessageId = $MessageId
                $hasProperty = $true
            }
            if ($hasCorrelationFilterProperty) {
                $rule.CorrelationFilterProperty = $CorrelationFilterProperty
                $hasProperty = $true
            }
            if ($hasReplyTo) {
                $rule.ReplyTo = $ReplyTo
                $hasProperty = $true
            }
            if ($hasReplyToSessionId) {
                $rule.ReplyToSessionId = $ReplyToSessionId
                $hasProperty = $true
            }
            if ($hasCorrelationFilterRequiresPreprocessing) {
                $rule.CorrelationFilterRequiresPreprocessing = $CorrelationFilterRequiresPreprocessing
                $hasProperty = $true
            }
            if ($hasSessionId) {
                $rule.SessionId = $SessionId
                $hasProperty = $true
            }
            if ($hasTo) {
                $rule.To = $To
                $hasProperty = $true
            }
            if ($hasFilterType) {
                $rule.FilterType = $FilterType
                $hasProperty = $true
            }
            if ($hasActionSqlExpression) {
                $rule.ActionSqlExpression = $ActionSqlExpression
                $hasProperty = $true
            }
            if ($hasActionRequiresPreprocessing) {
                $rule.ActionRequiresPreprocessing = $ActionRequiresPreprocessing
                $hasProperty = $true
            }

            if (($hasProperty -eq $false) -and ($PSCmdlet.ParameterSetName -eq 'SetViaIdentityExpanded')){
                throw 'Please specify the property you want to update on the -InputObject. Refer https://go.microsoft.com/fwlink/?linkid=2204584#behavior-of--inputobject for example.'
            }

            if ($hasAsJob) {
                $PSBoundParameters.Add('AsJob', $true)
            }

            if ($PSCmdlet.ShouldProcess("ServiceBus Rule $($rule.Name)", "Create or update")) {
                Az.ServiceBus.private\New-AzServiceBusRule_CreateViaIdentity -InputObject $rule -Parameter $rule @PSBoundParameters
            }
		}
		catch{
			throw
		}
	}
}