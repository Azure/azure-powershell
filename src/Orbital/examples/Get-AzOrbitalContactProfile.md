### Example 1: List the specified contact Profile.
```powershell
Get-AzOrbitalContactProfile
```

```output
Name                        Location ProvisioningState ResourceGroupName
----                        -------- ----------------- -----------------
azps-orbital-contactprofile westus2  succeeded         azpstest-gp
```

List the specified contact Profile.

### Example 2: Gets the specified contact Profile in a specified resource group.
```powershell
Get-AzOrbitalContactProfile -ResourceGroupName azpstest-gp
```

```output
Name                        Location      ProvisioningState ResourceGroupName
----                        --------      ----------------- -----------------
azps-orbital-contactprofile westus2       succeeded         azpstest-gp
Sweden-contactprofile       swedencentral succeeded         azpstest-gp
```

Gets the specified contact Profile in a specified resource group.

### Example 2: Get the specified contact Profile in a specified.
```powershell
Get-AzOrbitalContactProfile -ResourceGroupName azpstest-gp -Name azps-orbital-contactprofile
```

```output
Name                        Location ProvisioningState ResourceGroupName
----                        -------- ----------------- -----------------
azps-orbital-contactprofile westus2  succeeded         azpstest-gp
```

Get the specified contact Profile in a specified.