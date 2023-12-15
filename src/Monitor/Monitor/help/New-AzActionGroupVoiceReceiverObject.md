---
external help file: Az.ActionGroup.psm1-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-azactiongroupvoicereceiverobject
schema: 2.0.0
---

# New-AzActionGroupVoiceReceiverObject

## SYNOPSIS
Create an in-memory object for VoiceReceiver.

## SYNTAX

```
New-AzActionGroupVoiceReceiverObject -CountryCode <String> -Name <String> -PhoneNumber <String>
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for VoiceReceiver.

## EXAMPLES

### Example 1: create action group voice receiver
```powershell
New-AzActionGroupVoiceReceiverObject -CountryCode 86 -Name "sample voice" -PhoneNumber 01234567890
```

```output
CountryCode Name         PhoneNumber                                                                                                   
----------- ----         -----------
86          sample voice 01234567890
```

This command creates action group voice receiver object.

## PARAMETERS

### -CountryCode
The country code of the voice receiver.

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
The name of the voice receiver.
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
The phone number of the voice receiver.

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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.VoiceReceiver

## NOTES

## RELATED LINKS
