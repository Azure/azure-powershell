---
external help file: Az.ContainerInstance-help.xml
Module Name: Az.ContainerInstance
online version: https://learn.microsoft.com/powershell/module/az.containerinstance/new-azcontainergroup
schema: 2.0.0
---

# New-AzContainerGroup

## SYNOPSIS
Create or update container groups with specified configurations.

## SYNTAX

```
New-AzContainerGroup -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] -Location <String>
 [-Container <IContainer[]>] [-OSType <OperatingSystemTypes>] [-ContainerGroupProfileId <String>]
 [-ContainerGroupProfileRevision <Int32>] [-DnsConfigNameServer <String[]>] [-DnsConfigOption <String>]
 [-DnsConfigSearchDomain <String>] [-EncryptionPropertyKeyName <String>]
 [-EncryptionPropertyKeyVersion <String>] [-EncryptionPropertyVaultBaseUrl <String>]
 [-IPAddressDnsNameLabel <String>] [-IPAddressIP <String>] [-IPAddressPort <IPort[]>]
 [-IPAddressType <ContainerGroupIPAddressType>] [-IdentityType <ResourceIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-ImageRegistryCredential <IImageRegistryCredential[]>]
 [-InitContainer <IInitContainerDefinition[]>] [-LogAnalyticLogType <LogAnalyticsLogType>]
 [-LogAnalyticMetadata <Hashtable>] [-LogAnalyticWorkspaceId <String>] [-LogAnalyticWorkspaceKey <String>]
 [-LogAnalyticWorkspaceResourceId <String>] [-RestartPolicy <ContainerGroupRestartPolicy>]
 [-Sku <ContainerGroupSku>] [-StandbyPoolProfileFailContainerGroupCreateOnReuseFailure]
 [-StandbyPoolProfileId <String>] [-SubnetId <IContainerGroupSubnetId[]>] [-Tag <Hashtable>]
 [-Volume <IVolume[]>] [-Zone <String[]>] [-Priority <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create or update container groups with specified configurations.

## EXAMPLES

### Example 1: Create a container group with a container instance and request a public IP address with opening ports
```powershell
$port1 = New-AzContainerInstancePortObject -Port 8000 -Protocol TCP
$port2 = New-AzContainerInstancePortObject -Port 8001 -Protocol TCP
$container = New-AzContainerInstanceObject -Name test-container -Image nginx -RequestCpu 1 -RequestMemoryInGb 1.5 -Port @($port1, $port2)
$containerGroup = New-AzContainerGroup -ResourceGroupName test-rg -Name test-cg -Location eastus -Container $container -OsType Linux -RestartPolicy "Never" -IpAddressType Public
```

```output
Location Name    Zone ResourceGroupName
-------- ----    ---- -----------------
eastus   test-cg      test-rg
```

This commands creates a container group with a container instance, whose image is latest nginx, and requests a public IP address with opening port 8000 and 8001.

### Example 2: Create container group and runs a custom script inside the container.
```powershell
$pwd = ConvertTo-SecureString -String "****" -AsPlainText -Force
$env1 = New-AzContainerInstanceEnvironmentVariableObject -Name "env1" -Value "value1"
$env2 = New-AzContainerInstanceEnvironmentVariableObject -Name "env2" -SecureValue $pwd
$container = New-AzContainerInstanceObject -Name test-container -Image alpine -Command "/bin/sh -c myscript.sh" -EnvironmentVariable @($env1, $env2)
$containerGroup = New-AzContainerGroup -ResourceGroupName test-rg -Name test-cg -Location eastus -Container $container -OsType Linux
```

```output
Location Name    Zone ResourceGroupName
-------- ----    ---- -----------------
eastus   test-cg      test-rg
```

This commands creates a container group and runs a custom script inside the container.

### Example 3: Create a run-to-completion container group
```powershell
$container = New-AzContainerInstanceObject -Name test-container -Image alpine -Command "echo hello" 
$containerGroup = New-AzContainerGroup -ResourceGroupName test-rg -Name test-cg -Location eastus -Container $container -OsType Linux
```

```output
Location Name    Zone ResourceGroupName
-------- ----    ---- -----------------
eastus   test-cg      test-rg
```

This commands creates a container group which prints out 'hello' and stops.

### Example 4: Create a container group with a container instance using image nginx in Azure Container Registry
```powershell
$pwd = ConvertTo-SecureString -String "****" -AsPlainText -Force
$container = New-AzContainerInstanceObject -Name test-container -Image myacr.azurecr.io/nginx:latest
$imageRegistryCredential = New-AzContainerGroupImageRegistryCredentialObject -Server "myacr.azurecr.io" -Username "username" -Password $pwd
$containerGroup = New-AzContainerGroup -ResourceGroupName test-rg -Name test-cg -Location eastus -Container $container -ImageRegistryCredential $imageRegistryCredential
```

```output
Location Name    Zone ResourceGroupName
-------- ----    ---- -----------------
eastus   test-cg      test-rg
```

This commands creates a container group with a container instance, whose image is nginx in Azure Container Registry.

### Example 5: Create a container group with a container instance using image nginx in custom container image Registry
```powershell
$pwd = ConvertTo-SecureString -String "****" -AsPlainText -Force
$container = New-AzContainerInstanceObject -Name test-container -Image myserver.com/nginx:latest
$imageRegistryCredential = New-AzContainerGroupImageRegistryCredentialObject -Server "myserver.com" -Username "username" -Password $pwd
$containerGroup = New-AzContainerGroup -ResourceGroupName test-rg -Name test-cg -Location eastus -Container $container -ImageRegistryCredential $imageRegistryCredential
```

```output
Location Name    Zone ResourceGroupName
-------- ----    ---- -----------------
eastus   test-cg      test-rg
```

This commands creates a container group with a container instance, whose image is a custom image from a custom container image registry.

### Example 6: Create a container group that mounts Azure File volume
```powershell
$pwd = ConvertTo-SecureString -String "****" -AsPlainText -Force
$volume = New-AzContainerGroupVolumeObject -Name "myvolume" -AzureFileShareName "myshare" -AzureFileStorageAccountName "username" -AzureFileStorageAccountKey $pwd
$mount = New-AzContainerInstanceVolumeMountObject -MountPath "/aci/logs" -Name "myvolume"
$container = New-AzContainerInstanceObject -Name test-container -Image alpine -VolumeMount $mount
$containerGroup = New-AzContainerGroup -ResourceGroupName test-rg -Name test-cg -Location eastus -Container $container -Volume $volume
```

```output
Location Name    Zone ResourceGroupName
-------- ----    ---- -----------------
eastus   test-cg      test-rg
```

This commands creates a container group with a container instance, whose image is a custom image from a custom container image registry.

### Example 7: Create a container group with system assigned and user assigned identity
```powershell
$container = New-AzContainerInstanceObject -Name test-container -Image alpine
$containerGroup = New-AzContainerGroup -ResourceGroupName test-rg -Name test-cg -Location eastus -Container $container -IdentityType "SystemAssigned, UserAssigned" -IdentityUserAssignedIdentity @{"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}" = @{}}
```

```output
Location Name    Zone ResourceGroupName
-------- ----    ---- -----------------
eastus   test-cg      test-rg
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.IContainer[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContainerGroupProfileId
The container group profile reference id.This will be an ARM resource id in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroupProfiles/{containerGroupProfileName}'.

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

### -ContainerGroupProfileRevision
The container group profile reference revision.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ResourceIdentityType
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
Type: System.Collections.Hashtable
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
To construct, see NOTES section for IMAGEREGISTRYCREDENTIAL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.IImageRegistryCredential[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.IInitContainerDefinition[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.IPort[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupIPAddressType
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.LogAnalyticsLogType
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
Type: System.String
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.OperatingSystemTypes
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Priority
The priority of the Container Group.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupRestartPolicy
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupSku
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StandbyPoolProfileFailContainerGroupCreateOnReuseFailure
The flag to determine whether ACI should fail the create request if the container group can not be obtained from standby pool.

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

### -StandbyPoolProfileId
The standby pool profile reference id.This will be an ARM resource id in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.StandbyPool/standbyContainerGroupPools/{standbyPoolName}'.

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

### -SubnetId
The subnet resource IDs for a container group.
To construct, see NOTES section for SUBNETID properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.IContainerGroupSubnetId[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.IVolume[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Zone
The zones for the container group.

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

### Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.IContainerGroup

## NOTES

## RELATED LINKS
