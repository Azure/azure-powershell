---
external help file:
Module Name: Az.KeyVault
online version: https://docs.microsoft.com/en-us/powershell/module/az.keyvault/invoke-azkeyvaultsignkey
schema: 2.0.0
---

# Invoke-AzKeyVaultSignKey

## SYNOPSIS
The SIGN operation is applicable to asymmetric and symmetric keys stored in Azure Key Vault since this operation uses the private portion of the key.
This operation requires the keys/sign permission.

## SYNTAX

### Sign (Default)
```
Invoke-AzKeyVaultSignKey -KeyName <String> -KeyVersion <String> [-KeyVaultDnsSuffix <String>]
 [-VaultName <String>] [-Parameter <IKeySignParameters>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### SignExpanded
```
Invoke-AzKeyVaultSignKey -KeyName <String> -KeyVersion <String> -Algorithm <JsonWebKeySignatureAlgorithm>
 -InputFile <String> [-KeyVaultDnsSuffix <String>] [-VaultName <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SignViaIdentityExpanded
```
Invoke-AzKeyVaultSignKey -InputObject <IKeyVaultIdentity> -Algorithm <JsonWebKeySignatureAlgorithm>
 -InputFile <String> [-KeyVaultDnsSuffix <String>] [-VaultName <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SignViaIdentity
```
Invoke-AzKeyVaultSignKey -InputObject <IKeyVaultIdentity> [-KeyVaultDnsSuffix <String>] [-VaultName <String>]
 [-Parameter <IKeySignParameters>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The SIGN operation is applicable to asymmetric and symmetric keys stored in Azure Key Vault since this operation uses the private portion of the key.
This operation requires the keys/sign permission.

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
The signing/verification algorithm identifier.
For more information on possible algorithm types, see JsonWebKeySignatureAlgorithm.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Support.JsonWebKeySignatureAlgorithm
Parameter Sets: SignExpanded, SignViaIdentityExpanded
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

### -InputFile
Input File for Value (HELP MESSAGE MISSING)

```yaml
Type: System.String
Parameter Sets: SignExpanded, SignViaIdentityExpanded
Aliases:

Required: True
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
Parameter Sets: SignViaIdentityExpanded, SignViaIdentity
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
Parameter Sets: Sign, SignExpanded
Aliases:

Required: True
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

### -KeyVersion
The version of the key.

```yaml
Type: System.String
Parameter Sets: Sign, SignExpanded
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
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IKeySignParameters
Parameter Sets: Sign, SignViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IKeySignParameters

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IKeyOperationResult

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### PARAMETER <IKeySignParameters>: The key operations parameters.
  - `Algorithm <JsonWebKeySignatureAlgorithm>`: The signing/verification algorithm identifier. For more information on possible algorithm types, see JsonWebKeySignatureAlgorithm.
  - `Value <Byte[]>`: 

## RELATED LINKS

