---
external help file:
Module Name: Az.Authorization
online version: https://docs.microsoft.com/en-us/powershell/module/az.authorization/new-azauthorizationaccessreviewhistorydefinition
schema: 2.0.0
---

# New-AzAuthorizationAccessReviewHistoryDefinition

## SYNOPSIS
Create a scheduled or one-time Access Review History Definition

## SYNTAX

```
New-AzAuthorizationAccessReviewHistoryDefinition -HistoryDefinitionId <String> [-SubscriptionId <String>]
 [-Decision <AccessReviewResult[]>] [-DisplayName <String>] [-Instance <IAccessReviewHistoryInstance[]>]
 [-PatternInterval <Int32>] [-PatternType <AccessReviewRecurrencePatternType>] [-RangeEndDate <DateTime>]
 [-RangeNumberOfOccurrence <Int32>] [-RangeStartDate <DateTime>]
 [-RangeType <AccessReviewRecurrenceRangeType>] [-Scope <IAccessReviewScope[]>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a scheduled or one-time Access Review History Definition

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -Decision
Collection of review decisions which the history data should be filtered on.
For example if Approve and Deny are supplied the data will only contain review results in which the decision maker approved or denied a review request.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Authorization.Support.AccessReviewResult[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -DisplayName
The display name for the history definition.

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

### -HistoryDefinitionId
The id of the access review history definition.

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

### -Instance
Set of access review history instances for this history definition.
To construct, see NOTES section for INSTANCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Authorization.Models.Api20211116Preview.IAccessReviewHistoryInstance[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PatternInterval
The interval for recurrence.
For a quarterly review, the interval is 3 for type : absoluteMonthly.

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

### -PatternType
The recurrence type : weekly, monthly, etc.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Authorization.Support.AccessReviewRecurrencePatternType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RangeEndDate
The DateTime when the review is scheduled to end.
Required if type is endDate

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RangeNumberOfOccurrence
The number of times to repeat the access review.
Required and must be positive if type is numbered.

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

### -RangeStartDate
The DateTime when the review is scheduled to be start.
This could be a date in the future.
Required on create.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RangeType
The recurrence range type.
The possible values are: endDate, noEnd, numbered.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Authorization.Support.AccessReviewRecurrenceRangeType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
A collection of scopes used when selecting review history data
To construct, see NOTES section for SCOPE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Authorization.Models.Api20211116Preview.IAccessReviewScope[]
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.Authorization.Models.Api20211116Preview.IAccessReviewHistoryDefinition

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INSTANCE <IAccessReviewHistoryInstance[]>: Set of access review history instances for this history definition.
  - `[DisplayName <String>]`: The display name for the parent history definition.
  - `[Expiration <DateTime?>]`: Date time when history data report expires and the associated data is deleted.
  - `[FulfilledDateTime <DateTime?>]`: Date time when the history data report is scheduled to be generated.
  - `[ReviewHistoryPeriodEndDateTime <DateTime?>]`: Date time used when selecting review data, all reviews included in data end on or before this date. For use only with one-time/non-recurring reports.
  - `[ReviewHistoryPeriodStartDateTime <DateTime?>]`: Date time used when selecting review data, all reviews included in data start on or after this date. For use only with one-time/non-recurring reports.
  - `[RunDateTime <DateTime?>]`: Date time when the history data report is scheduled to be generated.

SCOPE <IAccessReviewScope[]>: A collection of scopes used when selecting review history data
  - `[ExpandNestedMembership <Boolean?>]`: Flag to indicate whether to expand nested memberships or not.
  - `[InactiveDuration <TimeSpan?>]`: Duration users are inactive for. The value should be in ISO  8601 format (http://en.wikipedia.org/wiki/ISO_8601#Durations).This code can be used to convert TimeSpan to a valid interval string: XmlConvert.ToString(new TimeSpan(hours, minutes, seconds))

## RELATED LINKS

