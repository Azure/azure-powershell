---
external help file: Azs.Fabric.Admin-help.xml
Module Name: Azs.Fabric.Admin
online version: 
schema: 2.0.0
---

# New-AzsIpPool

## SYNOPSIS
Create an infrastructure ip pool.

## SYNTAX

```
New-AzsIpPool -StartIpAddress <String> -AddressPrefix <String> -IpPool <String> -EndIpAddress <String>
 -Location <String> [<CommonParameters>]
```

## DESCRIPTION
Create an infrastructure ip pool.

## EXAMPLES

### Example 1
```
PS C:\> New-AzsIpPool -Location "local" -StartIpAddress "192.168.1.0" -AddressPrefix "192.168.1.0/24" -IpPool "MyTestIpPool" -EndIpAddress "192.168.1.254"

NumberOfIpAddressesInTransition StartIpAddress  Type                                           AddressPrefix NumberOfIpAddresses
0                               100.10.20.30   Microsoft.Fabric.Admin/fabricLocations/ipPools               100
```

Create a new IP Pool.  

## PARAMETERS

### -AddressPrefix
The address prefix is a description of the range of ip addresses.  For example "192.168.1.0/24"

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

### -EndIpAddress
The last valid IP address in the pool.

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

### -IpPool
Ip pool name.

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

### -Location
Location of the resource.

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

### -StartIpAddress
The first valid IP address in the pool.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Fabric.Admin.Models.IpPool

## NOTES

## RELATED LINKS

