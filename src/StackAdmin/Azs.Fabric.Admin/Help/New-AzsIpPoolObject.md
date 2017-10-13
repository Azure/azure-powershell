---
external help file: Azs.Fabric.Admin-help.xml
Module Name: Azs.Fabric.Admin
online version: 
schema: 2.0.0
---

# New-AzsIpPoolObject

## SYNOPSIS
This resource defines the range of IP addresses from which addresses are  allocated for nodes within a subnet.

## SYNTAX

```
New-AzsIpPoolObject [[-NumberOfIpAddressesInTransition] <Int64>] [[-StartIpAddress] <String>] [[-Id] <String>]
 [[-Type] <String>] [[-Tags] <System.Collections.Generic.Dictionary`2[System.String,System.String]>]
 [[-AddressPrefix] <String>] [[-NumberOfIpAddresses] <Int64>] [[-Name] <String>] [[-Location] <String>]
 [[-EndIpAddress] <String>] [[-NumberOfAllocatedIpAddresses] <Int64>] [<CommonParameters>]
```

## DESCRIPTION
This resource defines the range of IP addresses from which addresses are  allocated for nodes within a subnet.

## EXAMPLES

## PARAMETERS

### -AddressPrefix
The address prefix.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 6
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndIpAddress
The ending Ip address.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 10
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
URI of the resource.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Region Location of resource.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 9
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the resource.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 8
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NumberOfAllocatedIpAddresses
The number of currently allocated ip addresses.

```yaml
Type: Int64
Parameter Sets: (All)
Aliases: 

Required: False
Position: 11
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -NumberOfIpAddresses
The total number of ip addresses.

```yaml
Type: Int64
Parameter Sets: (All)
Aliases: 

Required: False
Position: 7
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -NumberOfIpAddressesInTransition
The current number of ip addresses in transition.

```yaml
Type: Int64
Parameter Sets: (All)
Aliases: 

Required: False
Position: 1
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartIpAddress
The starting Ip address.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tags
List of key value pairs.

```yaml
Type: System.Collections.Generic.Dictionary`2[System.String,System.String]
Parameter Sets: (All)
Aliases: 

Required: False
Position: 5
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
Type of resource.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

