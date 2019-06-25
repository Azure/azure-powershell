---
external help file: Microsoft.Azure.PowerShell.Cmdlets.AlertsManagement.dll-Help.xml
Module Name: Az.AlertsManagement
online version:
schema: 2.0.0
---

# Set-AzActionRule

## SYNOPSIS
{{ Fill in the Synopsis }}

## SYNTAX

### ByResourceId
```
Set-AzActionRule -ResourceId <String> [-SuppressionEndTime <String>] [-ReccurentValues <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByInputObject
```
Set-AzActionRule -InputObject <PSActionRule> [-SuppressionEndTime <String>] [-ReccurentValues <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByJsonFormatActionRule
```
Set-AzActionRule -ResourceGroupName <String> -Name <String> -ActionRule <String> -ActionRuleType <String>
 [-SuppressionEndTime <String>] [-ReccurentValues <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### BySimplifiedFormatActionRule
```
Set-AzActionRule -ResourceGroupName <String> -Name <String> [-Description <String>] -Status <String>
 -ScopeType <String> -ScopeValues <String> [-SeverityCondition <String>] [-MonitorServiceCondition <String>]
 [-MonitorCondition <String>] [-TargetResourceTypeCondition <String>] [-AlertRuleIdCondition <String>]
 [-DescriptionCondition <String>] [-AlertContextCondition <String>] -ActionRuleType <String>
 [-ReccurenceType <String>] [-SuppressionStartTime <String>] [-SuppressionEndTime <String>]
 [-ReccurentValues <String>] [-ActionGroupId <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
{{ Fill in the Description }}

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -ActionGroupId
Action Group Id which is to be notified.

```yaml
Type: String
Parameter Sets: BySimplifiedFormatActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ActionRule
Action rule Json format

```yaml
Type: String
Parameter Sets: ByJsonFormatActionRule
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ActionRuleType
Action rule Json format

```yaml
Type: String
Parameter Sets: ByJsonFormatActionRule, BySimplifiedFormatActionRule
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AlertContextCondition
Expected format - {\<operation\>:\<comma separated list of values\>} For eg.
Contains:smartgroups

```yaml
Type: String
Parameter Sets: BySimplifiedFormatActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AlertRuleIdCondition
Expected format - {\<operation\>:\<comma separated list of values\>} For eg.
Equals:/subscriptions/ad825170-845c-47db-8f00-11978947b089/resourceGroups/abvarma/providers/microsoft.insights/metricAlerts/test-mrmc-vm-abvarma

```yaml
Type: String
Parameter Sets: BySimplifiedFormatActionRule
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
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
Description of Action Rule

```yaml
Type: String
Parameter Sets: BySimplifiedFormatActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DescriptionCondition
Expected format - {\<operation\>:\<comma separated list of values\>} For eg.
Contains:Test Alert

```yaml
Type: String
Parameter Sets: BySimplifiedFormatActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The action rule resource

```yaml
Type: PSActionRule
Parameter Sets: ByInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MonitorCondition
Expected format - {\<operation\>:\<comma separated list of values\>} For eg.
NotEquals:Resolved

```yaml
Type: String
Parameter Sets: BySimplifiedFormatActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MonitorServiceCondition
Expected format - {\<operation\>:\<comma separated list of values\>} For eg.
Equals:Platform,Log Analytics

```yaml
Type: String
Parameter Sets: BySimplifiedFormatActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Action rule Name

```yaml
Type: String
Parameter Sets: ByJsonFormatActionRule, BySimplifiedFormatActionRule
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReccurenceType
Specifies the duration when the suppression should be applied.

```yaml
Type: String
Parameter Sets: BySimplifiedFormatActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReccurentValues
Reccurent values, if applicable.In case of Weekly - \[Saturday,Sunday\]
In case of Monthly - \[1,3,5,30\]

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name

```yaml
Type: String
Parameter Sets: ByJsonFormatActionRule, BySimplifiedFormatActionRule
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Get Action rule by resoure id.

```yaml
Type: String
Parameter Sets: ByResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScopeType
Scope Type

```yaml
Type: String
Parameter Sets: BySimplifiedFormatActionRule
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScopeValues
Comma separated list of values

```yaml
Type: String
Parameter Sets: BySimplifiedFormatActionRule
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SeverityCondition
Expected format - {\<operation\>:\<comma separated list of values\>} For eg.
Equals:Sev0,Sev1

```yaml
Type: String
Parameter Sets: BySimplifiedFormatActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Status
Status of Action Rule.

```yaml
Type: String
Parameter Sets: BySimplifiedFormatActionRule
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SuppressionEndTime
Suppression End Time.
Format 12/09/2018 06:00:00
 +Should be mentioned in case of Reccurent Supression Schedule - Once, Daily, Weekly or Monthly.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SuppressionStartTime
Suppression Start Time.
Format 12/09/2018 06:00:00
 +Should be mentioned in case of Reccurent Supression Schedule - Once, Daily, Weekly or Monthly.

```yaml
Type: String
Parameter Sets: BySimplifiedFormatActionRule
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetResourceTypeCondition
Expected format - {\<operation\>:\<comma separated list of values\>} For eg.
Contains:Virtual Machines,Storage Account

```yaml
Type: String
Parameter Sets: BySimplifiedFormatActionRule
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

### Microsoft.Azure.Commands.AlertsManagement.OutputModels.PSActionRule

## OUTPUTS

### Microsoft.Azure.Commands.AlertsManagement.OutputModels.PSActionRule

## NOTES

## RELATED LINKS
