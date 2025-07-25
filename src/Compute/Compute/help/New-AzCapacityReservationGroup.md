---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/new-azcapacityreservationgroup
schema: 2.0.0
---

# New-AzCapacityReservationGroup

## SYNOPSIS
Creates a Capacity Reservation Group

## SYNTAX

```
New-AzCapacityReservationGroup -ResourceGroupName <String> -Name <String> -Location <String> [-AsJob]
 [-Tag <Hashtable>] [-Zone <String[]>] [-SharingProfile <String[]>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzCapacityReservationGroup** cmdlet creates a Capacity Reservation Group

## EXAMPLES

### Example 1
```powershell
New-AzCapacityReservationGroup -ResourceGroupName "myRG" -Location "eastus" -Name "myCapacityReservationGroup"
```

This command will create a Capacity Reservation Group with given properties. 

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
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Specifies the name of the capacity reservation group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: CapacityReservationGroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
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

### -SharingProfile
Allows a Capacity Reservation Group to be shared across subscriptions. Pass "" to unshare all subscriptions.  It is an array of strings; Contains an array of Arm resource ids of subscriptions eg : "/subscriptions/{subscriptionId1}", "/subscriptions/{subscriptionId2}"

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
Specifies the zone list of the virtual machine.

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

### System.Collections.Hashtable

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSCapacityReservationGroup

## NOTES

## RELATED LINKS
