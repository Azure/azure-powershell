---
external help file: Microsoft.Azure.Commands.Insights.dll-Help.xml
ms.assetid: 11A521DF-E77C-4D6F-A2D9-1C2CF8972F57
online version: 
schema: 2.0.0
---

# Add-AzureRmLogAlertRule

## SYNOPSIS
Adds or replaces a log alert rule.

## SYNTAX

```
Add-AzureRmLogAlertRule [-TargetResourceGroup <String>] [-TargetResourceId <String>] [-Level <String>]
 -OperationName <String> [-TargetResourceProvider <String>] [-Status <String>] [-SubStatus <String>]
 -Location <String> [-Description <String>] [-DisableRule] -ResourceGroup <String> -Name <String>
 [-Actions <System.Collections.Generic.List`1[Microsoft.Azure.Management.Insights.Models.RuleAction]>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Add-AzureRmLogAlertRule** cmdlet adds or replaces an event alert rule.
The added rule is associated with a resource group and has a name.

## EXAMPLES

### Example 1: Add a log alert rule
```
PS C:\>Add-AzureRmLogAlertRule -Name "logRule" -Location "East US" -ResourceGroup "Default-Web-EastUS" -OperationName "Create" -TargetResourceId "/subscriptions/abbfb07c-6c93-40be-bc9b-4f0deba32f4c/resourceGroups/Default-Web-EastUS/providers/microsoft.web/sites/misitiooeltuyo" -Description "My log rule"
RequestId                                                                                                    StatusCode
---------                                                                                                    ----------
9a5bc388-c7ac-4dc6-aa70-f4bc29c2c712                                                                                 OK
```

This command adds or updates an event-based alert rule.

## PARAMETERS

### -Actions
Specifies a comma-separated list of actions.

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Management.Insights.Models.RuleAction]
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Description
Specifies a description of the rule.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DisableRule
Disables a rule.
If you do not specify this parameter, the rule is enabled.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Level
Specifies the level of the event the rule is monitoring.
Specify this parameter only for event-based rules.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Location
Specifies the location for the rule.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Specifies the name of the rule.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -OperationName
Specifies the name of the operation.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroup
Specifies the name of the resource group for the rule.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Status
Specifies the status.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SubStatus
Specifies the substatus.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TargetResourceGroup
Specifies the resource group of the resource the rule is monitoring.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TargetResourceId
Specifies the ID of the resource the rule is monitoring.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TargetResourceProvider
Specifies the resource provider of the resource the rule is monitoring.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.Commands.Insights.OutputClasses.PSAddAlertRuleOperationResponse

## NOTES

## RELATED LINKS

[Add-AzureRmMetricAlertRule](./Add-AzureRmMetricAlertRule.md)

[Add-AzureRmWebtestAlertRule](./Add-AzureRmWebtestAlertRule.md)

[Get-AzureRmAlertHistory](./Get-AzureRmAlertHistory.md)

[New-AzureRmAlertRuleEmail](./New-AzureRmAlertRuleEmail.md)

[New-AzureRmAlertRuleWebhook](./New-AzureRmAlertRuleWebhook.md)


