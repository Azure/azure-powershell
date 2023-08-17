---
external help file:
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/new-azcontainerapptrafficweightobject
schema: 2.0.0
---

# New-AzContainerAppTrafficWeightObject

## SYNOPSIS
Create an in-memory object for TrafficWeight.

## SYNTAX

```
New-AzContainerAppTrafficWeightObject [-Label <String>] [-LatestRevision <Boolean>] [-RevisionName <String>]
 [-Weight <Int32>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for TrafficWeight.

## EXAMPLES

### Example 1: Create a TrafficWeight object for ContainerApp.
```powershell
New-AzContainerAppTrafficWeightObject -Label production -LatestRevision $True -Weight 100
```

```output
Label      LatestRevision RevisionName Weight
-----      -------------- ------------ ------
production True                        100
```

Create a TrafficWeight object for ContainerApp.

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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.TrafficWeight

## NOTES

ALIASES

## RELATED LINKS

