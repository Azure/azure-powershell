---
external help file:
Module Name: Az.Communication
online version: https://learn.microsoft.com/powershell/module/az.communication/send-azcommunicationservicesemail
schema: 2.0.0
---

# Send-AzCommunicationServicesEmail

## SYNOPSIS
Queues an email message to be sent to one or more recipients

## SYNTAX

### Send (Default)
```
Send-AzCommunicationServicesEmail -Endpoint <String> -Message <IEmailMessage> [-ClientRequestId <String>]
 [-OperationId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### SendExpanded
```
Send-AzCommunicationServicesEmail -Endpoint <String> -ContentSubject <String> -RecipientTo <IEmailAddress[]>
 -SenderAddress <String> [-ClientRequestId <String>] [-OperationId <String>]
 [-Attachment <IEmailAttachment[]>] [-ContentHtml <String>] [-ContentPlainText <String>] [-Header <Hashtable>]
 [-RecipientBcc <IEmailAddress[]>] [-RecipientCc <IEmailAddress[]>] [-ReplyTo <IEmailAddress[]>]
 [-UserEngagementTrackingDisabled] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### SendViaJsonFilePath
```
Send-AzCommunicationServicesEmail -Endpoint <String> -JsonFilePath <String> [-ClientRequestId <String>]
 [-OperationId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### SendViaJsonString
```
Send-AzCommunicationServicesEmail -Endpoint <String> -JsonString <String> [-ClientRequestId <String>]
 [-OperationId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Queues an email message to be sent to one or more recipients

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -AsJob
Run the command as a job

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

### -Attachment
List of attachments.
Please note that we limit the total size of an email request (which includes attachments) to 10MB.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CommunicationServicesEmail.Models.IEmailAttachment[]
Parameter Sets: SendExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClientRequestId
Tracking ID sent with the request to help with debugging.

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

### -ContentHtml
Html version of the email message.

```yaml
Type: System.String
Parameter Sets: SendExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContentPlainText
Plain text version of the email message.

```yaml
Type: System.String
Parameter Sets: SendExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContentSubject
Subject of the email message

```yaml
Type: System.String
Parameter Sets: SendExpanded
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

### -Endpoint
The communication resource, for example https://my-resource.communication.azure.com

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

### -Header
Custom email headers to be passed.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: SendExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Send operation

```yaml
Type: System.String
Parameter Sets: SendViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Send operation

```yaml
Type: System.String
Parameter Sets: SendViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Message
Message payload for sending an email

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CommunicationServicesEmail.Models.IEmailMessage
Parameter Sets: Send
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -OperationId
This is the ID provided by the customer to identify the long running operation.
If an ID is not provided by the customer, the service will generate one.

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

### -RecipientBcc
Email BCC recipients

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CommunicationServicesEmail.Models.IEmailAddress[]
Parameter Sets: SendExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecipientCc
Email CC recipients

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CommunicationServicesEmail.Models.IEmailAddress[]
Parameter Sets: SendExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecipientTo
Email To recipients

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CommunicationServicesEmail.Models.IEmailAddress[]
Parameter Sets: SendExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReplyTo
Email addresses where recipients' replies will be sent to.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CommunicationServicesEmail.Models.IEmailAddress[]
Parameter Sets: SendExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SenderAddress
Sender email address from a verified domain.

```yaml
Type: System.String
Parameter Sets: SendExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserEngagementTrackingDisabled
Indicates whether user engagement tracking should be disabled for this request if the resource-level user engagement tracking setting was already enabled in the control plane.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: SendExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.CommunicationServicesEmail.Models.IEmailMessage

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CommunicationServicesEmail.Models.IEmailSendResult

## NOTES

## RELATED LINKS

