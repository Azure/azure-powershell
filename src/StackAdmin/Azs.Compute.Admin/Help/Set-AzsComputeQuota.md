---
external help file: Azs.Compute.Admin-help.xml
Module Name: Azs.Compute.Admin
online version: 
schema: 2.0.0
---

# Set-AzsComputeQuota

## SYNOPSIS
Update an existing compute quota using the provided parameters.

## SYNTAX

### Update (Default)
```
Set-AzsComputeQuota -Name <String> [-AvailabilitySetCount <Int32>] [-CoresLimit <Int32>]
 [-VmScaleSetCount <Int32>] [-VirtualMachineCount <Int32>] [-Location <String>] [<CommonParameters>]
```

### ResourceId
```
Set-AzsComputeQuota [-AvailabilitySetCount <Int32>] [-CoresLimit <Int32>] [-VmScaleSetCount <Int32>]
 [-VirtualMachineCount <Int32>] [-Location <String>] -ResourceId <String> [<CommonParameters>]
```

### InputObject
```
Set-AzsComputeQuota [-AvailabilitySetCount <Int32>] [-CoresLimit <Int32>] [-VmScaleSetCount <Int32>]
 [-VirtualMachineCount <Int32>] [-Location <String>] -InputObject <Quota> [<CommonParameters>]
```

## DESCRIPTION
Update an existing compute quota.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Set-AzsComputeQuota -Location local -Name Quota1 -CoresLimit 10
```

AvailabilitySet Id              Type            CoresLimit      VmScaleSetCount Name            VirtualMachineC Location
Count                                                                                           ount
--------------- --              ----            ----------      --------------- ----            --------------- --------
10              /subscriptio...
Microsoft.Co...
10              20              Quota1          20              local

Update a compute quota.

## PARAMETERS

### -AvailabilitySetCount
Maximum number of availability sets allowed.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -CoresLimit
Maximum number of core allowed.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Quota object.

```yaml
Type: Quota
Parameter Sets: InputObject
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
Location of the resource.

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
The name of the quota.

```yaml
Type: String
Parameter Sets: Update
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The ARM compute quota id.

```yaml
Type: String
Parameter Sets: ResourceId
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Default value: 0
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
Default value: 0
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

