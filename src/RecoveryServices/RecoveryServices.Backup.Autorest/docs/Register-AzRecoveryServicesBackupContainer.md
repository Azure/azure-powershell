---
external help file:
Module Name: Az.RecoveryServices
online version: https://learn.microsoft.com/powershell/module/az.recoveryservices/register-azrecoveryservicesbackupcontainer
schema: 2.0.0
---

# Register-AzRecoveryServicesBackupContainer

## SYNOPSIS
The Register-AzRecoveryServicesBackupContainer cmdlet registers an Azure VM for AzureWorkloads with specific DatasourceType.

## SYNTAX

### Register (Default)
```
Register-AzRecoveryServicesBackupContainer [-ResourceId] <String> [-DatasourceType] <DatasourceTypes>
 -ResourceGroupName <String> -VaultName <String> [-DefaultProfile <PSObject>] [-SubscriptionId <String>]
 [<CommonParameters>]
```

### ReRegister
```
Register-AzRecoveryServicesBackupContainer [-Container] <IProtectionContainerResource>
 [-DatasourceType] <DatasourceTypes> -ResourceGroupName <String> -VaultName <String>
 [-DefaultProfile <PSObject>] [-SubscriptionId <String>] [<CommonParameters>]
```

## DESCRIPTION
The Register-AzRecoveryServicesBackupContainer cmdlet registers an Azure VM for AzureWorkloads with specific DatasourceType.

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

### -Container
Specifies a container object for which this cmdlet triggers the re-registration.
To obtain an ProtectionContainerResource, use the Get-AzRecoveryServicesBackupContainer cmdlet
To construct, see NOTES section for CONTAINER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionContainerResource
Parameter Sets: ReRegister
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DatasourceType
Specifies the DatasourceType

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.DatasourceTypes
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile


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

### -ResourceGroupName
The name of the resource group where the recovery services vault is present

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

### -ResourceId
Specifies the ARM ID of an Instance or Availability Group

```yaml
Type: System.String
Parameter Sets: Register
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription Id

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

### -VaultName
The name of the recovery services vault

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionContainerResource

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionContainerResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`CONTAINER <IProtectionContainerResource>`: Specifies a container object for which this cmdlet triggers the re-registration. To obtain an ProtectionContainerResource, use the Get-AzRecoveryServicesBackupContainer cmdlet
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

