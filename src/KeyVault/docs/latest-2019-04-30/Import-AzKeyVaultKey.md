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
Import-AzKeyVaultKey -Name <String> [-KeyVaultDnsSuffix <String>] [-VaultName <String>]
 [-Parameter <IKeyImportParameters>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ImportExpanded
```
Import-AzKeyVaultKey -Name <String> [-KeyVaultDnsSuffix <String>] [-VaultName <String>] [-Enabled]
 [-Expire <DateTime>] [-Hsm] [-KeyCrv <JsonWebKeyCurveName>] [-KeyDInputFile <String>]
 [-KeyDpInputFile <String>] [-KeyDqInputFile <String>] [-KeyEInputFile <String>] [-KeyKInputFile <String>]
 [-KeyKid <String>] [-KeyKty <JsonWebKeyType>] [-KeyNInputFile <String>] [-KeyOp <String[]>]
 [-KeyPInputFile <String>] [-KeyQInputFile <String>] [-KeyQiInputFile <String>] [-KeyTInputFile <String>]
 [-KeyXInputFile <String>] [-KeyYInputFile <String>] [-NotBefore <DateTime>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ImportViaIdentityExpanded
```
Import-AzKeyVaultKey -InputObject <IKeyVaultIdentity> [-KeyVaultDnsSuffix <String>] [-VaultName <String>]
 [-Enabled] [-Expire <DateTime>] [-Hsm] [-KeyCrv <JsonWebKeyCurveName>] [-KeyDInputFile <String>]
 [-KeyDpInputFile <String>] [-KeyDqInputFile <String>] [-KeyEInputFile <String>] [-KeyKInputFile <String>]
 [-KeyKid <String>] [-KeyKty <JsonWebKeyType>] [-KeyNInputFile <String>] [-KeyOp <String[]>]
 [-KeyPInputFile <String>] [-KeyQInputFile <String>] [-KeyQiInputFile <String>] [-KeyTInputFile <String>]
 [-KeyXInputFile <String>] [-KeyYInputFile <String>] [-NotBefore <DateTime>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ImportViaIdentity
```
Import-AzKeyVaultKey -InputObject <IKeyVaultIdentity> [-KeyVaultDnsSuffix <String>] [-VaultName <String>]
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

### -KeyCrv
Elliptic curve name.
For valid values, see JsonWebKeyCurveName.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Support.JsonWebKeyCurveName
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KeyDInputFile
Input File for KeyD (RSA private exponent, or the D component of an EC private key.)

```yaml
Type: System.String
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KeyDpInputFile
Input File for KeyDp (RSA private key parameter.)

```yaml
Type: System.String
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KeyDqInputFile
Input File for KeyDq (RSA private key parameter.)

```yaml
Type: System.String
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KeyEInputFile
Input File for KeyE (RSA public exponent.)

```yaml
Type: System.String
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KeyKid
Key identifier.

```yaml
Type: System.String
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KeyKInputFile
Input File for KeyK (Symmetric key.)

```yaml
Type: System.String
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KeyKty
JsonWebKey key type (kty).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Support.JsonWebKeyType
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KeyNInputFile
Input File for KeyN (RSA modulus.)

```yaml
Type: System.String
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KeyOp
HELP MESSAGE MISSING

```yaml
Type: System.String[]
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KeyPInputFile
Input File for KeyP (RSA secret prime.)

```yaml
Type: System.String
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KeyQiInputFile
Input File for KeyQi (RSA private key parameter.)

```yaml
Type: System.String
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KeyQInputFile
Input File for KeyQ (RSA secret prime, with p < q.)

```yaml
Type: System.String
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KeyTInputFile
Input File for KeyT (HSM Token, used with 'Bring Your Own Key'.)

```yaml
Type: System.String
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KeyVaultDnsSuffix
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

### -KeyXInputFile
Input File for KeyX (X component of an EC public key.)

```yaml
Type: System.String
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KeyYInputFile
Input File for KeyY (Y component of an EC public key.)

```yaml
Type: System.String
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

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

### -Parameter
The key import parameters.
To construct, see NOTES section for PARAMETER properties and create a hash table.

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

### -Tag
Application specific metadata in the form of key-value pairs.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VaultName
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

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.IKeyVaultIdentity

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IKeyImportParameters

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IKeyBundle

## ALIASES

### Add-AzKeyVaultKey

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### PARAMETER <IKeyImportParameters>: The key import parameters.
  - `[AttributeEnabled <Boolean?>]`: Determines whether the object is enabled.
  - `[AttributeExpire <DateTime?>]`: Expiry date in UTC.
  - `[AttributeNotBefore <DateTime?>]`: Not before date in UTC.
  - `[Hsm <Boolean?>]`: Whether to import as a hardware key (HSM) or software key.
  - `[KeyCrv <JsonWebKeyCurveName?>]`: Elliptic curve name. For valid values, see JsonWebKeyCurveName.
  - `[KeyD <Byte[]>]`: RSA private exponent, or the D component of an EC private key.
  - `[KeyDp <Byte[]>]`: RSA private key parameter.
  - `[KeyDq <Byte[]>]`: RSA private key parameter.
  - `[KeyE <Byte[]>]`: RSA public exponent.
  - `[KeyK <Byte[]>]`: Symmetric key.
  - `[KeyKid <String>]`: Key identifier.
  - `[KeyKty <JsonWebKeyType?>]`: JsonWebKey key type (kty).
  - `[KeyN <Byte[]>]`: RSA modulus.
  - `[KeyOp <String[]>]`: 
  - `[KeyP <Byte[]>]`: RSA secret prime.
  - `[KeyQ <Byte[]>]`: RSA secret prime, with p < q.
  - `[KeyQi <Byte[]>]`: RSA private key parameter.
  - `[KeyT <Byte[]>]`: HSM Token, used with 'Bring Your Own Key'.
  - `[KeyX <Byte[]>]`: X component of an EC public key.
  - `[KeyY <Byte[]>]`: Y component of an EC public key.
  - `[Tag <IKeyImportParametersTags>]`: Application specific metadata in the form of key-value pairs.
    - `[(Any) <String>]`: This indicates any property can be added to this object.

## RELATED LINKS

