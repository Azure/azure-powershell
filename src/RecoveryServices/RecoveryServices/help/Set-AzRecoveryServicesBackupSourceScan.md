---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Backup.dll-Help.xml
Module Name: Az.RecoveryServices
online version: https://learn.microsoft.com/powershell/module/az.recoveryservices/set-azrecoveryservicesbackupsourcescan
schema: 2.0.0
---

# Set-AzRecoveryServicesBackupSourceScan

## SYNOPSIS
Configures Source Scan (Microsoft Defender for Cloud) for a Backup-protected item.

## SYNTAX

```
Set-AzRecoveryServicesBackupSourceScan [-Item] <ItemBase> [-State] <String> [-Force] [-VaultId <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzRecoveryServicesBackupSourceScan** cmdlet enables or disables Source Scan (Microsoft Defender for Cloud) for an Azure VM (Virtual Machine) Backup-protected item. Source Scan lets Microsoft Defender for Cloud scan the item's recovery points for malware and other threats. This cmdlet supports both enabling and disabling Source Scan, and preserves all other properties of the protected item.

Currently, only Azure VM backup items are supported. Set the vault context by using the Set-AzRecoveryServicesVaultContext cmdlet, or pass the -VaultId parameter, before you use the current cmdlet.

## EXAMPLES

### Example 1: Enable Source Scan for an Azure VM backup item
```powershell
$Cont = Get-AzRecoveryServicesBackupContainer -ContainerType AzureVM -VaultId $vault.ID
$PI = Get-AzRecoveryServicesBackupItem -Container $Cont[0] -WorkloadType AzureVM -VaultId $vault.ID
Set-AzRecoveryServicesBackupSourceScan -Item $PI[0] -State Enabled -VaultId $vault.ID
```

The first command gets an array of backup containers, and then stores it in the $Cont array.
The second command gets the Backup item corresponding to the first container item, and then stores it in the $PI variable.
The last command enables Source Scan for the item in $PI\[0\], and returns the tracking job.

### Example 2: Disable Source Scan for an Azure VM backup item without confirmation
```powershell
$item = Get-AzRecoveryServicesBackupItem -VaultId $vault.ID -BackupManagementType AzureVM -WorkloadType AzureVM
Set-AzRecoveryServicesBackupSourceScan -Item $item[0] -State Disabled -VaultId $vault.ID -Force
```

The first cmdlet fetches the AzureVM backup items for the recovery services vault.
The second cmdlet disables Source Scan for $item[0] without prompting for confirmation.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Forces the command to run without asking for user confirmation.

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

### -Item
Specifies the backup item for which Source Scan (Microsoft Defender for Cloud) is to be configured.
To obtain an item, use the Get-AzRecoveryServicesBackupItem cmdlet.

```yaml
Type: Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.ItemBase
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -State
Specifies the Source Scan state to set for the item. Allowed values are "Enabled", "Disabled".

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Enabled, Disabled

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultId
ARM ID of the Recovery Services Vault.

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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: False
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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.ItemBase

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.JobBase

## NOTES

## RELATED LINKS

[Get-AzRecoveryServicesBackupItem](./Get-AzRecoveryServicesBackupItem.md)

[Update-AzRecoveryServicesVault](./Update-AzRecoveryServicesVault.md)
