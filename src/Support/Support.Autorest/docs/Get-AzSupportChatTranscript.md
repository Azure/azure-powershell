---
external help file:
Module Name: Az.Support
online version: https://learn.microsoft.com/powershell/module/az.support/get-azsupportchattranscript
schema: 2.0.0
---

# Get-AzSupportChatTranscript

## SYNOPSIS
Returns chatTranscript details for a support ticket under a subscription.

## SYNTAX

### List (Default)
```
Get-AzSupportChatTranscript -SupportTicketName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzSupportChatTranscript -Name <String> -SupportTicketName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSupportChatTranscript -InputObject <ISupportIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentitySupportTicket
```
Get-AzSupportChatTranscript -Name <String> -SupportTicketInputObject <ISupportIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Returns chatTranscript details for a support ticket under a subscription.

## EXAMPLES

### Example 1: Get List of chat transcripts at subscription level
```powershell
 Get-AzSupportChatTranscript -SupportTicketName "58cf91d7-bedfb285-617ecf73-d627-4bfd-9298-5950da2170b7"
```

```output
Name                                 StartTime
----                                 ---------
595df7b4-167f-4f3e-8292-f0ba2b8a53f9 8/11/2023 7:27:49 PM
f8b45cd6-a8ec-40e2-b846-a28b848553cf 8/11/2023 7:52:44 PM
```

Lists all chat transcripts for a support ticket under subscription

### Example 2: Get single chat transcript at subscription level
```powershell
 Get-AzSupportChatTranscript -SupportTicketName "58cf91d7-bedfb285-617ecf73-d627-4bfd-9298-5950da2170b7" -Name "595df7b4-167f-4f3e-8292-f0ba2b8a53f9"
```

```output
Id                           : /subscriptions/76cb77fa-8b17-4eab-9493-b65dace99813/providers/Microsoft.Support/supportT
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

Returns chatTranscript details for a support ticket under a subscription.

## PARAMETERS

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

### -Name
ChatTranscript name.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentitySupportTicket
Aliases: ChatTranscriptName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
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

