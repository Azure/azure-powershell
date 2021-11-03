
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
Get the properties of a specific monitor resource.
.Description
Get the properties of a specific monitor resource.
.Example
PS C:\> Get-AzElasticMonitor

Name                           SkuName                         MonitoringStatus Location      ResourceGroupName
----                           -------                         ---------------- --------      -----------------
kk-elastictest02               ess-monthly-consumption_Monthly Enabled          westus2       kk-rg
kk-elastictest03               ess-monthly-consumption_Monthly Enabled          westus2       kk-rg
wusDeployValidate              ess-monthly-consumption_Monthly Enabled          westus2       poshett-rg
poshett-WestUS2-01             staging_Monthly                 Enabled          westus2       poshett-rg
hashahdemo01                   staging_Monthly                 Enabled          westus2       test-sub
.Example
PS C:\> Get-AzElasticMonitor -ResourceGroupName azure-elastic-test

Name             SkuName                         MonitoringStatus Location ResourceGroupName
----             -------                         ---------------- -------- -----------------
elastic-portal01 ess-monthly-consumption_Monthly Enabled          westus2  azure-elastic-test
elastic-portal02 ess-monthly-consumption_Monthly Enabled          westus2  azure-elastic-test
elastic-pwsh01   ess-monthly-consumption_Monthly Enabled          westus2  azure-elastic-test
elastic-pwsh02   ess-monthly-consumption_Monthly Enabled          westus2  azure-elastic-test
.Example
PS C:\> Get-AzElasticMonitor -ResourceGroupName azure-elastic-test -Name elastic-pwsh02

Name           SkuName                         MonitoringStatus Location ResourceGroupName
----           -------                         ---------------- -------- -----------------
elastic-pwsh02 ess-monthly-consumption_Monthly Enabled          westus2  azure-elastic-test
.Example
PS C:\> New-AzElasticMonitor -ResourceGroupName azps-elastic-test -Name elastic-pwsh02 -Location "westus2" -SkuName "ess-monthly-consumption_Monthly" -UserInfoEmailAddress 'xxx@microsoft.com' | Get-AzElasticMonitor

Name           SkuName                         MonitoringStatus Location ResourceGroupName
----           -------                         ---------------- -------- -----------------
elastic-pwsh02 ess-monthly-consumption_Monthly Enabled          westus2  azure-elastic-test

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.IElasticMonitorResource
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IElasticIdentity>: Identity Parameter
  [Id <String>]: Resource identity path
  [MonitorName <String>]: Monitor resource name
  [ResourceGroupName <String>]: The name of the resource group to which the Elastic resource belongs.
  [RuleSetName <String>]: Tag Rule Set resource name
  [SubscriptionId <String>]: The Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000)
.Link
https://docs.microsoft.com/powershell/module/az.elastic/get-azelasticmonitor
#>
function Get-AzElasticMonitor {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.IElasticMonitorResource])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
param(
    [Parameter(ParameterSetName='Get', Mandatory)]
    [Alias('MonitorName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Path')]
    [System.String]
    # Monitor resource name
    ${Name},

    [Parameter(ParameterSetName='Get', Mandatory)]
    [Parameter(ParameterSetName='List1', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Path')]
    [System.String]
    # The name of the resource group to which the Elastic resource belongs.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Get')]
    [Parameter(ParameterSetName='List')]
    [Parameter(ParameterSetName='List1')]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The Azure subscription ID.
    # This is a GUID-formatted string (e.g.
    # 00000000-0000-0000-0000-000000000000)
    ${SubscriptionId},

    [Parameter(ParameterSetName='GetViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

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
            Get = 'Az.Elastic.private\Get-AzElasticMonitor_Get';
            GetViaIdentity = 'Az.Elastic.private\Get-AzElasticMonitor_GetViaIdentity';
            List = 'Az.Elastic.private\Get-AzElasticMonitor_List';
            List1 = 'Az.Elastic.private\Get-AzElasticMonitor_List1';
        }
        if (('Get', 'List', 'List1') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
