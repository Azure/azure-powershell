---
external help file:
Module Name: Az.RecoveryServices
online version: https://learn.microsoft.com/powershell/module/az.recoveryservices/get-azrecoveryservicesbackupitem
schema: 2.0.0
---

# Get-AzRecoveryServicesBackupItem

## SYNOPSIS
Gets list of backup items protected with a recovery services vault

## SYNTAX

### GetItemsForVault (Default)
```
Get-AzRecoveryServicesBackupItem -DatasourceType <DatasourceTypes> -ResourceGroupName <String>
 -VaultName <String> [-DefaultProfile <PSObject>] [-DeleteState <String>] [-FriendlyName <String>]
 [-Name <String>] [-ProtectionState <String>] [-ProtectionStatus <String>] [-SubscriptionId <String[]>]
 [<CommonParameters>]
```

### GetItemsForContainer
```
Get-AzRecoveryServicesBackupItem -Container <IProtectionContainerResource> -DatasourceType <DatasourceTypes>
 -ResourceGroupName <String> -VaultName <String> [-DefaultProfile <PSObject>] [-DeleteState <String>]
 [-FriendlyName <String>] [-Name <String>] [-ProtectionState <String>] [-ProtectionStatus <String>]
 [-SubscriptionId <String[]>] [<CommonParameters>]
```

### GetItemsForpolicy
```
Get-AzRecoveryServicesBackupItem -Policy <IProtectionPolicyResource> -ResourceGroupName <String>
 -VaultName <String> [-DefaultProfile <PSObject>] [-DeleteState <String>] [-FriendlyName <String>]
 [-Name <String>] [-ProtectionState <String>] [-ProtectionStatus <String>] [-SubscriptionId <String[]>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets list of backup items protected with a recovery services vault

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
Specifies a container object from which this cmdlet gets backup items.
To obtain an ProtectionContainerResource, use the Get-AzRecoveryServicesBackupContainer cmdlet.
To construct, see NOTES section for CONTAINER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionContainerResource
Parameter Sets: GetItemsForContainer
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatasourceType
Specifies the DatasourceType

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.DatasourceTypes
Parameter Sets: GetItemsForContainer, GetItemsForVault
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

### -DeleteState
Specifies the delete state of the item The acceptable values for this parameter are: 
 ToBeDeleted 
 NotDeleted

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

### -FriendlyName
FriendlyName of the backed up item

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
Specifies the name of backup item.
For file share, specify the unique ID of protected file share.

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

### -Policy
Protection policy object
To construct, see NOTES section for POLICY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionPolicyResource
Parameter Sets: GetItemsForpolicy
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProtectionState
Specifies the state of protection.
The acceptable values for this parameter are: 
 IRPending.
Initial synchronization has not started and there is no recovery point yet.

 Protected.
Protection is ongoing.

 ProtectionError.
There is a protection error.

 ProtectionStopped.
Protection is disabled.

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

### -ProtectionStatus
Specifies the overall protection status of an item in the container.
The acceptable values for this parameter are: Healthy, Unhealthy

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
The name of the resource group where the recovery services vault is present.

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
The name of the recovery services vault.

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

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectedItemResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`CONTAINER <IProtectionContainerResource>`: Specifies a container object from which this cmdlet gets backup items. To obtain an ProtectionContainerResource, use the Get-AzRecoveryServicesBackupContainer cmdlet.
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

`POLICY <IProtectionPolicyResource>`: Protection policy object
  - `[ETag <String>]`: Optional ETag.
  - `[Location <String>]`: Resource location.
  - `[Tag <IResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[BackupManagementType <String>]`: This property will be used as the discriminator for deciding the specific types in the polymorphic chain of types.
  - `[ProtectedItemsCount <Int32?>]`: Number of items associated with this policy.
  - `[ResourceGuardOperationRequest <String[]>]`: ResourceGuard Operation Requests

## RELATED LINKS

