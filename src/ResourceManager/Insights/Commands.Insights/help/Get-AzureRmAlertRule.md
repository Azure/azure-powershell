---
external help file: Microsoft.Azure.Commands.Insights.dll-Help.xml
ms.assetid: A837077C-0A79-431C-93D2-799B2134EE69
online version: 
schema: 2.0.0
---

# Get-AzureRmAlertRule

## SYNOPSIS
Gets alert rules.

## SYNTAX

### Parameters for Get-AzureRmAlertRule cmdlet
```
Get-AzureRmAlertRule -ResourceGroup <String> [-DetailedOutput] [<CommonParameters>]
```

### Parameters for Get-AzureRmAlertRule cmdlet using name
```
Get-AzureRmAlertRule -ResourceGroup <String> -Name <String> [-DetailedOutput] [<CommonParameters>]
```

### Parameters for Get-AzureRmAlertRule cmdlet using target resource uri
```
Get-AzureRmAlertRule -ResourceGroup <String> -TargetResourceId <String> [-DetailedOutput] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmAlertRule** cmdlet gets an alert rule by its name or URI, or all alert rules from a specified resource group.

## EXAMPLES

### Example 1: Get alert rules for a resource group
```
PS C:\>Get-AzureRmAlertRule -ResourceGroup "Default-Web-CentralUS"
```

This command gets all of the alert rules for the resource group named Default-Web-CentralUS.
The output does not contain details about the rules because the *DetailedOutput* parameter is not specified.

### Example 2: Get an alert rule by name
```
PS C:\>Get-AzureRmAlertRule -ResourcGroup "Default-Web-CentralUS" -Name "myalert-7da64548-214d-42ca-b12b-b245bb8f0ac8"
```

This command gets the alert rule named myalert-7da64548-214d-42ca-b12b-b245bb8f0ac8.
Because the *DetailedOutput* parameter is not specified, the output contains only basic information about the alert rule.

### Example 3: Get an alert rule by name with detailed output
```
PS C:\>Get-AzureRmAlertRule -ResourceGroup "Default-Web-CentralUS" -Name "myalert-7da64548-214d-42ca-b12b-b245bb8f0ac8" -DetailedOutput
```

This command gets the alert rule named myalert-7da64548-214d-42ca-b12b-b245bb8f0ac8.
The *DetailedOutput* parameter is specified, so the output is detailed.

## PARAMETERS

### -DetailedOutput
Displays full details in the output.

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

### -Name
Specifies the name of the alert rule to get.

```yaml
Type: String
Parameter Sets: Parameters for Get-AzureRmAlertRule cmdlet using name
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroup
Specifies the name of the resource group.

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

### -TargetResourceId
Specifies the ID of the target resource.

```yaml
Type: String
Parameter Sets: Parameters for Get-AzureRmAlertRule cmdlet using target resource uri
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.Collections.Generic.List`1[Microsoft.Azure.Commands.Insights.OutputClasses.PSManagementItemDescriptor]

## NOTES

## RELATED LINKS

[Add-AzureRmLogAlertRule](./Add-AzureRmLogAlertRule.md)

[Add-AzureRmMetricAlertRule](./Add-AzureRmMetricAlertRule.md)

[Add-AzureRmWebtestAlertRule](./Add-AzureRmWebtestAlertRule.md)

[Get-AzureRmAlertHistory](./Get-AzureRmAlertHistory.md)

[Remove-AzureRmAlertRule](./Remove-AzureRmAlertRule.md)


