---
external help file: Az.VMware-help.xml
Module Name: Az.VMware
online version: https://learn.microsoft.com/powershell/module/Az.VMware/new-azvmwarevmplacementpolicypropertyobject
schema: 2.0.0
---

# New-AzVMwareVMPlacementPolicyPropertyObject

## SYNOPSIS
Create an in-memory object for VMPlacementPolicyProperties.

## SYNTAX

```
New-AzVMwareVMPlacementPolicyPropertyObject -AffinityType <String> -VMMember <String[]> [-DisplayName <String>]
 [-State <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for VMPlacementPolicyProperties.

## EXAMPLES

### Example 1: Create an in-memory object for VMPlacementPolicyProperties.
```powershell
New-AzVMwareVMPlacementPolicyPropertyObject -AffinityType 'Affinity' -VMMember @{"test"="test"}
```

```output
AffinityType      : Affinity
DisplayName       : 
ProvisioningState : 
State             : 
Type              : VmVm
VMMember          : {System.Collections.Hashtable}
```

Create an in-memory object for VMPlacementPolicyProperties.

## PARAMETERS

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

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.VMPlacementPolicyProperties

## NOTES

## RELATED LINKS
