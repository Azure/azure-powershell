---
external help file:
Module Name: Az.Support
online version: https://learn.microsoft.com/powershell/module/az.support/new-azsupportcommunicationsnosubscription
schema: 2.0.0
---

# New-AzSupportCommunicationsNoSubscription

## SYNOPSIS
Adds a new customer communication to an Azure support ticket.

## SYNTAX

```
New-AzSupportCommunicationsNoSubscription -CommunicationName <String> -SupportTicketName <String>
 -Body <String> -Subject <String> [-Sender <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Adds a new customer communication to an Azure support ticket.

## EXAMPLES

### Example 1: Create a new communication under a no subscription ticket
```powershell
New-AzSupportCommunicationsNoSubscription -SupportTicketName test1234 -Name testCommunication2 -Subject test -Body test
```

```output
Body                   : <pre>test</pre>
CommunicationDirection : Inbound
CommunicationType      : Web
CreatedDate            : 3/11/2024 2:21:32 PM
Id                     : /providers/Microsoft.Support/supportTickets/test-7d6ad184-eb1d-40b1-ae43-5b4312b702d4/communications/33445ea3-b
                         2df-ee11-904d-00224835ac0b
Name                   : 33445ea3-b2df-ee11-904d-00224835ac0b
ResourceGroupName      :
Sender                 : bhshah@TestTest06172019GBL.onmicrosoft.com
Subject                : test - TrackingID#2403070040015890
Type                   : Microsoft.Support/communications
```

Create a new communication under a no subscription ticket

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

### -Body
Body of the communication.

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

### -CommunicationName
Communication name.

```yaml
Type: System.String
Parameter Sets: (All)
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

### -Sender
Email address of the sender.
This property is required if called by a service principal.

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

### -Subject
Subject of the communication.

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

### -SupportTicketName
Support ticket name.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ICommunicationDetails

## NOTES

## RELATED LINKS

