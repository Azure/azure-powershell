### Example 1: List all available regions for Confluent
```powershell
Get-AzConfluentOrganizationRegion -ResourceGroupName confluent-rg -OrganizationName confluentorg-01
```

```output
Id          CloudProvider  RegionName    DisplayName
--          -------------  ----------    -----------
eastus      AZURE          eastus        East US
westus2     AZURE          westus2       West US 2
westeurope  AZURE          westeurope    West Europe
```

This command lists all available regions where Confluent resources can be deployed.

### Example 2: List regions filtered by cloud provider
```powershell
$searchFilters = @{SearchFilters = @{Cloud = "AZURE"}}
Get-AzConfluentOrganizationRegion -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -SearchFilter $searchFilters
```

This command lists regions filtered by cloud provider.

