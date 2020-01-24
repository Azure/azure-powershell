---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Support.dll-Help.xml
Module Name: Az.Support
online version:
schema: 2.0.0
---

# Get-AzSupportTicketCommunication

## SYNOPSIS
Get support ticket communications.

## SYNTAX

### GetByNameParameterSet (Default)
```
Get-AzSupportTicketCommunication -SupportTicketName <String> [-Name <String>] [-Filter <String>]
 [-First <UInt32>] [-Skip <UInt32>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByParentObjectParameterSet
```
Get-AzSupportTicketCommunication [-Name <String>] -SupportTicketObject <PSSupportTicket> [-Filter <String>]
 [-First <UInt32>] [-Skip <UInt32>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Gets communications for a support ticket. It will retrieve all the communications for a ticket if you do not specify any other parameters. You can also filter the communications by CreatedDate or CommunicationType using the Filter parameter. Here are some examples of filter values that you can specify.


| Scenario                                                        | Filter                                                     |
|-----------------------------------------------------------------|------------------------------------------------------------|
| Get Web communications                                          | "CommunicationType eq 'Web'"                               |
| Get Phone communications                                        | "CommunicationType eq 'Phone'"                             |
| Get communications that were created on or after 20th Dec, 2019 | "CreatedDate ge 2019-12-20"                                |
| Get communications that were created after 20th Dec, 2019       | "CreatedDate gt 2019-12-20"                                |
| Gets Web communications created after 20th Dec, 2019            | "CreatedDate gt 2019-12-20 and CommunicationType eq 'Web'" |


This cmdlet supports paging via First and Skip parameters.

You can also retrieve a single support ticket communication by specifying the communication name. 

## EXAMPLES

### Example 1: Retrieve all communications for a support ticket
```powershell
PS C:\> Get-AzSupportTicketCommunication -SupportTicketName test1

Id                     : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1/communications/testmessage1
Name                   : testmessage1
Type                   : Microsoft.Support/communications
CommunicationType      : Web
CommunicationDirection : Inbound
Sender                 : user@contoso.com
Subject                : test subject 1
Body                   : test message 1
CreatedDate            : 1/2/2020 1:15:49 AM

Id                     : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1/communications/testmessage2
Name                   : testmessage2
Type                   : Microsoft.Support/communications
CommunicationType      : Web
CommunicationDirection : Inbound
Sender                 : user@contoso.com
Subject                : test subject 2
Body                   : test message 2
CreatedDate            : 1/2/2020 1:16:05 AM
```

### Example 2: Retrieve a communication by it's name for a support ticket
```powershell
PS C:\> Get-AzSupportTicketCommunication -SupportTicketName test1 -Name testmessage1

Id                     : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1/communications/testmessage1
Name                   : testmessage1
Type                   : Microsoft.Support/communications
CommunicationType      : Web
CommunicationDirection : Inbound
Sender                 : user@contoso.com
Subject                : test subject 1
Body                   : test message 1
CreatedDate            : 1/2/2020 1:15:49 AM
```

### Example 3: Retrieve first 2 communications for a support ticket
```powershell
PS C:\> Get-AzSupportTicketCommunication -SupportTicketName test1 -First 2

Id                     : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1/communications/testmessage1
Name                   : testmessage1
Type                   : Microsoft.Support/communications
CommunicationType      : Web
CommunicationDirection : Inbound
Sender                 : user@contoso.com
Subject                : test subject 1
Body                   : test message 1
CreatedDate            : 1/2/2020 1:15:49 AM

Id                     : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1/communications/testmessage2
Name                   : testmessage2
Type                   : Microsoft.Support/communications
CommunicationType      : Web
CommunicationDirection : Inbound
Sender                 : user@contoso.com
Subject                : test subject 2
Body                   : test message 2
CreatedDate            : 1/2/2020 1:16:05 AM
```

### Example 4: Retrieve next 2 communications after skipping first 2 communications for a support ticket
```powershell
PS C:\> Get-AzSupportTicketCommunication -SupportTicketName test1 -Skip 2 -First 2

Id                     : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1/communications/testmessage3
Name                   : testmessage3
Type                   : Microsoft.Support/communications
CommunicationType      : Web
CommunicationDirection : Inbound
Sender                 : user@contoso.com
Subject                : test subject 1
Body                   : test message 1
CreatedDate            : 1/2/2020 1:15:49 AM

Id                     : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1/communications/testmessage4
Name                   : testmessage4
Type                   : Microsoft.Support/communications
CommunicationType      : Web
CommunicationDirection : Inbound
Sender                 : user@contoso.com
Subject                : test subject 2
Body                   : test message 2
CreatedDate            : 1/2/2020 1:16:05 AM
```

### Example 5: Retrieve all Web communications for a support ticket
```powershell
PS C:\> Get-AzSupportTicketCommunication -SupportTicketName test1 -Filter "CommunicationType eq 'Web'"

Id                     : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1/communications/testmessage3
Name                   : testmessage3
Type                   : Microsoft.Support/communications
CommunicationType      : Web
CommunicationDirection : Inbound
Sender                 : user@contoso.com
Subject                : test subject 1
Body                   : test message 1
CreatedDate            : 1/2/2020 1:15:49 AM

Id                     : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1/communications/testmessage4
Name                   : testmessage4
Type                   : Microsoft.Support/communications
CommunicationType      : Web
CommunicationDirection : Inbound
Sender                 : user@contoso.com
Subject                : test subject 2
Body                   : test message 2
CreatedDate            : 1/2/2020 1:16:05 AM
```

### Example 6: Retrieve all communications created on or after Dec 20th, 2019 for a support ticket
```powershell
PS C:\> Get-AzSupportTicketCommunication -SupportTicketName test1 -Filter "CreatedDate ge 2019-12-20"

Id                     : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1/communications/testmessage3
Name                   : testmessage3
Type                   : Microsoft.Support/communications
CommunicationType      : Web
CommunicationDirection : Inbound
Sender                 : user@contoso.com
Subject                : test subject 1
Body                   : test message 1
CreatedDate            : 1/2/2020 1:15:49 AM

Id                     : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1/communications/testmessage4
Name                   : testmessage4
Type                   : Microsoft.Support/communications
CommunicationType      : Web
CommunicationDirection : Inbound
Sender                 : user@contoso.com
Subject                : test subject 2
Body                   : test message 2
CreatedDate            : 1/2/2020 1:16:05 AM
```

### Example 7: Retrieve all Web communications created on or after Dec 20th, 2019 for a support ticket
```powershell
PS C:\> Get-AzSupportTicketCommunication -SupportTicketName test1 -Filter "CommunicationType eq 'Web' and CreatedDate ge 2019-12-20"

Id                     : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1/communications/testmessage3
Name                   : testmessage3
Type                   : Microsoft.Support/communications
CommunicationType      : Web
CommunicationDirection : Inbound
Sender                 : user@contoso.com
Subject                : test subject 1
Body                   : test message 1
CreatedDate            : 1/2/2020 1:15:49 AM

Id                     : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1/communications/testmessage4
Name                   : testmessage4
Type                   : Microsoft.Support/communications
CommunicationType      : Web
CommunicationDirection : Inbound
Sender                 : user@contoso.com
Subject                : test subject 2
Body                   : test message 2
CreatedDate            : 1/2/2020 1:16:05 AM
```

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
Filter to be applied to the results of this cmdlet.

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
Name of Communication resource that this cmdlet gets.

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

### -SupportTicketName
Name of SupportTicket resource for which Communication resources are retrieved by this cmdlet.

```yaml
Type: System.String
Parameter Sets: GetByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SupportTicketObject
SupportTicket resource object for which Communication resources are retrieved by this cmdlet.

```yaml
Type: Microsoft.Azure.Commands.Support.Models.PSSupportTicket
Parameter Sets: GetByParentObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Skip
Ignores the first N results and then gets the remaining results.

```yaml
Type: System.UInt32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -First
Maximum number of results that will be returned by this cmdlet.

```yaml
Type: System.UInt32
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

### Microsoft.Azure.Commands.Support.Models.PSSupportTicket

## OUTPUTS

### Microsoft.Azure.Commands.Support.Models.PSSupportTicketCommunication

## NOTES

## RELATED LINKS
