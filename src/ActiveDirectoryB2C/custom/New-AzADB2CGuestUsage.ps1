
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
Creates a Guest Usages resource for the Microsoft.AzureActiveDirectory resource provider
.Description
Creates a Guest Usages resource for the Microsoft.AzureActiveDirectory resource provider
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Models.Api20200501Preview.IGuestUsagesResource
.Link
https://docs.microsoft.com/en-us/powershell/module/az.activedirectoryb2c/new-azadb2cguestusage
#>
function New-AzADB2CGuestUsage {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Models.Api20200501Preview.IGuestUsagesResource])]
    [CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Category('Path')]
        [System.String]
        # The name of the resource group.
        ${ResourceGroupName},
    
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Category('Path')]
        [System.String]
        # The initial domain name of the AAD tenant.
        ${ResourceName},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The Azure subscription ID.
        # This is a GUID-formatted string (e.g.
        # 00000000-0000-0000-0000-000000000000)
        ${SubscriptionId},
    
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Category('Body')]
        [System.String]
        # Location of the Guest Usages resource.
        ${Location},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Models.Api20200501Preview.IGuestUsagesResourceTags]))]
        [System.Collections.Hashtable]
        # Key-value pairs of additional resource provisioning properties.
        ${Tag},
    
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Category('Body')]
        [System.String]
        # An identifier for the tenant for which the resource is being created
        ${TenantId},
    
        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )
   
    process {
        try {
            Az.ActiveDirectoryB2C.internal\New-AzADB2CGuestUsage @PSBoundParameters
        } catch {
            throw
        }
    }

}
    