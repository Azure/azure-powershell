### Example 1: Returns the target resource group associated with the resource sync rules of the Custom Location that match the rules passed in with the Find Target Resource Group Request.
```powershell
Find-AzCustomLocationTargetResourceGroup -ResourceGroupName azps_test_cluster -CustomLocationName azps-customlocation -Label @{"Key1"="Value1"} -PassThru
```

```output
True
```

Returns the target resource group associated with the resource sync rules of the Custom Location that match the rules passed in with the Find Target Resource Group Request.

### Example 2: Returns the target resource group associated with the resource sync rules of the Custom Location that match the rules passed in with the Find Target Resource Group Request.
```powershell
$obj = Get-AzCustomLocation -ResourceGroupName azps_test_cluster -Name azps-customlocation
Find-AzCustomLocationTargetResourceGroup -InputObject $obj -Label @{"Key1"="Value1"} -PassThru
```

```output
True
```

Returns the target resource group associated with the resource sync rules of the Custom Location that match the rules passed in with the Find Target Resource Group Request.