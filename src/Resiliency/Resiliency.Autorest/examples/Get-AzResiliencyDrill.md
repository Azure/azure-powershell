### Example 1: List drills of a service group
```powershell
Get-AzResiliencyDrill -ServiceGroupName contoso-sg
```

Lists all drills of service group `contoso-sg`.

### Example 2: Get a drill
```powershell
Get-AzResiliencyDrill -ServiceGroupName contoso-sg -Name contoso-zonal-drill
```

Gets drill `contoso-zonal-drill`.
