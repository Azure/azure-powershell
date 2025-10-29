---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Backup.dll-Help.xml
Module Name: Az.RecoveryServices
online version: https://learn.microsoft.com/powershell/module/az.recoveryservices/get-azrecoveryservicessoftdeletedvaultbackupitem
schema: 2.0.0
---

# Get-AzRecoveryServicesSoftDeletedVaultBackupItem

## SYNOPSIS
Gets backup items from soft-deleted Recovery Services vaults.

## SYNTAX

```
Get-AzRecoveryServicesSoftDeletedVaultBackupItem [[-VaultName] <String>] [[-ResourceGroupName] <String>]
 [[-VaultId] <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzRecoveryServicesSoftDeletedVaultBackupItem cmdlet retrieves backup items from soft-deleted Recovery Services vaults using Azure Resource Graph. This allows you to view what backup items were contained in a vault before it was deleted. You can specify the vault by either VaultId or by VaultName and ResourceGroupName.

## EXAMPLES

### Example 1: Get backup items using VaultId
```powershell
$sdVault = Get-AzRecoveryServicesSoftDeletedVault -Location westus | Where-Object { $_.Properties.VaultId -match "wus-vault" }
Get-AzRecoveryServicesSoftDeletedVaultBackupItem -VaultId $sdVault.ID
```

Gets backup items from a soft-deleted vault using the vault's ARM ID.

### Example 2: Get backup items using VaultName and ResourceGroupName
```powershell
$sdVault = Get-AzRecoveryServicesSoftDeletedVault -Location westus -Name "wus-rg_fe7567gh-9d2b-4376-aa4a-de1c7176e40e"
Get-AzRecoveryServicesSoftDeletedVaultBackupItem -VaultName $sdVault.Name -ResourceGroupName $sdVault.ResourceGroupName
```

Gets backup items from a soft-deleted vault using the vault name and resource group name.

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

### -ResourceGroupName
Resource group name of the soft deleted recovery services vault

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultId
ARM ID of the soft deleted Recovery Services Vault

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultName
Name of the soft deleted recovery services vault

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### System.Management.Automation.PSObject

## NOTES

## RELATED LINKS
