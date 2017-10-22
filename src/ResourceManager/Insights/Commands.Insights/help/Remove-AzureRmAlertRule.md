---
external help file: Microsoft.Azure.Commands.Insights.dll-Help.xml
ms.assetid: C7EC21C7-1C7E-49B2-9B33-486532FCDAEC
online version: 
schema: 2.0.0
---

# Remove-AzureRmAlertRule

## SYNOPSIS
Removes an alert rule.

## SYNTAX

```
Remove-AzureRmAlertRule -ResourceGroup <String> -Name <String> [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzureRmAlertRule** cmdlet removes an alert rule.
You must specify the name of the alert rule and the resource group to which it is assigned.

## EXAMPLES

### Example 1: Remove an alert rule
```
PS C:\>Remove-AzureRmAlertRule -ResourceGroup "Default-Web-CentralUS" -Name "myalert-7da64548-214d-42ca-b12b-b245bb8f0ac8"
RequestId                                                                                                    StatusCode
---------                                                                                                    ----------
2c6c159b-0e73-4a01-a67b-c32c1a0008a3                                                                                 OK
```

This command removes the alert rule named myalert-7da64548-214d-42ca-b12b-b245bb8f0ac8 in the resource group Default-Web-CentralUS.

## PARAMETERS

### -Name
Specifies the name of the alert rule to remove.

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
Specifies the name of the resource group for the alert rule.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.Collections.Generic.List`1[Microsoft.Azure.AzureOperationResponse]

## NOTES

## RELATED LINKS

[Add-AzureRmLogAlertRule](./Add-AzureRmLogAlertRule.md)

[Add-AzureRmMetricAlertRule](./Add-AzureRmMetricAlertRule.md)

[Add-AzureRmWebtestAlertRule](./Add-AzureRmWebtestAlertRule.md)

[Get-AzureRmAlertHistory](./Get-AzureRmAlertHistory.md)

[Get-AzureRmAlertRule](./Get-AzureRmAlertRule.md)


