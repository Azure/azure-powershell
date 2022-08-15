---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.dll-Help.xml
Module Name: Az.CosmosDB
online version: https://docs.microsoft.com/powershell/module/az.cosmosdb/get-azcosmosdblocation
schema: 2.0.0
---

# Get-AzCosmosDBLocation

## SYNOPSIS
List Azure Cosmos DB locations and their properties.
Get Azure Cosmos DB location properties for a specific location.

## SYNTAX

```
Get-AzCosmosDBLocation [-Location <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
List Azure Cosmos DB locations with their location properties. It includes Location Id, Name, Type, SupportsAvailabilityZone, IsResidencyRestricted and BackupStorageRedundancies.

## EXAMPLES

### Example 1: Get Azure Cosmos DB Account Location Properties for Given Location
<!-- Skip: Output cannot be splitted from code -->
```powershell
Get-AzCosmosDBLocation -Location "Central US"

Id                                                                                                      Name       Type                           Properties
--                                                                                                      ----       ----                           ----------
subscriptionId/subscriptionId/providers/Microsoft.DocumentDB/locations/centralus/ Central US Microsoft.DocumentDB/locations Microsoft.Azure.Commands.CosmosDB.Models.PSLocationP...


Get-AzCosmosDBLocation -Location "Central US" | ConvertTo-Json
{
    "Id":  "subscriptionId/<subscriptionId>/providers/Microsoft.DocumentDB/locations/centralus/",
    "Name":  "Central US",
    "Type":  "Microsoft.DocumentDB/locations",
    "Properties":  {
                       "SupportsAvailabilityZone":  true,
                       "IsResidencyRestricted":  false,
                       "BackupStorageRedundancies":  [
                                                         "Geo",
                                                         "Zone",
                                                         "Local"
                                                     ]
                   }
}
```

### Example 2: List Azure Cosmos DB Account Locations and their properties
<!-- Skip: Output cannot be splitted from code -->
```powershell
Get-AzCosmosDBLocation

Id                                                                                                               Name                 Type                           Properties
--                                                                                                               ----                 ----                           ----------
subscriptionId/<subscriptionId>/providers/Microsoft.DocumentDB/locations/brazilsoutheast/    Brazil Southeast     Microsoft.DocumentDB/locations Microsoft.Azure.Commands.CosmosDB...
subscriptionId/<subscriptionId>/providers/Microsoft.DocumentDB/locations/centralus/          Central US           Microsoft.DocumentDB/locations Microsoft.Azure.Commands.CosmosDB...
....


Get-AzCosmosDBLocation | ConvertTo-Json
[
    {
        "Id":  "subscriptionId/<subscriptionId>/providers/Microsoft.DocumentDB/locations/brazilsoutheast/",
        "Name":  "Brazil Southeast",
        "Type":  "Microsoft.DocumentDB/locations",
        "Properties":  {
                           "SupportsAvailabilityZone":  true,
                           "IsResidencyRestricted":  false,
                           "BackupStorageRedundancies":  "Geo Local"
                       }
    },
    {
        "Id":  "subscriptionId/<subscriptionId>/providers/Microsoft.DocumentDB/locations/centralus/",
        "Name":  "Central US",
        "Type":  "Microsoft.DocumentDB/locations",
        "Properties":  {
                           "SupportsAvailabilityZone":  true,
                           "IsResidencyRestricted":  false,
                           "BackupStorageRedundancies":  "Geo Zone Local"
                       }
    },
    {
        "Id":  "subscriptionId/<subscriptionId>/providers/Microsoft.DocumentDB/locations/australiasoutheast/",
        "Name":  "Australia Southeast",
        "Type":  "Microsoft.DocumentDB/locations",
        "Properties":  {
                           "SupportsAvailabilityZone":  false,
                           "IsResidencyRestricted":  false,
                           "BackupStorageRedundancies":  "Geo Local"
                       }
    }
]
```

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
-Name of the Location in string.

```yaml
Type: System.String
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

### None

## OUTPUTS

### Microsoft.Azure.Commands.CosmosDB.Models.PSLocationGetResult

## NOTES

## RELATED LINKS
