
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
Create or update container groups with specified configurations.
.Description
Create or update container groups with specified configurations.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroup
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

CONTAINER <IContainer[]>: The containers within the container group.
  Image <String>: The name of the image used to create the container instance.
  Name <String>: The user-provided name of the container instance.
  RequestCpu <Double>: The CPU request of this container instance.
  RequestMemoryInGb <Double>: The memory request in GB of this container instance.
  [Command <String[]>]: The commands to execute within the container instance in exec form.
  [EnvironmentVariable <IEnvironmentVariable[]>]: The environment variables to set in the container instance.
    Name <String>: The name of the environment variable.
    [SecureValue <String>]: The value of the secure environment variable.
    [Value <String>]: The value of the environment variable.
  [LimitCpu <Double?>]: The CPU limit of this container instance.
  [LimitMemoryInGb <Double?>]: The memory limit in GB of this container instance.
  [LimitsGpuCount <Int32?>]: The count of the GPU resource.
  [LimitsGpuSku <GpuSku?>]: The SKU of the GPU resource.
  [LivenessProbeExecCommand <String[]>]: The commands to execute within the container.
  [LivenessProbeFailureThreshold <Int32?>]: The failure threshold.
  [LivenessProbeHttpGetHttpHeadersName <String>]: The header name.
  [LivenessProbeHttpGetHttpHeadersValue <String>]: The header value.
  [LivenessProbeHttpGetPath <String>]: The path to probe.
  [LivenessProbeHttpGetPort <Int32?>]: The port number to probe.
  [LivenessProbeHttpGetScheme <Scheme?>]: The scheme.
  [LivenessProbeInitialDelaySecond <Int32?>]: The initial delay seconds.
  [LivenessProbePeriodSecond <Int32?>]: The period seconds.
  [LivenessProbeSuccessThreshold <Int32?>]: The success threshold.
  [LivenessProbeTimeoutSecond <Int32?>]: The timeout seconds.
  [Port <IContainerPort[]>]: The exposed ports on the container instance.
    Port <Int32>: The port number exposed within the container group.
    [Protocol <ContainerNetworkProtocol?>]: The protocol associated with the port.
  [ReadinessProbeExecCommand <String[]>]: The commands to execute within the container.
  [ReadinessProbeFailureThreshold <Int32?>]: The failure threshold.
  [ReadinessProbeHttpGetHttpHeadersName <String>]: The header name.
  [ReadinessProbeHttpGetHttpHeadersValue <String>]: The header value.
  [ReadinessProbeHttpGetPath <String>]: The path to probe.
  [ReadinessProbeHttpGetPort <Int32?>]: The port number to probe.
  [ReadinessProbeHttpGetScheme <Scheme?>]: The scheme.
  [ReadinessProbeInitialDelaySecond <Int32?>]: The initial delay seconds.
  [ReadinessProbePeriodSecond <Int32?>]: The period seconds.
  [ReadinessProbeSuccessThreshold <Int32?>]: The success threshold.
  [ReadinessProbeTimeoutSecond <Int32?>]: The timeout seconds.
  [RequestsGpuCount <Int32?>]: The count of the GPU resource.
  [RequestsGpuSku <GpuSku?>]: The SKU of the GPU resource.
  [VolumeMount <IVolumeMount[]>]: The volume mounts available to the container instance.
    MountPath <String>: The path within the container where the volume should be mounted. Must not contain colon (:).
    Name <String>: The name of the volume mount.
    [ReadOnly <Boolean?>]: The flag indicating whether the volume mount is read-only.

IMAGEREGISTRYCREDENTIALS <IImageRegistryCredential[]>: The image registry credentials by which the container group is created from.
  Server <String>: The Docker image registry server without a protocol such as "http" and "https".
  Username <String>: The username for the private registry.
  [Password <String>]: The password for the private registry.

INITCONTAINER <IInitContainerDefinition[]>: The init containers for a container group.
  Name <String>: The name for the init container.
  [Command <String[]>]: The command to execute within the init container in exec form.
  [EnvironmentVariable <IEnvironmentVariable[]>]: The environment variables to set in the init container.
    Name <String>: The name of the environment variable.
    [SecureValue <String>]: The value of the secure environment variable.
    [Value <String>]: The value of the environment variable.
  [Image <String>]: The image of the init container.
  [VolumeMount <IVolumeMount[]>]: The volume mounts available to the init container.
    MountPath <String>: The path within the container where the volume should be mounted. Must not contain colon (:).
    Name <String>: The name of the volume mount.
    [ReadOnly <Boolean?>]: The flag indicating whether the volume mount is read-only.

IPADDRESSPORT <IPort[]>: The list of ports exposed on the container group.
  Port1 <Int32>: The port number.
  [Protocol <ContainerGroupNetworkProtocol?>]: The protocol associated with the port.

VOLUME <IVolume[]>: The list of volumes that can be mounted by containers in this container group.
  Name <String>: The name of the volume.
  [AzureFileReadOnly <Boolean?>]: The flag indicating whether the Azure File shared mounted as a volume is read-only.
  [AzureFileShareName <String>]: The name of the Azure File share to be mounted as a volume.
  [AzureFileStorageAccountKey <String>]: The storage account access key used to access the Azure File share.
  [AzureFileStorageAccountName <String>]: The name of the storage account that contains the Azure File share.
  [EmptyDir <IAny>]: The empty directory volume.
  [GitRepoDirectory <String>]: Target directory name. Must not contain or start with '..'.  If '.' is supplied, the volume directory will be the git repository.  Otherwise, if specified, the volume will contain the git repository in the subdirectory with the given name.
  [GitRepoRepository <String>]: Repository URL
  [GitRepoRevision <String>]: Commit hash for the specified revision.
  [Secret <ISecretVolume>]: The secret volume.
    [(Any) <String>]: This indicates any property can be added to this object.
.Link
https://docs.microsoft.com/powershell/module/containerinstance/new-azcontainergroup
#>
function New-AzContainerGroup {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroup])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('ContainerGroupName')]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Path')]
    [System.String]
    # The name of the container group.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Path')]
    [System.String]
    # The name of the resource group.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription credentials which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainer[]]
    # The containers within the container group.
    # To construct, see NOTES section for CONTAINER properties and create a hash table.
    ${Container},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.OperatingSystemTypes])]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.String]
    # The operating system type required by the containers in the container group.
    ${OSType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.String[]]
    # The DNS servers for the container group.
    ${DnsConfigNameServer},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.String]
    # The DNS options for the container group.
    ${DnsConfigOption},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.String]
    # The DNS search domains for hostname lookup in the container group.
    ${DnsConfigSearchDomain},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.String]
    # The encryption key name.
    ${EncryptionPropertyKeyName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.String]
    # The encryption key version.
    ${EncryptionPropertyKeyVersion},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.String]
    # The keyvault base url.
    ${EncryptionPropertyVaultBaseUrl},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.String]
    # The Dns name label for the IP.
    ${IPAddressDnsNameLabel},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.String]
    # The IP exposed to the public internet.
    ${IPAddressIP},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IPort[]]
    # The list of ports exposed on the container group.
    # To construct, see NOTES section for IPADDRESSPORT properties and create a hash table.
    ${IPAddressPort},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupIPAddressType])]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.String]
    # Specifies if the IP is exposed to the public internet or private VNET.
    ${IPAddressType},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ResourceIdentityType])]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.String]
    # The type of identity used for the container group.
    # The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity and a set of user assigned identities.
    # The type 'None' will remove any identities from the container group.
    ${IdentityType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupIdentityUserAssignedIdentities]))]
    [System.String[]]
    # The list of user identities associated with the container group.
    # The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
    ${IdentityUserAssignedIdentity},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IImageRegistryCredential[]]
    # The image registry credentials by which the container group is created from.
    # To construct, see NOTES section for IMAGEREGISTRYCREDENTIALS properties and create a hash table.
    ${ImageRegistryCredential},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinition[]]
    # The init containers for a container group.
    # To construct, see NOTES section for INITCONTAINER properties and create a hash table.
    ${InitContainer},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.String]
    # The resource location.
    ${Location},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.LogAnalyticsLogType])]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.String]
    # The log type to be used.
    ${LogAnalyticLogType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsMetadata]))]
    [System.Collections.Hashtable]
    # Metadata for log analytics.
    ${LogAnalyticMetadata},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.String]
    # The workspace id for log analytics
    ${LogAnalyticWorkspaceId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.String]
    # The workspace key for log analytics
    ${LogAnalyticWorkspaceKey},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsWorkspaceResourceId]))]
    [System.Collections.Hashtable]
    # The workspace resource id for log analytics
    ${LogAnalyticWorkspaceResourceId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.String]
    # The identifier for a network profile.
    ${NetworkProfileId},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupRestartPolicy])]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.String]
    # Restart policy for all containers within the container group.
    # - `Always` Always restart- `OnFailure` Restart on failure- `Never` Never restart
    ${RestartPolicy},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupSku])]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.String]
    # The SKU for a container group.
    ${Sku},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceTags]))]
    [System.Collections.Hashtable]
    # The resource tags.
    ${Tag},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolume[]]
    # The list of volumes that can be mounted by containers in this container group.
    # To construct, see NOTES section for VOLUME properties and create a hash table.
    ${Volume},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)
process {
    try {
      if($PSBoundParameters.ContainsKey("ImageRegistryCredential")){
        $null = $PSBoundParameters.Add("ImageRegistryCredentials", $ImageRegistryCredential)
        $null = $PSBoundParameters.Remove("ImageRegistryCredential")        
      }

      if($PSBoundParameters.ContainsKey("IPAddressType") -and !$PSBoundParameters.ContainsKey("IPAddressPort"))
      {
        $null = $PSBoundParameters.Add("IPAddressPort", $Container.Port)
      }
      
      if(!$PSBoundParameters.ContainsKey("OSType"))
      {
        $null = $PSBoundParameters.Add("OSType", "Linux")
      }

      if($PSBoundParameters.ContainsKey("IdentityUserAssignedIdentity"))
      {
        $IdentityUserAssignedIdentityHashTable = @{}
        foreach ($identity in $IdentityUserAssignedIdentity) {
          $IdentityUserAssignedIdentityHashTable.Add($identity, @{})
        }
        $null = $PSBoundParameters["IdentityUserAssignedIdentity"] = $IdentityUserAssignedIdentityHashTable
      }
      
      Az.ContainerInstance.internal\New-AzContainerGroup @PSBoundParameters
    } catch {
        throw
    }
}

}
