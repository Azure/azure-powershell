### Example 1: List the resources of a drill run
```powershell
Get-AzResiliencyDrillRunResource -ServiceGroupName contoso-sg -DrillName contoso-zonal-drill -DrillRunName contoso-drill-run
```

Lists the resources of drill run `contoso-drill-run`.

### Example 2: Get a drill run resource
```powershell
Get-AzResiliencyDrillRunResource -ServiceGroupName contoso-sg -DrillName contoso-zonal-drill -DrillRunName contoso-drill-run -Name contoso-drill-run-resource
```

Gets a single drill run resource.
