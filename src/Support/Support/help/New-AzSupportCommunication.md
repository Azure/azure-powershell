---
external help file: Az.Support-help.xml
Module Name: Az.Support
online version: https://learn.microsoft.com/powershell/module/az.support/new-azsupportcommunication
schema: 2.0.0
---

# New-AzSupportCommunication

## SYNOPSIS
Adds a new customer communication to an Azure support ticket.

## SYNTAX

```
New-AzSupportCommunication -Name <String> -SupportTicketName <String> [-SubscriptionId <String>] -Body <String>
 -Subject <String> [-Sender <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Adds a new customer communication to an Azure support ticket.

## EXAMPLES

### Example 1: Adds communication to a support ticket at subscription level
```powershell
New-AzSupportCommunication -Name "test123" -SupportTicketName "test12345678" -Body "this is a test message from PS" -Subject "test subject" -Sender "test@test.com"
```

```output
Body                   : <pre>this is a test message from PS</pre>
CommunicationDirection : Inbound
CommunicationType      : Web
CreatedDate            : 2/22/2024 6:54:29 AM
Id                     : /subscriptions/76cb77fa-8b17-4eab-9493-b65dace99813/providers/Microsoft.Support/supportTickets
                         45678/communications/test123
Name                   : test123
ResourceGroupName      :
Sender                 : test@test.com
Subject                : test subject - TrackingID#2402220010002574
Type                   : Microsoft.Support/communications
```

Adds a new customer communication to an Azure support ticket

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

### -Name
Communication name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: CommunicationName

Required: True
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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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
