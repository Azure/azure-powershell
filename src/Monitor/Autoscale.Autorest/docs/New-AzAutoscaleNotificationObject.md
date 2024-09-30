---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-AzAutoscaleNotificationObject
schema: 2.0.0
---

# New-AzAutoscaleNotificationObject

## SYNOPSIS
Create an in-memory object for AutoscaleNotification.

## SYNTAX

```
New-AzAutoscaleNotificationObject [-EmailCustomEmail <String[]>]
 [-EmailSendToSubscriptionAdministrator <Boolean>] [-EmailSendToSubscriptionCoAdministrator <Boolean>]
 [-Webhook <IWebhookNotification[]>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AutoscaleNotification.

## EXAMPLES

### Example 1: Create web hook notification object
```powershell
$webhook1=New-AzAutoscaleWebhookNotificationObject -Property @{} -ServiceUri "http://myservice.com"
New-AzAutoscaleNotificationObject -EmailCustomEmail "gu@ms.com" -EmailSendToSubscriptionAdministrator $true -EmailSendToSubscriptionCoAdministrator $true -Webhook $webhook1
```

Create web hook notification object

## PARAMETERS

### -EmailCustomEmail
the custom e-mails list.
This value can be null or empty, in which case this attribute will be ignored.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EmailSendToSubscriptionAdministrator
a value indicating whether to send email to subscription administrator.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EmailSendToSubscriptionCoAdministrator
a value indicating whether to send email to subscription co-administrators.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Webhook
the collection of webhook notifications.
To construct, see NOTES section for WEBHOOK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Models.Api20221001.IWebhookNotification[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Models.Api20221001.AutoscaleNotification

## NOTES

## RELATED LINKS

