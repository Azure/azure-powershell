---
external help file: Az.DataCollectionRule.psm1-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-azplatformtelemetrydatasourceobject
schema: 2.0.0
---

# New-AzPlatformTelemetryDataSourceObject

## SYNOPSIS
Create an in-memory object for PlatformTelemetryDataSource.

## SYNTAX

```
New-AzPlatformTelemetryDataSourceObject -Stream <String[]> [-Name <String>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for PlatformTelemetryDataSource.

## EXAMPLES

### Example 1: Create platform telemetry data source object
```powershell
New-AzPlatformTelemetryDataSourceObject -Stream "Microsoft.Insights/autoscalesettings:Logs-AutoscaleEvaluations","Microsoft.Insights/autoscalesettings:Logs-AutoscaleScaleActions" -Name "myAutoScalePlatformTelemetryLogs"
```

```output
Name                             Stream
----                             ------
myAutoScalePlatformTelemetryLogs {Microsoft.Insights/autoscalesettings:Logs-AutoscaleEvaluations, Microsoft.Insights/autoscalesettings:Logs-AutoscaleScaleActions}
```

This command creates a platform telemetry data source object with XPathQuery.

## PARAMETERS

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
List of platform telemetry streams to collect.

```yaml
Type: System.String[]
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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.PlatformTelemetryDataSource

## NOTES

## RELATED LINKS
