---
external help file: Az.DataCollectionRule.psm1-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-azprometheusforwarderdatasourceobject
schema: 2.0.0
---

# New-AzPrometheusForwarderDataSourceObject

## SYNOPSIS
Create an in-memory object for PrometheusForwarderDataSource.

## SYNTAX

```
New-AzPrometheusForwarderDataSourceObject [-LabelIncludeFilter <Hashtable>] [-Name <String>]
 [-Stream <String[]>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for PrometheusForwarderDataSource.

## EXAMPLES

### Example 1: Create prometheus forwarder data source object
```powershell
New-AzPrometheusForwarderDataSourceObject -LabelIncludeFilter @{"microsoft_metrics_include_label"="MonitoringData"} -Name "myPromDataSource1" -Stream "Microsoft-PrometheusMetrics"
```

```output
LabelIncludeFilter                                          Name              Stream
------------------                                          ----              ------
{…                                                          myPromDataSource1 {Microsoft-PrometheusMetrics}
```

This command creates a prometheus forwarder data source object.

## PARAMETERS

### -LabelIncludeFilter
The list of label inclusion filters in the form of label "name-value" pairs.
        Currently only one label is supported: 'microsoft_metrics_include_label'.
        Label values are matched case-insensitively.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
A friendly name for the data source.
        This name should be unique across all data sources (regardless of type) within the data collection rule.

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

### -Stream
List of streams that this data source will be sent to.

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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.PrometheusForwarderDataSource

## NOTES

## RELATED LINKS
