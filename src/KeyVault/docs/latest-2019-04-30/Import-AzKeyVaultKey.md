---
external help file:
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
Import-AzKeyVaultKey -Name <String> [-VaultBaseUrl <String>] [-Parameter <IKeyImportParameters>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ImportExpanded
```
Import-AzKeyVaultKey -Name <String> [-VaultBaseUrl <String>] [-Crv <JsonWebKeyCurveName>] [-Dp <Byte[]>]
 [-Dq <Byte[]>] [-Enabled] [-Expire <DateTime>] [-Hsm] [-KeyD <Byte[]>] [-KeyE <Byte[]>] [-KeyK <Byte[]>]
 [-KeyN <Byte[]>] [-KeyP <Byte[]>] [-KeyQ <Byte[]>] [-KeyT <Byte[]>] [-KeyX <Byte[]>] [-KeyY <Byte[]>]
 [-Kid <String>] [-Kty <JsonWebKeyType>] [-NotBefore <DateTime>] [-Op <String[]>] [-Qi <Byte[]>]
 [-RecoveryLevel <DeletionRecoveryLevel>] [-Tag <IKeyImportParametersTags>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ImportViaIdentityExpanded
```
Import-AzKeyVaultKey -InputObject <IKeyVaultIdentity> [-VaultBaseUrl <String>] [-Crv <JsonWebKeyCurveName>]
 [-Dp <Byte[]>] [-Dq <Byte[]>] [-Enabled] [-Expire <DateTime>] [-Hsm] [-KeyD <Byte[]>] [-KeyE <Byte[]>]
 [-KeyK <Byte[]>] [-KeyN <Byte[]>] [-KeyP <Byte[]>] [-KeyQ <Byte[]>] [-KeyT <Byte[]>] [-KeyX <Byte[]>]
 [-KeyY <Byte[]>] [-Kid <String>] [-Kty <JsonWebKeyType>] [-NotBefore <DateTime>] [-Op <String[]>]
 [-Qi <Byte[]>] [-RecoveryLevel <DeletionRecoveryLevel>] [-Tag <IKeyImportParametersTags>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ImportViaIdentity
```
Import-AzKeyVaultKey -InputObject <IKeyVaultIdentity> [-VaultBaseUrl <String>]
 [-Parameter <IKeyImportParameters>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The import key operation may be used to import any key type into an Azure Key Vault.
If the named key already exists, Azure Key Vault creates a new version of the key.
This operation requires the keys/import permission.

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
Dynamic: False
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
Dynamic: False
```

### -Enabled
Determines whether the object is enabled.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Expire
Expiry date in UTC.

```yaml
Type: System.DateTime
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Hsm
Whether to import as a hardware key (HSM) or software key.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
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
Dynamic: False
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
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### -KeyQ
RSA secret prime, with p < q.

```yaml
Type: System.Byte[]
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
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
Dynamic: False
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
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### -NotBefore
Not before date in UTC.

```yaml
Type: System.DateTime
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### -RecoveryLevel
Reflects the deletion recovery level currently in effect for keys in the current vault.
If it contains 'Purgeable' the key can be permanently deleted by a privileged user; otherwise, only the system can purge the key, at the end of the retention interval.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Support.DeletionRecoveryLevel
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IKeyImportParameters

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.IKeyVaultIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IKeyBundle

## ALIASES

### Add-AzKeyVaultKey

## RELATED LINKS

