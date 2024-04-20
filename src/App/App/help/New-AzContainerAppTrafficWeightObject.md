---
external help file: Az.App-help.xml
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/Az.App/new-azcontainerapptrafficweightobject
schema: 2.0.0
---

# New-AzContainerAppTrafficWeightObject

## SYNOPSIS
Create an in-memory object for TrafficWeight.

## SYNTAX

```
New-AzContainerAppTrafficWeightObject [-Label <String>] [-LatestRevision <Boolean>] [-RevisionName <String>]
 [-Weight <Int32>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for TrafficWeight.

## EXAMPLES

### Example 1: Create an in-memory object for TrafficWeight.
```powershell
New-AzContainerAppTrafficWeightObject -Label "production" -Weight 100 -LatestRevision:$True
```

```output
Label      LatestRevision RevisionName Weight
-----      -------------- ------------ ------
production True                        100
```

Create an in-memory object for TrafficWeight.

## PARAMETERS

### -Label
Associates a traffic label with a revision.

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

### -LatestRevision
Indicates that the traffic weight belongs to a latest stable revision.

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

### -RevisionName
Name of a revision.

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

### -Weight
Traffic weight assigned to a revision.

```yaml
Type: System.Int32
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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.TrafficWeight

## NOTES

## RELATED LINKS
