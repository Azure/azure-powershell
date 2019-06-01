---
external help file:
Module Name: Az.KeyVault
online version: https://docs.microsoft.com/en-us/powershell/module/az.keyvault/invoke-azkeyvaultunwrapkey
schema: 2.0.0
---

# Invoke-AzKeyVaultUnwrapKey

## SYNOPSIS
The UNWRAP operation supports decryption of a symmetric key using the target key encryption key.
This operation is the reverse of the WRAP operation.
The UNWRAP operation applies to asymmetric and symmetric keys stored in Azure Key Vault since it uses the private portion of the key.
This operation requires the keys/unwrapKey permission.

## SYNTAX

### Unwrap (Default)
```
Invoke-AzKeyVaultUnwrapKey -KeyName <String> -KeyVersion <String> [-VaultBaseUrl <String>]
 [-Parameter <IKeyOperationsParameters>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UnwrapExpanded
```
Invoke-AzKeyVaultUnwrapKey -KeyName <String> -KeyVersion <String> -Algorithm <JsonWebKeyEncryptionAlgorithm>
 -Value <Byte[]> [-VaultBaseUrl <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UnwrapViaIdentityExpanded
```
Invoke-AzKeyVaultUnwrapKey -InputObject <IKeyVaultIdentity> -Algorithm <JsonWebKeyEncryptionAlgorithm>
 -Value <Byte[]> [-VaultBaseUrl <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UnwrapViaIdentity
```
Invoke-AzKeyVaultUnwrapKey -InputObject <IKeyVaultIdentity> [-VaultBaseUrl <String>]
 [-Parameter <IKeyOperationsParameters>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
The UNWRAP operation supports decryption of a symmetric key using the target key encryption key.
This operation is the reverse of the WRAP operation.
The UNWRAP operation applies to asymmetric and symmetric keys stored in Azure Key Vault since it uses the private portion of the key.
This operation requires the keys/unwrapKey permission.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -Algorithm
algorithm identifier

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Support.JsonWebKeyEncryptionAlgorithm
Parameter Sets: UnwrapExpanded, UnwrapViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.IKeyVaultIdentity
Parameter Sets: UnwrapViaIdentityExpanded, UnwrapViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -KeyName
The name of the key.

```yaml
Type: System.String
Parameter Sets: Unwrap, UnwrapExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KeyVersion
The version of the key.

```yaml
Type: System.String
Parameter Sets: Unwrap, UnwrapExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
The key operations parameters.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IKeyOperationsParameters
Parameter Sets: Unwrap, UnwrapViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Value
HELP MESSAGE MISSING

```yaml
Type: System.Byte[]
Parameter Sets: UnwrapExpanded, UnwrapViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VaultBaseUrl
MISSING DESCRIPTION 06

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IKeyOperationsParameters

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.IKeyVaultIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IKeyOperationResult

## ALIASES

## RELATED LINKS

