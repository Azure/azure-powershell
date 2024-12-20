---
external help file: Az.Fabric-help.xml
Module Name: Az.Fabric
online version: https://learn.microsoft.com/powershell/module/az.fabric/get-azfabriccapacitysku
schema: 2.0.0
---

# Get-AzFabricCapacitySku

## SYNOPSIS
List eligible SKUs for Microsoft Fabric resource provider

## SYNTAX

### List (Default)
```
Get-AzFabricCapacitySku [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzFabricCapacitySku [-SubscriptionId <String[]>] -CapacityName <String> -ResourceGroupName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
List eligible SKUs for Microsoft Fabric resource provider

## EXAMPLES

### Example 1: List Skus For Capacity
```powershell
Get-AzFabricCapacitySku -ResourceGroupName "testrg" -CapacityName "azsdktest" | Format-List
```

```output
ResourceType : Microsoft.Fabric/capacities
SkuName      : F16
SkuTier      : Fabric

ResourceType : Microsoft.Fabric/capacities
SkuName      : F8
SkuTier      : Fabric

ResourceType : Microsoft.Fabric/capacities
SkuName      : F64
SkuTier      : Fabric

ResourceType : Microsoft.Fabric/capacities
SkuName      : F1024
SkuTier      : Fabric

ResourceType : Microsoft.Fabric/capacities
SkuName      : F128
SkuTier      : Fabric

ResourceType : Microsoft.Fabric/capacities
SkuName      : F2
SkuTier      : Fabric

ResourceType : Microsoft.Fabric/capacities
SkuName      : F256
SkuTier      : Fabric

ResourceType : Microsoft.Fabric/capacities
SkuName      : F32
SkuTier      : Fabric

ResourceType : Microsoft.Fabric/capacities
SkuName      : F4
SkuTier      : Fabric

ResourceType : Microsoft.Fabric/capacities
SkuName      : F512
SkuTier      : Fabric

ResourceType : Microsoft.Fabric/capacities
SkuName      : F2048
SkuTier      : Fabric
```

The above command lists all eligible SKUs for the Fabric capacity named 'azsdktest' within the resource group 'testrg'

### Example 2: List Skus
```powershell
Get-AzFabricCapacitySku | Format-List
```

```output
Name  ResourceType
----  ------------
Location     : {West US}
Name         : F2
ResourceType : Capacities

Location     : {West US}
Name         : F4
ResourceType : Capacities

Location     : {West US}
Name         : F8
ResourceType : Capacities

Location     : {West US}
Name         : F16
ResourceType : Capacities

Location     : {West US}
Name         : F32
ResourceType : Capacities

Location     : {West US}
Name         : F64
ResourceType : Capacities

Location     : {West US}
Name         : F128
ResourceType : Capacities

Location     : {West US}
Name         : F256
ResourceType : Capacities

Location     : {West US}
Name         : F512
ResourceType : Capacities

Location     : {West US}
Name         : F1024
ResourceType : Capacities

Location     : {West US}
Name         : F2048
ResourceType : Capacities

Location     : {West India}
Name         : F2
ResourceType : Capacities

Location     : {West India}
Name         : F4
ResourceType : Capacities

.
.
.
```

The above command lists all eligible SKUs for Fabric resource provider

## PARAMETERS

### -CapacityName
The name of the capacity.

```yaml
Type: System.String
Parameter Sets: List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Fabric.Models.IRpSkuDetailsForExistingResource

### Microsoft.Azure.PowerShell.Cmdlets.Fabric.Models.IRpSkuDetailsForNewResource

## NOTES

## RELATED LINKS
