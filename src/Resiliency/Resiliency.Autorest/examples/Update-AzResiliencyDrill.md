### Example 1: Update the identity of a drill
```powershell
Update-AzResiliencyDrill -ServiceGroupName contoso-sg -Name contoso-zonal-drill -EnableSystemAssignedIdentity $true
```

Enables the system-assigned managed identity on an existing drill.
