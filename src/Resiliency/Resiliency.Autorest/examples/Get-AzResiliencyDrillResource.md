### Example 1: List the resources of a drill
```powershell
Get-AzResiliencyDrillResource -ServiceGroupName contoso-sg -DrillName contoso-zonal-drill
```

Lists the resources included in drill `contoso-zonal-drill`.

### Example 2: Get a drill resource
```powershell
Get-AzResiliencyDrillResource -ServiceGroupName contoso-sg -DrillName contoso-zonal-drill -Name contoso-drill-resource
```

Gets a single drill resource.
