---
external help file:
Module Name: Az.RecoveryServices
online version: https://learn.microsoft.com/powershell/module/az.recoveryservices/enable-azrecoveryservicesbackupprotection
schema: 2.0.0
---

# Enable-AzRecoveryServicesBackupProtection

## SYNOPSIS
Triggers the enable protection operation for the given item

## SYNTAX

### ModifyProtection (Default)
```
Enable-AzRecoveryServicesBackupProtection [-Policy] <IProtectionPolicyResource>
 [-Item] <IProtectedItemResource> -ResourceGroupName <String> -VaultName <String> [-DefaultProfile <PSObject>]
 [-ExcludeAllDataDisks] [-ExclusionDisksList <String[]>] [-InclusionDisksList <String[]>]
 [-ResetExclusionSettings] [-SubscriptionId <String>] [-Token <String>] [<CommonParameters>]
```

### AzureFileShareEnableProtection
```
Enable-AzRecoveryServicesBackupProtection [-Policy] <IProtectionPolicyResource> [-Name] <String>
 [-StorageAccountName] <String> -ResourceGroupName <String> -VaultName <String> [-DefaultProfile <PSObject>]
 [-SubscriptionId <String>] [<CommonParameters>]
```

### AzureVMClassicComputeEnableProtection
```
Enable-AzRecoveryServicesBackupProtection [-Policy] <IProtectionPolicyResource> [-Name] <String>
 [-ServiceName] <String> -ResourceGroupName <String> -VaultName <String> [-DefaultProfile <PSObject>]
 [-ExcludeAllDataDisks] [-ExclusionDisksList <String[]>] [-InclusionDisksList <String[]>]
 [-SubscriptionId <String>] [<CommonParameters>]
```

### AzureVMComputeEnableProtection
```
Enable-AzRecoveryServicesBackupProtection [-Policy] <IProtectionPolicyResource> [-Name] <String>
 [-VMResourceGroupName] <String> -ResourceGroupName <String> -VaultName <String> [-DefaultProfile <PSObject>]
 [-ExcludeAllDataDisks] [-ExclusionDisksList <String[]>] [-InclusionDisksList <String[]>]
 [-SubscriptionId <String>] [<CommonParameters>]
```

### AzureWorkloadEnableProtection
```
Enable-AzRecoveryServicesBackupProtection [-Policy] <IProtectionPolicyResource>
 [-ProtectableItem] <IWorkloadProtectableItemResource> -ResourceGroupName <String> -VaultName <String>
 [-DefaultProfile <PSObject>] [-SubscriptionId <String>] [<CommonParameters>]
```

## DESCRIPTION
Triggers the enable protection operation for the given item

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

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

### -ExcludeAllDataDisks
Option to specify to backup OS disks only

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AzureVMClassicComputeEnableProtection, AzureVMComputeEnableProtection, ModifyProtection
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExclusionDisksList
List of Disk LUNs to be excluded in backup and the rest are automatically included.

```yaml
Type: System.String[]
Parameter Sets: AzureVMClassicComputeEnableProtection, AzureVMComputeEnableProtection, ModifyProtection
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InclusionDisksList
List of Disk LUNs to be included in backup and the rest are automatically excluded except OS disk.

```yaml
Type: System.String[]
Parameter Sets: AzureVMClassicComputeEnableProtection, AzureVMComputeEnableProtection, ModifyProtection
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Item
Specifies the item to be protected with the given policy.
To obtain a BackupItem , use the Get-AzRecoveryServicesBackupItem cmdlet.
To construct, see NOTES section for ITEM properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectedItemResource
Parameter Sets: ModifyProtection
Aliases:

Required: True
Position: 4
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Specifies the name of backup item.
For file share, specify the unique ID of protected file share.

```yaml
Type: System.String
Parameter Sets: AzureFileShareEnableProtection, AzureVMClassicComputeEnableProtection, AzureVMComputeEnableProtection
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Policy
Specifies protection policy that this cmdlet associates with an item.
To obtain policy use Get-AzRecoveryServicesBackupProtectionPolicy cmdlet
To construct, see NOTES section for POLICY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionPolicyResource
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProtectableItem
Specifies the protectable item to be protected with the given policy.
To construct, see NOTES section for PROTECTABLEITEM properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IWorkloadProtectableItemResource
Parameter Sets: AzureWorkloadEnableProtection
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResetExclusionSettings
Specifies to reset disk exclusion setting associated with the item

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ModifyProtection
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

### -ServiceName
Cloud Service Name for Azure Classic Compute VM.

```yaml
Type: System.String
Parameter Sets: AzureVMClassicComputeEnableProtection
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -StorageAccountName
Azure file share storage account name

```yaml
Type: System.String
Parameter Sets: AzureFileShareEnableProtection
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -Token
Auxiliary access token for authenticating critical operation to resource guard subscription

```yaml
Type: System.String
Parameter Sets: ModifyProtection
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

### -VMResourceGroupName
Resource Group Name for Azure Compute VM.

```yaml
Type: System.String
Parameter Sets: AzureVMComputeEnableProtection
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectedItemResource

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IWorkloadProtectableItemResource

### System.String

## OUTPUTS

### System.Management.Automation.PSObject

## NOTES

## RELATED LINKS

