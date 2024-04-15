---
external help file: Az.SecurityInsights-help.xml
Module Name: Az.SecurityInsights
online version: https://learn.microsoft.com/powershell/module/az.securityinsights/get-azsentinelthreatintelligenceindicatormetric
schema: 2.0.0
---

# Get-AzSentinelThreatIntelligenceIndicatorMetric

## SYNOPSIS
Get threat intelligence indicators metrics (Indicators counts by Type, Threat Type, Source).

## SYNTAX

```
Get-AzSentinelThreatIntelligenceIndicatorMetric -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Get threat intelligence indicators metrics (Indicators counts by Type, Threat Type, Source).

## EXAMPLES

### Example 1: Get all metrics for Threat Intelligence Indicators
```powershell
Get-AzSentinelThreatIntelligenceIndicatorMetric -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
```

```output
LastUpdatedTimeUtc : 2022-02-07T10:44:45.3919348Z
PatternTypeMetric  : {network-traffic, url, ipv4-addr, file}
SourceMetric       : {Microsoft Emerging Threat Feed, Bing Safety Phishing URL, Azure Sentinel, CyberCrime…}
ThreatTypeMetric   : {botnet, maliciousurl, phishing, malicious-activity…}
```

This command gets Threat Intelligence Indicator metrics.

## PARAMETERS

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IThreatIntelligenceMetrics

## NOTES

## RELATED LINKS
