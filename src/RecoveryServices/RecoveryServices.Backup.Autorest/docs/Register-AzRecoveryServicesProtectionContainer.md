---
external help file:
Module Name: Az.RecoveryServices
online version: https://docs.microsoft.com/powershell/module/az.recoveryservices/register-azrecoveryservicesprotectioncontainer
schema: 2.0.0
---

# Register-AzRecoveryServicesProtectionContainer

## SYNOPSIS
Registers the container with Recovery Services vault.\r\nThis is an asynchronous operation.
To track the operation status, use location header to call get latest status of\r\nthe operation.

## SYNTAX

### RegisterExpanded (Default)
```
Register-AzRecoveryServicesProtectionContainer -ContainerName <String> -FabricName <String>
 -ResourceGroupName <String> -VaultName <String> [-SubscriptionId <String>]
 [-BackupManagementType <BackupManagementType>] [-ContainerType <ProtectableContainerType>] [-ETag <String>]
 [-FriendlyName <String>] [-HealthStatus <String>] [-Location <String>] [-ProtectableObjectType <String>]
 [-RegistrationStatus <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Register
```
Register-AzRecoveryServicesProtectionContainer -ContainerName <String> -FabricName <String>
 -ResourceGroupName <String> -VaultName <String> -Parameter <IProtectionContainerResource>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RegisterViaIdentity
```
Register-AzRecoveryServicesProtectionContainer -InputObject <IRecoveryServicesIdentity>
 -Parameter <IProtectionContainerResource> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RegisterViaIdentityExpanded
```
Register-AzRecoveryServicesProtectionContainer -InputObject <IRecoveryServicesIdentity>
 [-BackupManagementType <BackupManagementType>] [-ContainerType <ProtectableContainerType>] [-ETag <String>]
 [-FriendlyName <String>] [-HealthStatus <String>] [-Location <String>] [-ProtectableObjectType <String>]
 [-RegistrationStatus <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Registers the container with Recovery Services vault.\r\nThis is an asynchronous operation.
To track the operation status, use location header to call get latest status of\r\nthe operation.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -BackupManagementType
Type of backup management for the container.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.BackupManagementType
Parameter Sets: RegisterExpanded, RegisterViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContainerName
Name of the container to be registered.

```yaml
Type: System.String
Parameter Sets: Register, RegisterExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContainerType
Type of the container.
The value of this property for: 1.
Compute Azure VM is Microsoft.Compute/virtualMachines 2.Classic Compute Azure VM is Microsoft.ClassicCompute/virtualMachines 3.
Windows machines (like MAB, DPM etc) isWindows 4.
Azure SQL instance is AzureSqlContainer.
5.
Storage containers is StorageContainer.
6.
Azure workloadBackup is VMAppContainer

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.ProtectableContainerType
Parameter Sets: RegisterExpanded, RegisterViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -ETag
Optional ETag.

```yaml
Type: System.String
Parameter Sets: RegisterExpanded, RegisterViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FabricName
Fabric name associated with the container.

```yaml
Type: System.String
Parameter Sets: Register, RegisterExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FriendlyName
Friendly name of the container.

```yaml
Type: System.String
Parameter Sets: RegisterExpanded, RegisterViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HealthStatus
Status of health of the container.

```yaml
Type: System.String
Parameter Sets: RegisterExpanded, RegisterViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.IRecoveryServicesIdentity
Parameter Sets: RegisterViaIdentity, RegisterViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
Resource location.

```yaml
Type: System.String
Parameter Sets: RegisterExpanded, RegisterViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Base class for container with backup items.
Containers with specific workloads are derived from this class.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionContainerResource
Parameter Sets: Register, RegisterViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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

### -ProtectableObjectType
Type of the protectable object associated with this container

```yaml
Type: System.String
Parameter Sets: RegisterExpanded, RegisterViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegistrationStatus
Status of registration of the container with the Recovery Services Vault.

```yaml
Type: System.String
Parameter Sets: RegisterExpanded, RegisterViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group where the recovery services vault is present.

```yaml
Type: System.String
Parameter Sets: Register, RegisterExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription Id.

```yaml
Type: System.String
Parameter Sets: Register, RegisterExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: RegisterExpanded, RegisterViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultName
The name of the recovery services vault.

```yaml
Type: System.String
Parameter Sets: Register, RegisterExpanded
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionContainerResource

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.IRecoveryServicesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionContainerResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IRecoveryServicesIdentity>`: Identity Parameter
  - `[AzureRegion <String>]`: Azure region to hit Api
  - `[BackupEngineName <String>]`: Name of the backup management server.
  - `[ContainerName <String>]`: 
  - `[FabricName <String>]`: Fabric name associated with the backed up item.
  - `[Id <String>]`: Resource identity path
  - `[IntentObjectName <String>]`: Backed up item name whose details are to be fetched.
  - `[JobName <String>]`: Name of the job whose details are to be fetched.
  - `[OperationId <String>]`: Operation id
  - `[PolicyName <String>]`: Backup policy information to be fetched.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection.
  - `[ProtectedItemName <String>]`: 
  - `[RecoveryPointId <String>]`: 
  - `[ResourceGroupName <String>]`: The name of the resource group where the recovery services vault is present.
  - `[ResourceGuardProxyName <String>]`: 
  - `[SubscriptionId <String>]`: The subscription Id.
  - `[VaultName <String>]`: The name of the recovery services vault.

`PARAMETER <IProtectionContainerResource>`: Base class for container with backup items. Containers with specific workloads are derived from this class.
  - `[ETag <String>]`: Optional ETag.
  - `[Location <String>]`: Resource location.
  - `[Tag <IResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[BackupManagementType <BackupManagementType?>]`: Type of backup management for the container.
  - `[ContainerType <ProtectableContainerType?>]`: Type of the container. The value of this property for: 1. Compute Azure VM is Microsoft.Compute/virtualMachines 2.         Classic Compute Azure VM is Microsoft.ClassicCompute/virtualMachines 3. Windows machines (like MAB, DPM etc) is         Windows 4. Azure SQL instance is AzureSqlContainer. 5. Storage containers is StorageContainer. 6. Azure workload         Backup is VMAppContainer
  - `[FriendlyName <String>]`: Friendly name of the container.
  - `[HealthStatus <String>]`: Status of health of the container.
  - `[ProtectableObjectType <String>]`: Type of the protectable object associated with this container
  - `[RegistrationStatus <String>]`: Status of registration of the container with the Recovery Services Vault.

## RELATED LINKS

