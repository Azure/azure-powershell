---
external help file: Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.dll-Help.xml
online version: 
schema: 2.0.0
---

# Set-AzureRmRecoveryServicesAsrVaultSettings

## SYNOPSIS
Sets the Recovery Services vault context to be used for subsequent Azure Site Recovery operations in the current PowerShell session.

## SYNTAX

```
Set-AzureRmRecoveryServicesAsrVaultSettings -Vault <ARSVault> [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmRecoveryServicesAsrVaultSettings** cmdlet sets the Azure Site Recovery vault context for further operations.

## EXAMPLES

### Example 1
```
PS C:\> $vaultSettings = Set-AzureRmRecoveryServicesAsrVaultSettings -Vault $RecoveryServicesVault
```

Sets the vault context to the specified Recovery Services vault for subsequent Azure Site Recovery operations in the current PowerShell session.

## PARAMETERS

### -Vault
The Recovery Services vault object corresponding to the Recovery Services vault.

```yaml
Type: ARSVault
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.RecoveryServices.ARSVault

## OUTPUTS

### Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRVaultSettings

## NOTES

## RELATED LINKS

[Get-AzureRmRecoveryServicesAsrVaultSettings](./Get-AzureRmRecoveryServicesAsrVaultSettings.md)
