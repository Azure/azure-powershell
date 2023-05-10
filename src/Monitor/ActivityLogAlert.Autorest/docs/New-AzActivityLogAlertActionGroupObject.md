---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-AzActivityLogAlertActionGroupObject
schema: 2.0.0
---

# New-AzActivityLogAlertActionGroupObject

## SYNOPSIS
Create an in-memory object for ActionGroup.

## SYNTAX

```
New-AzActivityLogAlertActionGroupObject -Id <String> [-WebhookProperty <IActionGroupWebhookProperties>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ActionGroup.

## EXAMPLES

### Example 1: Create action group object
```powershell
New-AzActivityLogAlertActionGroupObject -Id $ActionGroupResourceId -WebhookProperty @{"sampleWebhookProperty"="SamplePropertyValue"}
```

Create action group object

## PARAMETERS

### -Id
The resource ID of the Action Group.
This cannot be null or empty.

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

### -WebhookProperty
the dictionary of custom properties to include with the post operation.
These data are appended to the webhook payload.
To construct, see NOTES section for WEBHOOKPROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActivityLogAlert.Models.Api20201001.IActionGroupWebhookProperties
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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActivityLogAlert.Models.Api20201001.ActionGroup

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`WEBHOOKPROPERTY <IActionGroupWebhookProperties>`: the dictionary of custom properties to include with the post operation. These data are appended to the webhook payload.
  - `[(Any) <String>]`: This indicates any property can be added to this object.

## RELATED LINKS

