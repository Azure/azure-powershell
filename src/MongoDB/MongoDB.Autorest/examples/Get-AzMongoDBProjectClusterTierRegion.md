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

Returns the supported Azure regions for each cluster tier (FREE, FLEX, M10, M30) available to the given project. Use this before calling `New-AzMongoDBCluster` to pick a valid `-RegionName` for the chosen `-ClusterTier`.
