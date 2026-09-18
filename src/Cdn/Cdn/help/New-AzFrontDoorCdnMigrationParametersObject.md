---
external help file: Az.Cdn-help.xml
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/Az.Cdn/new-azfrontdoorcdnmigrationparametersobject
schema: 2.0.0
---

# New-AzFrontDoorCdnMigrationParametersObject

## SYNOPSIS
Create an in-memory object for MigrationParameters.

## SYNTAX

```
New-AzFrontDoorCdnMigrationParametersObject -ProfileName <String> [-ClassicResourceReferenceId <String>]
 [-MigrationWebApplicationFirewallMapping <IMigrationWebApplicationFirewallMapping[]>] [-SkuName <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for MigrationParameters.

## EXAMPLES

### Example 1: Create an in-memory object for MigrationParameters
```powershell
New-AzFrontDoorCdnMigrationParametersObject -ProfileName test
```

```output
ProfileName
-----------
test
```

Create an in-memory object for MigrationParameters

## PARAMETERS

### -ClassicResourceReferenceId
Resource ID.

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

### -MigrationWebApplicationFirewallMapping
Waf mapping for the migrated profile.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IMigrationWebApplicationFirewallMapping[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProfileName
Name of the new profile that need to be created.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
Name of the pricing tier.

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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.MigrationParameters

## NOTES

## RELATED LINKS
