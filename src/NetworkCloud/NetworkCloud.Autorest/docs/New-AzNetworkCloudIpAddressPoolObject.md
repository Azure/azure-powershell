---
external help file:
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/Az.NetworkCloud/new-AzNetworkCloudIpAddressPoolObject
schema: 2.0.0
---

# New-AzNetworkCloudIpAddressPoolObject

## SYNOPSIS
Create an in-memory object for IpAddressPool.

## SYNTAX

```
New-AzNetworkCloudIpAddressPoolObject -Address <String[]> -Name <String> [-AutoAssign <BfdEnabled>]
 [-OnlyUseHostIP <BfdEnabled>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for IpAddressPool.

## EXAMPLES

### Example 1: Create an in-memory object for IpAddressPool.
```powershell
New-AzNetworkCloudIpAddressPoolObject -Address @("198.51.102.0/24") -Name "pool1" -AutoAssign True -OnlyUseHostIP True 
```

```output
Address           AutoAssign Name  OnlyUseHostIP
-------           ---------- ----  -------------
{198.51.102.0/24} True       pool1 True
```

Create an in-memory object for IpAddressPool.

## PARAMETERS

### -Address
The list of IP address ranges.
Each range can be a either a subnet in CIDR format or an explicit start-end range of IP addresses.
For a BGP service load balancer configuration, only CIDR format is supported and excludes /32 (IPv4) and /128 (IPv6) prefixes.

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

### -AutoAssign
The indicator to determine if automatic allocation from the pool should occur.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.BfdEnabled
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name used to identify this IP address pool for association with a BGP advertisement.

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

### -OnlyUseHostIP
The indicator to prevent the use of IP addresses ending with .0 and .255 for this pool.
Enabling this option will only use IP addresses between .1 and .254 inclusive.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.BfdEnabled
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IPAddressPool

## NOTES

## RELATED LINKS

