
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
The Create Domain Service operation creates a new domain service with the specified parameters.
If the specific service already exists, then any patchable properties will be updated and any immutable properties will remain unchanged.
.Description
The Create Domain Service operation creates a new domain service with the specified parameters.
If the specific service already exists, then any patchable properties will be updated and any immutable properties will remain unchanged.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainService
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

REPLICASET <IReplicaSet[]>: List of ReplicaSets
  [Location <String>]: Virtual network location
  [SubnetId <String>]: The name of the virtual network that Domain Services will be deployed on. The id of the subnet that Domain Services will be deployed on. /virtualNetwork/vnetName/subnets/subnetName.

RESOURCEFORESTSETTING <IForestTrust[]>: List of settings for Resource Forest
  [FriendlyName <String>]: Friendly Name
  [RemoteDnsIP <String>]: Remote Dns ips
  [TrustDirection <String>]: Trust Direction
  [TrustPassword <String>]: Trust Password
  [TrustedDomainFqdn <String>]: Trusted Domain FQDN
.Link
https://docs.microsoft.com/en-us/powershell/module/az.addomainservices/new-azaddomainservice
#>
function New-AzADDomainService {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainService])]
    [CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory)]
        [Alias('DomainServiceName')]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Path')]
        [System.String]
        # The name of the domain service.
        ${Name},
    
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Path')]
        [System.String]
        # The name of the resource group within the user's subscription.
        # The name is case insensitive.
        ${ResourceGroupName},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # Gets subscription credentials which uniquely identify the Microsoft Azure subscription.
        # The subscription ID forms part of the URI for every service call.
        ${SubscriptionId},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
        [ValidateSet("FullySynced", "ResourceTrusting")]
        [System.String]
        # Domain Configuration Type
        ${DomainConfigurationType},
    
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
        [System.String]
        # The name of the Azure domain that the user would like to deploy Domain Services to.
        ${DomainName},
        
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.DomainSecuritySettings]
        # Domain Security Settings.
        ${DomainSecuritySetting},
    
        [Parameter()]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.FilteredSync])]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
        [ValidateSet("Enabled", "Disabled")]
        [System.String]
        # Enabled or Disabled flag to turn on Group-based filtered sync
        ${FilteredSync},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.LdapsSettings]
        # Secure LDAP Settings.
        ${LdapsSetting},
            
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.NotificationSettings]
        # Notification Settings.
        ${NotificationSetting},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSet[]]
        # List of ReplicaSets
        # To construct, see NOTES section for REPLICASET properties and create a hash table.
        ${ReplicaSet},
        
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ResourceForestSettings]
        # Settings for Resource Forest.
        ${ResourceForestSetting},
        
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
        [ValidateSet("Standard", "Enterprise", "Premium")]
        [System.String]
        # Sku Type
        ${Sku},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResourceTags]))]
        [System.Collections.Hashtable]
        # Resource tags
        ${Tag},
    
        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )

    process {
        try {
            $PSBoundParameters['Location'] = $PSBoundParameters['ReplicaSet'][0].Location

            if ($PSBoundParameters.ContainsKey('DomainSecuritySetting')) {
                $PSBoundParameters['DomainSecuritySettingNtlmV1'] = $PSBoundParameters['DomainSecuritySetting'].NtlmV1
                $PSBoundParameters['DomainSecuritySettingSyncKerberosPassword'] = $PSBoundParameters['DomainSecuritySetting'].SyncKerberosPassword
                $PSBoundParameters['DomainSecuritySettingSyncNtlmPassword'] = $PSBoundParameters['DomainSecuritySetting'].SyncNtlmPassword
                $PSBoundParameters['DomainSecuritySettingSyncOnPremPassword'] = $PSBoundParameters['DomainSecuritySetting'].SyncOnPremPassword
                $PSBoundParameters['DomainSecuritySettingTlsV1'] = $PSBoundParameters['DomainSecuritySetting'].TlsV1
                $null = $PSBoundParameters.Remove('DomainSecuritySetting')
            }

            if ($PSBoundParameters.ContainsKey('LdapsSetting')) {
                $PSBoundParameters['LdapSettingExternalAccess'] = $PSBoundParameters['LdapsSetting'].ExternalAccess
                $PSBoundParameters['LdapSettingLdap'] = $PSBoundParameters['LdapsSetting'].Ldap
                $PSBoundParameters['LdapSettingPfxCertificate'] = $PSBoundParameters['LdapsSetting'].PfxCertificate
                $PSBoundParameters['LdapSettingPfxCertificatePassword'] = $PSBoundParameters['LdapsSetting'].PfxCertificatePassword
                $null = $PSBoundParameters.Remove('LdapsSetting')

            }

            if ($PSBoundParameters.ContainsKey('ResourceForestSetting')) {
                $PSBoundParameters['ResourceForest'] = $PSBoundParameters['ResourceForestSetting'].ResourceForest
                $PSBoundParameters['ForestTrust'] = $PSBoundParameters['ResourceForestSetting'].Setting
                $null = $PSBoundParameters.Remove('ResourceForestSetting')
            }
   
            if ($PSBoundParameters.ContainsKey('NotificationSetting')) {
                $PSBoundParameters['NotificationSettingAdditionalRecipient'] = $PSBoundParameters['NotificationSetting'].AdditionalRecipient
                $PSBoundParameters['NotificationSettingNotifyDcAdmin'] = $PSBoundParameters['NotificationSetting'].NotifyDcAdmin
                $PSBoundParameters['NotificationSettingNotifyGlobalAdmin'] = $PSBoundParameters['NotificationSetting'].NotifyGlobalAdmin
                $null = $PSBoundParameters.Remove('NotificationSetting')
            }
            Az.ADDomainServices.internal\New-AzADDomainService @PSBoundParameters
        } catch {
            throw
        }
    }

}
    