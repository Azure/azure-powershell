---
external help file:
Module Name: Az.SecurityInsights
online version: https://learn.microsoft.com/powershell/module/az.securityinsights/invoke-azsentinelthreatintelligenceindicatorquery
schema: 2.0.0
---

# Invoke-AzSentinelThreatIntelligenceIndicatorQuery

## SYNOPSIS
Query threat intelligence indicators as per filtering criteria.

## SYNTAX

### QueryExpanded (Default)
```
Invoke-AzSentinelThreatIntelligenceIndicatorQuery -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String>] [-Id <String[]>] [-IncludeDisabled] [-Keyword <String[]>] [-MaxConfidence <Int32>]
 [-MaxValidUntil <String>] [-MinConfidence <Int32>] [-MinValidUntil <String>] [-PageSize <Int32>]
 [-PatternType <String[]>] [-SkipToken <String>] [-SortBy <IThreatIntelligenceSortingCriteria[]>]
 [-Source <String[]>] [-ThreatType <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### QueryViaIdentityExpanded
```
Invoke-AzSentinelThreatIntelligenceIndicatorQuery -InputObject <ISecurityInsightsIdentity> [-Id <String[]>]
 [-IncludeDisabled] [-Keyword <String[]>] [-MaxConfidence <Int32>] [-MaxValidUntil <String>]
 [-MinConfidence <Int32>] [-MinValidUntil <String>] [-PageSize <Int32>] [-PatternType <String[]>]
 [-SkipToken <String>] [-SortBy <IThreatIntelligenceSortingCriteria[]>] [-Source <String[]>]
 [-ThreatType <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### QueryViaJsonFilePath
```
Invoke-AzSentinelThreatIntelligenceIndicatorQuery -ResourceGroupName <String> -WorkspaceName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### QueryViaJsonString
```
Invoke-AzSentinelThreatIntelligenceIndicatorQuery -ResourceGroupName <String> -WorkspaceName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Query threat intelligence indicators as per filtering criteria.

## EXAMPLES

### Example 1: Query all Threat Intelligence Indicators
```powershell
Invoke-AzSentinelThreatIntelligenceIndicatorQuery -ResourceGroupName "myResourceGroupName" -WorkspaceName "myWorkspaceName"
```

```output
Etag                                    Kind        Name                                    SystemDataCreatedAt SystemDataCreatedBy
----                                    ----        ----                                    ------------------- -------
"b603878e-0000-0100-0000-62d1d0010000"  indicator   f4dd9aa3-081b-2f0b-a5d7-3805954e8a39
```

This command queries TI indicators.

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

### -Id
Ids of threat intelligence indicators

```yaml
Type: System.String[]
Parameter Sets: QueryExpanded, QueryViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeDisabled
Parameter to include/exclude disabled indicators.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: QueryExpanded, QueryViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity
Parameter Sets: QueryViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Query operation

```yaml
Type: System.String
Parameter Sets: QueryViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Query operation

```yaml
Type: System.String
Parameter Sets: QueryViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Keyword
Keywords for searching threat intelligence indicators

```yaml
Type: System.String[]
Parameter Sets: QueryExpanded, QueryViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxConfidence
Maximum confidence.

```yaml
Type: System.Int32
Parameter Sets: QueryExpanded, QueryViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxValidUntil
End time for ValidUntil filter.

```yaml
Type: System.String
Parameter Sets: QueryExpanded, QueryViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MinConfidence
Minimum confidence.

```yaml
Type: System.Int32
Parameter Sets: QueryExpanded, QueryViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MinValidUntil
Start time for ValidUntil filter.

```yaml
Type: System.String
Parameter Sets: QueryExpanded, QueryViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PageSize
Page size

```yaml
Type: System.Int32
Parameter Sets: QueryExpanded, QueryViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PatternType
Pattern types

```yaml
Type: System.String[]
Parameter Sets: QueryExpanded, QueryViaIdentityExpanded
Aliases:

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
Parameter Sets: QueryExpanded, QueryViaJsonFilePath, QueryViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkipToken
Skip token.

```yaml
Type: System.String
Parameter Sets: QueryExpanded, QueryViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SortBy
Columns to sort by and sorting order

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.IThreatIntelligenceSortingCriteria[]
Parameter Sets: QueryExpanded, QueryViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Source
Sources of threat intelligence indicators

```yaml
Type: System.String[]
Parameter Sets: QueryExpanded, QueryViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: QueryExpanded, QueryViaJsonFilePath, QueryViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -ThreatType
Threat types of threat intelligence indicators

```yaml
Type: System.String[]
Parameter Sets: QueryExpanded, QueryViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceName
The name of the workspace.

```yaml
Type: System.String
Parameter Sets: QueryExpanded, QueryViaJsonFilePath, QueryViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.IThreatIntelligenceInformation

## NOTES

## RELATED LINKS

