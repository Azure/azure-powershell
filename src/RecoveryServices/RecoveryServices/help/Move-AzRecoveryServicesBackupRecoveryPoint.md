---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Backup.dll-Help.xml
Module Name: Az.RecoveryServices
online version: https://docs.microsoft.com/powershell/module/az.recoveryservices/move-azrecoveryservicesbackuprecoverypoint
schema: 2.0.0
---

# Move-AzRecoveryServicesBackupRecoveryPoint

## SYNOPSIS
Moves the recovery point from source tier to destination tier.

## SYNTAX

```
Move-AzRecoveryServicesBackupRecoveryPoint [-RecoveryPoint] <RecoveryPointBase>
 [-SourceTier] <RecoveryPointTier> [-DestinationTier] <RecoveryPointTier> [-VaultId <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Move-AzRecoveryServicesBackupRecoveryPoint** cmdlet moves the recovery point from source tier to destination tier. 
Currently only valid Source tier is VaultStandard, only valid destination tier is VaultArchive.

## EXAMPLES

### Example 1: Move recovery point from VaultStandard tier to VaultArchive tier

```powershell
$vault = Get-AzRecoveryServicesVault -ResourceGroupName "resourceGroup" -Name "vaultName"
$item = Get-AzRecoveryServicesBackupItem -BackupManagementType "AzureVM" -WorkloadType "AzureVM" -VaultId $vault.ID
$startDate = (Get-Date).AddDays(-7)
$endDate = Get-Date
$rp = Get-AzRecoveryServicesBackupRecoveryPoint -Item $item[3] -StartDate $startDate.ToUniversalTime() -EndDate $endDate.ToUniversalTime() -VaultId $vault.ID -Tier VaultStandard
Move-AzRecoveryServicesBackupRecoveryPoint -RecoveryPoint $rp[2] -SourceTier VaultStandard -DestinationTier VaultArchive -VaultId $vault.ID
```

First we get the recovery services vault, backup items list. Then, we fetch the recovery points for a particular backup item ($item[3] in this case) which are in
VaultStandard tier. Then we trigger move for one of the recovery points from the rp list to VaultArchive tier.  

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -DestinationTier
Destination Tier for Recovery Point move.
Currently the only acceptable value is 'VaultArchive'

```yaml
Type: Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.RecoveryPointTier
Parameter Sets: (All)
Aliases:
Accepted values: VaultArchive

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecoveryPoint
Recovery Point to move to archive

```yaml
Type: Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.RecoveryPointBase
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SourceTier
Source Tier for Recovery Point move.
Currently the only acceptable value is 'VaultStandard'

```yaml
Type: Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.RecoveryPointTier
Parameter Sets: (All)
Aliases:
Accepted values: VaultStandard

Required: True
Position: 1
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
Accept pipeline input: True (ByValue)
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.RecoveryPointBase

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.RecoveryPointBase

## NOTES

## RELATED LINKS
