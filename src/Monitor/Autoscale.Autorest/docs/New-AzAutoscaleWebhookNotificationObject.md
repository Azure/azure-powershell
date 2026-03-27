---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-azautoscalewebhooknotificationobject
schema: 2.0.0
---

# New-AzAutoscaleWebhookNotificationObject

## SYNOPSIS
Create an in-memory object for WebhookNotification.

## SYNTAX

```
New-AzAutoscaleWebhookNotificationObject [-Property <IWebhookNotificationProperties>] [-ServiceUri <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for WebhookNotification.

## EXAMPLES

### Example 1: Create webhook notification object
```powershell
New-AzAutoscaleWebhookNotificationObject -Property @{} -ServiceUri "http://myservice.com"
```

Create webhook notification object

## PARAMETERS

### -Property
a property bag of settings.
This value can be empty.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Models.IWebhookNotificationProperties
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceUri
the service address to receive the notification.

```yaml
Type: System.String
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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Models.WebhookNotification

## NOTES

## RELATED LINKS

