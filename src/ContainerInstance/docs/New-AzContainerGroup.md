---
external help file:
Module Name: Az.ContainerInstance
online version: https://docs.microsoft.com/powershell/module/containerinstance/new-azcontainergroup
schema: 2.0.0
---

# New-AzContainerGroup

## SYNOPSIS
Create or update container groups with specified configurations.

## SYNTAX

```
New-AzContainerGroup -Name <String> -ResourceGroupName <String> -Container <IContainer[]> -Location <String>
 [-SubscriptionId <String>] [-DnsConfigNameServer <String[]>] [-DnsConfigOption <String>]
 [-DnsConfigSearchDomain <String>] [-EncryptionPropertyKeyName <String>]
 [-EncryptionPropertyKeyVersion <String>] [-EncryptionPropertyVaultBaseUrl <String>] [-IdentityType <String>]
 [-IdentityUserAssignedIdentity <String[]>] [-ImageRegistryCredential <IImageRegistryCredential[]>]
 [-InitContainer <IInitContainerDefinition[]>] [-IPAddressDnsNameLabel <String>] [-IPAddressIP <String>]
 [-IPAddressPort <IPort[]>] [-IPAddressType <String>] [-LogAnalyticLogType <String>]
 [-LogAnalyticMetadata <Hashtable>] [-LogAnalyticWorkspaceId <String>] [-LogAnalyticWorkspaceKey <String>]
 [-LogAnalyticWorkspaceResourceId <Hashtable>] [-NetworkProfileId <String>] [-OSType <String>]
 [-RestartPolicy <String>] [-Sku <String>] [-Tag <Hashtable>] [-Volume <IVolume[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or update container groups with specified configurations.

## EXAMPLES

### Example 1: Create a container group with a container instance and request a public IP address with opening ports
```powershell
PS C:\> $port1 = New-AzContainerInstancePortObject -Port 8000 -Protocol TCP
PS C:\> $port2 = New-AzContainerInstancePortObject -Port 8001 -Protocol TCP
PS C:\> $container = New-AzContainerInstanceObject -Name test-container -Image nginx -RequestCpu 1 -RequestMemoryInGb 1.5 -Port @($port1, $port2)
PS C:\> $containerGroup = New-AzContainerGroup -ResourceGroupName test-rg -Name test-cg -Location eastus -Container $container -OsType Linux -RestartPolicy "Never" -IpAddressType Public

Location Name    Type
-------- ----    ----
eastus   test-cg Microsoft.ContainerInstance/containerGroups
```

This commands creates a container group with a container instance, whose image is latest nginx, and requests a public IP address with opening port 8000 and 8001.

### Example 2: Create container group and runs a custom script inside the container.
```powershell
PS C:\>  $env1 = New-AzContainerInstanceEnvironmentVariableObject -Name "env1" -Value "value1"
PS C:\>  $env2 = New-AzContainerInstanceEnvironmentVariableObject -Name "env2" -SecureValue (ConvertTo-SecureString -String "value2" -AsPlainText -Force)
PS C:\>  $container = New-AzContainerInstanceObject -Name test-container -Image alpine -Command "/bin/sh -c myscript.sh" -EnvironmentVariable @($env1, $env2)
PS C:\>  $containerGroup = New-AzContainerGroup -ResourceGroupName test-rg -Name test-cg -Location eastus -Container $container -OsType Linux

Location Name    Type
-------- ----    ----
eastus   test-cg Microsoft.ContainerInstance/containerGroups
```

This commands creates a container group and runs a custom script inside the container.

### Example 3: Create a run-to-completion container group
```powershell
PS C:\>  $container = New-AzContainerInstanceObject -Name test-container -Image alpine -Command "echo hello" 
PS C:\>  $containerGroup = New-AzContainerGroup -ResourceGroupName test-rg -Name test-cg -Location eastus -Container $container -OsType Linux

Location Name    Type
-------- ----    ----
eastus   test-cg Microsoft.ContainerInstance/containerGroups
```

This commands creates a container group which prints out 'hello' and stops.

### Example 4: Create a container group with a container instance using image nginx in Azure Container Registry
```powershell
PS C:\>  $container = New-AzContainerInstanceObject -Name test-container -Image myacr.azurecr.io/nginx:latest
PS C:\>  $imageRegistryCredential = New-AzContainerGroupImageRegistryCredentialObject -Server "myacr.azurecr.io" -Username "username" -Password (ConvertTo-SecureString "PlainTextPassword" -AsPlainText -Force) 
PS C:\>  $containerGroup = New-AzContainerGroup -ResourceGroupName test-rg -Name test-cg -Location eastus -Container $container -ImageRegistryCredential $imageRegistryCredential

Location Name    Type
-------- ----    ----
eastus   test-cg Microsoft.ContainerInstance/containerGroups
```

This commands creates a container group with a container instance, whose image is nginx in Azure Container Registry.

### Example 5: Create a container group with a container instance using image nginx in custom container image Registry
```powershell
PS C:\>  $container = New-AzContainerInstanceObject -Name test-container -Image myserver.com/nginx:latest
PS C:\>  $imageRegistryCredential = New-AzContainerGroupImageRegistryCredentialObject -Server "myserver.com" -Username "username" -Password (ConvertTo-SecureString "PlainTextPassword" -AsPlainText -Force) 
PS C:\>  $containerGroup = New-AzContainerGroup -ResourceGroupName test-rg -Name test-cg -Location eastus -Container $container -ImageRegistryCredential $imageRegistryCredential

Location Name    Type
-------- ----    ----
eastus   test-cg Microsoft.ContainerInstance/containerGroups
```

This commands creates a container group with a container instance, whose image is a custom image from a custom container image registry.

### Example 6: Create a container group that mounts Azure File volume
```powershell
PS C:\>  $volume = New-AzContainerGroupVolumeObject -Name "myvolume" -AzureFileShareName "myshare" -AzureFileStorageAccountName "username" -AzureFileStorageAccountKey (ConvertTo-SecureString "PlainTextPassword" -AsPlainText -Force)
PS C:\>  $container = New-AzContainerInstanceObject -Name test-container -Image alpine
PS C:\>  $containerGroup = New-AzContainerGroup -ResourceGroupName test-rg -Name test-cg -Location eastus -Container $container -Volume $volume

Location Name    Type
-------- ----    ----
eastus   test-cg Microsoft.ContainerInstance/containerGroups
```

This commands creates a container group with a container instance, whose image is a custom image from a custom container image registry.

### Example 7: Create a container group with system assigned and user assigned identity
```powershell
PS C:\>  $container = New-AzContainerInstanceObject -Name test-container -Image alpine
PS C:\>  $containerGroup = New-AzContainerGroup -ResourceGroupName test-rg -Name test-cg -Location eastus -Container $container -IdentityType "SystemAssigned, UserAssigned" -IdentityUserAssignedIdentity /subscriptions/<subscriptionId>/resourceGroups/<resourceGroup>/providers/Microsoft.ManagedIdentity/userAssignedIdentities/<UserIdentityName>

Location Name    Type
-------- ----    ----
eastus   test-cg Microsoft.ContainerInstance/containerGroups
```

This commands creates a container group with system assigned and user assigned identity.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Container
The containers within the container group.
To construct, see NOTES section for CONTAINER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainer[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DnsConfigNameServer
The DNS servers for the container group.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DnsConfigOption
The DNS options for the container group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DnsConfigSearchDomain
The DNS search domains for hostname lookup in the container group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EncryptionPropertyKeyName
The encryption key name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EncryptionPropertyKeyVersion
The encryption key version.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EncryptionPropertyVaultBaseUrl
The keyvault base url.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
The type of identity used for the container group.
The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity and a set of user assigned identities.
The type 'None' will remove any identities from the container group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
The list of user identities associated with the container group.
The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageRegistryCredential
The image registry credentials by which the container group is created from.
To construct, see NOTES section for IMAGEREGISTRYCREDENTIALS properties and create a hash table.
To construct, see NOTES section for IMAGEREGISTRYCREDENTIAL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IImageRegistryCredential[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InitContainer
The init containers for a container group.
To construct, see NOTES section for INITCONTAINER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinition[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IPAddressDnsNameLabel
The Dns name label for the IP.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IPAddressIP
The IP exposed to the public internet.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IPAddressPort
The list of ports exposed on the container group.
To construct, see NOTES section for IPADDRESSPORT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IPort[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IPAddressType
Specifies if the IP is exposed to the public internet or private VNET.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The resource location.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogAnalyticLogType
The log type to be used.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogAnalyticMetadata
Metadata for log analytics.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogAnalyticWorkspaceId
The workspace id for log analytics

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogAnalyticWorkspaceKey
The workspace key for log analytics

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogAnalyticWorkspaceResourceId
The workspace resource id for log analytics

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the container group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ContainerGroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkProfileId
The identifier for a network profile.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OSType
The operating system type required by the containers in the container group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RestartPolicy
Restart policy for all containers within the container group.
- `Always` Always restart- `OnFailure` Restart on failure- `Never` Never restart

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Sku
The SKU for a container group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
The resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Volume
The list of volumes that can be mounted by containers in this container group.
To construct, see NOTES section for VOLUME properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolume[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroup

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


CONTAINER <IContainer[]>: The containers within the container group.
  - `Image <String>`: The name of the image used to create the container instance.
  - `Name <String>`: The user-provided name of the container instance.
  - `RequestCpu <Double>`: The CPU request of this container instance.
  - `RequestMemoryInGb <Double>`: The memory request in GB of this container instance.
  - `[Command <String[]>]`: The commands to execute within the container instance in exec form.
  - `[EnvironmentVariable <IEnvironmentVariable[]>]`: The environment variables to set in the container instance.
    - `Name <String>`: The name of the environment variable.
    - `[SecureValue <String>]`: The value of the secure environment variable.
    - `[Value <String>]`: The value of the environment variable.
  - `[LimitCpu <Double?>]`: The CPU limit of this container instance.
  - `[LimitMemoryInGb <Double?>]`: The memory limit in GB of this container instance.
  - `[LimitsGpuCount <Int32?>]`: The count of the GPU resource.
  - `[LimitsGpuSku <GpuSku?>]`: The SKU of the GPU resource.
  - `[LivenessProbeExecCommand <String[]>]`: The commands to execute within the container.
  - `[LivenessProbeFailureThreshold <Int32?>]`: The failure threshold.
  - `[LivenessProbeHttpGetHttpHeadersName <String>]`: The header name.
  - `[LivenessProbeHttpGetHttpHeadersValue <String>]`: The header value.
  - `[LivenessProbeHttpGetPath <String>]`: The path to probe.
  - `[LivenessProbeHttpGetPort <Int32?>]`: The port number to probe.
  - `[LivenessProbeHttpGetScheme <Scheme?>]`: The scheme.
  - `[LivenessProbeInitialDelaySecond <Int32?>]`: The initial delay seconds.
  - `[LivenessProbePeriodSecond <Int32?>]`: The period seconds.
  - `[LivenessProbeSuccessThreshold <Int32?>]`: The success threshold.
  - `[LivenessProbeTimeoutSecond <Int32?>]`: The timeout seconds.
  - `[Port <IContainerPort[]>]`: The exposed ports on the container instance.
    - `Port <Int32>`: The port number exposed within the container group.
    - `[Protocol <ContainerNetworkProtocol?>]`: The protocol associated with the port.
  - `[ReadinessProbeExecCommand <String[]>]`: The commands to execute within the container.
  - `[ReadinessProbeFailureThreshold <Int32?>]`: The failure threshold.
  - `[ReadinessProbeHttpGetHttpHeadersName <String>]`: The header name.
  - `[ReadinessProbeHttpGetHttpHeadersValue <String>]`: The header value.
  - `[ReadinessProbeHttpGetPath <String>]`: The path to probe.
  - `[ReadinessProbeHttpGetPort <Int32?>]`: The port number to probe.
  - `[ReadinessProbeHttpGetScheme <Scheme?>]`: The scheme.
  - `[ReadinessProbeInitialDelaySecond <Int32?>]`: The initial delay seconds.
  - `[ReadinessProbePeriodSecond <Int32?>]`: The period seconds.
  - `[ReadinessProbeSuccessThreshold <Int32?>]`: The success threshold.
  - `[ReadinessProbeTimeoutSecond <Int32?>]`: The timeout seconds.
  - `[RequestsGpuCount <Int32?>]`: The count of the GPU resource.
  - `[RequestsGpuSku <GpuSku?>]`: The SKU of the GPU resource.
  - `[VolumeMount <IVolumeMount[]>]`: The volume mounts available to the container instance.
    - `MountPath <String>`: The path within the container where the volume should be mounted. Must not contain colon (:).
    - `Name <String>`: The name of the volume mount.
    - `[ReadOnly <Boolean?>]`: The flag indicating whether the volume mount is read-only.

IMAGEREGISTRYCREDENTIAL <IImageRegistryCredential[]>: The image registry credentials by which the container group is created from. To construct, see NOTES section for IMAGEREGISTRYCREDENTIALS properties and create a hash table.
  - `Server <String>`: The Docker image registry server without a protocol such as "http" and "https".
  - `Username <String>`: The username for the private registry.
  - `[Password <String>]`: The password for the private registry.

INITCONTAINER <IInitContainerDefinition[]>: The init containers for a container group.
  - `Name <String>`: The name for the init container.
  - `[Command <String[]>]`: The command to execute within the init container in exec form.
  - `[EnvironmentVariable <IEnvironmentVariable[]>]`: The environment variables to set in the init container.
    - `Name <String>`: The name of the environment variable.
    - `[SecureValue <String>]`: The value of the secure environment variable.
    - `[Value <String>]`: The value of the environment variable.
  - `[Image <String>]`: The image of the init container.
  - `[VolumeMount <IVolumeMount[]>]`: The volume mounts available to the init container.
    - `MountPath <String>`: The path within the container where the volume should be mounted. Must not contain colon (:).
    - `Name <String>`: The name of the volume mount.
    - `[ReadOnly <Boolean?>]`: The flag indicating whether the volume mount is read-only.

IPADDRESSPORT <IPort[]>: The list of ports exposed on the container group.
  - `Port1 <Int32>`: The port number.
  - `[Protocol <ContainerGroupNetworkProtocol?>]`: The protocol associated with the port.

VOLUME <IVolume[]>: The list of volumes that can be mounted by containers in this container group.
  - `Name <String>`: The name of the volume.
  - `[AzureFileReadOnly <Boolean?>]`: The flag indicating whether the Azure File shared mounted as a volume is read-only.
  - `[AzureFileShareName <String>]`: The name of the Azure File share to be mounted as a volume.
  - `[AzureFileStorageAccountKey <String>]`: The storage account access key used to access the Azure File share.
  - `[AzureFileStorageAccountName <String>]`: The name of the storage account that contains the Azure File share.
  - `[EmptyDir <IAny>]`: The empty directory volume.
  - `[GitRepoDirectory <String>]`: Target directory name. Must not contain or start with '..'.  If '.' is supplied, the volume directory will be the git repository.  Otherwise, if specified, the volume will contain the git repository in the subdirectory with the given name.
  - `[GitRepoRepository <String>]`: Repository URL
  - `[GitRepoRevision <String>]`: Commit hash for the specified revision.
  - `[Secret <ISecretVolume>]`: The secret volume.
    - `[(Any) <String>]`: This indicates any property can be added to this object.

## RELATED LINKS

