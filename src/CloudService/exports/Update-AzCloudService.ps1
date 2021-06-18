
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
Create or update a cloud service.
Please note some properties can be set only during cloud service creation.
.Description
Create or update a cloud service.
Please note some properties can be set only during cloud service creation.
.Example
# Create RDP extension object
PS C:\> $rdpExtension = New-AzCloudServiceRemoteDesktopExtensionObject -Name "RDPExtension" -Credential $credential -Expiration $expiration -TypeHandlerVersion "1.2.1"
# Get existing cloud service
PS C:\> $cloudService = Get-AzCloudService -ResourceGroup "ContosOrg" -CloudServiceName "ContosoCS"
# Add RDP extension to existing cloud service extension object
PS C:\> $cloudService.ExtensionProfile.Extension = $cloudService.ExtensionProfile.Extension + $rdpExtension
# Update cloud service
PS C:\> $cloudService | Update-AzCloudService
.Example
# Get existing cloud service
PS C:\> $cloudService = Get-AzCloudService -ResourceGroup "ContosOrg" -CloudServiceName "ContosoCS"
# Set extension to empty list
PS C:\> $cloudService.ExtensionProfile.Extension = @()
# Update cloud service
PS C:\> $cloudService | Update-AzCloudService
.Example
# Get existing cloud service
PS C:\> $cloudService = Get-AzCloudService -ResourceGroup "ContosOrg" -CloudServiceName "ContosoCS"
# Remove extension by name RDPExtension
PS C:\> $cloudService.ExtensionProfile.Extension = $cloudService.ExtensionProfile.Extension | Where-Object { $_.Name -ne "RDPExtension" }
# Update cloud service
PS C:\> $cloudService | Update-AzCloudService
.Example
# Get existing cloud service
PS C:\> $cloudService = Get-AzCloudService -ResourceGroup "ContosOrg" -CloudServiceName "ContosoCS"

# Scale-out all role instance count by 1
PS C:\> $cloudService.RoleProfile.Role | ForEach-Object {$_.SkuCapacity += 1}

# Scale-in ContosoFrontend role instance count by 1
PS C:\> $role = $cloudService.RoleProfile.Role | Where-Object {$_.Name -eq "ContosoFrontend"}
PS C:\> $role.SkuCapacity -= 1

# Update cloud service configuration as per the new role instance count
PS C:\> $cloudService.Configuration = $configuration

# Update cloud service
PS C:\> $cloudService | Update-AzCloudService

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudService
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudService
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <ICloudServiceIdentity>: Identity Parameter
  [CloudServiceName <String>]: 
  [Id <String>]: Resource identity path
  [Location <String>]: Name of the location that the OS version pertains to.
  [OSFamilyName <String>]: Name of the OS family.
  [OSVersionName <String>]: Name of the OS version.
  [ResourceGroupName <String>]: 
  [RoleInstanceName <String>]: Name of the role instance.
  [RoleName <String>]: Name of the role.
  [SubscriptionId <String>]: Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  [UpdateDomain <Int32?>]: Specifies an integer value that identifies the update domain. Update domains are identified with a zero-based index: the first update domain has an ID of 0, the second has an ID of 1, and so on.

PARAMETER <ICloudService>: Describes the cloud service.
  Location <String>: Resource location.
  [AllowModelOverride <Boolean?>]: (Optional) Indicates whether the role sku properties (roleProfile.roles.sku) specified in the model/template should override the role instance count and vm size specified in the .cscfg and .csdef respectively.         The default value is `false`.
  [Configuration <String>]: Specifies the XML service configuration (.cscfg) for the cloud service.
  [ConfigurationUrl <String>]: Specifies a URL that refers to the location of the service configuration in the Blob service. The service package URL  can be Shared Access Signature (SAS) URI from any storage account.         This is a write-only property and is not returned in GET calls.
  [ExtensionProfile <ICloudServiceExtensionProfile>]: Describes a cloud service extension profile.
    [Extension <IExtension[]>]: List of extensions for the cloud service.
      [AutoUpgradeMinorVersion <Boolean?>]: Explicitly specify whether platform can automatically upgrade typeHandlerVersion to higher minor versions when they become available.
      [ForceUpdateTag <String>]: Tag to force apply the provided public and protected settings.         Changing the tag value allows for re-running the extension without changing any of the public or protected settings.         If forceUpdateTag is not changed, updates to public or protected settings would still be applied by the handler.         If neither forceUpdateTag nor any of public or protected settings change, extension would flow to the role instance with the same sequence-number, and         it is up to handler implementation whether to re-run it or not
      [Name <String>]: The name of the extension.
      [ProtectedSetting <String>]: Protected settings for the extension which are encrypted before sent to the role instance.
      [ProtectedSettingFromKeyVaultSecretUrl <String>]: 
      [Publisher <String>]: The name of the extension handler publisher.
      [RolesAppliedTo <String[]>]: Optional list of roles to apply this extension. If property is not specified or '*' is specified, extension is applied to all roles in the cloud service.
      [Setting <String>]: Public settings for the extension. For JSON extensions, this is the JSON settings for the extension. For XML Extension (like RDP), this is the XML setting for the extension.
      [SourceVaultId <String>]: Resource Id
      [Type <String>]: Specifies the type of the extension.
      [TypeHandlerVersion <String>]: Specifies the version of the extension. Specifies the version of the extension. If this element is not specified or an asterisk (*) is used as the value, the latest version of the extension is used. If the value is specified with a major version number and an asterisk as the minor version number (X.), the latest minor version of the specified major version is selected. If a major version number and a minor version number are specified (X.Y), the specific extension version is selected. If a version is specified, an auto-upgrade is performed on the role instance.
  [NetworkProfile <ICloudServiceNetworkProfile>]: Network Profile for the cloud service.
    [LoadBalancerConfiguration <ILoadBalancerConfiguration[]>]: List of Load balancer configurations. Cloud service can have up to two load balancer configurations, corresponding to a Public Load Balancer and an Internal Load Balancer.
      FrontendIPConfiguration <ILoadBalancerFrontendIPConfiguration[]>: Specifies the frontend IP to be used for the load balancer. Only IPv4 frontend IP address is supported. Each load balancer configuration must have exactly one frontend IP configuration.
        Name <String>: The name of the resource that is unique within the set of frontend IP configurations used by the load balancer. This name can be used to access the resource.
        [PrivateIPAddress <String>]: The virtual network private IP address of the IP configuration.
        [PublicIPAddressId <String>]: Resource Id
        [SubnetId <String>]: Resource Id
      Name <String>: The name of the Load balancer
      [Id <String>]: Resource Id
    [SwappableCloudService <ISubResource>]: The id reference of the cloud service containing the target IP with which the subject cloud service can perform a swap. This property cannot be updated once it is set. The swappable cloud service referred by this id must be present otherwise an error will be thrown.
      [Id <String>]: Resource Id
  [OSProfile <ICloudServiceOSProfile>]: Describes the OS profile for the cloud service.
    [Secret <ICloudServiceVaultSecretGroup[]>]: Specifies set of certificates that should be installed onto the role instances.
      [SourceVaultId <String>]: Resource Id
      [VaultCertificate <ICloudServiceVaultCertificate[]>]: The list of key vault references in SourceVault which contain certificates.
        [CertificateUrl <String>]: This is the URL of a certificate that has been uploaded to Key Vault as a secret.
  [PackageUrl <String>]: Specifies a URL that refers to the location of the service package in the Blob service. The service package URL can be Shared Access Signature (SAS) URI from any storage account.         This is a write-only property and is not returned in GET calls.
  [RoleProfile <ICloudServiceRoleProfile>]: Describes the role profile for the cloud service.
    [Role <ICloudServiceRoleProfileProperties[]>]: List of roles for the cloud service.
      [Name <String>]: Resource name.
      [SkuCapacity <Int64?>]: Specifies the number of role instances in the cloud service.
      [SkuName <String>]: The sku name. NOTE: If the new SKU is not supported on the hardware the cloud service is currently on, you need to delete and recreate the cloud service or move back to the old sku.
      [SkuTier <String>]: Specifies the tier of the cloud service. Possible Values are <br /><br /> **Standard** <br /><br /> **Basic**
  [StartCloudService <Boolean?>]: (Optional) Indicates whether to start the cloud service immediately after it is created. The default value is `true`.         If false, the service model is still deployed, but the code is not run immediately. Instead, the service is PoweredOff until you call Start, at which time the service will be started. A deployed service still incurs charges, even if it is poweredoff.
  [Tag <ICloudServiceTags>]: Resource tags.
    [(Any) <String>]: This indicates any property can be added to this object.
  [UpgradeMode <CloudServiceUpgradeMode?>]: Update mode for the cloud service. Role instances are allocated to update domains when the service is deployed. Updates can be initiated manually in each update domain or initiated automatically in all update domains.         Possible Values are <br /><br />**Auto**<br /><br />**Manual** <br /><br />**Simultaneous**<br /><br />         If not specified, the default value is Auto. If set to Manual, PUT UpdateDomain must be called to apply the update. If set to Auto, the update is automatically applied to each update domain in sequence.
.Link
https://docs.microsoft.com/powershell/module/az.cloudservice/update-azcloudservice
#>
function Update-AzCloudService {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudService])]
[CmdletBinding(DefaultParameterSetName='CreateViaIdentity', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudService]
    # Describes the cloud service.
    # To construct, see NOTES section for PARAMETER properties and create a hash table.
    ${Parameter},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
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
            CreateViaIdentity = 'Az.CloudService.private\Update-AzCloudService_CreateViaIdentity';
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
