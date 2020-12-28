---
external help file:
Module Name: Az.ADDomainServices
online version: https://docs.microsoft.com/en-us/powershell/module/az.ADDomainServices/new-AzADDomainServicesResourceForestSettingsObject
schema: 2.0.0
---

# New-AzADDomainServiceResourceForestSettingObject

## SYNOPSIS
Create a in-memory object for ResourceForestSettings

## SYNTAX

```
New-AzADDomainServiceResourceForestSettingObject [-ForestTrust <IForestTrust[]>] [-ResourceForest <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for ResourceForestSettings

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> New-AzADDomainServiceResourceForestSettingObject -ResourceForest resourcetest

ResourceForest
--------------
resourcetest
```

{{ Add description here }}

## PARAMETERS

### -ForestTrust
List of settings for Resource Forest.
To construct, see NOTES section for FORESTTRUST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrust[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceForest
Resource Forest.

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

### Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ResourceForestSettings

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


FORESTTRUST <IForestTrust[]>: List of settings for Resource Forest.
  - `[FriendlyName <String>]`: Friendly Name
  - `[RemoteDnsIP <String>]`: Remote Dns ips
  - `[TrustDirection <String>]`: Trust Direction
  - `[TrustPassword <String>]`: Trust Password
  - `[TrustedDomainFqdn <String>]`: Trusted Domain FQDN

## RELATED LINKS

