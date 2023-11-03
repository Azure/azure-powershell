---
external help file:
Module Name: Az.Workloads
online version: https://learn.microsoft.com/powershell/module/Az.Workloads/new-AzWorkloadsSapLandscapeMonitorSidMappingObject
schema: 2.0.0
---

# New-AzWorkloadsSapLandscapeMonitorSidMappingObject

## SYNOPSIS
Create an in-memory object for SapLandscapeMonitorSidMapping.

## SYNTAX

```
New-AzWorkloadsSapLandscapeMonitorSidMappingObject [-Name <String>] [-TopSid <String[]>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for SapLandscapeMonitorSidMapping.

## EXAMPLES

### Example 1: Create a new SID mapping for SAP Landscape Monitor
```powershell
New-AzWorkloadsSapLandscapeMonitorSidMappingObject -Name Prod -TopSid "{SID2,SID1}"
```

```output
Name TopSid
---- ------
Prod {{SID2,SID1}}
```

Create a new Metrics Threshold object to be used for creating a SAP Landscape Monitor

## PARAMETERS

### -Name
Gets or sets the name of the grouping.

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

### -TopSid
Gets or sets the list of SID's.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.SapLandscapeMonitorSidMapping

## NOTES

ALIASES

## RELATED LINKS

