---
external help file: Az.Cdn-help.xml
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/Az.Cdn/new-AzFrontDoorCdnMigrationParametersObject
schema: 2.0.0
---

# New-AzFrontDoorCdnMigrationParametersObject

## SYNOPSIS
Create an in-memory object for MigrationParameters.

## SYNTAX

```
New-AzFrontDoorCdnMigrationParametersObject -ProfileName <String> [-ClassicResourceReferenceId <String>]
 [-MigrationWebApplicationFirewallMapping <IMigrationWebApplicationFirewallMapping[]>] [-SkuName <SkuName>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
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
To construct, see NOTES section for MIGRATIONWEBAPPLICATIONFIREWALLMAPPING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IMigrationWebApplicationFirewallMapping[]
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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
Name of the pricing tier.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.SkuName
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.MigrationParameters

## NOTES

## RELATED LINKS
