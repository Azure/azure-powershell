---
external help file: Microsoft.Azure.Commands.Insights.dll-Help.xml
Module Name: AzureRM.Insights
ms.assetid: 85492E00-3776-4F20-A444-9C28CC6154B7
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.insights/get-azurermactivitylogalert
schema: 2.0.0
---

# Get-AzureRmActivityLogAlert

## SYNOPSIS
Gets one or more activity log alert resources.

## SYNTAX

### GetByNameAndResourceGroup
```
Get-AzureRmActivityLogAlert -ResourceGroupName <String> -Name <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByResourceGroup
```
Get-AzureRmActivityLogAlert [-ResourceGroupName <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmActivityLogAlert** cmdlet gets one or more activity log alert resources.

## EXAMPLES

### Example 1: Get a activity log alerts by subscription ID
```
PS C:\>Get-AzureRmActivityLogAlert
```

This command lists all the activity log alerts for the current subscription.

### Example 2: Get activity log alerts for the given resource group
```
PS C:\>Get-AzureRmActivityLogAlert -ResourceGroupName "Default-activityLogAlerts"
```

This command lists activity log alerts for the given resource group.

### Example 3: Get an activity log alert.
```
PS C:\>Get-AzureRmActivityLogAlert -ResourceGroupName "Default-activityLogAlerts" -Name "alert1"
```

This command lists one (a list with a single element) activity log alert.

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
The name of the activity log alert.

```yaml
Type: String
Parameter Sets: GetByNameAndResourceGroup
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group where the alert resource exists.
If Name is not null or empty, this parameter must contain and non empty string.

```yaml
Type: String
Parameter Sets: GetByNameAndResourceGroup
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: GetByResourceGroup
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

### <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Insights.OutputClasses.PSActivityLogAlertResource]

### None

## NOTES

## RELATED LINKS

[Set-AzureRmActivityLogAlert](./Set-AzureRmActivityLogAlert.md)

[Update-AzureRmActivityLogAlert](./Update-AzureRmActivityLogAlert.md)

[Remove-AzureRmActivityLogAlert](./Remove-AzureRmActivityLogAlert.md)

[New-AzureRmActionGroup](./New-AzureRmActionGroup.md)

[New-AzureRmActivityLogAlertCondition](./Get-AzureRmActivityLogAlertCondition.md)
