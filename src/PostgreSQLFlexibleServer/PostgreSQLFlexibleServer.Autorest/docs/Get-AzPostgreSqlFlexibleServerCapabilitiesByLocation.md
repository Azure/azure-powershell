---
external help file:
Module Name: Az.PostgreSqlFlexibleServer
online version: https://learn.microsoft.com/powershell/module/az.postgresqlflexibleserver/get-azpostgresqlflexibleservercapabilitiesbylocation
schema: 2.0.0
---

# Get-AzPostgreSqlFlexibleServerCapabilitiesByLocation

## SYNOPSIS
Lists the capabilities available in a given location for a specific subscription.

## SYNTAX

```
Get-AzPostgreSqlFlexibleServerCapabilitiesByLocation -LocationName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Lists the capabilities available in a given location for a specific subscription.

## EXAMPLES

### Example 1: Get PostgreSQL Flexible Server capabilities for a location
```powershell
Get-AzPostgreSqlFlexibleServerCapabilitiesByLocation -Location "East US"
```

```output
Location          : East US
SupportedVersions : {11, 12, 13, 14, 15}
SupportedSkus     : {Standard_B1ms, Standard_B2s, Standard_D2s_v3, Standard_D4s_v3}
ZoneRedundantHA   : True
GeoBackup         : True
StorageAutoGrow   : True
MaxStorageSizeGb  : 65536
```

Retrieves the available capabilities for PostgreSQL Flexible Server in the East US region.

### Example 2: Check capabilities for a different region
```powershell
Get-AzPostgreSqlFlexibleServerCapabilitiesByLocation -Location "West Europe"
```

```output
Location          : West Europe
SupportedVersions : {11, 12, 13, 14, 15}
SupportedSkus     : {Standard_B1ms, Standard_B2s, Standard_D2s_v3, Standard_D4s_v3}
ZoneRedundantHA   : True
GeoBackup         : True
StorageAutoGrow   : True
MaxStorageSizeGb  : 65536
```

Retrieves the available capabilities for PostgreSQL Flexible Server in the West Europe region.

## PARAMETERS

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

### -LocationName
The name of the location.

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

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapability

## NOTES

## RELATED LINKS

