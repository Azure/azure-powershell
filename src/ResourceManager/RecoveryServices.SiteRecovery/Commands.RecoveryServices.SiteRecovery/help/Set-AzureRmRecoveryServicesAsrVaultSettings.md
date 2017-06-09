---
external help file: Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.dll-Help.xml
online version: 
schema: 2.0.0
---

# Set-AzureRmRecoveryServicesAsrVaultSettings

## SYNOPSIS
Sets the Site Recovery vault context for further operations.

## SYNTAX

```
Set-AzureRmRecoveryServicesAsrVaultSettings -Vault <ARSVault> [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmRecoveryServicesAsrVaultSettings** cmdlet sets the Azure Site Recovery vault context for further operations.
This does not apply to recovery services vaults.

## EXAMPLES

### Example 1
```
PS C:\> $vaultSettings = Set-AzureRmRecoveryServicesAsrVaultSettings -Vault $RecoveryServicesVault
```

Sets the passed recovery services vault context for further Azure Site Recovery cmdlets and returns the set vault settings.

## PARAMETERS

### -Vault
{{Fill Vault Description}}

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
