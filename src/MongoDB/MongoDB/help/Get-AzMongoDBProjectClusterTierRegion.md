---
external help file: Az.MongoDB-help.xml
Module Name: Az.MongoDB
online version: https://learn.microsoft.com/powershell/module/az.mongodb/get-azmongodbprojectclustertierregion
schema: 2.0.0
---

# Get-AzMongoDBProjectClusterTierRegion

## SYNOPSIS
List available regions by cluster tier for the project.

## SYNTAX

```
Get-AzMongoDBProjectClusterTierRegion -OrganizationName <String> -ProjectName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
List available regions by cluster tier for the project.

## EXAMPLES

### Example 1: List available regions per cluster tier for a Project
```powershell
Get-AzMongoDBProjectClusterTierRegion -ResourceGroupName sharmaanuTest -OrganizationName KanedaTest -ProjectName test-project-1 | Format-List
```

```output
OrganizationId : 6a2b114e620de528f66a43eb
ProjectId      : 6a3d3a7fee32a7a117663313
RegionsByTier  : {{
                   "tier": "FLEX",
                   "regions": [ "westeurope", "eastus2", "canadacentral", "westus", "northeurope", "centralindia", "eastasia" ]
                 }, {
                   "tier": "FREE",
                   "regions": [ "eastus2", "centralindia", "westeurope", "northeurope", "westus", "canadacentral", "eastasia" ]
                 }, {
                   "tier": "M10",
                   "regions": [ "westeurope", "eastasia", "brazilsoutheast", "malaysiawest", "chilecentral", "mexicocentral", "germanywestcentral", "norwaywest", "israelcentral", "centralus", "ukwest", "northeurope", "francecentral", "northcentralus", "westindia", "centralindia", "westus", "westus2", "koreasouth", "uaecentral", "polandcentral", "swedencentral", "francesouth", "australiasoutheast", "swedensouth", "southindia", "southafricawest", "norwayeast", "canadaeast", "southeastasia", "indonesiacentral", "eastus", "eastus2", "australiaeast", "spaincentral", "uaenorth", "newzealandnorth", "canadacentral", "germanynorth", "koreacentral", "qatarcentral", "japaneast", "southafricanorth", "brazilsouth", "japanwest", "italynorth", "uksouth", "australiacentral2", "southcentralus", "westus3", "australiacentral", "westcentralus", "switzerlandnorth", "switzerlandwest" ]
                 }, {
                   "tier": "M30",
                   "regions": [ "westeurope", "eastasia", "brazilsoutheast", "malaysiawest", "chilecentral", "mexicocentral", "germanywestcentral", "norwaywest", "israelcentral", "centralus", "ukwest", "northeurope", "francecentral", "northcentralus", "westindia", "centralindia", "westus", "westus2", "koreasouth", "uaecentral", "polandcentral", "swedencentral", "francesouth", "australiasoutheast", "swedensouth", "southindia", "southafricawest", "norwayeast", "canadaeast", "southeastasia", "indonesiacentral", "eastus", "eastus2", "australiaeast", "spaincentral", "uaenorth", "newzealandnorth", "canadacentral", "germanynorth", "koreacentral", "qatarcentral", "japaneast", "southafricanorth", "brazilsouth", "japanwest", "italynorth", "uksouth", "australiacentral2", "southcentralus", "westus3", "australiacentral", "westcentralus", "switzerlandnorth", "switzerlandwest" ]
                 }}
```

Returns the supported Azure regions for each cluster tier (FREE, FLEX, M10, M30) available to the given project.
Use this before calling `New-AzMongoDBCluster` to pick a valid `-RegionName` for the chosen `-ClusterTier`.

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

### -OrganizationName
Name of the Organization resource

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

### -ProjectName
Name of the MongoDB Atlas Project resource.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

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

### Microsoft.Azure.PowerShell.Cmdlets.MongoDB.Models.IRegionsByTierResponse

## NOTES

## RELATED LINKS
