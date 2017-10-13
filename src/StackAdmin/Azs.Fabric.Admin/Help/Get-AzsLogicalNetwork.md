---
external help file: Azs.Fabric.Admin-help.xml
Module Name: Azs.Fabric.Admin
online version: 
schema: 2.0.0
---

# Get-AzsLogicalNetwork

## SYNOPSIS
Get logical networks from a given location.

## SYNTAX

### LogicalNetworks_List (Default)
```
Get-AzsLogicalNetwork [-Filter <String>] [-Skip <Int32>] -Location <String> [-Top <Int32>] [<CommonParameters>]
```

### LogicalNetworks_Get
```
Get-AzsLogicalNetwork -LogicalNetwork <String> -Location <String> [<CommonParameters>]
```

## DESCRIPTION
Get logical networks from a given location.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzsLogicalNetwork -Location "local"

NetworkVirtualizationEnabled Type                                                   Metadata Name                                 Location
---------------------------- ----                                                   -------- ----                                 --------
False                        Microsoft.Fabric.Admin/fabricLocations/logicalNetworks          00000000-2222-1111-9999-000000000001 local
False                        Microsoft.Fabric.Admin/fabricLocations/logicalNetworks          47931036-2874-4d45-b1f1-b69666088968 local
False                        Microsoft.Fabric.Admin/fabricLocations/logicalNetworks          B60B71AA-36BF-40AC-A9CE-A6915D1EAE1A local
True                         Microsoft.Fabric.Admin/fabricLocations/logicalNetworks          bb6c6f28-bad9-441b-8e62-57d2be255904 local
False                        Microsoft.Fabric.Admin/fabricLocations/logicalNetworks          F207C184-367C-4BC7-8C74-03AA39D68C24 local
False                        Microsoft.Fabric.Admin/fabricLocations/logicalNetworks          f8f67956-3906-4303-94c5-09cf91e7e311 local
```

Get all logical networks at a location.

### Example 2
```
PS C:\> Get-AzsLogicalNetwork -Location "local" -LogicalNetwork "bb6c6f28-bad9-441b-8e62-57d2be255904"

True                         Microsoft.Fabric.Admin/fabricLocations/logicalNetworks          bb6c6f28-bad9-441b-8e62-57d2be255904 local
```

Get a specific logical networks at a location based on a name.

## PARAMETERS

### -Filter
OData filter parameter.

```yaml
Type: String
Parameter Sets: LogicalNetworks_List
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
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogicalNetwork
Name of the logical network.

```yaml
Type: String
Parameter Sets: LogicalNetworks_Get
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skip
Skip the first N items as specified by the parameter value.

```yaml
Type: Int32
Parameter Sets: LogicalNetworks_List
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
Parameter Sets: LogicalNetworks_List
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

### Microsoft.AzureStack.Management.Fabric.Admin.Models.LogicalNetwork

## NOTES

## RELATED LINKS

