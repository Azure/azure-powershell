---
external help file:
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/az.hdinsightonaks/New-AzHdInsightOnAksNodeProfileObject
schema: 2.0.0
---

# New-AzHdInsightOnAksNodeProfileObject

## SYNOPSIS
Create a node profile with SKU and worker count.

## SYNTAX

```
New-AzHdInsightOnAksNodeProfileObject -Count <Int32> -Type <String> -VMSize <String> [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create a node profile with SKU and worker count.

## EXAMPLES

### Example 1: Create a node profile with SKU and worker count.
```powershell
$vmSize="Standard_E8ads_v5";
$workerCount=5;
$nodeProfile = New-AzHdInsightOnAksNodeProfileObject -Type "Worker" -Count $workerCount -VMSize $vmSize
```

Create a profile with SKU Standard_E8ads_v5 and 5 worker nodes.

## PARAMETERS

### -Count
The virtual machine SKU.

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
The node type.

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
The number of virtual machines.

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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

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

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.INodeProfile

## NOTES

## RELATED LINKS

