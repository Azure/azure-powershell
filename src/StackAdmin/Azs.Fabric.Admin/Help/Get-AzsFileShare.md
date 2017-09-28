---
external help file: Azs.Fabric.Admin-help.xml
Module Name: Azs.Fabric.Admin
online version: 
schema: 2.0.0
---

# Get-AzsFileShare

## SYNOPSIS
Get file shares.

## SYNTAX

### FileShares_List (Default)
```
Get-AzsFileShare [-Filter <String>] -Location <String>
```

### FileShares_Get
```
Get-AzsFileShare -FileShare <String> -Location <String>
```

## DESCRIPTION
Get file shares.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzsEdgeGatewayPool -Location "local"

GatewayCapacityKiloBitsPerSecond Type                                                    GreVipSubnet PublicIpAddress                      EdgeGateways
-------------------------------- ----                                                    ------------ ---------------                      ------------
100000000                        Microsoft.Fabric.Admin/fabricLocations/edgeGatewayPools              00000000-5555-0000-0001-000000000000 {AzS-Gwy01}
200000000                        Microsoft.Fabric.Admin/fabricLocations/edgeGatewayPools              00000000-4444-0000-0001-000000000000 {AzS-Gwy02}
```

Returns a list of all file shares.

### Example 2
```
Get-AzsEdgeGatewayPool -Location "local" -EdgeGatewayPool "AzS-Gwy01"

GatewayCapacityKiloBitsPerSecond Type                                                    GreVipSubnet PublicIpAddress                      EdgeGateways
-------------------------------- ----                                                    ------------ ---------------                      ------------
100000000                        Microsoft.Fabric.Admin/fabricLocations/edgeGatewayPools              00000000-5555-0000-0001-000000000000 {AzS-Gwy01}
```

Returns a file shares based on name.

## PARAMETERS

### -FileShare
Fabric file share name.

```yaml
Type: String
Parameter Sets: FileShares_Get
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
OData filter parameter.

```yaml
Type: String
Parameter Sets: FileShares_List
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

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Fabric.Admin.Models.FileShare

## NOTES

## RELATED LINKS

