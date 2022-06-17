---
external help file:
Module Name: Az.OperationalInsights
online version: https://docs.microsoft.com/powershell/module/az.OperationalInsights/new-AzOperationalInsightsTableColumnObject
schema: 2.0.0
---

# New-AzOperationalInsightsTableColumnObject

## SYNOPSIS
Create an in-memory object for Column.

## SYNTAX

```
New-AzOperationalInsightsTableColumnObject [-DataTypeHint <ColumnDataTypeHintEnum>] [-Description <String>]
 [-DisplayName <String>] [-Name <String>] [-Type <ColumnTypeEnum>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for Column.

## EXAMPLES

### Example 1: Create a new Column which is used for New-AzOperationalInsightsTable cmdlet
```powershell
PS C:\> New-AzOperationalInsightsTableColumnObject -Name 'SourceSystem' -Description 'Type of agent the data was collected from. Possible values are OpsManager (Windows agent) or Linux.' -Type 'string'

DataTypeHint Description                                                                                         DisplayName IsDefaultDisplay IsHidden Name
------------ -----------                                                                                         ----------- ---------------- -------- ----
             Type of agent the data was collected from. Possible values are OpsManager (Windows agent) or Linux.                                       SourceSystem

```



### Example 2: Create a new Column which is used for New-AzOperationalInsightsTable cmdlet
```powershell
PS C:\> New-AzOperationalInsightsTableColumnObject -Name 'TimeGenerated' -Description 'Date and time the record was created.' -Type 'datetime'

DataTypeHint Description                           DisplayName IsDefaultDisplay IsHidden Name
------------ -----------                           ----------- ---------------- -------- ----
             Date and time the record was created.                                       TimeGenerated

```

Creates a TableColumnObject which is required to use "New-AzOperationalInsightsTable" cmdlet.

## PARAMETERS

### -DataTypeHint
Column data type logical hint.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.Support.ColumnDataTypeHintEnum
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
Column description.

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

### -DisplayName
Column display name.

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

### -Name
Column name.

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

### -Type
Column data type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.Support.ColumnTypeEnum
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

### Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.Models.Api20211201Preview.Column

## NOTES

ALIASES

## RELATED LINKS

