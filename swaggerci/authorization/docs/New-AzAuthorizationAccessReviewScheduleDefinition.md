---
external help file:
Module Name: Az.Authorization
online version: https://docs.microsoft.com/en-us/powershell/module/az.authorization/new-azauthorizationaccessreviewscheduledefinition
schema: 2.0.0
---

# New-AzAuthorizationAccessReviewScheduleDefinition

## SYNOPSIS
Create or Update access review schedule definition.

## SYNTAX

```
New-AzAuthorizationAccessReviewScheduleDefinition -ScheduleDefinitionId <String> [-SubscriptionId <String>]
 [-BackupReviewer <IAccessReviewReviewer[]>] [-DescriptionForAdmin <String>]
 [-DescriptionForReviewer <String>] [-DisplayName <String>] [-Instance <IAccessReviewInstance[]>]
 [-PatternInterval <Int32>] [-PatternType <AccessReviewRecurrencePatternType>] [-RangeEndDate <DateTime>]
 [-RangeNumberOfOccurrence <Int32>] [-RangeStartDate <DateTime>]
 [-RangeType <AccessReviewRecurrenceRangeType>] [-Reviewer <IAccessReviewReviewer[]>]
 [-SettingAutoApplyDecisionsEnabled] [-SettingDefaultDecision <DefaultDecisionType>]
 [-SettingDefaultDecisionEnabled] [-SettingInstanceDurationInDay <Int32>]
 [-SettingJustificationRequiredOnApproval] [-SettingMailNotificationsEnabled]
 [-SettingRecommendationLookBackDuration <TimeSpan>] [-SettingRecommendationsEnabled]
 [-SettingReminderNotificationsEnabled] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or Update access review schedule definition.

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

### -BackupReviewer
This is the collection of backup reviewers.
To construct, see NOTES section for BACKUPREVIEWER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Authorization.Models.Api20211116Preview.IAccessReviewReviewer[]
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

### -DescriptionForAdmin
The description provided by the access review creator and visible to admins.

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

### -DescriptionForReviewer
The description provided by the access review creator to be shown to reviewers.

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

### -DisplayName
The display name for the schedule definition.

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

### -Instance
This is the collection of instances returned when one does an expand on it.
To construct, see NOTES section for INSTANCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Authorization.Models.Api20211116Preview.IAccessReviewInstance[]
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

### -Reviewer
This is the collection of reviewers.
To construct, see NOTES section for REVIEWER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Authorization.Models.Api20211116Preview.IAccessReviewReviewer[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleDefinitionId
The id of the access review schedule definition.

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

### -SettingAutoApplyDecisionsEnabled
Flag to indicate whether auto-apply capability, to automatically change the target object access resource, is enabled.
If not enabled, a user must, after the review completes, apply the access review.

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

### -SettingDefaultDecision
This specifies the behavior for the autoReview feature when an access review completes.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Authorization.Support.DefaultDecisionType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SettingDefaultDecisionEnabled
Flag to indicate whether reviewers are required to provide a justification when reviewing access.

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

### -SettingInstanceDurationInDay
The duration in days for an instance.

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

### -SettingJustificationRequiredOnApproval
Flag to indicate whether the reviewer is required to pass justification when recording a decision.

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

### -SettingMailNotificationsEnabled
Flag to indicate whether sending mails to reviewers and the review creator is enabled.

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

### -SettingRecommendationLookBackDuration
Recommendations for access reviews are calculated by looking back at 30 days of data(w.r.t the start date of the review) by default.
However, in some scenarios, customers want to change how far back to look at and want to configure 60 days, 90 days, etc.
instead.
This setting allows customers to configure this duration.
The value should be in ISO 8601 format (http://en.wikipedia.org/wiki/ISO_8601#Durations).This code can be used to convert TimeSpan to a valid interval string: XmlConvert.ToString(new TimeSpan(hours, minutes, seconds))

```yaml
Type: System.TimeSpan
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SettingRecommendationsEnabled
Flag to indicate whether showing recommendations to reviewers is enabled.

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

### -SettingReminderNotificationsEnabled
Flag to indicate whether sending reminder emails to reviewers are enabled.

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

### Microsoft.Azure.PowerShell.Cmdlets.Authorization.Models.Api20211116Preview.IAccessReviewScheduleDefinition

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


BACKUPREVIEWER <IAccessReviewReviewer[]>: This is the collection of backup reviewers.
  - `[PrincipalId <String>]`: The id of the reviewer(user/servicePrincipal)

INSTANCE <IAccessReviewInstance[]>: This is the collection of instances returned when one does an expand on it.
  - `[BackupReviewer <IAccessReviewReviewer[]>]`: This is the collection of backup reviewers.
    - `[PrincipalId <String>]`: The id of the reviewer(user/servicePrincipal)
  - `[EndDateTime <DateTime?>]`: The DateTime when the review instance is scheduled to end.
  - `[Reviewer <IAccessReviewReviewer[]>]`: This is the collection of reviewers.
  - `[StartDateTime <DateTime?>]`: The DateTime when the review instance is scheduled to be start.

REVIEWER <IAccessReviewReviewer[]>: This is the collection of reviewers.
  - `[PrincipalId <String>]`: The id of the reviewer(user/servicePrincipal)

## RELATED LINKS

