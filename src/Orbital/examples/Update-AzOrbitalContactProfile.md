### Example 1: Updates the specified contact profile tags.
```powershell
Update-AzOrbitalContactProfile -Name azps-orbital-contactprofile -ResourceGroupName azpstest-gp -Tag @{"123"="abc"}
```

```output
Name                        Location ProvisioningState ResourceGroupName
----                        -------- ----------------- -----------------
azps-orbital-contactprofile westus2  succeeded         azpstest-gp
```

Updates the specified contact profile tags.

### Example 2: Updates the specified contact profile tags.
```powershell
Get-AzOrbitalContactProfile -ResourceGroupName azpstest-gp -Name azps-orbital-contactprofile | Update-AzOrbitalContactProfile -Tag @{"123"="abc"}
```

```output
Name                        Location ProvisioningState ResourceGroupName
----                        -------- ----------------- -----------------
azps-orbital-contactprofile westus2  succeeded         azpstest-gp
```

Updates the specified contact profile tags.