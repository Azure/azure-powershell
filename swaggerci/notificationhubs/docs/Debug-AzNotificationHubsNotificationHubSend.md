---
external help file:
Module Name: Az.NotificationHubs
online version: https://docs.microsoft.com/en-us/powershell/module/az.notificationhubs/debug-aznotificationhubsnotificationhubsend
schema: 2.0.0
---

# Debug-AzNotificationHubsNotificationHubSend

## SYNOPSIS
test send a push notification

## SYNTAX

### DebugExpanded (Default)
```
Debug-AzNotificationHubsNotificationHubSend -NamespaceName <String> -NotificationHubName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Debug
```
Debug-AzNotificationHubsNotificationHubSend -NamespaceName <String> -NotificationHubName <String>
 -ResourceGroupName <String> -Parameter <IAny> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DebugViaIdentity
```
Debug-AzNotificationHubsNotificationHubSend -InputObject <INotificationHubsIdentity> -Parameter <IAny>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DebugViaIdentityExpanded
```
Debug-AzNotificationHubsNotificationHubSend -InputObject <INotificationHubsIdentity>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
test send a push notification

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NotificationHubs.Models.INotificationHubsIdentity
Parameter Sets: DebugViaIdentity, DebugViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NamespaceName
The namespace name.

```yaml
Type: System.String
Parameter Sets: Debug, DebugExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NotificationHubName
The notification hub name.

```yaml
Type: System.String
Parameter Sets: Debug, DebugExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Any object

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NotificationHubs.Models.IAny
Parameter Sets: Debug, DebugViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Debug, DebugExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Debug, DebugExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NotificationHubs.Models.IAny

### Microsoft.Azure.PowerShell.Cmdlets.NotificationHubs.Models.INotificationHubsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NotificationHubs.Models.Api20170401.IDebugSendResponse

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <INotificationHubsIdentity>: Identity Parameter
  - `[AuthorizationRuleName <String>]`: Authorization Rule Name.
  - `[Id <String>]`: Resource identity path
  - `[NamespaceName <String>]`: The namespace name.
  - `[NotificationHubName <String>]`: The notification hub name.
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[SubscriptionId <String>]`: Gets subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

## RELATED LINKS

