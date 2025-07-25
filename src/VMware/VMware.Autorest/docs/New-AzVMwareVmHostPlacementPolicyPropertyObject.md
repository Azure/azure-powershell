---
external help file:
Module Name: Az.VMware
online version: https://learn.microsoft.com/powershell/module/Az.VMware/new-azvmwarevmhostplacementpolicypropertyobject
schema: 2.0.0
---

# New-AzVMwareVmHostPlacementPolicyPropertyObject

## SYNOPSIS
Create an in-memory object for VmHostPlacementPolicyProperties.

## SYNTAX

```
New-AzVMwareVmHostPlacementPolicyPropertyObject -AffinityType <String> -HostMember <String[]>
 -VMMember <String[]> [-AffinityStrength <String>] [-AzureHybridBenefitType <String>] [-DisplayName <String>]
 [-State <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for VmHostPlacementPolicyProperties.

## EXAMPLES

### Example 1: Create an in-memory object for VmHostPlacementPolicyProperties.
```powershell
New-AzVMwareVmHostPlacementPolicyPropertyObject -AffinityType 'AntiAffinity' -HostMember @{"test"="test"} -VMMember @{"test"="test"}
```

```output
AffinityStrength       : 
AffinityType           : AntiAffinity
AzureHybridBenefitType : 
DisplayName            : 
HostMember             : {System.Collections.Hashtable}
ProvisioningState      : 
State                  : 
Type                   : VmHost
VMMember               : {System.Collections.Hashtable}
```

Create an in-memory object for VmHostPlacementPolicyProperties.

## PARAMETERS

### -AffinityStrength
vm-host placement policy affinity strength (should/must).

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

### -AffinityType
placement policy affinity type.

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

### -AzureHybridBenefitType
placement policy azure hybrid benefit opt-in type.

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
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.VMHostPlacementPolicyProperties

## NOTES

## RELATED LINKS

