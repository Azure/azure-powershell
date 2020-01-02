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
Get-AzSupportTicketCommunication -SupportTicketName <String> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByParentObjectParameterSet
```
Get-AzSupportTicketCommunication [-Name <String>] -SupportTicketObject <PSSupportTicket> [-Filter <String>]
 [-Top <Int32>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByResourceIdParameterSet
```
Get-AzSupportTicketCommunication -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### NextLinkParameterSet
```
Get-AzSupportTicketCommunication [-NextLink <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Get support ticket communications. You can filter the results by *CreatedDate* or *CommunicationType* using *Filter* parameter. Output will be a paged result with *NextLink* if there are more results available. This can be used to retrieve the next page of results.


## EXAMPLES

### Example 1: Retrieve communications for a support ticket
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

Id                     : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1/c
                         ommunications/testmessage2
Type                   : Microsoft.Support/communications
CommunicationType      : Web
CommunicationDirection : Inbound
Sender                 : user@contoso.com
Subject                : test subject 2
Body                   : test message 2
CreatedDate            : 1/2/2020 1:16:05 AM
```

### Example 2: Retrieve communications for a support ticket using top parameter. Use the NextLink to retrieve the next page of communications.
```powershell
PS C:\> $a = Get-AzSupportTicketCommunication -SupportTicketName test1 -Top 1    
PS C:\> $a | fl

SupportTicketCommunicatons : {testmessage1}
NextLink                   : https://management.azure.com:443/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test1/communications?%24top=1&api-version=2019-05-01-preview&%24skipToken=xxxx
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
Parameter Sets: GetByParentObjectParameterSet, GetByNameParameterSet
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
Parameter Sets: GetByNameParameterSet, GetByParentObjectParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NextLink
The link for the next page of Communication resources to be obtained.
This value is obtained with the first Get-AzSupportTicketCommunication cmdlet call when more resources are still available to be queried.

```yaml
Type: System.String
Parameter Sets: NextLinkParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
Arm ResourceId of Communication resource that this cmdlet gets.

```yaml
Type: System.String
Parameter Sets: GetByResourceIdParameterSet
Aliases:

Required: True
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

### -Top
Max number of results that will be returned by this cmdlet.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: GetByParentObjectParameterSet, GetByNameParameterSet
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

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Support.Models.PSSupportTicketCommunication

## NOTES

## RELATED LINKS
