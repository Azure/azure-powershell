---
external help file:
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/Az.Purview/new-azpurviewazuresqldatabasemanagedinstancescanrulesetobject
schema: 2.0.0
---

# New-AzPurviewAzureSqlDatabaseManagedInstanceScanRulesetObject

## SYNOPSIS
Create an in-memory object for AzureSqlDatabaseManagedInstanceScanRuleset.

## SYNTAX

```
New-AzPurviewAzureSqlDatabaseManagedInstanceScanRulesetObject [-Description <String>]
 [-ExcludedSystemClassification <String[]>] [-IncludedCustomClassificationRuleName <String[]>]
 [-Type <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AzureSqlDatabaseManagedInstanceScanRuleset.

## EXAMPLES

### Example 1: Create Azure SQL Database Managed Instance custom scanruleset object
```powershell
New-AzPurviewAzureSqlDatabaseManagedInstanceScanRulesetObject -Description 'desc' -ExcludedSystemClassification @('MICROSOFT.FINANCIAL.CREDIT_CARD_NUMBER','MICROSOFT.SECURITY.COMMON_PASSWORDS') -IncludedCustomClassificationRuleName @('ClassificationRule2') -Type 'Custom'
```

```output
CreatedAt                            :
Description                          : desc
ExcludedSystemClassification         : {MICROSOFT.FINANCIAL.CREDIT_CARD_NUMBER, MICROSOFT.SECURITY.COMMON_PASSWORDS}
Id                                   :
IncludedCustomClassificationRuleName : {ClassificationRule2}
Kind                                 : AzureSqlDatabaseManagedInstance
LastModifiedAt                       :
Name                                 :
Status                               :
Type                                 : Custom
Version                              :
```

Create Azure SQL Database Managed Instance custom scanruleset object

## PARAMETERS

### -Description


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

### -ExcludedSystemClassification


```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludedCustomClassificationRuleName


```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type


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

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.AzureSqlDatabaseManagedInstanceScanRuleset

## NOTES

## RELATED LINKS

