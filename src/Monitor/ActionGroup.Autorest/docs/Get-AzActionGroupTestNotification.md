---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/get-azactiongrouptestnotification
schema: 2.0.0
---

# Get-AzActionGroupTestNotification

## SYNOPSIS
Get the test notifications by the notification id

## SYNTAX

### Get (Default)
```
Get-AzActionGroupTestNotification -ActionGroupName <String> -NotificationId <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityActionGroup
```
Get-AzActionGroupTestNotification -ActionGroupInputObject <IActionGroupIdentity> -NotificationId <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the test notifications by the notification id

## EXAMPLES

### Example 1: Get test result of specified action group
```powershell
Get-AzActionGroupTestNotification -ActionGroupName actiongroup1 -ResourceGroupName monitor-action -NotificationId 11000009464546
```

```output
ActionDetail              : {{
                              "MechanismType": "Sms",
                              "Name": "user2_-SMSAction-",
                              "Status": "Succeeded",
                              "SubState": "Default",
                              "SendTime": "2023-10-20T07:39:58.3543022+00:00"
                            }}
CompletedTime             : 2023-10-20T07:40:30.5419846+00:00
ContextNotificationSource : Microsoft.Insights/TestNotification
ContextType               : Microsoft.Insights/ServiceHealth
CreatedTime               : 2023-10-20T07:39:54.4913346+00:00
State                     : Complete
```

This command gets the test notifications by specified action group and notification id.

## PARAMETERS

### -ActionGroupInputObject
Identity Parameter
To construct, see NOTES section for ACTIONGROUPINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.IActionGroupIdentity
Parameter Sets: GetViaIdentityActionGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ActionGroupName
The name of the action group.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -NotificationId
The notification id

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.IActionGroupIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.ITestNotificationDetailsResponse

## NOTES

## RELATED LINKS

