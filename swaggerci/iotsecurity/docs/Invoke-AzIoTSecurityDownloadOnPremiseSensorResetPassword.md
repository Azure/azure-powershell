---
external help file:
Module Name: Az.IoTSecurity
online version: https://docs.microsoft.com/en-us/powershell/module/az.iotsecurity/invoke-aziotsecuritydownloadonpremisesensorresetpassword
schema: 2.0.0
---

# Invoke-AzIoTSecurityDownloadOnPremiseSensorResetPassword

## SYNOPSIS
Download file for reset password of the sensor

## SYNTAX

### DownloadExpanded (Default)
```
Invoke-AzIoTSecurityDownloadOnPremiseSensorResetPassword -OnPremiseSensorName <String> -OutFile <String>
 [-SubscriptionId <String>] [-ApplianceId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Download
```
Invoke-AzIoTSecurityDownloadOnPremiseSensorResetPassword -OnPremiseSensorName <String>
 -Body <IResetPasswordInput> -OutFile <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DownloadViaIdentity
```
Invoke-AzIoTSecurityDownloadOnPremiseSensorResetPassword -InputObject <IIoTSecurityIdentity>
 -Body <IResetPasswordInput> -OutFile <String> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### DownloadViaIdentityExpanded
```
Invoke-AzIoTSecurityDownloadOnPremiseSensorResetPassword -InputObject <IIoTSecurityIdentity> -OutFile <String>
 [-ApplianceId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Download file for reset password of the sensor

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

### -ApplianceId
The appliance id of the sensor.

```yaml
Type: System.String
Parameter Sets: DownloadExpanded, DownloadViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Body
Reset password input.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.IoTSecurity.Models.Api20210201Preview.IResetPasswordInput
Parameter Sets: Download, DownloadViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.IoTSecurity.Models.IIoTSecurityIdentity
Parameter Sets: DownloadViaIdentity, DownloadViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OnPremiseSensorName
Name of the on-premise IoT sensor

```yaml
Type: System.String
Parameter Sets: Download, DownloadExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OutFile
Path to write output file to

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

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
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
Type: System.String
Parameter Sets: Download, DownloadExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.IoTSecurity.Models.Api20210201Preview.IResetPasswordInput

### Microsoft.Azure.PowerShell.Cmdlets.IoTSecurity.Models.IIoTSecurityIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


BODY <IResetPasswordInput>: Reset password input.
  - `[ApplianceId <String>]`: The appliance id of the sensor.

INPUTOBJECT <IIoTSecurityIdentity>: Identity Parameter
  - `[DeviceGroupName <String>]`: Device group name
  - `[DeviceId <String>]`: Device Id
  - `[Id <String>]`: Resource identity path
  - `[IotDefenderLocation <String>]`: Defender for IoT location
  - `[OnPremiseSensorName <String>]`: Name of the on-premise IoT sensor
  - `[Scope <String>]`: Scope of the query (IoT Hub, /providers/Microsoft.Devices/iotHubs/myHub)
  - `[SensorName <String>]`: Name of the IoT sensor
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

