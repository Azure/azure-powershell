---
external help file: Az.KeyVault-help.xml
Module Name: Az.KeyVault
online version: https://docs.microsoft.com/en-us/powershell/module/az.keyvault/import-azkeyvaultkey
schema: 2.0.0
---

# Import-AzKeyVaultKey

## SYNOPSIS
The import key operation may be used to import any key type into an Azure Key Vault.
If the named key already exists, Azure Key Vault creates a new version of the key.
This operation requires the keys/import permission.

## SYNTAX

### Import (Default)
```
Import-AzKeyVaultKey -Name <String> [-Parameter <IKeyImportParameters>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### ImportExpanded
```
Import-AzKeyVaultKey -Name <String> [-Attribute <IKeyAttributes>] [-Crv <JsonWebKeyCurveName>] [-Dp <Byte[]>]
 [-Dq <Byte[]>] [-Hsm <Boolean>] [-KeyD <Byte[]>] [-KeyE <Byte[]>] [-KeyK <Byte[]>] [-KeyN <Byte[]>]
 [-KeyP <Byte[]>] [-KeyQ <Byte[]>] [-KeyT <Byte[]>] [-KeyX <Byte[]>] [-KeyY <Byte[]>] [-Kid <String>]
 [-Kty <JsonWebKeyType>] [-Op <String[]>] [-Qi <Byte[]>] [-Tag <IKeyImportParametersTags>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ImportViaIdentityExpanded
```
Import-AzKeyVaultKey -InputObject <IKeyVaultIdentity> [-Attribute <IKeyAttributes>]
 [-Crv <JsonWebKeyCurveName>] [-Dp <Byte[]>] [-Dq <Byte[]>] [-Hsm <Boolean>] [-KeyD <Byte[]>] [-KeyE <Byte[]>]
 [-KeyK <Byte[]>] [-KeyN <Byte[]>] [-KeyP <Byte[]>] [-KeyQ <Byte[]>] [-KeyT <Byte[]>] [-KeyX <Byte[]>]
 [-KeyY <Byte[]>] [-Kid <String>] [-Kty <JsonWebKeyType>] [-Op <String[]>] [-Qi <Byte[]>]
 [-Tag <IKeyImportParametersTags>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ImportViaIdentity
```
Import-AzKeyVaultKey -InputObject <IKeyVaultIdentity> [-Parameter <IKeyImportParameters>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The import key operation may be used to import any key type into an Azure Key Vault.
If the named key already exists, Azure Key Vault creates a new version of the key.
This operation requires the keys/import permission.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -Attribute
The key management attributes.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IKeyAttributes
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Crv
Elliptic curve name.
For valid values, see JsonWebKeyCurveName.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Support.JsonWebKeyCurveName
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases: KeyCrv

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -Dp
RSA private key parameter.

```yaml
Type: System.Byte[]
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases: KeyDp

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Dq
RSA private key parameter.

```yaml
Type: System.Byte[]
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases: KeyDq

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Hsm
Whether to import as a hardware key (HSM) or software key.

```yaml
Type: System.Boolean
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.IKeyVaultIdentity
Parameter Sets: ImportViaIdentityExpanded, ImportViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -KeyD
RSA private exponent, or the D component of an EC private key.

```yaml
Type: System.Byte[]
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyE
RSA public exponent.

```yaml
Type: System.Byte[]
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyK
Symmetric key.

```yaml
Type: System.Byte[]
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyN
RSA modulus.

```yaml
Type: System.Byte[]
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyP
RSA secret prime.

```yaml
Type: System.Byte[]
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyQ
RSA secret prime, with p \< q.

```yaml
Type: System.Byte[]
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyT
HSM Token, used with 'Bring Your Own Key'.

```yaml
Type: System.Byte[]
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyX
X component of an EC public key.

```yaml
Type: System.Byte[]
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyY
Y component of an EC public key.

```yaml
Type: System.Byte[]
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Kid
Key identifier.

```yaml
Type: System.String
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases: KeyKid

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Kty
JsonWebKey key type (kty).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Support.JsonWebKeyType
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases: KeyKty

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name for the imported key.

```yaml
Type: System.String
Parameter Sets: Import, ImportExpanded
Aliases: KeyName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Op
HELP MESSAGE MISSING

```yaml
Type: System.String[]
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases: KeyOp

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
The key import parameters.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IKeyImportParameters
Parameter Sets: Import, ImportViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Qi
RSA private key parameter.

```yaml
Type: System.Byte[]
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases: KeyQi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Application specific metadata in the form of key-value pairs.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IKeyImportParametersTags
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IKeyBundle
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.keyvault/import-azkeyvaultkey](https://docs.microsoft.com/en-us/powershell/module/az.keyvault/import-azkeyvaultkey)

