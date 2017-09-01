---
external help file: Microsoft.Azure.Commands.KeyVault.dll-Help.xml
ms.assetid: 80AAA327-77C6-4372-9461-FFED5A15E678
online version: http://go.microsoft.com/fwlink/?LinkId=690296
schema: 2.0.0
---

# Backup-AzureKeyVaultSecret

## SYNOPSIS
Backs up a secret in a key vault.

## SYNTAX

### BySecretName (Default)
```
Backup-AzureKeyVaultSecret [-VaultName] <String> [-Name] <String> [[-OutputFile] <String>] [-Force] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### BySecret
```
Backup-AzureKeyVaultSecret [-Secret] <Secret> [[-OutputFile] <String>] [-Force] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Backup-AzureKeyVaultSecret** cmdlet backs up a specified secret in a key vault by downloading it and storing it in a file.
If there are multiple versions of the secret, all versions are included in the backup.
Because the downloaded content is encrypted, it cannot be used outside of Azure Key Vault.
You can restore a backed-up secret to any key vault in the subscription that it was backed up from.

Typical reasons to use this cmdlet are:

- You want to escrow a copy of your secret, so that you have an offline copy in case you accidentally delete your secret in your key vault.
- You added a secret to a key vault and now want to clone the secret into a different Azure region, so that you can use it from all instances of your distributed application. Use the Backup-AzureKeyVaultSecret cmdlet to retrieve the secret in encrypted format and then use the Restore-AzureKeyVaultSecret cmdlet and specify a key vault in the second region. (Note that the regions must belong to the same geography.)

## EXAMPLES

### Example 1: Back up a secret with an automatically generated file name
```
PS C:\>Backup-AzureKeyVaultSecret -VaultName 'MyKeyVault' -Name 'MySecret'
```

This command retrieves the secret named MySecret from the key vault named MyKeyVault and saves a backup of that secret to a file that is automatically named for you, and displays the file name.

### Example 2: Back up a secret to a specified file name, overwriting the existing file without prompting
```
PS C:\>Backup-AzureKeyVaultSecret -VaultName 'MyKeyVault' -Name 'MySecret' -OutputFile 'C:\Backup.blob' -Force
```

This command retrieves the secret named MySecret from the key vaultnamed MyKeyVault and saves a backup of that secret to a file named Backup.blob.

### Example 3: Back up a secret previously retrieved to a specified file name
```
PS C:\>$secret = Get-AzureKeyVaultSecret -VaultName 'MyKeyVault' -Name 'MySecret'
PS C:\>Backup-AzureKeyVaultSecret -Secret $secret -OutputFile 'C:\Backup.blob'
```

This command uses the $secret object's vault name and name to retrieves the secret and saves its backup to a file named Backup.blob.

## PARAMETERS

### -Force
Prompts you for confirmation before overwriting the output file, if that exists.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: 3
Default value: False
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Specifies the name of the secret to back up.

```yaml
Type: String
Parameter Sets: BySecretName
Aliases: SecretName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -OutputFile
Specifies the output file in which the backup blob is stored.
If you do not specify this parameter, this cmdlet generates a file name for you.
If you specify the name of an existing output file, the operation will not complete and returns an error message that the backup file already exists.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Secret
Specifies the object whose name and vault should be used for the backup operation.

```yaml
Type: Secret
Parameter Sets: BySecret
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VaultName
Specifies the name of the key vault that contains the secret to back up.

```yaml
Type: String
Parameter Sets: BySecretName
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
Default value: False
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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### String
The cmdlet returns the path of the output file containing the backup of the key.

## NOTES

## RELATED LINKS

[Set-AzureKeyVaultSecret](./Set-AzureKeyVaultSecret.md)

[Get-AzureKeyVaultSecret](./Get-AzureKeyVaultSecret.md)

[Remove-AzureKeyVaultSecret](./Remove-AzureKeyVaultSecret.md)

[Restore-AzureKeyVaultSecret](./Restore-AzureKeyVaultSecret.md)

