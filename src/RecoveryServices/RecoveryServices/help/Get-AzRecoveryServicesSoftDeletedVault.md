---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.dll-Help.xml
Module Name: Az.RecoveryServices
online version: https://learn.microsoft.com/powershell/module/az.recoveryservices/get-azrecoveryservicessoftdeletedvault
schema: 2.0.0
---

# Get-AzRecoveryServicesSoftDeletedVault

## SYNOPSIS
Gets soft-deleted Recovery Services vaults in a specified location.

## SYNTAX

```
Get-AzRecoveryServicesSoftDeletedVault [[-ResourceGroupName] <String>] [[-Name] <String>] [-Location] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzRecoveryServicesSoftDeletedVault cmdlet retrieves Recovery Services vaults that have been soft-deleted in a specified Azure location. Soft-deleted vaults are vaults that have been deleted but are still recoverable for a certain retention period. You can optionally filter by resource group name and vault name.

## EXAMPLES

### Example 1: Get all soft-deleted vaults in a location
```powershell
Get-AzRecoveryServicesSoftDeletedVault -Location "westus"
```

Gets all soft-deleted Recovery Services vaults in the West US location within the subscription context.

### Example 2: Get a specific soft-deleted vault by name
```powershell
Get-AzRecoveryServicesSoftDeletedVault -Location "westus" -Name "wus-rg_fe7567gh-9d2b-4376-aa4a-de1c7176e40e" -ResourceGroupName "wus-rg"
```

Gets a specific soft-deleted Recovery Services vault named "wus-rg_fe7567gh-9d2b-4376-aa4a-de1c7176e40e" in the "wus-rg" resource group.

### Example 3: Filter soft-deleted vaults by original vault name
```powershell
$sdVault = Get-AzRecoveryServicesSoftDeletedVault -Location westus | Where-Object { $_.Properties.VaultId -match "wus-vault" }
```

Gets soft-deleted vaults in West US and filters them to find vaults with "wus-vault" in ARM ID of the original Recovery Services vault.

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

### -Location
The Azure location where the soft-deleted vaults are located. This parameter is required to specify which Azure region to search for soft-deleted Recovery Services vaults.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the specific soft-deleted Recovery Services vault to retrieve. When specified, only the vault with this exact name will be returned. If not specified, all soft-deleted vaults in the location will be returned.

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

### -ResourceGroupName
The name of the resource group that contained the soft-deleted Recovery Services vault. When specified along with the Name parameter, it helps to uniquely identify a specific soft-deleted vault.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.RecoveryServices.ARSSoftDeletedVault

## NOTES

## RELATED LINKS
