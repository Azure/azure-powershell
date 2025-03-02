---
external help file:
Module Name: Az.ScVmm
online version: https://learn.microsoft.com/powershell/module/Az.ScVmm/new-azscvmmavailabilitysetlistitemobject
schema: 2.0.0
---

# New-AzScVmmAvailabilitySetListItemObject

## SYNOPSIS
Create an in-memory object for AvailabilitySetListItem.

## SYNTAX

```
New-AzScVmmAvailabilitySetListItemObject [-Id <String>] [-Name <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AvailabilitySetListItem.

## EXAMPLES

### Example 1: Create AvailabilitySetListItem object in memory
```powershell
New-AzScVmmAvailabilitySetListItemObject -Name "test-avset" -Id "/subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.SCVMM/availabilitySets/test-avset"
```

```output
Id                                                                                                                                         Name
--                                                                                                                                         ----
/subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.SCVMM/availabilitySets/test-avset        test-avset
```

Create AvailabilitySetListItem object in memory.
Used in Update-AzScVmmVM for AvailabilitySet[].

## PARAMETERS

### -Id
Gets the ARM Id of the microsoft.scvmm/availabilitySets resource.

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

### -Name
Gets or sets the name of the availability set.

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

### Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.AvailabilitySetListItem

## NOTES

## RELATED LINKS

