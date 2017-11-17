---
external help file: Microsoft.Azure.Commands.Insights.dll-Help.xml
Module Name: AzureRM.Insights
ms.assetid: 1CA26790-C791-4BFD-B986-70F28E3B095B
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.insights/get-azurermactiongroup
schema: 2.0.0
---

# Get-AzureRmActionGroup

## SYNOPSIS
Gets action group(s).

## SYNTAX

### BySubscriptionOrResourceGroup (Default)
```
Get-AzureRmActionGroup [-ResourceGroupName <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByName
```
Get-AzureRmActionGroup -ResourceGroupName <String> -Name <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the action group.

```yaml
Type: String
Parameter Sets: ByName
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name

```yaml
Type: String
Parameter Sets: BySubscriptionOrResourceGroup
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: ByName
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

### None

## OUTPUTS

### <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Insights.OutputClasses.PSActionGroupResource]

### None

## NOTES

## RELATED LINKS

[Set-AzureRmActionGroup](./Set-AzureRmActionGroup.md)
[Remove-AzureRmActionGroup](./Remove-AzureRmActionGroup.md)
[New-AzureRmActionGroupReceiver](./AzureRmActionGroupReceiver.md)
