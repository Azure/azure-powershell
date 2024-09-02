---
external help file:
Module Name: Az.Support
online version: https://learn.microsoft.com/powershell/module/az.support/get-azsupportchattranscriptsnosubscription
schema: 2.0.0
---

# Get-AzSupportChatTranscriptsNoSubscription

## SYNOPSIS
Returns chatTranscript details for a no subscription support ticket.

## SYNTAX

### List (Default)
```
Get-AzSupportChatTranscriptsNoSubscription -SupportTicketName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzSupportChatTranscriptsNoSubscription -ChatTranscriptName <String> -SupportTicketName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSupportChatTranscriptsNoSubscription -InputObject <ISupportIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentitySupportTicket
```
Get-AzSupportChatTranscriptsNoSubscription -ChatTranscriptName <String>
 -SupportTicketInputObject <ISupportIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Returns chatTranscript details for a no subscription support ticket.

## EXAMPLES

### Example 1: List chat transcripts under a no subscription support ticket
```powershell
Get-AzSupportChatTranscriptsNoSubscription -SupportTicketName test12345
```

```output
Name                                 StartTime
----                                 ---------
595df7b4-167f-4f3e-8292-f0ba2b8a53f9 8/11/2023 7:27:49 PM
f8b45cd6-a8ec-40e2-b846-a28b848553cf 8/11/2023 7:52:44 PM
```

List chat transcripts under a no subscription support ticket

### Example 2: Get details of a chat transcript under a no subscription support ticket
```powershell
Get-AzSupportChatTranscriptsNoSubscription -SupportTicketName test12345 -Name 595df7b4-167f-4f3e-8292-f0ba2b8a53f9
```

```output
Id                           : /providers/Microsoft.Support/supportT
                               ickets/58cf91d7-bedfb285-617ecf73-d627-4bfd-9298-5950da2170b7/chatTranscripts/595df7b4-1
                               67f-4f3e-8292-f0ba2b8a53f9
Message                      : {{
                                 "contentType": "text",
                                 "communicationDirection": "Inbound",
                                 "sender": "",
                                 "body": "Hey",
                                 "createdDate": "2023-08-11T19:19:33.0000000Z"
                               }, {
                                 "contentType": "text",
                                 "communicationDirection": "Outbound",
                                 "sender": "Aditi Takle",
                                 "body": "hi",
                                 "createdDate": "2023-08-11T19:19:38.0000000Z"
                               }, {
                                 "contentType": "text",
                                 "communicationDirection": "Outbound",
                                 "sender": "Damian Spoltore",
                                 "body": "hi Aditi, I\u0027m Damian",
                                 "createdDate": "2023-08-11T19:24:19.0000000Z"
                               }, {
                                 "contentType": "text",
                                 "communicationDirection": "Outbound",
                                 "sender": "Damian Spoltore",
                                 "body": "I was entering to test",
                                 "createdDate": "2023-08-11T19:24:24.0000000Z"
                               }}
Name                         : 595df7b4-167f-4f3e-8292-f0ba2b8a53f9
ResourceGroupName            :
StartTime                    : 8/11/2023 7:27:49 PM
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Support/chatTranscripts
```

Get details of a chat transcript under a no subscription support ticket

## PARAMETERS

### -ChatTranscriptName
ChatTranscript name.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentitySupportTicket
Aliases: Name

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ISupportIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SupportTicketInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ISupportIdentity
Parameter Sets: GetViaIdentitySupportTicket
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SupportTicketName
Support ticket name.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ISupportIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Support.Models.IChatTranscriptDetails

## NOTES

## RELATED LINKS

