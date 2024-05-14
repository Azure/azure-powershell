---
external help file: Az.Support-help.xml
Module Name: Az.Support
online version: https://learn.microsoft.com/powershell/module/az.support/get-azsupportcommunicationsnosubscription
schema: 2.0.0
---

# Get-AzSupportCommunicationsNoSubscription

## SYNOPSIS
Returns communication details for a support ticket.

## SYNTAX

### List (Default)
```
Get-AzSupportCommunicationsNoSubscription -SupportTicketName <String> [-Filter <String>] [-Top <Int32>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentitySupportTicket
```
Get-AzSupportCommunicationsNoSubscription -CommunicationName <String>
 -SupportTicketInputObject <ISupportIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzSupportCommunicationsNoSubscription -CommunicationName <String> -SupportTicketName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSupportCommunicationsNoSubscription -InputObject <ISupportIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Returns communication details for a support ticket.

## EXAMPLES

### Example 1: List all communications under a no subscription support ticket
```powershell
Get-AzSupportCommunicationsNoSubscription -SupportTicketName test1234
```

```output
Name               Sender            Subject                                              CreatedDate
----               ------            -------                                              -----------
testCommunication1 sender@sender.com this is a test subject - TrackingID#2403070040015890 3/11/2024 3:46:43 PM
testCommunication2 sender@sender.com this is a test subject - TrackingID#2403070040015890 3/11/2024 3:46:43 PM
```

List all communications under a no subscription support ticket

### Example 2: Get a communication under a no subscription support ticket
```powershell
Get-AzSupportCommunicationsNoSubscription -SupportTicketName test1234 -Name testCommunication1
```

```output
Body                   : <pre>this is a test body</pre>
CommunicationDirection : Inbound
CommunicationType      : Web
CreatedDate            : 3/7/2024 11:53:33 PM
Id                     : /providers/Microsoft.Support/supportTickets/test1234/communications/testCommunication1
Name                   : testCommunication
ResourceGroupName      :
Sender                 : sender@sender.com
Subject                : this is a test subject - TrackingID#2403070040015890
Type                   : Microsoft.Support/communications
```

Get a communication under a no subscription support ticket

## PARAMETERS

### -CommunicationName
Communication name.

```yaml
Type: System.String
Parameter Sets: GetViaIdentitySupportTicket, Get
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

### -Filter
The filter to apply on the operation.
You can filter by communicationType and createdDate properties.
CommunicationType supports Equals ('eq') operator and createdDate supports Greater Than ('gt') and Greater Than or Equals ('ge') operators.
You may combine the CommunicationType and CreatedDate filters by Logical And ('and') operator.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

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
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
The number of values to return in the collection.
Default is 10 and max is 10.

```yaml
Type: System.Int32
Parameter Sets: List
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

### Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ISupportIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ICommunicationDetails

## NOTES

## RELATED LINKS
