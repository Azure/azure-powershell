
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
Get the network interfaces of a cloud service.
.Description
Get the network interfaces of a cloud service.
.Example
PS C:\> Get-AzCloudServiceNetworkInterfaces -ResourceGroupName "BRGThree" -CloudServiceName BService -SubscriptionId 1133e0eb-b53c-1234-b478-2eac8f04afca

.Example
PS C:\> $cs = Get-AzCloudService -ResourceGroupName "BRGThree" -CloudServiceName BService -SubscriptionId 1133e0eb-b53c-1234-b478-2eac8f04afca
PS C:\> Get-AzCloudServiceNetworkInterfaces -CloudService $cs

.Example
PS C:\> Get-AzCloudServiceNetworkInterfaces -CloudService $cs -RoleInstanceName WebRole1_IN_0


.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

CLOUDSERVICE <CloudService>: CloudService instance.
  Location <String>: Resource location.
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
    [LoadBalancerConfiguration <ILoadBalancerConfiguration[]>]: The list of load balancer configurations for the cloud service.
      [FrontendIPConfiguration <ILoadBalancerFrontendIPConfiguration[]>]: List of IP
        [Name <String>]: 
        [PrivateIPAddress <String>]: The private IP address referenced by the cloud service.
        [PublicIPAddressId <String>]: Resource Id
        [SubnetId <String>]: Resource Id
      [Name <String>]: Resource Name
    [SwappableCloudService <ISubResource>]: 
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
https://docs.microsoft.com/en-us/powershell/module/az.cloudservice/get-AzCloudServiceNetworkInterfaces
#>
function Get-AzCloudServiceNetworkInterfaces {
[CmdletBinding(DefaultParameterSetName='CloudServiceName', PositionalBinding=$false)]
param(
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='CloudService', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.CloudService]
    # CloudService instance.
    # To construct, see NOTES section for CLOUDSERVICE properties and create a hash table.
    ${CloudService},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # RoleInstanceName.
    ${RoleInstanceName},

    [Parameter(ParameterSetName='CloudServiceName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # ResourceGroupName.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='CloudServiceName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # CloudServiceName.
    ${CloudServiceName}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            CloudService = 'Az.CloudService.custom\Get-AzCloudServiceNetworkInterfaces';
            CloudServiceName = 'Az.CloudService.custom\Get-AzCloudServiceNetworkInterfaces';
        }
        if (('CloudService', 'CloudServiceName') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
