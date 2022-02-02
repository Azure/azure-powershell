
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
Create a monitor resource.
.Description
Create a monitor resource.
.Example
PS C:\> New-AzElasticMonitor -ResourceGroupName azps-elastic-test -Name elastic-pwsh02 -Location "westus2" -SkuName "ess-monthly-consumption_Monthly" -UserInfoEmailAddress 'xxx@microsoft.com'

Name           SkuName                         MonitoringStatus Location ResourceGroupName
----           -------                         ---------------- -------- -----------------
elastic-pwsh02 ess-monthly-consumption_Monthly Enabled          westus2  azure-elastic-test

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.IElasticMonitorResource
.Link
https://docs.microsoft.com/powershell/module/az.elastic/new-azelasticmonitor
#>
function New-AzElasticMonitor {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.IElasticMonitorResource])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('MonitorName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Path')]
    [System.String]
    # Monitor resource name
    ${Name},

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

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Body')]
    [System.String]
    # The location of the monitor resource
    ${Location},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Body')]
    [System.String]
    # Business of the company
    ${CompanyInfoBusiness},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Body')]
    [System.String]
    # Country of the company location.
    ${CompanyInfoCountry},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Body')]
    [System.String]
    # Domain of the company
    ${CompanyInfoDomain},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Body')]
    [System.String]
    # Number of employees in the company
    ${CompanyInfoEmployeesNumber},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Body')]
    [System.String]
    # State of the company location.
    ${CompanyInfoState},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Elastic.Support.ManagedIdentityTypes])]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Support.ManagedIdentityTypes]
    # Managed identity type.
    ${IdentityType},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Elastic.Support.MonitoringStatus])]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Support.MonitoringStatus]
    # Flag specifying if the resource monitoring is enabled or disabled.
    ${MonitoringStatus},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Body')]
    [System.String]
    # Name of the SKU.
    ${Sku},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.IElasticMonitorResourceTags]))]
    [System.Collections.Hashtable]
    # The tags of the monitor resource.
    ${Tag},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Body')]
    [System.String]
    # Company name of the user
    ${UserInfoCompanyName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Body')]
    [System.String]
    # Email of the user used by Elastic for contacting them if needed
    ${UserInfoEmailAddress},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Body')]
    [System.String]
    # First name of the user
    ${UserInfoFirstName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Body')]
    [System.String]
    # Last name of the user
    ${UserInfoLastName},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

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

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Elastic.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

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
            CreateExpanded = 'Az.Elastic.private\New-AzElasticMonitor_CreateExpanded';
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
