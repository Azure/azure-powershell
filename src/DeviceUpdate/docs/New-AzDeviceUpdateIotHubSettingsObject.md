---
external help file:
Module Name: Az.DeviceUpdate
online version: https://docs.microsoft.com/powershell/module/az.DeviceUpdate/new-AzDeviceUpdateIotHubSettingsObject
schema: 2.0.0
---

# New-AzDeviceUpdateIotHubSettingsObject

## SYNOPSIS
Create an in-memory object for IotHubSettings.

## SYNTAX

```
New-AzDeviceUpdateIotHubSettingsObject -ResourceId <String> [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for IotHubSettings.

## EXAMPLES

### Example 1: Create an IotHubSettings object for Instance.
```powershell
New-AzDeviceUpdateIotHubSettingsObject -ResourceId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.Devices/IotHubs/azpstest-iothub"
```

```output
ResourceId
----------
/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.Devices/IotHubs/azpstest-iothub
```

Create an IotHubSettings object for Instance.

## PARAMETERS

### -ResourceId
IoTHub resource ID.

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

### Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.Api20221001.IotHubSettings

## NOTES

ALIASES

## RELATED LINKS

