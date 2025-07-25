---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-azactiongrouplogicappreceiverobject
schema: 2.0.0
---

# New-AzActionGroupLogicAppReceiverObject

## SYNOPSIS
Create an in-memory object for LogicAppReceiver.

## SYNTAX

```
New-AzActionGroupLogicAppReceiverObject -CallbackUrl <String> -Name <String> -ResourceId <String>
 [-UseCommonAlertSchema <Boolean>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for LogicAppReceiver.

## EXAMPLES

### Example 1: create action group logic app receiver
```powershell
New-AzActionGroupLogicAppReceiverObject -CallbackUrl "https://p*****7w" -Name "sample logic app" -ResourceId "/subscriptions/{subId}/resourceGroups/LogicApp/providers/Microsoft.Logic/workflows/testLogicApp"
```

```output
CallbackUrl      Name             ResourceId
-----------      ----             ----------
https://p*****7w sample logic app /subscriptions/{subId}/resourceGroups/LogicApp/provid…
```

This command creates action group logic app receiver object.

## PARAMETERS

### -CallbackUrl
The callback url where http request sent to.

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
The name of the logic app receiver.
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

### -ResourceId
The azure resource id of the logic app receiver.

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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.LogicAppReceiver

## NOTES

## RELATED LINKS

