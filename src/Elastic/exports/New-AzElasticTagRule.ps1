
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
PS C:\> New-AzElasticTagRule -ResourceGroupName azps-elastic-test -MonitorName elastic-pwsh02 -LogRuleSendActivityLog

Name    ProvisioningState ResourceGroupName
----    ----------------- -----------------
default Succeeded         azps-elastic-test

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.IMonitoringTagRules
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

LOGRULEFILTERINGTAG <IFilteringTag[]>: List of filtering tags to be used for capturing logs. This only takes effect if SendActivityLogs flag is enabled. If empty, all resources will be captured. If only Exclude action is specified, the rules will apply to the list of all available resources. If Include actions are specified, the rules will only include resources with the associated tags.
  [Action <TagAction?>]: Valid actions for a filtering tag.
  [Name <String>]: The name (also known as the key) of the tag.
  [Value <String>]: The value of the tag.
.Link
https://docs.microsoft.com/powershell/module/az.elastic/new-azelastictagrule
#>
function New-AzElasticTagRule {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.IMonitoringTagRules])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Path')]
    [System.String]
    # Monitor resource name
    ${MonitorName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Path')]
    [System.String]
    # The name of the resource group to which the Elastic resource belongs.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The Azure subscription ID.
    # This is a GUID-formatted string (e.g.
    # 00000000-0000-0000-0000-000000000000)
    ${SubscriptionId},

    [Parameter()]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.IFilteringTag[]]
    # List of filtering tags to be used for capturing logs.
    # This only takes effect if SendActivityLogs flag is enabled.
    # If empty, all resources will be captured.
    # If only Exclude action is specified, the rules will apply to the list of all available resources.
    # If Include actions are specified, the rules will only include resources with the associated tags.
    # To construct, see NOTES section for LOGRULEFILTERINGTAG properties and create a hash table.
    ${LogRuleFilteringTag},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Flag specifying if AAD logs should be sent for the Monitor resource.
    ${LogRuleSendAadLog},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Flag specifying if activity logs from Azure resources should be sent for the Monitor resource.
    ${LogRuleSendActivityLog},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Flag specifying if subscription logs should be sent for the Monitor resource.
    ${LogRuleSendSubscriptionLog},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Runtime')]
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
            CreateExpanded = 'Az.Elastic.private\New-AzElasticTagRule_CreateExpanded';
        }
        if (('CreateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('RuleSetName')) {
            $PSBoundParameters['RuleSetName'] = "default"
        }
        if (('CreateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
