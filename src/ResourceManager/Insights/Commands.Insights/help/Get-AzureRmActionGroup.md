---
external help file: Microsoft.Azure.Commands.Insights.dll-Help.xml
ms.assetid: 1CA26790-C791-4BFD-B986-70F28E3B095B
online version: 
schema: 2.0.0
---

# Get-AzureRmActionGroup

## SYNOPSIS
Gets action group(s).

## SYNTAX

```
Get-AzureRmActionGroup [-Name <String>] [-ResourceGroup <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmActionGroup** cmdlet gets one or more action groups.

## EXAMPLES

### Example 1: Get an action group by subscription ID
```
PS C:\>Get-AzureRmActionGroup
```

This command lists all the action group for the current subscription.

### Example 2: Get action groups for the given resource group
```
PS C:\>Get-AzureRmActionGroup -ResourceGroup "Default-activityLogAlerts"
```

This command lists action groups for the given resource group.

### Example 3: Get an action group.
```
PS C:\>Get-AzureRmActionGroup -ResourceGroup "Default-activityLogAlerts" -Name "actionGroup1"
```

This command lists one (a list with a single element) action group.

## PARAMETERS

### -Name
The name of the action group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroup
The name of the resource group where the action group exists.
If Name is not null or empty, this parameter must contain and non empty string.

```yaml
Type: System.String
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

### None

## OUTPUTS

### <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Insights.OutputClasses.PSActionGroupResource]

### None

## NOTES

## RELATED LINKS

[Set-AzureRmActionGroup](./Set-AzureRmActionGroup.md)
[Remove-AzureRmActionGroup](./Remove-AzureRmActionGroup.md)
[New-AzureRmActionGroupReceiver](./AzureRmActionGroupReceiver.md)