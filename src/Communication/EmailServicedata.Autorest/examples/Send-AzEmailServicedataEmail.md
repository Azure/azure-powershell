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

