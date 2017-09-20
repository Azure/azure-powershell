---
external help file: Microsoft.Azure.Commands.Insights.dll-Help.xml
ms.assetid: 5E854358-CA9D-4336-BA6A-BF7B1FADAB50
online version: 
schema: 2.0.0
---

# New-AzureRmLeafCondition

## SYNOPSIS
Creates an new activity log alert condition object in memory.

## SYNTAX

```
New-AzureRmActivityLogAlertCondition -Field <String> -Equals <String> [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmActivityLogAlertCondition** cmdlet creates new activity log alert condition object in memory.

## EXAMPLES

### Example 1: Create a new activity log alert condition object in memory.
```
PS C:\>$condition = New-AzureRmActivityLogAlertCondition -Field "Requests" -Equals "OtherField"
```

This command creates a new activity log alert condition object in memory.

## PARAMETERS

### -Field
Specifies the field for the condition.

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

### -Equals
Specifies the equals property for the leaf condition.

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

### Microsoft.Azure.Management.Monitor.Management.Models.ActivityLogAlertLeafCondition

## NOTES

## RELATED LINKS

[Set-AzureRmActivityLogAlert](./Set-AzureRmActivityLogAlert.md)

[Enable-AzureRmActivityLogAlert](./Enable-AzureRmActivityLogAlert.md)

[Disable-AzureRmActivityLogAlert](./Disable-AzureRmActivityLogAlert.md)

[Get-AzureRmActivityLogAlert](./Get-AzureRmActivityLogAlert.md)

[Remove-AzureRmActivityLogAlert](./Remove-AzureRmActivityLogAlert.md)

[New-AzureRmActionGroup](./Get-AzureRmActionGroup.md)
