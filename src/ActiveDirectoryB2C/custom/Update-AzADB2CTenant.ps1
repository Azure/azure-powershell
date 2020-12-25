
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
Update the Azure AD B2C tenant resource.
.Description
Update the Azure AD B2C tenant resource.

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Models.IActiveDirectoryB2CIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Models.Api201901Preview.IB2CTenantResource
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IActiveDirectoryB2CIdentity>: Identity Parameter
  [Id <String>]: Resource identity path
  [OperationId <String>]: The operation ID.
  [ResourceGroupName <String>]: The name of the resource group.
  [ResourceName <String>]: The initial domain name of the B2C tenant.
  [SubscriptionId <String>]: Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.activedirectoryb2c/update-azadb2ctenant
#>
function Update-AzADB2CTenant {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Models.Api201901Preview.IB2CTenantResource])]
    [CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Category('Path')]
        [System.String]
        # The name of the resource group.
        ${ResourceGroupName},
    
        [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
        [Alias('ResourceName')]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Category('Path')]
        [System.String]
        # The initial domain name of the B2C tenant.
        ${Name},
    
        [Parameter(ParameterSetName='UpdateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # Subscription credentials which uniquely identify Microsoft Azure subscription.
        # The subscription ID forms part of the URI for every service call.
        ${SubscriptionId},
    
        [Parameter(ParameterSetName='UpdateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Models.IActiveDirectoryB2CIdentity]
        # Identity Parameter
        # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
        ${InputObject},
    
        [Parameter()]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Support.BillingType])]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Support.BillingType]
        # The type of billing.
        # Will be MAU for all new customers.
        # If 'Auths', it can be updated to 'MAU'.
        # Cannot be changed if value is 'MAU'.
        # Learn more about Azure AD B2C billing at [aka.ms/b2cBilling](https://aka.ms/b2cbilling).
        ${BillingType},
    
        [Parameter()]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Support.B2CResourceSkuname])]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Support.B2CResourceSkuname]
        # The name of the SKU for the tenant.
        ${Sku},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Models.Api201901Preview.IB2CTenantUpdateRequestTags]))]
        [System.Collections.Hashtable]
        # Resource Tags
        ${Tag},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Category('Body')]
        [System.String]
        # An identifier of the B2C tenant.
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
            if ($PSBoundParameters.ContainsKey('Sku')) {
                $PSBoundParameters['SkuTier'] = "A0"
            }
            Az.ActiveDirectoryB2C.internal\Update-AzADB2CTenant @PSBoundParameters
        } catch {
            throw
        }
    }

}
    