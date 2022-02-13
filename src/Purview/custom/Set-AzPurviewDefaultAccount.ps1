
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
Sets the default account for the scope.
.Description
Sets the default account for the scope.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IDefaultAccountPayload
.Link
https://docs.microsoft.com/powershell/module/az.purview/set-azpurviewdefaultaccount
#>
function Set-AzPurviewDefaultAccount {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IDefaultAccountPayload])]
[CmdletBinding(DefaultParameterSetName='SetExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Body')]
    [System.String]
    # The name of the account that is set as the default.
    ${AccountName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Body')]
    [System.String]
    # The resource group name of the account that is set as the default.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Body')]
    [System.String]
    # The scope object ID.
    # For example, sub ID or tenant ID.
    ${Scope},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Body')]
    [System.String]
    # The scope tenant in which the default account is set.
    ${ScopeTenantId},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.ScopeType])]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.ScopeType]
    # The scope where the default account is set.
    ${ScopeType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription ID of the account that is set as the default.
    ${SubscriptionId},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)
process {
    try {
        Az.Purview.internal\Set-AzPurviewDefaultAccount @PSBoundParameters
    } catch {
        throw
    }
}
}
