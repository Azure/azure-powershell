
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
Creates or updates an account
.Description
Creates or updates an account
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccount
.Link
https://docs.microsoft.com/powershell/module/az.purview/new-azpurviewaccount
#>
function New-AzPurviewAccount {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccount])]
    [CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory)]
        [Alias('AccountName')]
        [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Path')]
        [System.String]
        # The name of the account.
        ${Name},
    
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Path')]
        [System.String]
        # The resource group name.
        ${ResourceGroupName},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The subscription identifier
        ${SubscriptionId},
    
        [Parameter(Mandatory)]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.Type])]
        [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.Type]
        # Identity Type
        ${IdentityType},
    
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Body')]
        [System.String]
        # Gets or sets the location.
        ${Location},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Body')]
        [System.String]
        # Gets or sets the managed resource group name
        ${ManagedResourceGroupName},
    
        [Parameter()]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.PublicNetworkAccess])]
        [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.PublicNetworkAccess]
        # Gets or sets the public network access.
        ${PublicNetworkAccess},
    
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Body')]
        [System.Int32]
        # Gets or sets the sku capacity.
        # Possible values include: 4, 16
        ${SkuCapacity},
    
        [Parameter(Mandatory)]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.Name])]
        [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.Name]
        # Gets or sets the sku name.
        ${SkuName},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceTags]))]
        [System.Collections.Hashtable]
        # Tags on the azure resource.
        ${Tag},
    
        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},
    
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
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},
    
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
        Az.Purview.internal\New-AzPurviewAccount @PSBoundParameters
    } catch {
        throw
    }
}
}
