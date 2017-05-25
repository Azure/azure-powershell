---
external help file: Microsoft.Azure.Commands.Management.Storage.dll-Help.xml
online version: 
schema: 2.0.0
---

# New-AzureRmStorageAccountEncryptionKeySource

## SYNOPSIS
Create PSKeySource Object which will be used in Set-AzureRmStorageAccount as Encryption KeySource

## SYNTAX

### StorageKeySourceInstance
```
New-AzureRmStorageAccountEncryptionKeySource [-Type] <PsKeySourceTypeEnum> [<CommonParameters>]
```

### KeyVaultKeySourceInstance
```
New-AzureRmStorageAccountEncryptionKeySource [-Type] <PsKeySourceTypeEnum> -KeyName <String>
 -KeyVersion <String> -KeyVaultUri <String> [<CommonParameters>]
```

## DESCRIPTION
Create PSKeySource Object which will be used in Set-AzureRmStorageAccount as Encryption KeySource

## EXAMPLES

### Example 1: Enable Blob Encryption with KeyVault for a Storage account.
```
PS C:\>Set-AzureRmStorageAccount -ResourceGroupName "MyResourceGroup" -AccountName "MyStorageAccount" -IdentityType SystemAssigned
PS C:\>$account = Get-AzureRmStorageAccount -ResourceGroupName "MyResourceGroup" -AccountName "MyStorageAccount"

PS C:\>$keyVault = New-AzureRmKeyVault -VaultName "MyKeyVault" -ResourceGroupName "MyResourceGroup" -Location "EastUS2"
PS C:\>$key = Add-AzureKeyVaultKey -VaultName "MyKeyVault" -Name "MyKey" -Destination 'Software'
PS C:\>Set-AzureRmKeyVaultAccessPolicy -VaultName "MyKeyVault" -ObjectId $account.Identity.PrincipalId -PermissionsToKeys wrapkey,unwrapkey

PS C:\>$keySource = New-AzureRmStorageAccountEncryptionKeySource -Type MicrosoftKeyVault -KeyName $key.Name -KeyVersion $key.Version -KeyVaultUri $keyVault.VaultUri
PS C:\>Set-AzureRmStorageAccount -ResourceGroupName "MyResourceGroup" -AccountName "MyStorageAccount" -EnableEncryptionService "Blob" -KeySource $keySource
```

This command enables Storage Service encryption on Blob with a new created Keyvault.

### Example 2: Set Blob Encryption KeySource to Microsoft.Storage for a Storage account.
```
PS C:\>$keySource=New-AzureRmStorageAccountEncryptionKeySource -Type MicrosoftStorage
PS C:\>set-AzureRmStorageAccount -ResourceGroupName "MyResourceGroup" -Name "MyStorageAccount" -EnableEncryptionService Blob -KeySource $keySource
```

The command Enable Blob Encryption and set Blob Encryption KeySource to Microsoft.Storage for a Storage account.

## PARAMETERS

### -KeyName
Storage Account encryption keySource KeyVault KeyName

```yaml
Type: String
Parameter Sets: KeyVaultKeySourceInstance
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultUri
Storage Account encryption keySource KeyVault KeyVaultUri

```yaml
Type: String
Parameter Sets: KeyVaultKeySourceInstance
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVersion
Storage Account encryption keySource KeyVault KeyVersion

```yaml
Type: String
Parameter Sets: KeyVaultKeySourceInstance
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
Storage Account encryption keySource Type. 
The acceptable values for this parameter are:

- MicrosoftStorage
Set KeySource as "Microsoft.Storage", don't Specify KeyName, KeyVersion, KeyVaultUri when use this value.
- MicrosoftKeyvault
Set KeySource as "Microsoft.Keyvault", you must Specify KeyName, KeyVersion, KeyVaultUri when use this value.
```yaml
Type: PsKeySourceTypeEnum
Parameter Sets: (All)
Aliases: 
Accepted values: MicrosoftStorage, MicrosoftKeyvault

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Management.Storage.Models.PSKeySource

## NOTES

## RELATED LINKS

