---
external help file:
Module Name: Az.VMware
online version: https://docs.microsoft.com/powershell/module/az.VMware/new-AzVMwareVmHostPlacementPolicyPropertiesObject
schema: 2.0.0
---

# New-AzVMwareVmHostPlacementPolicyPropertiesObject

## SYNOPSIS
Create an in-memory object for VmHostPlacementPolicyProperties.

## SYNTAX

```
New-AzVMwareVmHostPlacementPolicyPropertiesObject -AffinityType <AffinityType> -HostMember <String[]>
 -Type <PlacementPolicyType> -VMMember <String[]> [-DisplayName <String>] [-State <PlacementPolicyState>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for VmHostPlacementPolicyProperties.

## EXAMPLES

### Example 1: Create an in-memory object for VmHostPlacementPolicyProperties.
```powershell
New-AzVMwareVmHostPlacementPolicyPropertiesObject -AffinityType 'AntiAffinity' -HostMember @{"abc"="123"}  -Type 'VmHost' -VMMember @{"abc"="123"}
```

```output
DisplayName ProvisioningState State AffinityType HostMember                     VMMember
----------- ----------------- ----- ------------ ----------                     --------
                                    AntiAffinity {System.Collections.Hashtable} {System.Collections.Hashtable}
```

Create an in-memory object for VmHostPlacementPolicyProperties.

## PARAMETERS

### -AffinityType
placement policy affinity type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.AffinityType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName
Display name of the placement policy.

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

### -HostMember
Host members list.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -State
Whether the placement policy is enabled or disabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.PlacementPolicyState
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
placement policy type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.PlacementPolicyType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMMember
Virtual machine members list.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20211201.VMHostPlacementPolicyProperties

## NOTES

ALIASES

## RELATED LINKS

