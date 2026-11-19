### Example 1: Get regional placement scores
```powershell
$desiredSizes = @(@{ sku = 'Standard_D2_v3' }, @{ sku = 'Standard_D4_v3' })
Invoke-AzComputePlacementScore -Location eastus -DesiredSize $desiredSizes -DesiredLocation @('eastus2', 'westus')
```

### Example 2: Get zonal placement scores
```powershell
$desiredSizes = @(@{ sku = 'Standard_D2_v3' })
Invoke-AzComputePlacementScore -Location eastus -DesiredSize $desiredSizes -DesiredCount 2 -AvailabilityZone
```
