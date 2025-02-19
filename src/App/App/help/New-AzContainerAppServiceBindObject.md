---
external help file: Az.App-help.xml
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/Az.App/new-azcontainerappservicebindobject
schema: 2.0.0
---

# New-AzContainerAppServiceBindObject

## SYNOPSIS
Create an in-memory object for ServiceBind.

## SYNTAX

```
New-AzContainerAppServiceBindObject [-Name <String>] [-ServiceId <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ServiceBind.

## EXAMPLES

### Example 1: Create an in-memory object for ServiceBind.
```powershell
New-AzContainerAppServiceBindObject -Name "redisService" -ServiceId "/subscriptions/{subId}/resourceGroups/azps_test_group_app/providers/Microsoft.App/containerApps/azps-containerapp-1"
```

```output
Name         ServiceId
----         ---------
redisService /subscriptions/{subId}/resourceGroups/azps_test_group_app/providers/Microsoft.App/containerApps/azps-containerapp-1
```

Create an in-memory object for ServiceBind.

## PARAMETERS

### -Name
Name of the service bind.

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

### -ServiceId
Resource id of the target service.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.ServiceBind

## NOTES

## RELATED LINKS
