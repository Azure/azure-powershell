---
external help file: Microsoft.Azure.Commands.KeyVault.dll-Help.xml
online version: https://msdn.microsoft.com/en-us/library/dn868052.aspx
schema: 2.0.0
---

# Undo-AzureKeyVaultKeyRemoval

## SYNOPSIS
Recovers a deleted key in a key vault into an active state.

## SYNTAX

```
Undo-AzureKeyVaultKeyRemoval [-VaultName] <String> [-Name] <String> [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Undo-AzureKeyVaultKeyRemoval** cmdlet will recover a previously deleted key.
The recovered key will be active and can be used for all normal key operations.
Caller needs to have 'recover' permission in order to perform this operation.

## EXAMPLES

### Example 1
```
PS C:\>Undo-AzureKeyVaultKeyRemoval -VaultName 'MyKeyVault' -Name 'MyKey'
```

This command will recover the key 'MyKey' that was previously deleted, into an active and usable state.

## PARAMETERS

### -Name
Key name.
Cmdlet constructs the FQDN of a key from vault name, currently selected environment and key name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: KeyName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VaultName
Vault name.
Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.KeyVault.Models.KeyBundle

## NOTES

## RELATED LINKS

[Remove-AzureKeyVaultKey](./Remove-AzureKeyVaultKey.md)

[Add-AzureKeyVaultKey](./Add-AzureKeyVaultKey.md)

[Get-AzureKeyVaultKey](./Get-AzureKeyVaultKey.md)

