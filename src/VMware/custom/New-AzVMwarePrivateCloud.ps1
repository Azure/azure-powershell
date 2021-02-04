
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
Create or update a private cloud
.Description
Create or update a private cloud
.Example
```powershell
PS C:\> New-AzVMwarePrivateCloud -Name azps-test-cloud -ResourceGroupName azps-test-group -NetworkBlock 192.168.48.0/22 -SkuName av36 -ManagementClusterSize 3 -Location australiaeast

Location      Name            Type
--------      ----            ----
australiaeast azps-test-cloud Microsoft.AVS/privateClouds
```

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloud
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

IDENTITYSOURCE <IIdentitySource[]>: vCenter Single Sign On Identity Sources
  [Alias <String>]: The domain's NetBIOS name
  [BaseGroupDn <String>]: The base distinguished name for groups
  [BaseUserDn <String>]: The base distinguished name for users
  [Domain <String>]: The domain's dns name
  [Name <String>]: The name of the identity source
  [Password <String>]: The password of the Active Directory user with a minimum of read-only access to Base DN for users and groups.
  [PrimaryServer <String>]: Primary server URL
  [SecondaryServer <String>]: Secondary server URL
  [Ssl <SslEnum?>]: Protect LDAP communication using SSL certificate (LDAPS)
  [Username <String>]: The ID of an Active Directory user with a minimum of read-only access to Base DN for users and group
.Link
https://docs.microsoft.com/en-us/powershell/module/az.VMware/new-azVMwareprivatecloud
#>
function New-AzVMwarePrivateCloud {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloud])]
    [CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory)]
        [Alias('PrivateCloudName')]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Path')]
        [System.String]
        # Name of the private cloud
        ${Name},
    
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Path')]
        [System.String]
        # The name of the resource group.
        # The name is case insensitive.
        ${ResourceGroupName},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},
    
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Body')]
        [System.String]
        # The block of addresses should be unique across VNet in your subscription as well as on-premise.
        # Make sure the CIDR format is conformed to (A.B.C.D/X) where A,B,C,D are between 0 and 255, and X is between 0 and 22
        ${NetworkBlock},
    
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Body')]
        [System.String]
        # The name of the SKU.
        ${Sku},
    
        [Parameter()]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.InternetEnum])]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.InternetEnum]
        # Connectivity to internet is enabled or disabled
        ${Internet},
    
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Body')]
        [System.String]
        # Resource location
        ${Location},
    
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Body')]
        [System.Int32]
        # The cluster size
        ${ManagementClusterSize},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Body')]
        [System.String]
        # Optionally, set the NSX-T Manager password when the private cloud is created
        ${NsxtPassword},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ITrackedResourceTags]))]
        [System.Collections.Hashtable]
        # Resource tags
        ${Tag},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Body')]
        [System.String]
        # Optionally, set the vCenter admin password when the private cloud is created
        ${VcenterPassword},
    
        [Parameter()]
        [System.Management.Automation.SwitchParameter]
        # Accept EULA of AVS, legal term will pop up without this parameter provided
        ${AcceptEULA},
        
        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )
    
    process {
        if(!$AcceptEULA){
            $legalTermPath = Join-Path $PSScriptRoot -ChildPath "LegalTerm.txt"
            try {
                $legalTerm = (Get-Content -Path $legalTermPath) -join "`r`n"
            } catch {
                throw 
            }
            $confirmation = Read-Host $legalTerm"`n[Y] Yes  [N] No  (default is `"N`")"
            switch ($confirmation) {
                'Y' {
                    Break
                }

                Default {
                    Return
                }
            }
        }else {
            $null = $PSBoundParameters.Remove('AcceptEULA')
        }

        try {
            if($PSBoundParameters.ContainsKey('Sku')) {
                $sku = $PSBoundParameters['Sku']
                $null = $PSBoundParameters.Remove('Sku')
                $PSBoundParameters.Add('SkuName', $sku)
            }  
            Az.VMware.internal\New-AzVMwarePrivateCloud @PSBoundParameters
        } catch {
            throw
        }
    }
}
    
