---
external help file:
Module Name: Az.IoTCentral
online version: https://docs.microsoft.com/powershell/module/az.iotcentral/get-aziotcentralapptemplate
schema: 2.0.0
---

# Get-AzIoTCentralAppTemplate

## SYNOPSIS
Get all available application templates.

## SYNTAX

```
Get-AzIoTCentralAppTemplate [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Get all available application templates.

## EXAMPLES

### Example 1: Get all available application templates.
```powershell
Get-AzIoTCentralAppTemplate
```

```output
Description                                                                                                                                                                         Industry   ManifestId
-----------                                                                                                                                                                         --------   ----------
Digitally connect and monitor your store environment to reduce operating costs and create experiences that customers love.                                                          Retail     iotc-condition
Enable remote tracking of water consumption to reduce field operations, detect leaks in time, while empowering cities to conserve water.                                            Government iotc-consumption
Digitally manage warehouse conveyor belt system efficiency using object detection and tracking.                                                                                     Retail     iotc-distribution
Enable accurate inventory tracking and ensure shelves are always stocked.                                                                                                           Retail     iotc-inventory
Track your shipment in real-time across air, water and land with location and condition monitoring.                                                                                 Retail     iotc-logistics
Connect utility meters to gain insights into billing, forecast consumption, and proactively detect outages.                                                                         Energy     iotc-meter
Digitally connect, monitor and manage all aspects of a fully automated fulfillment center to reduce costs by eliminating downtime while increasing security and overall efficiency. Retail     iotc-mfc
Connect and manage devices for in-patient and remote monitoring to improve patient outcomes, reduce re-admissions, and manage chronic diseases.                                     Health     iotc-patient
Create an application with Azure IoT Plug and Play.                                                                                                                                            iotc-pnp-preview
Connect, monitor, and manage your solar panels and energy generation.                                                                                                               Energy     iotc-power
Improve water quality and detect issues earlier by analyzing real-time measurements across your environment.                                                                        Government iotc-quality
Monitor and manage the checkout flow inside your store to improve efficiency and reduce wait times.                                                                                 Retail     iotc-store
Use cameras as a sensor in intelligent video analytics solutions powered by Azure IoT Edge, AI, and Azure Media Services.                                                           Retail     iotc-video-analy…
Maximize efficiency in the collection of solid wastes by dispatching field operators at the right time along an optimized collection route.                                         Government iotc-waste
```

Get all available application templates.

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

### -SubscriptionId
The subscription identifier.

```yaml
Type: System.String[]
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.IoTCentral.Models.Api20211101Preview.IAppTemplate

## NOTES

ALIASES

## RELATED LINKS

