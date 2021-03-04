---
external help file:
Module Name: Az.DataProtection
online version: https://docs.microsoft.com/en-us/powershell/module/az.dataprotection/getdatasourcesetinfo
schema: 2.0.0
---

# GetDatasourceSetInfo

## SYNOPSIS


## SYNTAX

```
GetDatasourceSetInfo [-DatasourceInfo] <IDatasource> [<CommonParameters>]
```

## DESCRIPTION


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

### -DatasourceInfo
To construct, see NOTES section for DATASOURCEINFO properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IDatasource
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.Object

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


DATASOURCEINFO <IDatasource>: 
  - `ResourceId <String>`: Full ARM ID of the resource. For azure resources, this is ARM ID. For non azure resources, this will be the ID created by backup service via Fabric/Vault.
  - `[ObjectType <String>]`: Type of Datasource object, used to initialize the right inherited type
  - `[ResourceLocation <String>]`: Location of datasource.
  - `[ResourceName <String>]`: Unique identifier of the resource in the context of parent.
  - `[ResourceType <String>]`: Resource Type of Datasource.
  - `[ResourceUri <String>]`: Uri of the resource.
  - `[Type <String>]`: DatasourceType of the resource.

## RELATED LINKS

