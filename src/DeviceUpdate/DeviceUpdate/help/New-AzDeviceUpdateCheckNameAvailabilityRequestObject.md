---
external help file: Az.DeviceUpdate-help.xml
Module Name: Az.DeviceUpdate
online version: https://learn.microsoft.com/powershell/module/az.DeviceUpdate/new-AzDeviceUpdateCheckNameAvailabilityRequestObject
schema: 2.0.0
---

# New-AzDeviceUpdateCheckNameAvailabilityRequestObject

## SYNOPSIS
Create an in-memory object for CheckNameAvailabilityRequest.

## SYNTAX

```
New-AzDeviceUpdateCheckNameAvailabilityRequestObject [-Name <String>] [-Type <String>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for CheckNameAvailabilityRequest.

## EXAMPLES

### Example 1: Check name availability request.
```powershell
New-AzDeviceUpdateCheckNameAvailabilityRequestObject -Name azpstest-account -Type "Microsoft.DeviceUpdate/accounts"
```

```output
Name
----
azpstest-account
```

Check name availability request.

## PARAMETERS

### -Name
The name of the resource for which availability needs to be checked.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
The resource type.

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

### Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.Api30.CheckNameAvailabilityRequest

## NOTES

## RELATED LINKS
