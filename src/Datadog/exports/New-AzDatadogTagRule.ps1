
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
Create or update a tag rule set for a given monitor resource.
.Description
Create or update a tag rule set for a given monitor resource.
.Example
PS C:\> $ftobjArray = @()
PS C:\> $ftobjArray += New-AzDatadogFilteringTagObject -Action "Include" -Value "Prod" -Name "Environment"
PS C:\> $ftobjArray += New-AzDatadogFilteringTagObject -Action "Exclude" -Value "Dev" -Name "Environment"
PS C:\> New-AzDatadogTagRule -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'test' -LogRuleFilteringTag $ftobjArray

Name    Type
----    ----
default microsoft.Datadog/monitors/tagrules
.Example
PS C:\> $ftobjArray = @()
PS C:\> $ftobjArray += New-AzDatadogFilteringTagObject -Action "Include" -Value "Prod" -Name "Environment"
PS C:\> $ftobjArray += New-AzDatadogFilteringTagObject -Action "Exclude" -Value "Dev" -Name "Environment"
PS C:\> Get-AzDatadogTagRule -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'default' | New-AzDatadogTagRule -LogRuleFilteringTag $ftobjArray

Name    Type
----    ----
default microsoft.Datadog/monitors/tagrules

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IDatadogIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRules
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IDatadogIdentity>: Identity Parameter
  [ConfigurationName <String>]: Configuration name
  [Id <String>]: Resource identity path
  [MonitorName <String>]: Monitor resource name
  [ResourceGroupName <String>]: The name of the resource group. The name is case insensitive.
  [RuleSetName <String>]: Rule set name
  [SubscriptionId <String>]: The ID of the target subscription.

LOGRULEFILTERINGTAG <IFilteringTag[]>: List of filtering tags to be used for capturing logs. This only takes effect if SendResourceLogs flag is enabled. If empty, all resources will be captured. If only Exclude action is specified, the rules will apply to the list of all available resources. If Include actions are specified, the rules will only include resources with the associated tags.
  [Action <TagAction?>]: Valid actions for a filtering tag. Exclusion takes priority over inclusion.
  [Name <String>]: The name (also known as the key) of the tag.
  [Value <String>]: The value of the tag.

METRICRULEFILTERINGTAG <IFilteringTag[]>: List of filtering tags to be used for capturing metrics. If empty, all resources will be captured. If only Exclude action is specified, the rules will apply to the list of all available resources. If Include actions are specified, the rules will only include resources with the associated tags.
  [Action <TagAction?>]: Valid actions for a filtering tag. Exclusion takes priority over inclusion.
  [Name <String>]: The name (also known as the key) of the tag.
  [Value <String>]: The value of the tag.
.Link
https://docs.microsoft.com/powershell/module/az.datadog/new-azdatadogtagrule
#>
function New-AzDatadogTagRule {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitoringTagRules])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Path')]
    [System.String]
    # Monitor resource name
    ${MonitorName},

    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Path')]
    [System.String]
    # Rule set name
    ${Name},

    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='CreateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IDatadogIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag[]]
    # List of filtering tags to be used for capturing logs.
    # This only takes effect if SendResourceLogs flag is enabled.
    # If empty, all resources will be captured.
    # If only Exclude action is specified, the rules will apply to the list of all available resources.
    # If Include actions are specified, the rules will only include resources with the associated tags.
    # To construct, see NOTES section for LOGRULEFILTERINGTAG properties and create a hash table.
    ${LogRuleFilteringTag},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Flag specifying if AAD logs should be sent for the Monitor resource.
    ${LogRuleSendAadLog},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Flag specifying if Azure resource logs should be sent for the Monitor resource.
    ${LogRuleSendResourceLog},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Flag specifying if Azure subscription logs should be sent for the Monitor resource.
    ${LogRuleSendSubscriptionLog},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IFilteringTag[]]
    # List of filtering tags to be used for capturing metrics.
    # If empty, all resources will be captured.
    # If only Exclude action is specified, the rules will apply to the list of all available resources.
    # If Include actions are specified, the rules will only include resources with the associated tags.
    # To construct, see NOTES section for METRICRULEFILTERINGTAG properties and create a hash table.
    ${MetricRuleFilteringTag},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            CreateExpanded = 'Az.Datadog.private\New-AzDatadogTagRule_CreateExpanded';
            CreateViaIdentityExpanded = 'Az.Datadog.private\New-AzDatadogTagRule_CreateViaIdentityExpanded';
        }
        if (('CreateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
        $scriptCmd = {& $wrappedCmd @PSBoundParameters}
        $steppablePipeline = $scriptCmd.GetSteppablePipeline($MyInvocation.CommandOrigin)
        $steppablePipeline.Begin($PSCmdlet)
    } catch {
        throw
    }
}

process {
    try {
        $steppablePipeline.Process($_)
    } catch {
        throw
    }
}

end {
    try {
        $steppablePipeline.End()
    } catch {
        throw
    }
}
}
