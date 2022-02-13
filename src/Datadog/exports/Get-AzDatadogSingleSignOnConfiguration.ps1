
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
Gets the datadog single sign-on resource for the given Monitor.
.Description
Gets the datadog single sign-on resource for the given Monitor.
.Example
PS C:\> Get-AzDatadogSingleSignOnConfiguration -ResourceGroupName azure-rg-Datadog -MonitorName Datadog

Name    Type
----    ----
default microsoft.Datadog/monitors/singlesignonconfigurations
.Example
PS C:\> Get-AzDatadogSingleSignOnConfiguration -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'default'

Name    Type
----    ----
default microsoft.Datadog/monitors/singlesignonconfigurations
.Example
PS C:\> New-AzDatadogSingleSignOnConfiguration -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Name 'default' -SingleSignOnState Enable -EnterpriseAppId 00000000-0000-0000-0000-000000000000 | Get-AzDatadogSingleSignOnConfiguration

Name    Type
----    ----
default microsoft.Datadog/monitors/singlesignonconfigurations

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IDatadogIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogSingleSignOnResource
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
.Link
https://docs.microsoft.com/powershell/module/az.datadog/get-azdatadogsinglesignonconfiguration
#>
function Get-AzDatadogSingleSignOnConfiguration {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogSingleSignOnResource])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
param(
    [Parameter(ParameterSetName='Get', Mandatory)]
    [Parameter(ParameterSetName='List', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Path')]
    [System.String]
    # Monitor resource name
    ${MonitorName},

    [Parameter(ParameterSetName='Get', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Path')]
    [System.String]
    # Configuration name
    ${Name},

    [Parameter(ParameterSetName='Get', Mandatory)]
    [Parameter(ParameterSetName='List', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Get')]
    [Parameter(ParameterSetName='List')]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='GetViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IDatadogIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

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
            Get = 'Az.Datadog.private\Get-AzDatadogSingleSignOnConfiguration_Get';
            GetViaIdentity = 'Az.Datadog.private\Get-AzDatadogSingleSignOnConfiguration_GetViaIdentity';
            List = 'Az.Datadog.private\Get-AzDatadogSingleSignOnConfiguration_List';
        }
        if (('Get', 'List') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
