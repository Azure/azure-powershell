---
external help file: Az.VMware-help.xml
Module Name: Az.VMware
online version: https://learn.microsoft.com/powershell/module/az.VMware/new-AzVMwareVmHostPlacementPolicyPropertiesObject
schema: 2.0.0
---

# New-AzVMwareVmHostPlacementPolicyPropertiesObject

## SYNOPSIS
Create an in-memory object for VmHostPlacementPolicyProperties.

## SYNTAX

```
New-AzVMwareVmHostPlacementPolicyPropertiesObject -AffinityType <String> -HostMember <String[]>
 -VMMember <String[]> -Type <String> [-DisplayName <String>] [-State <String>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for VmHostPlacementPolicyProperties.

## EXAMPLES

### Example 1: Create an in-memory object for VmHostPlacementPolicyProperties.
```powershell
New-AzVMwareVmHostPlacementPolicyPropertiesObject -AffinityType 'AntiAffinity' -HostMember @{"test"="test"}  -Type 'VmHost' -VMMember @{"test"="test"}
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

### -AffinityType
placementpolicyaffinitytype.

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
Displaynameoftheplacementpolicy.

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
Hostmemberslist.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -State
Whethertheplacementpolicyisenabledordisabled.

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

### -Type
placementpolicytype.

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

### -VMMember
Virtualmachinememberslist.

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
