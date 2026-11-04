### Example 1: List the runs of a drill
```powershell
Get-AzResiliencyDrillRun -ServiceGroupName contoso-sg -DrillName contoso-zonal-drill
```

Lists all runs of drill `contoso-zonal-drill`.

### Example 2: Get a drill run
```powershell
Get-AzResiliencyDrillRun -ServiceGroupName contoso-sg -DrillName contoso-zonal-drill -Name contoso-drill-run
```

Gets drill run `contoso-drill-run`.
