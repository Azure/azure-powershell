---
external help file:
Module Name: Az.Communication
online version: https://learn.microsoft.com/powershell/module/az.communication/send-azemailservicedataemail
schema: 2.0.0
---

# Send-AzEmailServicedataEmail

## SYNOPSIS
Queues an email message to be sent to one or more recipients

## SYNTAX

### Send (Default)
```
Send-AzEmailServicedataEmail -Endpoint <String> -Message <IEmailMessage> [-ClientRequestId <String>]
 [-OperationId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### SendExpanded
```
Send-AzEmailServicedataEmail -Endpoint <String> -ContentSubject <String> -RecipientTo <IEmailAddress[]>
 -SenderAddress <String> [-ClientRequestId <String>] [-OperationId <String>]
 [-Attachment <IEmailAttachment[]>] [-ContentHtml <String>] [-ContentPlainText <String>] [-Header <Hashtable>]
 [-RecipientBcc <IEmailAddress[]>] [-RecipientCc <IEmailAddress[]>] [-ReplyTo <IEmailAddress[]>]
 [-UserEngagementTrackingDisabled] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### SendViaJsonFilePath
```
Send-AzEmailServicedataEmail -Endpoint <String> -JsonFilePath <String> [-ClientRequestId <String>]
 [-OperationId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### SendViaJsonString
```
Send-AzEmailServicedataEmail -Endpoint <String> -JsonString <String> [-ClientRequestId <String>]
 [-OperationId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Queues an email message to be sent to one or more recipients

## EXAMPLES

### Example 1: Queues an email message to be sent to one or more recipients
```powershell
$emailRecipientTo = @(
   @{
        Address = "abc@contoso.com"
        DisplayName = "abc"
    }
)

$message = @{
	ContentSubject = "Test Email"
	RecipientTo = @($emailRecipientTo)  # Array of email address objects
	SenderAddress = 'info@contoso.com'	
	ContentPlainText = "This is the first email from ACS - HTML"	
}

Send-AzEmailServicedataEmail -Message $Message -endpoint "https://contoso.unitedstates.communication.azure.com"
```

```output
AdditionalInfo    :
Code              :
Detail            :
Id                : 1111c0de-899f-5cce-acb5-3ec493af3800
Message           :
ResourceGroupName :
RetryAfter        :
Status            : Succeeded
Target            : 
```

Queues an email message to be sent to one or more recipients, above is the example with only required fields.

### Example 2: Queues an email message to be sent to one or more recipients
```powershell

$emailRecipientTo = @(
   @{
        Address = "abc@contoso.com"
        DisplayName = "abc"
    },
   @{
        Address = "def@contoso.com"
        DisplayName = "def"
    }
)

$fileBytes = [System.IO.File]::ReadAllBytes("<file path>")

$emailAttachment = @(
	@{
		ContentInBase64 = $fileBytes
		ContentType = "<text/plain>"
		Name = "<test.txt>"
	}
)

$headers = @{
    "Key1" = "Value1"
    "Key2" = "Value2"
	"Importance" = "high"
}

$emailRecipientBcc = @(
   @{
        Address = "abc@contoso.com"
        DisplayName = "abc"
    }
)

$emailRecipientCc = @(
   @{
        Address = "abc@contoso.com"
        DisplayName = "abc"
    }
)

$emailRecipientReplyTo = @(
   @{
        Address = "abc@contoso.com"
        DisplayName = "abc"
    }
)

$message = @{
	ContentSubject = "Test Email"
	RecipientTo = @($emailRecipientTo)  # Array of email address objects
	SenderAddress = 'info@contoso.com'
	Attachment = @($emailAttachment) # Array of attachments
	ContentHtml = "<html><head><title>Enter title</title></head><body><h1>This is the first email from ACS - HTML</h1></body></html>"
	ContentPlainText = "This is the first email from ACS - HTML"
	Header = $headers  # Importance = high/medium/low or X-Priority = 2/3/4  
	RecipientBcc = @($emailRecipientBcc) # Array of email address objects
	RecipientCc = @($emailRecipientCc) # Array of email address objects
	ReplyTo = @($emailRecipientReplyTo) # Array of email address objects
	UserEngagementTrackingDisabled = $true
}

Send-AzEmailServicedataEmail -Message $Message -endpoint "https://contoso.unitedstates.communication.azure.com"
```

```output
AdditionalInfo    :
Code              :
Detail            :
Id                : 1111c0de-899f-5cce-acb5-3ec493af3801
Message           :
ResourceGroupName :
RetryAfter        :
Status            : Succeeded
Target            : 
```

Queues an email message to be sent to one or more recipients, above is the example with all the fields.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.EmailServicedata.Models.IEmailAttachment[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.EmailServicedata.Models.IEmailMessage
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
Type: Microsoft.Azure.PowerShell.Cmdlets.EmailServicedata.Models.IEmailAddress[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.EmailServicedata.Models.IEmailAddress[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.EmailServicedata.Models.IEmailAddress[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.EmailServicedata.Models.IEmailAddress[]
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

### Microsoft.Azure.PowerShell.Cmdlets.EmailServicedata.Models.IEmailMessage

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EmailServicedata.Models.IEmailSendResult

## NOTES

## RELATED LINKS

