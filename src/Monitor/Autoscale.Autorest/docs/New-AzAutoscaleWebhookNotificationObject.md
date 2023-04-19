---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-AzAutoscaleWebhookNotificationObject
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

### Example 1: Create webhook nofitication object
```powershell
New-AzAutoscaleWebhookNotificationObject -Property @{} -ServiceUri "http://myservice.com"
```

Create webhook nofitication object

## PARAMETERS

### -Property
a property bag of settings.
This value can be empty.
To construct, see NOTES section for PROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Models.Api20221001.IWebhookNotificationProperties
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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Models.Api20221001.WebhookNotification

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`PROPERTY <IWebhookNotificationProperties>`: a property bag of settings. This value can be empty.
  - `[(Any) <String>]`: This indicates any property can be added to this object.

## RELATED LINKS

