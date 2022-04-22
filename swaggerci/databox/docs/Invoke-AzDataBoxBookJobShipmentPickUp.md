---
external help file:
Module Name: Az.DataBox
online version: https://docs.microsoft.com/en-us/powershell/module/az.databox/invoke-azdataboxbookjobshipmentpickup
schema: 2.0.0
---

# Invoke-AzDataBoxBookJobShipmentPickUp

## SYNOPSIS
Book shipment pick up.

## SYNTAX

### BookExpanded (Default)
```
Invoke-AzDataBoxBookJobShipmentPickUp -JobName <String> -ResourceGroupName <String> -EndTime <DateTime>
 -ShipmentLocation <String> -StartTime <DateTime> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Book
```
Invoke-AzDataBoxBookJobShipmentPickUp -JobName <String> -ResourceGroupName <String>
 -ShipmentPickUpRequest <IShipmentPickUpRequest> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### BookViaIdentity
```
Invoke-AzDataBoxBookJobShipmentPickUp -InputObject <IDataBoxIdentity>
 -ShipmentPickUpRequest <IShipmentPickUpRequest> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### BookViaIdentityExpanded
```
Invoke-AzDataBoxBookJobShipmentPickUp -InputObject <IDataBoxIdentity> -EndTime <DateTime>
 -ShipmentLocation <String> -StartTime <DateTime> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Book shipment pick up.

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

### -EndTime
Maximum date before which the pick up should commence, this must be in local time of pick up area.

```yaml
Type: System.DateTime
Parameter Sets: BookExpanded, BookViaIdentityExpanded
Aliases:

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
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.IDataBoxIdentity
Parameter Sets: BookViaIdentity, BookViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JobName
The name of the job Resource within the specified resource group.
job names must be between 3 and 24 characters in length and use any alphanumeric and underscore only

```yaml
Type: System.String
Parameter Sets: Book, BookExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The Resource Group Name

```yaml
Type: System.String
Parameter Sets: Book, BookExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShipmentLocation
Shipment Location in the pickup place.
Eg.front desk

```yaml
Type: System.String
Parameter Sets: BookExpanded, BookViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShipmentPickUpRequest
Shipment pick up request details.
To construct, see NOTES section for SHIPMENTPICKUPREQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20211201.IShipmentPickUpRequest
Parameter Sets: Book, BookViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -StartTime
Minimum date after which the pick up should commence, this must be in local time of pick up area.

```yaml
Type: System.DateTime
Parameter Sets: BookExpanded, BookViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Subscription Id

```yaml
Type: System.String
Parameter Sets: Book, BookExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20211201.IShipmentPickUpRequest

### Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.IDataBoxIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20211201.IShipmentPickUpResponse

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IDataBoxIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[JobName <String>]`: The name of the job Resource within the specified resource group. job names must be between 3 and 24 characters in length and use any alphanumeric and underscore only
  - `[Location <String>]`: The location of the resource
  - `[ResourceGroupName <String>]`: The Resource Group Name
  - `[SubscriptionId <String>]`: The Subscription Id

SHIPMENTPICKUPREQUEST <IShipmentPickUpRequest>: Shipment pick up request details.
  - `EndTime <DateTime>`: Maximum date before which the pick up should commence, this must be in local time of pick up area.
  - `ShipmentLocation <String>`: Shipment Location in the pickup place. Eg.front desk
  - `StartTime <DateTime>`: Minimum date after which the pick up should commence, this must be in local time of pick up area.

## RELATED LINKS

