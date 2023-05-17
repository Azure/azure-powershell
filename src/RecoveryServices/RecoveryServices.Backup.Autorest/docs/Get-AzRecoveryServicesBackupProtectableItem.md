---
external help file:
Module Name: Az.RecoveryServices
online version: https://learn.microsoft.com/powershell/module/az.recoveryservices/get-azrecoveryservicesbackupprotectableitem
schema: 2.0.0
---

# Get-AzRecoveryServicesBackupProtectableItem

## SYNOPSIS
This command will retrieve all protectable items within a certain container or across all registered containers.
It will consist of all the elements of the hierarchy of the application.
Returns DBs and their upper tier entities like Instance, AvailabilityGroup etc.

## SYNTAX

### FilterParamSet (Default)
```
Get-AzRecoveryServicesBackupProtectableItem -DatasourceType <DatasourceTypes> -ResourceGroupName <String>
 -VaultName <String> [-Container <IProtectionContainerResource>] [-DefaultProfile <PSObject>]
 [-ItemType <String>] [-Name <String>] [-ServerName <String>] [-SubscriptionId <String[]>]
 [<CommonParameters>]
```

### IdParamSet
```
Get-AzRecoveryServicesBackupProtectableItem -ParentID <String> -ResourceGroupName <String> -VaultName <String>
 [-DefaultProfile <PSObject>] [-ItemType <String>] [-Name <String>] [-ServerName <String>]
 [-SubscriptionId <String[]>] [<CommonParameters>]
```

## DESCRIPTION
This command will retrieve all protectable items within a certain container or across all registered containers.
It will consist of all the elements of the hierarchy of the application.
Returns DBs and their upper tier entities like Instance, AvailabilityGroup etc.

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
Specifies a container object for which this cmdlet gets protectable items.
To obtain an ProtectionContainerResource, use the Get-AzRecoveryServicesBackupContainer cmdlet
To construct, see NOTES section for CONTAINER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionContainerResource
Parameter Sets: FilterParamSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatasourceType
Specifies the DatasourceType

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.DatasourceTypes
Parameter Sets: FilterParamSet
Aliases:

Required: True
Position: Named
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

### -ItemType
Specifies the type of protectable item.
Acceptable values: SQLDataBase, SQLInstance, SQLAvailabilityGroup

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
Specifies the name of the Database, Instance or AvailabilityGroup

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

### -ParentID
Specifies the ARM ID of an Instance or Availability Group

```yaml
Type: System.String
Parameter Sets: IdParamSet
Aliases:

Required: True
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

### -ServerName
Specifies the name of the server to which the item belongs

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
Subscription Id

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IWorkloadProtectableItemResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`CONTAINER <IProtectionContainerResource>`: Specifies a container object for which this cmdlet gets protectable items. To obtain an ProtectionContainerResource, use the Get-AzRecoveryServicesBackupContainer cmdlet
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

