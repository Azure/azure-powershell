---
external help file:
Module Name: Az.AppComplianceAutomation
online version: https://learn.microsoft.com/powershell/module/az.appComplianceAutomation/new-azacatwebhookresourceobject
schema: 2.0.0
---

# New-AzAcatWebhookResourceObject

## SYNOPSIS
Create an in-memory object for WebhookResource.

## SYNTAX

```
New-AzAcatWebhookResourceObject [-ContentType <String>] [-Disable]
 [-EnableSslVerification <EnableSslVerification>] [-Event <NotificationEvent[]>] [-PayloadUrl <String>]
 [-Secret <SecureString>] [-TriggerMode <SendAllEvents>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for WebhookResource.

## EXAMPLES

### Example 1: Create a WebhookResource object with default values.
```powershell
$secret = ConvertTo-SecureString "testSecret" -AsPlainText
New-AzAcatWebhookResourceObject -TriggerMode "all" -PayloadUrl "https://example.com" -Secret $secret
```

```output
Name SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
---- -------------------  ------------------- ----------------------- ------------------------ ------------------------
     1/1/0001 12:00:00 AM                                             1/1/0001 12:00:00 AM
```

Create a WebhookResource object with default values.

### Example 2: Create a WebhookResource object.
```powershell
$secret = ConvertTo-SecureString "testSecret" -AsPlainText
New-AzAcatWebhookResourceObject -EnableSslVerification "true"  -Disable -TriggerMode "all" -PayloadUrl "https://example.com" -ContentType "application/json" -Secret $secret
```

```output
Name SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
---- -------------------  ------------------- ----------------------- ------------------------ ------------------------
     1/1/0001 12:00:00 AM                                             1/1/0001 12:00:00 AM
```

Create a WebhookResource object.

## PARAMETERS

### -ContentType
content type

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

### -Disable
whether to disable webhook

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableSslVerification
whether to enable ssl verification

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Support.EnableSslVerification
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Event
under which event notification should be sent.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Support.NotificationEvent[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PayloadUrl
webhook payload url

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

### -Secret
webhook secret token.
If not set, this field value is null; otherwise, please set a string value.

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TriggerMode
whether to send notification under any event.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Support.SendAllEvents
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

### Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.IWebhookResource

## NOTES

ALIASES

## RELATED LINKS

