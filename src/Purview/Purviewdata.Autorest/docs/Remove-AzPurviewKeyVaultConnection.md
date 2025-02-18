---
external help file:
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/az.purview/remove-azpurviewkeyvaultconnection
schema: 2.0.0
---

# Remove-AzPurviewKeyVaultConnection

## SYNOPSIS
Deletes the key vault connection associated with the account

## SYNTAX

```
Remove-AzPurviewKeyVaultConnection -Endpoint <String> -KeyVaultName <String> [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Deletes the key vault connection associated with the account

## EXAMPLES

### Example 1: Remove a key vault connection
```powershell
Remove-AzPurviewKeyVaultConnection -Endpoint 'https://parv-brs-2.purview.azure.com/' -KeyVaultName 'KeyVaultConnection5'
```

```output
BaseUrl           : https://datascankv.vault.azure.net/
Description       : This is a key vault
Id                : keyVaults/KeyVaultConnection5
Name              : KeyVaultConnection5
```

Remove key vault connection named 'KeyVaultConnection5'

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -Endpoint
The scanning endpoint of your purview account.
Example: https://{accountName}.purview.azure.com

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

### -KeyVaultName
.

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

### -PassThru
Returns true when the command succeeds

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
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.Api20211001Preview.IAzureKeyVault

## NOTES

## RELATED LINKS

