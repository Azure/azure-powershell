---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/new-azcapacityreservation
schema: 2.0.0
---

# New-AzCapacityReservation

## SYNOPSIS
Creates a Capacity Reservation resource in a Capacity Reservation Group

## SYNTAX

```
New-AzCapacityReservation -ResourceGroupName <String> -ReservationGroupName <String> -Name <String>
 -Location <String> -CapacityToReserve <Int32> -Sku <String> [-AsJob] [-Tag <Hashtable>] [-Zone <String[]>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzCapacityReservation** cmdlet creates a Capacity Reservation resource in a Capacity Reservation Group

## EXAMPLES

### Example 1
```powershell
New-AzCapacityReservation -ResourceGroupName "myRG" -Location "eastus" -ReservationGroupName "myCapacityReservationGroup" -Name "myCapacityReservation" -Sku "Standard_DS1_v2" -CapacityToReserve 4
```

This command will create a Capacity Reservation resource with the provided sku and capacity in the Capacity Reservation Group named "myCapacityReservationGroup".

## PARAMETERS

### -AsJob
Run cmdlet in the background

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

### -CapacityToReserve
Specifies the number of virtual machines in the scale set.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Specifies the location.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Specifies the name of the capacity reservation resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: CapacityReservationName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ReservationGroupName
Specifies the name of the capacity reservation group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: CapacityReservationGroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -ResourceGroupName
Specifies the name of a resource group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Sku
SKU of the resource for which capacity needs be reserved.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Size

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
Specifies that resources and resource groups can be tagged with a set of name-value pairs. Adding tags to resources enables you to group resources together across resource groups and to create your own views. Each resource or resource group can have a maximum of 15 tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Zone
Availability Zone to use for this capacity reservation.

```yaml
Type: System.String[]
Parameter Sets: (All)
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

### System.String

### System.Int32

### System.Collections.Hashtable

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSCapacityReservation

## NOTES

## RELATED LINKS
