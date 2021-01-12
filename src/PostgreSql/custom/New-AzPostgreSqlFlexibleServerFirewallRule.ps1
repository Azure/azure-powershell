
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
Creates a new firewall rule or updates an existing firewall rule.
.Description
Creates a new firewall rule or updates an existing firewall rule.
#>
function New-AzPostgreSqlFlexibleServerFirewallRule {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IFirewallRule])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter()]
    [Alias('FirewallRuleName')]
    [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Path')]
    [System.String]
    # The name of the server firewall rule.
    # If not specified, the default is undefined.
    # If AllowAll is present, the default name is AllowAll_yyyy-MM-dd_HH-mm-ss.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Path')]
    [System.String]
    # The name of the server.
    ${ServerName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Body')]
    [System.String]
    # The end IP address of the server firewall rule.
    # Must be IPv4 format.
    ${EndIPAddress},

    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Body')]
    [System.String]
    # The start IP address of the server firewall rule.
    # Must be IPv4 format.
    ${StartIPAddress},

    [Parameter(ParameterSetName='ClientIPAddress', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Body')]
    [System.String]
    # Client specified single IP of the server firewall rule.
    # Must be IPv4 format.
    ${ClientIPAddress},

    [Parameter(ParameterSetName='AllowAll', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Present to allow all range IPs, from 0.0.0.0 to 255.255.255.255.
    ${AllowAll},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

process {
    try {
        if($PSBoundParameters.ContainsKey('AllowAll'))
        {
            if(!$PSBoundParameters.ContainsKey('Name'))
            {
                $PSBoundParameters['Name'] = Get-Date -Format "AllowAll_yyyy-MM-dd_HH-mm-ss"
            }
            $PSBoundParameters['StartIPAddress'] = "0.0.0.0"
            $PSBoundParameters['EndIPAddress'] = "255.255.255.255"

            $null = $PSBoundParameters.Remove('AllowAll')
        }
        elseif($PSBoundParameters.ContainsKey('ClientIPAddress'))
        {
            $PSBoundParameters['StartIPAddress'] = $PSBoundParameters['ClientIPAddress']
            $PSBoundParameters['EndIPAddress'] = $PSBoundParameters['ClientIPAddress']

            if(!$PSBoundParameters.ContainsKey('Name'))
            {
                $PSBoundParameters['Name'] = "ClientIPAddress_" + (Get-Date -Format "yyyy-MM-dd_HH-mm-ss")
            }

            $null = $PSBoundParameters.Remove('ClientIPAddress')
        }
        else
        {
            if(!$PSBoundParameters.ContainsKey('Name'))
            {
                $PSBoundParameters['Name'] = "undefined"
            }
        }
        $PSBoundParameters['FirewallRuleName'] = $PSBoundParameters['Name']
        $null = $PSBoundParameters.Remove('Name')

        Az.PostgreSql.internal\New-AzPostgreSqlFlexibleServerFirewallRule @PSBoundParameters
    } catch {
        throw
    }
}
}
