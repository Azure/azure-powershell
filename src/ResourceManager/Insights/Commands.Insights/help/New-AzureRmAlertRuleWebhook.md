---
external help file: Microsoft.Azure.Commands.Insights.dll-Help.xml
ms.assetid: 0137ECA3-37E1-4064-8A65-A582519E9017
online version: 
schema: 2.0.0
---

# New-AzureRmAlertRuleWebhook

## SYNOPSIS
Creates an alert rule webhook.

## SYNTAX

```
New-AzureRmAlertRuleWebhook [-ServiceUri] <String> [[-Properties] <Hashtable>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmAlertRuleWebhook** cmdlet creates an alert rule webhook.

## EXAMPLES

### Example 1: Create an alert rule webhook
```
PS C:\>New-AzureRmAlertRuleWebhook -ServiceUri "http://contoso.com"
```

This command creates an alert rule webhook by specifying only the service URI.

### Example 2: Create a webhook with one property
```
PS C:\>$Actual = New-AzureRmAlertRuleWebhook -ServiceUri "http://contoso.com" -Properties @{prop1 = 'value1'}
```

This command creates an alert rule webhook for Contoso.com that has one property, and then stores it in the $Actual variable.

## PARAMETERS

### -Properties
Specifies the list of properties in the format @(property1 = 'value1',....).

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases: 

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServiceUri
Specifies the service URI.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[Add-AzureRmLogAlertRule](./Add-AzureRmLogAlertRule.md)

[Add-AzureRmMetricAlertRule](./Add-AzureRmMetricAlertRule.md)

[Add-AzureRmWebtestAlertRule](./Add-AzureRmWebtestAlertRule.md)

[New-AzureRmAlertRuleEmail](./New-AzureRmAlertRuleEmail.md)

[New-AzureRmAutoscaleWebhook](./New-AzureRmAutoscaleWebhook.md)


