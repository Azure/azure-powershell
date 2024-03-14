---
external help file:
Module Name: Az.AppComplianceAutomation
online version: https://learn.microsoft.com/powershell/module/az.appComplianceAutomation/update-azacatwebhook
schema: 2.0.0
---

# Update-AzAcatWebhook

## SYNOPSIS
Update an exiting AppComplianceAutomation webhook.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzAcatWebhook -Name <String> -ReportName <String> [-ContentType <String>] [-Disable]
 [-EnableSslVerification <EnableSslVerification>] [-Event <NotificationEvent[]>] [-PayloadUrl <String>]
 [-Secret <SecureString>] [-TriggerMode <SendAllEvents>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Update
```
Update-AzAcatWebhook -Name <String> -Parameter <IWebhookResource> -ReportName <String>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update an exiting AppComplianceAutomation webhook.

## EXAMPLES

### Example 1: Update certain fields of a webhook under a report.
```powershell
$secret = ConvertTo-SecureString "testSecret" -AsPlainText
Update-AzAcatWebhook -Name "test-webhook" -ReportName "test-report" -TriggerMode "all" -PayloadUrl "https://example.com" -Secret $secret
```

```output
Name          SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastM
                                                                                                        odifiedBy
----          -------------------  ------------------- ----------------------- ------------------------ ---------------
test-webhook  7/27/2023 9:14:20 AM                     User                    7/31/2023 7:50:04 AM
```

Update certain fields of a webhook under a report.

### Example 2: Update all fields of a webhook under a report.
```powershell
$secret = ConvertTo-SecureString "testSecret" -AsPlainText
Update-AzAcatWebhook -Name "test-webhook" -ReportName "test-report" -EnableSslVerification "true"  -Disable -TriggerMode "all" -PayloadUrl "https://example.com" -ContentType "application/json" -Secret $secret
```

```output
Name          SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastM
                                                                                                        odifiedBy
----          -------------------  ------------------- ----------------------- ------------------------ ---------------
test-webhook  7/27/2023 9:14:20 AM                     User                    7/31/2023 7:50:04 AM
```

Update all fields of a webhook under a report.

### Example 3: Update a webhook under a report use parameter object.
```powershell
$secret = ConvertTo-SecureString "testSecret" -AsPlainText
$param = New-AzAcatWebhookResourceObject -TriggerMode "all" -PayloadUrl "https://example.com" -Secret $secret
$param | Update-AzAcatWebhook -Name "test-webhook" -ReportName "test-report"
```

```output
Name          SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastM
                                                                                                        odifiedBy
----          -------------------  ------------------- ----------------------- ------------------------ ---------------
test-webhook  7/27/2023 9:14:20 AM                     User                    7/31/2023 7:50:04 AM
```

Update a webhook under a report use parameter object.

## PARAMETERS

### -ContentType
content type

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Disable
whether to disable webhook

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Webhook Name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: WebhookName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
A class represent a AppComplianceAutomation webhook resource update properties.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.IWebhookResource
Parameter Sets: Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PayloadUrl
webhook payload url

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReportName
Report Name.

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

### -Secret
webhook secret token.
If not set, this field value is null; otherwise, please set a string value.

```yaml
Type: System.Security.SecureString
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
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

### Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.IWebhookResource

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppComplianceAutomation.Models.Api20230215Preview.IWebhookResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


PARAMETER <IWebhookResource>: A class represent a AppComplianceAutomation webhook resource update properties.
  - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[SystemDataLastModifiedAt <DateTime?>]`: The timestamp of resource last modification (UTC)
  - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[SystemDataLastModifiedByType <CreatedByType?>]`: The type of identity that last modified the resource.
  - `[ContentType <ContentType?>]`: content type
  - `[EnableSslVerification <EnableSslVerification?>]`: whether to enable ssl verification
  - `[Event <NotificationEvent[]>]`: under which event notification should be sent.
  - `[PayloadUrl <String>]`: webhook payload url
  - `[SendAllEvent <SendAllEvents?>]`: whether to send notification under any event.
  - `[Status <WebhookStatus?>]`: Webhook status.
  - `[UpdateWebhookKey <UpdateWebhookKey?>]`: whether to update webhookKey.
  - `[WebhookKey <String>]`: webhook secret token. If not set, this field value is null; otherwise, please set a string value.

## RELATED LINKS

