---
external help file: Az.SecurityInsights-help.xml
Module Name: Az.SecurityInsights
online version: https://learn.microsoft.com/powershell/module/az.securityinsights/get-azsentinelentityinsight
schema: 2.0.0
---

# Get-AzSentinelEntityInsight

## SYNOPSIS
Execute Insights for an entity.

## SYNTAX

```
Get-AzSentinelEntityInsight -EntityId <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] -EndTime <DateTime> -StartTime <DateTime> [-AddDefaultExtendedTimeRange]
 [-InsightQueryId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Execute Insights for an entity.

## EXAMPLES

### Example 1: Get Insights for an Entity for a given time range
```powershell
$startTime = (Get-Date).AddDays(-7).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
 $endTime = (Get-Date).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
 Get-AzSentinelEntityInsight -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -EntityId "myEntityId" -EndTime $endTime -StartTime $startTime
```

```output
QueryId                    : 4191a4d7-e72b-4564-b2fb-25580630384b
QueryTimeIntervalEndTime   : 12/21/2021 10:00:00 AM
QueryTimeIntervalStartTime : 12/14/2021 10:00:00 AM
TableQueryResultColumn     : {Activity, expectedCount, actualCount, anomalyScore…}
TableQueryResultRow        : {4663 - An attempt was made to access an object. 0 3901 713.91 1 0}
```

This command gets insights for an Entity for a given time range.

### Example 2: Get Insights for an Entity by entity Id for a given time range
```powershell
$startTime = (Get-Date).AddDays(-7).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
 $endTime = (Get-Date).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
 $Entity = Get-AzSentinelEntity -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -EntityId "8d036a2d-f37d-e936-6cca-4e172687cb79"
 $Entity | Get-AzSentinelEntityInsight -EndTime $endTime -StartTime $startTime
```

```output
QueryId                    : 4191a4d7-e72b-4564-b2fb-25580630384b
QueryTimeIntervalEndTime   : 12/21/2021 10:00:00 AM
QueryTimeIntervalStartTime : 12/14/2021 10:00:00 AM
TableQueryResultColumn     : {Activity, expectedCount, actualCount, anomalyScore…}
TableQueryResultRow        : {4663 - An attempt was made to access an object. 0 3901 713.91 1 0}
```

This command gets insights for an Entity by object for a given time range.

## PARAMETERS

### -AddDefaultExtendedTimeRange
Indicates if query time range should be extended with default time range of the query.
Default value is false

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndTime
The end timeline date, so the results returned are before this date.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EntityId
entity ID

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

### -InsightQueryId
List of Insights Query Id.
If empty, default value is all insights of this entity

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -StartTime
The start timeline date, so the results returned are after this date.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceName
The name of the workspace.

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

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IEntityGetInsightsResponse

## NOTES

## RELATED LINKS
