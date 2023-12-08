---
external help file: Az.ActionGroup.psm1-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-azactiongroupsmsreceiverobject
schema: 2.0.0
---

# New-AzActionGroupSmsReceiverObject

## SYNOPSIS
Create an in-memory object for SmsReceiver.

## SYNTAX

```
New-AzActionGroupSmsReceiverObject -CountryCode <String> -Name <String> -PhoneNumber <String>
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for SmsReceiver.

## EXAMPLES

### Example 1: create action group sms receiver
```powershell
New-AzActionGroupSmsReceiverObject -CountryCode 86 -Name user1 -PhoneNumber '01234567890'
```

```output
CountryCode Name  PhoneNumber Status
----------- ----  ----------- ------
86          user1 01234567890
```

This command creates action group sms receiver object.

## PARAMETERS

### -CountryCode
The country code of the SMS receiver.

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

### -Name
The name of the SMS receiver.
Names must be unique across all receivers within an action group.

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

### -PhoneNumber
The phone number of the SMS receiver.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.SmsReceiver

## NOTES

## RELATED LINKS
