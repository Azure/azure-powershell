---
external help file:
Module Name: Az.IoTSecurity
online version: https://learn.microsoft.com/powershell/module/az.iotsecurity/get-aziotsecuritydevice
schema: 2.0.0
---

# Get-AzIoTSecurityDevice

## SYNOPSIS
Get device

## SYNTAX

### List (Default)
```
Get-AzIoTSecurityDevice -GroupName <String> -IotDefenderLocation <String> [-SubscriptionId <String[]>]
 [-SkipToken <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzIoTSecurityDevice -GroupName <String> -Id <String> -IotDefenderLocation <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzIoTSecurityDevice -InputObject <IIoTSecurityIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get device

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

### -GroupName
Device group name

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases: DeviceGroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Device Id

```yaml
Type: System.String
Parameter Sets: Get
Aliases: DeviceId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.IoTSecurity.Models.IIoTSecurityIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IotDefenderLocation
Defender for IoT location

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkipToken
Skip token used for pagination

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.IoTSecurity.Models.IIoTSecurityIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.IoTSecurity.Models.Api20210201Preview.IDeviceModel

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IIoTSecurityIdentity>`: Identity Parameter
  - `[DeviceGroupName <String>]`: Device group name
  - `[DeviceId <String>]`: Device Id
  - `[Id <String>]`: Resource identity path
  - `[IotDefenderLocation <String>]`: Defender for IoT location
  - `[OnPremiseSensorName <String>]`: Name of the on-premise IoT sensor
  - `[Scope <String>]`: Scope of the query (IoT Hub, /providers/Microsoft.Devices/iotHubs/myHub)
  - `[SensorName <String>]`: Name of the IoT sensor
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

