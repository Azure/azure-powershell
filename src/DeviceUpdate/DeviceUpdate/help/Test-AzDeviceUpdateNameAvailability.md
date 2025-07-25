---
external help file: Az.DeviceUpdate-help.xml
Module Name: Az.DeviceUpdate
online version: https://learn.microsoft.com/powershell/module/az.deviceupdate/test-azdeviceupdatenameavailability
schema: 2.0.0
---

# Test-AzDeviceUpdateNameAvailability

## SYNOPSIS
Checks ADU resource name availability.

## SYNTAX

### CheckExpanded (Default)
```
Test-AzDeviceUpdateNameAvailability [-SubscriptionId <String>] [-Name <String>] [-Type <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Check
```
Test-AzDeviceUpdateNameAvailability [-SubscriptionId <String>] -Request <ICheckNameAvailabilityRequest>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CheckViaJsonFilePath
```
Test-AzDeviceUpdateNameAvailability [-SubscriptionId <String>] -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CheckViaJsonString
```
Test-AzDeviceUpdateNameAvailability [-SubscriptionId <String>] -JsonString <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Checks ADU resource name availability.

## EXAMPLES

### Example 1: Checks ADU resource name availability.
```powershell
$data = New-AzDeviceUpdateCheckNameAvailabilityRequestObject -Name azpstest-account -Type "Microsoft.DeviceUpdate/accounts"
Test-AzDeviceUpdateNameAvailability -Request $data
```

```output
Message NameAvailable Reason
------- ------------- ------
        True
```

Checks ADU resource name availability.

### Example 2: Checks ADU resource name availability.
```powershell
Test-AzDeviceUpdateNameAvailability -Name azpstest-account -Type "Microsoft.DeviceUpdate/accounts"
```

```output
Message NameAvailable Reason
------- ------------- ------
        True
```

Checks ADU resource name availability.

## PARAMETERS

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

### -JsonFilePath
Path of Json file supplied to the Check operation

```yaml
Type: System.String
Parameter Sets: CheckViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Check operation

```yaml
Type: System.String
Parameter Sets: CheckViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the resource for which availability needs to be checked.

```yaml
Type: System.String
Parameter Sets: CheckExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Request
The check availability request body.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.ICheckNameAvailabilityRequest
Parameter Sets: Check
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
The Azure subscription ID.

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

### -Type
The resource type.

```yaml
Type: System.String
Parameter Sets: CheckExpanded
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.ICheckNameAvailabilityRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DeviceUpdate.Models.ICheckNameAvailabilityResponse

## NOTES

## RELATED LINKS
