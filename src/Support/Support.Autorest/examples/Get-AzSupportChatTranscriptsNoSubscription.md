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

