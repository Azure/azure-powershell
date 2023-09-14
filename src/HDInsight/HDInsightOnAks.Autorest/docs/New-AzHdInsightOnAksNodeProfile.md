---
external help file:
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/az.hdinsightonaks/new-azhdinsightonaksnodeprofile
schema: 2.0.0
---

# New-AzHdInsightOnAksNodeProfile

## SYNOPSIS
Create node profile.

## SYNTAX

```
New-AzHdInsightOnAksNodeProfile -Count <Int32> -Type <String> -VMSize <String> [<CommonParameters>]
```

## DESCRIPTION
Create node profile.

## EXAMPLES

### Example 1: Create a node profile with SKU and worker count.
```powershell
$vmSize="Standard_E8ads_v5";
$workerCount=5;
$nodeProfile = New-AzHdInsightOnAksNodeProfile -Type "Worker" -Count $workerCount -VMSize $vmSize
```

Create a profile with SKU Standard_E8ads_v5 and 5 worker nodes.

## PARAMETERS

### -Count


```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: True
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

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMSize


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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api20230601Preview.INodeProfile

## NOTES

ALIASES

## RELATED LINKS



