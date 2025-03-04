---
external help file:
Module Name: Az.ServiceLinker
online version: https://learn.microsoft.com/powershell/module/az.ServiceLinker/new-azservicelinkersecretauthinfoobject
schema: 2.0.0
---

# New-AzServiceLinkerSecretAuthInfoObject

## SYNOPSIS
Create an in-memory object for SecretAuthInfo.

## SYNTAX

```
New-AzServiceLinkerSecretAuthInfoObject [-Name <String>] [-SecretKeyVaultUri <String>]
 [-SecretNameInKeyVault <String>] [-SecretValue <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for SecretAuthInfo.

## EXAMPLES

### Example 1: Create Secret Auth info with raw value
```powershell
New-AzServiceLinkerSecretAuthInfoObject -Name user -SecretValue password
```

```output
AuthType Name
-------- ----
secret   user
```

Create Secret Auth info with raw value

### Example 2: Create Secret Auth info with keyvault secret uri
```powershell
New-AzServiceLinkerSecretAuthInfoObject -Name user -SecretKeyVaultUri "https://servicelinker-kv-ref.vault.azure.net/secrets/test-secret/cc5d8095a54f4755b342f4e7884b5c84" 
```

```output
AuthType Name
-------- ----
secret   user
```

Create Secret Auth info with keyvault secret uri

### Example 3: Create Secret Auth info with keyvault secret reference(It's for AKS only and `-SecretStoreVaultId` must be set at the same time when creating linker)
```powershell
New-AzServiceLinkerSecretAuthInfoObject -Name user -SecretNameInKeyVault test-secret
```

```output
AuthType Name
-------- ----
secret   user
```

Create Secret Auth info with keyvault secret reference
It's for AKS only and `-SecretStoreVaultId` must be set at the same time when creating linker

## PARAMETERS

### -Name
Username or account name for secret auth.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecretKeyVaultUri
The Key Vault Uri of secret.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecretNameInKeyVault
The name of secret in keyvault refenced by -SecretStoreKeyVaultId.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecretValue
Raw value of secret.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Models.Api20221101Preview.SecretAuthInfo

## NOTES

## RELATED LINKS

