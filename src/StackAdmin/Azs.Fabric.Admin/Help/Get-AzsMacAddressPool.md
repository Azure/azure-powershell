---
external help file: Azs.Fabric.Admin-help.xml
Module Name: Azs.Fabric.Admin
online version: 
schema: 2.0.0
---

# Get-AzsMacAddressPool

## SYNOPSIS
Returns a list of all MAC address pools at a location.

## SYNTAX

### List (Default)
```
Get-AzsMacAddressPool [-Location <String>] [-ResourceGroupName <String>] [-Filter <String>] [-Skip <Int32>]
 [-Top <Int32>] [<CommonParameters>]
```

### Get
```
Get-AzsMacAddressPool [-Name] <String> [-Location <String>] [-ResourceGroupName <String>] [<CommonParameters>]
```

### ResourceId
```
Get-AzsMacAddressPool -ResourceId <String> [<CommonParameters>]
```

## DESCRIPTION
Returns a list of all MAC address pools at a location.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Get-AzsMacAddressPool -ResourceGroup "System.local" -Location "local"
```

NumberOfAllocatedMacAddresses Type                                                   Metadata NumberOfAvailableMacAddresses StartMacAddress
----------------------------- ----                                                   -------- ----------------------------- ---------------
2                             Microsoft.Fabric.Admin/fabricLocations/macAddressPools          3998718                       00-1D-D8-B7-1C-00
6                             Microsoft.Fabric.Admin/fabricLocations/macAddressPools          3998718                       01-1D-D8-B7-1C-00

Get all MAC address pools at a location.

### -------------------------- EXAMPLE 2 --------------------------
```
Get-AzsMacAddressPool -ResourceGroup "System.local" -Location "local" -MacAddressPool "8197fd09-8a69-417e-a55c-10c2c61f5ee7"
```

NumberOfAllocatedMacAddresses Type                                                   Metadata NumberOfAvailableMacAddresses StartMacAddress
----------------------------- ----                                                   -------- ----------------------------- ---------------
2                             Microsoft.Fabric.Admin/fabricLocations/macAddressPools          3998718                       00-1D-D8-B7-1C-00

Get a specific MAC address pool at a location based on name.

## PARAMETERS

### -Filter
OData filter parameter.

```yaml
Type: String
Parameter Sets: List
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Location of the resource.

```yaml
Type: String
Parameter Sets: List, Get
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the MAC address pool.

```yaml
Type: String
Parameter Sets: Get
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource group in which the resource provider has been registered.

```yaml
Type: String
Parameter Sets: List, Get
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id.

```yaml
Type: String
Parameter Sets: ResourceId
Aliases: id

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Skip
Skip the first N items as specified by the parameter value.

```yaml
Type: Int32
Parameter Sets: List
Aliases: 

Required: False
Position: Named
Default value: -1
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
Return the top N items as specified by the parameter value.
Applies after the -Skip parameter.

```yaml
Type: Int32
Parameter Sets: List
Aliases: 

Required: False
Position: Named
Default value: -1
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Fabric.Admin.Models.MacAddressPool

## NOTES

## RELATED LINKS

