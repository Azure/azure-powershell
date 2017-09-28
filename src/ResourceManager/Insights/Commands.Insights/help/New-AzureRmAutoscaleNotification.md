---
external help file: Microsoft.Azure.Commands.Insights.dll-Help.xml
ms.assetid: B5B5F494-D912-40D0-99E2-A62FAACA3EC9
online version: 
schema: 2.0.0
---

# New-AzureRmAutoscaleNotification

## SYNOPSIS
Creates an Autoscale email notification.

## SYNTAX

```
New-AzureRmAutoscaleNotification [[-Webhooks] <WebhookNotification[]>] [[-CustomEmails] <String[]>]
 [-SendEmailToSubscriptionAdministrator] [-SendEmailToSubscriptionCoAdministrators] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmAutoscaleNotification** cmdlet creates an email notification for Autoscale.

## EXAMPLES

### Example 1: Create an Autoscale email notification
```
PS C:\>New-AzureRmAutoscaleNotification -CustomEmails "pattif@contoso.com, davidchew@contoso.net"
```

This command creates an Autosacale email notification for two specified addresses.

### Example 2: Create an Autoscale email notification for the subscription administrator
```
PS C:\>New-AzureRmAutoscaleNotification -SendEmailToSubscriptionAdministrator
```

This command creates an Autosacale email notification for the subscription administrator.

## PARAMETERS

### -CustomEmails
Specifies a comma-separated list of email addresses.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases: 

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SendEmailToSubscriptionAdministrator
Indicates that this operation sends an email notification to the subscription administrator.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SendEmailToSubscriptionCoAdministrators
Indicates that this operation sends an email notification to the subscription co-administrators.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Webhooks
Specifies a comma-separated list of Autoscale webhooks.

```yaml
Type: WebhookNotification[]
Parameter Sets: (All)
Aliases: 

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.Management.Monitor.Management.Models.AutoscaleNotification

## NOTES

## RELATED LINKS

[New-AzureRmAutoscaleWebhook](./New-AzureRmAutoscaleWebhook.md)


