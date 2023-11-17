---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-azactiongroupwebhookreceiverobject
schema: 2.0.0
---

# New-AzActionGroupWebhookReceiverObject

## SYNOPSIS
Create an in-memory object for WebhookReceiver.

## SYNTAX

```
New-AzActionGroupWebhookReceiverObject -Name <String> -ServiceUri <String> [-IdentifierUri <String>]
 [-ObjectId <String>] [-TenantId <String>] [-UseAadAuth <Boolean>] [-UseCommonAlertSchema <Boolean>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for WebhookReceiver.

## EXAMPLES

### Example 1: create action group webhook receiver with aad auth
```powershell
New-AzActionGroupWebhookReceiverObject -Name "sample webhook" -ServiceUri "http://www.example.com/webhook1" -IdentifierUri "http://someidentifier/d7811ba3-7996-4a93-99b6-6b2f3f355f8a" -ObjectId "d3bb868c-fe44-452c-aa26-769a6538c808" -TenantId 68a4459a-ccb8-493c-b9da-dd30457d1b84 -UseAadAuth $true -UseCommonAlertSchema $true
```

```output
IdentifierUri        : http://someidentifier/d7811ba3-7996-4a93-99b6-6b2f3f355f8a
Name                 : sample webhook
ObjectId             : d3bb868c-fe44-452c-aa26-769a6538c808
ServiceUri           : http://www.example.com/webhook1
TenantId             : 68a4459a-ccb8-493c-b9da-dd30457d1b84
UseAadAuth           : True
UseCommonAlertSchema : True
```

This command creates action group webhook receiver object.

### Example 2: create minimum action group webhook receiver
```powershell
New-AzActionGroupWebhookReceiverObject -Name "sample webhook" -ServiceUri "http://www.example.com/webhook2"                                                        
```

```output
IdentifierUri        : 
Name                 : sample webhook
ObjectId             : 
ServiceUri           : http://www.example.com/webhook2
TenantId             : 
UseAadAuth           : 
UseCommonAlertSchema : 
```

This command creates action group email receiver object.

## PARAMETERS

### -IdentifierUri
Indicates the identifier uri for aad auth.

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

### -Name
The name of the webhook receiver.
Names must be unique across all receivers within an action group.

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

### -ObjectId
Indicates the webhook app object Id for aad auth.

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

### -ServiceUri
The URI where webhooks should be sent.

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

### -TenantId
Indicates the tenant id for aad auth.

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

### -UseAadAuth
Indicates whether or not use AAD authentication.

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

### -UseCommonAlertSchema
Indicates whether to use common alert schema.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.WebhookReceiver

## NOTES

## RELATED LINKS

