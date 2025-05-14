---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-azactiongroupazureapppushreceiverobject
schema: 2.0.0
---

# New-AzActionGroupAzureAppPushReceiverObject

## SYNOPSIS
Create an in-memory object for AzureAppPushReceiver.

## SYNTAX

```
New-AzActionGroupAzureAppPushReceiverObject -EmailAddress <String> -Name <String> [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AzureAppPushReceiver.

## EXAMPLES

### Example 1: create action group app push receiver
```powershell
New-AzActionGroupAzureAppPushReceiverObject -EmailAddress "johndoe@email.com" -Name "Sample azureAppPush"
```

```output
EmailAddress      Name
------------      ----
johndoe@email.com Sample azureAppPush
```

This command creates action group app push receiver object.

## PARAMETERS

### -EmailAddress
The email address registered for the Azure mobile app.

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
The name of the Azure mobile app push receiver.
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.AzureAppPushReceiver

## NOTES

## RELATED LINKS

