---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version: https://learn.microsoft.com/powershell/module/az.keyvault/invoke-azkeyvaultkeyoperation
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

### Example 1: Encrypts using an encryption key
```powershell
$result = Invoke-AzKeyVaultKeyOperation -Operation Encrypt -Algorithm RSA1_5 -VaultName test-kv -Name test-key -Value (ConvertTo-SecureString -String "test" -AsPlainText -Force)
$result | Format-List
```

```output
KeyId     : https://test-kv.vault.azure.net/keys/test-key/bd8b77352a2443d4983bd70e9f660bc6
Result    : iVlA6rHicEm6F9vtU3jARzxWughOcRK9htj4UMy0ijd4a4hHwYrSy4lSXhiQTKSMpX+Qv3NTaz/fKNWdSoudCAwv2ZX/pYlSqZmDoAHzjUc
            4wDQAAVZAUvOxHcpCQf3CrlvQK3XfsZeddeiD9laiUU3iB2Ivh3trX0G/Y29gL54THKsmlwXh5mBhxcXHaUv0erDzEVAGnC73FHlJoHCTdm
            7eUMWvsnfhtd/BhcuBb/CeMy1QzHgoBTrByWms4KsTODBEZt41aVkdYxJDREsC8X6a/1vp9EeV+7jm3sZLl+Dm7XOpUjbR+/BUU7HKaw09i
            BRQJGhXf7oyZOf3g6EPEQ==
Algorithm : RSA1_5
```

Encrypts string "test" using test-key stored in test-kv. The `Result` is encrypted result in Base64 string format.

### Example 2: Decrypt encrypted data
```powershell
$result
$result = Invoke-AzKeyVaultKeyOperation -Operation Decrypt -Algorithm RSA1_5 -VaultName test-kv -Name test-key -Value (ConvertTo-SecureString -String $result.Result -AsPlainText -Force)
$result | Format-List
```

```output
KeyId     : https://test-kv.vault.azure.net/keys/test-key/bd8b77352a2443d4983bd70e9f660bc6
Result    : test
Algorithm : RSA1_5
```

Decrypts encrypted data that is encrypted using test-key stored in test-kv. The `Result` is a plain string.

### Example 3: Wraps a symmetric key using a specified key
```powershell
$result = Invoke-AzKeyVaultKeyOperation -Operation Wrap -Algorithm RSA1_5 -VaultName test-kv -Name test-key -Value (ConvertTo-SecureString -String "ovQIlbB0DgWhZA7sgkPxbg9H-Ly-VlNGPSgGrrZvlIo" -AsPlainText -Force) 

$result | Format-List
```

```output
KeyId     : https://test-kv.vault.azure.net/keys/test-key/375cdf20252043b79c8ca0c57b6c7679
Result    : imHceWcmB5jufcz+qS+HwaXOvPiaeOQ2dF1Bh+2DByuw+AOyoL3wtwDSilP5BlR3DAB3byj4hlUqkEKcoHJpOGnU53mWeV0yhL+Wx0O4T9n
            +e54Gtv/sfJD0CcMg+89mssi7hgU0u1IaaowzgSmP7ViRrSVGu8FniAR6hdf7j0JL7ON8IIFMy/+7yq00aJs/dspcESGjcZDry5pLzYphel
            x7VAEbjuv1TuiHwu8cJYH/GsvROErOQbQ+aKcKlYTMzZRGdCA07xXltvFrTiCIvzeKE/lTJVIHH/Nv4aRne/ENRC2cx92r9XFhEBID6o5Td
            kN09Wdjejo8nLDRw9XbtQ==
Algorithm : RSA1_5
```

Wraps a symmetric key using key named test-key stored in test-kv. The `Result` is wrapped result in Base64 string format.

### Example 4: Unwraps a symmetric key using a specified key
```powershell
Invoke-AzKeyVaultKeyOperation -Operation Unwrap -Algorithm RSA1_5 -VaultName test-kv -Name test-key -Value (ConvertTo-SecureString -String $result.Result -AsPlainText -Force) 
```

```output
KeyId     : https://test-kv.vault.azure.net/keys/test-key/375cdf20252043b79c8ca0c57b6c7679
Result    : ovQIlbB0DgWhZA7sgkPxbg9H-Ly-VlNGPSgGrrZvlIo
Algorithm : RSA1_5
```

Unwraps a symmetric key using a specified key test-key stored in test-kv. The `Result` is a plain string.

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
