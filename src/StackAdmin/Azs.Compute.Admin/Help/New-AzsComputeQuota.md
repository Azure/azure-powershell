---
external help file: Azs.Compute.Admin-help.xml
Module Name: Azs.Compute.Admin
online version: 
schema: 2.0.0
---

# New-AzsComputeQuota

## SYNOPSIS
Create a new compute quota used to limit compute resources.

## SYNTAX

```
New-AzsComputeQuota -Name <String> [-AvailabilitySetCount <Int32>] [-CoresLimit <Int32>]
 [-VmScaleSetCount <Int32>] [-VirtualMachineCount <Int32>] [-Location <String>] [<CommonParameters>]
```

## DESCRIPTION
Create a new compute quota.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
New-AzsComputeQuota -Location local -Name testQuota5 -AvailabilitySetCount 1000 -CoresLimit 1000 -VmScaleSetCount 1000 -VirtualMachineCount 1000
```

AvailabilitySet Id              Type            CoresLimit      VmScaleSetCount Name            VirtualMachineC Location
Count                                                                                           ount
--------------- --              ----            ----------      --------------- ----            --------------- --------
1000            /subscriptio...
Microsoft.Co...
1000            1000            testQuota5      1000            local

Create a new compute quota.

## PARAMETERS

### -AvailabilitySetCount
Maximum number of availability sets allowed.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: 10
Accept pipeline input: False
Accept wildcard characters: False
```

### -CoresLimit
Maximum number of cores allowed.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: 100
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
{{Fill Location Description}}

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the quota.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualMachineCount
Maximum number of virtual machines allowed.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: 100
Accept pipeline input: False
Accept wildcard characters: False
```

### -VmScaleSetCount
Maximum number of scale sets allowed.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: 100
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Compute.Admin.Models.Quota

## NOTES

## RELATED LINKS

