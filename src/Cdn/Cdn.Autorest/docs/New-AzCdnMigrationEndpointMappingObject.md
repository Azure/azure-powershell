---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/Az.Cdn/new-azcdnmigrationendpointmappingobject
schema: 2.0.0
---

# New-AzCdnMigrationEndpointMappingObject

## SYNOPSIS
Create an in-memory object for MigrationEndpointMapping.

## SYNTAX

```
New-AzCdnMigrationEndpointMappingObject [-MigratedFrom <String>] [-MigratedTo <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for MigrationEndpointMapping.

## EXAMPLES

### Example 1: Create a Cdn Migration Endpoint Mapping Object
```powershell
$map1 = New-AzCdnMigrationEndpointMappingObject -MigratedFrom maxtestendpointcli-test-profile1.azureedge.net -MigratedTo maxtestendpointcli-test-profile2
```

Generate a map for endpoint to be migrated

## PARAMETERS

### -MigratedFrom
Name of the classic CDN profile endpoint.

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

### -MigratedTo
Name of the newly created migrated Azure Frontdoor Standard/Premium profile endpoint.
This name will replace the name of the classic CDN endpoint resource.

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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.MigrationEndpointMapping

## NOTES

## RELATED LINKS

