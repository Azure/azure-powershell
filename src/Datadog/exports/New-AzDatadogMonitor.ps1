
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
PS C:\> New-AzDatadogMonitor -ResourceGroupName azure-rg-test -Name Datadog-pwsh01 -SkuName 'drawdown_testing_20200904_Monthly' -Location 'eastus2euap' -UserInfoEmailAddress 'xxxx@microsoft.com' -UserInfoName 'user' -UserInfoPhoneNumber 'xxxxxxxxxxxx' -IdentityType SystemAssigned

Location    Name           Type
--------    ----           ----
eastus2euap Datadog-pwsh01 microsoft.Datadog/monitors

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResource
.Link
https://docs.microsoft.com/powershell/module/az.datadog/new-azdatadogmonitor
#>
function New-AzDatadogMonitor {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResource])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('MonitorName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Path')]
    [System.String]
    # Monitor resource name
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Body')]
    [System.String]
    # .
    ${Location},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ManagedIdentityTypes])]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ManagedIdentityTypes]
    # Identity type
    ${IdentityType},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MonitoringStatus])]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MonitoringStatus]
    # Flag specifying if the resource monitoring is enabled or disabled.
    ${MonitoringStatus},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Body')]
    [System.String]
    # Api key associated to the Datadog organization.
    ${OrganizationApiKey},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Body')]
    [System.String]
    # Application key associated to the Datadog organization.
    ${OrganizationApplicationKey},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Body')]
    [System.String]
    # The Id of the Enterprise App used for Single sign on.
    ${OrganizationEnterpriseAppId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Body')]
    [System.String]
    # The auth code used to linking to an existing datadog organization.
    ${OrganizationLinkingAuthCode},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Body')]
    [System.String]
    # The client_id from an existing in exchange for an auth token to link organization.
    ${OrganizationLinkingClientId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Body')]
    [System.String]
    # The redirect uri for linking.
    ${OrganizationRedirectUri},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Body')]
    [System.String]
    # Name of the SKU.
    ${SkuName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceTags]))]
    [System.Collections.Hashtable]
    # Dictionary of <string>
    ${Tag},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Body')]
    [System.String]
    # Email of the user used by Datadog for contacting them if needed
    ${UserInfoEmailAddress},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Body')]
    [System.String]
    # Name of the user
    ${UserInfoName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Body')]
    [System.String]
    # Phone number of the user used by Datadog for contacting them if needed
    ${UserInfoPhoneNumber},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

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

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

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
            CreateExpanded = 'Az.Datadog.private\New-AzDatadogMonitor_CreateExpanded';
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
