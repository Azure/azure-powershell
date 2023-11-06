---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-azactiongroupemailreceiverobject
schema: 2.0.0
---

# New-AzActionGroupEmailReceiverObject

## SYNOPSIS
Create an in-memory object for EmailReceiver.

## SYNTAX

```
New-AzActionGroupEmailReceiverObject -EmailAddress <String> -Name <String> [-UseCommonAlertSchema <Boolean>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for EmailReceiver.

## EXAMPLES

### Example 1: create action group email receiver
```powershell
New-AzActionGroupEmailReceiverObject -EmailAddress user@example.com -Name user1
```

```output
EmailAddress     Name  Status UseCommonAlertSchema
------------     ----  ------ --------------------
user@example.com user1 
```

This command creates action group email receiver object.

## PARAMETERS

### -EmailAddress
The email address of this receiver.

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
The name of the email receiver.
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

### -UseCommonAlertSchema
Indicates whether to use common alert schema.

```yaml
Type: System.Boolean
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.EmailReceiver

## NOTES

## RELATED LINKS

