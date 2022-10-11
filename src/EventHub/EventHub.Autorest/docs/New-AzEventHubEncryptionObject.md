---
external help file:
Module Name: Az.EventHub
online version: https://docs.microsoft.com/powershell/module/az.EventHub/new-AzEventHubEncryptionObject
schema: 2.0.0
---

# New-AzEventHubEncryptionObject

## SYNOPSIS
Create an in-memory object for Encryption.

## SYNTAX

```
New-AzEventHubEncryptionObject [-KeySource <KeySource>] [-KeyVaultProperty <IKeyVaultProperties[]>]
 [-RequireInfrastructureEncryption <Boolean>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for Encryption.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -KeySource
Enumerates the possible value of keySource for Encryption.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventHub.Support.KeySource
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultProperty
Properties of KeyVault.
To construct, see NOTES section for KEYVAULTPROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IKeyVaultProperties[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequireInfrastructureEncryption
Enable Infrastructure Encryption (Double Encryption).

```yaml
Type: System.Boolean
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

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.Encryption

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`KEYVAULTPROPERTY <IKeyVaultProperties[]>`: Properties of KeyVault.
  - `[IdentityUserAssignedIdentity <String>]`: ARM ID of user Identity selected for encryption
  - `[KeyName <String>]`: Name of the Key from KeyVault
  - `[KeyVaultUri <String>]`: Uri of KeyVault
  - `[KeyVersion <String>]`: Key Version

## RELATED LINKS

