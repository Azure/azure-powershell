---
external help file:
Module Name: Az.DeviceServices
online version: https://docs.microsoft.com/en-us/powershell/module/az.deviceservices/test-azdeviceservicesservicedeviceservicenameavailability
schema: 2.0.0
---

# Test-AzDeviceServicesServiceDeviceServiceNameAvailability

## SYNOPSIS
Check if a Windows IoT Device Service name is available.

## SYNTAX

### CheckExpanded (Default)
```
Test-AzDeviceServicesServiceDeviceServiceNameAvailability -Name <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Check
```
Test-AzDeviceServicesServiceDeviceServiceNameAvailability
 -DeviceServiceCheckNameAvailabilityParameter <IDeviceServiceCheckNameAvailabilityParameters>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CheckViaIdentity
```
Test-AzDeviceServicesServiceDeviceServiceNameAvailability -InputObject <IDeviceServicesIdentity>
 -DeviceServiceCheckNameAvailabilityParameter <IDeviceServiceCheckNameAvailabilityParameters>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CheckViaIdentityExpanded
```
Test-AzDeviceServicesServiceDeviceServiceNameAvailability -InputObject <IDeviceServicesIdentity>
 -Name <String> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Check if a Windows IoT Device Service name is available.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -DeviceServiceCheckNameAvailabilityParameter
Input values.
To construct, see NOTES section for DEVICESERVICECHECKNAMEAVAILABILITYPARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceServices.Models.Api20190601.IDeviceServiceCheckNameAvailabilityParameters
Parameter Sets: Check, CheckViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceServices.Models.IDeviceServicesIdentity
Parameter Sets: CheckViaIdentity, CheckViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Windows IoT Device Service to check.

```yaml
Type: System.String
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription identifier.

```yaml
Type: System.String
Parameter Sets: Check, CheckExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.DeviceServices.Models.Api20190601.IDeviceServiceCheckNameAvailabilityParameters

### Microsoft.Azure.PowerShell.Cmdlets.DeviceServices.Models.IDeviceServicesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DeviceServices.Models.Api20190601.IDeviceServiceNameAvailabilityInfo

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


DEVICESERVICECHECKNAMEAVAILABILITYPARAMETER <IDeviceServiceCheckNameAvailabilityParameters>: Input values.
  - `Name <String>`: The name of the Windows IoT Device Service to check.

INPUTOBJECT <IDeviceServicesIdentity>: Identity Parameter
  - `[DeviceName <String>]`: The name of the Windows IoT Device Service.
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: The name of the resource group that contains the Windows IoT Device Service.
  - `[SubscriptionId <String>]`: The subscription identifier.

## RELATED LINKS

