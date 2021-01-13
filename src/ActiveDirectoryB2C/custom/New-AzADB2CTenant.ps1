
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
Initiates an async request to create both the Azure AD B2C tenant and the corresponding Azure resource linked to a subscription.
.Description
Initiates an async request to create both the Azure AD B2C tenant and the corresponding Azure resource linked to a subscription.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Models.Api201901Preview.IB2CTenantResource
.Link
https://docs.microsoft.com/en-us/powershell/module/az.activedirectoryb2c/new-azadb2ctenant
#>
function New-AzADB2CTenant {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Models.Api201901Preview.IB2CTenantResource])]
    [CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory)]
        [Alias('ResourceName')]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Category('Path')]
        [System.String]
        # The initial domain name of the B2C tenant.
        ${Name},
        
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Category('Path')]
        [System.String]
        # The name of the resource group.
        ${ResourceGroupName},
        
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # Subscription credentials which uniquely identify Microsoft Azure subscription.
        # The subscription ID forms part of the URI for every service call.
        ${SubscriptionId},
    
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Category('Body')]
        [System.String]
        # The location in which the resource is hosted and data resides.
        # Refer to [this documentation](https://aka.ms/B2CDataResidency) to see valid data residency locations.
        # Please choose one of 'United States', 'Europe', and 'Asia Pacific'.
        ${Location},
    
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Category('Body')]
        [System.String]
        # Country code of Azure tenant (e.g.
        # 'US').
        # Refer to [aka.ms/B2CDataResidency](https://aka.ms/B2CDataResidency) to see valid country codes and corresponding data residency locations.
        # If you do not see a country code in an valid data residency location, choose one from the list.
        ${CountryCode},
    
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Category('Body')]
        [System.String]
        # The display name of the B2C tenant.
        ${DisplayName},
    
        [Parameter(Mandatory)]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Support.B2CResourceSkuname])]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Support.B2CResourceSkuname]
        # The name of the SKU for the tenant.
        ${Sku},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Models.Api201901Preview.ICreateTenantRequestBodyTags]))]
        [System.Collections.Hashtable]
        # Resource Tags
        ${Tag},
    
        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},
    
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
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ActiveDirectoryB2C.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},
    
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
            $PSBoundParameters['SkuTier'] = "A0"
            Write-Debug $PSBoundParameters
            Az.ActiveDirectoryB2C.internal\New-AzADB2CTenant @PSBoundParameters
        } catch {
            throw
        }
    }

}
    