### Example 1: Update a computefleet organization by name
```powershell
Update-AzComputeFleetOrganization -ResourceGroupName azure-rg-test -Name computefleetorg-02-pwsh -Tag @{"key01" = "value01"}
```

```output
Location Name                 Type
-------- ----                 ----
eastus   computefleetorg-02-pwsh Microsoft.ComputeFleet/organizations
```

This command updates a computefleet organization by name.

### Example 2: Update a computefleet organization by pipeline
```powershell
Get-AzComputeFleetOrganization -ResourceGroupName azure-rg-test -Name computefleetorg-02-pwsh | Update-AzComputeFleetOrganization -Tag @{"key01" = "value01"; "key02"="value02"}
```

```output
Location Name                 Type
-------- ----                 ----
eastus   computefleetorg-02-pwsh Microsoft.ComputeFleet/organizations
```

This command updates a computefleet organization by pipeline.

