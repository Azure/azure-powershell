---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version: https://docs.microsoft.com/powershell/module/az.keyvault/invoke-azkeyvaultkeyoperation
schema: 2.0.0
---

# Invoke-AzKeyVaultKeyOperation

## SYNOPSIS
Performs operation like "Encrypt", "Decrypt", "Wrap" or "Unwrap" using a specified key stored in a key vault or managed hsm.

## SYNTAX

### ByVaultName (Default)
```
Invoke-AzKeyVaultKeyOperation -Operation <String> -Algorithm <String> -Value <SecureString>
 [-VaultName] <String> [-Name] <String> [-Version <String>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByHsmName
```
Invoke-AzKeyVaultKeyOperation -Operation <String> -Algorithm <String> -Value <SecureString> [-HsmName] <String>
 [-Name] <String> [-Version <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByKeyInputObject
```
Invoke-AzKeyVaultKeyOperation -Operation <String> -Algorithm <String> -Value <SecureString>
 [-InputObject] <PSKeyVaultKeyIdentityItem> [-Version <String>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Invoke-AzKeyVaultKeyOperation cmdlet supports
1. Encrypting an arbitrary sequence of bytes using an encryption key.
2. Decrypting a single block of encrypted data.
3. Wrapping a symmetric key using a specified key.
4. Unwrapping a symmetric key using the specified key that was initially used for wrapping that key.

## EXAMPLES

### Encrypts using an encryption key
```powershell
$result = Invoke-AzKeyVaultKeyOperation -Operation Encrypt -Algorithm RSA1_5 -VaultName test-kv -Name test-key -Value (ConvertTo-SecureString -String "test" -AsPlainText -Force)
$result | Format-List
```

```output
KeyId     : https://test-kv.vault.azure.net/keys/test-key/375cdf20252043b79c8ca0c57b6c7679
Result    : e01HmkipqwCZyQd2QZ5XOTSA3rlZ719qqHHadzepFGtvTSoDwr+sBPmODVqScvq5/MBS9YyT+u6AM5hsFKD+h2FJOB6Pj/nwO5MZ/tZ8F974qAxXXT2qvdNm6pHKhREgPlCHmz+L6xK/8KOF+LS1E9wmuAt8ZPsJ7BtcT2bcvR4VmeOaUhvxcuNMV675nsFpwHBv6GWSfQA+RkDCIpmv6msdpK8NG6+la+fSPA6EKMJkmqF3SZ6RhSOjg00S7jXEWncIzdp6RRKYZFKY+QhqLgFVABL876IW4nDGYgdVSG7KnH0K56QqtK5L4MhvU4XYE69I4WiWbZ7rcVLE3cO/9A==
Algorithm : RSA1_5
```

Encrypts string "test" using test-key stored in test-kv. The returned result is Base64 string format.

### Decrypt encrypted data
```powershell
$result
$result = Invoke-AzKeyVaultKeyOperation -Operation Decrypt -Algorithm RSA1_5 -VaultName test-kv -Name test-key -Value (ConvertTo-SecureString -String $result.Result -AsPlainText -Force)
$result | Format-List
```

```output
KeyId     : https://test-kv.vault.azure.net/keys/test-key/375cdf20252043b79c8ca0c57b6c7679
Result    : test
Algorithm : RSA1_5
```

Decrypts encrypted data that is encrypted using test-key stored in test-kv. 

### Encrypts using an encryption key
```powershell
$result = Invoke-AzKeyVaultKeyOperation -Operation Encrypt -Algorithm RSA1_5 -VaultName test-kv -Name test-key -Value (ConvertTo-SecureString -String "test" -AsPlainText -Force) 

$result | Format-List
```

```output
KeyId     : https://test-kv.vault.azure.net/keys/test-key/375cdf20252043b79c8ca0c57b6c7679
Result    : e01HmkipqwCZyQd2QZ5XOTSA3rlZ719qqHHadzepFGtvTSoDwr+sBPmODVqScvq5/MBS9YyT+u6AM5hsFKD+h2FJOB6Pj/nwO5MZ/tZ8F974qAxXXT2qvdNm6pHKhREgPlCHmz+L6xK/8KOF+LS1E9wmuAt8ZPsJ7BtcT2bcvR4VmeOaUhvxcuNMV675nsFpwHBv6GWSfQA+RkDCIpmv6msdpK8NG6+la+fSPA6EKMJkmqF3SZ6RhSOjg00S7jXEWncIzdp6RRKYZFKY+QhqLgFVABL876IW4nDGYgdVSG7KnH0K56QqtK5L4MhvU4XYE69I4WiWbZ7rcVLE3cO/9A==
Algorithm : RSA1_5
```

Encrypts string "test" using test-key stored in test-kv. The returned result is Base64 string format.

### Wraps a symmetric key using a specified key
```powershell
$result = Invoke-AzKeyVaultKeyOperation -Operation Wrap -Algorithm RSA1_5 -VaultName test-kv -Name test-key -Value (ConvertTo-SecureString -String "ovQIlbB0DgWhZA7sgkPxbg9H-Ly-VlNGPSgGrrZvlIo" -AsPlainText -Force) 

$result | Format-List
```

```output
KeyId     : https://test-kv.vault.azure.net/keys/test-key/375cdf20252043b79c8ca0c57b6c7679
Result    : e01HmkipqwCZyQd2QZ5XOTSA3rlZ719qqHHadzepFGtvTSoDwr+sBPmODVqScvq5/MBS9YyT+u6AM5hsFKD+h2FJOB6Pj/nwO5MZ/tZ8F974qAxXXT2qvdNm6pHKhREgPlCHmz+L6xK/8KOF+LS1E9wmuAt8ZPsJ7BtcT2bcvR4VmeOaUhvxcuNMV675nsFpwHBv6GWSfQA+RkDCIpmv6msdpK8NG6+la+fSPA6EKMJkmqF3SZ6RhSOjg00S7jXEWncIzdp6RRKYZFKY+QhqLgFVABL876IW4nDGYgdVSG7KnH0K56QqtK5L4MhvU4XYE69I4WiWbZ7rcVLE3cO/9A==
Algorithm : RSA1_5
```

Wraps a symmetric key using key named test-key stored in test-kv. The returned result is Base64 string.

### Unwraps a symmetric key using a specified key
```powershell
Invoke-AzKeyVaultKeyOperation -Operation Unwrap -Algorithm RSA1_5 -VaultName test-kv -Name test-key -Value (ConvertTo-SecureString -String $result.Result -AsPlainText -Force) 
```

```output
KeyId     : https://test-kv.vault.azure.net/keys/test-key/375cdf20252043b79c8ca0c57b6c7679
Result    : ovQIlbB0DgWhZA7sgkPxbg9H-Ly-VlNGPSgGrrZvlIo
Algorithm : RSA1_5
```

 Unwraps a symmetric key using a specified key test-key stored in test-kv. 

## PARAMETERS

### -Algorithm
Algorithm identifier

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: EncryptionAlgorithm, WrapAlgorithm

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -HsmName
HSM name.

```yaml
Type: System.String
Parameter Sets: ByHsmName
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Key object

```yaml
Type: Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultKeyIdentityItem
Parameter Sets: ByKeyInputObject
Aliases: Key

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Key name.

```yaml
Type: System.String
Parameter Sets: ByVaultName, ByHsmName
Aliases: KeyName

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Operation
Algorithm identifier

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

### -Value
The value to be operated

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultName
Vault name.

```yaml
Type: System.String
Parameter Sets: ByVaultName
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
Key version.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: KeyVersion

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

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultKeyIdentityItem

## OUTPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyOperationResult

## NOTES

## RELATED LINKS
