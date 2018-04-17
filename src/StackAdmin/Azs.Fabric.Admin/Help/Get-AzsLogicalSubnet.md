---
external help file: Azs.Fabric.Admin-help.xml
Module Name: Azs.Fabric.Admin
online version: 
schema: 2.0.0
---

# Get-AzsLogicalSubnet

## SYNOPSIS
Returns a list of all logical subnets.

## SYNTAX

### List (Default)
```
Get-AzsLogicalSubnet -LogicalNetwork <String> [-Location <String>] [-ResourceGroupName <String>]
 [-Filter <String>] [-Skip <Int32>] [-Top <Int32>] [<CommonParameters>]
```

### Get
```
Get-AzsLogicalSubnet -Name <String> -LogicalNetwork <String> [-Location <String>] [-ResourceGroupName <String>]
 [<CommonParameters>]
```

### ResourceId
```
Get-AzsLogicalSubnet -ResourceId <String> [<CommonParameters>]
```

## DESCRIPTION
Returns a list of all logical subnets.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Get-AzsLogicalSubnet -ResourceGroup "System.local" -Location "local" -LogicalNetwork "00000000-2222-1111-9999-000000000001"
```

Type                                                                  Metadata Name                                 Location IsPublic
----                                                                  -------- ----                                 -------- --------
Microsoft.Fabric.Admin/fabricLocations/logicalNetworks/logicalSubnets          d8cfef2d-c0c8-4cdb-b0a8-fb1bdf3f2ad7 local    False

Get a list of all logical subnets for a given logical network and location.

### -------------------------- EXAMPLE 2 --------------------------
```
Get-AzsLogicalSubnet -ResourceGroup "System.local" -Location "local" -LogicalNetwork "00000000-2222-1111-9999-000000000001" -LogicalSubnet "d8cfef2d-c0c8-4cdb-b0a8-fb1bdf3f2ad7"
```

Type                                                                  Metadata Name                                 Location IsPublic
----                                                                  -------- ----                                 -------- --------
Microsoft.Fabric.Admin/fabricLocations/logicalNetworks/logicalSubnets          d8cfef2d-c0c8-4cdb-b0a8-fb1bdf3f2ad7 local    False

Get a specific logical subnet for a given logical network and location based on name.

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

### -LogicalNetwork
Name of the logical network.

```yaml
Type: String
Parameter Sets: List, Get
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the logical subnet.

```yaml
Type: String
Parameter Sets: Get
Aliases: 

Required: True
Position: Named
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

### Microsoft.AzureStack.Management.Fabric.Admin.Models.LogicalSubnet

## NOTES

## RELATED LINKS

